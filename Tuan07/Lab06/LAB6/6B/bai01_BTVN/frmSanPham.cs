using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace bai01_BTVN
{
    public partial class frmSanPham : Form
    {
        private readonly string connectionString =
            @"Server=.\SQLEXPRESS;Database=QLCuaHang;Integrated Security=True;TrustServerCertificate=True;";

        public frmSanPham()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenSP = txtTenSP.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenSP))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!");
                txtTenSP.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            string sqlSP = @"
INSERT INTO dbo.SANPHAM (TenSP)
OUTPUT INSERTED.MaSP
VALUES (@TenSP);";

                            int maSP;

                            using (SqlCommand cmd =
                                new SqlCommand(sqlSP, conn, tran))
                            {
                                cmd.Parameters.Add("@TenSP",
                                    SqlDbType.NVarChar, 100).Value = tenSP;

                                maSP = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            string sqlTon = @"
INSERT INTO dbo.TONKHO
(MaSP, NgayTon, SLDau, SLNhap, SLBan)
VALUES (@MaSP, CAST(GETDATE() AS DATE), 0, 0, 0);";

                            using (SqlCommand cmd =
                                new SqlCommand(sqlTon, conn, tran))
                            {
                                cmd.Parameters.Add("@MaSP",
                                    SqlDbType.Int).Value = maSP;

                                cmd.ExecuteNonQuery();
                            }

                            tran.Commit();

                            MessageBox.Show(
                                "Thêm sản phẩm thành công!\nMã SP: " + maSP);

                            txtTenSP.Clear();
                            txtTenSP.Focus();
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
