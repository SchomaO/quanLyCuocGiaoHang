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
    public partial class frmGiaohang : Form
    {
        BUS_QuanLyCuocGiaoHang.BUS_QLCuoc busQLCuoc = new BUS_QuanLyCuocGiaoHang.BUS_QLCuoc();

        public frmGiaohang()
        {
            InitializeComponent();
        }

        private void frmGiaohang_Load(object sender, EventArgs e)
        {
            // Mới mở Form lên thì khóa chặt GroupBox cập nhật bên phải lại, bắt phải tìm đơn trước
            gbReality.Enabled = false;
            cboKetQuaGiao.SelectedIndex = -1;
        }

        // 🔍 NÚT TÌM ĐƠN HÀNG
        private void btnTimDon_Click(object sender, EventArgs e)
        {
            string maDon = txtMaDon.Text.Trim();
            if (string.IsNullOrEmpty(maDon))
            {
                MessageBox.Show("Vui lòng nhập mã đơn cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = busQLCuoc.BusTimDonHangDeGiao(maDon);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Đổ dữ liệu lên các ô TextBox ReadOnly
                txtKH.Text = dt.Rows[0]["MaKH"].ToString();
                txtTrangthai.Text = dt.Rows[0]["TrangThai"].ToString();
                txtNguoiNhan.Text = dt.Rows[0]["HoTen"].ToString();
                txtSDT.Text = dt.Rows[0]["SDT"].ToString();
                txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();

                // Kiểm tra tình trạng
                if (txtTrangthai.Text != "Đã giao thành công" && txtTrangthai.Text != "Đơn hàng hoàn lại")
                {
                    // Đơn hàng chưa kết thúc (có thể là Tiếp nhận, Đang vận chuyển, Chưa xử lý...) 
                    // -> Cho phép nhân viên chọn 1 trong 3 mốc để cập nhật kết quả thực tế
                    gbReality.Enabled = true;
                    MessageBox.Show($"Đơn hàng đang ở trạng thái [{txtTrangthai.Text}]. Vui lòng chọn kết quả cập nhật thực tế bên phải.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Đơn đã giao xong hoặc đã trả hàng về kho rồi thì KHÓA LẠI, không cho sửa nữa
                    gbReality.Enabled = false;
                    MessageBox.Show($"Đơn hàng này đã KẾT THÚC với kết quả là [{txtTrangthai.Text}], không thể cập nhật thêm!", "Cảnh báo logic", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                gbReality.Enabled = false;
                XoaTrangTextBox();
                MessageBox.Show("Mã đơn vận chuyển không tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 💾 NÚT XÁC NHẬN CẬP NHẬT TÌNH TRẠNG MỚI (CHỌN 1 TRONG 3 MỐC)
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string maDon = txtMaDon.Text.Trim();
            string trangThaiMoi = cboKetQuaGiao.Text; // Lấy mốc đã chọn (Đã giao thành công, Khách hẹn ngày giao lại, Đơn hàng hoàn lại)
            string ghiChu = txtGhiChuThucTe.Text.Trim();

            if (string.IsNullOrEmpty(trangThaiMoi))
            {
                MessageBox.Show("Vui lòng chọn 1 trong 3 mốc trạng thái thực tế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi BUS xuống CSDL để cập nhật trạng thái mới cho Form theo dõi đọc được
            bool ketQua = busQLCuoc.BusUpdateTrangThaiThucTe(maDon, trangThaiMoi, ghiChu);

            if (ketQua)
            {
                MessageBox.Show($"Cập nhật tình trạng đơn [{maDon}] thành [{trangThaiMoi}] thành công!", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xử lý xong thì reset form về trạng thái ban đầu để nhận đơn tiếp theo
                XoaTrangTextBox();
                txtMaDon.Clear();
                gbReality.Enabled = false;
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại, vui lòng kiểm tra lại kết nối mạng!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XoaTrangTextBox()
        {
            txtKH.Clear();
            txtTrangthai.Clear();
            txtNguoiNhan.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtGhiChuThucTe.Clear();
            cboKetQuaGiao.SelectedIndex = -1;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            XoaTrangTextBox();
            txtMaDon.Clear();
            gbReality.Enabled = false;
        }
    }
}
