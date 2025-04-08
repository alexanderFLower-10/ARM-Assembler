using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMAssember2
{
    // condition is EQ GT NE LT or R for just a regular branch
    public class BranchesInst : Instruction
    {
        private string label;
        private string condition; 
        public BranchesInst( string label, string condition = "r")
        {
            this.label = label;
            this.condition = condition;
        }
    }
    public class CompareInst : Instruction
    {
        private int Rn;
        private int operand2;
        private string addresingType;
        public CompareInst(int Rn, string operand2)
        {
            this.Rn = Rn;
            var tuple = getAddresingType(operand2);
            addresingType = tuple.Item1;
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
    public class Label : Instruction
    {
        private string label;
        public Label(string label) { this.label = label; }
        public string getLabel() { return label; }
    }
}
