using DAO_QuanLyCuocGiaoHang;
using DTO_QuanLyCuocGiaoHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLyCuocGiaoHang
{
    public class DonVanChuyenBUS
    {
        private DonVanChuyenDAO donDAO = new DonVanChuyenDAO();

   

        public bool TaoDonHang(DonVanChuyenDTO dh)
        {
            // Kiểm tra ràng buộc logic nghiệp vụ bưu cục
            if (string.IsNullOrEmpty(dh.HoTenGui) || string.IsNullOrEmpty(dh.HoTenNhan))
            {
                throw new ArgumentException("Họ tên người gửi và người nhận không được để trống!");
            }

            if (dh.TongCuoc <= 0)
            {
                throw new ArgumentException("Đơn hàng chưa được tính cước phí hợp lệ! Vui lòng thực hiện tính cước.");
            }

            // Đạt điều kiện thì gọi tầng DAO xử lý xuống Database
            return donDAO.ThemDonHangMoi(dh);
        }
    }
}
