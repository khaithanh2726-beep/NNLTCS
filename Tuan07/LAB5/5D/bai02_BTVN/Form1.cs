using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace bai02_BTVN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Hàm hỗ trợ mở Form con và ẩn tất cả các Form con khác
        private void MoFormCon<T>() where T : Form, new()
        {
            T formTarget = null;

            foreach (Form child in this.MdiChildren)
            {
                if (child is T)
                {
                    formTarget = (T)child;
                }
                else
                {
                    child.Hide();
                }
            }

            if (formTarget == null)
            {
                formTarget = new T();
                formTarget.MdiParent = this;
                formTarget.Show();
            }
            else
            {
                formTarget.Show();
                formTarget.Activate();
            }
        }

        private void mnuBai01_BTTL_Click(object sender, EventArgs e)
        {
            MoFormCon<frmBaitap1>();
        }

        private void mnuBai02_BTTL_Click(object sender, EventArgs e)
        {
            MoFormCon<frmBai02_BTTL>();
        }

        private void mnuBai01_BTNC_Click(object sender, EventArgs e)
        {
            MoFormCon<frmBai01_BTNC>();
        }

        private void mnuBai01_BTVN_Click(object sender, EventArgs e)
        {
            MoFormCon<frmBaitap2>();
        }

        private void mnuBai02_BTVN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đây là Form chính MDI Container quản lý tất cả các bài tập trong tuần!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // ==========================================================
    // BÀI 1: bai01_BTTL - Quản lý thông tin sinh viên (Đã thêm Thêm, Sửa, Xóa, Thoát)
    // ==========================================================
    public class frmBaitap1 : Form
    {
        private Label lblHoTen, lblMaSV, lblGioiTinh, lblNgoaiNgu, lblDanToc;
        private TextBox txtHoTen, txtMaSV;
        private RadioButton rdoNam, rdoNu;
        private CheckBox chkAnh, chkPhap, chkHoa;
        private ComboBox cboDanToc;
        private ListView lvSinhVien;
        private Button btnThem, btnSua, btnXoa, btnThoat;

        public frmBaitap1()
        {
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "frmBaitap1 (bai01_BTTL)";
            this.Size = new Size(520, 520);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblHoTen = new Label() { Text = "Họ và Tên", Location = new Point(30, 20), AutoSize = true };
            txtHoTen = new TextBox() { Location = new Point(150, 17), Width = 260 };

            lblMaSV = new Label() { Text = "Mã sinh viên", Location = new Point(30, 60), AutoSize = true };
            txtMaSV = new TextBox() { Location = new Point(150, 57), Width = 260 };

            lblGioiTinh = new Label() { Text = "Giới tính", Location = new Point(30, 100), AutoSize = true };
            rdoNam = new RadioButton() { Text = "Nam", Location = new Point(150, 98), Checked = true, AutoSize = true };
            rdoNu = new RadioButton() { Text = "Nữ", Location = new Point(230, 98), AutoSize = true };

            lblNgoaiNgu = new Label() { Text = "Ngoại ngữ", Location = new Point(30, 140), AutoSize = true };
            chkAnh = new CheckBox() { Text = "Anh", Location = new Point(150, 138), Checked = true, AutoSize = true };
            chkPhap = new CheckBox() { Text = "Pháp", Location = new Point(230, 138), AutoSize = true };
            chkHoa = new CheckBox() { Text = "Hoa", Location = new Point(310, 138), AutoSize = true };

            lblDanToc = new Label() { Text = "Dân tộc", Location = new Point(30, 180), AutoSize = true };
            cboDanToc = new ComboBox() { Location = new Point(150, 177), Width = 260, DropDownStyle = ComboBoxStyle.DropDownList };
            cboDanToc.Items.AddRange(new object[] { "Kinh", "Tày", "Nùng", "Mường", "Khơ-me", "H'Mông" });
            cboDanToc.SelectedIndex = 0;

            // Thêm các Nút bấm Thêm, Sửa, Xóa, Thoát
            btnThem = new Button() { Text = "Thêm", Location = new Point(30, 215), Size = new Size(80, 30) };
            btnSua = new Button() { Text = "Sửa", Location = new Point(125, 215), Size = new Size(80, 30) };
            btnXoa = new Button() { Text = "Xóa", Location = new Point(220, 215), Size = new Size(80, 30) };
            btnThoat = new Button() { Text = "Thoát", Location = new Point(315, 215), Size = new Size(80, 30) };

            lvSinhVien = new ListView() { Location = new Point(20, 260), Size = new Size(465, 190), View = View.Details, FullRowSelect = true, GridLines = true, MultiSelect = false };
            lvSinhVien.Columns.Add("Họ tên", 110);
            lvSinhVien.Columns.Add("Mã sinh viên", 90);
            lvSinhVien.Columns.Add("Giới tính", 70);
            lvSinhVien.Columns.Add("Ngoại ngữ", 100);
            lvSinhVien.Columns.Add("Dân tộc", 80);

            // Đăng ký sự kiện cho nút và ListView
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnThoat.Click += (s, e) => this.Close();
            lvSinhVien.SelectedIndexChanged += LvSinhVien_SelectedIndexChanged;

            this.Controls.AddRange(new Control[] {
                lblHoTen, txtHoTen, lblMaSV, txtMaSV, lblGioiTinh, rdoNam, rdoNu,
                lblNgoaiNgu, chkAnh, chkPhap, chkHoa, lblDanToc, cboDanToc,
                btnThem, btnSua, btnXoa, btnThoat, lvSinhVien
            });
        }

        private string GetNgoaiNgu()
        {
            List<string> list = new List<string>();
            if (chkAnh.Checked) list.Add("Anh");
            if (chkPhap.Checked) list.Add("Pháp");
            if (chkHoa.Checked) list.Add("Hoa");
            return string.Join(", ", list);
        }

        private void ClearInputs()
        {
            txtHoTen.Clear();
            txtMaSV.Clear();
            rdoNam.Checked = true;
            chkAnh.Checked = true;
            chkPhap.Checked = false;
            chkHoa.Checked = false;
            cboDanToc.SelectedIndex = 0;
            txtHoTen.Focus();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = new ListViewItem(txtHoTen.Text.Trim());
            item.SubItems.Add(txtMaSV.Text.Trim());
            item.SubItems.Add(rdoNam.Checked ? "Nam" : "Nữ");
            item.SubItems.Add(GetNgoaiNgu());
            item.SubItems.Add(cboDanToc.SelectedItem.ToString());

            lvSinhVien.Items.Add(item);
            ClearInputs();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtMaSV.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ListViewItem item = lvSinhVien.SelectedItems[0];
                item.SubItems[0].Text = txtHoTen.Text.Trim();
                item.SubItems[1].Text = txtMaSV.Text.Trim();
                item.SubItems[2].Text = rdoNam.Checked ? "Nam" : "Nữ";
                item.SubItems[3].Text = GetNgoaiNgu();
                item.SubItems[4].Text = cboDanToc.SelectedItem.ToString();

                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lvSinhVien.Items.Remove(lvSinhVien.SelectedItems[0]);
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lvSinhVien.SelectedItems[0];
                txtHoTen.Text = item.SubItems[0].Text;
                txtMaSV.Text = item.SubItems[1].Text;

                if (item.SubItems[2].Text == "Nam") rdoNam.Checked = true;
                else rdoNu.Checked = true;

                string nn = item.SubItems[3].Text;
                chkAnh.Checked = nn.Contains("Anh");
                chkPhap.Checked = nn.Contains("Pháp");
                chkHoa.Checked = nn.Contains("Hoa");

                cboDanToc.SelectedItem = item.SubItems[4].Text;
            }
        }
    }

    // ==========================================================
    // BÀI 2: bai02_BTTL - Quản lý thông tin tài khoản ngân hàng
    // ==========================================================
    public class frmBai02_BTTL : Form
    {
        private Label lblTitle, lblSoTK, lblTenKH, lblDiaChi, lblSoTien, lblTongTien;
        private TextBox txtSoTK, txtTenKH, txtDiaChi, txtSoTien, txtTongTien;
        private Button btnThem, btnLuu, btnXoa, btnThoat;
        private ListView lvTaiKhoan;

        public frmBai02_BTTL()
        {
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "frmBaiTap2 (bai02_BTTL)";
            this.Size = new Size(745, 520);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblTitle = new Label() { Text = "QUẢN LÝ THÔNG TIN TÀI KHOẢN", Font = new Font("Arial", 16, FontStyle.Bold), ForeColor = Color.Blue, Location = new Point(145, 18), AutoSize = true };

            lblSoTK = new Label() { Text = "Số tài khoản", Location = new Point(230, 72), AutoSize = true };
            txtSoTK = new TextBox() { Location = new Point(325, 69), Width = 330, ReadOnly = true };

            lblTenKH = new Label() { Text = "Tên khách hàng", Location = new Point(208, 108), AutoSize = true };
            txtTenKH = new TextBox() { Location = new Point(325, 105), Width = 330, ReadOnly = true };

            lblDiaChi = new Label() { Text = "Địa chỉ khách hàng", Location = new Point(196, 144), AutoSize = true };
            txtDiaChi = new TextBox() { Location = new Point(325, 141), Width = 330, ReadOnly = true };

            lblSoTien = new Label() { Text = "Số tiền trong tài khoản", Location = new Point(177, 180), AutoSize = true };
            txtSoTien = new TextBox() { Location = new Point(325, 177), Width = 330, TextAlign = HorizontalAlignment.Right, ReadOnly = true };

            btnThem = new Button() { Text = "Thêm", Location = new Point(325, 215), Size = new Size(75, 30) };
            btnLuu = new Button() { Text = "Lưu", Location = new Point(410, 215), Size = new Size(75, 30), Enabled = false };
            btnXoa = new Button() { Text = "Xóa", Location = new Point(495, 215), Size = new Size(75, 30), Enabled = false };
            btnThoat = new Button() { Text = "Thoát", Location = new Point(580, 215), Size = new Size(75, 30) };

            lvTaiKhoan = new ListView() { Location = new Point(25, 260), Size = new Size(695, 175), View = View.Details, FullRowSelect = true, GridLines = true, MultiSelect = false };
            lvTaiKhoan.Columns.Add("STT", 50);
            lvTaiKhoan.Columns.Add("Số tài khoản", 130);
            lvTaiKhoan.Columns.Add("Tên khách hàng", 180);
            lvTaiKhoan.Columns.Add("Địa chỉ", 170);
            lvTaiKhoan.Columns.Add("Số tiền", 140, HorizontalAlignment.Right);

            lblTongTien = new Label() { Text = "Tổng tiền", Location = new Point(435, 452), AutoSize = true };
            txtTongTien = new TextBox() { Location = new Point(510, 450), Width = 210, ReadOnly = true, TextAlign = HorizontalAlignment.Right, Text = "0" };

            btnThem.Click += BtnThem_Click;
            btnLuu.Click += BtnLuu_Click;
            btnXoa.Click += BtnXoa_Click;
            btnThoat.Click += (s, e) => this.Close();
            lvTaiKhoan.SelectedIndexChanged += LvTaiKhoan_SelectedIndexChanged;

            this.Controls.AddRange(new Control[] {
                lblTitle, lblSoTK, txtSoTK, lblTenKH, txtTenKH, lblDiaChi, txtDiaChi,
                lblSoTien, txtSoTien, btnThem, btnLuu, btnXoa, btnThoat, lvTaiKhoan, lblTongTien, txtTongTien
            });
        }

        private void KhoaControls(bool khoa)
        {
            txtSoTK.ReadOnly = khoa;
            txtTenKH.ReadOnly = khoa;
            txtDiaChi.ReadOnly = khoa;
            txtSoTien.ReadOnly = khoa;
        }

        private void XoaTrang()
        {
            txtSoTK.Clear(); txtTenKH.Clear(); txtDiaChi.Clear(); txtSoTien.Clear();
        }

        private void CapNhatSTTVaTongTien()
        {
            long tong = 0;
            for (int i = 0; i < lvTaiKhoan.Items.Count; i++)
            {
                lvTaiKhoan.Items[i].SubItems[0].Text = (i + 1).ToString();
                string s = lvTaiKhoan.Items[i].SubItems[4].Text.Replace(",", "").Replace(".", "").Trim();
                if (long.TryParse(s, out long t)) tong += t;
            }
            txtTongTien.Text = string.Format(CultureInfo.InvariantCulture, "{0:N0}", tong);
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Hủy"; btnLuu.Enabled = true; btnXoa.Enabled = false;
                KhoaControls(false); XoaTrang(); txtSoTK.Focus();
            }
            else
            {
                btnThem.Text = "Thêm"; btnLuu.Enabled = false;
                btnXoa.Enabled = (lvTaiKhoan.SelectedItems.Count > 0);
                XoaTrang(); KhoaControls(true);
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoTK.Text) || string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) || string.IsNullOrWhiteSpace(txtSoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(txtSoTien.Text.Trim(), out long st) || st < 0)
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListViewItem item = new ListViewItem("");
            item.SubItems.Add(txtSoTK.Text.Trim());
            item.SubItems.Add(txtTenKH.Text.Trim());
            item.SubItems.Add(txtDiaChi.Text.Trim());
            item.SubItems.Add(string.Format(CultureInfo.InvariantCulture, "{0:N0}", st));

            lvTaiKhoan.Items.Add(item);
            CapNhatSTTVaTongTien();

            btnThem.Text = "Thêm"; btnLuu.Enabled = false; KhoaControls(true); XoaTrang();
        }

        private void LvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count > 0)
            {
                ListViewItem item = lvTaiKhoan.SelectedItems[0];
                txtSoTK.Text = item.SubItems[1].Text;
                txtTenKH.Text = item.SubItems[2].Text;
                txtDiaChi.Text = item.SubItems[3].Text;
                txtSoTien.Text = item.SubItems[4].Text.Replace(",", "").Replace(".", "").Trim();
                btnXoa.Enabled = true; KhoaControls(true);
            }
            else btnXoa.Enabled = false;
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count > 0)
            {
                lvTaiKhoan.Items.Remove(lvTaiKhoan.SelectedItems[0]);
                CapNhatSTTVaTongTien(); XoaTrang(); btnXoa.Enabled = false;
            }
        }
    }

    // ==========================================================
    // BÀI 3: bai01_BTNC - Quản lý học viên & chuyển lớp
    // ==========================================================
    public class frmBai01_BTNC : Form
    {
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuCapNhat, mnuNhapMoi, mnuChuyenB, mnuChuyenA, mnuXoa, mnuKetThuc;
        private GroupBox grpLopA, grpLopB;
        private ListBox lstLopA, lstLopB;

        public frmBai01_BTNC()
        {
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Quản lý học viên (bai01_BTNC)";
            this.Size = new Size(564, 340);
            this.StartPosition = FormStartPosition.CenterScreen;

            menuStrip1 = new MenuStrip() { Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            mnuCapNhat = new ToolStripMenuItem("Cập nhật");
            mnuKetThuc = new ToolStripMenuItem("Kết thúc");

            mnuNhapMoi = new ToolStripMenuItem("Nhập học viên mới");
            mnuChuyenB = new ToolStripMenuItem("Chuyển sang lớp B");
            mnuChuyenA = new ToolStripMenuItem("Chuyển sang lớp A");
            mnuXoa = new ToolStripMenuItem("Xóa học viên");

            mnuCapNhat.DropDownItems.AddRange(new ToolStripItem[] { mnuNhapMoi, mnuChuyenB, mnuChuyenA, mnuXoa });
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuCapNhat, mnuKetThuc });

            grpLopA = new GroupBox() { Text = "Lớp A", Location = new Point(30, 40), Size = new Size(235, 240) };
            lstLopA = new ListBox() { Dock = DockStyle.Fill, SelectionMode = SelectionMode.MultiExtended };
            lstLopA.Items.AddRange(new object[] { "Trần Hùng", "Nguyễn Hưng", "Lâm Tứ" });
            grpLopA.Controls.Add(lstLopA);

            grpLopB = new GroupBox() { Text = "Lớp B", Location = new Point(295, 40), Size = new Size(235, 240) };
            lstLopB = new ListBox() { Dock = DockStyle.Fill, SelectionMode = SelectionMode.MultiExtended };
            lstLopB.Items.AddRange(new object[] { "Tuấn Hưng", "Hồng Ngọc", "Anh Minh", "Bảo Lâm" });
            grpLopB.Controls.Add(lstLopB);

            mnuChuyenB.Click += (s, e) => ChuyenLop(lstLopA, lstLopB, "Lớp A");
            mnuChuyenA.Click += (s, e) => ChuyenLop(lstLopB, lstLopA, "Lớp B");
            mnuXoa.Click += MnuXoa_Click;
            mnuKetThuc.Click += (s, e) => this.Close();
            mnuNhapMoi.Click += MnuNhapMoi_Click;

            this.MainMenuStrip = menuStrip1;
            this.Controls.AddRange(new Control[] { menuStrip1, grpLopA, grpLopB });
        }

        private void ChuyenLop(ListBox nguon, ListBox dich, string tenLop)
        {
            if (nguon.SelectedItems.Count == 0)
            {
                MessageBox.Show($"Vui lòng chọn học viên ở {tenLop}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<object> ds = new List<object>();
            foreach (var item in nguon.SelectedItems) ds.Add(item);
            foreach (var item in ds) { dich.Items.Add(item); nguon.Items.Remove(item); }
        }

        private void MnuXoa_Click(object sender, EventArgs e)
        {
            if (lstLopA.SelectedIndices.Count == 0 && lstLopB.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = lstLopA.SelectedIndices.Count - 1; i >= 0; i--) lstLopA.Items.RemoveAt(lstLopA.SelectedIndices[i]);
            for (int i = lstLopB.SelectedIndices.Count - 1; i >= 0; i--) lstLopB.Items.RemoveAt(lstLopB.SelectedIndices[i]);
        }

        private void MnuNhapMoi_Click(object sender, EventArgs e)
        {
            Form f = new Form() { Text = "Nhập học viên mới", Size = new Size(360, 180), StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog };
            Label l1 = new Label() { Text = "Họ và Tên", Location = new Point(20, 20), AutoSize = true };
            TextBox t1 = new TextBox() { Location = new Point(100, 17), Width = 220 };
            Label l2 = new Label() { Text = "Lớp", Location = new Point(20, 60), AutoSize = true };
            ComboBox c1 = new ComboBox() { Location = new Point(100, 57), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
            c1.Items.AddRange(new object[] { "Lớp A", "Lớp B" }); c1.SelectedIndex = 0;
            Button b1 = new Button() { Text = "Cập nhật", Location = new Point(100, 100), Size = new Size(90, 30) };

            b1.Click += (sb, eb) => {
                if (string.IsNullOrWhiteSpace(t1.Text)) return;
                if (c1.SelectedItem.ToString() == "Lớp A") lstLopA.Items.Add(t1.Text.Trim());
                else lstLopB.Items.Add(t1.Text.Trim());
                t1.Clear(); t1.Focus();
            };

            f.Controls.AddRange(new Control[] { l1, t1, l2, c1, b1 });
            f.ShowDialog(this);
        }
    }

    // ==========================================================
    // BÀI 4: bai01_BTVN - Đồng hồ đếm ngược
    // ==========================================================
    public class frmBaitap2 : Form
    {
        private Label lblDongHo;
        private Button btnBatDau;
        private Timer timer;
        private int tongSoGiay = 30 * 60;

        public frmBaitap2()
        {
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Đồng hồ (bai01_BTVN)";
            this.Size = new Size(300, 180);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblDongHo = new Label()
            {
                Text = "30:00",
                Font = new Font("Consolas", 20, FontStyle.Bold),
                Location = new Point(50, 20),
                Size = new Size(180, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            btnBatDau = new Button() { Text = "Bắt đầu", Location = new Point(90, 75), Size = new Size(100, 35) };
            btnBatDau.Click += BtnBatDau_Click;

            timer = new Timer() { Interval = 1000 };
            timer.Tick += Timer_Tick;

            this.Controls.AddRange(new Control[] { lblDongHo, btnBatDau });
        }

        private void BtnBatDau_Click(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                if (tongSoGiay <= 0) tongSoGiay = 30 * 60;
                timer.Start();
                btnBatDau.Text = "Tạm dừng";
            }
            else
            {
                timer.Stop();
                btnBatDau.Text = "Tiếp tục";
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (tongSoGiay > 0)
            {
                tongSoGiay--;
                int phut = tongSoGiay / 60;
                int giay = tongSoGiay % 60;
                lblDongHo.Text = $"{phut:D2}:{giay:D2}";
            }
            else
            {
                timer.Stop();
                btnBatDau.Text = "Bắt đầu";
                MessageBox.Show("Hết giờ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}