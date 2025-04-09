 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMAssember2
{
    public abstract class TwoParameterExecutes
    {
        public abstract void Execute(ARMEmulator ARM, TwoParameterInst parameters);
    }

    public class LDR : TwoParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, TwoParameterInst parameters)
        {
            int memval = ARM.GetMemoryVal(parameters.getOperand2());
            ARM.SetRegisterVal(parameters.getRd(), memval);

        }
    }
    public class STR : TwoParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, TwoParameterInst parameters)
        {
            int rval = ARM.GetRegisterVal(parameters.getRd());
            ARM.SetMemoryVal(parameters.getOperand2(), rval);
        }
    }
    public class MOV : TwoParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, TwoParameterInst parameters)
        {
            ARM.SetRegisterVal(parameters.getRd(), parameters.getOperand2());
        }
    }
    public class MVN : TwoParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, TwoParameterInst parameters)
        {
            BinaryStuff bin = new BinaryStuff();
            int operand2 = parameters.getOperand2();
            string operand = bin.DecimalToBinary(operand2);
            string res = "";
            for(int i = 0; i < operand.Length; i++)
            {
                if (operand[i] == '1') res += '0';
                else res += '1';
            }
            int result = bin.BinaryToDecimal(res);
            ARM.SetRegisterVal(parameters.getRd(), result);

        }
    }
}
