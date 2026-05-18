using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyCuocGiaoHang
{
    public class DonVanChuyenDTO
    {
        public string MaDon { get; set; }
        public int MaNguoiGui { get; set; }
        public int MaNguoiNhan { get; set; }
        public int MaDV { get; set; }

        // Kích thước bưu kiện (cm)
        public double ChieuDai { get; set; }
        public double ChieuRong { get; set; }
        public double ChieuCao { get; set; }

        // Khoảng cách vận chuyển (km) - Thay cho trọng lượng cũ
        public double KhoangCach { get; set; }

        public decimal TongCuoc { get; set; }
        public string TrangThai { get; set; }
    }
}

