using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Caracrist.Tools.SolutionTreeWalker
{
    public class ReferenceParser
    {
        protected XmlNode ReferenceNode { get; private set; }
        public ProjectParser Project { get; private set; }

        public ReferenceParser(ProjectParser project, XmlNode referenceNode)
        {
            Project = project;
            ReferenceNode = referenceNode;
        }
    }
}
