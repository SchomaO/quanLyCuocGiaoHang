using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO_QuanLyCuocGiaoHang;

namespace BUS_QuanLyCuocGiaoHang
{
    public class BUS_NguoiDung
    {
        private DAO_NguoiDung daoUser = new DAO_NguoiDung();

        public bool DangNhap(string taiKhoan, string matKhau)
        {
            if (string.IsNullOrEmpty(taiKhoan.Trim()) || string.IsNullOrEmpty(matKhau.Trim()))
            {
                return false;
            }

            // Gọi xuống DAO để kiểm tra xem tài khoản có tồn tại không
            return daoUser.KiemTraDangNhap(taiKhoan.Trim(), matKhau.Trim());
        }

        public string DangKy(string user, string pass, string rePass)
        {
            // Giữ nguyên bộ lọc này ở BUS để xử lý tập trung
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                return "Vui lòng nhập đầy đủ thông tin!";

            if (pass != rePass)
                return "Mật khẩu xác nhận không trùng khớp!";

            bool kq = daoUser.DangKyTaiKhoan(user, pass);
            if (kq) return "Đăng ký thành công!";
            else return "Tên đăng nhập đã tồn tại hoặc xảy ra lỗi!";
        }
        public string LayQuyenTruyCap(string taiKhoan)
        {
            if (string.IsNullOrEmpty(taiKhoan))
                return "";

            // Gọi xuống DAO để lấy chuỗi Quyen từ SQL
            return daoUser.LayQuyenTaiKhoan(taiKhoan.Trim());
        }
    }
}
