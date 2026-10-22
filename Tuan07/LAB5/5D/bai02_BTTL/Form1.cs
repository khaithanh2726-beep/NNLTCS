using System;
using System.Globalization;
using System.Windows.Forms;

namespace bai02_BTTL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Khi Form load lên: Trạng thái ban đầu đúng như đề bài
        private void Form1_Load(object sender, EventArgs e)
        {
            btnThem.Text = "Thêm";
            btnLuu.Enabled = false; // Nút Lưu bị mờ ban đầu
            btnXoa.Enabled = false; // Nút Xóa bị mờ cho đến khi chọn dòng
            txtTongTien.Text = "0";

            KhoaControls(true); // Khóa các TextBox khi chưa bấm Thêm
        }

        // Hàm hỗ trợ khóa/mở các ô nhập
        private void KhoaControls(bool khoa)
        {
            txtSoTK.ReadOnly = khoa;
            txtTenKH.ReadOnly = khoa;
            txtDiaChi.ReadOnly = khoa;
            txtSoTien.ReadOnly = khoa;
        }

        // Hàm xóa trắng các ô nhập
        private void XoaTrangTextBox()
        {
            txtSoTK.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSoTien.Clear();
        }

        // Hàm đánh lại số thứ tự (STT) tự động từ 1 đến N và tính Tổng tiền
        private void CapNhatSTTVaTongTien()
        {
            long tongTien = 0;

            for (int i = 0; i < lvTaiKhoan.Items.Count; i++)
            {
                // Cột 0: STT
                lvTaiKhoan.Items[i].SubItems[0].Text = (i + 1).ToString();

                // Cột 4: Số tiền (loại bỏ dấu phân cách hàng nghìn để cộng tổng)
                string strSoTien = lvTaiKhoan.Items[i].SubItems[4].Text.Replace(",", "").Replace(".", "").Trim();
                if (long.TryParse(strSoTien, out long tien))
                {
                    tongTien += tien;
                }
            }

            // Hiển thị định dạng tiền tệ có dấu phẩy (VD: 6,400,000)
            txtTongTien.Text = string.Format(CultureInfo.InvariantCulture, "{0:N0}", tongTien);
        }

        // Kiểm tra xem số tài khoản đã có trên ListView chưa
        private bool KiemTraTrungSoTK(string soTK)
        {
            foreach (ListViewItem item in lvTaiKhoan.Items)
            {
                if (item.SubItems[1].Text.Trim().Equals(soTK, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        // 2. Nút "Thêm" / "Hủy"
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                // Chuyển text sang "Hủy", kích hoạt nút "Lưu"
                btnThem.Text = "Hủy";
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;

                KhoaControls(false); // Mở khóa các TextBox để nhập
                XoaTrangTextBox();
                txtSoTK.Focus();      // Đặt con trỏ vào TextBox Số tài khoản
            }
            else // Khi người dùng bấm "Hủy"
            {
                btnThem.Text = "Thêm";
                btnLuu.Enabled = false;
                btnXoa.Enabled = (lvTaiKhoan.SelectedItems.Count > 0);

                XoaTrangTextBox();
                KhoaControls(true);
            }
        }

        // 3. Nút "Lưu": Lưu dữ liệu từ các TextBox vào ListView
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string soTK = txtSoTK.Text.Trim();
            string tenKH = txtTenKH.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string soTienStr = txtSoTien.Text.Trim();

            // Kiểm tra các trường không để trống
            if (string.IsNullOrWhiteSpace(soTK) || string.IsNullOrWhiteSpace(tenKH) ||
                string.IsNullOrWhiteSpace(diaChi) || string.IsNullOrWhiteSpace(soTienStr))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra tính hợp lệ của số tiền
            if (!long.TryParse(soTienStr, out long soTien) || soTien < 0)
            {
                MessageBox.Show("Số tiền phải là số tự nhiên hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoTien.SelectAll();
                txtSoTien.Focus();
                return;
            }

            // Kiểm tra trùng Số tài khoản
            if (KiemTraTrungSoTK(soTK))
            {
                MessageBox.Show("Số tài khoản này đã tồn tại trong hệ thống!", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTK.SelectAll();
                txtSoTK.Focus();
                return;
            }

            // Tạo dòng ListViewItem mới
            ListViewItem item = new ListViewItem(""); // STT tạm để rỗng, sẽ cập nhật qua hàm
            item.SubItems.Add(soTK);
            item.SubItems.Add(tenKH);
            item.SubItems.Add(diaChi);
            item.SubItems.Add(string.Format(CultureInfo.InvariantCulture, "{0:N0}", soTien));

            lvTaiKhoan.Items.Add(item);

            // Cập nhật lại STT tự động và Tổng tiền
            CapNhatSTTVaTongTien();

            // Reset trạng thái sau khi lưu thành công
            btnThem.Text = "Thêm";
            btnLuu.Enabled = false;
            KhoaControls(true);
            XoaTrangTextBox();

            MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 4. Khi click vào một khách hàng trên ListView: Hiển thị thông tin lên TextBox & Enabled nút Xóa
        private void lvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count > 0)
            {
                ListViewItem item = lvTaiKhoan.SelectedItems[0];
                txtSoTK.Text = item.SubItems[1].Text;
                txtTenKH.Text = item.SubItems[2].Text;
                txtDiaChi.Text = item.SubItems[3].Text;
                // Bỏ dấu phẩy khi hiển thị lại ô nhập tiền
                txtSoTien.Text = item.SubItems[4].Text.Replace(",", "").Replace(".", "").Trim();

                btnXoa.Enabled = true; // Bật nút Xóa khi có bản ghi được chọn
                KhoaControls(true);    // Khóa các ô ở chế độ xem

                // Nếu đang ở trạng thái chuẩn bị thêm mà click chọn dòng thì hủy trạng thái thêm
                if (btnThem.Text == "Hủy")
                {
                    btnThem.Text = "Thêm";
                    btnLuu.Enabled = false;
                }
            }
            else
            {
                btnXoa.Enabled = false;
            }
        }

        // 5. Nút "Xóa": Xóa mẫu tin hiện hành trong ListView
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = lvTaiKhoan.SelectedItems[0];
            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa tài khoản [{item.SubItems[1].Text} - {item.SubItems[2].Text}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                lvTaiKhoan.Items.Remove(item);

                // Cập nhật lại STT và Tổng tiền sau khi xóa
                CapNhatSTTVaTongTien();
                XoaTrangTextBox();
                btnXoa.Enabled = false;

                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 6. Nút "Thoát"
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi chương trình?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}