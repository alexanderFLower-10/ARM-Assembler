using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMAssember2
{
    // Instruction class specialises down based on instType and is executed
    public abstract class ThreeParameterExecutes
    {
        public abstract void Execute(ARMEmulator ARM, ThreeParameterInst parameters);
    }

    public class ADD : ThreeParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, ThreeParameterInst parameters)
        {
            int result = ARM.GetRegisterVal(parameters.getRn()) + parameters.getOperand2();
            ARM.SetRegisterVal(parameters.getRd(), result);
            
        }
    }
    public class SUB : ThreeParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, ThreeParameterInst parameters)
        {
            int result = ARM.GetRegisterVal(parameters.getRn()) - parameters.getOperand2();
            ARM.SetRegisterVal(parameters.getRd(), result);
        }
    }
    public class AND : ThreeParameterExecutes
    {
       
        public override void Execute(ARMEmulator ARM, ThreeParameterInst parameters)
        {
            BinaryStuff bin = new BinaryStuff();
            string res = "";
            string temp = "";
            string Rn = bin.DecimalToBinary(ARM.GetRegisterVal(parameters.getRn()));
            string operand2 = bin.DecimalToBinary(parameters.getOperand2());
            if(!(Rn.Length == operand2.Length))
            {
                if(Rn.Length > operand2.Length)
                {
                    int diff = Rn.Length - operand2.Length;
                    for(int i = 0; i < diff; i++)
                    {
                        temp += "0";
                    }
                    temp += operand2;
                    operand2 = temp;

                }
                else
                {
                    int diff = operand2.Length - Rn.Length;
                    for (int i = 0; i < diff; i++)
                    {
                        temp += "0";
                    }
                    temp += Rn;
                    Rn = temp;
                }
            }
            for(int i = 0; i<operand2.Length; i++)
            {
                if (operand2[i] == '1' && Rn[i] == '1') res += '1';
                else res += '0';
            }
            int result = bin.BinaryToDecimal(res);
            ARM.SetRegisterVal(parameters.getRd(), result); 
        }
    }
    public class ORR : ThreeParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, ThreeParameterInst parameters)
        {
            BinaryStuff bin = new BinaryStuff();
            string res = "";
            string temp = "";
            string Rn = bin.DecimalToBinary(ARM.GetRegisterVal(parameters.getRn()));
            string operand2 = bin.DecimalToBinary(parameters.getOperand2());
            if (!(Rn.Length == operand2.Length))
            {
                if (Rn.Length > operand2.Length)
                {
                    int diff = Rn.Length - operand2.Length;
                    for (int i = 0; i < diff; i++)
                    {
                        temp += "0";
                    }
                    temp += operand2;
                    operand2 = temp;

                }
                else
                {
                    int diff = operand2.Length - Rn.Length;
                    for (int i = 0; i < diff; i++)
                    {
                        temp += "0";
                    }
                    temp += Rn;
                    Rn = temp;
                }
            }
            for (int i = 0; i < operand2.Length; i++)
            {
                if (operand2[i] == '1' || Rn[i] == '1') res += '1';
                else res += '0';
            }
            int result = bin.BinaryToDecimal(res);
            ARM.SetRegisterVal(parameters.getRd(), result);
        }
    }
    public class EOR : ThreeParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, ThreeParameterInst parameters)
        {
            BinaryStuff bin = new BinaryStuff();
            string res = "";
            string temp = "";
            string Rn = bin.DecimalToBinary(ARM.GetRegisterVal(parameters.getRn()));
            string operand2 = bin.DecimalToBinary(parameters.getOperand2());
            if (!(Rn.Length == operand2.Length))
            {
                if (Rn.Length > operand2.Length)
                {
                    int diff = Rn.Length - operand2.Length;
                    for (int i = 0; i < diff; i++)
                    {
                        temp += "0";
                    }
                    temp += operand2;
                    operand2 = temp;

                }
                else
                {
                    int diff = operand2.Length - Rn.Length;
                    for (int i = 0; i < diff; i++)
                    {
                        temp += "0";
                    }
                    temp += Rn;
                    Rn = temp;
                }
            }
            for (int i = 0; i < operand2.Length; i++)
            {
                if (operand2[i] == '1' && Rn[i] != '1') res += '1';
                else if (operand2[i] != '1' && Rn[i] == '1') res += '1';
                else res += '0';
            }
            int result = bin.BinaryToDecimal(res);
            ARM.SetRegisterVal(parameters.getRd(), result);
        }
    }
    public class LSL : ThreeParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, ThreeParameterInst parameters)
        {
            int Rn = (ARM.GetRegisterVal(parameters.getRn()));
            int operand2 = parameters.getOperand2();
            int result = Rn * (int)Math.Pow(2, operand2);
            ARM.SetRegisterVal(parameters.getRd(), result);
           
        }
    }
    public class LSR : ThreeParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, ThreeParameterInst parameters)
        {
            int Rn = (ARM.GetRegisterVal(parameters.getRn()));
            int operand2 = parameters.getOperand2();
            int result = Rn / (int)Math.Pow(2, operand2);
            if (result < 0) throw new Exception("We only do integers here (for now) ");
            ARM.SetRegisterVal(parameters.getRd(), result);
        }

    }

}
