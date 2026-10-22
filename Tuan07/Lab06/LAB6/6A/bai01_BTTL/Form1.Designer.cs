
namespace bai01_BTTL
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblMaMH;
        private System.Windows.Forms.Label lblTenMH;
        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.TextBox txtTenMH;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMaMH = new Label();
            lblTenMH = new Label();
            txtMaMH = new TextBox();
            txtTenMH = new TextBox();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();

            SuspendLayout();

            // Label Mã môn học
            lblMaMH.AutoSize = true;
            lblMaMH.Location = new Point(25, 30);
            lblMaMH.Text = "Mã mh";

            // TextBox Mã môn học
            txtMaMH.Location = new Point(90, 27);
            txtMaMH.Size = new Size(220, 27);
            txtMaMH.Name = "txtMaMH";

            // Label Tên môn học
            lblTenMH.AutoSize = true;
            lblTenMH.Location = new Point(25, 75);
            lblTenMH.Text = "Tên mh";

            // TextBox Tên môn học
            txtTenMH.Location = new Point(90, 72);
            txtTenMH.Size = new Size(220, 27);
            txtTenMH.Name = "txtTenMH";

            // Button Thêm
            btnThem.Location = new Point(25, 125);
            btnThem.Size = new Size(85, 40);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            // Button Xóa
            btnXoa.Location = new Point(125, 125);
            btnXoa.Size = new Size(85, 40);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            // Button Sửa
            btnSua.Location = new Point(225, 125);
            btnSua.Size = new Size(85, 40);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            // Form
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 195);
            Controls.Add(lblMaMH);
            Controls.Add(lblTenMH);
            Controls.Add(txtMaMH);
            Controls.Add(txtTenMH);
            Controls.Add(btnThem);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);

            Name = "Form1";
            Text = "Quản lý môn học";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
