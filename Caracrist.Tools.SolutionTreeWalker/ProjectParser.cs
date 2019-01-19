using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Caracrist.Tools.SolutionTreeWalker
{
    public class ProjectParser
    { 
        public ProjectParser(SolutionParser solution, string name, Uri uri, Guid uid)
        {
            Solution = solution;
            Name = name;
            ProjectFileUri = uri;
            Uid = uid;
            ProjectFileContent = new XmlDocument();
            ProjectFileContent.Load(ProjectFileUri.AbsolutePath);

            Trace.Write($"ProjectParser: {this}");
        }
        public string Name { get; private set; }
        public Guid Uid { get; private set; }
        public override string ToString()
        {
            return $"{Name} {{{Uid}}}";
        }

        public IEnumerable<ReferenceParser> References
        {
            get
            {
                foreach (var assemblyReference in AssemblyReferences)
                {
                    yield return assemblyReference;
                }
                foreach (var projectReferences in ProjectReferences)
                {
                    yield return projectReferences;
                }
                foreach (var nugetReferences in NugetReferences)
                {
                    yield return nugetReferences;
                }
            }
        }

        public IEnumerable<AssemblyReferenceParser> AssemblyReferences
        {
            get
            {
                var assemblyNodes = ProjectFileContent.SelectNodes("*[local-name()='Project']/*[local-name()='ItemGroup']/*[local-name()='Reference']");
                for (int i = 0; i < assemblyNodes.Count; i++)
                {
                    yield return new AssemblyReferenceParser(this, assemblyNodes[i]);
                }
            }
        }
        public IEnumerable<NugetReferenceParser> NugetReferences
        {
            get
            {
                Uri packagesConfigFileUri;
                if (!Uri.TryCreate(ProjectFileUri, "packages.config", out packagesConfigFileUri))
                {
                    throw new ProjectParserException($"Failed to create packagesConfigFileUri from: [{ProjectFileUri}]");
                }
                if (!File.Exists(packagesConfigFileUri.AbsolutePath))
                {
                    yield break;
                }
                var packagesConfigFileContent = new XmlDocument();
                packagesConfigFileContent.Load(packagesConfigFileUri.AbsolutePath);
                var packageNodes = packagesConfigFileContent.SelectNodes("*[local-name()='packages']/*[local-name()='package']");
                for (int i = 0; i < packageNodes.Count; i++)
                {
                    yield return new NugetReferenceParser(this, packageNodes[i]);
                }
            }
        }
        public IEnumerable<ProjectReferenceParser> ProjectReferences
        {
            get
            {
                var projectNodes = ProjectFileContent.SelectNodes("*[local-name()='Project']/*[local-name()='ItemGroup']/*[local-name()='ProjectReference']");
                for (int i = 0; i < projectNodes.Count; i++)
                {
                    yield return new ProjectReferenceParser(this, projectNodes[i]);
                }
            }
        }

        public SolutionParser Solution { get; private set; }
        public Uri ProjectFileUri { get; private set; }
        XmlDocument ProjectFileContent { get; set; }
    }
}
