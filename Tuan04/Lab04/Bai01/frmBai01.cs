using System;
using System.Windows.Forms;

namespace Bai01;

public partial class frmBai01 : Form
{
    public frmBai01()
    {
        InitializeComponent();

        txtA.Focus();
    }

    private bool LayHaiSo(out double a, out double b)
    {
        a = 0;
        b = 0;

        bool hopLe = true;

        errorProvider1.SetError(txtA, "");
        errorProvider1.SetError(txtB, "");

        if (!double.TryParse(txtA.Text, out a))
        {
            errorProvider1.SetError(
                txtA,
                "Vui lòng nhập số hợp lệ cho a."
            );

            hopLe = false;
        }

        if (!double.TryParse(txtB.Text, out b))
        {
            errorProvider1.SetError(
                txtB,
                "Vui lòng nhập số hợp lệ cho b."
            );

            hopLe = false;
        }

        return hopLe;
    }

    private void txtA_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) &&
            e.KeyChar != '-' &&
            e.KeyChar != '.' &&
            e.KeyChar != ',' &&
            e.KeyChar != '\b')
        {
            e.Handled = true;
        }
    }

    private void txtB_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) &&
            e.KeyChar != '-' &&
            e.KeyChar != '.' &&
            e.KeyChar != ',' &&
            e.KeyChar != '\b')
        {
            e.Handled = true;
        }
    }

    private void txtA_Leave(object? sender, EventArgs e)
    {
        if (!double.TryParse(txtA.Text, out _))
        {
            errorProvider1.SetError(
                txtA,
                "Vui lòng nhập số hợp lệ."
            );
        }
        else
        {
            errorProvider1.SetError(txtA, "");
        }
    }

    private void txtB_Leave(object? sender, EventArgs e)
    {
        if (!double.TryParse(txtB.Text, out _))
        {
            errorProvider1.SetError(
                txtB,
                "Vui lòng nhập số hợp lệ."
            );
        }
        else
        {
            errorProvider1.SetError(txtB, "");
        }
    }

    private void btnCong_Click(object? sender, EventArgs e)
    {
        if (!LayHaiSo(out double a, out double b))
        {
            MessageBox.Show(
                "Vui lòng nhập a và b hợp lệ!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return;
        }

        TinhToan dt = new TinhToan(a, b);

        txtKetQua.Text = dt.Cong().ToString();
    }

    private void btnTru_Click(object? sender, EventArgs e)
    {
        if (!LayHaiSo(out double a, out double b))
        {
            MessageBox.Show(
                "Vui lòng nhập a và b hợp lệ!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return;
        }

        TinhToan dt = new TinhToan(a, b);

        txtKetQua.Text = dt.Tru().ToString();
    }

    private void btnNhan_Click(object? sender, EventArgs e)
    {
        if (!LayHaiSo(out double a, out double b))
        {
            MessageBox.Show(
                "Vui lòng nhập a và b hợp lệ!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return;
        }

        TinhToan dt = new TinhToan(a, b);

        txtKetQua.Text = dt.Nhan().ToString();
    }

    private void btnChia_Click(object? sender, EventArgs e)
    {
        if (!LayHaiSo(out double a, out double b))
        {
            MessageBox.Show(
                "Vui lòng nhập a và b hợp lệ!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return;
        }

        if (b == 0)
        {
            MessageBox.Show(
                "Không thể chia cho 0!",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            return;
        }

        TinhToan dt = new TinhToan(a, b);

        txtKetQua.Text = dt.Chia().ToString();
    }

    private void frmBai01_FormClosing(
        object? sender,
        FormClosingEventArgs e)
    {
        DialogResult result = MessageBox.Show(
            "Bạn có chắc muốn thoát không?",
            "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (result == DialogResult.No)
        {
            e.Cancel = true;
        }
    }
}