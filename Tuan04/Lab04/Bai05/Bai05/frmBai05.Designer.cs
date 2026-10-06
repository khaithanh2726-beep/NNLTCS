#nullable enable

namespace Bai05;

partial class frmBai05
{
    private System.ComponentModel.IContainer? components = null;

    private Label lblSo = null!;
    private Label lblKetQua = null!;

    private TextBox txtSo = null!;
    private TextBox txtKetQua = null!;

    private Button btnThucHien = null!;
    private Button btnXoa = null!;
    private Button btnThoat = null!;

    private ErrorProvider errorProvider1 = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        lblSo = new Label();
        lblKetQua = new Label();

        txtSo = new TextBox();
        txtKetQua = new TextBox();

        btnThucHien = new Button();
        btnXoa = new Button();
        btnThoat = new Button();

        errorProvider1 = new ErrorProvider(components);

        SuspendLayout();

        // lblSo
        lblSo.AutoSize = true;
        lblSo.Location = new Point(50, 55);
        lblSo.Name = "lblSo";
        lblSo.Size = new Size(55, 15);
        lblSo.Text = "Nhập số:";

        // txtSo
        txtSo.Location = new Point(130, 50);
        txtSo.Name = "txtSo";
        txtSo.Size = new Size(250, 23);
        txtSo.TabIndex = 0;
        txtSo.KeyPress += txtSo_KeyPress;

        // lblKetQua
        lblKetQua.AutoSize = true;
        lblKetQua.Location = new Point(50, 100);
        lblKetQua.Name = "lblKetQua";
        lblKetQua.Size = new Size(50, 15);
        lblKetQua.Text = "Kết quả:";

        // txtKetQua
        txtKetQua.Location = new Point(130, 95);
        txtKetQua.Name = "txtKetQua";
        txtKetQua.ReadOnly = true;
        txtKetQua.Size = new Size(350, 23);
        txtKetQua.TabIndex = 1;

        // btnThucHien
        btnThucHien.Location = new Point(130, 150);
        btnThucHien.Name = "btnThucHien";
        btnThucHien.Size = new Size(100, 35);
        btnThucHien.TabIndex = 2;
        btnThucHien.Text = "Thực hiện";
        btnThucHien.UseVisualStyleBackColor = true;
        btnThucHien.Click += btnThucHien_Click;

        // btnXoa
        btnXoa.Location = new Point(245, 150);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(80, 35);
        btnXoa.TabIndex = 3;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;

        // btnThoat
        btnThoat.Location = new Point(340, 150);
        btnThoat.Name = "btnThoat";
        btnThoat.Size = new Size(80, 35);
        btnThoat.TabIndex = 4;
        btnThoat.Text = "Thoát";
        btnThoat.UseVisualStyleBackColor = true;
        btnThoat.Click += btnThoat_Click;

        // errorProvider1
        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

        // frmBai05
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(550, 240);

        Controls.Add(btnThoat);
        Controls.Add(btnXoa);
        Controls.Add(btnThucHien);
        Controls.Add(txtKetQua);
        Controls.Add(lblKetQua);
        Controls.Add(txtSo);
        Controls.Add(lblSo);

        Name = "frmBai05";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Lab04 - Bài 5: Đọc số thành chữ";

        FormClosing += frmBai05_FormClosing;

        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}