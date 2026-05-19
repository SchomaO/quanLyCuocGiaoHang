using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyCuocGiaoHang
{
    public class BaoCaoDTO
    {
        public string MaDon { get; set; }
        public DateTime NgayTao { get; set; }
        public string TenNguoiGui { get; set; }
        public string TenNguoiNhan { get; set; }
        public string TenDV { get; set; }
        public string TrangThai { get; set; }

        // CHÍNH LÀ DÒNG NÀY ĐÂY: Phải có nó thì thằng BUS mới cộng số Km được!
        public double KhoangCach { get; set; }

        public decimal TongCuoc { get; set; }
    }

    // Đại diện cho 3 ô tổng kết dữ liệu nằm ở dưới cùng của giao diện
    public class ThongKeTongKetDTO
    {
        public int TongSoDon { get; set; }
        public decimal TongDoanhThu { get; set; }

        // Đã đổi từ TongKhoangCach sang SoDonThanhCong
        public int SoDonThanhCong { get; set; }
    }
}