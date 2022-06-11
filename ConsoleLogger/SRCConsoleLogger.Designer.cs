namespace ConsoleLogger
{
    partial class SRCConsoleLogger
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.lblFocusPatcher = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbConsole
            // 
            this.rtbConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbConsole.Location = new System.Drawing.Point(5, 5);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(523, 402);
            this.rtbConsole.TabIndex = 1;
            this.rtbConsole.Text = "";
            // 
            // lblFocusPatcher
            // 
            this.lblFocusPatcher.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFocusPatcher.Location = new System.Drawing.Point(197, 190);
            this.lblFocusPatcher.Name = "lblFocusPatcher";
            this.lblFocusPatcher.Size = new System.Drawing.Size(32, 16);
            this.lblFocusPatcher.TabIndex = 2;
            this.lblFocusPatcher.Text = "This label only exists to take focus from RichTextBox";
            // 
            // SRCConsoleLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbConsole);
            this.Controls.Add(this.lblFocusPatcher);
            this.Name = "SRCConsoleLogger";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(533, 412);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.Label lblFocusPatcher;
    }
}
