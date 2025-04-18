using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMAssember2
{
    public class CMP
    {
        public void Execute(ARMEmulator ARM, CompareInst parameters)
        {
            int Rn = ARM.GetRegisterVal(parameters.getRn());
            int operand2 = parameters.getOperand2();
            if(operand2 == Rn)
            {
                ARM.setSR("EQ");
            }
            else if (Rn > operand2)
            {
                ARM.setSR("GT");
            }
            else if (Rn < operand2)
            {
                ARM.setSR("LT");
            }
        }
    }
 
}
