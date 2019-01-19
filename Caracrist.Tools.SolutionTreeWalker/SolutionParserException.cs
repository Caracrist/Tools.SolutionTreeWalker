using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caracrist.Tools.SolutionTreeWalker
{
    public class SolutionParserException : Exception
    {
        public SolutionParserException(string message) : base(message)
        {

        }
        public SolutionParserException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
