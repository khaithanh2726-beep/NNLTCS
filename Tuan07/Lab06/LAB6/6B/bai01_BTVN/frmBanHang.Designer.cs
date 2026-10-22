
namespace bai01_BTVN
{
    partial class frmBanHang
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnTaoHD;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThanhToan;

        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.Label lblSoLuong;

        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.ComboBox cboMaSP;
        private System.Windows.Forms.GroupBox groupBox1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnTaoHD = new System.Windows.Forms.Button();
            btnThem = new System.Windows.Forms.Button();
            btnHuy = new System.Windows.Forms.Button();
            btnThanhToan = new System.Windows.Forms.Button();

            lblMaHD = new System.Windows.Forms.Label();
            lblMaSP = new System.Windows.Forms.Label();
            lblSoLuong = new System.Windows.Forms.Label();

            txtMaHD = new System.Windows.Forms.TextBox();
            txtSoLuong = new System.Windows.Forms.TextBox();
            cboMaSP = new System.Windows.Forms.ComboBox();
            groupBox1 = new System.Windows.Forms.GroupBox();

            groupBox1.SuspendLayout();
            SuspendLayout();

            btnTaoHD.Location = new System.Drawing.Point(310, 25);
            btnTaoHD.Size = new System.Drawing.Size(160, 35);
            btnTaoHD.Text = "Tạo hóa đơn mới";
            btnTaoHD.Click += btnTaoHD_Click;

            groupBox1.Location = new System.Drawing.Point(60, 85);
            groupBox1.Size = new System.Drawing.Size(450, 245);
            groupBox1.Text = "Chi tiết hóa đơn";

            lblMaHD.Location = new System.Drawing.Point(25, 40);
            lblMaHD.Size = new System.Drawing.Size(110, 25);
            lblMaHD.Text = "Mã hóa đơn";

            txtMaHD.Location = new System.Drawing.Point(150, 35);
            txtMaHD.Size = new System.Drawing.Size(210, 27);
            txtMaHD.ReadOnly = true;

            lblMaSP.Location = new System.Drawing.Point(25, 85);
            lblMaSP.Size = new System.Drawing.Size(110, 25);
            lblMaSP.Text = "Mã sản phẩm";

            cboMaSP.Location = new System.Drawing.Point(150, 80);
            cboMaSP.Size = new System.Drawing.Size(210, 28);
            cboMaSP.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            lblSoLuong.Location = new System.Drawing.Point(25, 130);
            lblSoLuong.Size = new System.Drawing.Size(110, 25);
            lblSoLuong.Text = "Số lượng";

            txtSoLuong.Location = new System.Drawing.Point(150, 125);
            txtSoLuong.Size = new System.Drawing.Size(210, 27);

            btnThem.Location = new System.Drawing.Point(175, 185);
            btnThem.Size = new System.Drawing.Size(90, 35);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnHuy.Location = new System.Drawing.Point(285, 185);
            btnHuy.Size = new System.Drawing.Size(90, 35);
            btnHuy.Text = "Hủy";
            btnHuy.Click += btnHuy_Click;

            btnThanhToan.Location = new System.Drawing.Point(345, 350);
            btnThanhToan.Size = new System.Drawing.Size(165, 38);
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.Click += btnThanhToan_Click;

            groupBox1.Controls.Add(lblMaHD);
            groupBox1.Controls.Add(txtMaHD);
            groupBox1.Controls.Add(lblMaSP);
            groupBox1.Controls.Add(cboMaSP);
            groupBox1.Controls.Add(lblSoLuong);
            groupBox1.Controls.Add(txtSoLuong);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(btnHuy);

            AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            ClientSize = new System.Drawing.Size(580, 425);

            Controls.Add(btnTaoHD);
            Controls.Add(groupBox1);
            Controls.Add(btnThanhToan);

            Name = "frmBanHang";
            Text = "BanHang";
            StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            Load += frmBanHang_Load;

            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }
    }
}
