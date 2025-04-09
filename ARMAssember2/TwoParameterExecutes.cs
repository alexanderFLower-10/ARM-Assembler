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

        }
    }
    public class STR : TwoParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, TwoParameterInst parameters)
        {

        }
    }
    public class MOV : TwoParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, TwoParameterInst parameters)
        {

        }
    }
    public class MVN : TwoParameterExecutes
    {
        public override void Execute(ARMEmulator ARM, TwoParameterInst parameters)
        {

        }
    }
}
