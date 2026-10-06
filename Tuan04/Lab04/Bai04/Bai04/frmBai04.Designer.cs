#nullable enable

namespace Bai04;

partial class frmBai04
{
    private System.ComponentModel.IContainer? components = null;

    private Label lblNhapSo = null!;
    private Label lblDayVuaNhap = null!;
    private Label lblTong = null!;
    private Label lblTongChan = null!;
    private Label lblTongLe = null!;

    private TextBox txtNhapSo = null!;
    private TextBox txtDayVuaNhap = null!;
    private TextBox txtTong = null!;
    private TextBox txtTongChan = null!;
    private TextBox txtTongLe = null!;

    private Button btnNhap = null!;
    private Button btnTinhTong = null!;
    private Button btnTongChan = null!;
    private Button btnTongLe = null!;
    private Button btnTiepTuc = null!;
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

        lblNhapSo = new Label();
        lblDayVuaNhap = new Label();
        lblTong = new Label();
        lblTongChan = new Label();
        lblTongLe = new Label();

        txtNhapSo = new TextBox();
        txtDayVuaNhap = new TextBox();
        txtTong = new TextBox();
        txtTongChan = new TextBox();
        txtTongLe = new TextBox();

        btnNhap = new Button();
        btnTinhTong = new Button();
        btnTongChan = new Button();
        btnTongLe = new Button();
        btnTiepTuc = new Button();
        btnThoat = new Button();

        errorProvider1 = new ErrorProvider(components);

        SuspendLayout();

        // lblNhapSo
        lblNhapSo.AutoSize = true;
        lblNhapSo.Location = new Point(40, 40);
        lblNhapSo.Name = "lblNhapSo";
        lblNhapSo.Size = new Size(55, 15);
        lblNhapSo.Text = "Nhập số:";

        // txtNhapSo
        txtNhapSo.Location = new Point(120, 35);
        txtNhapSo.Name = "txtNhapSo";
        txtNhapSo.Size = new Size(180, 23);
        txtNhapSo.TabIndex = 0;
        txtNhapSo.KeyPress += txtNhapSo_KeyPress;

        // btnNhap
        btnNhap.Location = new Point(320, 34);
        btnNhap.Name = "btnNhap";
        btnNhap.Size = new Size(80, 27);
        btnNhap.TabIndex = 1;
        btnNhap.Text = "Nhập";
        btnNhap.UseVisualStyleBackColor = true;
        btnNhap.Click += btnNhap_Click;

        // lblDayVuaNhap
        lblDayVuaNhap.AutoSize = true;
        lblDayVuaNhap.Location = new Point(40, 80);
        lblDayVuaNhap.Name = "lblDayVuaNhap";
        lblDayVuaNhap.Size = new Size(85, 15);
        lblDayVuaNhap.Text = "Dãy vừa nhập:";

        // txtDayVuaNhap
        txtDayVuaNhap.Location = new Point(40, 105);
        txtDayVuaNhap.Multiline = true;
        txtDayVuaNhap.Name = "txtDayVuaNhap";
        txtDayVuaNhap.ReadOnly = true;
        txtDayVuaNhap.ScrollBars = ScrollBars.Vertical;
        txtDayVuaNhap.Size = new Size(360, 70);
        txtDayVuaNhap.TabIndex = 2;

        // lblTong
        lblTong.AutoSize = true;
        lblTong.Location = new Point(40, 200);
        lblTong.Name = "lblTong";
        lblTong.Size = new Size(40, 15);
        lblTong.Text = "Tổng:";

        // txtTong
        txtTong.Location = new Point(120, 195);
        txtTong.Name = "txtTong";
        txtTong.ReadOnly = true;
        txtTong.Size = new Size(180, 23);
        txtTong.TabIndex = 3;

        // lblTongChan
        lblTongChan.AutoSize = true;
        lblTongChan.Location = new Point(40, 235);
        lblTongChan.Name = "lblTongChan";
        lblTongChan.Size = new Size(70, 15);
        lblTongChan.Text = "Tổng chẵn:";

        // txtTongChan
        txtTongChan.Location = new Point(120, 230);
        txtTongChan.Name = "txtTongChan";
        txtTongChan.ReadOnly = true;
        txtTongChan.Size = new Size(180, 23);
        txtTongChan.TabIndex = 4;

        // lblTongLe
        lblTongLe.AutoSize = true;
        lblTongLe.Location = new Point(40, 270);
        lblTongLe.Name = "lblTongLe";
        lblTongLe.Size = new Size(60, 15);
        lblTongLe.Text = "Tổng lẻ:";

        // txtTongLe
        txtTongLe.Location = new Point(120, 265);
        txtTongLe.Name = "txtTongLe";
        txtTongLe.ReadOnly = true;
        txtTongLe.Size = new Size(180, 23);
        txtTongLe.TabIndex = 5;

        // btnTinhTong
        btnTinhTong.Location = new Point(40, 315);
        btnTinhTong.Name = "btnTinhTong";
        btnTinhTong.Size = new Size(90, 35);
        btnTinhTong.TabIndex = 6;
        btnTinhTong.Text = "Tính tổng";
        btnTinhTong.UseVisualStyleBackColor = true;
        btnTinhTong.Click += btnTinhTong_Click;

        // btnTongChan
        btnTongChan.Location = new Point(140, 315);
        btnTongChan.Name = "btnTongChan";
        btnTongChan.Size = new Size(90, 35);
        btnTongChan.TabIndex = 7;
        btnTongChan.Text = "Tổng chẵn";
        btnTongChan.UseVisualStyleBackColor = true;
        btnTongChan.Click += btnTongChan_Click;

        // btnTongLe
        btnTongLe.Location = new Point(240, 315);
        btnTongLe.Name = "btnTongLe";
        btnTongLe.Size = new Size(90, 35);
        btnTongLe.TabIndex = 8;
        btnTongLe.Text = "Tổng lẻ";
        btnTongLe.UseVisualStyleBackColor = true;
        btnTongLe.Click += btnTongLe_Click;

        // btnTiepTuc
        btnTiepTuc.Location = new Point(340, 315);
        btnTiepTuc.Name = "btnTiepTuc";
        btnTiepTuc.Size = new Size(90, 35);
        btnTiepTuc.TabIndex = 9;
        btnTiepTuc.Text = "Tiếp tục";
        btnTiepTuc.UseVisualStyleBackColor = true;
        btnTiepTuc.Click += btnTiepTuc_Click;

        // btnThoat
        btnThoat.Location = new Point(340, 360);
        btnThoat.Name = "btnThoat";
        btnThoat.Size = new Size(90, 35);
        btnThoat.TabIndex = 10;
        btnThoat.Text = "Thoát";
        btnThoat.UseVisualStyleBackColor = true;
        btnThoat.Click += btnThoat_Click;

        // errorProvider
        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

        // frmBai04
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(480, 430);

        Controls.Add(btnThoat);
        Controls.Add(btnTiepTuc);
        Controls.Add(btnTongLe);
        Controls.Add(btnTongChan);
        Controls.Add(btnTinhTong);

        Controls.Add(txtTongLe);
        Controls.Add(lblTongLe);

        Controls.Add(txtTongChan);
        Controls.Add(lblTongChan);

        Controls.Add(txtTong);
        Controls.Add(lblTong);

        Controls.Add(txtDayVuaNhap);
        Controls.Add(lblDayVuaNhap);

        Controls.Add(btnNhap);
        Controls.Add(txtNhapSo);
        Controls.Add(lblNhapSo);

        Name = "frmBai04";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Lab04 - Bài 4: Dãy số nguyên";

        FormClosing += frmBai04_FormClosing;

        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}