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
    public partial class frmKhachHang : Form
    {
        BUS_KhachHang busKH = new BUS_KhachHang();
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
            ResetForm();
        }
        private void LoadDanhSach()
        {
            dgvKhachHang.DataSource = busKH.GetKhachHang();
        }
        private void ResetForm()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            mtbSDT.Clear();
            txtDiaChi.Clear();
            txtHoTen.Focus();

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.BackColor = Color.Gray;
            btnXoa.BackColor = Color.Gray;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void txtThem_Click(object sender, EventArgs e)
        {
            DTO_KhachHang kh = new DTO_KhachHang(txtHoTen.Text, mtbSDT.Text, txtDiaChi.Text);

            // Truyền xuống BUS xử lý
            if (busKH.AddKhachHang(kh))
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSach(); // Cập nhật lại bảng
                ResetForm();
            }
            else
            {
                MessageBox.Show("Thêm thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tránh lỗi click vào tiêu đề cột (Header)
            if (e.RowIndex >= 0)
            {
                int i = dgvKhachHang.CurrentRow.Index;
                txtMaKH.Text = dgvKhachHang.Rows[i].Cells["MaKH"].Value.ToString();
                txtHoTen.Text = dgvKhachHang.Rows[i].Cells["HoTen"].Value.ToString();
                mtbSDT.Text = dgvKhachHang.Rows[i].Cells["SDT"].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.Rows[i].Cells["DiaChi"].Value.ToString();

                // Bổ sung: Khi đã chọn 1 dòng hợp lệ, bật sáng nút Sửa và Xóa lên
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.BackColor = Color.RoyalBlue; // Trả lại màu Xanh dương cho nút Sửa
                btnXoa.BackColor = Color.Crimson;
            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text;

            // Đẩy xuống BUS để lấy Data và gắn trực tiếp vào bảng
            dgvKhachHang.DataSource = busKH.SearchKhachHang(tuKhoa);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn khách hàng nào trên DataGridView chưa
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đóng gói dữ liệu vào DTO
            DTO_KhachHang kh = new DTO_KhachHang(txtHoTen.Text, mtbSDT.Text, txtDiaChi.Text);
            kh.MaKH = Convert.ToInt32(txtMaKH.Text); // Bắt buộc phải gắn mã KH vào để biết đang sửa ai

            // Đẩy xuống BUS
            if (busKH.UpdateKhachHang(kh))
            {
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSach(); // Tải lại bảng
                ResetForm();    // Xóa trắng form
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn khách hàng chưa
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // UX Chuyên nghiệp: Hiện hộp thoại cảnh báo trước khi xóa
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này khỏi hệ thống không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.Yes) // Nếu người dùng bấm Yes
            {
                int maKH = Convert.ToInt32(txtMaKH.Text);

                if (busKH.DeleteKhachHang(maKH))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSach();
                    ResetForm();
                }
                else
                {
                    // Báo lỗi chi tiết để người dùng hiểu nguyên nhân
                    MessageBox.Show("Xóa thất bại! Nguyên nhân có thể do khách hàng này đang có Đơn Vận Chuyển trong hệ thống.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
