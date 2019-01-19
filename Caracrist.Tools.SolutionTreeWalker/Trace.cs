using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caracrist.Tools.SolutionTreeWalker
{
    public class Trace
    {
        internal static RichTextBox Box;
        public static void Write(string line)
        {
            if (Box.InvokeRequired)
            {
                Box.Invoke(new Action(() =>
                {
                    Box.AppendText($"{line}\n");
                }));
            }
            else
            {
                   Box.AppendText($"{line}\n");
            }
        }
    }
}
