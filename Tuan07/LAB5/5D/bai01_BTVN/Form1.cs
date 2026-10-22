using System;
using System.Windows.Forms;

namespace bai01_BTVN
{
    public partial class Form1 : Form
    {
        // Thời gian đếm ngược tính bằng giây (30 phút = 1800 giây)
        private int tongSoGiay = 30 * 60;

        public Form1()
        {
            InitializeComponent();
        }

        // 1. Khởi tạo giao diện ban đầu
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiThoiGian();
        }

        // Hàm hỗ trợ quy đổi tổng số giây ra định dạng "mm:ss"
        private void HienThiThoiGian()
        {
            int phut = tongSoGiay / 60;
            int giay = tongSoGiay % 60;
            lblDongHo.Text = $"{phut:D2}:{giay:D2}";
        }

        // 2. Nút "Bắt đầu" / "Tạm dừng"
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (!timerDemNguoc.Enabled)
            {
                // Nếu hết thời gian mà nhấn lại thì reset về 30 phút
                if (tongSoGiay <= 0)
                {
                    tongSoGiay = 30 * 60;
                    HienThiThoiGian();
                }

                timerDemNguoc.Start();
                btnBatDau.Text = "Tạm dừng";
            }
            else
            {
                timerDemNguoc.Stop();
                btnBatDau.Text = "Tiếp tục";
            }
        }

        // 3. Sự kiện Tick của Timer (chạy mỗi 1000ms = 1 giây)
        private void timerDemNguoc_Tick(object sender, EventArgs e)
        {
            if (tongSoGiay > 0)
            {
                tongSoGiay--;
                HienThiThoiGian();
            }
            else
            {
                timerDemNguoc.Stop();
                btnBatDau.Text = "Bắt đầu";
                MessageBox.Show("Hết giờ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}