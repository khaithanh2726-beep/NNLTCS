
namespace bai01_BTVN
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblMaKhoa;
        private Label lblMaLop;
        private Label lblTenLop;

        private TextBox txtMaKhoa;
        private TextBox txtMaLop;
        private TextBox txtTenLop;

        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMaKhoa = new Label();
            lblMaLop = new Label();
            lblTenLop = new Label();

            txtMaKhoa = new TextBox();
            txtMaLop = new TextBox();
            txtTenLop = new TextBox();

            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();

            SuspendLayout();

            // Mã khoa
            lblMaKhoa.AutoSize = true;
            lblMaKhoa.Location = new Point(25, 30);
            lblMaKhoa.Text = "Mã khoa";

            txtMaKhoa.Location = new Point(100, 27);
            txtMaKhoa.Size = new Size(230, 27);
            txtMaKhoa.Name = "txtMaKhoa";

            // Mã lớp
            lblMaLop.AutoSize = true;
            lblMaLop.Location = new Point(25, 75);
            lblMaLop.Text = "Mã lớp";

            txtMaLop.Location = new Point(100, 72);
            txtMaLop.Size = new Size(230, 27);
            txtMaLop.Name = "txtMaLop";

            // Tên lớp
            lblTenLop.AutoSize = true;
            lblTenLop.Location = new Point(25, 120);
            lblTenLop.Text = "Tên lớp";

            txtTenLop.Location = new Point(100, 117);
            txtTenLop.Size = new Size(230, 27);
            txtTenLop.Name = "txtTenLop";

            // Nút Thêm
            btnThem.Location = new Point(25, 180);
            btnThem.Size = new Size(90, 40);
            btnThem.Text = "Thêm";
            btnThem.Name = "btnThem";
            btnThem.Click += btnThem_Click;

            // Nút Xóa
            btnXoa.Location = new Point(135, 180);
            btnXoa.Size = new Size(90, 40);
            btnXoa.Text = "Xóa";
            btnXoa.Name = "btnXoa";
            btnXoa.Click += btnXoa_Click;

            // Nút Sửa
            btnSua.Location = new Point(245, 180);
            btnSua.Size = new Size(90, 40);
            btnSua.Text = "Sửa";
            btnSua.Name = "btnSua";
            btnSua.Click += btnSua_Click;

            // Form
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 250);

            Controls.Add(lblMaKhoa);
            Controls.Add(lblMaLop);
            Controls.Add(lblTenLop);

            Controls.Add(txtMaKhoa);
            Controls.Add(txtMaLop);
            Controls.Add(txtTenLop);

            Controls.Add(btnThem);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);

            Name = "Form1";
            Text = "frmLop";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
