using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace bai01_BTVN
{
    public partial class frmBanHang : Form
    {
        private readonly string connectionString =
            @"Server=.\SQLEXPRESS;Database=QLCuaHang;Integrated Security=True;TrustServerCertificate=True;";

        private int maHD = 0;

        public frmBanHang()
        {
            InitializeComponent();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            LoadSanPham();
            KhoaNhapLieu();
        }

        private void KhoaNhapLieu()
        {
            cboMaSP.Enabled = false;
            txtSoLuong.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = false;
            btnThanhToan.Enabled = false;
        }

        private void MoNhapLieu()
        {
            cboMaSP.Enabled = true;
            txtSoLuong.Enabled = true;
            btnThem.Enabled = true;
            btnHuy.Enabled = true;
            btnThanhToan.Enabled = true;
        }

        private void LoadSanPham()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql =
                        "SELECT MaSP, TenSP FROM dbo.SANPHAM ORDER BY MaSP";

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboMaSP.DataSource = dt;
                        cboMaSP.DisplayMember = "MaSP";
                        cboMaSP.ValueMember = "MaSP";
                        cboMaSP.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message);
            }
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            if (maHD != 0)
            {
                MessageBox.Show(
                    "Hãy thanh toán hóa đơn hiện tại trước!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
INSERT INTO dbo.HOADON
(NgayTao, TinhTrangThanhToan)
OUTPUT INSERTED.MaHD
VALUES (CAST(GETDATE() AS DATE), 0);";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        maHD = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                txtMaHD.Text = maHD.ToString();
                LoadSanPham();
                MoNhapLieu();

                MessageBox.Show("Tạo hóa đơn thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (maHD == 0)
            {
                MessageBox.Show("Chưa tạo hóa đơn!");
                return;
            }

            if (cboMaSP.SelectedValue == null ||
                cboMaSP.SelectedValue is DataRowView)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong)
                || soLuong <= 0)
            {
                MessageBox.Show(
                    "Số lượng phải là số nguyên lớn hơn 0!");
                return;
            }

            int maSP = Convert.ToInt32(cboMaSP.SelectedValue);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlTransaction tran =
                        conn.BeginTransaction(IsolationLevel.Serializable))
                    {
                        try
                        {
                            string sqlHD = @"
SELECT TinhTrangThanhToan
FROM dbo.HOADON WITH (UPDLOCK, HOLDLOCK)
WHERE MaHD = @MaHD;";

                            using (SqlCommand cmd =
                                new SqlCommand(sqlHD, conn, tran))
                            {
                                cmd.Parameters.Add("@MaHD",
                                    SqlDbType.Int).Value = maHD;

                                object trangThai = cmd.ExecuteScalar();

                                if (trangThai == null ||
                                    Convert.ToInt32(trangThai) != 0)
                                {
                                    throw new Exception(
                                        "Hóa đơn không tồn tại hoặc đã thanh toán!");
                                }
                            }

                            string sqlKiemTra = @"
SELECT COUNT(*)
FROM dbo.CHITIET_HOADON
WHERE MaHD = @MaHD AND MaSP = @MaSP;";

                            using (SqlCommand cmd =
                                new SqlCommand(sqlKiemTra, conn, tran))
                            {
                                cmd.Parameters.Add("@MaHD",
                                    SqlDbType.Int).Value = maHD;
                                cmd.Parameters.Add("@MaSP",
                                    SqlDbType.Int).Value = maSP;

                                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                                {
                                    throw new Exception(
                                        "Sản phẩm đã có trong hóa đơn!");
                                }
                            }

                            string sqlTon = @"
UPDATE dbo.TONKHO
SET SLBan = SLBan + @SoLuong
WHERE MaSP = @MaSP
  AND NgayTon = CAST(GETDATE() AS DATE)
  AND SLDau + SLNhap - SLBan >= @SoLuong;";

                            using (SqlCommand cmd =
                                new SqlCommand(sqlTon, conn, tran))
                            {
                                cmd.Parameters.Add("@MaSP",
                                    SqlDbType.Int).Value = maSP;
                                cmd.Parameters.Add("@SoLuong",
                                    SqlDbType.Int).Value = soLuong;

                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    throw new Exception(
                                        "Chưa tạo tồn kho hôm nay hoặc số lượng không đủ!");
                                }
                            }

                            string sqlThem = @"
INSERT INTO dbo.CHITIET_HOADON
(MaHD, MaSP, SoLuong)
VALUES (@MaHD, @MaSP, @SoLuong);";

                            using (SqlCommand cmd =
                                new SqlCommand(sqlThem, conn, tran))
                            {
                                cmd.Parameters.Add("@MaHD",
                                    SqlDbType.Int).Value = maHD;
                                cmd.Parameters.Add("@MaSP",
                                    SqlDbType.Int).Value = maSP;
                                cmd.Parameters.Add("@SoLuong",
                                    SqlDbType.Int).Value = soLuong;

                                cmd.ExecuteNonQuery();
                            }

                            tran.Commit();

                            MessageBox.Show(
                                "Thêm chi tiết hóa đơn thành công!");

                            cboMaSP.SelectedIndex = -1;
                            txtSoLuong.Clear();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            cboMaSP.SelectedIndex = -1;
            txtSoLuong.Clear();
            cboMaSP.Focus();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (maHD == 0)
            {
                MessageBox.Show("Chưa có hóa đơn!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
UPDATE dbo.HOADON
SET TinhTrangThanhToan = 1
WHERE MaHD = @MaHD
  AND TinhTrangThanhToan = 0
  AND EXISTS
  (
      SELECT 1 FROM dbo.CHITIET_HOADON
      WHERE MaHD = @MaHD
  );";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaHD",
                            SqlDbType.Int).Value = maHD;

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Thanh toán thành công!");

                            maHD = 0;
                            txtMaHD.Clear();
                            cboMaSP.SelectedIndex = -1;
                            txtSoLuong.Clear();
                            KhoaNhapLieu();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Hóa đơn chưa có sản phẩm hoặc đã thanh toán!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
