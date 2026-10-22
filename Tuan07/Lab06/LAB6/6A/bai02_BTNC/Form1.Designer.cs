
namespace bai02_BTNC
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblMaSV;
        private Label lblMaMH;
        private Label lblDiem;

        private TextBox txtMaSV;
        private TextBox txtMaMH;
        private TextBox txtDiem;

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
            lblMaSV = new Label();
            lblMaMH = new Label();
            lblDiem = new Label();

            txtMaSV = new TextBox();
            txtMaMH = new TextBox();
            txtDiem = new TextBox();

            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();

            SuspendLayout();

            // Mã sinh viên
            lblMaSV.AutoSize = true;
            lblMaSV.Location = new Point(25, 30);
            lblMaSV.Text = "Mã sv";

            txtMaSV.Location = new Point(90, 27);
            txtMaSV.Size = new Size(230, 27);
            txtMaSV.Name = "txtMaSV";

            // Mã môn học
            lblMaMH.AutoSize = true;
            lblMaMH.Location = new Point(25, 75);
            lblMaMH.Text = "Mã mh";

            txtMaMH.Location = new Point(90, 72);
            txtMaMH.Size = new Size(230, 27);
            txtMaMH.Name = "txtMaMH";

            // Điểm
            lblDiem.AutoSize = true;
            lblDiem.Location = new Point(25, 120);
            lblDiem.Text = "Điểm";

            txtDiem.Location = new Point(90, 117);
            txtDiem.Size = new Size(230, 27);
            txtDiem.Name = "txtDiem";

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

            Controls.Add(lblMaSV);
            Controls.Add(lblMaMH);
            Controls.Add(lblDiem);

            Controls.Add(txtMaSV);
            Controls.Add(txtMaMH);
            Controls.Add(txtDiem);

            Controls.Add(btnThem);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);

            Name = "Form1";
            Text = "Quản lý Điểm";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
