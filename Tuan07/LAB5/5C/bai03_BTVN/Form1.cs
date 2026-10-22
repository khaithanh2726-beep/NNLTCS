using System;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace bai03_BTVN
{
    public partial class Form1 : Form
    {
        private ImageList imageListIcons;

        public Form1()
        {
            InitializeComponent();
        }

        // Tạo icon thư mục/người trực tiếp bằng code để gán vào TreeView
        private void KhoiTaoImageList()
        {
            imageListIcons = new ImageList();
            imageListIcons.ImageSize = new Size(16, 16);

            // Icon 0: Folder (đại diện cho chữ cái nhóm danh bạ)
            Bitmap bmpFolder = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmpFolder))
            {
                g.Clear(Color.Transparent);
                g.FillRectangle(Brushes.Goldenrod, 1, 3, 14, 11);
                g.FillRectangle(Brushes.DarkGoldenrod, 1, 1, 7, 3);
            }

            // Icon 1: Person (đại diện cho liên hệ người dùng)
            Bitmap bmpPerson = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmpPerson))
            {
                g.Clear(Color.Transparent);
                g.FillEllipse(Brushes.Peru, 4, 1, 8, 8);
                g.FillPie(Brushes.Peru, 1, 8, 14, 12, 180, 180);
            }

            imageListIcons.Images.Add("folder", bmpFolder);
            imageListIcons.Images.Add("person", bmpPerson);

            tvDanhBa.ImageList = imageListIcons;
        }

        // 1. Khi form được load: Nạp tất cả các ký tự từ A -> Z vào TreeView
        private void Form1_Load(object sender, EventArgs e)
        {
            KhoiTaoImageList();
            tvDanhBa.Nodes.Clear();

            for (char c = 'A'; c <= 'Z'; c++)
            {
                TreeNode node = new TreeNode(c.ToString());
                node.Name = c.ToString(); // Đặt Name để dễ tìm kiếm bằng Find
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
                tvDanhBa.Nodes.Add(node);
            }

            // Thêm dữ liệu mẫu ban đầu theo đúng hình minh họa (B -> Bình, Ngô Thanh)
            ThemDanhBa("Bình", "Ngô Thanh");
        }

        // Hàm chuẩn hóa loại bỏ dấu tiếng Việt để lấy ký tự chữ cái đầu chuẩn tiếng Anh (VD: Á -> A, Đ -> D)
        private string BoDauTiengViet(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            string normalized = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char ch in normalized)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC).Replace('đ', 'd').Replace('Đ', 'D');
        }

        // Hàm phụ hỗ trợ thêm liên hệ vào đúng nhánh chữ cái
        private void ThemDanhBa(string firstName, string lastName)
        {
            string tenKhongDau = BoDauTiengViet(firstName);
            char kyTuDau = char.ToUpper(tenKhongDau[0]);

            TreeNode[] matchingNodes = tvDanhBa.Nodes.Find(kyTuDau.ToString(), false);
            if (matchingNodes.Length > 0)
            {
                TreeNode parentNode = matchingNodes[0];

                // Định dạng hiển thị theo đề: "FirstName, LastName"
                TreeNode personNode = new TreeNode($"{firstName}, {lastName}");
                personNode.ImageIndex = 1;
                personNode.SelectedImageIndex = 1;

                parentNode.Nodes.Add(personNode);
                parentNode.Expand();
                tvDanhBa.SelectedNode = personNode;
            }
        }

        // 2. Nút "Add": Thêm liên hệ vào node chữ cái đầu của First Name
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            // Kiểm tra tính hợp lệ
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ First Name và Last Name!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (string.IsNullOrWhiteSpace(firstName)) txtFirstName.Focus();
                else txtLastName.Focus();
                return;
            }

            string tenKhongDau = BoDauTiengViet(firstName);
            char kyTuDau = char.ToUpper(tenKhongDau[0]);

            if (kyTuDau < 'A' || kyTuDau > 'Z')
            {
                MessageBox.Show("First Name phải bắt đầu bằng chữ cái hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.SelectAll();
                txtFirstName.Focus();
                return;
            }

            ThemDanhBa(firstName, lastName);

            // Xóa rỗng form và đặt lại con trỏ chuột
            txtFirstName.Clear();
            txtLastName.Clear();
            txtFirstName.Focus();
        }

        // 3. Nút "Exit": Thoát ứng dụng
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có muốn thoát chương trình?",
                "Xác nhận",
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