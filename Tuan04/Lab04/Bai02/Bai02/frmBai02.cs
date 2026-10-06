using System;
using System.Windows.Forms;

namespace Bai02;

public partial class frmBai02 : Form
{
    public frmBai02()
    {
        InitializeComponent();

        txtHoTen.Focus();
    }

    private bool KiemTraEmail(string email)
    {
        return email.Contains("@") &&
               email.Contains(".");
    }

    private bool KiemTraDuLieu()
    {
        bool hopLe = true;

        errorProvider1.SetError(txtHoTen, "");
        errorProvider1.SetError(txtTaiKhoan, "");
        errorProvider1.SetError(txtEmail, "");
        errorProvider1.SetError(txtMatKhau, "");
        errorProvider1.SetError(txtXacNhan, "");

        // Họ tên
        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        {
            errorProvider1.SetError(
                txtHoTen,
                "Họ tên không được để trống.");

            hopLe = false;
        }

        // Tên đăng nhập
        if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
        {
            errorProvider1.SetError(
                txtTaiKhoan,
                "Tên đăng nhập không được để trống.");

            hopLe = false;
        }

        // Email
        if (string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            errorProvider1.SetError(
                txtEmail,
                "Email không được để trống.");

            hopLe = false;
        }
        else if (!KiemTraEmail(txtEmail.Text))
        {
            errorProvider1.SetError(
                txtEmail,
                "Email không đúng định dạng.");

            hopLe = false;
        }

        // Mật khẩu
        if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
        {
            errorProvider1.SetError(
                txtMatKhau,
                "Mật khẩu không được để trống.");

            hopLe = false;
        }

        // Xác nhận mật khẩu
        if (string.IsNullOrWhiteSpace(txtXacNhan.Text))
        {
            errorProvider1.SetError(
                txtXacNhan,
                "Vui lòng xác nhận mật khẩu.");

            hopLe = false;
        }
        else if (txtMatKhau.Text != txtXacNhan.Text)
        {
            errorProvider1.SetError(
                txtXacNhan,
                "Mật khẩu xác nhận không khớp.");

            hopLe = false;
        }

        return hopLe;
    }

    private void txtEmail_Leave(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            errorProvider1.SetError(
                txtEmail,
                "Email không được để trống.");
        }
        else if (!KiemTraEmail(txtEmail.Text))
        {
            errorProvider1.SetError(
                txtEmail,
                "Email không đúng định dạng.");
        }
        else
        {
            errorProvider1.SetError(txtEmail, "");
        }
    }

    private void btnDangKy_Click(object? sender, EventArgs e)
    {
        if (!KiemTraDuLieu())
        {
            MessageBox.Show(
                "Vui lòng kiểm tra lại dữ liệu!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        string thongTin =
            "Họ tên: " + txtHoTen.Text + "\n" +
            "Tên đăng nhập: " + txtTaiKhoan.Text + "\n" +
            "Email: " + txtEmail.Text + "\n" +
            "Mật khẩu: " + txtMatKhau.Text + "\n" +
            "Xác nhận mật khẩu: " + txtXacNhan.Text;

        MessageBox.Show(
            thongTin,
            "Thông tin đăng ký",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void btnThoat_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void frmBai02_FormClosing(
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