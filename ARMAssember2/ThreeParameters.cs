using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ARMAssember2
{
     public class ThreeParameterInst : Instruction
     {
        private string inst;
        private int Rd;
        private int Rn;
        private string originalOperand2;
        private int operand2;
        private string addresingType;
        private string fullinst;
        private int linenum;

        public ThreeParameterInst(string inst, int Rd, int Rn, string operand2, int linenumber, string fullinst)
        {
            this.linenum = linenumber;
            this.fullinst = fullinst;
            originalOperand2 = operand2;
            this.inst = inst;
            this.Rd = Rd;
            this.Rn = Rn;
            var tuple = ComputeAddresingType(operand2, linenumber, fullinst);
            addresingType = tuple.Item1;
            this.operand2 = tuple.Item2;
        }

        public ThreeParameterInst Clone()
        {
            return new ThreeParameterInst(inst, Rd, Rn, originalOperand2, linenum, fullinst);
        }
        public int getRd() { return Rd; }
        public int getRn() { return Rn; }
        public string GetInstType() { return inst; }
        public void setOperand2(int value) { operand2 = value; }
        public int getOperand2() { return operand2; }
        public string getAddressingType() { return addresingType; }

        private Tuple<string, int> ComputeAddresingType(string operand2, int linenumber, string fullinst)
        {
            try
            {
                if (operand2[0] == '#') return Tuple.Create("im", Convert.ToInt32(operand2.Substring(1)));
                if (operand2[0] == 'R') return Tuple.Create("dr", Convert.ToInt32(operand2.Substring(1)));
                if (operand2[0] == '[' && operand2[operand2.Length - 1] == ']' && operand2[1] == 'R') return Tuple.Create("indr", Convert.ToInt32(operand2.Substring(2, inst.Length - 3)));
                if (Char.IsNumber(operand2[0])) return Tuple.Create("dm", Convert.ToInt32(operand2));
                else throw new ArgumentException("Invalid Instruction Type");
            }
            catch (System.FormatException)
            {
                throw new FormatException("Parameter invalid error on line " + linenumber + ":\n" + fullinst);
            }
            catch(Exception e)
            {
                throw new Exception("Fatal error occured, error handling needs to be implemented");
            }


        }
    }
}
