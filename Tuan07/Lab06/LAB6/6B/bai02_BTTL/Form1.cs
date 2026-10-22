using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace bai02_BTTL
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối SQL Server
        private readonly string connectionString =
            @"Server=.\SQLEXPRESS;Database=QLSinhVien;Integrated Security=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
            LoadDanhSach();
        }

        // =========================
        // TẢI DỮ LIỆU COMBOBOX
        // =========================
        private void LoadDanhSach()
        {
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Danh sách sinh viên
                    string sqlSV =
                        "SELECT MaSV, HoTen " +
                        "FROM dbo.SinhVien_DiemCombo " +
                        "ORDER BY MaSV";

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(sqlSV, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboSinhVien.DataSource = dt;
                        cboSinhVien.DisplayMember = "HoTen";
                        cboSinhVien.ValueMember = "MaSV";
                        cboSinhVien.SelectedIndex = -1;
                    }

                    // Danh sách môn học
                    string sqlMH =
                        "SELECT MaMH, TenMH " +
                        "FROM dbo.MonHoc_DiemCombo " +
                        "ORDER BY MaMH";

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(sqlMH, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboMonHoc.DataSource = dt;
                        cboMonHoc.DisplayMember = "TenMH";
                        cboMonHoc.ValueMember = "MaMH";
                        cboMonHoc.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // =========================
        // KIỂM TRA COMBOBOX
        // =========================
        private bool KiemTraLuaChon()
        {
            if (cboSinhVien.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn sinh viên!");
                cboSinhVien.Focus();
                return false;
            }

            if (cboMonHoc.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn môn học!");
                cboMonHoc.Focus();
                return false;
            }

            return true;
        }

        // =========================
        // KIỂM TRA ĐIỂM
        // =========================
        private bool KiemTraDiem(out double diem)
        {
            diem = 0;

            string giaTri = txtDiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(giaTri))
            {
                MessageBox.Show(
                    "Điểm không được để trống!");
                txtDiem.Focus();
                return false;
            }

            giaTri = giaTri.Replace(',', '.');

            if (!double.TryParse(
                giaTri,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out diem) ||
                double.IsNaN(diem) ||
                double.IsInfinity(diem))
            {
                MessageBox.Show(
                    "Điểm phải là số hợp lệ!");
                txtDiem.Focus();
                return false;
            }

            if (diem < 0 || diem > 10)
            {
                MessageBox.Show(
                    "Điểm phải nằm trong khoảng 0 đến 10!");
                txtDiem.Focus();
                return false;
            }

            return true;
        }

        // =========================
        // XÓA TRẮNG DỮ LIỆU
        // =========================
        private void XoaTrang()
        {
            cboSinhVien.SelectedIndex = -1;
            cboMonHoc.SelectedIndex = -1;
            txtDiem.Clear();
            cboSinhVien.Focus();
        }

        // =========================
        // KIỂM TRA ĐIỂM TỒN TẠI
        // =========================
        private bool DiemTonTai(string maSV, string maMH)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();

                string sql =
                    "SELECT COUNT(*) FROM dbo.Diem_Combo " +
                    "WHERE MaSV = @MaSV AND MaMH = @MaMH";

                using (SqlCommand cmd =
                    new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(
                        "@MaSV", SqlDbType.NVarChar, 20)
                        .Value = maSV;

                    cmd.Parameters.Add(
                        "@MaMH", SqlDbType.NVarChar, 20)
                        .Value = maMH;

                    return Convert.ToInt32(
                        cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // =========================
        // CHỨC NĂNG THÊM ĐIỂM
        // =========================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraLuaChon())
                return;

            if (!KiemTraDiem(out double diem))
                return;

            try
            {
                string maSV =
                    cboSinhVien.SelectedValue.ToString();

                string maMH =
                    cboMonHoc.SelectedValue.ToString();

                if (DiemTonTai(maSV, maMH))
                {
                    MessageBox.Show(
                        "Sinh viên đã có điểm môn học này!");
                    return;
                }

                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "INSERT INTO dbo.Diem_Combo " +
                        "(MaSV, MaMH, Diem) " +
                        "VALUES (@MaSV, @MaMH, @Diem)";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaSV", SqlDbType.NVarChar, 20)
                            .Value = maSV;

                        cmd.Parameters.Add(
                            "@MaMH", SqlDbType.NVarChar, 20)
                            .Value = maMH;

                        cmd.Parameters.Add(
                            "@Diem", SqlDbType.Float)
                            .Value = diem;

                        int ketQua = cmd.ExecuteNonQuery();

                        if (ketQua > 0)
                        {
                            MessageBox.Show(
                                "Thêm điểm thành công!",
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
                        "Điểm môn học này đã tồn tại!");
                }
                else if (ex.Number == 547)
                {
                    MessageBox.Show(
                        "Mã sinh viên hoặc mã môn học không hợp lệ!");
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
        // CHỨC NĂNG XÓA ĐIỂM
        // =========================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!KiemTraLuaChon())
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
                        "DELETE FROM dbo.Diem_Combo " +
                        "WHERE MaSV = @MaSV AND MaMH = @MaMH";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaSV", SqlDbType.NVarChar, 20)
                            .Value = cboSinhVien.SelectedValue.ToString();

                        cmd.Parameters.Add(
                            "@MaMH", SqlDbType.NVarChar, 20)
                            .Value = cboMonHoc.SelectedValue.ToString();

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
                if (ex.Number == 547)
                    MessageBox.Show(
                        "Không thể xóa do ràng buộc khóa ngoại!");
                else
                    MessageBox.Show(
                        "Lỗi SQL: " + ex.Message);
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
            if (!KiemTraLuaChon())
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
                        "UPDATE dbo.Diem_Combo " +
                        "SET Diem = @Diem " +
                        "WHERE MaSV = @MaSV AND MaMH = @MaMH";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaSV", SqlDbType.NVarChar, 20)
                            .Value = cboSinhVien.SelectedValue.ToString();

                        cmd.Parameters.Add(
                            "@MaMH", SqlDbType.NVarChar, 20)
                            .Value = cboMonHoc.SelectedValue.ToString();

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
                if (ex.Number == 547)
                    MessageBox.Show(
                        "Vi phạm ràng buộc dữ liệu!");
                else
                    MessageBox.Show(
                        "Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
