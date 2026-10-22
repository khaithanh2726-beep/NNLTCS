
namespace bai01_BTVN
{
    partial class frmSanPham
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThoat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTenSP = new System.Windows.Forms.Label();
            txtTenSP = new System.Windows.Forms.TextBox();
            btnThem = new System.Windows.Forms.Button();
            btnThoat = new System.Windows.Forms.Button();

            SuspendLayout();

            lblTenSP.AutoSize = true;
            lblTenSP.Location = new System.Drawing.Point(35, 45);
            lblTenSP.Text = "Tên sản phẩm";

            txtTenSP.Location = new System.Drawing.Point(145, 40);
            txtTenSP.Size = new System.Drawing.Size(200, 27);
            txtTenSP.Name = "txtTenSP";

            btnThem.Location = new System.Drawing.Point(90, 100);
            btnThem.Size = new System.Drawing.Size(90, 35);
            btnThem.Name = "btnThem";
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnThoat.Location = new System.Drawing.Point(230, 100);
            btnThoat.Size = new System.Drawing.Size(90, 35);
            btnThoat.Name = "btnThoat";
            btnThoat.Text = "Thoát";
            btnThoat.Click += btnThoat_Click;

            AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            ClientSize = new System.Drawing.Size(410, 185);

            Controls.Add(lblTenSP);
            Controls.Add(txtTenSP);
            Controls.Add(btnThem);
            Controls.Add(btnThoat);

            Name = "frmSanPham";
            Text = "Thêm sản phẩm mới";
            StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
