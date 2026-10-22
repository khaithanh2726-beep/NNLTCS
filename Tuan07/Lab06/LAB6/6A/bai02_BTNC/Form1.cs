using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
namespace bai02_BTNC
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

        // Kiểm tra mã sinh viên và mã môn học
        private bool KiemTraMa()
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Mã sinh viên không được để trống!");
                txtMaSV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMaMH.Text))
            {
                MessageBox.Show("Mã môn học không được để trống!");
                txtMaMH.Focus();
                return false;
            }

            return true;
        }

        // Kiểm tra điểm nhập vào
        private bool KiemTraDiem(out double diem)
        {
            diem = 0;

            string giaTri = txtDiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(giaTri))
            {
                MessageBox.Show("Điểm không được để trống!");
                txtDiem.Focus();
                return false;
            }

            // Hỗ trợ nhập điểm bằng dấu chấm hoặc dấu phẩy
            giaTri = giaTri.Replace(',', '.');

            if (!double.TryParse(
                giaTri,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out diem))
            {
                MessageBox.Show("Điểm phải là số!");
                txtDiem.Focus();
                return false;
            }

            // Kiểm tra thang điểm 10
            if (diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm phải từ 0 đến 10!");
                txtDiem.Focus();
                return false;
            }

            return true;
        }

        // Xóa trắng các ô nhập
        private void XoaTrang()
        {
            txtMaSV.Clear();
            txtMaMH.Clear();
            txtDiem.Clear();
            txtMaSV.Focus();
        }

        // =========================
        // CHỨC NĂNG THÊM ĐIỂM
        // =========================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraMa())
                return;

            if (!KiemTraDiem(out double diem))
                return;

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "INSERT INTO dbo.Diem_Lab06 " +
                        "(MaSV, MaMH, Diem) " +
                        "VALUES (@MaSV, @MaMH, @Diem)";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaSV", SqlDbType.NVarChar, 20)
                            .Value = txtMaSV.Text.Trim();

                        cmd.Parameters.Add(
                            "@MaMH", SqlDbType.NVarChar, 20)
                            .Value = txtMaMH.Text.Trim();

                        cmd.Parameters.Add(
                            "@Diem", SqlDbType.Float)
                            .Value = diem;

                        cmd.ExecuteNonQuery();

                        MessageBox.Show(
                            "Thêm điểm thành công!",
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
                {
                    MessageBox.Show(
                        "Sinh viên đã có điểm môn học này!");
                }
                else
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // =========================
        // CHỨC NĂNG XÓA ĐIỂM
        // =========================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Chỉ cần mã SV và mã MH
            if (!KiemTraMa())
                return;

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa điểm này?",
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
                        "DELETE FROM dbo.Diem_Lab06 " +
                        "WHERE MaSV = @MaSV AND MaMH = @MaMH";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaSV", SqlDbType.NVarChar, 20)
                            .Value = txtMaSV.Text.Trim();

                        cmd.Parameters.Add(
                            "@MaMH", SqlDbType.NVarChar, 20)
                            .Value = txtMaMH.Text.Trim();

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                "Xóa điểm thành công!");
                            XoaTrang();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Không tìm thấy điểm cần xóa!");
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
        // CHỨC NĂNG SỬA ĐIỂM
        // =========================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraMa())
                return;

            if (!KiemTraDiem(out double diem))
                return;

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "UPDATE dbo.Diem_Lab06 " +
                        "SET Diem = @Diem " +
                        "WHERE MaSV = @MaSV AND MaMH = @MaMH";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaSV", SqlDbType.NVarChar, 20)
                            .Value = txtMaSV.Text.Trim();

                        cmd.Parameters.Add(
                            "@MaMH", SqlDbType.NVarChar, 20)
                            .Value = txtMaMH.Text.Trim();

                        cmd.Parameters.Add(
                            "@Diem", SqlDbType.Float)
                            .Value = diem;

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                "Sửa điểm thành công!");
                            XoaTrang();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Không tìm thấy điểm cần sửa!");
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
