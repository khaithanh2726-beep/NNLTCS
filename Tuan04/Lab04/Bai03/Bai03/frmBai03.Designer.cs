#nullable enable

namespace Bai03;

partial class frmBai03
{
    private System.ComponentModel.IContainer? components = null;

    private Label lblA = null!;
    private Label lblB = null!;
    private Label lblUCLN = null!;
    private Label lblBCNN = null!;

    private TextBox txtA = null!;
    private TextBox txtB = null!;
    private TextBox txtUCLN = null!;
    private TextBox txtBCNN = null!;

    private Button btnTinh = null!;
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

        lblA = new Label();
        lblB = new Label();
        lblUCLN = new Label();
        lblBCNN = new Label();

        txtA = new TextBox();
        txtB = new TextBox();
        txtUCLN = new TextBox();
        txtBCNN = new TextBox();

        btnTinh = new Button();
        btnXoa = new Button();
        btnThoat = new Button();

        errorProvider1 = new ErrorProvider(components);

        SuspendLayout();

        // lblA
        lblA.AutoSize = true;
        lblA.Location = new Point(70, 50);
        lblA.Name = "lblA";
        lblA.Size = new Size(25, 15);
        lblA.Text = "a =";

        // txtA
        txtA.Location = new Point(150, 45);
        txtA.Name = "txtA";
        txtA.Size = new Size(250, 23);
        txtA.TabIndex = 0;

        // lblB
        lblB.AutoSize = true;
        lblB.Location = new Point(70, 90);
        lblB.Name = "lblB";
        lblB.Size = new Size(25, 15);
        lblB.Text = "b =";

        // txtB
        txtB.Location = new Point(150, 85);
        txtB.Name = "txtB";
        txtB.Size = new Size(250, 23);
        txtB.TabIndex = 1;

        // lblUCLN
        lblUCLN.AutoSize = true;
        lblUCLN.Location = new Point(70, 130);
        lblUCLN.Name = "lblUCLN";
        lblUCLN.Size = new Size(50, 15);
        lblUCLN.Text = "UCLN =";

        // txtUCLN
        txtUCLN.Location = new Point(150, 125);
        txtUCLN.Name = "txtUCLN";
        txtUCLN.ReadOnly = true;
        txtUCLN.Size = new Size(250, 23);
        txtUCLN.TabIndex = 2;

        // lblBCNN
        lblBCNN.AutoSize = true;
        lblBCNN.Location = new Point(70, 170);
        lblBCNN.Name = "lblBCNN";
        lblBCNN.Size = new Size(55, 15);
        lblBCNN.Text = "BCNN =";

        // txtBCNN
        txtBCNN.Location = new Point(150, 165);
        txtBCNN.Name = "txtBCNN";
        txtBCNN.ReadOnly = true;
        txtBCNN.Size = new Size(250, 23);
        txtBCNN.TabIndex = 3;

        // btnTinh
        btnTinh.Location = new Point(100, 220);
        btnTinh.Name = "btnTinh";
        btnTinh.Size = new Size(90, 35);
        btnTinh.TabIndex = 4;
        btnTinh.Text = "Tính";
        btnTinh.UseVisualStyleBackColor = true;
        btnTinh.Click += btnTinh_Click;

        // btnXoa
        btnXoa.Location = new Point(210, 220);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(90, 35);
        btnXoa.TabIndex = 5;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;

        // btnThoat
        btnThoat.Location = new Point(320, 220);
        btnThoat.Name = "btnThoat";
        btnThoat.Size = new Size(90, 35);
        btnThoat.TabIndex = 6;
        btnThoat.Text = "Thoát";
        btnThoat.UseVisualStyleBackColor = true;
        btnThoat.Click += btnThoat_Click;

        // errorProvider1
        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

        // frmBai03
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(480, 300);
        Controls.Add(btnThoat);
        Controls.Add(btnXoa);
        Controls.Add(btnTinh);
        Controls.Add(txtBCNN);
        Controls.Add(lblBCNN);
        Controls.Add(txtUCLN);
        Controls.Add(lblUCLN);
        Controls.Add(txtB);
        Controls.Add(lblB);
        Controls.Add(txtA);
        Controls.Add(lblA);
        Name = "frmBai03";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Lab04 - Bài 3: UCLN và BCNN";
        FormClosing += frmBai03_FormClosing;

        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}