using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caracrist.Tools.SolutionTreeWalker
{
    static class Program
    {
        static Dictionary<Guid, ProjectParser> projectsByUid = new Dictionary<Guid, ProjectParser>();
        static Dictionary<string, ProjectParser> projectsByName = new Dictionary<string, ProjectParser>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new DependenciesReportForm(args[0]);
            Trace.Box = form.TraceBox;
            Application.Run(form);
        }
    }
}
