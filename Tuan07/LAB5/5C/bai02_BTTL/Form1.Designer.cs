namespace bai02_BTTL
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tvLop = new System.Windows.Forms.TreeView();
            this.lblChonLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.grpSinhVien = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.chkThemLop = new System.Windows.Forms.CheckBox();
            this.grpThemLop = new System.Windows.Forms.GroupBox();
            this.btnThemLop = new System.Windows.Forms.Button();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.grpSinhVien.SuspendLayout();
            this.grpThemLop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvLop
            // 
            this.tvLop.Location = new System.Drawing.Point(12, 12);
            this.tvLop.Name = "tvLop";
            this.tvLop.Size = new System.Drawing.Size(260, 420);
            this.tvLop.TabIndex = 0;
            this.tvLop.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLop_AfterSelect);
            // 
            // lblChonLop
            // 
            this.lblChonLop.AutoSize = true;
            this.lblChonLop.Location = new System.Drawing.Point(300, 25);
            this.lblChonLop.Name = "lblChonLop";
            this.lblChonLop.Size = new System.Drawing.Size(64, 16);
            this.lblChonLop.TabIndex = 1;
            this.lblChonLop.Text = "Chọn Lớp";
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(375, 22);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(270, 24);
            this.cboLop.TabIndex = 2;
            // 
            // grpSinhVien
            // 
            this.grpSinhVien.Controls.Add(this.btnXoa);
            this.grpSinhVien.Controls.Add(this.btnCapNhat);
            this.grpSinhVien.Controls.Add(this.txtDiaChi);
            this.grpSinhVien.Controls.Add(this.txtHoTen);
            this.grpSinhVien.Controls.Add(this.txtMaSV);
            this.grpSinhVien.Controls.Add(this.lblDiaChi);
            this.grpSinhVien.Controls.Add(this.lblHoTen);
            this.grpSinhVien.Controls.Add(this.lblMaSV);
            this.grpSinhVien.Location = new System.Drawing.Point(290, 65);
            this.grpSinhVien.Name = "grpSinhVien";
            this.grpSinhVien.Size = new System.Drawing.Size(365, 220);
            this.grpSinhVien.TabIndex = 3;
            this.grpSinhVien.TabStop = false;
            this.grpSinhVien.Text = "Thông tin sinh viên";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(215, 170);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 30);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(85, 170);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(100, 30);
            this.btnCapNhat.TabIndex = 6;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(85, 125);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(260, 22);
            this.txtDiaChi.TabIndex = 5;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(85, 80);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(260, 22);
            this.txtHoTen.TabIndex = 4;
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(85, 35);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(260, 22);
            this.txtMaSV.TabIndex = 3;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(15, 128);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(50, 16);
            this.lblDiaChi.TabIndex = 2;
            this.lblDiaChi.Text = "Địa Chỉ";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(15, 83);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(52, 16);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ Tên";
            // 
            // lblMaSV
            // 
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Location = new System.Drawing.Point(15, 38);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(50, 16);
            this.lblMaSV.TabIndex = 0;
            this.lblMaSV.Text = "Mã SV:";
            // 
            // chkThemLop
            // 
            this.chkThemLop.AutoSize = true;
            this.chkThemLop.Location = new System.Drawing.Point(290, 300);
            this.chkThemLop.Name = "chkThemLop";
            this.chkThemLop.Size = new System.Drawing.Size(86, 20);
            this.chkThemLop.TabIndex = 4;
            this.chkThemLop.Text = "Thêm lớp";
            this.chkThemLop.UseVisualStyleBackColor = true;
            this.chkThemLop.CheckedChanged += new System.EventHandler(this.chkThemLop_CheckedChanged);
            // 
            // grpThemLop
            // 
            this.grpThemLop.Controls.Add(this.btnThemLop);
            this.grpThemLop.Controls.Add(this.txtTenLop);
            this.grpThemLop.Controls.Add(this.lblTenLop);
            this.grpThemLop.Location = new System.Drawing.Point(290, 330);
            this.grpThemLop.Name = "grpThemLop";
            this.grpThemLop.Size = new System.Drawing.Size(365, 80);
            this.grpThemLop.TabIndex = 5;
            this.grpThemLop.TabStop = false;
            this.grpThemLop.Text = "Thông tin lớp";
            // 
            // btnThemLop
            // 
            this.btnThemLop.Location = new System.Drawing.Point(260, 28);
            this.btnThemLop.Name = "btnThemLop";
            this.btnThemLop.Size = new System.Drawing.Size(95, 28);
            this.btnThemLop.TabIndex = 2;
            this.btnThemLop.Text = "Thêm lớp";
            this.btnThemLop.UseVisualStyleBackColor = true;
            this.btnThemLop.Click += new System.EventHandler(this.btnThemLop_Click);
            // 
            // txtTenLop
            // 
            this.txtTenLop.Location = new System.Drawing.Point(85, 31);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(165, 22);
            this.txtTenLop.TabIndex = 1;
            // 
            // lblTenLop
            // 
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Location = new System.Drawing.Point(15, 34);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Size = new System.Drawing.Size(56, 16);
            this.lblTenLop.TabIndex = 0;
            this.lblTenLop.Text = "Tên lớp";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 445);
            this.Controls.Add(this.grpThemLop);
            this.Controls.Add(this.chkThemLop);
            this.Controls.Add(this.grpSinhVien);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.lblChonLop);
            this.Controls.Add(this.tvLop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sinh viên";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpSinhVien.ResumeLayout(false);
            this.grpSinhVien.PerformLayout();
            this.grpThemLop.ResumeLayout(false);
            this.grpThemLop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TreeView tvLop;
        private System.Windows.Forms.Label lblChonLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.GroupBox grpSinhVien;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.CheckBox chkThemLop;
        private System.Windows.Forms.GroupBox grpThemLop;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.Button btnThemLop;
    }
}