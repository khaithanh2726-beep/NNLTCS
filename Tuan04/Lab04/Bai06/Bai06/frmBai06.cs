using System;
using System.Windows.Forms;

namespace Bai06;

public partial class frmBai06 : Form
{
    public frmBai06()
    {
        InitializeComponent();

        rdoBacNhat.Checked = true;

        txtA.Focus();
    }

    private void rdoBacNhat_CheckedChanged(
        object? sender,
        EventArgs e)
    {
        if (rdoBacNhat.Checked)
        {
            txtC.Enabled = false;
            lblC.Enabled = false;

            txtC.Clear();

            btnGiai.Enabled = KiemTraInput();
        }
    }

    private void rdoBacHai_CheckedChanged(
        object? sender,
        EventArgs e)
    {
        if (rdoBacHai.Checked)
        {
            txtC.Enabled = true;
            lblC.Enabled = true;

            btnGiai.Enabled = KiemTraInput();
        }
    }

    private bool KiemTraInput()
    {
        errorProvider1.SetError(txtA, "");
        errorProvider1.SetError(txtB, "");
        errorProvider1.SetError(txtC, "");

        bool hopLe = true;

        if (!double.TryParse(txtA.Text, out _))
        {
            errorProvider1.SetError(
                txtA,
                "a phải là số.");

            hopLe = false;
        }

        if (!double.TryParse(txtB.Text, out _))
        {
            errorProvider1.SetError(
                txtB,
                "b phải là số.");

            hopLe = false;
        }

        if (rdoBacHai.Checked &&
            !double.TryParse(txtC.Text, out _))
        {
            errorProvider1.SetError(
                txtC,
                "c phải là số.");

            hopLe = false;
        }

        return hopLe;
    }

    private void btnGiai_Click(
        object? sender,
        EventArgs e)
    {
        if (!KiemTraInput())
        {
            MessageBox.Show(
                "Vui lòng nhập đầy đủ dữ liệu!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        double a = double.Parse(txtA.Text);
        double b = double.Parse(txtB.Text);

        if (rdoBacNhat.Checked)
        {
            PhuongTrinhBacHai pt =
                new PhuongTrinhBacHai(a, b, 0);

            txtKetQua.Text = pt.GiaiBacNhat();
        }
        else
        {
            double c = double.Parse(txtC.Text);

            if (a == 0)
            {
                MessageBox.Show(
                    "Hệ số a phải khác 0 đối với phương trình bậc hai.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            PhuongTrinhBacHai pt =
                new PhuongTrinhBacHai(a, b, c);

            txtKetQua.Text = pt.GiaiBacHai();
        }

        btnGiai.Enabled = false;
    }

    private void btnXoa_Click(
        object? sender,
        EventArgs e)
    {
        txtA.Clear();
        txtB.Clear();
        txtC.Clear();
        txtKetQua.Clear();

        errorProvider1.SetError(txtA, "");
        errorProvider1.SetError(txtB, "");
        errorProvider1.SetError(txtC, "");

        btnGiai.Enabled = false;

        txtA.Focus();
    }

    private void btnThoat_Click(
        object? sender,
        EventArgs e)
    {
        Close();
    }

    private void txtSo_KeyPress(
        object? sender,
        KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) &&
            e.KeyChar != '-' &&
            e.KeyChar != '.' &&
            e.KeyChar != ',' &&
            e.KeyChar != '\b')
        {
            e.Handled = true;
        }

        if (sender is TextBox textBox)
        {
            if (e.KeyChar == '-' &&
                textBox.SelectionStart != 0)
            {
                e.Handled = true;
            }
        }

        btnGiai.Enabled = KiemTraInput();
    }

    private void frmBai06_FormClosing(
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