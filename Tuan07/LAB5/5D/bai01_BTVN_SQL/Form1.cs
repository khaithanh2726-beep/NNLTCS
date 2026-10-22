using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace bai01_BTVN_SQL
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
            string maKhoa = txtMaKhoa.Text.Trim();
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();

            // Yêu cầu: Mã khoa, Mã lớp, Tên lớp không được để trống
            if (string.IsNullOrEmpty(maKhoa) || string.IsNullOrEmpty(maLop) || string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Mã khoa, Mã lớp và Tên lớp không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Lop (MaLop, MaKhoa, TenLop) VALUES (@MaLop, @MaKhoa, @TenLop)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLop", maLop);
                        cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                        cmd.Parameters.AddWithValue("@TenLop", tenLop);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Thêm lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            XoaTrang();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Lỗi trùng khóa chính MaLop
                    {
                        MessageBox.Show("Mã lớp này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string maLop = txtMaLop.Text.Trim();

            // Yêu cầu: Mã lớp không được để trống, Mã khoa & Tên lớp không nhập dữ liệu
            if (string.IsNullOrEmpty(maLop))
            {
                MessageBox.Show("Mã lớp không được để trống khi xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtMaKhoa.Text.Trim()) || !string.IsNullOrEmpty(txtTenLop.Text.Trim()))
            {
                MessageBox.Show("Khi xóa chỉ cần nhập Mã lớp, không nhập Mã khoa và Tên lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa lớp [{maLop}] không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM Lop WHERE MaLop = @MaLop";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLop", maLop);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Xóa thông tin lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            XoaTrang();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy lớp có Mã lớp vừa nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string maLop = txtMaLop.Text.Trim();
            string maKhoa = txtMaKhoa.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();

            // Yêu cầu: Mã lớp không được để trống
            if (string.IsNullOrEmpty(maLop))
            {
                MessageBox.Show("Mã lớp không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Yêu cầu: Mã khoa, Tên lớp phải có ít nhất 1 trường có dữ liệu
            if (string.IsNullOrEmpty(maKhoa) && string.IsNullOrEmpty(tenLop))
            {
                MessageBox.Show("Mã khoa hoặc Tên lớp phải có ít nhất 1 trường có dữ liệu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> setClauses = new List<string>();
            SqlCommand cmd = new SqlCommand();

            if (!string.IsNullOrEmpty(maKhoa))
            {
                setClauses.Add("MaKhoa = @MaKhoa");
                cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
            }

            if (!string.IsNullOrEmpty(tenLop))
            {
                setClauses.Add("TenLop = @TenLop");
                cmd.Parameters.AddWithValue("@TenLop", tenLop);
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = $"UPDATE Lop SET {string.Join(", ", setClauses)} WHERE MaLop = @MaLop";
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@MaLop", maLop);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        XoaTrang();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy lớp có Mã lớp vừa nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtMaKhoa.Clear();
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtMaKhoa.Focus();
        }
    }
}