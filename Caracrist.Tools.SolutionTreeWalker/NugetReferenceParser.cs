using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Caracrist.Tools.SolutionTreeWalker
{
    public class NugetReferenceParser : ReferenceParser
    {
        public NugetReferenceParser(ProjectParser project, XmlNode referenceNode) : base(project, referenceNode)
        {
            Trace.Write($"NugetReference: {this}");
        }

        public NugetParser ReferencedNuget
        {
            get
            {
                return new NugetParser(Id, Version, FolderPath);
            }
        }
        public string Id
        {
            get
            {
                return ReferenceNode.Attributes["id"].Value;
            }
        }
        public Version Version
        {
            get
            {
                return new Version(ReferenceNode.Attributes["version"].Value);
            }
        }
        public string FolderName
        {
            get
            {
                return $"{Id}.{Version}";
            }
        }
        public Uri FolderPath
        {
            get
            {
                Uri folderPath;
                if (!Uri.TryCreate(Project.Solution.SlnFileUri, $"packages\\{FolderName}", out folderPath))
                {
                    throw new NugetReferenceParserException($"Failed to create folder path relative to solution file: {Project.Solution.SlnFileUri}");
                }
                return folderPath;
            }
        }
        public override string ToString()
        {
            return FolderName;
        }
    }
}
