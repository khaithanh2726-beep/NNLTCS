using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace bai01_BTNC
{
    public partial class Form1 : Form
    {
        // 3 mảng dữ liệu mẫu theo đề bài
        private readonly string[] HO = { "Lê", "Nguyễn", "Lý", "Trần", "Lâm", "Hồ", "Lai", "Huỳnh", "La" };
        private readonly string[] TENLOT = { "Quang", "Thành", "Ngọc", "Anh", "Xuân", "Bảo", "Cẩm", "Thị", "Kim", "Thái", "Hồng" };
        private readonly string[] TEN = { "Hà", "Danh", "Sơn", "Mai", "Thắng", "Kỳ", "Thành", "Lâm", "Tâm", "Phụng", "Thắm" };

        public Form1()
        {
            InitializeComponent();
        }

        // 1. Nút "Nhập tên ngẫu nhiên": Tạo 50 tên ngẫu nhiên nạp vào ListBox
        private void btnNgauNhien_Click(object sender, EventArgs e)
        {
            lstDanhSach.Items.Clear();
            Random rand = new Random();

            for (int i = 0; i < 50; i++)
            {
                string ho = HO[rand.Next(HO.Length)];
                string lot = TENLOT[rand.Next(TENLOT.Length)];
                string ten = TEN[rand.Next(TEN.Length)];

                lstDanhSach.Items.Add($"{ho} {lot} {ten}");
            }
        }

        // 2. Nút "Xóa Phần tử đang chọn"
        private void btnXoaChon_Click(object sender, EventArgs e)
        {
            if (lstDanhSach.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một phần tử để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xóa ngược từ cuối về đầu để tránh lệch chỉ số
            for (int i = lstDanhSach.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstDanhSach.Items.RemoveAt(lstDanhSach.SelectedIndices[i]);
            }
        }

        // 3. Nút "Xóa phần tử có tên là Sơn"
        private void btnXoaSon_Click(object sender, EventArgs e)
        {
            for (int i = lstDanhSach.Items.Count - 1; i >= 0; i--)
            {
                string hoTen = lstDanhSach.Items[i].ToString().Trim();
                string[] parts = hoTen.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0)
                {
                    string ten = parts[parts.Length - 1]; // Từ cuối cùng là Tên
                    if (string.Equals(ten, "Sơn", StringComparison.OrdinalIgnoreCase))
                    {
                        lstDanhSach.Items.RemoveAt(i);
                    }
                }
            }
        }

        // 4. Nút "Xóa Phần tử có họ là Lê"
        private void btnXoaLe_Click(object sender, EventArgs e)
        {
            for (int i = lstDanhSach.Items.Count - 1; i >= 0; i--)
            {
                string hoTen = lstDanhSach.Items[i].ToString().Trim();
                string[] parts = hoTen.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0)
                {
                    string ho = parts[0]; // Từ đầu tiên là Họ
                    if (string.Equals(ho, "Lê", StringComparison.OrdinalIgnoreCase))
                    {
                        lstDanhSach.Items.RemoveAt(i);
                    }
                }
            }
        }

        // 5. Nút "Chuyển PT đang chọn thành chữ HOA"
        private void btnInHoa_Click(object sender, EventArgs e)
        {
            if (lstDanhSach.SelectedIndices.Count == 0) return;

            // 1. Sao lưu danh sách các vị trí đang chọn
            int[] selected = new int[lstDanhSach.SelectedIndices.Count];
            lstDanhSach.SelectedIndices.CopyTo(selected, 0);

            // 2. Sao chép toàn bộ danh sách ra List
            List<string> items = new List<string>();
            foreach (var item in lstDanhSach.Items)
            {
                items.Add(item.ToString());
            }

            // 3. Biến đổi chữ HOA cho các dòng được chọn
            foreach (int idx in selected)
            {
                items[idx] = items[idx].ToUpper();
            }

            // 4. Nạp lại vào ListBox để ép xóa bộ đệm hiển thị (render cache)
            lstDanhSach.BeginUpdate();
            lstDanhSach.Items.Clear();
            foreach (var str in items)
            {
                lstDanhSach.Items.Add(str);
            }

            // 5. Phục hồi trạng thái bôi xanh
            foreach (int idx in selected)
            {
                lstDanhSach.SetSelected(idx, true);
            }
            lstDanhSach.EndUpdate();
        }

        // 6. Nút "Chuyển PT đang chọn thành chữ thường"
        private void btnInThuong_Click(object sender, EventArgs e)
        {
            if (lstDanhSach.SelectedIndices.Count == 0) return;

            int[] selected = new int[lstDanhSach.SelectedIndices.Count];
            lstDanhSach.SelectedIndices.CopyTo(selected, 0);

            List<string> items = new List<string>();
            foreach (var item in lstDanhSach.Items)
            {
                items.Add(item.ToString());
            }

            foreach (int idx in selected)
            {
                items[idx] = items[idx].ToLower();
            }

            lstDanhSach.BeginUpdate();
            lstDanhSach.Items.Clear();
            foreach (var str in items)
            {
                lstDanhSach.Items.Add(str);
            }

            foreach (int idx in selected)
            {
                lstDanhSach.SetSelected(idx, true);
            }
            lstDanhSach.EndUpdate();
        }

        // 7. Nút "Chuyển PT đang chọn thành viết Hoa đầu mỗi từ"
        private void btnVietHoaDauTu_Click(object sender, EventArgs e)
        {
            if (lstDanhSach.SelectedIndices.Count == 0) return;

            int[] selected = new int[lstDanhSach.SelectedIndices.Count];
            lstDanhSach.SelectedIndices.CopyTo(selected, 0);

            TextInfo textInfo = new CultureInfo("vi-VN", false).TextInfo;

            List<string> items = new List<string>();
            foreach (var item in lstDanhSach.Items)
            {
                items.Add(item.ToString());
            }

            foreach (int idx in selected)
            {
                // Hạ về chữ thường trước khi ToTitleCase để tránh bỏ sót ký tự
                string lower = items[idx].ToLower();
                items[idx] = textInfo.ToTitleCase(lower);
            }

            lstDanhSach.BeginUpdate();
            lstDanhSach.Items.Clear();
            foreach (var str in items)
            {
                lstDanhSach.Items.Add(str);
            }

            foreach (int idx in selected)
            {
                lstDanhSach.SetSelected(idx, true);
            }
            lstDanhSach.EndUpdate();
        }

        // 8. Nút "Xóa tất cả các Phần tử"
        private void btnXoaTatCa_Click(object sender, EventArgs e)
        {
            lstDanhSach.Items.Clear();
        }

        // 9. Double click vào phần tử -> mở InputBox sửa tên
        private void lstDanhSach_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = lstDanhSach.SelectedIndex;
            if (selectedIndex == -1) return;

            string currentName = lstDanhSach.Items[selectedIndex].ToString();
            string newName = ShowCustomInputBox("Nhập tên mới:", "Thay đổi họ tên", currentName);

            if (!string.IsNullOrWhiteSpace(newName))
            {
                lstDanhSach.BeginUpdate();
                lstDanhSach.Items[selectedIndex] = newName.Trim();
                // Nạp làm mới nhẹ để đồng bộ
                lstDanhSach.Items.Insert(selectedIndex, newName.Trim());
                lstDanhSach.Items.RemoveAt(selectedIndex + 1);
                lstDanhSach.EndUpdate();
            }
        }

        // Hộp thoại nhập tên (InputBox) tự tạo
        private string ShowCustomInputBox(string prompt, string title, string defaultValue)
        {
            Form promptForm = new Form()
            {
                Width = 360,
                Height = 175,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 15, Text = prompt, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 20, Top = 40, Width = 300, Text = defaultValue };
            Button confirmation = new Button() { Text = "OK", Left = 135, Width = 85, Top = 80, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Hủy", Left = 235, Width = 85, Top = 80, DialogResult = DialogResult.Cancel };

            confirmation.Click += (s, ev) => { promptForm.Close(); };
            cancel.Click += (s, ev) => { promptForm.Close(); };

            promptForm.Controls.Add(textLabel);
            promptForm.Controls.Add(textBox);
            promptForm.Controls.Add(confirmation);
            promptForm.Controls.Add(cancel);
            promptForm.AcceptButton = confirmation;
            promptForm.CancelButton = cancel;

            return promptForm.ShowDialog(this) == DialogResult.OK ? textBox.Text : "";
        }
    }
}