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

        // =========================
        // SỰ KIỆN LOAD FORM
        // =========================
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadMonHoc();
            HienThiDiem(null);
        }

        // =========================
        // LOAD COMBOBOX MÔN HỌC
        // =========================
        private void LoadMonHoc()
        {
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "SELECT MaMH, TenMH " +
                        "FROM dbo.MonHoc_DiemLV " +
                        "ORDER BY MaMH";

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Thêm dòng trống để xem tất cả
                        DataRow row = dt.NewRow();
                        row["MaMH"] = "";
                        row["TenMH"] = "";
                        dt.Rows.InsertAt(row, 0);

                        cboMonHoc.DataSource = dt;
                        cboMonHoc.DisplayMember = "MaMH";
                        cboMonHoc.ValueMember = "MaMH";

                        cboMonHoc.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải môn học: " + ex.Message);
            }
        }

        // =========================
        // HIỂN THỊ ĐIỂM LÊN LISTVIEW
        // =========================
        private void HienThiDiem(string maMH)
        {
            try
            {
                lvDiem.Items.Clear();

                double tongDiem = 0;
                int stt = 1;

                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql =
                        "SELECT sv.HoTen, sv.NgaySinh, " +
                        "mh.TenMH, d.Diem " +
                        "FROM dbo.Diem_ListView d " +
                        "INNER JOIN dbo.SinhVien_DiemLV sv " +
                        "ON d.MaSV = sv.MaSV " +
                        "INNER JOIN dbo.MonHoc_DiemLV mh " +
                        "ON d.MaMH = mh.MaMH " +
                        "WHERE (@MaMH IS NULL OR d.MaMH = @MaMH) " +
                        "ORDER BY sv.MaSV, mh.MaMH";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(
                            "@MaMH", SqlDbType.NVarChar, 20)
                            .Value = string.IsNullOrEmpty(maMH)
                                ? (object)DBNull.Value
                                : maMH;

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListViewItem item =
                                    new ListViewItem(stt.ToString());

                                item.SubItems.Add(
                                    reader["HoTen"].ToString());

                                DateTime ngaySinh =
                                    Convert.ToDateTime(
                                        reader["NgaySinh"]);

                                item.SubItems.Add(
                                    ngaySinh.ToString("dd/MM/yyyy"));

                                item.SubItems.Add(
                                    reader["TenMH"].ToString());
                                double diem =
                                    Convert.ToDouble(reader["Diem"]);

                                item.SubItems.Add(
                                    diem.ToString(
                                        CultureInfo.InvariantCulture));

                                lvDiem.Items.Add(item);

                                tongDiem += diem;
                                stt++;
                            }
                        }
                    }
                }

                txtTongDiem.Text =
                    tongDiem.ToString(
                        CultureInfo.InvariantCulture);
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
        // NÚT LỌC DỮ LIỆU
        // =========================
        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (cboMonHoc.SelectedValue == null)
            {
                HienThiDiem(null);
                return;
            }

            string maMH =
                cboMonHoc.SelectedValue.ToString();

            if (string.IsNullOrWhiteSpace(maMH))
            {
                // Hiển thị tất cả môn học
                HienThiDiem(null);
            }
            else
            {
                // Lọc theo môn học được chọn
                HienThiDiem(maMH);
            }
        }
    }
}
