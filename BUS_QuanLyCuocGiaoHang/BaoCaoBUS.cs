using DAO_QuanLyCuocGiaoHang;
using DTO_QuanLyCuocGiaoHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLyCuocGiaoHang
{
    public class BaoCaoBUS
    {
        private BaoCaoDAO _baoCaoDAO = new BaoCaoDAO();

        public List<BaoCaoDTO> LayDanhSachBaoCao(DateTime tuNgay, DateTime denNgay, string loaiDichVu)
        {
            // Kiểm tra tính logic của thời gian trước khi gọi xuống Database
            if (tuNgay > denNgay)
            {
                throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc!");
            }

            return _baoCaoDAO.LayDanhSachBaoCao(tuNgay, denNgay, loaiDichVu);
        }

        // Logic duyệt danh sách để tính toán 3 thông số tổng kết ở dưới form
        public ThongKeTongKetDTO TinhToanThongKe(List<BaoCaoDTO> danhSach)
        {
            ThongKeTongKetDTO thongKe = new ThongKeTongKetDTO
            {
                TongSoDon = danhSach.Count,
                TongDoanhThu = 0,
                TongKhoangCach = 0
            };

            foreach (var item in danhSach)
            {
                thongKe.TongDoanhThu += item.TongCuoc; // Cộng dồn cột TongCuoc
                thongKe.TongKhoangCach += item.KhoangCach; // Cộng dồn cột KhoangCach
            }

            return thongKe;
        }
    }
}
