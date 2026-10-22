using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace bai01_BTTL
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối SQL Server
        // Thay tên Server cho đúng với máy của bạn
        private readonly string connectionString =
            @"Server=.\SQLEXPRESS;Database=QLSinhVien;Integrated Security=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
        }

        // Kiểm tra dữ liệu nhập
        private bool KiemTraDuLieu(bool kiemTraTen)
        {
            if (string.IsNullOrWhiteSpace(txtMaMH.Text))
            {
                MessageBox.Show(
                    "Mã môn học không được để trống!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMaMH.Focus();
                return false;
            }

            if (kiemTraTen &&
                string.IsNullOrWhiteSpace(txtTenMH.Text))
            {
                MessageBox.Show(
                    "Tên môn học không được để trống!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenMH.Focus();
                return false;
            }

            return true;
        }

        // Xóa nội dung TextBox
        private void XoaTrang()
        {
            txtMaMH.Clear();
            txtTenMH.Clear();
            txtMaMH.Focus();
        }

        // =========================
        // CHỨC NĂNG THÊM MÔN HỌC
        // =========================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu(true))
                return;

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "INSERT INTO dbo.MonHoc_Lab06 " +
                        "(MaMH, TenMH) " +
                        "VALUES (@MaMH, @TenMH)";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaMH",
                            SqlDbType.NVarChar, 20).Value =
                            txtMaMH.Text.Trim();

                        cmd.Parameters.Add(
                            "@TenMH",
                            SqlDbType.NVarChar, 100).Value =
                            txtTenMH.Text.Trim();

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                "Thêm môn học thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            XoaTrang();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show(
                        "Mã môn học đã tồn tại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Lỗi SQL: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi: " + ex.Message);
            }
        }

        // =========================
        // CHỨC NĂNG XÓA MÔN HỌC
        // =========================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Chỉ yêu cầu nhập mã môn học
            if (!KiemTraDuLieu(false))
                return;

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa môn học này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "DELETE FROM dbo.MonHoc_Lab06 " +
                        "WHERE MaMH = @MaMH";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaMH",
                            SqlDbType.NVarChar, 20).Value =
                            txtMaMH.Text.Trim();

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                "Xóa môn học thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            XoaTrang();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Không tìm thấy mã môn học!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi: " + ex.Message);
            }
        }

        // =========================
        // CHỨC NĂNG SỬA MÔN HỌC
        // =========================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu(true))
                return;

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "UPDATE dbo.MonHoc_Lab06 " +
                        "SET TenMH = @TenMH " +
                        "WHERE MaMH = @MaMH";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaMH",
                            SqlDbType.NVarChar, 20).Value =
                            txtMaMH.Text.Trim();

                        cmd.Parameters.Add(
                            "@TenMH",
                            SqlDbType.NVarChar, 100).Value =
                            txtTenMH.Text.Trim();

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                "Sửa môn học thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            XoaTrang();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Không tìm thấy mã môn học!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi: " + ex.Message);
            }
        }
    }
}
