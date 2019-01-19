using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caracrist.Tools.SolutionTreeWalker
{
    public class NugetParser
    {
        private Uri folderPath;
        private string id;
        private Version version;

        public NugetParser(string id, Version version, Uri folderPath)
        {
            this.id = id;
            this.version = version;
            this.folderPath = folderPath;
        }

        Uri NupkgFilePath
        {
            get
            {
                Uri fullPath;
                if (!Uri.TryCreate(folderPath, $"{id}.{version}.nupkg", out fullPath))
                {
                    throw new NugetParserException($"Failed to build nupkg file path with {folderPath}");
                }
                return fullPath;
            }
        }

        ZipArchive NupkgFileArchive
        {
            get
            {
                return ZipFile.OpenRead(NupkgFilePath.ToString());
            }
        }

    }
}
