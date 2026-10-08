using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaiThucHanhForm
{
    public partial class frmBaiTapVeNha : Form
    {
        // Các biến lưu trữ toán hạng và phép toán
        private double memory = 0;
        private string operation = "";
        private bool isOperationPerformed = false;

        private Label lblTitle;
        private TextBox txtDisplay;
        private Panel panelKeypad;

        public frmBaiTapVeNha()
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.lblTitle = new Label();
            this.txtDisplay = new TextBox();
            this.panelKeypad = new Panel();

            this.SuspendLayout();

            // Form Settings
            this.Text = "Máy Tính Bỏ Túi";
            this.Size = new Size(330, 380);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += new FormClosingEventHandler(this.frmBaiTapVeNha_FormClosing);

            // Title
            this.lblTitle.Text = "Máy Tính Bỏ Túi";
            this.lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Red;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(70, 15);

            // Màn hình hiển thị kết quả (TextBox)
            this.txtDisplay.Location = new Point(25, 55);
            this.txtDisplay.Size = new Size(260, 35);
            this.txtDisplay.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.txtDisplay.TextAlign = HorizontalAlignment.Right;
            this.txtDisplay.ReadOnly = true;
            this.txtDisplay.Text = "0";

            // Panel chứa các nút bấm
            this.panelKeypad.Location = new Point(25, 100);
            this.panelKeypad.Size = new Size(260, 210);

            // Mảng bố trí nút theo hình minh họa trong đề:
            // Row 1: 1, 2, 3, 4
            // Row 2: 5, 6, 7, 8
            // Row 3: 9, 0, =, C
            // Row 4: +, -, *, /
            string[,] buttonTexts = new string[,]
            {
                { "1", "2", "3", "4" },
                { "5", "6", "7", "8" },
                { "9", "0", "=", "C" },
                { "+", "-", "*", "/" }
            };

            int btnWidth = 55;
            int btnHeight = 45;
            int gap = 10;

            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    Button btn = new Button();
                    btn.Text = buttonTexts[r, c];
                    btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    btn.Size = new Size(btnWidth, btnHeight);
                    btn.Location = new Point(c * (btnWidth + gap), r * (btnHeight + gap));

                    // Gán sự kiện cho từng loại nút
                    string txt = btn.Text;
                    if ("0123456789".Contains(txt))
                    {
                        btn.Click += new EventHandler(this.NumButton_Click);
                    }
                    else if ("+-*/".Contains(txt))
                    {
                        btn.Click += new EventHandler(this.OperatorButton_Click);
                    }
                    else if (txt == "=")
                    {
                        btn.Click += new EventHandler(this.EqualsButton_Click);
                    }
                    else if (txt == "C")
                    {
                        btn.Click += new EventHandler(this.ClearButton_Click);
                    }

                    this.panelKeypad.Controls.Add(btn);
                }
            }

            // Controls Add
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.panelKeypad);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Click phím số (0 - 9)
        private void NumButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (txtDisplay.Text == "0" || isOperationPerformed)
            {
                txtDisplay.Text = "";
            }

            isOperationPerformed = false;
            txtDisplay.Text += btn.Text;
        }

        // Click phím phép toán (+, -, *, /)
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (memory != 0)
            {
                EqualsButton_Click(sender, e);
            }

            operation = btn.Text;
            memory = Convert.ToDouble(txtDisplay.Text);
            isOperationPerformed = true;
        }

        // Click phím Bằng (=)
        private void EqualsButton_Click(object sender, EventArgs e)
        {
            double secondNum = Convert.ToDouble(txtDisplay.Text);
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = memory + secondNum;
                    break;
                case "-":
                    result = memory - secondNum;
                    break;
                case "*":
                    result = memory * secondNum;
                    break;
                case "/":
                    if (secondNum != 0)
                    {
                        result = memory / secondNum;
                    }
                    else
                    {
                        MessageBox.Show("Không thể chia cho 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearButton_Click(sender, e);
                        return;
                    }
                    break;
                default:
                    return;
            }

            txtDisplay.Text = result.ToString();
            memory = result;
            operation = "";
            isOperationPerformed = true;
        }

        // Click phím Xóa (C)
        private void ClearButton_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            memory = 0;
            operation = "";
            isOperationPerformed = false;
        }

        private void frmBaiTapVeNha_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}