#nullable enable

namespace Bai01;

partial class frmBai01
{
    private System.ComponentModel.IContainer? components = null;

   private Label lblA = null!;
private Label lblB = null!;
private Label lblKetQua = null!;

private TextBox txtA = null!;
private TextBox txtB = null!;
private TextBox txtKetQua = null!;

private Button btnCong = null!;
private Button btnTru = null!;
private Button btnNhan = null!;
private Button btnChia = null!;

private ErrorProvider errorProvider1 = null!;

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
        components = new System.ComponentModel.Container();

        lblA = new Label();
        lblB = new Label();
        lblKetQua = new Label();

        txtA = new TextBox();
        txtB = new TextBox();
        txtKetQua = new TextBox();

        btnCong = new Button();
        btnTru = new Button();
        btnNhan = new Button();
        btnChia = new Button();

        errorProvider1 = new ErrorProvider(components);

        SuspendLayout();

        // lblA
        lblA.AutoSize = true;
        lblA.Location = new Point(80, 60);
        lblA.Name = "lblA";
        lblA.Size = new Size(24, 15);
        lblA.Text = "a =";

        // txtA
        txtA.Location = new Point(140, 55);
        txtA.Name = "txtA";
        txtA.Size = new Size(200, 23);
        txtA.TabIndex = 0;
        txtA.KeyPress += txtA_KeyPress;
        txtA.Leave += txtA_Leave;

        // lblB
        lblB.AutoSize = true;
        lblB.Location = new Point(80, 105);
        lblB.Name = "lblB";
        lblB.Size = new Size(24, 15);
        lblB.Text = "b =";

        // txtB
        txtB.Location = new Point(140, 100);
        txtB.Name = "txtB";
        txtB.Size = new Size(200, 23);
        txtB.TabIndex = 1;
        txtB.KeyPress += txtB_KeyPress;
        txtB.Leave += txtB_Leave;

        // lblKetQua
        lblKetQua.AutoSize = true;
        lblKetQua.Location = new Point(60, 150);
        lblKetQua.Name = "lblKetQua";
        lblKetQua.Size = new Size(65, 15);
        lblKetQua.Text = "Kết quả =";

        // txtKetQua
        txtKetQua.Location = new Point(140, 145);
        txtKetQua.Name = "txtKetQua";
        txtKetQua.ReadOnly = true;
        txtKetQua.Size = new Size(200, 23);
        txtKetQua.TabIndex = 2;

        // btnCong
        btnCong.Location = new Point(70, 205);
        btnCong.Name = "btnCong";
        btnCong.Size = new Size(70, 35);
        btnCong.TabIndex = 3;
        btnCong.Text = "+";
        btnCong.UseVisualStyleBackColor = true;
        btnCong.Click += btnCong_Click;

        // btnTru
        btnTru.Location = new Point(155, 205);
        btnTru.Name = "btnTru";
        btnTru.Size = new Size(70, 35);
        btnTru.TabIndex = 4;
        btnTru.Text = "-";
        btnTru.UseVisualStyleBackColor = true;
        btnTru.Click += btnTru_Click;

        // btnNhan
        btnNhan.Location = new Point(240, 205);
        btnNhan.Name = "btnNhan";
        btnNhan.Size = new Size(70, 35);
        btnNhan.TabIndex = 5;
        btnNhan.Text = "x";
        btnNhan.UseVisualStyleBackColor = true;
        btnNhan.Click += btnNhan_Click;

        // btnChia
        btnChia.Location = new Point(325, 205);
        btnChia.Name = "btnChia";
        btnChia.Size = new Size(70, 35);
        btnChia.TabIndex = 6;
        btnChia.Text = "/";
        btnChia.UseVisualStyleBackColor = true;
        btnChia.Click += btnChia_Click;

        // errorProvider1
        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

        // frmBai01
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(480, 300);
        Controls.Add(btnChia);
        Controls.Add(btnNhan);
        Controls.Add(btnTru);
        Controls.Add(btnCong);
        Controls.Add(txtKetQua);
        Controls.Add(lblKetQua);
        Controls.Add(txtB);
        Controls.Add(lblB);
        Controls.Add(txtA);
        Controls.Add(lblA);
        Name = "frmBai01";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Lab04 - Bài 1: Cộng Trừ Nhân Chia";
        FormClosing += frmBai01_FormClosing;

        ResumeLayout(false);
        PerformLayout();
    }
}