using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyCuocGiaoHang
{
    public class DTO_KhachHang
    {
        public int MaKH { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }

        // Constructor rỗng
        public DTO_KhachHang() { }

        // Constructor có tham số
        public DTO_KhachHang(string hoTen, string sdt, string diaChi)
        {
            this.HoTen = hoTen;
            this.SDT = sdt;
            this.DiaChi = diaChi;
        }
    }
}
