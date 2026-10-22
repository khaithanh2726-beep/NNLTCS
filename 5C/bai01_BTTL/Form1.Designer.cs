namespace bai01_BTTL
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
            lblNhapSo = new Label();
            txtNhapSo = new TextBox();
            btnCapNhat = new Button();
            cboSo = new ComboBox();
            lblUocSo = new Label();
            lstUocSo = new ListBox();
            btnTongUoc = new Button();
            btnDemChan = new Button();
            btnDemNguyenTo = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // lblNhapSo
            // 
            lblNhapSo.AutoSize = true;
            lblNhapSo.Location = new Point(120, 31);
            lblNhapSo.Name = "lblNhapSo";
            lblNhapSo.Size = new Size(66, 20);
            lblNhapSo.TabIndex = 0;
            lblNhapSo.Text = "Nhập Số";
            // 
            // txtNhapSo
            // 
            txtNhapSo.Location = new Point(123, 62);
            txtNhapSo.Margin = new Padding(3, 4, 3, 4);
            txtNhapSo.Name = "txtNhapSo";
            txtNhapSo.Size = new Size(120, 27);
            txtNhapSo.TabIndex = 1;
            // 
            // btnCapNhat
            // 
            btnCapNhat.Location = new Point(255, 59);
            btnCapNhat.Margin = new Padding(3, 4, 3, 4);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(90, 35);
            btnCapNhat.TabIndex = 2;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = true;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // cboSo
            // 
            cboSo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSo.FormattingEnabled = true;
            cboSo.Location = new Point(123, 106);
            cboSo.Margin = new Padding(3, 4, 3, 4);
            cboSo.Name = "cboSo";
            cboSo.Size = new Size(222, 28);
            cboSo.TabIndex = 3;
            cboSo.SelectedIndexChanged += cboSo_SelectedIndexChanged;
            // 
            // lblUocSo
            // 
            lblUocSo.AutoSize = true;
            lblUocSo.Location = new Point(390, 31);
            lblUocSo.Name = "lblUocSo";
            lblUocSo.Size = new Size(151, 20);
            lblUocSo.TabIndex = 4;
            lblUocSo.Text = "Danh sách các ước số";
            // 
            // lstUocSo
            // 
            lstUocSo.FormattingEnabled = true;
            lstUocSo.Location = new Point(393, 62);
            lstUocSo.Margin = new Padding(3, 4, 3, 4);
            lstUocSo.Name = "lstUocSo";
            lstUocSo.Size = new Size(250, 164);
            lstUocSo.TabIndex = 5;
            // 
            // btnTongUoc
            // 
            btnTongUoc.Location = new Point(393, 244);
            btnTongUoc.Margin = new Padding(3, 4, 3, 4);
            btnTongUoc.Name = "btnTongUoc";
            btnTongUoc.Size = new Size(250, 38);
            btnTongUoc.TabIndex = 6;
            btnTongUoc.Text = "Tổng các ước số";
            btnTongUoc.UseVisualStyleBackColor = true;
            btnTongUoc.Click += btnTongUoc_Click;
            // 
            // btnDemChan
            // 
            btnDemChan.Location = new Point(393, 294);
            btnDemChan.Margin = new Padding(3, 4, 3, 4);
            btnDemChan.Name = "btnDemChan";
            btnDemChan.Size = new Size(250, 38);
            btnDemChan.TabIndex = 7;
            btnDemChan.Text = "Số lượng các ướ&c số chẵn";
            btnDemChan.UseVisualStyleBackColor = true;
            btnDemChan.Click += btnDemChan_Click;
            // 
            // btnDemNguyenTo
            // 
            btnDemNguyenTo.Location = new Point(393, 344);
            btnDemNguyenTo.Margin = new Padding(3, 4, 3, 4);
            btnDemNguyenTo.Name = "btnDemNguyenTo";
            btnDemNguyenTo.Size = new Size(250, 38);
            btnDemNguyenTo.TabIndex = 8;
            btnDemNguyenTo.Text = "Số lượng các ước số &nguyên tố";
            btnDemNguyenTo.UseVisualStyleBackColor = true;
            btnDemNguyenTo.Click += btnDemNguyenTo_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(260, 344);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(85, 38);
            btnThoat.TabIndex = 9;
            btnThoat.Text = "Th&oát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 419);
            Controls.Add(btnThoat);
            Controls.Add(btnDemNguyenTo);
            Controls.Add(btnDemChan);
            Controls.Add(btnTongUoc);
            Controls.Add(lstUocSo);
            Controls.Add(lblUocSo);
            Controls.Add(cboSo);
            Controls.Add(btnCapNhat);
            Controls.Add(txtNhapSo);
            Controls.Add(lblNhapSo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Combobox";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNhapSo;
        private System.Windows.Forms.TextBox txtNhapSo;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.ComboBox cboSo;
        private System.Windows.Forms.Label lblUocSo;
        private System.Windows.Forms.ListBox lstUocSo;
        private System.Windows.Forms.Button btnTongUoc;
        private System.Windows.Forms.Button btnDemChan;
        private System.Windows.Forms.Button btnDemNguyenTo;
        private System.Windows.Forms.Button btnThoat;
    }
}