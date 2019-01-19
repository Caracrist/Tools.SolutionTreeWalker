using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caracrist.Tools.SolutionTreeWalker
{
    public class AssemblyReferenceParserException : Exception
    {
        public AssemblyReferenceParserException(string message) : base(message)
        {

        }
        public AssemblyReferenceParserException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
