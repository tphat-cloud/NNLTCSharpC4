using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaiThucHanhForm
{
    public partial class frmBai3 : Form
    {
        // Khai báo các Control
        private Label lblTitle;
        private Label lblSoA;
        private Label lblSoB;
        private Label lblUCLN;
        private Label lblBCNN;

        private TextBox txtSoA;
        private TextBox txtSoB;
        private TextBox txtUCLN;
        private TextBox txtBCNN;

        private Button btnThucHien;
        private Button btnTiepTuc;
        private Button btnThoat;

        private ErrorProvider errorProvider1;

        public frmBai3()
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.lblTitle = new Label();
            this.lblSoA = new Label();
            this.lblSoB = new Label();
            this.lblUCLN = new Label();
            this.lblBCNN = new Label();

            this.txtSoA = new TextBox();
            this.txtSoB = new TextBox();
            this.txtUCLN = new TextBox();
            this.txtBCNN = new TextBox();

            this.btnThucHien = new Button();
            this.btnTiepTuc = new Button();
            this.btnThoat = new Button();

            this.errorProvider1 = new ErrorProvider();

            this.SuspendLayout();

            // Form Settings
            this.Text = "Ước Số - Bội Số";
            this.Size = new Size(380, 280);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += new FormClosingEventHandler(this.frmBai3_FormClosing);

            // Title
            this.lblTitle.Text = "Ước Số Chung - Bội Số Chung";
            this.lblTitle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Red;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(40, 15);

            // Nhập số a
            this.lblSoA.Text = "Nhập số a :";
            this.lblSoA.Location = new Point(40, 55);
            this.lblSoA.AutoSize = true;

            this.txtSoA.Location = new Point(180, 52);
            this.txtSoA.Size = new Size(130, 20);

            // Nhập số b
            this.lblSoB.Text = "Nhập số b :";
            this.lblSoB.Location = new Point(40, 85);
            this.lblSoB.AutoSize = true;

            this.txtSoB.Location = new Point(180, 82);
            this.txtSoB.Size = new Size(130, 20);

            // Ước số chung lớn nhất
            this.lblUCLN.Text = "Ước số chung lớn nhất :";
            this.lblUCLN.Location = new Point(40, 115);
            this.lblUCLN.AutoSize = true;

            this.txtUCLN.Location = new Point(180, 112);
            this.txtUCLN.Size = new Size(130, 20);
            this.txtUCLN.ReadOnly = true;

            // Bội số chung nhỏ nhất
            this.lblBCNN.Text = "Bội số chung nhỏ nhất :";
            this.lblBCNN.Location = new Point(40, 145);
            this.lblBCNN.AutoSize = true;

            this.txtBCNN.Location = new Point(180, 142);
            this.txtBCNN.Size = new Size(130, 20);
            this.txtBCNN.ReadOnly = true;

            // Buttons
            this.btnThucHien.Text = "Thực Hiện";
            this.btnThucHien.Location = new Point(30, 185);
            this.btnThucHien.Size = new Size(95, 30);
            this.btnThucHien.Click += new EventHandler(this.btnThucHien_Click);

            this.btnTiepTuc.Text = "Tiếp Tục";
            this.btnTiepTuc.Location = new Point(135, 185);
            this.btnTiepTuc.Size = new Size(95, 30);
            this.btnTiepTuc.Click += new EventHandler(this.btnTiepTuc_Click);

            this.btnThoat.Text = "Thoát";
            this.btnThoat.Location = new Point(240, 185);
            this.btnThoat.Size = new Size(95, 30);
            this.btnThoat.Click += new EventHandler(this.btnThoat_Click);

            // Controls Add
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSoA);
            this.Controls.Add(this.txtSoA);
            this.Controls.Add(this.lblSoB);
            this.Controls.Add(this.txtSoB);
            this.Controls.Add(this.lblUCLN);
            this.Controls.Add(this.txtUCLN);
            this.Controls.Add(this.lblBCNN);
            this.Controls.Add(this.txtBCNN);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.btnTiepTuc);
            this.Controls.Add(this.btnThoat);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Hàm tính Ước Số Chung Lớn Nhất (Euclid)
        private long TinhUCLN(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Button Thực Hiện
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            long a, b;

            // Kiểm tra số a
            if (!long.TryParse(txtSoA.Text, out a) || a <= 0)
            {
                errorProvider1.SetError(txtSoA, "Vui lòng nhập số nguyên dương hợp lệ!");
                MessageBox.Show("Số a phải là số nguyên dương!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoA.Focus();
                return;
            }

            // Kiểm tra số b
            if (!long.TryParse(txtSoB.Text, out b) || b <= 0)
            {
                errorProvider1.SetError(txtSoB, "Vui lòng nhập số nguyên dương hợp lệ!");
                MessageBox.Show("Số b phải là số nguyên dương!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoB.Focus();
                return;
            }

            // Tính toán
            long ucln = TinhUCLN(a, b);
            long bcnn = (a * b) / ucln;

            txtUCLN.Text = ucln.ToString();
            txtBCNN.Text = bcnn.ToString();
        }

        // Button Tiếp Tục (Làm mới Form)
        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            txtSoA.Clear();
            txtSoB.Clear();
            txtUCLN.Clear();
            txtBCNN.Clear();
            errorProvider1.Clear();
            txtSoA.Focus();
        }

        // Button Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBai3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}