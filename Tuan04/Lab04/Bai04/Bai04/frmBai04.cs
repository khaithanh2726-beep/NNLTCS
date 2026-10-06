using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bai04;

public partial class frmBai04 : Form
{
    private readonly List<int> danhSach = new();

    public frmBai04()
    {
        InitializeComponent();

        txtNhapSo.Focus();
    }

    private void txtNhapSo_KeyPress(
        object? sender,
        KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) &&
            e.KeyChar != '-' &&
            e.KeyChar != '\b')
        {
            e.Handled = true;
        }

        // Chỉ cho phép dấu - ở đầu số
        if (e.KeyChar == '-' &&
            txtNhapSo.SelectionStart != 0)
        {
            e.Handled = true;
        }
    }

    private void btnNhap_Click(
        object? sender,
        EventArgs e)
    {
        errorProvider1.SetError(txtNhapSo, "");

        if (!int.TryParse(txtNhapSo.Text, out int so))
        {
            errorProvider1.SetError(
                txtNhapSo,
                "Vui lòng nhập một số nguyên hợp lệ.");

            MessageBox.Show(
                "Dữ liệu nhập không hợp lệ!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtNhapSo.Focus();

            return;
        }

        danhSach.Add(so);

        CapNhatDaySo();

        txtNhapSo.Clear();
        txtNhapSo.Focus();
    }

    private void CapNhatDaySo()
    {
        txtDayVuaNhap.Text = string.Join(
            "   ",
            danhSach);
    }

    private void btnTinhTong_Click(
        object? sender,
        EventArgs e)
    {
        if (danhSach.Count == 0)
        {
            MessageBox.Show(
                "Chưa có số nào trong dãy!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        int tong = danhSach.Sum();

        txtTong.Text = tong.ToString();
    }

    private void btnTongChan_Click(
        object? sender,
        EventArgs e)
    {
        if (danhSach.Count == 0)
        {
            MessageBox.Show(
                "Chưa có số nào trong dãy!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        int tongChan = danhSach
            .Where(x => x % 2 == 0)
            .Sum();

        txtTongChan.Text = tongChan.ToString();
    }

    private void btnTongLe_Click(
        object? sender,
        EventArgs e)
    {
        if (danhSach.Count == 0)
        {
            MessageBox.Show(
                "Chưa có số nào trong dãy!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        int tongLe = danhSach
            .Where(x => x % 2 != 0)
            .Sum();

        txtTongLe.Text = tongLe.ToString();
    }

    private void btnTiepTuc_Click(
        object? sender,
        EventArgs e)
    {
        danhSach.Clear();

        txtNhapSo.Clear();
        txtDayVuaNhap.Clear();
        txtTong.Clear();
        txtTongChan.Clear();
        txtTongLe.Clear();

        errorProvider1.SetError(txtNhapSo, "");

        txtNhapSo.Focus();
    }

    private void btnThoat_Click(
        object? sender,
        EventArgs e)
    {
        Close();
    }

    private void frmBai04_FormClosing(
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