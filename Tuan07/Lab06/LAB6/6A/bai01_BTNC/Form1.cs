
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace bai01_BTNC
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

        // Kiểm tra mã sinh viên
        private bool KiemTraMaSV()
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show(
                    "Mã sinh viên không được để trống!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMaSV.Focus();
                return false;
            }

            return true;
        }

        // Kiểm tra và chuyển đổi ngày sinh
        private bool LayNgaySinh(out DateTime ngaySinh)
        {
            ngaySinh = DateTime.MinValue;

            if (!txtNgaySinh.MaskCompleted)
                return false;

            return DateTime.TryParseExact(
                txtNgaySinh.Text,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out ngaySinh);
        }

        // Xóa trắng các ô nhập
        private void XoaTrang()
        {
            txtMaLop.Clear();
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtNgaySinh.Clear();
            txtMaSV.Focus();
        }

        // =========================
        // CHỨC NĂNG THÊM SINH VIÊN
        // =========================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Mã lớp không được để trống!");
                txtMaLop.Focus();
                return;
            }

            if (!KiemTraMaSV())
                return;

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!");
                txtHoTen.Focus();
                return;
            }

            if (!LayNgaySinh(out DateTime ngaySinh))
            {
                MessageBox.Show(
                    "Ngày sinh không hợp lệ! Nhập dd/MM/yyyy");
                txtNgaySinh.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "INSERT INTO dbo.SinhVien_Lab06 " +
                        "(MaLop, MaSV, HoTen, NgaySinh) " +
                        "VALUES (@MaLop, @MaSV, @HoTen, @NgaySinh)";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaLop", SqlDbType.NVarChar, 20)
                            .Value = txtMaLop.Text.Trim();

                        cmd.Parameters.Add(
                            "@MaSV", SqlDbType.NVarChar, 20)
                            .Value = txtMaSV.Text.Trim();

                        cmd.Parameters.Add(
                            "@HoTen", SqlDbType.NVarChar, 100)
                            .Value = txtHoTen.Text.Trim();

                        cmd.Parameters.Add(
                            "@NgaySinh", SqlDbType.Date)
                            .Value = ngaySinh;

                        cmd.ExecuteNonQuery();

                        MessageBox.Show(
                            "Thêm sinh viên thành công!",
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
                    MessageBox.Show("Mã sinh viên đã tồn tại!");
                else
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // =========================
        // CHỨC NĂNG XÓA SINH VIÊN
        // =========================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!KiemTraMaSV())
                return;

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!");
                txtHoTen.Focus();
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sinh viên này?",
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
                        "DELETE FROM dbo.SinhVien_Lab06 " +
                        "WHERE MaSV = @MaSV AND HoTen = @HoTen";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaSV", SqlDbType.NVarChar, 20)
                            .Value = txtMaSV.Text.Trim();

                        cmd.Parameters.Add(
                            "@HoTen", SqlDbType.NVarChar, 100)
                            .Value = txtHoTen.Text.Trim();

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                "Xóa sinh viên thành công!");
                            XoaTrang();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Không tìm thấy sinh viên có mã và họ tên này!");
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
        // CHỨC NĂNG SỬA SINH VIÊN
        // =========================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraMaSV())
                return;

            bool coMaLop =
                !string.IsNullOrWhiteSpace(txtMaLop.Text);

            bool coHoTen =
                !string.IsNullOrWhiteSpace(txtHoTen.Text);

            bool coNgaySinh =
                !string.IsNullOrWhiteSpace(
                    txtNgaySinh.Text.Replace("/", "").Replace("_", ""));

            if (!coMaLop && !coHoTen && !coNgaySinh)
            {
                MessageBox.Show(
                    "Phải nhập ít nhất một thông tin cần sửa!");
                return;
            }

            DateTime ngaySinh = DateTime.MinValue;

            if (coNgaySinh && !LayNgaySinh(out ngaySinh))
            {
                MessageBox.Show(
                    "Ngày sinh không hợp lệ! Nhập dd/MM/yyyy");
                txtNgaySinh.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "UPDATE dbo.SinhVien_Lab06 SET " +
                        "MaLop = COALESCE(@MaLop, MaLop), " +
                        "HoTen = COALESCE(@HoTen, HoTen), " +
                        "NgaySinh = COALESCE(@NgaySinh, NgaySinh) " +
                        "WHERE MaSV = @MaSV";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaSV", SqlDbType.NVarChar, 20)
                            .Value = txtMaSV.Text.Trim();

                        cmd.Parameters.Add(
                            "@MaLop", SqlDbType.NVarChar, 20)
                            .Value = coMaLop
                                ? txtMaLop.Text.Trim()
                                : (object)DBNull.Value;

                        cmd.Parameters.Add(
                            "@HoTen", SqlDbType.NVarChar, 100)
                            .Value = coHoTen
                                ? txtHoTen.Text.Trim()
                                : (object)DBNull.Value;

                        cmd.Parameters.Add(
                            "@NgaySinh", SqlDbType.Date)
                            .Value = coNgaySinh
                                ? ngaySinh
                                : (object)DBNull.Value;

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                "Sửa sinh viên thành công!");
                            XoaTrang();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Không tìm thấy mã sinh viên!");
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
