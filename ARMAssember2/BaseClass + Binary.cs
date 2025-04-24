using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ARMAssember2
{
    // Only used to store all instructions as a list

    public class Instruction
    {
    }
    public class HALT : Instruction
    {
        public HALT() { }   
    }
    public class BinaryStuff
    {
        public BinaryStuff() { }
        // top band recursion
        public string DecimalToBinary(int dec)
        {
            if (dec > 1) return DecimalToBinary(dec / 2) + (dec % 2);
            return dec.ToString();    
        }

        public int BinaryToDecimal(string bin)
        {
            double res = 0;
            for(int i = 0; i < bin.Length; i++)
            {
                if (bin[i] == '1') res += Math.Pow(2, bin.Length - i - 1);
            }
            return (int)res;    
        }
    }
}
