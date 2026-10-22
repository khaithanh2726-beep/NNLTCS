using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bai01_BTNC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Khi Form1 nạp: Thêm danh sách mẫu ban đầu theo hình
        private void Form1_Load(object sender, EventArgs e)
        {
            lstLopA.Items.AddRange(new object[] { "Trần Hùng", "Nguyễn Hưng", "Lâm Tứ" });
            lstLopB.Items.AddRange(new object[] { "Tuấn Hưng", "Hồng Ngọc", "Anh Minh", "Bảo Lâm" });
        }

        // 2. Chức năng Kết thúc: Hỏi xác nhận Yes/No trước khi đóng ứng dụng
        private void mnuKetThuc_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có thực sự muốn kết thúc chương trình không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // 3. Chức năng Chuyển sang lớp B: Chuyển các mục đang chọn trong Lớp A sang Lớp B
        private void mnuChuyenSangLopB_Click(object sender, EventArgs e)
        {
            if (lstLopA.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên ở Lớp A cần chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy danh sách học viên đang chọn
            List<object> danhSachChuyen = new List<object>();
            foreach (var item in lstLopA.SelectedItems)
            {
                danhSachChuyen.Add(item);
            }

            // Thêm sang Lớp B và xóa khỏi Lớp A
            foreach (var item in danhSachChuyen)
            {
                lstLopB.Items.Add(item);
                lstLopA.Items.Remove(item);
            }
        }

        // 4. Chức năng Chuyển sang lớp A: Chuyển các mục đang chọn trong Lớp B sang Lớp A
        private void mnuChuyenSangLopA_Click(object sender, EventArgs e)
        {
            if (lstLopB.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên ở Lớp B cần chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<object> danhSachChuyen = new List<object>();
            foreach (var item in lstLopB.SelectedItems)
            {
                danhSachChuyen.Add(item);
            }

            foreach (var item in danhSachChuyen)
            {
                lstLopA.Items.Add(item);
                lstLopB.Items.Remove(item);
            }
        }

        // 5. Chức năng Xóa học viên: Xóa tất cả các mục đang chọn ở cả Lớp A và Lớp B
        private void mnuXoaHocVien_Click(object sender, EventArgs e)
        {
            if (lstLopA.SelectedIndices.Count == 0 && lstLopB.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một học viên cần xóa ở Lớp A hoặc Lớp B!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xóa các mục chọn ở Lớp A (lùi từ cuối về đầu để tránh lệch index)
            for (int i = lstLopA.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstLopA.Items.RemoveAt(lstLopA.SelectedIndices[i]);
            }

            // Xóa các mục chọn ở Lớp B
            for (int i = lstLopB.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstLopB.Items.RemoveAt(lstLopB.SelectedIndices[i]);
            }

            MessageBox.Show("Đã xóa học viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 6. Chức năng Nhập học viên mới: Mở Form con nhập liệu
        private void mnuNhapHocVienMoi_Click(object sender, EventArgs e)
        {
            frmNhapHocVien fNhap = new frmNhapHocVien();

            // Đăng ký sự kiện nhận dữ liệu từ form con trả về form chính
            fNhap.OnThemHocVien += (hoTen, tenLop) =>
            {
                if (tenLop == "Lớp A")
                {
                    lstLopA.Items.Add(hoTen);
                }
                else
                {
                    lstLopB.Items.Add(hoTen);
                }
            };

            fNhap.ShowDialog(this);
        }
    }

    // ==========================================
    // FORM CON: "Nhập học viên mới"
    // ==========================================
    public class frmNhapHocVien : Form
    {
        private Label lblHoTen;
        private Label lblLop;
        private TextBox txtHoTen;
        private ComboBox cboLop;
        private Button btnCapNhat;
        private Button btnTroVe;

        // Delegate truyền dữ liệu về Form chính
        public event Action<string, string> OnThemHocVien;

        public frmNhapHocVien()
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.lblHoTen = new Label() { Text = "Họ và Tên", Location = new System.Drawing.Point(30, 30), AutoSize = true };
            this.txtHoTen = new TextBox() { Location = new System.Drawing.Point(120, 27), Width = 220 };

            this.lblLop = new Label() { Text = "Lớp", Location = new System.Drawing.Point(30, 75), AutoSize = true };
            this.cboLop = new ComboBox() { Location = new System.Drawing.Point(120, 72), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
            this.cboLop.Items.AddRange(new object[] { "Lớp A", "Lớp B" });
            this.cboLop.SelectedIndex = 0; // Mặc định chọn Lớp A

            this.btnCapNhat = new Button() { Text = "Cập nhật", Location = new System.Drawing.Point(120, 125), Width = 95, Height = 32 };
            this.btnTroVe = new Button() { Text = "Trở về", Location = new System.Drawing.Point(245, 125), Width = 95, Height = 32 };

            this.btnCapNhat.Click += BtnCapNhat_Click;
            this.btnTroVe.Click += (s, e) => { this.Close(); };

            this.ClientSize = new System.Drawing.Size(380, 180);
            this.Controls.AddRange(new Control[] { lblHoTen, txtHoTen, lblLop, cboLop, btnCapNhat, btnTroVe });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Nhập học viên mới";
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();

            // Nếu Họ và Tên rỗng
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ và Tên học viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            // Nếu khác rỗng: Thêm vào lớp tương ứng trên form chính
            string lopDaChon = cboLop.SelectedItem.ToString();
            OnThemHocVien?.Invoke(hoTen, lopDaChon);

            MessageBox.Show("Thêm học viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Dọn ô nhập để tiếp tục nhập học viên khác
            txtHoTen.Clear();
            txtHoTen.Focus();
        }
    }
}