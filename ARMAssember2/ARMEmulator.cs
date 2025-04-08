using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public ARMEmulator(List<Instruction> instructions, int PC = 0, int RegistersCap = 16, int MemoryCap = 16)
        {
            Registers = new int[RegistersCap];
            Memory = new int[MemoryCap];
            this.PC = PC;
            this.instructions = instructions;
            labelsLocations = new Dictionary<string, int>();
        }
        public void Step()
        {
            if (instructions[PC].GetType() == typeof(Label))
            {
                Label temp = (Label) instructions[PC];
                string labelname = temp.getLabel();
                if (!labelsLocations.ContainsKey(labelname))
                {
                    labelsLocations.Add(labelname, PC);
                }
                return;
            }

        }

        

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
