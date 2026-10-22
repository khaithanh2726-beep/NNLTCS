
using System.Drawing;
using System.Windows.Forms;

namespace bai02_BTTL
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblSinhVien;
        private Label lblMonHoc;
        private Label lblDiem;

        private ComboBox cboSinhVien;
        private ComboBox cboMonHoc;
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
            lblSinhVien = new Label();
            lblMonHoc = new Label();
            lblDiem = new Label();

            cboSinhVien = new ComboBox();
            cboMonHoc = new ComboBox();
            txtDiem = new TextBox();

            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();

            SuspendLayout();

            // Sinh viên
            lblSinhVien.AutoSize = true;
            lblSinhVien.Location = new Point(20, 30);
            lblSinhVien.Text = "Sinh viên";

            cboSinhVien.Location = new Point(100, 27);
            cboSinhVien.Size = new Size(230, 28);
            cboSinhVien.Name = "cboSinhVien";
            cboSinhVien.DropDownStyle =
                ComboBoxStyle.DropDownList;

            // Môn học
            lblMonHoc.AutoSize = true;
            lblMonHoc.Location = new Point(20, 75);
            lblMonHoc.Text = "Môn học";

            cboMonHoc.Location = new Point(100, 72);
            cboMonHoc.Size = new Size(230, 28);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.DropDownStyle =
                ComboBoxStyle.DropDownList;

            // Điểm
            lblDiem.AutoSize = true;
            lblDiem.Location = new Point(20, 120);
            lblDiem.Text = "Điểm";

            txtDiem.Location = new Point(100, 117);
            txtDiem.Size = new Size(230, 27);
            txtDiem.Name = "txtDiem";

            // Nút Thêm
            btnThem.Location = new Point(25, 180);
            btnThem.Size = new Size(90, 40);
            btnThem.Name = "btnThem";
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            // Nút Xóa
            btnXoa.Location = new Point(135, 180);
            btnXoa.Size = new Size(90, 40);
            btnXoa.Name = "btnXoa";
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            // Nút Sửa
            btnSua.Location = new Point(245, 180);
            btnSua.Size = new Size(90, 40);
            btnSua.Name = "btnSua";
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            // Form
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 250);

            Controls.Add(lblSinhVien);
            Controls.Add(lblMonHoc);
            Controls.Add(lblDiem);

            Controls.Add(cboSinhVien);
            Controls.Add(cboMonHoc);
            Controls.Add(txtDiem);

            Controls.Add(btnThem);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);

            Name = "Form1";
            Text = "frmDiem_combo";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
