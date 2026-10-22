
namespace bai02_BTNC
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.Label lblTongDiem;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.ListView lvDiem;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.TextBox txtTongDiem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMonHoc = new System.Windows.Forms.Label();
            lblTongDiem = new System.Windows.Forms.Label();
            cboMonHoc = new System.Windows.Forms.ComboBox();
            lvDiem = new System.Windows.Forms.ListView();
            btnLoc = new System.Windows.Forms.Button();
            txtTongDiem = new System.Windows.Forms.TextBox();

            SuspendLayout();

            // Label Môn học
            lblMonHoc.AutoSize = true;
            lblMonHoc.Location =
                new System.Drawing.Point(30, 35);
            lblMonHoc.Text = "Môn học";

            // ComboBox Môn học
            cboMonHoc.Location =
                new System.Drawing.Point(120, 30);
            cboMonHoc.Size =
                new System.Drawing.Size(260, 28);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Button Lọc dữ liệu
            btnLoc.Location =
                new System.Drawing.Point(420, 28);
            btnLoc.Size =
                new System.Drawing.Size(110, 32);
            btnLoc.Name = "btnLoc";
            btnLoc.Text = "Lọc dữ liệu";
            btnLoc.UseVisualStyleBackColor = true;
            btnLoc.Click += btnLoc_Click;

            // ListView
            lvDiem.Location =
                new System.Drawing.Point(30, 85);
            lvDiem.Size =
                new System.Drawing.Size(620, 300);
            lvDiem.Name = "lvDiem";

            lvDiem.View =
                System.Windows.Forms.View.Details;
            lvDiem.FullRowSelect = true;
            lvDiem.GridLines = true;
            lvDiem.MultiSelect = false;
            lvDiem.HideSelection = false;

            // Các cột ListView
            lvDiem.Columns.Add("STT", 50);
            lvDiem.Columns.Add("Tên SV", 160);
            lvDiem.Columns.Add("Ngày sinh", 130);
            lvDiem.Columns.Add("Tên môn học", 190);
            lvDiem.Columns.Add("Điểm", 80);

            // Label Tổng điểm
            lblTongDiem.AutoSize = true;
            lblTongDiem.Location =
                new System.Drawing.Point(420, 410);
            lblTongDiem.Text = "Tổng điểm";

            // TextBox Tổng điểm
            txtTongDiem.Location =
                new System.Drawing.Point(510, 405);
            txtTongDiem.Size =
                new System.Drawing.Size(140, 27);
            txtTongDiem.Name = "txtTongDiem";
            txtTongDiem.ReadOnly = true;

            // Form
            AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            ClientSize =
                new System.Drawing.Size(685, 465);

            Controls.Add(lblMonHoc);
            Controls.Add(lblTongDiem);
            Controls.Add(cboMonHoc);
            Controls.Add(lvDiem);
            Controls.Add(btnLoc);
            Controls.Add(txtTongDiem);

            Name = "Form1";
            Text = "Danh sách sinh viên";

            StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            Load += Form1_Load;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
