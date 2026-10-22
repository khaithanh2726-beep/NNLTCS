using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bai01_BTTL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Khi Load form: Thêm dữ liệu vào ComboBox Dân tộc
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] dsDanToc = { "Kinh", "Tày", "Thái", "Mường", "H'Mông", "Khmer", "Nùng", "Hoa", "Dao", "Gia Rai", "Ê Đê", "Ba Na" };
            cboDanToc.Items.AddRange(dsDanToc);
            cboDanToc.SelectedIndex = 0; // Mặc định chọn "Kinh"
        }

        // Hàm phụ lấy chuỗi Ngoại ngữ từ các CheckBox
        private string LayChuoiNgoaiNgu()
        {
            List<string> nn = new List<string>();
            if (chkAnh.Checked) nn.Add("Anh");
            if (chkPhap.Checked) nn.Add("Pháp");
            if (chkHoa.Checked) nn.Add("Hoa");

            return nn.Count > 0 ? string.Join(", ", nn) : "Không";
        }

        // Hàm kiểm tra trùng Mã sinh viên trên ListView
        private bool KiemTraTrungMaSV(string maSV)
        {
            foreach (ListViewItem item in lvSinhVien.Items)
            {
                // SubItems[1] lưu Mã SV
                if (item.SubItems[1].Text.Trim().Equals(maSV, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        // Hàm xóa trắng ô nhập liệu sau khi thao tác
        private void XoaTrangForm()
        {
            txtHoTen.Clear();
            txtMaSV.Clear();
            txtMaSV.ReadOnly = false; // Mở lại ô Mã SV
            radNam.Checked = true;
            chkAnh.Checked = true;
            chkPhap.Checked = false;
            chkHoa.Checked = false;
            cboDanToc.SelectedIndex = 0;
            txtHoTen.Focus();
        }

        // 2. Nút "Thêm": Thêm sinh viên vào ListView (không cho trùng Mã SV)
        private void btnThem_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string maSV = txtMaSV.Text.Trim();

            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (string.IsNullOrWhiteSpace(hoTen)) txtHoTen.Focus();
                else txtMaSV.Focus();
                return;
            }

            // Kiểm tra trùng mã sinh viên
            if (KiemTraTrungMaSV(maSV))
            {
                MessageBox.Show("Mã sinh viên này đã tồn tại! Vui lòng nhập mã khác.", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSV.SelectAll();
                txtMaSV.Focus();
                return;
            }

            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            string ngoaiNgu = LayChuoiNgoaiNgu();
            string danToc = cboDanToc.SelectedItem?.ToString() ?? "Kinh";

            // Tạo dòng ListViewItem mới
            ListViewItem item = new ListViewItem(hoTen);
            item.SubItems.Add(maSV);
            item.SubItems.Add(gioiTinh);
            item.SubItems.Add(ngoaiNgu);
            item.SubItems.Add(danToc);

            lvSinhVien.Items.Add(item);
            XoaTrangForm();
            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 3. Khi click chọn dòng trên ListView: Đổ dữ liệu lên control và khóa ô Mã SV (không cho sửa)
        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lvSinhVien.SelectedItems[0];
                txtHoTen.Text = item.SubItems[0].Text;
                txtMaSV.Text = item.SubItems[1].Text;
                txtMaSV.ReadOnly = true; // Khóa Mã sinh viên theo yêu cầu đề bài

                // Giới tính
                string gioiTinh = item.SubItems[2].Text;
                if (gioiTinh == "Nam") radNam.Checked = true;
                else radNu.Checked = true;

                // Ngoại ngữ
                string ngoaiNgu = item.SubItems[3].Text;
                chkAnh.Checked = ngoaiNgu.Contains("Anh");
                chkPhap.Checked = ngoaiNgu.Contains("Pháp");
                chkHoa.Checked = ngoaiNgu.Contains("Hoa");

                // Dân tộc
                cboDanToc.SelectedItem = item.SubItems[4].Text;
            }
            else
            {
                txtMaSV.ReadOnly = false;
            }
        }

        // 4. Nút "Sửa": Cập nhật thông tin sinh viên đang chọn (không cho sửa Mã SV)
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên trong danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Họ và Tên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            ListViewItem item = lvSinhVien.SelectedItems[0];
            item.SubItems[0].Text = hoTen;
            // Mã SV item.SubItems[1] được giữ nguyên hoàn toàn
            item.SubItems[2].Text = radNam.Checked ? "Nam" : "Nữ";
            item.SubItems[3].Text = LayChuoiNgoaiNgu();
            item.SubItems[4].Text = cboDanToc.SelectedItem?.ToString() ?? "Kinh";

            XoaTrangForm();
            MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Hàm dùng chung cho việc Xóa
        private void ThucHienXoa()
        {
            if (lvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = lvSinhVien.SelectedItems[0];
            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sinh viên [{item.SubItems[0].Text} - {item.SubItems[1].Text}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                lvSinhVien.Items.Remove(item);
                XoaTrangForm();
                MessageBox.Show("Đã xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 5. Nút "Xóa"
        private void btnXoa_Click(object sender, EventArgs e)
        {
            ThucHienXoa();
        }

        // 6. Xóa qua ContextMenuStrip khi nhấp chuột phải vào dòng trên ListView
        private void menuXoa_Click(object sender, EventArgs e)
        {
            ThucHienXoa();
        }

        // 7. Hỏi xác nhận trước khi đóng Form
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn đóng form không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.No)
            {
                e.Cancel = true; // Hủy thao tác đóng form
            }
        }
    }
}