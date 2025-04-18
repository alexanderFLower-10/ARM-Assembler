using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMAssember2
{
    public class HALTException : Exception
    {
        public HALTException()
        {
        }

        public HALTException(string message)
            : base(message)
        {
        }

        public HALTException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class InstParsingException : Exception
    {
        public InstParsingException()
        {
        }

        public InstParsingException(string message)
            : base(message)
        {
        }

        public InstParsingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
