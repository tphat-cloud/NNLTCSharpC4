using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaiThucHanhForm
{
    public partial class frmBai1 : Form
    {
        // Khai báo các Control trực tiếp trong code để không bị lỗi Missing Control
        private Label lblA;
        private Label lblB;
        private Label lblKetQua;
        private TextBox txtA;
        private TextBox txtB;
        private TextBox txtKetQua;
        private Button btnCong;
        private Button btnTru;
        private Button btnNhan;
        private Button btnChia;
        private ErrorProvider errorProvider1;

        public frmBai1()
        {
            InitializeComponentCustom();
        }

        // Tự động tạo giao diện bằng code thuần (Không lo bị lỗi Designer)
        private void InitializeComponentCustom()
        {
            this.lblA = new Label();
            this.lblB = new Label();
            this.lblKetQua = new Label();
            this.txtA = new TextBox();
            this.txtB = new TextBox();
            this.txtKetQua = new TextBox();
            this.btnCong = new Button();
            this.btnTru = new Button();
            this.btnNhan = new Button();
            this.btnChia = new Button();
            this.errorProvider1 = new ErrorProvider();

            this.SuspendLayout();

            // Form
            this.Text = "Cộng trừ nhân chia";
            this.Size = new Size(350, 220);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += new FormClosingEventHandler(this.frmBai1_FormClosing);

            // lblA
            this.lblA.Text = "a =";
            this.lblA.Location = new Point(30, 20);
            this.lblA.AutoSize = true;

            // txtA
            this.txtA.Location = new Point(65, 17);
            this.txtA.Size = new Size(80, 20);
            this.txtA.KeyPress += new KeyPressEventHandler(this.txtA_KeyPress);

            // lblB
            this.lblB.Text = "b =";
            this.lblB.Location = new Point(170, 20);
            this.lblB.AutoSize = true;

            // txtB
            this.txtB.Location = new Point(200, 17);
            this.txtB.Size = new Size(80, 20);
            this.txtB.KeyPress += new KeyPressEventHandler(this.txtB_KeyPress);

            // lblKetQua
            this.lblKetQua.Text = "Kết quả";
            this.lblKetQua.Location = new Point(30, 60);
            this.lblKetQua.AutoSize = true;

            // txtKetQua
            this.txtKetQua.Location = new Point(90, 57);
            this.txtKetQua.Size = new Size(190, 20);
            this.txtKetQua.ReadOnly = true;

            // btnCong (+)
            this.btnCong.Text = "+";
            this.btnCong.Location = new Point(30, 100);
            this.btnCong.Size = new Size(50, 30);
            this.btnCong.Click += new EventHandler(this.btnCong_Click);

            // btnTru (-)
            this.btnTru.Text = "-";
            this.btnTru.Location = new Point(95, 100);
            this.btnTru.Size = new Size(50, 30);
            this.btnTru.Click += new EventHandler(this.btnTru_Click);

            // btnNhan (*)
            this.btnNhan.Text = "x";
            this.btnNhan.Location = new Point(160, 100);
            this.btnNhan.Size = new Size(50, 30);
            this.btnNhan.Click += new EventHandler(this.btnNhan_Click);

            // btnChia (/)
            this.btnChia.Text = "/";
            this.btnChia.Location = new Point(225, 100);
            this.btnChia.Size = new Size(50, 30);
            this.btnChia.Click += new EventHandler(this.btnChia_Click);

            // Controls Add
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.btnCong);
            this.Controls.Add(this.btnTru);
            this.Controls.Add(this.btnNhan);
            this.Controls.Add(this.btnChia);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // --- XỬ LÝ LOGIC KIỂM TRA DỮ LIỆU ---
        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập số!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng chỉ nhập số!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool KiemTraHopLe()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtA.Text))
            {
                errorProvider1.SetError(txtA, "Vui lòng nhập giá trị a!");
                isValid = false;
            }
            else errorProvider1.SetError(txtA, "");

            if (string.IsNullOrWhiteSpace(txtB.Text))
            {
                errorProvider1.SetError(txtB, "Vui lòng nhập giá trị b!");
                isValid = false;
            }
            else errorProvider1.SetError(txtB, "");

            return isValid;
        }

        // --- CÁC PHÉP TÍNH ---
        private void btnCong_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;
            double a = Convert.ToDouble(txtA.Text);
            double b = Convert.ToDouble(txtB.Text);
            txtKetQua.Text = (a + b).ToString();
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;
            double a = Convert.ToDouble(txtA.Text);
            double b = Convert.ToDouble(txtB.Text);
            txtKetQua.Text = (a - b).ToString();
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;
            double a = Convert.ToDouble(txtA.Text);
            double b = Convert.ToDouble(txtB.Text);
            txtKetQua.Text = (a * b).ToString();
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;
            double a = Convert.ToDouble(txtA.Text);
            double b = Convert.ToDouble(txtB.Text);
            if (b == 0)
            {
                MessageBox.Show("Không thể chia cho 0!", "Lỗi toán học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtKetQua.Text = (a / b).ToString();
        }

        private void frmBai1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}