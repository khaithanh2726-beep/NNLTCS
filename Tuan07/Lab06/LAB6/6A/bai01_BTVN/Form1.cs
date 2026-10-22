using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
namespace bai01_BTVN
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối SQL Server
        private readonly string connectionString =
            @"Server=.\SQLEXPRESS;Database=QLSinhVien;Integrated Security=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
        }

        // Kiểm tra mã lớp
        private bool KiemTraMaLop()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Mã lớp không được để trống!");
                txtMaLop.Focus();
                return false;
            }

            return true;
        }

        // Xóa trắng các ô nhập
        private void XoaTrang()
        {
            txtMaKhoa.Clear();
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtMaLop.Focus();
        }

        // =========================
        // CHỨC NĂNG THÊM LỚP
        // =========================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhoa.Text))
            {
                MessageBox.Show("Mã khoa không được để trống!");
                txtMaKhoa.Focus();
                return;
            }

            if (!KiemTraMaLop())
                return;

            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Tên lớp không được để trống!");
                txtTenLop.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "INSERT INTO dbo.Lop_Lab06 " +
                        "(MaKhoa, MaLop, TenLop) " +
                        "VALUES (@MaKhoa, @MaLop, @TenLop)";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaKhoa", SqlDbType.NVarChar, 20)
                            .Value = txtMaKhoa.Text.Trim();

                        cmd.Parameters.Add(
                            "@MaLop", SqlDbType.NVarChar, 20)
                            .Value = txtMaLop.Text.Trim();

                        cmd.Parameters.Add(
                            "@TenLop", SqlDbType.NVarChar, 100)
                            .Value = txtTenLop.Text.Trim();

                        cmd.ExecuteNonQuery();

                        MessageBox.Show(
                            "Thêm lớp thành công!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        XoaTrang();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    MessageBox.Show("Mã lớp đã tồn tại!");
                else
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // =========================
        // CHỨC NĂNG XÓA LỚP
        // =========================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Chỉ cần nhập mã lớp
            if (!KiemTraMaLop())
                return;

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa lớp này?",
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
                        "DELETE FROM dbo.Lop_Lab06 " +
                        "WHERE MaLop = @MaLop";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaLop", SqlDbType.NVarChar, 20)
                            .Value = txtMaLop.Text.Trim();

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                "Xóa lớp thành công!");
                            XoaTrang();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Không tìm thấy mã lớp!");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // =========================
        // CHỨC NĂNG SỬA LỚP
        // =========================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraMaLop())
                return;

            bool coMaKhoa =
                !string.IsNullOrWhiteSpace(txtMaKhoa.Text);

            bool coTenLop =
                !string.IsNullOrWhiteSpace(txtTenLop.Text);

            if (!coMaKhoa && !coTenLop)
            {
                MessageBox.Show(
                    "Phải nhập ít nhất một thông tin cần sửa!");
                return;
            }

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "UPDATE dbo.Lop_Lab06 SET " +
                        "MaKhoa = COALESCE(@MaKhoa, MaKhoa), " +
                        "TenLop = COALESCE(@TenLop, TenLop) " +
                        "WHERE MaLop = @MaLop";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaLop", SqlDbType.NVarChar, 20)
                            .Value = txtMaLop.Text.Trim();

                        cmd.Parameters.Add(
                            "@MaKhoa", SqlDbType.NVarChar, 20)
                            .Value = coMaKhoa
                                ? txtMaKhoa.Text.Trim()
                                : (object)DBNull.Value;

                        cmd.Parameters.Add(
                            "@TenLop", SqlDbType.NVarChar, 100)
                            .Value = coTenLop
                                ? txtTenLop.Text.Trim()
                                : (object)DBNull.Value;

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                "Sửa lớp thành công!");
                            XoaTrang();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Không tìm thấy mã lớp!");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
