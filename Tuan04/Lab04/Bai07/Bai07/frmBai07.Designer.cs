#nullable enable

namespace Bai07;

partial class frmBai07
{
    private System.ComponentModel.IContainer? components = null;

    private Label lblNhap = null!;
    private Label lblMang = null!;
    private Label lblTim = null!;
    private Label lblViTri = null!;
    private Label lblGiaTriMoi = null!;
    private Label lblViTriThem = null!;
    private Label lblGiaTriThem = null!;
    private Label lblTong = null!;
    private Label lblTongChan = null!;
    private Label lblTongLe = null!;
    private Label lblMax = null!;
    private Label lblMin = null!;

    private TextBox txtNhap = null!;
    private TextBox txtMang = null!;
    private TextBox txtTim = null!;
    private TextBox txtViTri = null!;
    private TextBox txtGiaTriMoi = null!;
    private TextBox txtViTriThem = null!;
    private TextBox txtGiaTriThem = null!;
    private TextBox txtTong = null!;
    private TextBox txtTongChan = null!;
    private TextBox txtTongLe = null!;
    private TextBox txtMax = null!;
    private TextBox txtMin = null!;

    private Button btnThem = null!;
    private Button btnTim = null!;
    private Button btnThayThe = null!;
    private Button btnThemTaiViTri = null!;
    private Button btnSapTang = null!;
    private Button btnSapGiam = null!;
    private Button btnTong = null!;
    private Button btnTongChan = null!;
    private Button btnTongLe = null!;
    private Button btnMax = null!;
    private Button btnMin = null!;
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

        lblNhap = new Label();
        lblMang = new Label();
        lblTim = new Label();
        lblViTri = new Label();
        lblGiaTriMoi = new Label();
        lblViTriThem = new Label();
        lblGiaTriThem = new Label();
        lblTong = new Label();
        lblTongChan = new Label();
        lblTongLe = new Label();
        lblMax = new Label();
        lblMin = new Label();

        txtNhap = new TextBox();
        txtMang = new TextBox();
        txtTim = new TextBox();
        txtViTri = new TextBox();
        txtGiaTriMoi = new TextBox();
        txtViTriThem = new TextBox();
        txtGiaTriThem = new TextBox();
        txtTong = new TextBox();
        txtTongChan = new TextBox();
        txtTongLe = new TextBox();
        txtMax = new TextBox();
        txtMin = new TextBox();

        btnThem = new Button();
        btnTim = new Button();
        btnThayThe = new Button();
        btnThemTaiViTri = new Button();
        btnSapTang = new Button();
        btnSapGiam = new Button();
        btnTong = new Button();
        btnTongChan = new Button();
        btnTongLe = new Button();
        btnMax = new Button();
        btnMin = new Button();
        btnXoa = new Button();
        btnThoat = new Button();

        errorProvider1 = new ErrorProvider(components);

        SuspendLayout();

        // Form
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(720, 520);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Name = "frmBai07";
        Text = "Lab04 - Bài 7: Mảng một chiều";
        FormClosing += frmBai07_FormClosing;

        // Nhập số
        lblNhap.AutoSize = true;
        lblNhap.Location = new Point(30, 25);
        lblNhap.Text = "Nhập số:";

        txtNhap.Location = new Point(100, 20);
        txtNhap.Name = "txtNhap";
        txtNhap.Size = new Size(160, 23);
        txtNhap.TabIndex = 0;
        txtNhap.KeyPress += txtSo_KeyPress;

        btnThem.Location = new Point(275, 19);
        btnThem.Name = "btnThem";
        btnThem.Size = new Size(80, 27);
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;
        btnThem.Click += btnThem_Click;

        // Mảng
        lblMang.AutoSize = true;
        lblMang.Location = new Point(30, 60);
        lblMang.Text = "Mảng hiện tại:";

        txtMang.Location = new Point(30, 85);
        txtMang.Name = "txtMang";
        txtMang.Multiline = true;
        txtMang.ReadOnly = true;
        txtMang.ScrollBars = ScrollBars.Horizontal;
        txtMang.Size = new Size(650, 50);
        txtMang.TabIndex = 1;

        // Tìm kiếm
        lblTim.AutoSize = true;
        lblTim.Location = new Point(30, 160);
        lblTim.Text = "Giá trị tìm:";

        txtTim.Location = new Point(100, 155);
        txtTim.Name = "txtTim";
        txtTim.Size = new Size(100, 23);
        txtTim.TabIndex = 2;
        txtTim.KeyPress += txtSo_KeyPress;

        btnTim.Location = new Point(215, 154);
        btnTim.Name = "btnTim";
        btnTim.Size = new Size(90, 27);
        btnTim.Text = "Tìm kiếm";
        btnTim.UseVisualStyleBackColor = true;
        btnTim.Click += btnTim_Click;

        // Thay thế
        lblViTri.AutoSize = true;
        lblViTri.Location = new Point(330, 160);
        lblViTri.Text = "Vị trí:";

        txtViTri.Location = new Point(380, 155);
        txtViTri.Name = "txtViTri";
        txtViTri.Size = new Size(80, 23);
        txtViTri.TabIndex = 3;
        txtViTri.KeyPress += txtSo_KeyPress;

        lblGiaTriMoi.AutoSize = true;
        lblGiaTriMoi.Location = new Point(475, 160);
        lblGiaTriMoi.Text = "Giá trị mới:";

        txtGiaTriMoi.Location = new Point(550, 155);
        txtGiaTriMoi.Name = "txtGiaTriMoi";
        txtGiaTriMoi.Size = new Size(80, 23);
        txtGiaTriMoi.TabIndex = 4;
        txtGiaTriMoi.KeyPress += txtSo_KeyPress;

        btnThayThe.Location = new Point(640, 154);
        btnThayThe.Name = "btnThayThe";
        btnThayThe.Size = new Size(70, 27);
        btnThayThe.Text = "Thay thế";
        btnThayThe.UseVisualStyleBackColor = true;
        btnThayThe.Click += btnThayThe_Click;

        // Thêm tại vị trí
        lblViTriThem.AutoSize = true;
        lblViTriThem.Location = new Point(30, 200);
        lblViTriThem.Text = "Vị trí thêm:";

        txtViTriThem.Location = new Point(100, 195);
        txtViTriThem.Name = "txtViTriThem";
        txtViTriThem.Size = new Size(80, 23);
        txtViTriThem.TabIndex = 5;
        txtViTriThem.KeyPress += txtSo_KeyPress;

        lblGiaTriThem.AutoSize = true;
        lblGiaTriThem.Location = new Point(200, 200);
        lblGiaTriThem.Text = "Giá trị:";

        txtGiaTriThem.Location = new Point(250, 195);
        txtGiaTriThem.Name = "txtGiaTriThem";
        txtGiaTriThem.Size = new Size(100, 23);
        txtGiaTriThem.TabIndex = 6;
        txtGiaTriThem.KeyPress += txtSo_KeyPress;

        btnThemTaiViTri.Location = new Point(365, 194);
        btnThemTaiViTri.Name = "btnThemTaiViTri";
        btnThemTaiViTri.Size = new Size(100, 27);
        btnThemTaiViTri.Text = "Thêm vị trí";
        btnThemTaiViTri.UseVisualStyleBackColor = true;
        btnThemTaiViTri.Click += btnThemTaiViTri_Click;

        // Các chức năng
        btnSapTang.Location = new Point(30, 240);
        btnSapTang.Name = "btnSapTang";
        btnSapTang.Size = new Size(80, 30);
        btnSapTang.Text = "Tăng";
        btnSapTang.UseVisualStyleBackColor = true;
        btnSapTang.Click += btnSapTang_Click;

        btnSapGiam.Location = new Point(120, 240);
        btnSapGiam.Name = "btnSapGiam";
        btnSapGiam.Size = new Size(80, 30);
        btnSapGiam.Text = "Giảm";
        btnSapGiam.UseVisualStyleBackColor = true;
        btnSapGiam.Click += btnSapGiam_Click;

        btnTong.Location = new Point(210, 240);
        btnTong.Name = "btnTong";
        btnTong.Size = new Size(80, 30);
        btnTong.Text = "Tổng";
        btnTong.UseVisualStyleBackColor = true;
        btnTong.Click += btnTong_Click;

        btnTongChan.Location = new Point(300, 240);
        btnTongChan.Name = "btnTongChan";
        btnTongChan.Size = new Size(95, 30);
        btnTongChan.Text = "Tổng chẵn";
        btnTongChan.UseVisualStyleBackColor = true;
        btnTongChan.Click += btnTongChan_Click;

        btnTongLe.Location = new Point(405, 240);
        btnTongLe.Name = "btnTongLe";
        btnTongLe.Size = new Size(85, 30);
        btnTongLe.Text = "Tổng lẻ";
        btnTongLe.UseVisualStyleBackColor = true;
        btnTongLe.Click += btnTongLe_Click;

        btnMax.Location = new Point(500, 240);
        btnMax.Name = "btnMax";
        btnMax.Size = new Size(70, 30);
        btnMax.Text = "Max";
        btnMax.UseVisualStyleBackColor = true;
        btnMax.Click += btnMax_Click;

        btnMin.Location = new Point(580, 240);
        btnMin.Name = "btnMin";
        btnMin.Size = new Size(70, 30);
        btnMin.Text = "Min";
        btnMin.UseVisualStyleBackColor = true;
        btnMin.Click += btnMin_Click;

        // Kết quả
        lblTong.AutoSize = true;
        lblTong.Location = new Point(30, 295);
        lblTong.Text = "Tổng:";

        txtTong.Location = new Point(100, 290);
        txtTong.Name = "txtTong";
        txtTong.ReadOnly = true;
        txtTong.Size = new Size(100, 23);
        txtTong.TabIndex = 7;

        lblTongChan.AutoSize = true;
        lblTongChan.Location = new Point(220, 295);
        lblTongChan.Text = "Tổng chẵn:";

        txtTongChan.Location = new Point(290, 290);
        txtTongChan.Name = "txtTongChan";
        txtTongChan.ReadOnly = true;
        txtTongChan.Size = new Size(100, 23);
        txtTongChan.TabIndex = 8;

        lblTongLe.AutoSize = true;
        lblTongLe.Location = new Point(410, 295);
        lblTongLe.Text = "Tổng lẻ:";

        txtTongLe.Location = new Point(465, 290);
        txtTongLe.Name = "txtTongLe";
        txtTongLe.ReadOnly = true;
        txtTongLe.Size = new Size(100, 23);
        txtTongLe.TabIndex = 9;

        lblMax.AutoSize = true;
        lblMax.Location = new Point(30, 335);
        lblMax.Text = "Max:";

        txtMax.Location = new Point(100, 330);
        txtMax.Name = "txtMax";
        txtMax.ReadOnly = true;
        txtMax.Size = new Size(100, 23);
        txtMax.TabIndex = 10;

        lblMin.AutoSize = true;
        lblMin.Location = new Point(220, 335);
        lblMin.Text = "Min:";

        txtMin.Location = new Point(290, 330);
        txtMin.Name = "txtMin";
        txtMin.ReadOnly = true;
        txtMin.Size = new Size(100, 23);
        txtMin.TabIndex = 11;

        // Nút cuối
        btnXoa.Location = new Point(500, 380);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(80, 32);
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;

        btnThoat.Location = new Point(590, 380);
        btnThoat.Name = "btnThoat";
        btnThoat.Size = new Size(80, 32);
        btnThoat.Text = "Thoát";
        btnThoat.UseVisualStyleBackColor = true;
        btnThoat.Click += btnThoat_Click;

        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

        Controls.AddRange(new Control[]
        {
            lblNhap, txtNhap, btnThem,
            lblMang, txtMang,
            lblTim, txtTim, btnTim,
            lblViTri, txtViTri,
            lblGiaTriMoi, txtGiaTriMoi, btnThayThe,
            lblViTriThem, txtViTriThem,
            lblGiaTriThem, txtGiaTriThem, btnThemTaiViTri,
            btnSapTang, btnSapGiam, btnTong,
            btnTongChan, btnTongLe, btnMax, btnMin,
            lblTong, txtTong,
            lblTongChan, txtTongChan,
            lblTongLe, txtTongLe,
            lblMax, txtMax,
            lblMin, txtMin,
            btnXoa, btnThoat
        });

        ResumeLayout(false);
        PerformLayout();
    }
}
