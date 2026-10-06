using System;
using System.Windows.Forms;

namespace Bai05;

public partial class frmBai05 : Form
{
    public frmBai05()
    {
        InitializeComponent();

        txtSo.Focus();
    }

    private void txtSo_KeyPress(
        object? sender,
        KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) &&
            e.KeyChar != '\b')
        {
            e.Handled = true;
        }
    }

    private string DocHangDonVi(int so)
    {
        string[] chuSo =
        {
            "không",
            "một",
            "hai",
            "ba",
            "bốn",
            "năm",
            "sáu",
            "bảy",
            "tám",
            "chín"
        };

        return chuSo[so];
    }

    private string DocSoHaiChuSo(int so)
    {
        int hangChuc = so / 10;
        int hangDonVi = so % 10;

        if (hangChuc == 0)
        {
            return DocHangDonVi(hangDonVi);
        }

        if (hangChuc == 1)
        {
            if (hangDonVi == 0)
            {
                return "mười";
            }

            if (hangDonVi == 5)
            {
                return "mười lăm";
            }

            return "mười " + DocHangDonVi(hangDonVi);
        }

        string ketQua =
            DocHangDonVi(hangChuc) + " mươi";

        if (hangDonVi == 0)
        {
            return ketQua;
        }

        if (hangDonVi == 1)
        {
            return ketQua + " mốt";
        }

        if (hangDonVi == 5)
        {
            return ketQua + " lăm";
        }

        return ketQua + " " +
               DocHangDonVi(hangDonVi);
    }

    private string DocSo(int so)
    {
        if (so < 1 || so > 999)
        {
            return "";
        }

        int hangTram = so / 100;
        int haiChuSo = so % 100;

        // Số từ 1 đến 99
        if (hangTram == 0)
        {
            return DocSoHaiChuSo(so);
        }

        string ketQua =
            DocHangDonVi(hangTram) + " trăm";

        // Ví dụ 100
        if (haiChuSo == 0)
        {
            return ketQua;
        }

        // Ví dụ 105
        if (haiChuSo < 10)
        {
            return ketQua +
                   " lẻ " +
                   DocHangDonVi(haiChuSo);
        }

        return ketQua +
               " " +
               DocSoHaiChuSo(haiChuSo);
    }

    private void btnThucHien_Click(
        object? sender,
        EventArgs e)
    {
        errorProvider1.SetError(txtSo, "");

        if (!int.TryParse(txtSo.Text, out int so))
        {
            errorProvider1.SetError(
                txtSo,
                "Vui lòng nhập một số nguyên.");

            MessageBox.Show(
                "Dữ liệu không hợp lệ!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtSo.Focus();

            return;
        }

        if (so < 1 || so > 999)
        {
            errorProvider1.SetError(
                txtSo,
                "Chỉ được nhập số từ 1 đến 999.");

            MessageBox.Show(
                "Số phải nằm trong khoảng từ 1 đến 999!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtSo.Focus();

            return;
        }

        txtKetQua.Text = DocSo(so);
    }

    private void btnXoa_Click(
        object? sender,
        EventArgs e)
    {
        txtSo.Clear();
        txtKetQua.Clear();

        errorProvider1.SetError(txtSo, "");

        txtSo.Focus();
    }

    private void btnThoat_Click(
        object? sender,
        EventArgs e)
    {
        Close();
    }

    private void frmBai05_FormClosing(
        object? sender,
        FormClosingEventArgs e)
    {
        DialogResult result = MessageBox.Show(
            "Bạn có chắc muốn thoát không?",
            "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.No)
        {
            e.Cancel = true;
        }
    }
}