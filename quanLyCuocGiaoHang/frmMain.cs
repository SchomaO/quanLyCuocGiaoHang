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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Khi vừa mở phần mềm, ẩn Menu chính đi, chỉ hiện màn hình đăng nhập
            panelMenu.Visible = false;
            HienThiDangNhap();
        }

        public void HienThiDangNhap()
        {
            frmDangNhap fLogin = new frmDangNhap(this);
            fLogin.TopLevel = false;
            fLogin.FormBorderStyle = FormBorderStyle.None;
            fLogin.Dock = DockStyle.Fill;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(fLogin);
            fLogin.Show();
        }
        public void HienThiDangKy()
        {
            frmDangKy fRegister = new frmDangKy(this);
            fRegister.TopLevel = false;
            fRegister.FormBorderStyle = FormBorderStyle.None;
            fRegister.Dock = DockStyle.Fill;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(fRegister);
            fRegister.Show();
        }

        public void DangNhapThanhCong()
        {
            // Khi đăng nhập thành công, gọi hàm này từ frmDangNhap sang để hiện Menu làm việc lên
            panelMenu.Visible = true;
            panelMain.Controls.Clear();

            // Có thể load màn hình dashboard/thống kê ở đây như bài trước
            MessageBox.Show("Chào mừng bạn đã đăng nhập hệ thống!", "Thành công");
        }
        // Hàm dùng chung để nhúng các form chức năng (Giao hàng, Theo dõi...)
        private void MoFormCon(Form formCon)
        {
            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls[0].Dispose();
            }
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            panelMain.Controls.Add(formCon);
            formCon.Show();
        }
        // Sự kiện Click các nút trên Menu
        private void btnGiaoHang_Click(object sender, EventArgs e) => MoFormCon(new frmGiaohang());
        private void btnTheoDoi_Click(object sender, EventArgs e) => MoFormCon(new frmTheodoi());

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Reset lại trạng thái phần mềm về lúc chưa đăng nhập
            panelMenu.Visible = false;
            HienThiDangNhap();
        }
    }
}