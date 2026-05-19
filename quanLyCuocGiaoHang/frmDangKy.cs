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

using System.IO;
namespace quanLyCuocGiaoHang
{
    public partial class frmDangKy : Form
    {
        BUS_NguoiDung busUser = new BUS_NguoiDung();
        frmMain formChinh;
        public frmDangKy(frmMain mainForm)
        {
            InitializeComponent();
            this.formChinh = mainForm;
        }

        private void lnDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formChinh.HienThiDangNhap(); // Quay lại màn hình đăng nhập
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string user = txtUserDK.Text.Trim();
            string pass = txtPassDK.Text.Trim();
            string confirm = txtRePassDK.Text.Trim();

            // GUI BÂY GIỜ CHỈ LÀM ĐÚNG 1 NHIỆM VỤ: Gửi dữ liệu xuống BUS và hứng kết quả trả về
            string result = busUser.DangKy(user, pass, confirm);

            if (result == "Đăng ký thành công!")
            {
                MessageBox.Show("Đăng ký tài khoản nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                formChinh.HienThiDangNhap();
            }
            else
            {
                // Toàn bộ các lỗi trống, lỗi lệch mật khẩu sẽ được thông báo ở đây dựa trên chuỗi trả về từ BUS
                MessageBox.Show(result, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
