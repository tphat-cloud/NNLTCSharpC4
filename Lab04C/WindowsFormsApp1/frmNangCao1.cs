using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BaiThucHanhForm
{
    public partial class frmNangCao1 : Form
    {
        // Danh sách lưu 15 nút ghế
        private Button[] gheButtons = new Button[15];

        // Mảng định nghĩa trạng thái ghế: 0: Trống (Trắng), 1: Đang chọn (Xanh), 2: Đã bán (Vàng)
        private int[] trangThaiGhe = new int[15];

        // Mảng giá vé tương ứng cho 15 ghế
        // Ghế 1-5 (Lô A: 1000), Ghế 6-10 (Lô B: 1500), Ghế 11-15 (Lô C: 2000)
        private int[] giaVe = new int[15]
        {
            1000, 1000, 1000, 1000, 1000,
            1500, 1500, 1500, 1500, 1500,
            2000, 2000, 2000, 2000, 2000
        };

        private Label lblTitle;
        private Label lblThanhTienText;
        private TextBox txtThanhTien;
        private Button btnChon;
        private Button btnHuyBo;
        private Button btnKetThuc;

        public frmNangCao1()
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.lblTitle = new Label();
            this.lblThanhTienText = new Label();
            this.txtThanhTien = new TextBox();
            this.btnChon = new Button();
            this.btnHuyBo = new Button();
            this.btnKetThuc = new Button();

            this.SuspendLayout();

            // Form Settings
            this.Text = "BÁN VÉ RẠP CHIẾU BÓNG";
            this.Size = new Size(380, 420);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += new FormClosingEventHandler(this.frmNangCao1_FormClosing);

            // MÀN ẢNH Title
            this.lblTitle.Text = "MÀN ẢNH";
            this.lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.OrangeRed;
            this.lblTitle.AutoSize = false;
            this.lblTitle.Size = new Size(320, 35);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new Point(15, 10);
            this.lblTitle.BorderStyle = BorderStyle.FixedSingle;

            // Tạo sơ đồ 15 ghế (3 hàng x 5 cột)
            int xStart = 20;
            int yStart = 60;
            int btnWidth = 55;
            int btnHeight = 45;
            int gap = 10;

            for (int i = 0; i < 15; i++)
            {
                int row = i / 5;
                int col = i % 5;

                gheButtons[i] = new Button();
                gheButtons[i].Text = (i + 1).ToString();
                gheButtons[i].Font = new Font("Segoe UI", 11, FontStyle.Bold);
                gheButtons[i].Size = new Size(btnWidth, btnHeight);
                gheButtons[i].Location = new Point(xStart + col * (btnWidth + gap), yStart + row * (btnHeight + gap));
                gheButtons[i].BackColor = Color.White; // Mặc định màu trắng
                gheButtons[i].Tag = i; // Lưu chỉ số ghế

                // Gán sự kiện click ghế
                gheButtons[i].Click += new EventHandler(this.Ghe_Click);

                this.Controls.Add(gheButtons[i]);
            }

            // Label Thành Tiền
            this.lblThanhTienText.Text = "Thành Tiền:";
            this.lblThanhTienText.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.lblThanhTienText.Location = new Point(20, 240);
            this.lblThanhTienText.AutoSize = true;

            // TextBox Thành Tiền
            this.txtThanhTien.Location = new Point(110, 237);
            this.txtThanhTien.Size = new Size(225, 25);
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Text = "0";

            // Buttons Chức Năng
            this.btnChon.Text = "Chọn";
            this.btnChon.Location = new Point(20, 290);
            this.btnChon.Size = new Size(90, 35);
            this.btnChon.Click += new EventHandler(this.btnChon_Click);

            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Location = new Point(130, 290);
            this.btnHuyBo.Size = new Size(90, 35);
            this.btnHuyBo.Click += new EventHandler(this.btnHuyBo_Click);

            this.btnKetThuc.Text = "Kết thúc";
            this.btnKetThuc.Location = new Point(240, 290);
            this.btnKetThuc.Size = new Size(95, 35);
            this.btnKetThuc.Click += new EventHandler(this.btnKetThuc_Click);

            // Add Controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblThanhTienText);
            this.Controls.Add(this.txtThanhTien);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.btnHuyBo);
            this.Controls.Add(this.btnKetThuc);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Sự kiện Click chọn/bỏ chọn ghế
        private void Ghe_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = (int)btn.Tag;

            // Nếu ghế đã bán (màu vàng) -> Thông báo
            if (trangThaiGhe[index] == 2)
            {
                MessageBox.Show($"Vé ở vị trí ghế số {index + 1} đã được bán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Nếu ghế đang chọn (màu xanh) -> Đổi lại màu trắng (chưa bán)
            else if (trangThaiGhe[index] == 1)
            {
                trangThaiGhe[index] = 0;
                btn.BackColor = Color.White;
            }
            // Nếu ghế đang trống (màu trắng) -> Đổi sang màu xanh (đang chọn)
            else if (trangThaiGhe[index] == 0)
            {
                trangThaiGhe[index] = 1;
                btn.BackColor = Color.Blue;
                btn.ForeColor = Color.White;
            }
        }

        // Button CHỌN (Thanh toán & Chuyển sang Đã bán)
        private void btnChon_Click(object sender, EventArgs e)
        {
            int tongTien = 0;
            bool coGheChon = false;

            for (int i = 0; i < 15; i++)
            {
                // Nếu ghế đang ở trạng thái chọn (1)
                if (trangThaiGhe[i] == 1)
                {
                    coGheChon = true;
                    trangThaiGhe[i] = 2; // Chuyển thành đã bán
                    gheButtons[i].BackColor = Color.Yellow; // Đổi sang màu vàng
                    gheButtons[i].ForeColor = Color.Black;
                    tongTien += giaVe[i];
                }
                // Nếu ghế đã bán từ trước đó
                else if (trangThaiGhe[i] == 2)
                {
                    tongTien += giaVe[i];
                }
            }

            if (!coGheChon)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một vị trí ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Cập nhật tổng tiền lên TextBox
            txtThanhTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        // Button HỦY BỎ (Hủy các ghế đang chọn)
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                // Nếu ghế đang chọn (màu xanh) -> Đổi lại màu trắng
                if (trangThaiGhe[i] == 1)
                {
                    trangThaiGhe[i] = 0;
                    gheButtons[i].BackColor = Color.White;
                    gheButtons[i].ForeColor = Color.Black;
                }
            }
            txtThanhTien.Text = "0";
        }

        // Button KẾT THÚC
        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNangCao1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn đóng ứng dụng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}