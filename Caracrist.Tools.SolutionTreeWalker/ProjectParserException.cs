using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caracrist.Tools.SolutionTreeWalker
{
    public class ProjectParserException : Exception
    {
        public ProjectParserException(string message) : base(message)
        {

        }
        public ProjectParserException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
