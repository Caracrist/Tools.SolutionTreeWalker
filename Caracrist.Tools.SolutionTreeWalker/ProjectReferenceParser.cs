using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Caracrist.Tools.SolutionTreeWalker
{
    public class ProjectReferenceParser : ReferenceParser
    {
        public ProjectReferenceParser(ProjectParser project, XmlNode referenceNode) : base(project, referenceNode)
        {
            Trace.Write($"ProjectReference: {this}");
        }
        public ProjectParser ReferencedProject
        {
            get
            {
                return Project.Solution.GetProject(Uid);
            }
        }
        public string Name
        {
            get
            {
                var nameNode = ReferenceNode.SelectSingleNode("*[local-name()='Name']");
                if (nameNode != null)
                    return nameNode.InnerText;
                return ReferencedProject.Name;
            }
        }
        public Guid Uid
        {
            get
            {
                return new Guid(ReferenceNode.SelectSingleNode("*[local-name()='Project']").InnerText);
            }
        }
        public override string ToString()
        {
            return $"{Name} {{{Uid}}}";
        }
    }
}
