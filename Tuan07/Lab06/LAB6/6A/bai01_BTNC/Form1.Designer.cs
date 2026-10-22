
namespace bai01_BTNC
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblMaLop;
        private Label lblMaSV;
        private Label lblHoTen;
        private Label lblNgaySinh;

        private TextBox txtMaLop;
        private TextBox txtMaSV;
        private TextBox txtHoTen;
        private MaskedTextBox txtNgaySinh;

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
            lblMaLop = new Label();
            lblMaSV = new Label();
            lblHoTen = new Label();
            lblNgaySinh = new Label();

            txtMaLop = new TextBox();
            txtMaSV = new TextBox();
            txtHoTen = new TextBox();
            txtNgaySinh = new MaskedTextBox();

            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();

            SuspendLayout();

            // Mã lớp
            lblMaLop.AutoSize = true;
            lblMaLop.Location = new Point(25, 30);
            lblMaLop.Text = "Mã lớp";

            txtMaLop.Location = new Point(105, 27);
            txtMaLop.Size = new Size(225, 27);
            txtMaLop.Name = "txtMaLop";

            // Mã sinh viên
            lblMaSV.AutoSize = true;
            lblMaSV.Location = new Point(25, 70);
            lblMaSV.Text = "Mã sv";

            txtMaSV.Location = new Point(105, 67);
            txtMaSV.Size = new Size(225, 27);
            txtMaSV.Name = "txtMaSV";

            // Họ tên
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(25, 110);
            lblHoTen.Text = "Họ tên";

            txtHoTen.Location = new Point(105, 107);
            txtHoTen.Size = new Size(225, 27);
            txtHoTen.Name = "txtHoTen";

            // Ngày sinh
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(25, 150);
            lblNgaySinh.Text = "Ngày sinh";

            txtNgaySinh.Location = new Point(105, 147);
            txtNgaySinh.Size = new Size(225, 27);
            txtNgaySinh.Name = "txtNgaySinh";
            txtNgaySinh.Mask = "00/00/0000";
            txtNgaySinh.ValidatingType = typeof(DateTime);
            txtNgaySinh.PromptChar = '_';

            // Button Thêm
            btnThem.Location = new Point(25, 200);
            btnThem.Size = new Size(90, 40);
            btnThem.Text = "Thêm";
            btnThem.Name = "btnThem";
            btnThem.Click += btnThem_Click;

            // Button Xóa
            btnXoa.Location = new Point(140, 200);
            btnXoa.Size = new Size(90, 40);
            btnXoa.Text = "Xóa";
            btnXoa.Name = "btnXoa";
            btnXoa.Click += btnXoa_Click;

            // Button Sửa
            btnSua.Location = new Point(255, 200);
            btnSua.Size = new Size(90, 40);
            btnSua.Text = "Sửa";
            btnSua.Name = "btnSua";
            btnSua.Click += btnSua_Click;

            // Form
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 270);

            Controls.Add(lblMaLop);
            Controls.Add(lblMaSV);
            Controls.Add(lblHoTen);
            Controls.Add(lblNgaySinh);

            Controls.Add(txtMaLop);
            Controls.Add(txtMaSV);
            Controls.Add(txtHoTen);
            Controls.Add(txtNgaySinh);

            Controls.Add(btnThem);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);

            Name = "Form1";
            Text = "Quản lý sinh viên";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
