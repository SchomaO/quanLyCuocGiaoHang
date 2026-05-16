using DAO_QuanLyCuocGiaoHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLyCuocGiaoHang
{
    public class BUS_DichVu
    {
        DAO_DichVu daoDV = new DAO_DichVu();

        // Gọi DAO để lấy danh sách
        public DataTable GetDanhSachDichVu()
        {
            return daoDV.GetDanhSachDichVu();
        }

        // --- CÁC HÀM XỬ LÝ NGHIỆP VỤ TÍNH TOÁN ---

        // 1. Hàm tính Trọng lượng quy đổi theo thể tích (W_vol)
        public double TinhTrongLuongQuyDoi(double l, double w, double h)
        {
            // Công thức: (Dài x Rộng x Cao) / 5000
            return (l * w * h) / 5000.0;
        }

        // 2. Hàm tìm Trọng lượng tính phí (W)
        public double TimTrongLuongTinhPhi(double w_actual, double w_vol)
        {
            // Lấy giá trị lớn nhất giữa thực tế và quy đổi
            return Math.Max(w_actual, w_vol);
        }

        // 3. Hàm ráp công thức ra Tổng cước cuối cùng
        public double TinhTongCuoc(double w_final, double k_dist, double giaTheoKm, double phiCoBan, double phuPhi)
        {
            // Total Fee = P_base + (W * U_price * K_dist) + S_serv
            return phiCoBan + (w_final * giaTheoKm * k_dist) + phuPhi;
        }
    }
}