using DAO_QuanLyCuocGiaoHang;
using DTO_QuanLyCuocGiaoHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLyCuocGiaoHang
{
    public class BUS_KhachHang
    {
        DAO_KhachHang daoKH = new DAO_KhachHang();

        public DataTable GetKhachHang()
        {
            return daoKH.GetKhachHang();
        }

        public bool AddKhachHang(DTO_KhachHang kh)
        {
            // Kiểm tra nghiệp vụ: Không được để trống tên và SĐT
            if (string.IsNullOrWhiteSpace(kh.HoTen) || string.IsNullOrWhiteSpace(kh.SDT))
            {
                return false;
            }
            return daoKH.AddKhachHang(kh);
        }
        // Sửa khách hàng
        public bool UpdateKhachHang(DTO_KhachHang kh)
        {
            // Kiểm tra không cho phép để trống tên hoặc SĐT
            if (string.IsNullOrWhiteSpace(kh.HoTen) || string.IsNullOrWhiteSpace(kh.SDT))
            {
                return false;
            }
            return daoKH.UpdateKhachHang(kh);
        }

        // Xóa khách hàng
        public bool DeleteKhachHang(int maKH)
        {
            return daoKH.DeleteKhachHang(maKH);
        }
        public DataTable SearchKhachHang(string keyword)
        {
            // Nếu ô tìm kiếm để trống hoặc chỉ chứa dấu cách, ta tự động load lại toàn bộ danh sách
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return daoKH.GetKhachHang();
            }

            // Nếu có chữ, cắt bỏ khoảng trắng thừa ở 2 đầu rồi đẩy xuống DAO
            return daoKH.SearchKhachHang(keyword.Trim());
        }
    }
}