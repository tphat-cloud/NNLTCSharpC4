using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BaiThucHanhForm
{
    public partial class frmBai2 : Form
    {
        // Khai báo Controls
        private Label lblTitle;
        private Label lblTenDN;
        private Label lblEmail;
        private Label lblMatKhau;
        private Label lblXacNhanMK;
        private Label lblSao1, lblSao2, lblSao3;

        private TextBox txtTenDN;
        private TextBox txtEmail;
        private TextBox txtMatKhau;
        private TextBox txtXacNhanMK;

        private Button btnDangKy;
        private ErrorProvider errorProvider1;

        public frmBai2()
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.lblTitle = new Label();
            this.lblTenDN = new Label();
            this.lblEmail = new Label();
            this.lblMatKhau = new Label();
            this.lblXacNhanMK = new Label();
            this.lblSao1 = new Label();
            this.lblSao2 = new Label();
            this.lblSao3 = new Label();

            this.txtTenDN = new TextBox();
            this.txtEmail = new TextBox();
            this.txtMatKhau = new TextBox();
            this.txtXacNhanMK = new TextBox();

            this.btnDangKy = new Button();
            this.errorProvider1 = new ErrorProvider();

            this.SuspendLayout();

            // Form Settings
            this.Text = "Đăng ký tài khoản";
            this.Size = new Size(420, 320);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += new FormClosingEventHandler(this.frmBai2_FormClosing);

            // Title
            this.lblTitle.Text = "Đăng ký tài khoản";
            this.lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.DodgerBlue;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(120, 15);

            // Tên đăng nhập (*)
            this.lblTenDN.Text = "Tên đăng nhập";
            this.lblTenDN.Location = new Point(30, 60);
            this.lblTenDN.AutoSize = true;

            this.txtTenDN.Location = new Point(150, 57);
            this.txtTenDN.Size = new Size(180, 20);

            this.lblSao1.Text = "(*)";
            this.lblSao1.ForeColor = Color.Red;
            this.lblSao1.Location = new Point(335, 60);
            this.lblSao1.AutoSize = true;

            // Email (*)
            this.lblEmail.Text = "Địa chỉ email";
            this.lblEmail.Location = new Point(30, 95);
            this.lblEmail.AutoSize = true;

            this.txtEmail.Location = new Point(150, 92);
            this.txtEmail.Size = new Size(180, 20);
            this.txtEmail.Leave += new EventHandler(this.txtEmail_Leave);

            this.lblSao2.Text = "(*)";
            this.lblSao2.ForeColor = Color.Red;
            this.lblSao2.Location = new Point(335, 95);
            this.lblSao2.AutoSize = true;

            // Mật khẩu (*)
            this.lblMatKhau.Text = "Mật khẩu";
            this.lblMatKhau.Location = new Point(30, 130);
            this.lblMatKhau.AutoSize = true;

            this.txtMatKhau.Location = new Point(150, 127);
            this.txtMatKhau.Size = new Size(180, 20);
            this.txtMatKhau.PasswordChar = '*';

            this.lblSao3.Text = "(*)";
            this.lblSao3.ForeColor = Color.Red;
            this.lblSao3.Location = new Point(335, 130);
            this.lblSao3.AutoSize = true;

            // Xác nhận mật khẩu
            this.lblXacNhanMK.Text = "Xác nhận mật khẩu";
            this.lblXacNhanMK.Location = new Point(30, 165);
            this.lblXacNhanMK.AutoSize = true;

            this.txtXacNhanMK.Location = new Point(150, 162);
            this.txtXacNhanMK.Size = new Size(180, 20);
            this.txtXacNhanMK.PasswordChar = '*';
            this.txtXacNhanMK.KeyDown += new KeyEventHandler(this.txtXacNhanMK_KeyDown);

            // Button Đăng ký
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.Location = new Point(150, 210);
            this.btnDangKy.Size = new Size(180, 35);
            this.btnDangKy.Click += new EventHandler(this.btnDangKy_Click);

            // Gán Enter Key cho Button
            this.AcceptButton = this.btnDangKy;

            // Thêm các controls vào Form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTenDN);
            this.Controls.Add(this.txtTenDN);
            this.Controls.Add(this.lblSao1);

            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblSao2);

            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblSao3);

            this.Controls.Add(this.lblXacNhanMK);
            this.Controls.Add(this.txtXacNhanMK);

            this.Controls.Add(this.btnDangKy);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // 1. Kiểm tra định dạng Email khi rời khỏi TextBox
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                errorProvider1.SetError(txtEmail, "Định dạng Email không hợp lệ (Ví dụ: abc@gmail.com)!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }

        // 2. Xử lý Đăng ký
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Bắt buộc nhập các ô có (*)
            if (string.IsNullOrWhiteSpace(txtTenDN.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDN.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Địa chỉ Email không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            // Kiểm tra mật khẩu xác nhận
            if (txtMatKhau.Text != txtXacNhanMK.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMK.Focus();
                return;
            }

            // Hiển thị thông tin lên MessageBox
            string thongTin = $"ĐĂNG KÝ THÀNH CÔNG!\n\n" +
                              $"Tên đăng nhập: {txtTenDN.Text}\n" +
                              $"Email: {txtEmail.Text}\n" +
                              $"Mật khẩu: {txtMatKhau.Text}";

            MessageBox.Show(thongTin, "Thông tin đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nhấn Enter ở ô Xác nhận mật khẩu để Đăng ký
        private void txtXacNhanMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangKy_Click(sender, e);
            }
        }

        // Hỏi khi đóng Form
        private void frmBai2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}