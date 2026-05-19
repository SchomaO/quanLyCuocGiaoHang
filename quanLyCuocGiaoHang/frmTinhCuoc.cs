using BUS_QuanLyCuocGiaoHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanLyCuocGiaoHang
{
    public partial class frmTinhCuoc : Form
    {
        BUS_DichVu busDV = new BUS_DichVu();
        public frmTinhCuoc()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmTinhCuoc_Load(object sender, EventArgs e)
        {
            DataTable dtDichVu = busDV.GetDanhSachDichVu();

            cboDichVu.DataSource = dtDichVu;
            cboDichVu.DisplayMember = "TenDV"; // Chữ hiện lên (VD: Hỏa tốc)
            cboDichVu.ValueMember = "MaDV";    // Giá trị ẩn bên dưới
        }

        private void btnTinhCuoc_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Lấy các biến số từ TextBox do nhân viên nhập
                double w_actual = Convert.ToDouble(txtTrongLuong.Text);
                double l = Convert.ToDouble(txtDai.Text);
                double w_width = Convert.ToDouble(txtRong.Text);
                double h = Convert.ToDouble(txtCao.Text);
                double k_dist = Convert.ToDouble(txtKhoangCach.Text);

                // Bước 2: Gọi tầng BUS để tính Trọng lượng quy đổi & Trọng lượng tính phí
                double w_vol = busDV.TinhTrongLuongQuyDoi(l, w_width, h);
                double w_final = busDV.TimTrongLuongTinhPhi(w_actual, w_vol);

                // Hiển thị ra các ô ReadOnly (Làm tròn 2 chữ số thập phân)
                txtTLQuyDoi.Text = Math.Round(w_vol, 2).ToString();
                txtTLTinhPhi.Text = Math.Round(w_final, 2).ToString();

                // Bước 3: Lấy bảng giá ẩn phía dưới cái Dịch vụ đang được chọn ở ComboBox
                DataRowView rowView = (DataRowView)cboDichVu.SelectedItem;
                double giaTheoKm = Convert.ToDouble(rowView["GiaTheoKm"]);
                double phiCoBan = Convert.ToDouble(rowView["PhiCoBan"]);
                double phuPhi = Convert.ToDouble(rowView["PhuPhi"]);

                // Bước 4: Gọi tầng BUS để tính Tổng tiền
                double tongCuoc = busDV.TinhTongCuoc(w_final, k_dist, giaTheoKm, phiCoBan, phuPhi);

                // Nếu có nhập tiền COD thì cộng thêm phí thu hộ (Giả sử lấy 1% tiền COD làm phí thu hộ)
                // Nếu quy trình của bạn không tính phí COD, bạn có thể bỏ đoạn này
                if (!string.IsNullOrEmpty(txtTienCOD.Text))
                {
                    double tienCOD = Convert.ToDouble(txtTienCOD.Text);
                    tongCuoc += (tienCOD * 0.01); // Cộng 1% phí xử lý COD
                }

                // Hiển thị số tiền đỏ chót lên Form với định dạng có dấu phẩy (VD: 55,000)
                txtTongCuoc.Text = string.Format("{0:N0} VNĐ", tongCuoc);
            }
            catch (FormatException)
            {
                // Bẫy lỗi: Ngăn phần mềm bị sập nếu nhân viên lỡ tay gõ chữ "ABC" vào ô nhập số, hoặc để trống
                MessageBox.Show("Vui lòng điền đầy đủ và chính xác các con số vào thông số kiện hàng!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Xóa trắng toàn bộ TextBox
            txtTrongLuong.Clear();
            txtDai.Clear();
            txtRong.Clear();
            txtCao.Clear();
            txtKhoangCach.Clear();
            txtTienCOD.Clear();

            txtTLQuyDoi.Clear();
            txtTLTinhPhi.Clear();
            txtTongCuoc.Clear();

            // Đưa con trỏ chuột về lại ô đầu tiên để nhập đơn mới
            txtTrongLuong.Focus();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem nhân viên đã tính ra tiền chưa
            if (string.IsNullOrEmpty(txtTongCuoc.Text))
            {
                MessageBox.Show("Vui lòng ấn nút 'Tính Cước' trước khi xác nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy dữ liệu cước phí đang có trên màn hình
            string maDV = cboDichVu.SelectedValue.ToString();
            string tenDV = cboDichVu.Text;
            double khoangCach = Convert.ToDouble(txtKhoangCach.Text);
            double tienCOD = string.IsNullOrEmpty(txtTienCOD.Text) ? 0 : Convert.ToDouble(txtTienCOD.Text);

            // Cắt bỏ chuỗi chữ dư thừa để lấy số thuần túy
            string chuoiTien = txtTongCuoc.Text.Replace(" VNĐ", "").Replace(",", "").Trim();
            double tongCuoc = Convert.ToDouble(chuoiTien);

            // 3. XỬ LÝ THÔNG MINH 2 LUỒNG
            frmTaoDon fTaoDon = this.Owner as frmTaoDon;

            if (fTaoDon != null)
            {
                // TRƯỜNG HỢP 1: Form Tính Cước được gọi TỪ FORM TẠO ĐƠN (Trả dữ liệu về form cũ)
                fTaoDon.NhanDuLieuTuFormTinhCuoc(maDV, tenDV, khoangCach, tienCOD, tongCuoc);
                this.Close(); // Truyền xong thì đóng form tính cước lại
            }
            else
            {
                // TRƯỜNG HỢP 2: Form Tính Cước được mở ĐỘC LẬP TỪ MENU CHÍNH (Đang nằm trong Panel)
                DialogResult dr = MessageBox.Show("Bạn có muốn dùng cước phí này để tạo đơn hàng mới luôn không?",
                                                  "Chuyển sang Tạo Đơn",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    // Tìm chính xác cái Form Chính (frmMain) đang chạy của chương trình
                    frmMain formChinh = Application.OpenForms["frmMain"] as frmMain;

                    if (formChinh != null)
                    {
                        // Tạo ra một form Tạo Đơn mới tinh
                        frmTaoDon frmMoi = new frmTaoDon();

                        // Nhét trước dữ liệu cước phí vào form Tạo Đơn đó (Tự động điền vào lblTongCuoc_HienThi)
                        frmMoi.NhanDuLieuTuFormTinhCuoc(maDV, tenDV, khoangCach, tienCOD, tongCuoc);

                        // Ra lệnh cho Form Chính nhúng cái frmMoi này vào Panel bên phải để che form tính cước đi
                        formChinh.MoFormCon(frmMoi);
                    }
                    else
                    {
                        // Phương án dự phòng nếu chạy kiểm thử không mở qua frmMain
                        frmTaoDon frmMoi = new frmTaoDon();
                        frmMoi.NhanDuLieuTuFormTinhCuoc(maDV, tenDV, khoangCach, tienCOD, tongCuoc);
                        frmMoi.ShowDialog();
                    }
                }
            }
        }
    }
}
