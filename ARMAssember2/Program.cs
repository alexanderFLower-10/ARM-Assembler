using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ARMAssember2
{
    internal class Program
    {
        static Random rn = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter fullscreen and click enter to continue");
            Console.ReadLine();
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
                else if (choice == "M")
                {
                    displayInstructionManual();
                }
                else if (choice == "I")
                {
                    EnterIDE();
                }
            }

        }
        static void displayInstructionManual()
        {
            string[] lines = File.ReadAllLines(@"Misc\manual.txt");
            Console.Clear();
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
            Console.Clear();

        }
        static string loadScreen()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("    ____                         __  ___   __                 _                 __  __                                              __\r\n   / __ \\________  __________   /  |/  /  / /_____     _   __(_)__ _      __   / /_/ /_  ___     ____ ___  ____ _____  __  ______ _/ /\r\n  / /_/ / ___/ _ \\/ ___/ ___/  / /|_/ /  / __/ __ \\   | | / / / _ \\ | /| / /  / __/ __ \\/ _ \\   / __ `__ \\/ __ `/ __ \\/ / / / __ `/ / \r\n / ____/ /  /  __(__  |__  )  / /  / /  / /_/ /_/ /   | |/ / /  __/ |/ |/ /  / /_/ / / /  __/  / / / / / / /_/ / / / / /_/ / /_/ / /  \r\n/_/   /_/   \\___/____/____/  /_/  /_/   \\__/\\____/    |___/_/\\___/|__/|__/   \\__/_/ /_/\\___/  /_/ /_/ /_/\\__,_/_/ /_/\\__,_/\\__,_/_/   \r\n                                                                                                                                      ");
            Console.WriteLine();
            Console.Write("    ____                         ______   __                 __  __                       __        __         _                      __          ____                          \r\n   / __ \\________  __________   / ____/  / /_____     ____ _/ /_/ /____  ____ ___  ____  / /_     _/_/  _   __(_)__ _      __   _____/ /_  ____ _/ / /__  ____  ____ ____  _____\r\n  / /_/ / ___/ _ \\/ ___/ ___/  / /      / __/ __ \\   / __ `/ __/ __/ _ \\/ __ `__ \\/ __ \\/ __/   _/_/   | | / / / _ \\ | /| / /  / ___/ __ \\/ __ `/ / / _ \\/ __ \\/ __ `/ _ \\/ ___/\r\n / ____/ /  /  __(__  |__  )  / /___   / /_/ /_/ /  / /_/ / /_/ /_/  __/ / / / / / /_/ / /_   _/_/     | |/ / /  __/ |/ |/ /  / /__/ / / / /_/ / / /  __/ / / / /_/ /  __(__  ) \r\n/_/   /_/   \\___/____/____/   \\____/   \\__/\\____/   \\__,_/\\__/\\__/\\___/_/ /_/ /_/ .___/\\__/  /_/       |___/_/\\___/|__/|__/   \\___/_/ /_/\\__,_/_/_/\\___/_/ /_/\\__, /\\___/____/  \r\n                                                                               /_/                                                                           /____/             ");
            Console.WriteLine();
            Console.Write("    ____                         __       __           __                __                                                      \r\n   / __ \\________  __________   / /      / /_____     / /___  ____ _____/ /  ____ _   ____  _________  ____ __________ _____ ___ \r\n  / /_/ / ___/ _ \\/ ___/ ___/  / /      / __/ __ \\   / / __ \\/ __ `/ __  /  / __ `/  / __ \\/ ___/ __ \\/ __ `/ ___/ __ `/ __ `__ \\\r\n / ____/ /  /  __(__  |__  )  / /___   / /_/ /_/ /  / / /_/ / /_/ / /_/ /  / /_/ /  / /_/ / /  / /_/ / /_/ / /  / /_/ / / / / / /\r\n/_/   /_/   \\___/____/____/  /_____/   \\__/\\____/  /_/\\____/\\__,_/\\__,_/   \\__,_/  / .___/_/   \\____/\\__, /_/   \\__,_/_/ /_/ /_/ \r\n                                                                                  /_/               /____/                       ");
            Console.WriteLine();
            Console.WriteLine("    ____                         ____   __                                __          __         ___ __                                               \r\n   / __ \\________  __________   /  _/  / /_____     _____________  ____ _/ /____    _/_/__  ____/ (_) /_   ____  _________  ____ __________ _____ ___ \r\n  / /_/ / ___/ _ \\/ ___/ ___/   / /   / __/ __ \\   / ___/ ___/ _ \\/ __ `/ __/ _ \\ _/_// _ \\/ __  / / __/  / __ \\/ ___/ __ \\/ __ `/ ___/ __ `/ __ `__ \\\r\n / ____/ /  /  __(__  |__  )  _/ /   / /_/ /_/ /  / /__/ /  /  __/ /_/ / /_/  __//_/ /  __/ /_/ / / /_   / /_/ / /  / /_/ / /_/ / /  / /_/ / / / / / /\r\n/_/   /_/   \\___/____/____/  /___/   \\__/\\____/   \\___/_/   \\___/\\__,_/\\__/\\___/_/   \\___/\\__,_/_/\\__/  / .___/_/   \\____/\\__, /_/   \\__,_/_/ /_/ /_/ \r\n                                                                                                       /_/               /____/                       ");
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
                else if (key == ConsoleKey.M)
                {
                    return "M";
                }
                else if (key == ConsoleKey.I)
                {
                    return "I";
                }

            }

        }

        static void loadIndividualProgram()
        {
            ARMEmulator ARM = LoadProgram();
            if (ARM.getFilePath() == null) return;
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
                    else if (key == ConsoleKey.I)
                    {
                        string[] modified = ARM.enterIDE();
                        ARM = new ARMEmulator(getInstListSafe(modified), modified, ARM.getFilePath());
                        Console.Clear();
                        ARM.displayGUI();
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

        static void EnterIDE()
        {
            var fileinfo = getRawFile();
            if (fileinfo.Item2 == "")
            {
                return;
            }
            string[] rawInstructions = fileinfo.Item1;
            string filename = fileinfo.Item2;
            ARMEmulator ARM = new ARMEmulator(null, null, null);
            if (filename == "NewFile")
            {
                ARM = new ARMEmulator(null, null, null);
            }
            else
            {
                ARM = new ARMEmulator(null, rawInstructions, null);
            }
            string[] newRawInst = ARM.enterIDE();

            if (filename == "NewFile")
            {
                Console.Clear();
                Console.WriteLine("Enter desired filename to store this under (without filename extension)");
                FileStream fs = new FileStream(Console.ReadLine() + ".asm", FileMode.Create);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (string s in newRawInst)
                    {
                        sw.WriteLine(s);
                    }
                }
            }
            else
            {
                Console.Clear();
                using (StreamWriter sw = new StreamWriter(filename, false))
                {
                    foreach (string s in newRawInst)
                    {
                        sw.WriteLine(s);
                    }
                }
            }
            Console.Clear();
        }
        // All loading a program subroutines ↓↓↓
        static ARMEmulator LoadProgram()
        {
            // Loads a program
            List<Instruction> list = new List<Instruction>() { new Label("Error") };
            ARMEmulator result = new ARMEmulator(list, null, "");
            Console.WriteLine("LOAD PROJECT");
            var fileinfo = getRawFile();
            if (fileinfo.Item2 == "")
            {
                return new ARMEmulator(null, null, null);
            }
            string[] rawInstructions = fileinfo.Item1;
            string filepath = fileinfo.Item2;
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
                result = new ARMEmulator(instructions, rawInstructions, filepath, 0, regCount, memCount);
            }
            if (!customisedMemory)
            {
                result = new ARMEmulator(instructions, rawInstructions, filepath, 0);
            }
            Console.Clear();
            return result;
        }
        static Tuple<string[], string> getRawFile()
        {
            // Gets filename from user
            Console.Clear();
            string[] res;
            string filepath;
            DirectoryInfo d = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            FileInfo[] filesasm = d.GetFiles("*.asm");
            FileInfo[] filestxt = d.GetFiles("*.txt");
            FileInfo[] combinedfiles = filesasm.Concat(filestxt).ToArray();
            string[] fileNames = new string[combinedfiles.Length + 1];
            for (int i = 0; i < combinedfiles.Length; i++)
            {
                fileNames[i] = combinedfiles[i].Name;
            }
            fileNames[combinedfiles.Length] = "NewFile";
            int index = menuHandler("Choose a file:", fileNames);
            string[] anti = new string[0];
            if (index == -1) return Tuple.Create(anti, "");
            filepath = fileNames[index];
            if (filepath == "NewFile")
            {
                return Tuple.Create(new string[0], "NewFile");
            }
            res = File.ReadAllLines(filepath);
            return Tuple.Create(res, filepath);

        }
        static int menuHandler(string desc, string[] choices)
        {
            Console.CursorVisible = false;
            int temp = 0;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(desc);
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 1; i < choices.Length + 1; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.WriteLine(choices[i - 1]);
            }
            int pointer = 1;
            while (true)
            {
                temp = pointer;
                Console.SetCursorPosition(0, pointer);
                Console.Write(">");
                ConsoleKey input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.Enter)
                {
                    Console.Clear(); return pointer - 1;
                }
                else if (input == ConsoleKey.Escape) { Console.Clear(); return -1; }
                else if (input == ConsoleKey.UpArrow)
                {
                    if (pointer == 1) pointer = choices.Length;
                    else pointer--;
                }
                else
                {
                    if (input == ConsoleKey.DownArrow)
                    {
                        if (pointer == choices.Length) pointer = 1;
                        else pointer++;
                    }
                }
                Console.SetCursorPosition(0, temp);
                Console.Write(" ");
            }
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
                    Console.Clear();
                    parsingError(e.Message);
                }
                catch (Exception e)
                {
                    Console.Clear();
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
                Console.SetCursorPosition(xpo, 14);
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
                    Console.SetCursorPosition(xpo, 14);
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
                    }
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    if (challengeNumDisplayed != 1)
                    {
                        Console.Clear();
                        challengeNumDisplayed--;
                        printOtherChallengeNum(challengeNumDisplayed, diff);
                    }
                }
                else if (key == ConsoleKey.A)
                {
                    attemptOtherChallenge(challengeNumDisplayed, diff);

                }
                else if (key == ConsoleKey.R)
                {
                    printOtherChallengeInstUse(challengeNumDisplayed, diff);
                }

                writePageNum(challengeNumDisplayed, challengesMadeCount);

            }

        }

        static void attemptOtherChallenge(int num, string diff)
        {

            var fileinfo = getRawFile();
            while (true)
            {
                if (fileinfo.Item2 == "")
                {
                    return;
                }
                else if (fileinfo.Item2 == "NewFile")
                {
                    EnterIDE();
                }
                else
                {
                    break;
                }
            }

            string[] rawInstructions = fileinfo.Item1;
            string filename = fileinfo.Item2;
            var instructons = getInstList(rawInstructions);
            ARMEmulator userprogram = new ARMEmulator(instructons, rawInstructions, filename);
            Console.Clear();
            if (diff == "E")
            {
                if (num == 1)
                {
                    attemptE1(userprogram);
                }
                if (num == 2)
                {
                    attemptE2(userprogram);
                }
            }
            else if (diff == "M")
            {
                if (num == 1)
                {
                    attemptM1(userprogram);
                }
            }
        }

        static ARMEmulator getSolution(int num, string diff)
        {
            string[] rawInstructions = caeserDecrypt($@"Solutions\{diff}{num}.asm");
            List<Instruction> instList = getInstListSafe(rawInstructions);
            return new ARMEmulator(instList, rawInstructions, $@"Solutions\{diff}{num}.asm");
        }

        static int testCase(ARMEmulator ARM, string solutionLoc, int solutionIndex)
        {
            while (true)
            {
                try
                {
                    ARM.Step();
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
            if (solutionLoc == "R")
            {
                return ARM.GetRegisterVal(solutionIndex);

            }
            else if (solutionLoc == "M")
            {
                return ARM.GetMemoryVal(solutionIndex);
            }
            else throw new ArgumentException("Invalid solution location");
        }

        static string twoInputPassedResultBuilder(int testCaseNum, string case1Loc, int case1Val, string case2Loc, int case2Val, string resultLocation, int requiredresult, int userresult)
        {
            string result = $"Testcase {testCaseNum}";
            for (int j = testCaseNum.ToString().Length; j < 5; j++)
            {
                result += " ";
            }
            result += $"PASSED: {case1Loc} = {case1Val}";
            for (int j = case1Val.ToString().Length; j < 5; j++)
            {
                result += " ";
            }
            result += $" {case2Loc} = {case2Val}";
            for (int j = case2Val.ToString().Length; j < 5; j++)
            {
                result += " ";
            }
            result += $" Expected {resultLocation} = {requiredresult}";
            for (int j = requiredresult.ToString().Length; j < 5; j++)
            {
                result += " ";
            }
            result += $" Your {resultLocation} = ";
            result += userresult.ToString();
            for (int j = requiredresult.ToString().Length; j < 5; j++)
            {
                result += " ";
            }
            return result;
        }

        static Tuple<int, int> inputTwoValTestCases(ARMEmulator sol, ARMEmulator user, string loc1, string loc2)
        {

            if (loc1[0] == 'M')
            {
                int addy1 = Convert.ToInt32(loc1.Substring(1));
                int testcase1 = rn.Next(1, 10000);
                sol.SetMemoryVal(addy1, testcase1);
                user.SetMemoryVal(addy1, testcase1);

                int addy2 = Convert.ToInt32(loc2.Substring(1));
                int testcase2 = rn.Next(1, 10000);
                sol.SetMemoryVal(addy2, testcase2);
                user.SetMemoryVal(addy2, testcase2);
                return Tuple.Create(testcase1, testcase2);
            }
            else if (loc1[0] == 'R')
            {
                int addy1 = Convert.ToInt32(loc1.Substring(1));
                int testcase1 = rn.Next(1, 10000);
                sol.SetMemoryVal(addy1, testcase1);
                user.SetMemoryVal(addy1, testcase1);

                int addy2 = Convert.ToInt32(loc2.Substring(1));
                int testcase2 = rn.Next(1, 10000);
                sol.SetRegisterVal(addy2, testcase2);
                user.SetRegisterVal(addy2, testcase2);
                return Tuple.Create(testcase1, testcase2);
            }
            else throw new Exception();
        }

        static int inputOneValTestCases(ARMEmulator sol, ARMEmulator user, string loc1)
        {
            if (loc1[0] == 'M')
            {
                int addy1 = Convert.ToInt32(loc1.Substring(1));
                int testcase1 = rn.Next(1, 10000);
                sol.SetMemoryVal(addy1, testcase1);
                user.SetMemoryVal(addy1, testcase1);
                return testcase1;

            }
            else if (loc1[0] == 'R')
            {
                int addy1 = Convert.ToInt32(loc1.Substring(1));
                int testcase1 = rn.Next(1, 10000);
                sol.SetMemoryVal(addy1, testcase1);
                user.SetMemoryVal(addy1, testcase1);
                return testcase1;
            }
            else throw new Exception();
        }

        static string oneInputPassedResultBuilder(int testCaseNum, string case1Loc, int case1Val, string resultLocation, int requiredresult, int userresult)
        {
            string result = $"Testcase {testCaseNum}";
            for (int j = testCaseNum.ToString().Length; j < 5; j++)
            {
                result += " ";
            }
            result += $"PASSED: {case1Loc} = {case1Val}";
            for (int j = case1Val.ToString().Length; j < 5; j++)
            {
                result += " ";
            }
            result += $" Expected {resultLocation} = {requiredresult}";
            for (int j = requiredresult.ToString().Length; j < 5; j++)
            {
                result += " ";
            }
            result += $" Your {resultLocation} = ";
            result += userresult.ToString();
            for (int j = requiredresult.ToString().Length; j < 5; j++)
            {
                result += " ";
            }
            return result;
        }
        static void attemptE1(ARMEmulator userProgram)
        {
            ARMEmulator solution = getSolution(1, "E");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 1000; i++)
            {
                var cases = inputTwoValTestCases(solution, userProgram, "M1", "M2");
                int testCaseMVal1 = cases.Item1;
                int testCaseMVal2 = cases.Item2;
                int requiredresult = testCase(solution, "M", 0);
                solution.Reset();
                int userresult = testCase(userProgram, "M", 0);
                userProgram.Reset();
                if (userresult != requiredresult)
                {
                    failTestCase($"Testcase {i + 1} FAILED: M1 = {testCaseMVal1} M2 = {testCaseMVal2} Expected M0 = {requiredresult} Your M0 = {userresult}");
                }
                else
                {
                    Console.WriteLine(twoInputPassedResultBuilder(i + 1, "M1", testCaseMVal1, "M2", testCaseMVal2, "M0", requiredresult, userresult));
                }
            }

            Console.WriteLine("Program is valid");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
        }

        static void attemptE2(ARMEmulator userProgram)
        {
            string[] rawInst = userProgram.getRawInst();
            bool mov = false;
            foreach (string s in rawInst)
            {
                if (s.Substring(0, 3).ToUpper() == "MOV")
                {
                    mov = true; break;
                }
            }
            if (!mov)
            {
                Console.WriteLine("FAILED: You have not directly inputted the key into a register");
                Console.WriteLine("Press h to display a hint or enter to continue");
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.H)
                {
                    Console.WriteLine("HINT: Look at the instruction MOV on the AQA Instruction Set");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    return;

                }
                else
                {
                    Console.Clear();
                    return;
                }
            }
            ARMEmulator solution = getSolution(2, "E");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 1000; i++)
            {
                int testCaseMVal1 = inputOneValTestCases(solution, userProgram, "M1");
                int requiredresult = testCase(solution, "M", 0);
                solution.Reset();
                int userresult = testCase(userProgram, "M", 0);
                userProgram.Reset();


                if (userresult != requiredresult)
                {
                    failTestCase($"Testcase {i + 1} FAILED: M1 = {testCaseMVal1} Expected M0 = {requiredresult} Your M0 = {userresult}");
                }
                else
                {
                    Console.WriteLine(oneInputPassedResultBuilder(i + 1, "M1", testCaseMVal1, "M0", requiredresult, userresult));
                }
            }
            Console.WriteLine("Program is valid");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void attemptM1(ARMEmulator userProgram)
        {
            ARMEmulator solution = getSolution(1, "M");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 1000; i++)
            {
                var cases = inputTwoValTestCases(solution, userProgram, "M1", "M2");
                int testCaseMVal1 = cases.Item1;
                int testCaseMVal2 = cases.Item2;
                int requiredresult = testCase(solution, "M", 0);
                solution.Reset();
                int userresult = testCase(userProgram, "M", 0);
                userProgram.Reset();
                if (userresult != requiredresult)
                {
                    failTestCase($"Testcase {i + 1} FAILED: M1 = {testCaseMVal1} M2 = {testCaseMVal2} Expected M0 = {requiredresult} Your M0 = {userresult}");
                }
                else
                {
                    Console.WriteLine(twoInputPassedResultBuilder(i + 1, "M1", testCaseMVal1, "M2", testCaseMVal2, "M0", requiredresult, userresult));
                }
            }

            Console.WriteLine("Program is valid");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
        }
        static void failTestCase(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
            Environment.Exit(0);
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
                    Console.WriteLine("Logic gates\r\n> Value A is stored in memory address 1\r\n> Value B is stored in memory address 2\r\n> Carry out the following operation and store the result in memory address 0\r\n> NOT( (A \u2022 B) \u2022 (A + B)) ");
                }
            }
            else if (diff == "H")
            {
                if (num == 1)
                {
                    Console.WriteLine("ADDTOWNS PT 2\r\n> n values are stored in memory address locations 1,2 … ,n\r\n> The number n is stored in memory location 0\r\n> Using indirect addressing (more info in manual at start) add all of these values\r\n> Store the result of the operation in Register 0\r\n");
                }
            }
            Console.WriteLine("Press r to view required instruction usage for this questions");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press a to submit a solution");

        }
        static void printOtherChallengeInstUse(int num, string diff)
        {
            Console.SetCursorPosition(100, 0);
            if (diff == "E")
            {
                if (num == 1)
                {

                    Console.WriteLine("Required Instructions:\nLDR\nSTR\nADD");
                }
                if (num == 2)
                {
                    Console.WriteLine("Required Instructions:\nLDR\nSTR\nEOR");
                }
            }
            else if (diff == "M")
            {
                if (num == 1)
                {
                    Console.WriteLine("Required Instructions:\nLDR\nSTR\nAND\nORR\nMVN");
                }

            }
            else if (diff == "H")
            {
                if (num == 1)
                {
                }
            }


        }

        static void writePageNum(int num, int cap)
        {
            int cursortop = Console.CursorTop;
            int cursorwidth = Console.CursorLeft;
            int length = num.ToString().Length + cap.ToString().Length + 1 + "Challenge: ".Length;
            Console.SetCursorPosition(Console.WindowWidth - length, 0);
            Console.Write("Challenge: " + num + "/" + cap);
            Console.SetCursorPosition(cursortop, cursorwidth);
        }

    }







}
