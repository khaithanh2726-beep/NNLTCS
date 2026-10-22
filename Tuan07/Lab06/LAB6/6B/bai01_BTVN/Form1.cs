using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace bai01_BTVN
{
    public partial class Form1 : Form
    {
        private readonly string connectionString =
            @"Server=.\SQLEXPRESS;Database=QLCuaHang;Integrated Security=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnTaoTonKho_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
INSERT INTO dbo.TONKHO
(MaSP, NgayTon, SLDau, SLNhap, SLBan)
SELECT
    sp.MaSP,
    CAST(GETDATE() AS DATE),
    ISNULL(t.SLDau + t.SLNhap - t.SLBan, 0),
    0,
    0
FROM dbo.SANPHAM sp
OUTER APPLY
(
    SELECT TOP 1 SLDau, SLNhap, SLBan
    FROM dbo.TONKHO
    WHERE MaSP = sp.MaSP
      AND NgayTon < CAST(GETDATE() AS DATE)
    ORDER BY NgayTon DESC
) t
WHERE NOT EXISTS
(
    SELECT 1 FROM dbo.TONKHO tk
    WHERE tk.MaSP = sp.MaSP
      AND tk.NgayTon = CAST(GETDATE() AS DATE)
);";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        int ketQua = cmd.ExecuteNonQuery();

                        MessageBox.Show(
                            "Tạo tồn kho thành công!\nSố dòng mới: " + ketQua);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            using (frmSanPham f = new frmSanPham())
            {
                f.ShowDialog();
            }
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            using (frmBanHang f = new frmBanHang())
            {
                f.ShowDialog();
            }
        }
    }
}
