using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace bai01_BTNC_SQL
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QLSinhVien;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        // 1. CHỨC NĂNG THÊM DỮ LIỆU
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string ngaySinhStr = mtxtNgaySinh.Text.Trim();

            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrEmpty(maLop) || string.IsNullOrEmpty(maSV) ||
                string.IsNullOrEmpty(hoTen) || !mtxtNgaySinh.MaskCompleted)
            {
                MessageBox.Show("Mã lớp, Mã sinh viên, Tên sinh viên và Ngày sinh không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ép kiểu Ngày sinh theo chuẩn dd/MM/yyyy
            if (!DateTime.TryParseExact(ngaySinhStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không đúng định dạng dd/MM/yyyy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO SinhVien (MaLop, MaSV, TenSV, NgaySinh) VALUES (@MaLop, @MaSV, @TenSV, @NgaySinh)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLop", maLop);
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@TenSV", hoTen);
                        // Chỉ lấy Date để truyền vào CSDL
                        cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = ngaySinh.Date;

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            XoaTrang();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Lỗi trùng khóa chính (MaSV)
                    {
                        MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // 2. CHỨC NĂNG XÓA DỮ LIỆU
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            // Yêu cầu: Mã sinh viên và Tên sinh viên không được để trống
            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Mã sinh viên và Tên sinh viên không được để trống khi xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc muốn xóa sinh viên [{hoTen}] - Mã: [{maSV}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM SinhVien WHERE MaSV = @MaSV AND TenSV = @TenSV";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@TenSV", hoTen);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            XoaTrang();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sinh viên có Mã và Tên khớp với thông tin nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 3. CHỨC NĂNG SỬA DỮ LIỆU
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string maLop = txtMaLop.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            bool hasNgaySinh = mtxtNgaySinh.MaskCompleted;

            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Mã sinh viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(maLop) && string.IsNullOrEmpty(hoTen) && !hasNgaySinh)
            {
                MessageBox.Show("Mã lớp, Tên sinh viên, Ngày sinh phải có ít nhất một trường có dữ liệu để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> setClauses = new List<string>();
            SqlCommand cmd = new SqlCommand();

            if (!string.IsNullOrEmpty(maLop))
            {
                setClauses.Add("MaLop = @MaLop");
                cmd.Parameters.AddWithValue("@MaLop", maLop);
            }

            if (!string.IsNullOrEmpty(hoTen))
            {
                setClauses.Add("TenSV = @TenSV");
                cmd.Parameters.AddWithValue("@TenSV", hoTen);
            }

            if (hasNgaySinh)
            {
                if (DateTime.TryParseExact(mtxtNgaySinh.Text.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ngaySinh))
                {
                    setClauses.Add("NgaySinh = @NgaySinh");
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = ngaySinh.Date;
                }
                else
                {
                    MessageBox.Show("Ngày sinh không đúng định dạng dd/MM/yyyy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = $"UPDATE SinhVien SET {string.Join(", ", setClauses)} WHERE MaSV = @MaSV";
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@MaSV", maSV);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        XoaTrang();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên có Mã sinh viên tương ứng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void XoaTrang()
        {
            txtMaLop.Clear();
            txtMaSV.Clear();
            txtHoTen.Clear();
            mtxtNgaySinh.Clear();
            txtMaLop.Focus();
        }
    }
}