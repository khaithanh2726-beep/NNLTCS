using System;
using System.Windows.Forms;

namespace bai01_BTTL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Hàm hỗ trợ kiểm tra số nguyên tố
        private bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        // 1. Thêm số vào combobox và kiểm tra hợp lệ
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNhapSo.Text))
            {
                MessageBox.Show("Vui lòng nhập một số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapSo.Focus();
                return;
            }

            if (!int.TryParse(txtNhapSo.Text.Trim(), out int number) || number <= 0)
            {
                MessageBox.Show("Vui lòng nhập một số nguyên dương hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNhapSo.SelectAll();
                txtNhapSo.Focus();
                return;
            }

            if (cboSo.Items.Contains(number))
            {
                MessageBox.Show("Số này đã tồn tại trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cboSo.Items.Add(number);
                cboSo.SelectedItem = number;
            }

            txtNhapSo.Clear();
            txtNhapSo.Focus();
        }

        // 2. Chọn giá trị trên combobox -> tính danh sách ước số nạp vào ListBox
        private void cboSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSo.SelectedItem == null) return;

            lstUocSo.Items.Clear();
            int n = (int)cboSo.SelectedItem;

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    lstUocSo.Items.Add(i);
                }
            }
        }

        // 3. Tính tổng các ước số trên listbox
        private void btnTongUoc_Click(object sender, EventArgs e)
        {
            if (lstUocSo.Items.Count == 0)
            {
                MessageBox.Show("Chưa có danh sách ước số để tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sum = 0;
            foreach (var item in lstUocSo.Items)
            {
                sum += Convert.ToInt32(item);
            }

            MessageBox.Show($"Tổng các ước số là: {sum}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 4. Đếm số lượng các ước số chẵn trên listbox
        private void btnDemChan_Click(object sender, EventArgs e)
        {
            if (lstUocSo.Items.Count == 0)
            {
                MessageBox.Show("Chưa có danh sách ước số để tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int count = 0;
            foreach (var item in lstUocSo.Items)
            {
                int val = Convert.ToInt32(item);
                if (val % 2 == 0)
                {
                    count++;
                }
            }

            MessageBox.Show($"Số lượng các ước số chẵn là: {count}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 5. Đếm số lượng các ước số nguyên tố trên listbox
        private void btnDemNguyenTo_Click(object sender, EventArgs e)
        {
            if (lstUocSo.Items.Count == 0)
            {
                MessageBox.Show("Chưa có danh sách ước số để tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int count = 0;
            foreach (var item in lstUocSo.Items)
            {
                int val = Convert.ToInt32(item);
                if (IsPrime(val))
                {
                    count++;
                }
            }

            MessageBox.Show($"Số lượng các ước số nguyên tố là: {count}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 6. Thoát chương trình có xác nhận
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Bạn có chắc muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}