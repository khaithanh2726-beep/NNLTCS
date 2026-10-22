using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bai01_BTVN
{
    public partial class Form1 : Form
    {
        // Lớp đối tượng lưu trữ từ và nghĩa
        public class TuDienItem
        {
            public string Tu { get; set; }
            public string Nghia { get; set; }

            public TuDienItem(string tu, string nghia)
            {
                Tu = tu;
                Nghia = nghia;
            }

            public override string ToString()
            {
                return Tu;
            }
        }

        // Danh sách lưu trữ bằng List theo đúng yêu cầu đề bài
        private List<TuDienItem> dsAnhViet = new List<TuDienItem>();
        private List<TuDienItem> dsVietAnh = new List<TuDienItem>();

        public Form1()
        {
            InitializeComponent();
        }

        // 1. Khởi tạo dữ liệu từ điển ban đầu
        private void Form1_Load(object sender, EventArgs e)
        {
            // Dữ liệu mẫu Anh - Việt theo hình ảnh minh họa
            dsAnhViet.Add(new TuDienItem("student", "Sinh viên, học sinh"));
            dsAnhViet.Add(new TuDienItem("teacher", "Giáo viên, giảng viên"));
            dsAnhViet.Add(new TuDienItem("worker", "Công nhân, người lao động"));
            dsAnhViet.Add(new TuDienItem("hat", "Cái mũ, cái nón"));
            dsAnhViet.Add(new TuDienItem("head", "Cái đầu, người đứng đầu"));
            dsAnhViet.Add(new TuDienItem("mouse", "Con chuột, chuột máy tính"));
            dsAnhViet.Add(new TuDienItem("cat", "Con mèo"));
            dsAnhViet.Add(new TuDienItem("dog", "Con chó"));
            dsAnhViet.Add(new TuDienItem("snake", "Con rắn"));
            dsAnhViet.Add(new TuDienItem("lumb", "Khối, tảng, cục"));
            dsAnhViet.Add(new TuDienItem("loan", "Khoản vay, tiền vay"));
            dsAnhViet.Add(new TuDienItem("frog", "Con ếch"));
            dsAnhViet.Add(new TuDienItem("sheep", "Con cừu"));

            // Dữ liệu mẫu Việt - Anh tương ứng
            dsVietAnh.Add(new TuDienItem("sinh viên", "student"));
            dsVietAnh.Add(new TuDienItem("giáo viên", "teacher"));
            dsVietAnh.Add(new TuDienItem("công nhân", "worker"));
            dsVietAnh.Add(new TuDienItem("cái mũ", "hat"));
            dsVietAnh.Add(new TuDienItem("cái đầu", "head"));
            dsVietAnh.Add(new TuDienItem("con chuột", "mouse"));
            dsVietAnh.Add(new TuDienItem("con mèo", "cat"));
            dsVietAnh.Add(new TuDienItem("con chó", "dog"));
            dsVietAnh.Add(new TuDienItem("con rắn", "snake"));
            dsVietAnh.Add(new TuDienItem("khoản vay", "loan"));
            dsVietAnh.Add(new TuDienItem("con ếch", "frog"));
            dsVietAnh.Add(new TuDienItem("con cừu", "sheep"));

            // Nạp dữ liệu lên Tab Anh - Việt
            foreach (var item in dsAnhViet)
            {
                cboTuAV.Items.Add(item.Tu);
                lstTuAV.Items.Add(item.Tu);
            }

            // Nạp dữ liệu lên Tab Việt - Anh
            foreach (var item in dsVietAnh)
            {
                cboTuVA.Items.Add(item.Tu);
                lstTuVA.Items.Add(item.Tu);
            }

            // Chọn mặc định mục đầu tiên
            if (lstTuAV.Items.Count > 0)
            {
                lstTuAV.SelectedIndex = 0;
            }
        }

        // ================= XỬ LÝ TAB ANH - VIỆT =================

        private void TraTuAnhViet(string tuCanTra)
        {
            if (string.IsNullOrWhiteSpace(tuCanTra)) return;

            tuCanTra = tuCanTra.Trim().ToLower();

            // Tìm trong List
            TuDienItem item = dsAnhViet.Find(x => x.Tu.ToLower() == tuCanTra);
            if (item != null)
            {
                txtNghiaAV.Text = item.Nghia;
                cboTuAV.Text = item.Tu;
                lstTuAV.SelectedItem = item.Tu;
            }
            else
            {
                txtNghiaAV.Text = "Không tìm thấy từ này trong từ điển!";
            }
        }

        // Nhấn Enter trên ComboBox Anh - Việt
        private void cboTuAV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TraTuAnhViet(cboTuAV.Text);
                e.Handled = true;
                e.SuppressKeyPress = true; // Ngăn tiếng bip mặc định của Windows
            }
        }

        // Chọn hoặc Double click trên ListBox Anh - Việt
        private void lstTuAV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTuAV.SelectedItem != null)
            {
                TraTuAnhViet(lstTuAV.SelectedItem.ToString());
            }
        }

        private void lstTuAV_DoubleClick(object sender, EventArgs e)
        {
            if (lstTuAV.SelectedItem != null)
            {
                TraTuAnhViet(lstTuAV.SelectedItem.ToString());
            }
        }

        // ================= XỬ LÝ TAB VIỆT - ANH =================

        private void TraTuVietAnh(string tuCanTra)
        {
            if (string.IsNullOrWhiteSpace(tuCanTra)) return;

            tuCanTra = tuCanTra.Trim().ToLower();

            TuDienItem item = dsVietAnh.Find(x => x.Tu.ToLower() == tuCanTra);
            if (item != null)
            {
                txtNghiaVA.Text = item.Nghia;
                cboTuVA.Text = item.Tu;
                lstTuVA.SelectedItem = item.Tu;
            }
            else
            {
                txtNghiaVA.Text = "Không tìm thấy từ này trong từ điển!";
            }
        }

        // Nhấn Enter trên ComboBox Việt - Anh
        private void cboTuVA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TraTuVietAnh(cboTuVA.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Chọn hoặc Double click trên ListBox Việt - Anh
        private void lstTuVA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTuVA.SelectedItem != null)
            {
                TraTuVietAnh(lstTuVA.SelectedItem.ToString());
            }
        }

        private void lstTuVA_DoubleClick(object sender, EventArgs e)
        {
            if (lstTuVA.SelectedItem != null)
            {
                TraTuVietAnh(lstTuVA.SelectedItem.ToString());
            }
        }

        // ========== NÚT THOÁT =============
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}