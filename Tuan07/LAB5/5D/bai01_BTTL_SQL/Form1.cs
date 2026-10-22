using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace bai01_BTTL_SQL
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối đến cơ sở dữ liệu QLSinhVien (điều chỉnh Server Name nếu cần)
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QLSinhVien;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        // Chức năng Thêm môn học
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maMH = txtMaMH.Text.Trim();
            string tenMH = txtTenMH.Text.Trim();

            // Kiểm tra không được để trống
            if (string.IsNullOrEmpty(maMH) || string.IsNullOrEmpty(tenMH))
            {
                MessageBox.Show("Mã môn học và Tên môn học không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO MonHoc (MaMH, TenMH) VALUES (@MaMH, @TenMH)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        cmd.Parameters.AddWithValue("@TenMH", tenMH);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            XoaTrang();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Lỗi trùng khóa chính (Primary Key)
                    {
                        MessageBox.Show("Mã môn học đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Chức năng Xóa môn học
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maMH = txtMaMH.Text.Trim();

            if (string.IsNullOrEmpty(maMH))
            {
                MessageBox.Show("Vui lòng nhập Mã môn học cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa môn học có mã [{maMH}] không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM MonHoc WHERE MaMH = @MaMH";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaMH", maMH);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Xóa môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            XoaTrang();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy môn học có mã vừa nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Chức năng Sửa môn học
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maMH = txtMaMH.Text.Trim();
            string tenMH = txtTenMH.Text.Trim();

            if (string.IsNullOrEmpty(maMH) || string.IsNullOrEmpty(tenMH))
            {
                MessageBox.Show("Mã môn học và Tên môn học không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE MonHoc SET TenMH = @TenMH WHERE MaMH = @MaMH";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        cmd.Parameters.AddWithValue("@TenMH", tenMH);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            XoaTrang();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy môn học cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hàm xóa trắng ô nhập liệu
        private void XoaTrang()
        {
            txtMaMH.Clear();
            txtTenMH.Clear();
            txtMaMH.Focus();
        }
    }
}