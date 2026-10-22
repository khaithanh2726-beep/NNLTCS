
namespace bai01_BTTL
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblLop;
        private Label lblMaSV;
        private Label lblHoTen;
        private Label lblNgaySinh;

        private ComboBox cboLop;
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
            lblLop = new Label();
            lblMaSV = new Label();
            lblHoTen = new Label();
            lblNgaySinh = new Label();

            cboLop = new ComboBox();
            txtMaSV = new TextBox();
            txtHoTen = new TextBox();
            txtNgaySinh = new MaskedTextBox();

            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();

            SuspendLayout();

            lblLop.AutoSize = true;
            lblLop.Location = new Point(25, 30);
            lblLop.Text = "Lớp";

            cboLop.Location = new Point(105, 27);
            cboLop.Size = new Size(225, 28);
            cboLop.Name = "cboLop";
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;

            lblMaSV.AutoSize = true;
            lblMaSV.Location = new Point(25, 70);
            lblMaSV.Text = "Mã sv";

            txtMaSV.Location = new Point(105, 67);
            txtMaSV.Size = new Size(225, 27);
            txtMaSV.Name = "txtMaSV";

            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(25, 110);
            lblHoTen.Text = "Họ tên";

            txtHoTen.Location = new Point(105, 107);
            txtHoTen.Size = new Size(225, 27);
            txtHoTen.Name = "txtHoTen";

            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(25, 150);
            lblNgaySinh.Text = "Ngày sinh";

            txtNgaySinh.Location = new Point(105, 147);
            txtNgaySinh.Size = new Size(225, 27);
            txtNgaySinh.Name = "txtNgaySinh";
            txtNgaySinh.Mask = "00/00/0000";
            txtNgaySinh.PromptChar = '_';

            btnThem.Location = new Point(25, 200);
            btnThem.Size = new Size(90, 40);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnXoa.Location = new Point(140, 200);
            btnXoa.Size = new Size(90, 40);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnSua.Location = new Point(255, 200);
            btnSua.Size = new Size(90, 40);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 270);

            Controls.Add(lblLop);
            Controls.Add(lblMaSV);
            Controls.Add(lblHoTen);
            Controls.Add(lblNgaySinh);

            Controls.Add(cboLop);
            Controls.Add(txtMaSV);
            Controls.Add(txtHoTen);
            Controls.Add(txtNgaySinh);

            Controls.Add(btnThem);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);

            Name = "Form1";
            Text = "frmSinhvien_Combo";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
