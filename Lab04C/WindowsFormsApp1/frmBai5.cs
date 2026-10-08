using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaiThucHanhForm
{
    public partial class frmBai5 : Form
    {
        // Khai báo Controls
        private Label lblTitle;
        private Label lblNhapSo;
        private Label lblKetQua;

        private TextBox txtNhapSo;
        private Button btnThucHien;
        private Button btnXoa;
        private Button btnThoat;

        private ErrorProvider errorProvider1;

        public frmBai5()
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.lblTitle = new Label();
            this.lblNhapSo = new Label();
            this.lblKetQua = new Label();

            this.txtNhapSo = new TextBox();
            this.btnThucHien = new Button();
            this.btnXoa = new Button();
            this.btnThoat = new Button();

            this.errorProvider1 = new ErrorProvider();

            this.SuspendLayout();

            // Form Settings
            this.Text = "Tâm Gà - Đọc Chữ Số";
            this.Size = new Size(380, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += new FormClosingEventHandler(this.frmBai5_FormClosing);

            // Title
            this.lblTitle.Text = "Đọc Số Thành Chữ";
            this.lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Red;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(85, 15);

            // Nhập dãy số
            this.lblNhapSo.Text = "Nhập dãy số : (từ 1 đến 999)";
            this.lblNhapSo.Location = new Point(25, 60);
            this.lblNhapSo.AutoSize = true;

            this.txtNhapSo.Location = new Point(200, 57);
            this.txtNhapSo.Size = new Size(130, 20);

            // Buttons
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.Location = new Point(30, 95);
            this.btnThucHien.Size = new Size(90, 30);
            this.btnThucHien.Click += new EventHandler(this.btnThucHien_Click);

            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new Point(135, 95);
            this.btnXoa.Size = new Size(90, 30);
            this.btnXoa.Click += new EventHandler(this.btnXoa_Click);

            this.btnThoat.Text = "Thoát";
            this.btnThoat.Location = new Point(240, 95);
            this.btnThoat.Size = new Size(90, 30);
            this.btnThoat.Click += new EventHandler(this.btnThoat_Click);

            // Label Kết quả đọc số
            this.lblKetQua.Text = "";
            this.lblKetQua.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblKetQua.ForeColor = Color.DarkMagenta;
            this.lblKetQua.BackColor = Color.Bisque;
            this.lblKetQua.Location = new Point(30, 145);
            this.lblKetQua.Size = new Size(300, 35);
            this.lblKetQua.TextAlign = ContentAlignment.MiddleCenter;

            this.AcceptButton = this.btnThucHien;

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblNhapSo);
            this.Controls.Add(this.txtNhapSo);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lblKetQua);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // --- HÀM THUẬT TOÁN ĐỌC SỐ TỪ 1 ĐẾN 999 ---
        private string DocSoThanhChu(int n)
        {
            string[] chuSo = { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };

            int tram = n / 100;
            int chuc = (n % 100) / 10;
            int donVi = n % 10;

            string ketQua = "";

            // Xử lý Hàng Trăm
            if (tram > 0)
            {
                ketQua += chuSo[tram] + " Trăm ";
            }

            // Xử lý Hàng Chục
            if (chuc > 1)
            {
                ketQua += chuSo[chuc] + " Mươi ";
            }
            else if (chuc == 1)
            {
                ketQua += "Mười ";
            }
            else if (tram > 0 && donVi > 0)
            {
                ketQua += "Lẻ ";
            }

            // Xử lý Hàng Đơn Vị
            if (donVi > 0)
            {
                if (donVi == 1 && chuc > 1)
                    ketQua += "Mốt";
                else if (donVi == 5 && chuc > 0)
                    ketQua += "Lăm";
                else
                    ketQua += chuSo[donVi];
            }

            return ketQua.Trim();
        }

        // Button Thực Hiện
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            int number;

            if (!int.TryParse(txtNhapSo.Text, out number) || number < 1 || number > 999)
            {
                errorProvider1.SetError(txtNhapSo, "Chỉ nhập số nguyên từ 1 đến 999!");
                MessageBox.Show("Vui lòng nhập số trong khoảng từ 1 đến 999!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapSo.Focus();
                return;
            }

            lblKetQua.Text = DocSoThanhChu(number);
        }

        // Button Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtNhapSo.Clear();
            lblKetQua.Text = "";
            errorProvider1.Clear();
            txtNhapSo.Focus();
        }

        // Button Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBai5_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}