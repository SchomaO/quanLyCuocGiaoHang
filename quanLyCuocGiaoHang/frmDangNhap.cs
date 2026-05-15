using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLyCuocGiaoHang;

namespace quanLyCuocGiaoHang
{
    public partial class frmDangNhap : Form
    {
        BUS_NguoiDung busUser = new BUS_NguoiDung();
        frmMain formChinh;

        public frmDangNhap(frmMain mainForm)
        {
            InitializeComponent();
            this.formChinh = mainForm; // Nhận tham chiếu từ Trang chủ
        }
        private void lnkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Gọi hàm chuyển trang trên Form1 (Mình sẽ viết hàm này ở mục 4)
            formChinh.HienThiDangKy();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (busUser.DangNhap(txtUser.Text, txtPass.Text))
            {
                formChinh.DangNhapThanhCong(); // Kích hoạt hiện Menu ở Trang chủ
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
    }
}
