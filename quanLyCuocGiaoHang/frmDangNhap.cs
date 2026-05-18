using BUS_QuanLyCuocGiaoHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // Lấy dữ liệu (Sử dụng đúng tên TextBox mà bạn đã đặt ở giao diện Design)
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            // 1. Kiểm tra xác thực (Đúng tài khoản & mật khẩu không?)
            if (busUser.DangNhap(user, pass))
            {
                // 2. Nếu đúng, chui vào Database lấy cái chữ "Admin" hoặc "Nhanvien" lên
                string quyen = busUser.LayQuyenTruyCap(user);

                // 3. Đẩy cái quyền đó sang cho Form Main xử lý ẩn/hiện nút bấm
                formChinh.DangNhapThanhCong(quyen);
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
