using System;
using System.Data;
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

        // =========================
        // HIỂN THỊ DANH SÁCH LỚP
        // =========================
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa dữ liệu cũ trên ListView
                lvLop.Items.Clear();

                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "SELECT MaLop, TenLop, MaKhoa " +
                        "FROM dbo.Lop_ListView " +
                        "ORDER BY MaLop";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            int stt = 1;

                            while (reader.Read())
                            {
                                // Tạo dòng mới
                                ListViewItem item =
                                    new ListViewItem(stt.ToString());

                                // Thêm Mã lớp
                                item.SubItems.Add(
                                    reader["MaLop"].ToString());

                                // Thêm Tên lớp
                                item.SubItems.Add(
                                    reader["TenLop"].ToString());

                                // Thêm Mã khoa
                                item.SubItems.Add(
                                    reader["MaKhoa"].ToString());

                                // Đưa dòng vào ListView
                                lvLop.Items.Add(item);

                                stt++;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Lỗi SQL: " + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi: " + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // CHỨC NĂNG THOÁT
        // =========================
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
