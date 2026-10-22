namespace bai02_BTVN
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuBai01_BTTL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBai02_BTTL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBai01_BTNC = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBai01_BTVN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBai02_BTVN = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBai01_BTTL,
            this.mnuBai02_BTTL,
            this.mnuBai01_BTNC,
            this.mnuBai01_BTVN,
            this.mnuBai02_BTVN});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(850, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuBai01_BTTL
            // 
            this.mnuBai01_BTTL.Name = "mnuBai01_BTTL";
            this.mnuBai01_BTTL.Size = new System.Drawing.Size(99, 24);
            this.mnuBai01_BTTL.Text = "bai01_BTTL";
            this.mnuBai01_BTTL.Click += new System.EventHandler(this.mnuBai01_BTTL_Click);
            // 
            // mnuBai02_BTTL
            // 
            this.mnuBai02_BTTL.Name = "mnuBai02_BTTL";
            this.mnuBai02_BTTL.Size = new System.Drawing.Size(99, 24);
            this.mnuBai02_BTTL.Text = "bai02_BTTL";
            this.mnuBai02_BTTL.Click += new System.EventHandler(this.mnuBai02_BTTL_Click);
            // 
            // mnuBai01_BTNC
            // 
            this.mnuBai01_BTNC.Name = "mnuBai01_BTNC";
            this.mnuBai01_BTNC.Size = new System.Drawing.Size(104, 24);
            this.mnuBai01_BTNC.Text = "bai01_BTNC";
            this.mnuBai01_BTNC.Click += new System.EventHandler(this.mnuBai01_BTNC_Click);
            // 
            // mnuBai01_BTVN
            // 
            this.mnuBai01_BTVN.Name = "mnuBai01_BTVN";
            this.mnuBai01_BTVN.Size = new System.Drawing.Size(104, 24);
            this.mnuBai01_BTVN.Text = "bai01_BTVN";
            this.mnuBai01_BTVN.Click += new System.EventHandler(this.mnuBai01_BTVN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 620);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BTVN_Tuan6";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuBai01_BTTL;
        private System.Windows.Forms.ToolStripMenuItem mnuBai02_BTTL;
        private System.Windows.Forms.ToolStripMenuItem mnuBai01_BTNC;
        private System.Windows.Forms.ToolStripMenuItem mnuBai01_BTVN;
        private System.Windows.Forms.ToolStripMenuItem mnuBai02_BTVN;
    }
}