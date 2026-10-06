using System;
using System.Windows.Forms;

namespace Bai03;

public partial class frmBai03 : Form
{
    public frmBai03()
    {
        InitializeComponent();

        txtA.Focus();
    }

    private bool LayHaiSo(out int a, out int b)
    {
        a = 0;
        b = 0;

        bool hopLe = true;

        errorProvider1.SetError(txtA, "");
        errorProvider1.SetError(txtB, "");

        if (!int.TryParse(txtA.Text, out a))
        {
            errorProvider1.SetError(
                txtA,
                "Vui lòng nhập số nguyên hợp lệ.");

            hopLe = false;
        }

        if (!int.TryParse(txtB.Text, out b))
        {
            errorProvider1.SetError(
                txtB,
                "Vui lòng nhập số nguyên hợp lệ.");

            hopLe = false;
        }

        return hopLe;
    }

    private int UCLN(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            int temp = a % b;
            a = b;
            b = temp;
        }

        return a;
    }

    private long BCNN(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        if (a == 0 || b == 0)
        {
            return 0;
        }

        return (long)a / UCLN(a, b) * b;
    }

    private void btnTinh_Click(object? sender, EventArgs e)
    {
        if (!LayHaiSo(out int a, out int b))
        {
            MessageBox.Show(
                "Dữ liệu nhập vào không hợp lệ!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (a == 0 && b == 0)
        {
            MessageBox.Show(
                "Không thể xác định UCLN của 0 và 0!",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        int ucln = UCLN(a, b);
        long bcnn = BCNN(a, b);

        txtUCLN.Text = ucln.ToString();
        txtBCNN.Text = bcnn.ToString();
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        txtA.Clear();
        txtB.Clear();
        txtUCLN.Clear();
        txtBCNN.Clear();

        errorProvider1.SetError(txtA, "");
        errorProvider1.SetError(txtB, "");

        txtA.Focus();
    }

    private void btnThoat_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void frmBai03_FormClosing(
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