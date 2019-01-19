using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace Caracrist.Tools.SolutionTreeWalker
{
    public class AssemblyReferenceParser : ReferenceParser
    {
        public AssemblyReferenceParser(ProjectParser project, XmlNode referenceNode) : base(project, referenceNode)
        {
            Trace.Write($"AssemblyReference: {this}");
        }

        public override string ToString()
        {
            return $"{(HintPath == null ? AssemblyName : HintPath.ToString())} {(FileVersion == null ? "" : FileVersion.ToString())}";
        }
        public Version FileVersion
        {
            get
            {
                string includeValue = ReferenceNode.Attributes["Include"].Value;
                string[] valueParts = includeValue.Split(',');
                foreach (var valuePart in valueParts)
                {
                    if (valuePart.StartsWith("Version="))
                    {
                        return new Version(valuePart.Split('=')[1]);
                    }
                }
                return null;
            }
        }
        public string AssemblyName
        {
            get
            {
                string includeValue = ReferenceNode.Attributes["Include"].Value;
                return includeValue.Split(',')[0];
            }
        }
        public Uri HintPath
        {
            get
            {
                var hintNode = ReferenceNode.SelectSingleNode("*[local-name()='HintPath']");
                if (hintNode == null)
                {
                    return null;
                }
                string relativePath = hintNode.InnerText;
                Uri hintPath;
                if (!Uri.TryCreate(Project.ProjectFileUri, relativePath, out hintPath))
                {
                    throw new AssemblyReferenceParserException($"Failed to create path from [{relativePath}] relative to [{Project.ProjectFileUri}]");
                }
                return hintPath;
            }
        }
    }
}
