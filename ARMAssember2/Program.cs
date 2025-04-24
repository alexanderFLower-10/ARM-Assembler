using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.SqlServer.Server;
using System.Diagnostics.SymbolStore;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;

namespace ARMAssember2
{
    internal class Program
    {
        // Parameters class holds instructions until the actual instruction class can be executed when passing through to ARM
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                int choice = menuHandler("Choose an option:", new string[] { "View challenges", "Load a program", "Attempt a challenge" });
                if (choice == 0)
                {


                }
                if (choice == 1)
                {
                    ARMEmulator ARM = LoadProgram();
                    ARM.displayGUI();
                    int xstart = (Console.WindowWidth - (Console.WindowWidth / 3) * 2);
                    int ystart = 5;
                    ConsoleDrawing drawOptions = new ConsoleDrawing(new string[] { " Step for debugging", " Run whole program" }, xstart-2 , ystart-1, "Choose an option", ConsoleColor.Magenta);
                    drawOptions.drawNoText();

                    int innerChoice = menuHandler("Choose an option:", new string[] { "Step for debugging", "Run whole program"} ,xstart, ystart );
                    if (innerChoice == 0)
                    {
                        while (true)
                        {
                            Console.ReadKey();
                            try
                            {
                                ARM.Step();
                                ARM.displayGUI();

                            }
                            catch (HALTException e)
                            {
                                ARM.displayGUI();
                                Console.ReadKey(true);
                                break;
                            }
                        }
                                        
                    }
                    else if(innerChoice == 1)
                    {
                        while (true)
                        {
                            try
                            {
                                ARM.Step();
                                ARM.displayGUI();
                            }
                            catch (HALTException e)
                            {
                                ARM.displayGUI();
                                Console.ReadKey(true);
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void displayEverything(ARMEmulator ARM)
        {
            Console.Clear();
            ARM.displayGUI();
        }

        static void executeIndividualProgram(ARMEmulator ARM)
        {
            
        }
        static ARMEmulator LoadProgram()
        {
            List<Instruction> list = new List<Instruction>() {new  Label("Error")};
            ARMEmulator result = new ARMEmulator(list, null);
            Console.WriteLine("LOAD PROJECT");
            string[] rawInstructions = getRawFile();
            var instructions = getInstListSafe(rawInstructions);
            bool customisedMemory = false;
            int memCount= -1;
            int regCount = -1;
            while (true)
            {
                Console.WriteLine("Would you like to custom memory and register amounts (deafult is 16 each, y or n)");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "y")
                {
                    customisedMemory = true;
                    memCount = getSafeInt("Enter memory amount:", 0);
                    regCount = getSafeInt("Enter register amount:", 0);
                    break;

                }
                else if (answer.ToLower() != "n")
                {
                    Console.WriteLine("Invalid input try again");
                }
                else break;

            }
            if (customisedMemory)
            {
                result = new ARMEmulator(instructions, rawInstructions, 0,  regCount, memCount);
            }
            if (!customisedMemory)
            {
                result = new ARMEmulator(instructions, rawInstructions, 0);
            }
            Console.Clear();
            return result;  
        }

        static int getSafeInt(string msg, int lb = int.MinValue, int ub = int.MaxValue)
        {
            int a = -1;
            while (true)
            {
                Console.WriteLine(msg);
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                    if (a <= lb || a >= ub) throw new ArgumentOutOfRangeException();
                    return a;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Input out of range please try again");

                }
                catch (FormatException)
                {
                    Console.WriteLine("Integer not entered please try again");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input please try again");
                }
            }
        }
        static string[] getRawFile()
        {
            string[] res;
            while (true)
            {
                Console.WriteLine("Please enter filename of project in debug folder: ");
                string filepath = Console.ReadLine();
                try
                {
                    res = File.ReadAllLines(filepath);
                    break;
                }
                catch(FileNotFoundException)
                {
                    Console.WriteLine($"Error reading file {filepath}, please ensure it is in your debug folder and retry");
                }
            }
            return res;
        }
        static void syntaxError(string errormsg)
        {
            Console.WriteLine(errormsg);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
            Environment.Exit(0);
        }
        static List<Instruction> getInstListSafe(string[] insts)
        {
            List<Instruction> res = new List<Instruction>();
            while (true)
            {
                try
                {
                    res = getInstList(insts);
                    break;
                }
                catch (InstParsingException e)
                {
                    syntaxError(e.Message);
                }
                catch (System.FormatException e)
                {
                    syntaxError(e.Message);
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }

            }
            return res;
        }

        static int menuHandler(string desc, string[] choices, int xstart = 0, int ystart= 0)
        {
            Console.CursorVisible = false;
            int temp = 0;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(xstart, ystart);
            Console.WriteLine(desc);
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 1; i < choices.Length + 1; i++)
            {
                Console.SetCursorPosition(xstart + 1, ystart + i);
                Console.WriteLine(choices[i - 1]);
            }
            int pointer = ystart + 1; ;
            while (true)
            {
                temp = pointer;
                Console.SetCursorPosition(xstart, pointer);
                Console.Write(">");
                ConsoleKey input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.Enter)
                {
                    Console.Clear(); return pointer - 1 - ystart;
                }
                else if (input == ConsoleKey.Escape) { Console.Clear(); return -1; }
                else if (input == ConsoleKey.UpArrow)
                {
                    if (pointer == ystart + 1) pointer = choices.Length + ystart;
                    else pointer--;
                }
                else
                {
                    if (input == ConsoleKey.DownArrow)
                    {
                        if (pointer == choices.Length + ystart) pointer = 1 + ystart;
                        else pointer++;
                    }
                }
                Console.SetCursorPosition(xstart, temp);
                Console.Write(" ");
            }
        }

        static List<Instruction> getInstList(string[] insts)
        {
            List<Instruction> list = new List<Instruction>();
            for(int i = 0; i < insts.Length; i++)
            {
                if (insts[i] == "") continue; 
                if (insts[i][0] == 'B') list.Add(getBranchInst(insts[i]));
                else if (insts[i][insts[i].Length - 1] == ':' && insts[i].Trim() == insts[i])
                {
                    string temp = insts[i].Substring(0, insts[i].Length - 1);
                    list.Add(createLabel(temp));
                }
                else if (insts[i] == "HALT")
                {
                    HALT h = new HALT();
                    list.Add(h);
                }
                else
                {
                    string instType = insts[i][0].ToString() + insts[i][1].ToString() + insts[i][2].ToString();
                    string[] arr = insts[i].Substring(4).Split(',');
                    for (int j = 1; j < arr.Length; j++)
                    {
                        arr[j] = arr[j].Trim();
                    }
                    if (instType == "CMP")
                    {
                        list.Add(createCMP(arr));
                    }
                    else if (arr.Length == 3)
                    {
                        list.Add(getThreeParInst(arr, instType, i + 1, insts[i]));
                    }
                    else if (arr.Length == 2)
                    {
                        list.Add(getTwoParInst(arr, instType, i + 1, insts[i]));
                    }
                    else throw new InstParsingException("Invalid parameters / instruction: " + insts[i]);
                }
            }
            return list;
        }


        static CompareInst createCMP(string[] operands)
        {
            return new CompareInst(Convert.ToInt32(operands[0].Substring(1)), operands[1]);
        }

        static Label createLabel(string label)
        {
            return new Label(label);
        }

        static TwoParameterInst getTwoParInst(string[] operands, string instType, int linenumber, string fullinst)
        {
            return new TwoParameterInst(instType, Convert.ToInt32(operands[0].Substring(1)), operands[1], linenumber,  fullinst);
        }
        static ThreeParameterInst getThreeParInst(string[] operands, string instType, int linenumber, string fullinst)
        {
            return new ThreeParameterInst(instType, Convert.ToInt32(operands[0].Substring(1)), Convert.ToInt32(operands[1].Substring(1)), operands[2], linenumber, fullinst);
        }

        static BranchesInst getBranchInst(string inst)
        {
            if (inst[1] == ' ') return new BranchesInst(inst.Substring(2));
            if (inst[1] == 'E' && inst[2] == 'Q') return new BranchesInst(inst.Substring(4), "EQ");
            if (inst[1] == 'N' && inst[2] == 'E') return new BranchesInst(inst.Substring(4), "NE");
            if (inst[1] == 'L' && inst[2] == 'T') return new BranchesInst(inst.Substring(4), "LT");
            if (inst[1] == 'G' && inst[2] == 'T') return new BranchesInst(inst.Substring(4), "GT");
            throw new ArgumentException("Branch Condition Invalid");
        }

    }



   



}
