using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ARMAssember2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                string choice = loadScreen();
                if (choice == "L")
                {
                    loadIndividualProgram();
                }
                else if (choice == "C")
                {
                    viewChallenges();
                }
            }

        }

        static string loadScreen()
        {
            loadScreenPart1();
            Console.Clear();
            return loadScreenPart2();

        }


        static void loadScreenPart1()
        {
            Console.WriteLine("Press m to view instruction manual or any other key to continue");
            if (Console.ReadKey(true).Key == ConsoleKey.M) displayInstructionManual();
            Console.WriteLine("Please enter fullscreen then press enter continue (after this screen press any key to continue)");
            Console.ReadLine();
            Thread.Sleep(100);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
            string s = "";
            s += (" ▄▄▄       ██▀███   ███▄ ▄███▓    ▄▄▄        ██████   ██████ ▓█████  ███▄ ▄███▓ ▄▄▄▄   ▓█████  ██▓    ▓█████  ██▀███      ▄▄▄▄    ▄▄▄        ██████ ▓█████ ▓█████▄             \r\n▒████▄    ▓██ ▒ ██▒▓██▒▀█▀ ██▒   ▒████▄    ▒██    ▒ ▒██    ▒ ▓█   ▀ ▓██▒▀█▀ ██▒▓█████▄ ▓█   ▀ ▓██▒    ▓█   ▀ ▓██ ▒ ██▒   ▓█████▄ ▒████▄    ▒██    ▒ ▓█   ▀ ▒██▀ ██▌            \r\n▒██  ▀█▄  ▓██ ░▄█ ▒▓██    ▓██░   ▒██  ▀█▄  ░ ▓██▄   ░ ▓██▄   ▒███   ▓██    ▓██░▒██▒ ▄██▒███   ▒██░    ▒███   ▓██ ░▄█ ▒   ▒██▒ ▄██▒██  ▀█▄  ░ ▓██▄   ▒███   ░██   █▌            \r\n░██▄▄▄▄██ ▒██▀▀█▄  ▒██    ▒██    ░██▄▄▄▄██   ▒   ██▒  ▒   ██▒▒▓█  ▄ ▒██    ▒██ ▒██░█▀  ▒▓█  ▄ ▒██░    ▒▓█  ▄ ▒██▀▀█▄     ▒██░█▀  ░██▄▄▄▄██   ▒   ██▒▒▓█  ▄ ░▓█▄   ▌            \r\n ▓█   ▓██▒░██▓ ▒██▒▒██▒   ░██▒    ▓█   ▓██▒▒██████▒▒▒██████▒▒░▒████▒▒██▒   ░██▒░▓█  ▀█▓░▒████▒░██████▒░▒████▒░██▓ ▒██▒   ░▓█  ▀█▓ ▓█   ▓██▒▒██████▒▒░▒████▒░▒████▓             \r\n ▒▒   ▓▒█░░ ▒▓ ░▒▓░░ ▒░   ░  ░    ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░▒ ▒▓▒ ▒ ░░░ ▒░ ░░ ▒░   ░  ░░▒▓███▀▒░░ ▒░ ░░ ▒░▓  ░░░ ▒░ ░░ ▒▓ ░▒▓░   ░▒▓███▀▒ ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░░░ ▒░ ░ ▒▒▓  ▒             \r\n  ▒   ▒▒ ░  ░▒ ░ ▒░░  ░      ░     ▒   ▒▒ ░░ ░▒  ░ ░░ ░▒  ░ ░ ░ ░  ░░  ░      ░▒░▒   ░  ░ ░  ░░ ░ ▒  ░ ░ ░  ░  ░▒ ░ ▒░   ▒░▒   ░   ▒   ▒▒ ░░ ░▒  ░ ░ ░ ░  ░ ░ ▒  ▒             \r\n  ░   ▒     ░░   ░ ░      ░        ░   ▒   ░  ░  ░  ░  ░  ░     ░   ░      ░    ░    ░    ░     ░ ░      ░     ░░   ░     ░    ░   ░   ▒   ░  ░  ░     ░    ░ ░  ░             \r\n      ░  ░   ░            ░            ░  ░      ░        ░     ░  ░       ░    ░         ░  ░    ░  ░   ░  ░   ░         ░            ░  ░      ░     ░  ░   ░                \r\n                                                                                     ░                                         ░                            ░      \n");
            s += (" ▒█████   ███▄    █     ▄▄▄        █████   ▄▄▄          ██▓ ███▄    █   ██████ ▄▄▄█████▓ ██▀███   █    ██  ▄████▄  ▄▄▄█████▓ ██▓ ▒█████   ███▄    █      ██████ ▓█████▄▄▄█████▓\r\n▒██▒  ██▒ ██ ▀█   █    ▒████▄    ▒██▓  ██▒▒████▄       ▓██▒ ██ ▀█   █ ▒██    ▒ ▓  ██▒ ▓▒▓██ ▒ ██▒ ██  ▓██▒▒██▀ ▀█  ▓  ██▒ ▓▒▓██▒▒██▒  ██▒ ██ ▀█   █    ▒██    ▒ ▓█   ▀▓  ██▒ ▓▒\r\n▒██░  ██▒▓██  ▀█ ██▒   ▒██  ▀█▄  ▒██▒  ██░▒██  ▀█▄     ▒██▒▓██  ▀█ ██▒░ ▓██▄   ▒ ▓██░ ▒░▓██ ░▄█ ▒▓██  ▒██░▒▓█    ▄ ▒ ▓██░ ▒░▒██▒▒██░  ██▒▓██  ▀█ ██▒   ░ ▓██▄   ▒███  ▒ ▓██░ ▒░\r\n▒██   ██░▓██▒  ▐▌██▒   ░██▄▄▄▄██ ░██  █▀ ░░██▄▄▄▄██    ░██░▓██▒  ▐▌██▒  ▒   ██▒░ ▓██▓ ░ ▒██▀▀█▄  ▓▓█  ░██░▒▓▓▄ ▄██▒░ ▓██▓ ░ ░██░▒██   ██░▓██▒  ▐▌██▒     ▒   ██▒▒▓█  ▄░ ▓██▓ ░ \r\n░ ████▓▒░▒██░   ▓██░    ▓█   ▓██▒░▒███▒█▄  ▓█   ▓██▒   ░██░▒██░   ▓██░▒██████▒▒  ▒██▒ ░ ░██▓ ▒██▒▒▒█████▓ ▒ ▓███▀ ░  ▒██▒ ░ ░██░░ ████▓▒░▒██░   ▓██░   ▒██████▒▒░▒████▒ ▒██▒ ░ \r\n░ ▒░▒░▒░ ░ ▒░   ▒ ▒     ▒▒   ▓▒█░░░ ▒▒░ ▒  ▒▒   ▓▒█░   ░▓  ░ ▒░   ▒ ▒ ▒ ▒▓▒ ▒ ░  ▒ ░░   ░ ▒▓ ░▒▓░░▒▓▒ ▒ ▒ ░ ░▒ ▒  ░  ▒ ░░   ░▓  ░ ▒░▒░▒░ ░ ▒░   ▒ ▒    ▒ ▒▓▒ ▒ ░░░ ▒░ ░ ▒ ░░   \r\n  ░ ▒ ▒░ ░ ░░   ░ ▒░     ▒   ▒▒ ░ ░ ▒░  ░   ▒   ▒▒ ░    ▒ ░░ ░░   ░ ▒░░ ░▒  ░ ░    ░      ░▒ ░ ▒░░░▒░ ░ ░   ░  ▒       ░     ▒ ░  ░ ▒ ▒░ ░ ░░   ░ ▒░   ░ ░▒  ░ ░ ░ ░  ░   ░    \r\n░ ░ ░ ▒     ░   ░ ░      ░   ▒      ░   ░   ░   ▒       ▒ ░   ░   ░ ░ ░  ░  ░    ░        ░░   ░  ░░░ ░ ░ ░          ░       ▒ ░░ ░ ░ ▒     ░   ░ ░    ░  ░  ░     ░    ░      \r\n    ░ ░           ░          ░  ░    ░          ░  ░    ░           ░       ░              ░        ░     ░ ░                ░      ░ ░           ░          ░     ░  ░        ");
            s += "\n"; s += "\n"; s += "\n"; s += "\n"; s += "\n"; s += "\n"; s += "\n"; s += "\n"; s += "\n"; s += "\n";

            s += ("                        __        __                   __                          __             ____              __         \r\n   ____ ___  ____ _____/ /__     / /_  __  __   ____ _/ /__  _  ______ _____  ____/ /__  _____   / __/___ _      __/ /__  _____\r\n  / __ `__ \\/ __ `/ __  / _ \\   / __ \\/ / / /  / __ `/ / _ \\| |/_/ __ `/ __ \\/ __  / _ \\/ ___/  / /_/ __ \\ | /| / / / _ \\/ ___/\r\n / / / / / / /_/ / /_/ /  __/  / /_/ / /_/ /  / /_/ / /  __/>  </ /_/ / / / / /_/ /  __/ /     / __/ /_/ / |/ |/ / /  __/ /    \r\n/_/ /_/ /_/\\__,_/\\__,_/\\___/  /_.___/\\__, /   \\__,_/_/\\___/_/|_|\\__,_/_/ /_/\\__,_/\\___/_/     /_/  \\____/|__/|__/_/\\___/_/     \r\n                                    /____/                                                                                   ");
            Console.WriteLine(s);
            Console.ReadKey(true);
        }

        static void displayInstructionManual()
        {
            Console.Clear();
            Console.WriteLine("Instruction Manual For ARM Emulator Based on AQA Instruction Set\r\n\r\nThis program is made up of 2 main components\r\n\r\nViewing/Attempting challenges:\r\n>This shows the user a comprehensive list of assembly challenges they may wish to attempt, if they do\r\n\r\n>You will be asked to enter a filename for your program to be loaded\r\n>This program is then tested against the output from random testcases of premade programs which produce a valid solution to the challenge\r\n>If all of your program outputs match the correct solution it will be marked as valid and you have the option to save   the progress under your name\r\n>If not, failed testcases, the result produced and the result meant to be produced will be specified\r\n\nLoad Program:\r\n>Ensure .txt or .asm file (specify when asked for filename) is placed in bin debug folder of solution\r\n>Enter filename when prompted\r\n>This will then attempt to parse your program to prepare it to be exectued\r\n>Errors are then checked for in the syntax\r\n>Afterwards your program will be loaded, from there follow the key binds to execute your program\r\n>Many debugging tools are included\r\n\r\nExtra function, Indirect addressing:\r\n> Indirect addressing is where the operand of an instruction is the memory address of a number stored in a register\r\n> To do this, use square brackets\r\n> For example, if I wanted to access the memory address stored in register R0, get the value, and add it to R1:\r\n>> ADD R1, R1, [R0]\r\n> If R1 = 5, R0 = 2 and Memory address location 2 stored the values 4:\r\n>> Operand is the value of the memory address location stored in R0 so values of memory address location 2 = 4\r\n\r\n--Made by Alexander Fowler\r\n");
            Console.WriteLine("Press enter to continie");
            Console.ReadLine();
            Console.Clear();

        }
        static string loadScreenPart2()
        {
            Console.Write("    ____                         ______   __                 __  __                       __        __         _                      __          ____                          \r\n   / __ \\________  __________   / ____/  / /_____     ____ _/ /_/ /____  ____ ___  ____  / /_     _/_/  _   __(_)__ _      __   _____/ /_  ____ _/ / /__  ____  ____ ____  _____\r\n  / /_/ / ___/ _ \\/ ___/ ___/  / /      / __/ __ \\   / __ `/ __/ __/ _ \\/ __ `__ \\/ __ \\/ __/   _/_/   | | / / / _ \\ | /| / /  / ___/ __ \\/ __ `/ / / _ \\/ __ \\/ __ `/ _ \\/ ___/\r\n / ____/ /  /  __(__  |__  )  / /___   / /_/ /_/ /  / /_/ / /_/ /_/  __/ / / / / / /_/ / /_   _/_/     | |/ / /  __/ |/ |/ /  / /__/ / / / /_/ / / /  __/ / / / /_/ /  __(__  ) \r\n/_/   /_/   \\___/____/____/   \\____/   \\__/\\____/   \\__,_/\\__/\\__/\\___/_/ /_/ /_/ .___/\\__/  /_/       |___/_/\\___/|__/|__/   \\___/_/ /_/\\__,_/_/_/\\___/_/ /_/\\__, /\\___/____/  \r\n                                                                               /_/                                                                           /____/             ");
            Console.WriteLine();
            Console.Write("    ____                         __       __           __                __                                                      \r\n   / __ \\________  __________   / /      / /_____     / /___  ____ _____/ /  ____ _   ____  _________  ____ __________ _____ ___ \r\n  / /_/ / ___/ _ \\/ ___/ ___/  / /      / __/ __ \\   / / __ \\/ __ `/ __  /  / __ `/  / __ \\/ ___/ __ \\/ __ `/ ___/ __ `/ __ `__ \\\r\n / ____/ /  /  __(__  |__  )  / /___   / /_/ /_/ /  / / /_/ / /_/ / /_/ /  / /_/ /  / /_/ / /  / /_/ / /_/ / /  / /_/ / / / / / /\r\n/_/   /_/   \\___/____/____/  /_____/   \\__/\\____/  /_/\\____/\\__,_/\\__,_/   \\__,_/  / .___/_/   \\____/\\__, /_/   \\__,_/_/ /_/ /_/ \r\n                                                                                  /_/               /____/                       ");
            Console.WriteLine();

            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.C)
                {
                    return "C";
                }
                else if (key == ConsoleKey.L)
                {
                    return "L";
                }

            }

        }

        static void loadIndividualProgram()
        {
            ARMEmulator ARM = LoadProgram();
            ARM.displayGUI();
            int xstart = (Console.WindowWidth - (Console.WindowWidth / 3) * 2);
            displayEverything(ARM);
            int inputXPos = ARM.getInputXIndex();
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                try
                {
                    if (key == ConsoleKey.Spacebar)
                    {

                        ARM.Step();
                        displayEverything(ARM);

                    }
                    else if (key == ConsoleKey.Enter)
                    {
                        while (true)
                        {

                            ARM.Step();
                            displayEverything(ARM);

                        }
                    }
                    else if (key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else if (key == ConsoleKey.J)
                    {
                        int ln = getSafeIntInputBox(inputXPos + 2, ARM, ARM.getMaxLines(), "Enter line numnber:   ");
                        ARM.SetPC(ln);
                        displayEverything(ARM);
                    }
                    else if (key == ConsoleKey.Q)
                    {
                        int ln = getSafeIntInputBox(inputXPos + 2, ARM, ARM.getMaxLines(), "Enter line numnber:   ");
                        while (ARM.GetPC() != ln)
                        {
                            ARM.Step();
                        }
                        displayEverything(ARM);
                    }
                    else if (key == ConsoleKey.M)
                    {
                        int Mn = getSafeIntInputBox(inputXPos + 2, ARM, ARM.getRegisterLength() - 1, "Enter memory address location:   ");
                        int Operand2 = getSafeIntInputBox(inputXPos + 2, ARM, int.MaxValue, $"Enter value for loc {Mn}:   ");
                        ARM.SetMemoryVal(Mn, Operand2);
                        displayEverything(ARM);
                    }
                    else if (key == ConsoleKey.R)
                    {
                        int Rn = getSafeIntInputBox(inputXPos + 2, ARM, ARM.getRegisterLength() - 1, "Enter Register Number:   ");
                        int Operand2 = getSafeIntInputBox(inputXPos + 2, ARM, int.MaxValue, $"Enter value for R{Rn}:   ");
                        ARM.SetRegisterVal(Rn, Operand2);
                        displayEverything(ARM);
                    }
                }
                catch (Exception e)
                {
                    displayEverything(ARM);
                    ARM.drawError(e.Message + ". Please press any key to exit");
                    Console.ReadKey(true);
                    break;
                }


            }
        }
        // All loading a program subroutines ↓↓↓
        static ARMEmulator LoadProgram()
        {
            // Loads a program
            List<Instruction> list = new List<Instruction>() { new Label("Error") };
            ARMEmulator result = new ARMEmulator(list, null);
            Console.WriteLine("LOAD PROJECT");
            string[] rawInstructions = getRawFile();
            var instructions = getInstListSafe(rawInstructions);
            bool customisedMemory = false;
            int memCount = -1;
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
                result = new ARMEmulator(instructions, rawInstructions, 0, regCount, memCount);
            }
            if (!customisedMemory)
            {
                result = new ARMEmulator(instructions, rawInstructions, 0);
            }
            Console.Clear();
            return result;
        }
        static string[] getRawFile(string message = "    ____  __                                   __               _____ __                                 \r\n   / __ \\/ /__  ____ _________     ___  ____  / /____  _____   / __(_) /__  ____  ____ _____ ___  ___  _ \r\n  / /_/ / / _ \\/ __ `/ ___/ _ \\   / _ \\/ __ \\/ __/ _ \\/ ___/  / /_/ / / _ \\/ __ \\/ __ `/ __ `__ \\/ _ \\(_)\r\n / ____/ /  __/ /_/ (__  )  __/  /  __/ / / / /_/  __/ /     / __/ / /  __/ / / / /_/ / / / / / /  __/   \r\n/_/   /_/\\___/\\__,_/____/\\___/   \\___/_/ /_/\\__/\\___/_/     /_/ /_/_/\\___/_/ /_/\\__,_/_/ /_/ /_/\\___(_)  \r\n                                                                                                         ")
        {
            // Gets filename from user
            Console.Clear();
            string[] res;
            while (true)
            {
                Console.WriteLine(message);
                string filepath = Console.ReadLine();
                try
                {
                    res = File.ReadAllLines(filepath);
                    break;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"Error reading file {filepath}, please ensure it is in your debug folder and retry, either exit or press any key to retry");
                    Console.ReadKey(true);
                    Console.Clear();

                }
            }
            return res;
        }
        static List<Instruction> getInstListSafe(string[] insts)
        {
            Console.Clear();
            // Gets the instruction lists and handles any errors occured when parsing instructions
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
                    parsingError(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return res;
        }
        static void parsingError(string errormsg)
        {
            Console.Clear();
            Console.WriteLine(errormsg);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        static List<Instruction> getInstList(string[] insts)
        {
            // Loop to create the list of instructions based on user input in text files
            int counter = 0;
            List<Instruction> list = new List<Instruction>();
            for (int i = 0; i < insts.Length; i++)
            {
                if (insts[i] == "") continue;
                if (insts[i][0] == 'B') list.Add(getBranchInst(insts[i], counter));
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
                counter++;
            }
            return list;
        }

        static CompareInst createCMP(string[] operands)
        {
            // Returns correct CMPInstruction
            return new CompareInst(Convert.ToInt32(operands[0].Substring(1)), operands[1]);
        }

        static Label createLabel(string label)
        {
            // Returns correct label
            return new Label(label);
        }

        static TwoParameterInst getTwoParInst(string[] operands, string instType, int linenumber, string fullinst)
        {
            // Returns correct twoParameterInstruction
            return new TwoParameterInst(instType, Convert.ToInt32(operands[0].Substring(1)), operands[1], linenumber, fullinst);
        }
        static ThreeParameterInst getThreeParInst(string[] operands, string instType, int linenumber, string fullinst)
        {
            // Returns correct threeParameterInstruction
            return new ThreeParameterInst(instType, Convert.ToInt32(operands[0].Substring(1)), Convert.ToInt32(operands[1].Substring(1)), operands[2], linenumber, fullinst);
        }

        static BranchesInst getBranchInst(string inst, int ln)
        {
            // Identifies and return correct branch instruction
            if (inst[1] == ' ') return new BranchesInst(inst.Substring(2));
            if (inst[1] == 'E' && inst[2] == 'Q') return new BranchesInst(inst.Substring(4), "EQ");
            if (inst[1] == 'N' && inst[2] == 'E') return new BranchesInst(inst.Substring(4), "NE");
            if (inst[1] == 'L' && inst[2] == 'T') return new BranchesInst(inst.Substring(4), "LT");
            if (inst[1] == 'G' && inst[2] == 'T') return new BranchesInst(inst.Substring(4), "GT");
            throw new InstParsingException("Branch Condition Invalid on line");
        }

        static int getSafeIntInputBox(int xpo, ARMEmulator ARM, int upperlim, string message)
        {
            // Gets the input from the input box safely when required
            int a = -1;
            while (true)
            {
                ARM.drawBlankInputBox();
                Console.SetCursorPosition(xpo, 12);
                Console.Write(message);
                Console.CursorVisible = true;
                try
                {

                    a = Convert.ToInt32(Console.ReadLine());
                    if (a < 0 || a > upperlim) throw new ArgumentException();
                    Console.CursorVisible = false;
                    return a;
                }
                catch (Exception)
                {
                    ARM.drawBlankInputBox();
                    Console.SetCursorPosition(xpo, 12);
                    Console.Write("Invalid input, press any key to continue");
                }
            }
        }
        static void displayEverything(ARMEmulator ARM)
        {
            Console.Clear();
            ARM.displayGUI();
        }

        static int getSafeInt(string msg, int lb = int.MinValue, int ub = int.MaxValue)
        {
            // Gets an integer safely via error handling
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


        // All loading a program subroutines ↑↑↑ 
        // All viewing challenges subroutines ↓↓↓
        static void viewChallenges()
        {
            Console.Clear();
            Console.WriteLine("    ____                         ___       __                 _                                  __                                                              __          ____                          \r\n   / __ \\________  __________   /   |     / /_____     _   __(_)__ _      __   ____  ____ ______/ /_   ____ _____ _____ _   ____  ____ _____  ___  _____   _____/ /_  ____ _/ / /__  ____  ____ ____  _____\r\n  / /_/ / ___/ _ \\/ ___/ ___/  / /| |    / __/ __ \\   | | / / / _ \\ | /| / /  / __ \\/ __ `/ ___/ __/  / __ `/ __ `/ __ `/  / __ \\/ __ `/ __ \\/ _ \\/ ___/  / ___/ __ \\/ __ `/ / / _ \\/ __ \\/ __ `/ _ \\/ ___/\r\n / ____/ /  /  __(__  |__  )  / ___ |   / /_/ /_/ /   | |/ / /  __/ |/ |/ /  / /_/ / /_/ (__  ) /_   / /_/ / /_/ / /_/ /  / /_/ / /_/ / /_/ /  __/ /     / /__/ / / / /_/ / / /  __/ / / / /_/ /  __(__  ) \r\n/_/   /_/   \\___/____/____/  /_/  |_|   \\__/\\____/    |___/_/\\___/|__/|__/  / .___/\\__,_/____/\\__/   \\__,_/\\__, /\\__,_/  / .___/\\__,_/ .___/\\___/_/      \\___/_/ /_/\\__,_/_/_/\\___/_/ /_/\\__, /\\___/____/  \r\n                                                                           /_/                               /_/        /_/         /_/                                                 /____/             ");
            Console.WriteLine();
            Console.WriteLine("    ____                         ____     __                      _                   __  __                      __          ____                          \r\n   / __ \\________  __________   / __ \\   / /_____     _   _____  (_)      __   ____  / /_/ /_  ___  _____   _____/ /_  ____ _/ / /__  ____  ____ ____  _____\r\n  / /_/ / ___/ _ \\/ ___/ ___/  / / / /  / __/ __ \\   | | / / _ \\/ / | /| / /  / __ \\/ __/ __ \\/ _ \\/ ___/  / ___/ __ \\/ __ `/ / / _ \\/ __ \\/ __ `/ _ \\/ ___/\r\n / ____/ /  /  __(__  |__  )  / /_/ /  / /_/ /_/ /   | |/ /  __/ /| |/ |/ /  / /_/ / /_/ / / /  __/ /     / /__/ / / / /_/ / / /  __/ / / / /_/ /  __(__  ) \r\n/_/   /_/   \\___/____/____/   \\____/   \\__/\\____/    |___/\\___/_/ |__/|__/   \\____/\\__/_/ /_/\\___/_/      \\___/_/ /_/\\__,_/_/_/\\___/_/ /_/\\__, /\\___/____/  \r\n                                                                                                                                         /____/             ");
            Console.WriteLine();
            Console.WriteLine("For both use arrow keys to control");
            Console.ForegroundColor = ConsoleColor.Gray;
            while (true)
            {

                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape) break;
                if (key == ConsoleKey.A)
                {

                }
                if (key == ConsoleKey.O)
                {
                    displayOtherChallenges();
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;

        }

        static string getDifficulty()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Enter difficulty or challenges to be displayed (e, m or h) (esc to exit)");
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape) break;
                else if (key == ConsoleKey.E) return "E";
                else if (key == ConsoleKey.M) return "M";
                else if (key == ConsoleKey.H) return "H";
            }
            return "";
        }
        static void displayOtherChallenges()
        {
            string diff = getDifficulty();
            Console.Clear();
            int challengeNumDisplayed = 1;
            int challengesMadeCount = 0;
            if (diff == "E")
            {
                challengesMadeCount = 2;
            }
            else if (diff == "M")
            {
                challengesMadeCount = 1;
            }
            else if (diff == "H")
            {
                challengesMadeCount = 1;
            }
            printOtherChallengeNum(1, diff);
            writePageNum(1, challengesMadeCount);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press a to submit a solution");
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape) break;
                else if (key == ConsoleKey.RightArrow)
                {

                    if (challengeNumDisplayed != challengesMadeCount)
                    {
                        Console.Clear();
                        challengeNumDisplayed++;
                        printOtherChallengeNum(challengeNumDisplayed, diff);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Press a to submit a solution");
                    }
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    if (challengeNumDisplayed != 1)
                    {
                        Console.Clear();
                        challengeNumDisplayed--;
                        printOtherChallengeNum(challengeNumDisplayed, diff);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Press a to submit a solution");
                    }
                }
                else if (key == ConsoleKey.A)
                {
                    attemptOtherChallenge(challengeNumDisplayed, diff);
                }
                writePageNum(challengeNumDisplayed, challengesMadeCount);
            }

        }

        static void attemptOtherChallenge(int num, string diff)
        {

            string[] rawInstructions = getRawFile("    ______      __               _____ __                                         ____              __      __  _           \r\n   / ____/___  / /____  _____   / __(_) /__  ____  ____ _____ ___  ___     ____  / __/  _________  / /_  __/ /_(_)___  ____ \r\n  / __/ / __ \\/ __/ _ \\/ ___/  / /_/ / / _ \\/ __ \\/ __ `/ __ `__ \\/ _ \\   / __ \\/ /_   / ___/ __ \\/ / / / / __/ / __ \\/ __ \\\r\n / /___/ / / / /_/  __/ /     / __/ / /  __/ / / / /_/ / / / / / /  __/  / /_/ / __/  (__  ) /_/ / / /_/ / /_/ / /_/ / / / /\r\n/_____/_/ /_/\\__/\\___/_/     /_/ /_/_/\\___/_/ /_/\\__,_/_/ /_/ /_/\\___/   \\____/_/    /____/\\____/_/\\__,_/\\__/_/\\____/_/ /_/ \r\n                                                                                                                            ");
            var instructons = getInstList(rawInstructions);
            ARMEmulator userprogram = new ARMEmulator(instructons, rawInstructions);
            Console.Clear();
            if (diff == "E")
            {
                if (num == 1)
                {
                    attemptE1(userprogram);
                }
            }
        }

        static ARMEmulator getSolution(int num, string diff)
        {
            string[] rawInstructions = caeserDecrypt($@"C:\Users\alexa\Documents\GitHub\ARM-Assembler\ARMAssember2\bin\Debug\Soltuions\{diff}{num}.asm");
            List<Instruction> instList = getInstListSafe(rawInstructions);
            return new ARMEmulator(instList, rawInstructions);
        }

        static void attemptE1(ARMEmulator userProgram)
        {
            ARMEmulator solution = getSolution(1, "E");
            Random rn = new Random();
            int testCaseMVal1, testCaseMVal2;
            for (int i = 0; i < 100; i++)
            {
                solution.Reset();
                userProgram.Reset();
                testCaseMVal1 = rn.Next(1, 100);
                testCaseMVal2 = rn.Next(1, 100);
                userProgram.SetMemoryVal(1, testCaseMVal1);
                userProgram.SetMemoryVal(2, testCaseMVal2);
                solution.SetMemoryVal(1, testCaseMVal1);
                solution.SetMemoryVal(2, testCaseMVal2);
                while (true)
                {
                    try
                    {
                        solution.Step();

                    }
                    catch (HALTException)
                    {
                        break;
                    }

                }
                int requiredresult = solution.GetMemoryVal(0);
                while (true)
                {
                    try
                    {
                        userProgram.Step();

                    }
                    catch (HALTException)
                    {
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                    }
                }
                if (userProgram.GetMemoryVal(0) != requiredresult)
                {
                    Console.WriteLine($"Testcase {i + 1} FAILED: M1 = {testCaseMVal1} M2 = {testCaseMVal2} Expected M0 = {requiredresult} Your M0 = {userProgram.GetMemoryVal(0)}");
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey(true);
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine($"Testcase {i + 1} PASSED: M1 = {testCaseMVal1} M2 = {testCaseMVal2} Expected M0 = {requiredresult} Your M0 = {userProgram.GetMemoryVal(0)}");
                }
            }
            Console.WriteLine("Program is valid");
            Console.ReadLine();
        }


        static void caeserEncrypt(string filepath)
        {
            // Only used by me to encrypt files in folder to ensure user cannot accidentally access solutions
            string[] lines = File.ReadAllLines(filepath);
            string temp;
            int originalCharCode;
            for (int j = 0; j < lines.Length; j++)
            {
                temp = "";
                for (int i = 0; i < lines[j].Length; i++)
                {
                    originalCharCode = (int)lines[j][i];
                    originalCharCode += 7;
                    temp += (char)originalCharCode;
                }
                lines[j] = temp;
            }
            using (var sw = new StreamWriter(filepath, false))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    sw.WriteLine(lines[i]);
                }
            }
        }
        static string[] caeserDecrypt(string filepath)
        {
            int originalCharCode;
            string[] res = File.ReadAllLines(filepath);
            for (int i = 0; i < res.Length; i++)
            {
                string temp = "";
                for (int j = 0; j < res[i].Length; j++)
                {
                    originalCharCode = (int)res[i][j];
                    originalCharCode -= 7;
                    temp += (char)originalCharCode;
                }
                res[i] = temp;
            }
            return res;
        }

        static void printOtherChallengeNum(int num, string diff)
        {
            if (diff == "E")
            {
                if (num == 1)
                {
                    Console.WriteLine("ADDTOWNS\r\n> 2 sections of a city both have different populations\r\n> The population of each city is stored in memory locations 1 and 2 respectively\r\n> I need memory location 0 to store the sum of all the people in the city");

                }
                if (num == 2)
                {
                    Console.WriteLine("Vernam Cipher\r\n> A character code is stored in memory address 1\r\n> You must input the special key (the number 7) directly into a register\r\n> Then X/EOR the key with the character code and store the result in memory location 0");
                }
            }
            else if (diff == "M")
            {
                if (num == 1)
                {
                    Console.WriteLine("Logic gates\r\n> Value A is stored in memory address 1\r\n> value B is stored in memory address 2\r\n> Carry out the following operation and store the result in memory address 0\r\n> NOT( A \u2022 B \u2022 A + B) ");
                }
            }
            else if (diff == "H")
            {
                if (num == 1)
                {
                    Console.WriteLine("ADDTOWNS PT 2\r\n> n values are stored in memory address locations 1,2 … ,n\r\n> The number n is stored in memory location 0\r\n> Using indirect addressing (more info in manual at start) add all of these values\r\n> Store the result of the operation in Register 0\r\n");
                }
            }

        }

        static void writePageNum(int num, int cap)
        {
            int length = num.ToString().Length + cap.ToString().Length + 1 + "Challenge: ".Length;
            Console.SetCursorPosition(Console.WindowWidth - length, 0);
            Console.Write("Challenge: " + num + "/" + cap);
        }

    }







}
