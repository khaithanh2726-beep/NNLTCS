
namespace bai01_BTVN
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnTaoTonKho;
        private System.Windows.Forms.ToolStripMenuItem btnSanPham;
        private System.Windows.Forms.ToolStripMenuItem btnBanHang;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            btnTaoTonKho = new System.Windows.Forms.ToolStripMenuItem();
            btnSanPham = new System.Windows.Forms.ToolStripMenuItem();
            btnBanHang = new System.Windows.Forms.ToolStripMenuItem();

            menuStrip1.SuspendLayout();
            SuspendLayout();

            menuStrip1.Items.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    btnTaoTonKho,
                    btnSanPham,
                    btnBanHang
                });

            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(650, 30);

            btnTaoTonKho.Text = "Tạo tồn kho";
            btnTaoTonKho.Click += btnTaoTonKho_Click;

            btnSanPham.Text = "Thêm sản phẩm mới";
            btnSanPham.Click += btnSanPham_Click;

            btnBanHang.Text = "Bán hàng";
            btnBanHang.Click += btnBanHang_Click;

            AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            ClientSize = new System.Drawing.Size(650, 350);

            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;

            Name = "Form1";
            Text = "Quản lý cửa hàng";
            StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
