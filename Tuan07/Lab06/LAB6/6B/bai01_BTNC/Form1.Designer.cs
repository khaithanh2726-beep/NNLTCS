
using System.Drawing;
using System.Windows.Forms;

namespace bai01_BTNC
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnHienThi;
        private Button btnThoat;
        private ListView lvLop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnHienThi = new Button();
            btnThoat = new Button();
            lvLop = new ListView();

            SuspendLayout();

            // Nút Hiển thị dữ liệu
            btnHienThi.Location = new Point(35, 20);
            btnHienThi.Size = new Size(120, 35);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Text = "Hiển thị dữ liệu";
            btnHienThi.UseVisualStyleBackColor = true;
            btnHienThi.Click += btnHienThi_Click;

            // ListView
            lvLop.Location = new Point(35, 65);
            lvLop.Size = new Size(550, 260);
            lvLop.Name = "lvLop";
            lvLop.View = View.Details;
            lvLop.FullRowSelect = true;
            lvLop.GridLines = true;
            lvLop.MultiSelect = false;
            lvLop.HideSelection = false;

            // Các cột ListView
            lvLop.Columns.Add("STT", 70);
            lvLop.Columns.Add("Mã lớp", 130);
            lvLop.Columns.Add("Tên lớp", 240);
            lvLop.Columns.Add("Mã khoa", 105);

            // Nút Thoát
            btnThoat.Location = new Point(450, 340);
            btnThoat.Size = new Size(135, 45);
            btnThoat.Name = "btnThoat";
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;

            // Form
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 405);

            Controls.Add(btnHienThi);
            Controls.Add(lvLop);
            Controls.Add(btnThoat);

            Name = "Form1";
            Text = "Danh sách Lớp";
            StartPosition = FormStartPosition.CenterScreen;

            ResumeLayout(false);
        }
    }
}
