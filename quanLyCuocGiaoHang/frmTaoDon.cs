using BUS_QuanLyCuocGiaoHang;
using DTO_QuanLyCuocGiaoHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace quanLyCuocGiaoHang
{
    public partial class frmTaoDon : Form
    {
        private BUS_DichVu _busDichVu = new BUS_DichVu(); 
        private DonVanChuyenBUS _donHangBUS = new DonVanChuyenBUS();
        private string _maDichVuAn = "";
        public frmTaoDon()
        {
            InitializeComponent();
        }
        public void NhanDuLieuTuFormTinhCuoc(string maDV, string tenDV, double khoangCach, double tienCOD, double tongCuoc)
        {
            _maDichVuAn = maDV; // Lưu lại mã dịch vụ phục vụ lưu database

            // Hiển thị trực quan lên 4 ô TextBox trên giao diện để nhân viên nhìn thấy
            txtTenDV.Text = tenDV;
            txtKhoangCach_HienThi.Text = khoangCach.ToString() + " km";
            txtCOD_HienThi.Text = tienCOD.ToString("N0");
            lblTongCuoc_HienThi.Text =  tongCuoc.ToString("N0");
        }
        private void btnTaoDon_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Đóng gói toàn bộ thông tin trên Form vào đối tượng DTO
                DonVanChuyenDTO donMoi = new DonVanChuyenDTO    
                {
                    HoTenGui = txtHoTenGui.Text.Trim(),
                    SDTGui = txtSDTGui.Text.Trim(),
                    DiaChiGui = txtDiaChiGui.Text.Trim(),
                    MaKH = txtMaKHGui.Text.Trim(),

                    HoTenNhan = txtHoTenNhan.Text.Trim(),
                    SDTNhan = txtSDTNhan.Text.Trim(),
                    DiaChiNhan = txtDiaChiNhan.Text.Trim(),
                    TinhThanhNhan = txtTinhTPNhan.Text.Trim(),

                    // Dữ liệu cước phí nhận được từ form Tính Cước
                    MaDV = _maDichVuAn,
                    KhoangCach = string.IsNullOrEmpty(txtKhoangCach_HienThi.Text) ? 0 : Convert.ToDouble(txtKhoangCach_HienThi.Text.Replace(" km", "")),
                    TienCOD = string.IsNullOrEmpty(txtCOD_HienThi.Text) ? 0 : Convert.ToDouble(txtCOD_HienThi.Text.Replace(",", "")),
                    TongCuoc = string.IsNullOrEmpty(lblTongCuoc_HienThi.Text) ? 0 : Convert.ToDouble(lblTongCuoc_HienThi.Text.Replace(",", ""))
                };

                // 2. Gửi hộp DTO sang cho tầng BUS thẩm định và xử lý
                if (_donHangBUS.TaoDonHang(donMoi))
                {
                    MessageBox.Show("Hệ thống đã tạo và lưu đơn hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(null, null); // Tạo xong tự động dọn sạch form
                }
            }
            catch (ArgumentException ex)
            {
                // Bắt các lỗi thiếu thông tin hoặc chưa tính cước phí
                MessageBox.Show(ex.Message, "Cảnh báo nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Bắt lỗi hệ thống hoặc SQL kết nối sập
                MessageBox.Show("Không thể tạo đơn hàng. " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTenGui.Clear(); txtSDTGui.Clear(); txtDiaChiGui.Clear(); txtMaKHGui.Clear();
            txtHoTenNhan.Clear(); txtSDTNhan.Clear(); txtDiaChiNhan.Clear(); txtTinhTPNhan.Clear();

            // Xóa sạch thông tin cước phí
            _maDichVuAn = "";
            //txtTenDV.Clear();
            txtKhoangCach_HienThi.Clear();
            txtCOD_HienThi.Clear();
            lblTongCuoc_HienThi.Text = " ";

            txtHoTenGui.Focus();
        }

        private void btnGoiTinhCuoc_Click(object sender, EventArgs e)
        {
            frmMain fMain = (frmMain)Application.OpenForms["frmMain"];
            if (fMain != null)
            {
                // Nạp 'this' (chính là Form Tạo Đơn hiện tại) vào trong ruột frmTinhCuoc
                fMain.MoFormCon(new frmTinhCuoc(this));
            }
        }

        private void frmTaoDon_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtDichVu = _busDichVu.GetDanhSachDichVu();
                txtTenDV.DataSource = dtDichVu;
                txtTenDV.DisplayMember = "TenDV"; // Hiện chữ cho nhân viên xem
                txtTenDV.ValueMember = "MaDV";    // Giữ mã số (1, 2, 3...) để lưu SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách dịch vụ: " + ex.Message);
            }
        }
    }
}
