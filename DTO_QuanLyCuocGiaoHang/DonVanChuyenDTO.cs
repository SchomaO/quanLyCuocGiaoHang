using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyCuocGiaoHang
{
    public class DonVanChuyenDTO
    {
        public string HoTenGui { get; set; }
        public string SDTGui { get; set; }
        public string DiaChiGui { get; set; }
        public string MaKH { get; set; } // Có thể để trống nếu là khách vãng lai

        // 2. Thông tin người nhận
        public string HoTenNhan { get; set; }
        public string SDTNhan { get; set; }
        public string DiaChiNhan { get; set; }
        public string TinhThanhNhan { get; set; }

        // 3. Thông tin cước phí (Nhận từ form Tính Cước)
        public string MaDV { get; set; }
        public double KhoangCach { get; set; }
        public double TienCOD { get; set; }
        public double TongCuoc { get; set; }
    }
}

