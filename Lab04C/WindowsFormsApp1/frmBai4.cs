using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BaiThucHanhForm
{
    public partial class frmBai4 : Form
    {
        // Khai báo danh sách lưu dãy số nguyên
        private List<int> daySo = new List<int>();

        // Khai báo Controls
        private Label lblTitle;
        private Label lblNhapSo;
        private Label lblDayNhap;
        private Label lblTongDay;
        private Label lblTongChan;
        private Label lblTongLe;

        private TextBox txtNhapSo;
        private TextBox txtDayNhap;
        private TextBox txtTongDay;
        private TextBox txtTongChan;
        private TextBox txtTongLe;

        private Button btnNhap;
        private Button btnTiepTuc;
        private Button btnThoat;

        private ErrorProvider errorProvider1;

        public frmBai4()
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.lblTitle = new Label();
            this.lblNhapSo = new Label();
            this.lblDayNhap = new Label();
            this.lblTongDay = new Label();
            this.lblTongChan = new Label();
            this.lblTongLe = new Label();

            this.txtNhapSo = new TextBox();
            this.txtDayNhap = new TextBox();
            this.txtTongDay = new TextBox();
            this.txtTongChan = new TextBox();
            this.txtTongLe = new TextBox();

            this.btnNhap = new Button();
            this.btnTiepTuc = new Button();
            this.btnThoat = new Button();

            this.errorProvider1 = new ErrorProvider();

            this.SuspendLayout();

            // Form Settings
            this.Text = "Dãy số và Tính Tổng";
            this.Size = new Size(380, 310);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += new FormClosingEventHandler(this.frmBai4_FormClosing);

            // Title
            this.lblTitle.Text = "Nhập Dãy Số và Tính Tổng";
            this.lblTitle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Red;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(60, 15);

            // Nhập số
            this.lblNhapSo.Text = "Nhập số :";
            this.lblNhapSo.Location = new Point(30, 55);
            this.lblNhapSo.AutoSize = true;

            this.txtNhapSo.Location = new Point(160, 52);
            this.txtNhapSo.Size = new Size(90, 20);

            this.btnNhap.Text = "Nhập";
            this.btnNhap.Location = new Point(260, 50);
            this.btnNhap.Size = new Size(75, 25);
            this.btnNhap.Click += new EventHandler(this.btnNhap_Click);

            // Dãy vừa nhập
            this.lblDayNhap.Text = "Dãy vừa nhập :";
            this.lblDayNhap.Location = new Point(30, 90);
            this.lblDayNhap.AutoSize = true;

            this.txtDayNhap.Location = new Point(160, 87);
            this.txtDayNhap.Size = new Size(175, 20);
            this.txtDayNhap.ReadOnly = true;

            // Tổng các phần tử trong dãy
            this.lblTongDay.Text = "Tổng các phần tử trong dãy :";
            this.lblTongDay.Location = new Point(30, 125);
            this.lblTongDay.AutoSize = true;

            this.txtTongDay.Location = new Point(230, 122);
            this.txtTongDay.Size = new Size(105, 20);
            this.txtTongDay.ReadOnly = true;

            // Tổng Chẵn
            this.lblTongChan.Text = "Tổng Chẵn :";
            this.lblTongChan.Location = new Point(30, 160);
            this.lblTongChan.AutoSize = true;

            this.txtTongChan.Location = new Point(100, 157);
            this.txtTongChan.Size = new Size(60, 20);
            this.txtTongChan.ReadOnly = true;

            // Tổng Lẻ
            this.lblTongLe.Text = "Tổng Lẻ :";
            this.lblTongLe.Location = new Point(180, 160);
            this.lblTongLe.AutoSize = true;

            this.txtTongLe.Location = new Point(235, 157);
            this.txtTongLe.Size = new Size(100, 20);
            this.txtTongLe.ReadOnly = true;

            // Buttons Tiếp tục & Thoát
            this.btnTiepTuc.Text = "Tiếp Tục";
            this.btnTiepTuc.Location = new Point(80, 210);
            this.btnTiepTuc.Size = new Size(90, 30);
            this.btnTiepTuc.Click += new EventHandler(this.btnTiepTuc_Click);

            this.btnThoat.Text = "Thoát";
            this.btnThoat.Location = new Point(200, 210);
            this.btnThoat.Size = new Size(90, 30);
            this.btnThoat.Click += new EventHandler(this.btnThoat_Click);

            // Gán phím Enter cho nút Nhập
            this.AcceptButton = this.btnNhap;

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblNhapSo);
            this.Controls.Add(this.txtNhapSo);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.lblDayNhap);
            this.Controls.Add(this.txtDayNhap);
            this.Controls.Add(this.lblTongDay);
            this.Controls.Add(this.txtTongDay);
            this.Controls.Add(this.lblTongChan);
            this.Controls.Add(this.txtTongChan);
            this.Controls.Add(this.lblTongLe);
            this.Controls.Add(this.txtTongLe);
            this.Controls.Add(this.btnTiepTuc);
            this.Controls.Add(this.btnThoat);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Xử lý nút Nhập (Thêm số vào dãy & tính tổng ngay)
        private void btnNhap_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            int n;

            if (!int.TryParse(txtNhapSo.Text, out n))
            {
                errorProvider1.SetError(txtNhapSo, "Vui lòng nhập một số nguyên!");
                MessageBox.Show("Giá trị nhập vào phải là số nguyên!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapSo.Focus();
                return;
            }

            // Thêm vào danh sách
            daySo.Add(n);

            // Cập nhật TextBox Dãy vừa nhập
            txtDayNhap.Text = string.Join("  ", daySo);

            // Tính tổng
            int tongDay = 0;
            int tongChan = 0;
            int tongLe = 0;

            foreach (int item in daySo)
            {
                tongDay += item;
                if (item % 2 == 0)
                    tongChan += item;
                else
                    tongLe += item;
            }

            // Hiển thị kết quả
            txtTongDay.Text = tongDay.ToString();
            txtTongChan.Text = tongChan.ToString();
            txtTongLe.Text = tongLe.ToString();

            // Reset ô nhập để nhập số tiếp theo
            txtNhapSo.Clear();
            txtNhapSo.Focus();
        }

        // Xử lý nút Tiếp Tục (Làm mới trạng thái ban đầu)
        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            daySo.Clear();
            txtNhapSo.Clear();
            txtDayNhap.Clear();
            txtTongDay.Clear();
            txtTongChan.Clear();
            txtTongLe.Clear();
            errorProvider1.Clear();
            txtNhapSo.Focus();
        }

        // Xử lý nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBai4_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}