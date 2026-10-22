using System;
using System.Windows.Forms;

namespace bai02_BTTL
{
    public partial class Form1 : Form
    {
        private TreeNode rootNode;

        public Form1()
        {
            InitializeComponent();
        }

        // 1. Khi Form hiện lên: Khởi tạo danh sách lớp và ẩn GroupBox Thêm lớp
        private void Form1_Load(object sender, EventArgs e)
        {
            // Cấu trúc cây: Node gốc "Danh sách lớp"
            rootNode = new TreeNode("Danh sách lớp");
            tvLop.Nodes.Add(rootNode);

            string[] dsLopBanDau = { "05DHTH1", "05DHTH2", "05DHTH3", "05DHTH4" };
            foreach (string lop in dsLopBanDau)
            {
                // Thêm vào TreeView (dưới node Danh sách lớp)
                TreeNode nodeLop = new TreeNode(lop);
                rootNode.Nodes.Add(nodeLop);

                // Thêm vào ComboBox
                cboLop.Items.Add(lop);
            }

            rootNode.Expand(); // Mở rộng danh sách lớp
            if (cboLop.Items.Count > 0)
            {
                cboLop.SelectedIndex = 0;
            }

            // Ẩn groupbox Thêm lớp ban đầu
            chkThemLop.Checked = false;
            grpThemLop.Visible = false;
        }

        // 2. CheckBox Thêm lớp thay đổi trạng thái (ẩn/hiện groupbox Thêm lớp)
        private void chkThemLop_CheckedChanged(object sender, EventArgs e)
        {
            grpThemLop.Visible = chkThemLop.Checked;
            if (chkThemLop.Checked)
            {
                txtTenLop.Focus();
            }
        }

        // 3. Button Thêm lớp: Thêm lớp mới vào TreeView và ComboBox (không trùng lặp)
        private void btnThemLop_Click(object sender, EventArgs e)
        {
            string tenLopMoi = txtTenLop.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenLopMoi))
            {
                MessageBox.Show("Vui lòng nhập tên lớp cần thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return;
            }

            // Kiểm tra trùng tên lớp trong TreeView / ComboBox
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (string.Equals(node.Text.Trim(), tenLopMoi, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Tên lớp này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenLop.SelectAll();
                    txtTenLop.Focus();
                    return;
                }
            }

            // Thêm node lớp vào TreeView
            TreeNode newNode = new TreeNode(tenLopMoi);
            rootNode.Nodes.Add(newNode);
            rootNode.Expand();

            // Thêm vào ComboBox và chọn lớp vừa thêm
            cboLop.Items.Add(tenLopMoi);
            cboLop.SelectedItem = tenLopMoi;

            txtTenLop.Clear();
            MessageBox.Show("Thêm lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Hàm kiểm tra trùng mã sinh viên trên toàn bộ các lớp trong TreeView
        private bool KiemTraTrungMaSV(string maSV)
        {
            foreach (TreeNode nodeLop in rootNode.Nodes)
            {
                foreach (TreeNode nodeSV in nodeLop.Nodes)
                {
                    // Lấy mã SV từ chuỗi "MãSV, HọTên"
                    string[] parts = nodeSV.Text.Split(',');
                    if (parts.Length > 0 && parts[0].Trim().Equals(maSV, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // 4. Button Cập Nhật: Thêm sinh viên vào lớp đang chọn
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn lớp để thêm sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            // Kiểm tra các ô nhập không được để trống
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Mã SV, Họ Tên và Địa Chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng mã sinh viên
            if (KiemTraTrungMaSV(maSV))
            {
                MessageBox.Show("Mã sinh viên này đã tồn tại trong hệ thống!", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSV.SelectAll();
                txtMaSV.Focus();
                return;
            }

            // Tìm node lớp tương ứng trên TreeView
            string lopDangChon = cboLop.SelectedItem.ToString();
            TreeNode targetLopNode = null;
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (node.Text == lopDangChon)
                {
                    targetLopNode = node;
                    break;
                }
            }

            if (targetLopNode != null)
            {
                // Tạo node sinh viên: "MãSV, HọTên"
                TreeNode svNode = new TreeNode($"{maSV}, {hoTen}");

                // Tạo node con chứa địa chỉ
                TreeNode diaChiNode = new TreeNode(diaChi);
                svNode.Nodes.Add(diaChiNode);

                // Thêm vào node lớp và mở rộng
                targetLopNode.Nodes.Add(svNode);
                targetLopNode.Expand();
                svNode.Expand();

                // Dọn ô nhập
                txtMaSV.Clear();
                txtHoTen.Clear();
                txtDiaChi.Clear();
                txtMaSV.Focus();

                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 5. Click chọn node trên TreeView: Đổ dữ liệu lên TextBox nếu là node sinh viên
        private void tvLop_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selected = e.Node;

            // Kiểm tra nếu node được chọn là node sinh viên (cha của nó là một lớp, tức nằm dưới root 2 cấp)
            if (selected != null && selected.Parent != null && selected.Parent != rootNode)
            {
                // Nếu người dùng chọn trúng node địa chỉ (node con nhất) -> lấy node cha là node SV
                TreeNode svNode = (selected.Nodes.Count == 0 && selected.Parent.Parent != null && selected.Parent.Parent != rootNode)
                    ? selected.Parent
                    : selected;

                string[] parts = svNode.Text.Split(',');
                if (parts.Length >= 2)
                {
                    txtMaSV.Text = parts[0].Trim();
                    txtHoTen.Text = parts[1].Trim();
                }

                // Địa chỉ nằm ở node con đầu tiên
                if (svNode.Nodes.Count > 0)
                {
                    txtDiaChi.Text = svNode.Nodes[0].Text.Trim();
                }

                // Đồng bộ lớp lên ComboBox
                if (svNode.Parent != null)
                {
                    cboLop.SelectedItem = svNode.Parent.Text;
                }
            }
        }

        // 6. Button Xóa: Chỉ cho phép xóa node sinh viên đang chọn (kèm xác nhận)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            TreeNode selected = tvLop.SelectedNode;

            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa trên TreeView!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra node có phải là sinh viên không (phải có cha là một lớp học)
            TreeNode svNode = null;
            if (selected.Parent != null && selected.Parent != rootNode)
            {
                svNode = (selected.Nodes.Count == 0 && selected.Parent.Parent != null && selected.Parent.Parent != rootNode)
                    ? selected.Parent
                    : selected;
            }

            if (svNode == null)
            {
                MessageBox.Show("Chỉ được phép xóa một node sinh viên!", "Lỗi thao tác", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sinh viên [{svNode.Text}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                svNode.Remove();

                // Xóa trắng form nhập
                txtMaSV.Clear();
                txtHoTen.Clear();
                txtDiaChi.Clear();

                MessageBox.Show("Đã xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}