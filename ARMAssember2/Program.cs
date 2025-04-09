using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.SqlServer.Server;

namespace ARMAssember2
{
    internal class Program
    {
        // Parameters class holds instructions until the actual instruction class can be executed when passing through to ARM
        static void Main(string[] args)
        {
            string filepath = Console.ReadLine();
            var instlist = getInstList(filepath);
            ARMEmulator ARM = new ARMEmulator(instlist);
            ARM.Step();
        }

        static List<Instruction> getInstList(string filepath)
        {
            List<Instruction> list = new List<Instruction>();
            string[] insts = File.ReadAllLines(filepath);
            foreach(string inst in insts)
            {
                if (inst[0] == 'B' && inst[1] == ' ') list.Add(getBranchInst(inst));
                else if (inst[inst.Length - 1] == ':' && inst.Trim() == inst)
                {
                    string temp = inst.Substring(0, inst.Length - 1);
                    list.Add(createLabel(temp));
                }
                else if(inst == "HALT")
                {
                    HALT h =  new HALT();
                    list.Add(h);
                }
                else
                {
                    string instType = inst[0].ToString() + inst[1].ToString() + inst[2].ToString();
                    string[] arr = inst.Substring(4).Split(',');
                    for (int i = 1; i < arr.Length; i++)
                    {
                        arr[i] = arr[i].Trim();
                    }
                    if (instType == "CMP")
                    {
                        list.Add(createCMP(arr));   
                    }
                    else if (arr.Length == 3)
                    {
                        list.Add(getThreeParInst(arr, instType));
                    }
                    else if (arr.Length == 2)
                    {
                        list.Add(getTwoParInst(arr, instType));
                    }
                    else throw new ArgumentException("Inst too large or small parameter wise");
                }
            }
            return list;
        }

        static CompareInst createCMP(string[] operands)
        {
            return new CompareInst(Convert.ToInt32(operands[0]), operands[1]);
        }

        static Label createLabel(string label)
        {
            return new Label(label);
        }

        static TwoParameterInst getTwoParInst(string[] operands, string instType)
        {
            return new TwoParameterInst(instType, Convert.ToInt32(operands[0].Substring(1)), operands[1].Substring(1));
        }
        static ThreeParameterInst getThreeParInst(string[] operands, string instType)
        {
            return new ThreeParameterInst(instType, Convert.ToInt32(operands[0].Substring(1)), Convert.ToInt32(operands[1].Substring(1)), operands[2]);
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
