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
       
        private DonVanChuyenBUS _donHangBUS = new DonVanChuyenBUS();
        private string _maDichVuAn = "";
        private double _trongLuongAn = 0;
        private double _chieuDaiAn = 0;
        private double _chieuRongAn = 0;
        private double _chieuCaoAn = 0;
        public frmTaoDon()
        {
            InitializeComponent();
          
        }
        public void NhanDuLieuTuFormTinhCuoc(string maDV, string tenDV, double khoangCach, double tienCOD, double tongCuoc, double trongLuong, double dai, double rong, double cao)
        {
            _maDichVuAn = maDV;
            _trongLuongAn = trongLuong;
            _chieuDaiAn = dai;
            _chieuRongAn = rong;
            _chieuCaoAn = cao;

            // Phần hiển thị lên giao diện giữ nguyên như cũ
            txtTenDV.Text = tenDV;
            txtKhoangCach_HienThi.Text = khoangCach.ToString() + " km";
            txtCOD_HienThi.Text = tienCOD.ToString("N0");
            lblTongCuoc_HienThi.Text = tongCuoc.ToString("N0");
        }
        private void btnTaoDon_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra an toàn: Bắt buộc phải tính cước thì mới có Mã Dịch Vụ ẩn
                if (string.IsNullOrEmpty(_maDichVuAn))
                {
                    MessageBox.Show("Vui lòng ấn nút 'Tính Cước' để hệ thống nạp mã dịch vụ trước khi tạo đơn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Kiểm tra Mã KH (Nếu có nhập thì bắt buộc phải là số)
                string maKHTam = txtMaKHGui.Text.Trim();
                if (!string.IsNullOrEmpty(maKHTam) && !int.TryParse(maKHTam, out _))
                {
                    MessageBox.Show("Mã khách hàng phải là chữ số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaKHGui.Focus();
                    return;
                }

                // 3. Đóng gói DTO an toàn tuyệt đối
                DonVanChuyenDTO donMoi = new DonVanChuyenDTO
                {
                    HoTenGui = txtHoTenGui.Text.Trim(),
                    SDTGui = txtSDTGui.Text.Trim(),
                    DiaChiGui = txtDiaChiGui.Text.Trim(),
                    MaKH = maKHTam, // Sẽ mang giá trị "" hoặc một con số

                    HoTenNhan = txtHoTenNhan.Text.Trim(),
                    SDTNhan = txtSDTNhan.Text.Trim(),
                    DiaChiNhan = txtDiaChiNhan.Text.Trim(),
                    TinhThanhNhan = txtTinhTPNhan.Text.Trim(),

                    // SỬA CHÍNH TẠI ĐÂY: Dùng biến ẩn chứa số, KHÔNG DÙNG txtTenDV.Text
                    MaDV = _maDichVuAn,

                    // Bóc tách số an toàn
                    KhoangCach = string.IsNullOrEmpty(txtKhoangCach_HienThi.Text) ? 0 : Convert.ToDouble(txtKhoangCach_HienThi.Text.Replace("km", "").Trim()),
                    TienCOD = string.IsNullOrEmpty(txtCOD_HienThi.Text) ? 0 : Convert.ToDouble(txtCOD_HienThi.Text.Replace(",", "").Replace(".", "").Trim()),
                    TongCuoc = string.IsNullOrEmpty(lblTongCuoc_HienThi.Text) ? 0 : Convert.ToDouble(lblTongCuoc_HienThi.Text.Replace(",", "").Replace(".", "").Trim()),

                    TrongLuong = _trongLuongAn,
                    ChieuDai = _chieuDaiAn,
                    ChieuRong = _chieuRongAn,
                    ChieuCao = _chieuCaoAn
                };

                // 4. Gọi BUS xử lý
                if (_donHangBUS.TaoDonHang(donMoi))
                {
                    MessageBox.Show("Tạo đơn hàng thành công! (Mã tự động tăng)", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(null, null);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtTenDV.Clear();
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
            txtHoTenGui.Focus();
        }

    }
}
