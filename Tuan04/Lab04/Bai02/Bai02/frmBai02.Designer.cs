#nullable enable

namespace Bai02;

partial class frmBai02
{
    private System.ComponentModel.IContainer? components = null;

    private Label lblHoTen = null!;
    private Label lblTaiKhoan = null!;
    private Label lblEmail = null!;
    private Label lblMatKhau = null!;
    private Label lblXacNhan = null!;

    private TextBox txtHoTen = null!;
    private TextBox txtTaiKhoan = null!;
    private TextBox txtEmail = null!;
    private TextBox txtMatKhau = null!;
    private TextBox txtXacNhan = null!;

    private Button btnDangKy = null!;
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

        lblHoTen = new Label();
        lblTaiKhoan = new Label();
        lblEmail = new Label();
        lblMatKhau = new Label();
        lblXacNhan = new Label();

        txtHoTen = new TextBox();
        txtTaiKhoan = new TextBox();
        txtEmail = new TextBox();
        txtMatKhau = new TextBox();
        txtXacNhan = new TextBox();

        btnDangKy = new Button();
        btnThoat = new Button();

        errorProvider1 = new ErrorProvider(components);

        SuspendLayout();

        // lblHoTen
        lblHoTen.AutoSize = true;
        lblHoTen.Location = new Point(70, 50);
        lblHoTen.Name = "lblHoTen";
        lblHoTen.Size = new Size(70, 15);
        lblHoTen.Text = "Họ tên (*)";

        // txtHoTen
        txtHoTen.Location = new Point(180, 45);
        txtHoTen.Name = "txtHoTen";
        txtHoTen.Size = new Size(350, 23);
        txtHoTen.TabIndex = 0;

        // lblTaiKhoan
        lblTaiKhoan.AutoSize = true;
        lblTaiKhoan.Location = new Point(70, 90);
        lblTaiKhoan.Name = "lblTaiKhoan";
        lblTaiKhoan.Size = new Size(95, 15);
        lblTaiKhoan.Text = "Tên đăng nhập (*)";

        // txtTaiKhoan
        txtTaiKhoan.Location = new Point(180, 85);
        txtTaiKhoan.Name = "txtTaiKhoan";
        txtTaiKhoan.Size = new Size(350, 23);
        txtTaiKhoan.TabIndex = 1;

        // lblEmail
        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(70, 130);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(95, 15);
        lblEmail.Text = "Địa chỉ email (*)";

        // txtEmail
        txtEmail.Location = new Point(180, 125);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(350, 23);
        txtEmail.TabIndex = 2;
        txtEmail.Leave += txtEmail_Leave;

        // lblMatKhau
        lblMatKhau.AutoSize = true;
        lblMatKhau.Location = new Point(70, 170);
        lblMatKhau.Name = "lblMatKhau";
        lblMatKhau.Size = new Size(85, 15);
        lblMatKhau.Text = "Mật khẩu (*)";

        // txtMatKhau
        txtMatKhau.Location = new Point(180, 165);
        txtMatKhau.Name = "txtMatKhau";
        txtMatKhau.Size = new Size(350, 23);
        txtMatKhau.TabIndex = 3;
        txtMatKhau.UseSystemPasswordChar = true;

        // lblXacNhan
        lblXacNhan.AutoSize = true;
        lblXacNhan.Location = new Point(70, 210);
        lblXacNhan.Name = "lblXacNhan";
        lblXacNhan.Size = new Size(110, 15);
        lblXacNhan.Text = "Xác nhận mật khẩu (*)";

        // txtXacNhan
        txtXacNhan.Location = new Point(180, 205);
        txtXacNhan.Name = "txtXacNhan";
        txtXacNhan.Size = new Size(350, 23);
        txtXacNhan.TabIndex = 4;
        txtXacNhan.UseSystemPasswordChar = true;

        // btnDangKy
        btnDangKy.Location = new Point(180, 255);
        btnDangKy.Name = "btnDangKy";
        btnDangKy.Size = new Size(100, 35);
        btnDangKy.TabIndex = 5;
        btnDangKy.Text = "Đăng ký";
        btnDangKy.UseVisualStyleBackColor = true;
        btnDangKy.Click += btnDangKy_Click;

        // btnThoat
        btnThoat.Location = new Point(300, 255);
        btnThoat.Name = "btnThoat";
        btnThoat.Size = new Size(100, 35);
        btnThoat.TabIndex = 6;
        btnThoat.Text = "Thoát";
        btnThoat.UseVisualStyleBackColor = true;
        btnThoat.Click += btnThoat_Click;

        // errorProvider1
        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

        // frmBai02
        AcceptButton = btnDangKy;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(620, 350);
        Controls.Add(btnThoat);
        Controls.Add(btnDangKy);
        Controls.Add(txtXacNhan);
        Controls.Add(lblXacNhan);
        Controls.Add(txtMatKhau);
        Controls.Add(lblMatKhau);
        Controls.Add(txtEmail);
        Controls.Add(lblEmail);
        Controls.Add(txtTaiKhoan);
        Controls.Add(lblTaiKhoan);
        Controls.Add(txtHoTen);
        Controls.Add(lblHoTen);
        Name = "frmBai02";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Lab04 - Bài 2: Đăng ký tài khoản";
        FormClosing += frmBai02_FormClosing;

        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}