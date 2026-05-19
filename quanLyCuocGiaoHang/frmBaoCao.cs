using BUS_QuanLyCuocGiaoHang;
using DTO_QuanLyCuocGiaoHang;
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
    public partial class frmBaoCao : Form
    {
        // Khai báo đối tượng tầng BUS
        private BaoCaoBUS _baoCaoBUS = new BaoCaoBUS();
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvBaoCao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            // Nạp dữ liệu ban đầu cho ComboBox loại dịch vụ
            cboLoaiDichVu.Items.Clear();
            cboLoaiDichVu.Items.Add("Tất cả");
            cboLoaiDichVu.Items.Add("Chuyển phát tiêu chuẩn");
            cboLoaiDichVu.Items.Add("Chuyển phát nhanh");
            cboLoaiDichVu.Items.Add("Hỏa tốc nội đô");

            cboLoaiDichVu.SelectedIndex = 0;
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy các giá trị người dùng vừa chọn trên Form
                DateTime tuNgay = dtpTuNgay.Value;
                DateTime denNgay = dtpDenNgay.Value;
                string loaiDichVu = cboLoaiDichVu.SelectedItem?.ToString();

                // 1. Gọi BUS để lấy dữ liệu đơn hàng
                List<BaoCaoDTO> danhSach = _baoCaoBUS.LayDanhSachBaoCao(tuNgay, denNgay, loaiDichVu);

                // 2. Đổ danh sách tìm được lên lưới dữ liệu DataGridView
                dgvBaoCao.DataSource = danhSach;

                // 3. Gọi BUS để tính toán các con số tổng kết ở dưới
                ThongKeTongKetDTO thongKe = _baoCaoBUS.TinhToanThongKe(danhSach);

                // 4. In các con số đã tính lên các Label trên giao diện
                lblTongSoDon.Text = $"Tổng số đơn : {thongKe.TongSoDon}";
                lblTongDoanhThu.Text = $"Tổng Doanh Thu : {thongKe.TongDoanhThu:N0} VNĐ";
                lblTongKhoangCach.Text = $"Tổng Khoảng Cách : {thongKe.TongKhoangCach:N1} km";
            }
            catch (ArgumentException ex)
            {
                // Hiển thị cảnh báo nếu người dùng nhập sai logic ngày tháng
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi hệ thống nếu mất kết nối SQL hoặc sai tên cột...
                MessageBox.Show("Lỗi hệ thống khi tải báo cáo: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }
