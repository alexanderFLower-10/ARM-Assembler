using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMAssember2
{
    public class TwoParameterInst : Instruction
    {
        private string inst;
        private int Rd;
        private int operand2;
        private string addresingType;

        public TwoParameterInst(string inst, int Rd, string operand2)
        {
            this.inst = inst;
            this.Rd = Rd;
            var tuple = getAddresingType(operand2);
            addresingType = tuple.Item1;
            if(inst == "STR" || inst == "LDR")
            {
                if (addresingType != "dm") throw new ArgumentException(inst + " cant have a operand other than a memory loc");
            }
            this.operand2 = tuple.Item2;
        }

        private Tuple<string, int> getAddresingType(string operand2)
        {
            if (operand2[0] == '#') return Tuple.Create("im", Convert.ToInt32(operand2.Substring(1)));
            if (operand2[0] == 'R') return Tuple.Create("dr", Convert.ToInt32(operand2.Substring(1)));
            if (operand2[0] == '[' && operand2[operand2.Length - 1] == ']') return Tuple.Create("indr", Convert.ToInt32(operand2.Substring(1, operand2.Length - 2)));
            if (Char.IsNumber(operand2[0])) return Tuple.Create("dm", Convert.ToInt32(operand2));
            else throw new ArgumentException("Invalid Instruction Type");
        }
    }
}
