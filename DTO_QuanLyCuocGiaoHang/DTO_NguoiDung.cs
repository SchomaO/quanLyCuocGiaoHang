using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyCuocGiaoHang
{
    namespace DTO_QuanLyCuocGiaoHang
    {
        public class DTO_NguoiDung
        {
            // 1. Các thuộc tính (Giống hệt các cột trong bảng NguoiDung trên SQL)
            public string TenDangNhap { get; set; }
            public string MatKhau { get; set; }
            public string Quyen { get; set; }

            // 2. Constructor mặc định (Không tham số)
            public DTO_NguoiDung()
            {
            }

            // 3. Constructor đầy đủ tham số
            public DTO_NguoiDung(string tenDangNhap, string matKhau, string quyen)
            {
                this.TenDangNhap = tenDangNhap;
                this.MatKhau = matKhau;
                this.Quyen = quyen;
            }

            // 4. Constructor dùng cho việc Đăng nhập/Đăng ký (chưa cần biết Quyền vội)
            public DTO_NguoiDung(string tenDangNhap, string matKhau)
            {
                this.TenDangNhap = tenDangNhap;
                this.MatKhau = matKhau;
            }
        }
    }
}
