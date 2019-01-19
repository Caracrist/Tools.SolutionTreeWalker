using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caracrist.Tools.SolutionTreeWalker
{
    enum EParseProgress
    {
        None,
        FoundVersion
    }
    public class SolutionParser
    {
        const string versionPrefix = "VisualStudioVersion = ";
        public SolutionParser(string slnPath)
        {
            try
            {
                SlnFileUri = new Uri(slnPath);
                SlnLines = File.ReadAllLines(slnPath);
            }
            catch(Exception ex)
            {
                throw new SolutionParserException($"Failed to load solution file from path: [{slnPath}]", ex);
            }

            foreach (var line in SlnLines)
            {
                if (line.StartsWith(versionPrefix))
                {
                    string version = line.Substring(versionPrefix.Length);
                    try
                    {
                        Version = new Version(version);
                    }
                    catch(Exception ex)
                    {
                        throw new SolutionParserException($"Failed to parse version from line: [{line}]", ex);
                    }
                    ExtractProjects();
                    return;
                }
            }
            throw new SolutionParserException($"No version found in solution file: [{slnPath}]");
        }
        public override string ToString()
        {
            return SlnFileUri.Segments.Last();
        }
        public void ExtractProjects()
        {
            if (Version.Major != 14)
            {
                throw new SolutionParserException($"Not supported solution file version: {Version}");
            }
            foreach (var line in SlnLines)
            {
                string[] lineParts = line.Split(',');
                if (lineParts.Length == 3 &&
                    lineParts[0].StartsWith("Project") &&
                    !lineParts[0].StartsWith(@"Project(""{2150E333-8FDC-42A3-9474-1A3956D46DE8}"")"))
                {
                    try
                    {
                        string name = lineParts[0].Split('=')[1].Trim(' ', '"');
                        string relativePath = lineParts[1].Trim(' ', '"');
                        Uri projectUri;
                        if (!Uri.TryCreate(SlnFileUri, relativePath, out projectUri))
                        {
                            throw new SolutionParserException($"Failed to create full path for project line [{line}]");
                        }
                        Guid projectUid = new Guid(lineParts[2].Trim(' ', '"'));
                        ProjectParser project = new ProjectParser(this, name, projectUri, projectUid);
                        projectsByUid[project.Uid] = project;
                        projectsByName[project.Name] = project;
                    }
                    catch (Exception ex)
                    {
                        throw new SolutionParserException($"Failed to parse project entry line: [{line}]", ex);
                    }
                }
            }
        }



        Dictionary<Guid, ProjectParser> projectsByUid = new Dictionary<Guid, ProjectParser>();
        Dictionary<string, ProjectParser> projectsByName = new Dictionary<string, ProjectParser>();
        public ProjectParser GetProject(Guid uid)
        {
            return projectsByUid[uid];
        }
        public ProjectParser GetProject(string name)
        {
            return projectsByName[name];
        }
        public IEnumerable<ProjectParser> Projects
        {
            get
            {
                foreach (var project in projectsByUid.Values)
                {
                    yield return project;
                }
            }
        }
        public Version Version { get; private set; }
        public Uri SlnFileUri { get; private set; }
        string[] SlnLines { get; set; }
    }
    
}
