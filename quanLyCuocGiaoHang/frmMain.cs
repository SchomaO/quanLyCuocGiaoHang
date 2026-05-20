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
        private string QuyenNguoiDung = "";
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Khi vừa mở phần mềm, ẩn Menu chính đi, chỉ hiện màn hình đăng nhập
            panelMenu.Visible = true;
            HienThiDangNhap();
        }

        public void HienThiDangNhap()
        {
            isLoggedIn = false;

            // 1. Khóa các nút chức năng trên Menu (Chưa đăng nhập thì không cho bấm)
            btnCalculater.Enabled = false;
            btnCreate.Enabled = false;
            btnDelivery.Enabled = false;
            btnReport.Enabled = false;
            btnTheodoi.Enabled = false;
            btnKhachHang.Enabled = false;
            btnQuanLyGiaCuoc.Enabled = false;

            // 2. Chuyển nút Auth về trạng thái "Đăng nhập" màu xanh
            btnAuth.Text = "Đăng nhập";
            btnAuth.BackColor = Color.FromArgb(59, 130, 246);

            // 3. CHÍNH LÀ NÓ: Tự động nhúng sẵn frmDangNhap vào panelMain luôn
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

        public void DangNhapThanhCong(string quyen)
        {
            this.QuyenNguoiDung = quyen;
            isLoggedIn = true;
            panelMenu.Visible = true;

            // 1. Mở khóa toàn bộ các nút chức năng cơ bản để bấm được
            btnCalculater.Enabled = true;
            btnCreate.Enabled = true;
            btnDelivery.Enabled = true;
            btnTheodoi.Enabled = true;
            btnKhachHang.Enabled = true;
            btnQuanLyGiaCuoc.Enabled = true; // Mở khóa nút quản lý cước
            btnReport.Enabled = true;
            // 2. PHÂN QUYỀN ADMIN / NHÂN VIÊN TẠI ĐÂY
            if (QuyenNguoiDung == "Nhanvien")
            {
                // Nếu là nhân viên, ẨN nút Quản lý giá cước và Báo cáo
                btnQuanLyGiaCuoc.Visible = false;
              
            }
            else if (QuyenNguoiDung == "Admin")
            {
                // Nếu là Admin, HIỆN tất cả lên đầy đủ
                btnQuanLyGiaCuoc.Visible = true;
                btnReport.Visible = true;
            }

            // 3. Chuyển nút Auth về Đăng xuất
            btnAuth.Text = "Đăng xuất";
            btnAuth.BackColor = Color.FromArgb(239, 68, 68);

            panelMain.Controls.Clear();
            MessageBox.Show("Chào mừng bạn đã đăng nhập hệ thống với quyền: " + quyen, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        // Hàm dùng chung để nhúng các form chức năng (Giao hàng, Theo dõi...)
        public void MoFormCon(Form formCon)
        {
            // 1. Thay vì .Close(), ta chỉ gỡ Form cũ ra khỏi Panel để giữ mạng cho nó
            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls.Clear(); // Chỉ xóa Control hiển thị trên Panel chứ không xóa Object trong bộ nhớ
            }

            // 2. Cấu hình Form con mới chuẩn bị nhúng vào
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;

            // 3. Đổ Form con vào Panel và hiển thị lên màn hình
            panelMain.Controls.Add(formCon);
            panelMain.Tag = formCon;
            formCon.BringToFront();
            formCon.Show();
        }
        // Sự kiện Click các nút trên Menu
        private void btnDelivery_Click(object sender, EventArgs e) => MoFormCon(new frmGiaohang());
        private void btnTheoDoi_Click(object sender, EventArgs e) => MoFormCon(new frmTheodoi());
        private void btnReport_Click(object sender, EventArgs e) => MoFormCon(new frmBaoCao());
        private void btnKhachHang_Click(object sender, EventArgs e) => MoFormCon(new frmKhachHang());
        private void btnCreate_Click(object sender, EventArgs e) => MoFormCon(new frmTaoDon());
        private void btnCalculater_Click(object sender, EventArgs e) => MoFormCon(new frmTinhCuoc());
        
        private void btnAuth_Click(object sender, EventArgs e)
        {
            if (isLoggedIn)
            {
                // 1. Nếu đang Đã Đăng Nhập -> Bấm vào là để ĐĂNG XUẤT
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    HienThiDangNhap(); // Gọi hàm này nó sẽ tự khóa chức năng và hiện sẵn form đăng nhập lại
                }
            }
            else
            {
                // 2. Nếu đang Chưa Đăng Nhập -> Load lại màn hình đăng nhập (đề phòng họ đang ở màn hình Đăng ký)
                HienThiDangNhap();
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQuanLyGiaCuoc_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmQuanLyGiaCuoc());
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide(); // Giấu form đi

                // 1. Phải bật Visible = true TRƯỚC
                notifyIcon1.Visible = true;

                // 2. Mới gọi bong bóng thông báo SAU
                notifyIcon1.ShowBalloonTip(2000, "Quản Lý Cước", "Phần mềm đang chạy ngầm ở đây!", ToolTipIcon.Info);
            }

        }

        private void frmMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show(); // Bật lại Form
            this.WindowState = FormWindowState.Maximized; // Trả lại kích thước bình thường
            notifyIcon1.Visible = false; // Tắt cái icon dưới góc đi
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show(); // Hiện lại form
            this.WindowState = FormWindowState.Maximized; // Phóng to lại kích thước bình thường
            notifyIcon1.Visible = false; // Giấu cái icon dưới góc đi
        }
    }
}