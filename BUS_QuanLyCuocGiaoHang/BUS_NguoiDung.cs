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

        public bool DangNhap(string user, string pass)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass)) return false;
            return daoUser.KiemTraDangNhap(user, pass);
        }

        public string DangKy(string user, string pass, string rePass)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                return "Vui lòng nhập đầy đủ thông tin!";
            if (pass != rePass)
                return "Mật khẩu xác nhận không trùng khớp!";

            bool kq = daoUser.DangKyTaiKhoan(user, pass);
            if (kq) return "Đăng ký thành công!";
            else return "Tên đăng nhập đã tồn tại hoặc xảy ra lỗi!";
        }
    }
}
