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
        public bool KiemTraDangNhap(string user, string pass)
        {
            string query = "SELECT COUNT(*) FROM NguoiDung WHERE TenDangNhap = @user AND MatKhau = @pass";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                int count = (int)cmd.ExecuteScalar();
                return count > 0; // Nếu tìm thấy tài khoản hợp lệ, trả về true
            }
            catch { return false; }
            finally { _conn.Close(); }
        }

        // 2. Hàm xử lý Đăng ký tài khoản mới
        public bool DangKyTaiKhoan(string user, string pass)
        {
            string query = "INSERT INTO NguoiDung(TenDangNhap, MatKhau, Quyen) VALUES(@user, @pass, N'NhanVien')";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch { return false; }
            finally { _conn.Close(); }
        }
    }
}
