using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bai02_BTVN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Nhập số tự nhiên N vào ListBox (kiểm tra N >= 0)
        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập một số tự nhiên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhap.Focus();
                return;
            }

            if (!long.TryParse(txtNhap.Text.Trim(), out long n) || n < 0)
            {
                MessageBox.Show("Vui lòng nhập số tự nhiên hợp lệ (>= 0)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNhap.SelectAll();
                txtNhap.Focus();
                return;
            }

            lstSo.Items.Add(n);
            txtNhap.Clear();
            txtNhap.Focus();
        }

        // 2. Tính tổng các phần tử trong ListBox
        private void btnTong_Click(object sender, EventArgs e)
        {
            if (lstSo.Items.Count == 0)
            {
                MessageBox.Show("Listbox đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long tong = 0;
            foreach (var item in lstSo.Items)
            {
                tong += Convert.ToInt64(item);
            }

            MessageBox.Show($"Tổng các phần tử trong List là: {tong}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 3. Xóa phần tử đầu và cuối của ListBox
        private void btnXoaDauCuoi_Click(object sender, EventArgs e)
        {
            if (lstSo.Items.Count == 0)
            {
                MessageBox.Show("Listbox đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstSo.Items.Count == 1)
            {
                lstSo.Items.RemoveAt(0);
            }
            else
            {
                // Xóa phần tử cuối cùng trước để không làm xê dịch chỉ mục của phần tử đầu
                lstSo.Items.RemoveAt(lstSo.Items.Count - 1);
                lstSo.Items.RemoveAt(0);
            }
        }

        // 4. Xóa các phần tử đang chọn trong ListBox
        private void btnXoaChon_Click(object sender, EventArgs e)
        {
            if (lstSo.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một phần tử cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xóa ngược từ chỉ số lớn nhất về nhỏ nhất để tránh lệch index
            for (int i = lstSo.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstSo.Items.RemoveAt(lstSo.SelectedIndices[i]);
            }
        }

        // 5. Tăng mỗi phần tử lên 2
        private void btnTang2_Click(object sender, EventArgs e)
        {
            if (lstSo.Items.Count == 0) return;

            List<long> updatedList = new List<long>();
            foreach (var item in lstSo.Items)
            {
                updatedList.Add(Convert.ToInt64(item) + 2);
            }

            // Dùng BeginUpdate / EndUpdate để xóa bộ đệm hiển thị và vẽ lại ngay lập tức
            lstSo.BeginUpdate();
            lstSo.Items.Clear();
            foreach (var val in updatedList)
            {
                lstSo.Items.Add(val);
            }
            lstSo.EndUpdate();
        }

        // 6. Thay mỗi phần tử bằng bình phương của chính nó
        private void btnBinhPhuong_Click(object sender, EventArgs e)
        {
            if (lstSo.Items.Count == 0) return;

            List<long> updatedList = new List<long>();
            foreach (var item in lstSo.Items)
            {
                long val = Convert.ToInt64(item);
                updatedList.Add(val * val);
            }

            lstSo.BeginUpdate();
            lstSo.Items.Clear();
            foreach (var val in updatedList)
            {
                lstSo.Items.Add(val);
            }
            lstSo.EndUpdate();
        }

        // 7. Chọn các số chẵn trong ListBox
        private void btnChonChan_Click(object sender, EventArgs e)
        {
            lstSo.ClearSelected();
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                if (Convert.ToInt64(lstSo.Items[i]) % 2 == 0)
                {
                    lstSo.SetSelected(i, true);
                }
            }
        }

        // 8. Chọn các số lẻ trong ListBox
        private void btnChonLe_Click(object sender, EventArgs e)
        {
            lstSo.ClearSelected();
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                if (Convert.ToInt64(lstSo.Items[i]) % 2 != 0)
                {
                    lstSo.SetSelected(i, true);
                }
            }
        }

        // 9. Nút KẾT THÚC
        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn kết thúc chương trình?",
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