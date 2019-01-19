using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caracrist.Tools.SolutionTreeWalker
{
    public partial class DependenciesReportForm : Form
    {
        public DependenciesReportForm(string slnPath)
        {
            this.slnPath = slnPath;
            InitializeComponent();
        }

        string slnPath;
        SolutionParser parser;

        private void DependenciesReportForm_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            parser = new SolutionParser(slnPath);

            foreach (var project in parser.Projects)
            {
                foreach (var reference in project.References)
                {
                }
            }
            Cursor = Cursors.Default;
        }
    }
}
