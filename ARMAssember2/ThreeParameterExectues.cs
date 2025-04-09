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
            
        }
    }
    public class SUB : ThreeParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, ThreeParameterInst parameters)
        {

        }
    }
    public class AND : ThreeParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, ThreeParameterInst parameters)
        {

        }
    }
    public class ORR : ThreeParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, ThreeParameterInst parameters)
        {

        }
    }
    public class EOR : ThreeParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, ThreeParameterInst parameters)
        {

        }
    }
    public class LSL : ThreeParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, ThreeParameterInst parameters)
        {

        }
    }
    public class LSR : ThreeParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, ThreeParameterInst parameters)
        {

        }

    }

}
