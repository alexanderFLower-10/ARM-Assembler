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

        public ARMEmulator(List<Instruction> instructions, string[] rawInstructions, int PC = 0, int RegistersCap = 16, int MemoryCap = 16)
        {
            this.rawInstructions = rawInstructions;
            Registers = new int[RegistersCap];
            Memory = new int[MemoryCap];
            this.PC = PC;
            this.instructions = instructions;
            labelsLocations = new Dictionary<string, int>();
            for(int i = 0; i < instructions.Count; i++)
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
            if(rawInstructions != null)
            {
                DrawInstructions = new ConsoleDrawing(rawInstructions, 63, 1, "ASSEMBLY PROGRAM:", ConsoleColor.Blue);
            }

        }

        public void displayGUI(string errorOrMsg = "")
        {    
            //first draw the program and register boxes
            DrawInstructions.Draw();
            string[] regs = new string[Registers.Length];
            for(int i = 0; i <  regs.Length; i++)
            {
                if(i >= 10) regs[i] = $"R{i}: {Registers[i}}";
                else regs[i] = $"R{i}:  {Registers[i]}";
                i++;
            }
            DrawRegisters = new ConsoleDrawing(regs, 2, 1, "REGISTERS:", ConsoleColor.Magenta);
            DrawRegisters.Draw();
            string[] mems = new string[Memory.Length];
            for (int i = 0; i < Memory.Length; i++)
            {
                if (i >= 10) mems[i] = $"{i}: {Memory[i]}";
                else mems[i] = $"{i}:  {Memory[i]}";
            }

            DrawMemory = new ConsoleDrawing(mems,20, 1, "MEMORY LOCATIONS:",  ConsoleColor.Cyan);
            DrawMemory.Draw();

            //Then must box the menu and add an errors box
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
                ThreeParameterInst Current = (ThreeParameterInst) instructions[PC];
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
                TwoParameterInst Current = (TwoParameterInst)instructions[PC];
                string addressingType = Current.getAddressingType();
                int baseOperand = Current.getOperand2();
                string instType = Current.GetInstType();
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
            throw new HALTException("HALT PROGRAM (PLS CATCH THIS)");
        }
        public string getSR() { return SR; }
        public void setSR(string s) { SR = s; }
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
