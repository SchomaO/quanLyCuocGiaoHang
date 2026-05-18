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

        public bool XulyThemDonHang(DonVanChuyenDTO don)
        {
            // Kiểm tra điều kiện dữ liệu cơ bản trước khi cho lưu
            if (string.IsNullOrEmpty(don.MaDon) || don.KhoangCach <= 0)
                return false;

            return donDAO.ThemDonHang(don);
        }
    }
}
