namespace Caracrist.Tools.SolutionTreeWalker
{
    partial class DependenciesReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TraceBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TraceBox
            // 
            this.TraceBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TraceBox.Location = new System.Drawing.Point(0, 243);
            this.TraceBox.Name = "TraceBox";
            this.TraceBox.Size = new System.Drawing.Size(1136, 171);
            this.TraceBox.TabIndex = 0;
            this.TraceBox.Text = "";
            // 
            // DependenciesReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 414);
            this.Controls.Add(this.TraceBox);
            this.Name = "DependenciesReportForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DependenciesReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.RichTextBox TraceBox;
    }
}

