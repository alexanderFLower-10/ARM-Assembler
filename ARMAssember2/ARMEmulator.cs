using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ARMAssember2
{
    public class ARMEmulator
    {
        List<Instruction> instructions;
        private int PC;
        private int[] Registers;
        private int[] Memory;
        Dictionary<string, int> labelsLocations;
        string SR;
        private ConsoleDrawing DrawInstructions;
        private ConsoleDrawing DrawRegisters;
        private ConsoleDrawing DrawMemory;
        private string[] rawInstructions;
        private int keyBindsXIndex;
        private string[] keybinds;
        int maxLines;
        private int largestStorage;
        private string filepath;
        public ARMEmulator(List<Instruction> instructions, string[] rawInstructions, string filepath, int PC = 0, int RegistersCap = 16, int MemoryCap = 16 )
        {
            this.filepath = filepath;
            List<Instruction> tempInstList = new List<Instruction> ();
            if(instructions!= null)
                
            {
                this.instructions = instructions;
                for (int i = 0; i < instructions.Count; i++)
                {
                    tempInstList.Add(instructions[i]);
                }
                Registers = new int[RegistersCap];
                Memory = new int[MemoryCap];
                this.PC = PC;
                this.instructions = instructions;
                labelsLocations = new Dictionary<string, int>();
                SR = "N/A";
                for (int i = 0; i < instructions.Count; i++)
                {
                    if (instructions[i].GetType() == typeof(Label))
                    {
                        Label temp = (Label)instructions[i];
                        string labelname = temp.getLabel();
                        if (!labelsLocations.ContainsKey(labelname))
                        {
                            labelsLocations.Add(labelname, i);
                        }
                        else throw new Exception("Label name in use");
                    }
                }
            }

            this.rawInstructions = rawInstructions;
            if(rawInstructions != null)
            {
                DrawInstructions = new ConsoleDrawing(rawInstructions, 35, 1, "ASSEMBLY PROGRAM:", ConsoleColor.Blue);
                int max = 0;
                for (int i = 0; i < rawInstructions.Length; i++)
                {
                    if (rawInstructions[i].Length > max) max = rawInstructions[i].Length;
                }
                keyBindsXIndex = max + 41;
                keybinds = buildsKeyBinds();
                maxLines = rawInstructions.Length - 1;
                if (Memory.Length > Registers.Length) largestStorage = Memory.Length;
                else largestStorage = Registers.Length;
            }

        }



        public string[] enterIDE()
        {
            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            string[] inst;
            int xpos, index;
            ConsoleDrawing kbdraw;

            if (rawInstructions!= null)
            {
                inst = rawInstructions;
                kbdraw = new ConsoleDrawing(new string[] { "Backspace + Space + Arrows - Self explainatory", "Esc - Exit and dont save ", "Tab - Exit and save", "F1 - Caps lock" }, keyBindsXIndex, 1, "KEYBINDS:", ConsoleColor.Yellow);
                kbdraw.Draw();
                Console.SetCursorPosition(0, 0);
                foreach (string s in inst)
                {
                    Console.WriteLine(s);
                }
                index = inst.Length - 1;
                xpos = inst[inst.Length - 1].Length;
                Console.SetCursorPosition(xpos, index);
            }
            else
            {
                inst = new string[1];
                xpos = 0;
                index = 0;
                kbdraw = new ConsoleDrawing(new string[] { "Backspace + Space + Arrows + Delete - Self explainatory", "Esc - Exit and dont save ", "Tab - Exit and save", "F1 - Caps lock" }, 60, 1, "KEYBINDS:", ConsoleColor.Yellow);
                kbdraw.Draw();
                Console.SetCursorPosition(xpos, index);
            }


            bool caps = false;
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.DownArrow)
                {
                    if (index < inst.Length - 1)
                    {
                        index++;
                        if (xpos >= inst[index].Length)
                        {
                            Console.SetCursorPosition(inst[index].Length, index);
                            xpos = inst[index].Length;
                        }
                        else
                        {
                            Console.SetCursorPosition(xpos, index);
                        }
                        Console.SetCursorPosition(xpos, index);
                    }
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    if (index > 0)
                    {
                        index--;
                        if (xpos >= inst[index].Length)
                        {
                            Console.SetCursorPosition(inst[index].Length, index);
                            xpos = inst[index].Length;
                        }
                        else
                        {
                            Console.SetCursorPosition(xpos, index);
                        }
                        Console.SetCursorPosition(xpos, index);
                    }
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    if (Console.CursorLeft - 1 >= 0)
                    {
                        xpos--;
                        Console.SetCursorPosition(xpos, index);
                    }
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    if (!(Console.CursorLeft + 1 > inst[index].Length))
                    {
                        xpos++;
                        Console.SetCursorPosition(xpos, index);
                    }
                }
                else if (key == ConsoleKey.Spacebar)
                {
                    if (inst[index] != null)
                    {
                        inst[index] = inst[index].Substring(0, xpos) + " " + inst[index].Substring(inst[index].Length - (inst[index].Length - xpos));
                    }
                    else
                    {
                        inst[index] = " ";
                    }

                    Console.SetCursorPosition(0, index);
                    Console.Write(inst[index]);
                    xpos++;
                    Console.SetCursorPosition(xpos, index);
                }
                else if (key == ConsoleKey.Backspace)
                {
                    if (xpos != 0)
                    {
                        inst[index] = inst[index].Substring(0, xpos - 1) + inst[index].Substring(xpos);
                        Console.SetCursorPosition(0, index);
                        Console.Write(inst[index] + " ");
                        xpos--;
                        Console.SetCursorPosition(xpos, index);
                    }
                }
                else if (key == ConsoleKey.D1 || key == ConsoleKey.D2 || key == ConsoleKey.D3 || key == ConsoleKey.D4 || key == ConsoleKey.D5 || key == ConsoleKey.D6 || key == ConsoleKey.D7 || key == ConsoleKey.D8 || key == ConsoleKey.D9 || key == ConsoleKey.D0 )
                {
                    if (inst[index] != null)
                    {

                        inst[index] = inst[index].Substring(0, xpos) + key.ToString().Substring(1) + inst[index].Substring(inst[index].Length - (inst[index].Length - xpos));

                    }
                    else
                    {
                        inst[index] = key.ToString().Substring(1);
                    }

                    Console.SetCursorPosition(0, index);
                    Console.Write(inst[index]);
                    xpos++;
                    Console.SetCursorPosition(xpos, index);
                }
                else if(key == ConsoleKey.OemComma)
                {
                    if (inst[index] != null)
                    {

                            inst[index] = inst[index].Substring(0, xpos) + "," + inst[index].Substring(inst[index].Length - (inst[index].Length - xpos));

                    }
                    else
                    {
                        inst[index] = ",";
                    }

                    Console.SetCursorPosition(0, index);
                    Console.Write(inst[index]);
                    xpos++;
                    Console.SetCursorPosition(xpos, index);
                }
                else if (key == ConsoleKey.Oem7)
                {
                    if (inst[index] != null)
                    {

                        inst[index] = inst[index].Substring(0, xpos) + "#" + inst[index].Substring(inst[index].Length - (inst[index].Length - xpos));

                    }
                    else
                    {
                        inst[index] = "#";
                    }

                    Console.SetCursorPosition(0, index);
                    Console.Write(inst[index]);
                    xpos++;
                    Console.SetCursorPosition(xpos, index);
                }
                else if (key == ConsoleKey.Oem1)
                {
                    if (inst[index] != null)
                    {

                        inst[index] = inst[index].Substring(0, xpos) + ":" + inst[index].Substring(inst[index].Length - (inst[index].Length - xpos));

                    }
                    else
                    {
                        inst[index] = ":";
                    }

                    Console.SetCursorPosition(0, index);
                    Console.Write(inst[index]);
                    xpos++;
                    Console.SetCursorPosition(xpos, index);
                }
                else if (key == ConsoleKey.F1)
                {
                    if (caps) caps = false;
                    else caps = true;
                }
                else if (key == ConsoleKey.Delete)
                {
                    if (xpos != inst[index].Length)
                    {
                        inst[index] = inst[index].Substring(0, xpos) + inst[index].Substring(xpos+1);
                        Console.SetCursorPosition(0, index);
                        Console.Write(inst[index] + " ");
                        Console.SetCursorPosition(xpos, index);
                    }
                }
                else if (key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    return this.rawInstructions;
                }
                else if (key == ConsoleKey.Tab)
                {
                    Console.CursorVisible = false;
                    return inst;
                }
                else if (key == ConsoleKey.Enter)
                {
                    string[] temp = new string[inst.Length+1];
                    for(int i = 0; i <= index; i++)
                    {
                        temp[i] = inst[i];
                    }
                    temp[index + 1] = "";
                    for(int i = index + 2; i < temp.Length; i++)
                    {
                        temp[i] = inst[i - 1];
                    }
                    Console.Clear();
                    foreach (string s in temp)
                    {
                        Console.WriteLine(s);
                    }
                    kbdraw.Draw();
                    xpos = 0;
                    index++;
                    Console.SetCursorPosition (xpos, index);
                    inst = temp;    
                }
                else
                {
                    if (inst[index] != null)
                    {
                        if (caps)
                        {
                            inst[index] = inst[index].Substring(0, xpos) + key.ToString().Substring(0, 1) + inst[index].Substring(inst[index].Length - (inst[index].Length - xpos));
                        }
                        else
                        {
                            inst[index] = inst[index].Substring(0, xpos) + key.ToString().ToLower().Substring(0, 1) + inst[index].Substring(inst[index].Length - (inst[index].Length - xpos));
                        }
                    }
                    else
                    {
                        if (caps)
                        {
                            inst[index] = key.ToString().Substring(0, 1);

                        }
                        else
                        {
                            inst[index] = key.ToString().ToLower().Substring(0, 1);
                        }
                    }


                    Console.SetCursorPosition(0, index);
                    Console.Write(inst[index]);
                    xpos++;
                    Console.SetCursorPosition(xpos, index);
                }
            }
        }
        public string getFilePath()
        {
            return filepath;
        }
        public void Reset()
        {
            for(int i = 0; i < Registers.Length; i++)
            {
                Registers[i] = 0;
                Memory[i] = 0;
            }
            PC = 0;
            SR = "N/A";
        }

        public int getMaxLines() { return maxLines; }

        private string[] buildsKeyBinds()
        {
            string[] keybinds = new string[9];
            keybinds[0] = "SpaceBar - Step 1 Instructions";
            keybinds[1] = "Enter - Run Whole Program";
            keybinds[2] = "M - Manually edit memory location";
            keybinds[3] = "R - Manually edit register location";
            keybinds[4] = "J - Jump to line number";
            keybinds[5] = "Q - Run program to line number";
            keybinds[6] = "Backspace - Go back a line";
            keybinds[7] = "Shift - Reset program";
            keybinds[8] = "I - Edit Program";
            return keybinds;


        }
        public string[] getRawInst()
        {
            return rawInstructions;
        }
        
        public int getMemorylength() { return Memory.Length; }  
        public int getRegisterLength() { return Registers.Length; }
        public void drawBlankInputBox()
        {
            string[] str = new string[1];
            str[0] = "                                   "; 
            ConsoleDrawing inpdraw = new ConsoleDrawing(str , keyBindsXIndex, 12, "INPUT:", ConsoleColor.Green);
            inpdraw.Draw();
            Console.SetCursorPosition(keyBindsXIndex + 38, 12);
            Console.Write("╣");
            Console.SetCursorPosition(keyBindsXIndex, 12);
            Console.Write("╠");

        }
        public void displayGUI(string errorOrMsg = "")
        {    
            DrawInstructions.DrawAndHighlightLineNumber(PC);
            drawRegisters();
            drawMemoryAdds();
            drawSR();
            drawPC();
            drawError();
            drawEscthing();
            drawKeybinds();
            drawBlankInputBox();

            drawCorners();
        }
        public int getKeyBindsX()
        {
            return keyBindsXIndex;
        }
        private void drawKeybinds()
        {
            ConsoleDrawing kbdraw = new ConsoleDrawing(keybinds, keyBindsXIndex, 1, "KEYBINDS:", ConsoleColor.Yellow);
            kbdraw.Draw();
        }

        private void drawSR()
        {
            string[] temp = new string[1];
            temp[0] = SR;
            ConsoleDrawing statusdraw = new ConsoleDrawing(temp , 2, largestStorage+3, "SR:", ConsoleColor.Yellow);
            statusdraw.DrawCentrally();
        }
        private void drawPC()
        {
            string[] temp = new string[1];
            temp[0] = PC.ToString(); ;
            ConsoleDrawing PCdraw = new ConsoleDrawing(temp, 8, largestStorage+3, "PC: ", ConsoleColor.Yellow);
            PCdraw.DrawCentrally();
        }
        public void drawError(string error = null)
        {
            ConsoleDrawing Errors = new ConsoleDrawing(new string[] { " " }, 0,0);
            if (error != null)
            {
                if(error.Length > 30)
                {
                    string[] arr = new string[7];
                    string[] temp = error.Split(' ');
                    int current = 0;
                    for(int i = 0; i < temp.Length; i++)
                    {
                        if (arr[current] != null)
                        {
                            if (temp[i].Length + arr[current].Length > 30)
                            {
                                current++;
                                arr[current] = temp[i];
                            }
                            else arr[current] += " " + temp[i]; 
                        }
                        else arr[current] = temp[i];    

                    }
                    current++;
                    if(current < 7)
                    {
                        for(int i = current; i < 7; i++)
                        {
                            arr[i] = " ";
                        }
                    }
                    Errors = new ConsoleDrawing(arr, 2, largestStorage + 6, "ERRORS:                       ", ConsoleColor.Red);
                }
            }
            else
            {
                string[] boxed = new string[7];
                for (int i = 0; i < 7; i++)
                {
                    string temp = "";
                    for (int j = 0; j < 30; j++)
                    {
                        temp += " ";
                    }
                    boxed[i] = temp;
                }
                Errors = new ConsoleDrawing(boxed, 2, largestStorage + 6, "ERRORS:", ConsoleColor.Red);
            }
            Errors.Draw();
            drawCorners();
        }
        public int getInputXIndex() { return keyBindsXIndex; }

        private void drawCorners()
        {
            Console.SetCursorPosition(2, 19 + (largestStorage-16));
            Console.Write("╠");
            Console.SetCursorPosition(8, 19 + (largestStorage - 16));
            Console.Write("╦");
            Console.SetCursorPosition(8, 22 + (largestStorage - 16));
            Console.Write("╩");
            Console.SetCursorPosition(15, 19 + (largestStorage - 16));
            Console.Write("╬");
            Console.SetCursorPosition(15, 1);
            Console.Write("╦");
            Console.SetCursorPosition(2, 22 + (largestStorage - 16));
            Console.Write("╠");
            Console.SetCursorPosition(15, 22 + (largestStorage - 16));
            Console.Write("╩");
            Console.SetCursorPosition(35, 19 + (largestStorage - 16));
            Console.Write("╣");
            Console.SetCursorPosition(35, 22 + (largestStorage - 16));
            Console.Write("╣");
            Console.SetCursorPosition(35, 1);
            Console.Write("╦");
            Console.SetCursorPosition(keyBindsXIndex, 11);
            Console.Write("╠");
            Console.SetCursorPosition(keyBindsXIndex, rawInstructions.Length + 3);
            Console.Write("╣");
            Console.SetCursorPosition(keyBindsXIndex+38, 11);
            Console.Write("╣");
            if (rawInstructions.Length + 3 <= 28)
            {
                Console.SetCursorPosition(35, rawInstructions.Length + 3);
                if (rawInstructions.Length + 3 == 19 || rawInstructions.Length + 3 == 22)
                {
                    Console.Write("╬");
                }
                else if (rawInstructions.Length + 3 == 28)
                {
                    Console.Write("╩");
                }
                else
                {
                    Console.Write("╠");
                }
            }
            else
            {
                Console.SetCursorPosition(35, 29);
                Console.Write("╣");
                
                   
                
            }
            Console.SetCursorPosition(keyBindsXIndex, 1);
            Console.Write("╦");

        }
        private void drawEscthing()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.SetCursorPosition(16, largestStorage + 4);
            Console.Write(" Press esc to exit");
            Console.SetCursorPosition(16, largestStorage + 5);
            Console.Write(" the assembler");
            Console.ForegroundColor = ConsoleColor.Gray;


            Console.SetCursorPosition(35, largestStorage + 4);
            Console.Write("║");
            Console.SetCursorPosition(35, largestStorage + 5);
            Console.Write("║");


        }
        private void drawRegisters()
        {
            string[] regs = new string[Registers.Length];
            for (int i = 0; i < regs.Length; i++)
            {
                if (i >= 10) regs[i] = $"R{i}: {Registers[i]}";
                else regs[i] = $"R{i}:  {Registers[i]}";
            }
            DrawRegisters = new ConsoleDrawing(regs, 2, 1, "REGISTERS:", ConsoleColor.Magenta);
            DrawRegisters.Draw();
        }

        private void drawMemoryAdds()
        {
            string[] mems = new string[Memory.Length];
            for (int i = 0; i < Memory.Length; i++)
            {
                if (i >= 10) mems[i] = $"{i}: {Memory[i]}";
                else mems[i] = $"{i}:  {Memory[i]}";
            }

            DrawMemory = new ConsoleDrawing(mems, 15, 1, "MEMORY LOCATIONS:", ConsoleColor.Cyan);
            DrawMemory.Draw();

        }
        public void Step()
        {
            if (instructions[PC].GetType() == typeof(HALT))
            {
                HALT();
            }
            else if (instructions[PC].GetType() == typeof(Label))
            {
               // pass on labels
            }
            else if(instructions[PC].GetType() == typeof(ThreeParameterInst))
            {
                Dictionary<string, Type> ThreeParInstMap = new Dictionary<string, Type>()
                {
                    {"ADD", typeof(ADD) },
                    {"SUB", typeof(SUB) },
                    {"AND", typeof(AND) },
                    {"ORR", typeof(ORR) },
                    {"EOR", typeof(EOR) },
                    {"LSL", typeof(LSL) },
                    {"LSR", typeof(LSR) }
                };
                ThreeParameterInst current = (ThreeParameterInst) instructions[PC];
                ThreeParameterInst Current = current.Clone();
                string addressingType = Current.getAddressingType();
                int baseOperand = Current.getOperand2();
                string instType = Current.GetInstType();
                if(addressingType == "im")
                {
                    // nothing to be done as operand 2 already set properly in constructor
                }
                else if (addressingType == "dr")
                {
                    Current.setOperand2(Registers[Current.getOperand2()]);
                }
                else if (addressingType == "dm")
                {
                    Current.setOperand2(Memory[Current.getOperand2()]);
                }
                else if (addressingType == "indr")
                {
                    Current.setOperand2(Memory[Registers[Current.getOperand2()]]);
                }

                if (ThreeParInstMap.ContainsKey(instType))
                {
                    ThreeParameterExecutes inst = (ThreeParameterExecutes)Activator.CreateInstance(ThreeParInstMap[instType]);
                    inst.Execute(this, Current);
                }
                else
                {
                    throw new Exception($"You forgot to implement the inst map for the inst type {instType}");
                }
            }
            else if (instructions[PC].GetType() == typeof(TwoParameterInst))
            {
                Dictionary<string, Type> TwoParInstMap = new Dictionary<string, Type>()
                {
                    {"LDR", typeof(LDR) },
                    {"STR", typeof(STR) },
                    {"MOV", typeof(MOV) },
                    {"MVN", typeof(MVN) },
                };
                TwoParameterInst current = (TwoParameterInst)instructions[PC];
                TwoParameterInst Current = current.Clone();
                string addressingType = Current.getAddressingType();
                int baseOperand = Current.getOperand2();
                string instType = Current.GetInstType();
                if (instType != "STR")
                {
                    if (addressingType == "im")
                    {
                        // nothing to be done as operand 2 already set properly in constructor
                    }
                    else if (addressingType == "dr")
                    {
                        Current.setOperand2(Registers[Current.getOperand2()]);
                    }
                    else if (addressingType == "dm")
                    {
                        Current.setOperand2(Memory[Current.getOperand2()]);
                    }
                    else if (addressingType == "indr")
                    {
                        Current.setOperand2(Memory[Registers[Current.getOperand2()]]);
                    }
                }
            
            



                if (TwoParInstMap.ContainsKey(instType))
                {
                    TwoParameterExecutes inst = (TwoParameterExecutes)Activator.CreateInstance(TwoParInstMap[instType]);
                    inst.Execute(this, Current);
                }
                else
                {
                    throw new Exception($"You forgot to implement the inst map for the inst type {instType}");
                }
            }
            else if(instructions[PC].GetType() == typeof(CompareInst))
            {
                CompareInst Current = (CompareInst)instructions[PC];
                CMP compare = new CMP();
                compare.Execute(this, Current);
            }
            else if (instructions[PC].GetType() == typeof(BranchesInst))
            {
                BranchesInst Current = (BranchesInst)instructions[PC];
                string label = Current.getLabel();
                string condition = Current.getCondition();
                if (condition == "R")
                {
                    if (labelsLocations.ContainsKey(label))
                    {
                        PC = labelsLocations[label];
                    }
                    else throw new Exception("Label doesn't exist");

                }
                else if (condition == "EQ")
                {
                    if (SR == "EQ")
                    {
                        if (labelsLocations.ContainsKey(label))
                        {
                            PC = labelsLocations[label];
                        }
                        else throw new Exception("Label doesn't exist");
                    }
                }
                else if (condition == "LT")
                {
                    if (SR == "LT")
                    {
                        if (labelsLocations.ContainsKey(label))
                        {
                            PC = labelsLocations[label];
                        }
                        else throw new Exception("Label doesn't exist");
                    }
                }
                else if (condition == "GT")
                {
                    if (SR == "GT")
                    {
                        if (labelsLocations.ContainsKey(label))
                        {
                            PC = labelsLocations[label];
                        }
                        else throw new Exception("Label doesn't exist");
                    }
                }
                else if (condition == "NE")
                {
                    if (SR != "EQ")
                    {
                        if (labelsLocations.ContainsKey(label))
                        {
                            PC = labelsLocations[label];
                        }
                        else throw new Exception("Label doesn't exist");
                    }
                }
            }
            PC++;
        }

        public void HALT()
        {
            throw new HALTException("Program halted.");
        }
        public string getSR() { return SR; }
        public void setSR(string s) { SR = s + " "; }
        public int GetRegisterVal(int index) { return Registers[index]; }   
        public int GetMemoryVal(int index) {return Memory[index]; }

        public void SetRegisterVal(int index, int val) { Registers[index] = val; }
        public void SetMemoryVal(int index, int val) { Memory[index] = val; }
        public void SetPC(int value) { PC = value; }

        public int GetPC() 
        {
            return PC;
        }
    }
}
