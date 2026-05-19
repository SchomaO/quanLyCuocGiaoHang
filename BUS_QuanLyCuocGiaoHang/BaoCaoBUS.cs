using DAO_QuanLyCuocGiaoHang;
using DTO_QuanLyCuocGiaoHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLyCuocGiaoHang
{
    // NHỚ PHẢI CÓ CHỮ "public" Ở ĐÂY NỮA
    public class BaoCaoBUS
    {
        private BaoCaoDAO _baoCaoDAO = new BaoCaoDAO();

        // Hàm 1: Đi nhờ DAO lấy danh sách từ SQL lên
        public List<BaoCaoDTO> LayDanhSachBaoCao(DateTime tuNgay, DateTime denNgay, string loaiDichVu)
        {
            // Kiểm tra logic: Ngày bắt đầu không thể lớn hơn ngày kết thúc
            if (tuNgay > denNgay)
            {
                throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc!");
            }

            // Nếu đúng hết rồi thì gọi DAO chạy lệnh SQL
            return _baoCaoDAO.LayDanhSachBaoCao(tuNgay, denNgay, loaiDichVu);
        }

        // Hàm 2: Tự động cộng dồn tiền và khoảng cách
        public ThongKeTongKetDTO TinhToanThongKe(List<BaoCaoDTO> danhSach)
        {
            ThongKeTongKetDTO tk = new ThongKeTongKetDTO();
            tk.TongSoDon = danhSach.Count;
            tk.TongDoanhThu = 0;
            tk.SoDonThanhCong = 0; // Khởi tạo bằng 0

            foreach (var item in danhSach)
            {
                // Vẫn cộng dồn tiền bình thường
                tk.TongDoanhThu += item.TongCuoc;

                // KIỂM TRA TRẠNG THÁI: Chỉ đếm những đơn đã giao xong
                // (Lưu ý: Chữ "Đã giao hàng" phải gõ y hệt như chữ bạn lưu trong SQL nhé)
                if (item.TrangThai == "Đã giao hàng" || item.TrangThai == "Đã giao thành công")
                {
                    tk.SoDonThanhCong++; // Tăng biến đếm lên 1
                }
            }

            return tk;
        }
    }
}