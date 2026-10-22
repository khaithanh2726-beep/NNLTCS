using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
namespace bai01_BTTL
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối SQL Server
        private readonly string connectionString =
            @"Server=.\SQLEXPRESS;Database=QLSinhVien;Integrated Security=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
            LoadDanhSachLop();
        }

        // =========================
        // HIỂN THỊ DANH SÁCH LỚP
        // =========================
        private void LoadDanhSachLop()
        {
            cboLop.DataSource = null;
            cboLop.Items.Clear();

            cboLop.Items.Add("DCT124C1");
            cboLop.Items.Add("DCT124C2");
            cboLop.Items.Add("DCT124C3");
            cboLop.Items.Add("DCT124C4");
            cboLop.Items.Add("DCT124C5");

            cboLop.SelectedIndex = -1;
        }

        // =========================
        // KIỂM TRA MÃ SINH VIÊN
        // =========================
        private bool KiemTraMaSV()
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show(
                    "Mã sinh viên không được để trống!");
                txtMaSV.Focus();
                return false;
            }

            return true;
        }

        // =========================
        // KIỂM TRA NGÀY SINH
        // =========================
        private bool KiemTraNgaySinh(out DateTime ngaySinh)
        {
            ngaySinh = DateTime.MinValue;

            if (!txtNgaySinh.MaskCompleted ||
                !DateTime.TryParseExact(
                    txtNgaySinh.Text,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out ngaySinh))
            {
                MessageBox.Show(
                    "Ngày sinh không hợp lệ! Nhập dd/MM/yyyy");
                txtNgaySinh.Focus();
                return false;
            }

            // Kiểm tra tuổi theo năm sinh
            int tuoi = DateTime.Today.Year - ngaySinh.Year;

            if (tuoi < 17)
            {
                MessageBox.Show(
                    "Sinh viên phải từ 17 tuổi trở lên!");
                txtNgaySinh.Focus();
                return false;
            }

            return true;
        }

        // =========================
        // KIỂM TRA DỮ LIỆU
        // =========================
        private bool KiemTraDuLieu(out DateTime ngaySinh)
        {
            ngaySinh = DateTime.MinValue;

            if (cboLop.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn lớp!");
                cboLop.Focus();
                return false;
            }

            if (!KiemTraMaSV())
                return false;

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show(
                    "Họ tên không được để trống!");
                txtHoTen.Focus();
                return false;
            }

            return KiemTraNgaySinh(out ngaySinh);
        }

        // =========================
        // XÓA TRẮNG Ô NHẬP
        // =========================
        private void XoaTrang()
        {
            cboLop.SelectedIndex = -1;
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtNgaySinh.Clear();
            txtMaSV.Focus();
        }

        // =========================
        // KIỂM TRA SINH VIÊN TỒN TẠI
        // =========================
        private bool SinhVienTonTai(string maSV)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();

                string sql =
                    "SELECT COUNT(*) FROM dbo.SinhVien_Combo " +
                    "WHERE MaSV = @MaSV";

                using (SqlCommand cmd =
                    new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(
                        "@MaSV", SqlDbType.NVarChar, 20)
                        .Value = maSV;

                    return Convert.ToInt32(
                        cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // =========================
        // CHỨC NĂNG THÊM SINH VIÊN
        // =========================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu(out DateTime ngaySinh))
                return;

            try
            {
                string maSV = txtMaSV.Text.Trim();

                if (SinhVienTonTai(maSV))
                {
                    MessageBox.Show(
                        "Mã sinh viên đã tồn tại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "INSERT INTO dbo.SinhVien_Combo " +
                        "(MaLop, MaSV, HoTen, NgaySinh) " +
                        "VALUES (@MaLop, @MaSV, @HoTen, @NgaySinh)";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaLop", SqlDbType.NVarChar, 20)
                            .Value = cboLop.SelectedItem.ToString();

                        cmd.Parameters.Add(
                            "@MaSV", SqlDbType.NVarChar, 20)
                            .Value = maSV;

                        cmd.Parameters.Add(
                            "@HoTen", SqlDbType.NVarChar, 100)
                            .Value = txtHoTen.Text.Trim();

                        cmd.Parameters.Add(
                            "@NgaySinh", SqlDbType.Date)
                            .Value = ngaySinh;

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                "Thêm sinh viên thành công!",
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
                        "Mã sinh viên đã tồn tại!");
                }
                else if (ex.Number == 547)
                {
                    MessageBox.Show(
                        "Mã lớp không hợp lệ hoặc vi phạm ràng buộc dữ liệu!");
                }
                else
                {
                    MessageBox.Show(
                        "Lỗi SQL: " + ex.Message);
                }
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
                        "DELETE FROM dbo.SinhVien_Combo " +
                        "WHERE MaSV = @MaSV";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaSV", SqlDbType.NVarChar, 20)
                            .Value = txtMaSV.Text.Trim();

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                "Xóa sinh viên thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

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
                if (ex.Number == 547)
                {
                    MessageBox.Show(
                        "Không thể xóa vì sinh viên đang được bảng khác tham chiếu!");
                }
                else
                {
                    MessageBox.Show(
                        "Lỗi SQL: " + ex.Message);
                }
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
            if (!KiemTraDuLieu(out DateTime ngaySinh))
                return;

            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "UPDATE dbo.SinhVien_Combo " +
                        "SET MaLop = @MaLop, " +
                        "HoTen = @HoTen, " +
                        "NgaySinh = @NgaySinh " +
                        "WHERE MaSV = @MaSV";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaSV", SqlDbType.NVarChar, 20)
                            .Value = txtMaSV.Text.Trim();

                        cmd.Parameters.Add(
                            "@MaLop", SqlDbType.NVarChar, 20)
                            .Value = cboLop.SelectedItem.ToString();

                        cmd.Parameters.Add(
                            "@HoTen", SqlDbType.NVarChar, 100)
                            .Value = txtHoTen.Text.Trim();

                        cmd.Parameters.Add(
                            "@NgaySinh", SqlDbType.Date)
                            .Value = ngaySinh;

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                "Sửa sinh viên thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

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
                if (ex.Number == 547)
                {
                    MessageBox.Show(
                        "Mã lớp không hợp lệ hoặc vi phạm ràng buộc dữ liệu!");
                }
                else
                {
                    MessageBox.Show(
                        "Lỗi SQL: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
