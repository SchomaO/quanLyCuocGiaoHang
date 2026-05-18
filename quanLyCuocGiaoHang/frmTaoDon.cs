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
        public frmTaoDon()
        {
            InitializeComponent();
        }

        private void btnTaoDon_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra điều kiện nhập xuất cơ bản (Validation)
            if (string.IsNullOrEmpty(txtHoTenGui.Text) || string.IsNullOrEmpty(txtHoTenNhan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ họ tên người gửi và người nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Chuỗi kết nối SQL Server (Thay bằng chuỗi của bạn nhé)
            string connectionString = @"Data Source=DESKTOP-5K1RTKO;Initial Catalog=QuanLyCuoc;Integrated Security=True";

            // 3. Câu lệnh INSERT SQL
            string query = "INSERT INTO DonHang (HoTenGui, SDTGui, DiaChiGui, MaKH, HoTenNhan, SDTNhan, DiaChiNhan, TinhThanhNhan) " +
                           "VALUES (@HoTenGui, @SDTGui, @DiaChiGui, @MaKH, @HoTenNhan, @SDTNhan, @DiaChiNhan, @TinhThanhNhan)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Truyền tham số để tránh SQL Injection
                        cmd.Parameters.AddWithValue("@HoTenGui", txtHoTenGui.Text.Trim());
                        cmd.Parameters.AddWithValue("@SDTGui", txtSDTGui.Text.Trim());
                        cmd.Parameters.AddWithValue("@DiaChiGui", txtDiaChiGui.Text.Trim());

                        // Kiểm tra mã KH nếu trống thì lưu NULL hoặc rỗng
                        cmd.Parameters.AddWithValue("@MaKH", string.IsNullOrEmpty(txtMaKHGui.Text) ? (object)DBNull.Value : txtMaKHGui.Text.Trim());

                        cmd.Parameters.AddWithValue("@HoTenNhan", txtHoTenNhan.Text.Trim());
                        cmd.Parameters.AddWithValue("@SDTNhan", txtSDTNhan.Text.Trim());
                        cmd.Parameters.AddWithValue("@DiaChiNhan", txtDiaChiNhan.Text.Trim());
                        cmd.Parameters.AddWithValue("@TinhThanhNhan", txtTinhTPNhan.Text.Trim());

                        // Thực thi câu lệnh
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Tạo đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Tự động làm mới form sau khi thêm thành công (tùy chọn)
                        
                        }
                        else
                        {
                            MessageBox.Show("Tạo đơn hàng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Xóa sạch chữ trong các ô TextBox của Người gửi
            txtHoTenGui.Clear();
            txtSDTGui.Clear();
            txtDiaChiGui.Clear();
            txtMaKHGui.Clear();

            // Xóa sạch chữ trong các ô TextBox của Người nhận
            txtHoTenNhan.Clear();
            txtSDTNhan.Clear();
            txtDiaChiNhan.Clear();
            txtTinhTPNhan.Clear();

            // Đưa con trỏ chuột nhấp nháy về lại ô đầu tiên để người dùng nhập đơn mới
            txtHoTenGui.Focus();
        }
    }
}
