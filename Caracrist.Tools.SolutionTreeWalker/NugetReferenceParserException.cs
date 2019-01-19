using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caracrist.Tools.SolutionTreeWalker
{
    public class NugetReferenceParserException : Exception
    {
        public NugetReferenceParserException(string message) : base(message)
        {

        }
        public NugetReferenceParserException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
