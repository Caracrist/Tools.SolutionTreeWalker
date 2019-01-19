using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caracrist.Tools.SolutionTreeWalker
{
    public class NugetParserException : Exception
    {
        public NugetParserException(string message) : base(message)
        {

        }
        public NugetParserException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
