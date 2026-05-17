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
using DAO_QuanLyCuocGiaoHang;

namespace quanLyCuocGiaoHang
{
    public partial class frmMain : Form
    {
        private bool isLoggedIn = false;
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
            isLoggedIn = false;
            //1. Khóa các nút chức năng trên Menu chính lại
            btnCalculater.Enabled = false;
            btnCreate.Enabled = false;
            btnDelivery.Enabled = false;
            btnReport.Enabled = false;
            btnTheodoi.Enabled = false;
            btnKhachHang.Enabled = false;
            // 2. Chuyển nút Auth về trạng thái "Đăng nhập" màu xanh
            btnAuth.Text = "Đăng nhập";
            btnAuth.BackColor = Color.FromArgb(59, 130, 246); // Màu xanh hiện đại

            // 3. Nhúng form đăng nhập vào vùng chính
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
            panelMenu.Visible = true;
            // Khi đăng nhập thành công, gọi hàm này từ frmDangNhap sang để hiện Menu làm việc lên
            isLoggedIn = true;

            // 1. Mở khóa toàn bộ các nút chức năng để nhân viên bấm được
            btnCalculater.Enabled = true;
            btnCreate.Enabled = true;
            btnDelivery.Enabled = true;
            btnReport.Enabled = true;
            btnTheodoi.Enabled = true;
            btnKhachHang.Enabled = true;

            // 2. BIẾN ĐỔI NÚT: Chuyển nút bấm sang chữ "Đăng xuất" màu đỏ
            btnAuth.Text = "Đăng xuất";
            btnAuth.BackColor = Color.FromArgb(239, 68, 68); // Màu đỏ chuyên nghiệp (Crimson Red)

            // 3. Dọn sạch màn hình đăng nhập cũ và load Form mặc định lên luôn
            panelMain.Controls.Clear();
            MessageBox.Show("Chào mừng bạn đã đăng nhập hệ thống!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        private void btnDelivery_Click(object sender, EventArgs e) => MoFormCon(new frmGiaohang());
        private void btnTheoDoi_Click(object sender, EventArgs e) => MoFormCon(new frmTheodoi());
        private void btnReport_Click(object sender, EventArgs e) => MoFormCon(new frmMain());
        private void btnKhachHang_Click(object sender, EventArgs e) => MoFormCon(new frmKhachHang());
        private void btnCreate_Click(object sender, EventArgs e) => MoFormCon(new frmMain());
        private void btnCalculater_Click(object sender, EventArgs e) => MoFormCon(new frmTinhCuoc());
        
        private void btnAuth_Click(object sender, EventArgs e)
        {
            if (isLoggedIn)
            {
                // Nếu đang Đã Đăng Nhập mà người dùng bấm vào -> Nghĩa là họ muốn ĐĂNG XUẤT
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    HienThiDangNhap(); // Gọi hàm này nó sẽ tự khóa chức năng và chuyển nút về màu xanh lại
                }
            }
            else
            {
                // Nếu đang Chưa Đăng Nhập mà bấm vào -> Load lại màn hình đăng nhập (đề phòng họ đang ở màn hình Đăng ký)
                HienThiDangNhap();
            }
        }
    }
}