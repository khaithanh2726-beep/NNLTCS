#nullable enable

namespace Bai06;

partial class frmBai06
{
    private System.ComponentModel.IContainer? components = null;

    private RadioButton rdoBacNhat = null!;
    private RadioButton rdoBacHai = null!;

    private Label lblA = null!;
    private Label lblB = null!;
    private Label lblC = null!;
    private Label lblKetQua = null!;

    private TextBox txtA = null!;
    private TextBox txtB = null!;
    private TextBox txtC = null!;
    private TextBox txtKetQua = null!;

    private Button btnGiai = null!;
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

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        rdoBacNhat = new RadioButton();
        rdoBacHai = new RadioButton();

        lblA = new Label();
        lblB = new Label();
        lblC = new Label();
        lblKetQua = new Label();

        txtA = new TextBox();
        txtB = new TextBox();
        txtC = new TextBox();
        txtKetQua = new TextBox();

        btnGiai = new Button();
        btnXoa = new Button();
        btnThoat = new Button();

        errorProvider1 = new ErrorProvider(components);

        SuspendLayout();

        // rdoBacNhat
        rdoBacNhat.AutoSize = true;
        rdoBacNhat.Location = new Point(70, 35);
        rdoBacNhat.Name = "rdoBacNhat";
        rdoBacNhat.Size = new Size(170, 19);
        rdoBacNhat.Text = "Phương trình bậc nhất";
        rdoBacNhat.CheckedChanged += rdoBacNhat_CheckedChanged;

        // rdoBacHai
        rdoBacHai.AutoSize = true;
        rdoBacHai.Location = new Point(270, 35);
        rdoBacHai.Name = "rdoBacHai";
        rdoBacHai.Size = new Size(155, 19);
        rdoBacHai.Text = "Phương trình bậc hai";
        rdoBacHai.CheckedChanged += rdoBacHai_CheckedChanged;

        // lblA
        lblA.AutoSize = true;
        lblA.Location = new Point(70, 80);
        lblA.Name = "lblA";
        lblA.Text = "a =";

        // txtA
        txtA.Location = new Point(130, 75);
        txtA.Name = "txtA";
        txtA.Size = new Size(260, 23);
        txtA.TabIndex = 0;
        txtA.KeyPress += txtSo_KeyPress;

        // lblB
        lblB.AutoSize = true;
        lblB.Location = new Point(70, 120);
        lblB.Name = "lblB";
        lblB.Text = "b =";

        // txtB
        txtB.Location = new Point(130, 115);
        txtB.Name = "txtB";
        txtB.Size = new Size(260, 23);
        txtB.TabIndex = 1;
        txtB.KeyPress += txtSo_KeyPress;

        // lblC
        lblC.AutoSize = true;
        lblC.Location = new Point(70, 160);
        lblC.Name = "lblC";
        lblC.Text = "c =";

        // txtC
        txtC.Location = new Point(130, 155);
        txtC.Name = "txtC";
        txtC.Size = new Size(260, 23);
        txtC.TabIndex = 2;
        txtC.KeyPress += txtSo_KeyPress;

        // lblKetQua
        lblKetQua.AutoSize = true;
        lblKetQua.Location = new Point(70, 200);
        lblKetQua.Name = "lblKetQua";
        lblKetQua.Text = "Kết quả:";

        // txtKetQua
        txtKetQua.Location = new Point(130, 195);
        txtKetQua.Multiline = true;
        txtKetQua.Name = "txtKetQua";
        txtKetQua.ReadOnly = true;
        txtKetQua.Size = new Size(430, 70);
        txtKetQua.TabIndex = 3;

        // btnGiai
        btnGiai.Location = new Point(130, 290);
        btnGiai.Name = "btnGiai";
        btnGiai.Size = new Size(90, 35);
        btnGiai.Text = "Giải";
        btnGiai.Enabled = false;
        btnGiai.UseVisualStyleBackColor = true;
        btnGiai.Click += btnGiai_Click;

        // btnXoa
        btnXoa.Location = new Point(240, 290);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(90, 35);
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;

        // btnThoat
        btnThoat.Location = new Point(350, 290);
        btnThoat.Name = "btnThoat";
        btnThoat.Size = new Size(90, 35);
        btnThoat.Text = "Thoát";
        btnThoat.UseVisualStyleBackColor = true;
        btnThoat.Click += btnThoat_Click;

        // ErrorProvider
        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

        // frmBai06
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(620, 370);

        Controls.Add(btnThoat);
        Controls.Add(btnXoa);
        Controls.Add(btnGiai);

        Controls.Add(txtKetQua);
        Controls.Add(lblKetQua);

        Controls.Add(txtC);
        Controls.Add(lblC);

        Controls.Add(txtB);
        Controls.Add(lblB);

        Controls.Add(txtA);
        Controls.Add(lblA);

        Controls.Add(rdoBacHai);
        Controls.Add(rdoBacNhat);

        Name = "frmBai06";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Lab04 - Bài 6: Giải phương trình";

        FormClosing += frmBai06_FormClosing;

        ResumeLayout(false);
        PerformLayout();
    }
}