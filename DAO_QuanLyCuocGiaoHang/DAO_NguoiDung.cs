using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_QuanLyCuocGiaoHang
{
    public class DAO_NguoiDung : DBConnect
    {
        // 1. Hàm kiểm tra Đăng nhập
        public bool KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            // Dùng hàm RTRIM trong SQL để tự động cắt bỏ khoảng trắng ẩn ở ô Quyen hoặc TenDangNhap nếu có
            string query = "SELECT COUNT(*) FROM NguoiDung WHERE RTRIM(TenDangNhap) = @User AND MatKhau = @Pass";

            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@User", taiKhoan);
                cmd.Parameters.AddWithValue("@Pass", matKhau);

                try
                {
                    OpenConnection(); // Gọi hàm mở kết nối an toàn từ lớp cha DBConnect

                    int ketQua = (int)cmd.ExecuteScalar(); // Trả về số lượng dòng tìm thấy

                    if (ketQua > 0)
                    {
                        return true; // Đăng nhập khớp thông tin
                    }
                }
                catch (Exception)
                {
                    // Có thể xử lý ghi log lỗi ở đây nếu cần
                    return false;
                }
                finally
                {
                    CloseConnection(); // Gọi hàm đóng kết nối an toàn từ lớp cha DBConnect
                }
            }
            return false;
        }

        // HÀM ĐĂNG KÝ TÀI KHOẢN MẶC ĐỊNH QUYỀN NHÂN VIÊN
        public bool DangKyTaiKhoan(string user, string pass)
        {
            // 1. Kiểm tra tài khoản đã tồn tại chưa
            string queryCheck = "SELECT COUNT(*) FROM NguoiDung WHERE TenDangNhap = @User";

            // 2. Ép cứng quyền 'Nhanvien' ngay trong câu lệnh SQL để lưu vào database
            string queryInsert = "INSERT INTO NguoiDung (TenDangNhap, MatKhau, Quyen) VALUES (@User, @Pass, N'Nhanvien')";

            try
            {
                OpenConnection(); // Mở kết nối từ DBConnect

                // Bước 1: Check trùng tên đăng nhập
                using (SqlCommand cmdCheck = new SqlCommand(queryCheck, _conn))
                {
                    cmdCheck.Parameters.AddWithValue("@User", user);
                    int testTonTai = (int)cmdCheck.ExecuteScalar();
                    if (testTonTai > 0) return false; // Trùng tên, trả về false để BUS báo lỗi
                }

                // Bước 2: Thực hiện chèn tài khoản mới
                using (SqlCommand cmdInsert = new SqlCommand(queryInsert, _conn))
                {
                    cmdInsert.Parameters.AddWithValue("@User", user);
                    cmdInsert.Parameters.AddWithValue("@Pass", pass);

                    int result = cmdInsert.ExecuteNonQuery();
                    return result > 0; // Nếu chèn thành công sẽ trả về true
                }
            }
            catch (Exception)
            {
                return false; // Lỗi kết nối hoặc lỗi cú pháp SQL
            }
            finally
            {
                CloseConnection(); // Đóng kết nối an toàn
            }
        }
    }
}
