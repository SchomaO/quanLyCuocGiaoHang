using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO_QuanLyCuocGiaoHang;
using DTO_QuanLyCuocGiaoHang;

namespace BUS_QuanLyCuocGiaoHang
{
    public class BUS_QLCuoc
    {
        // Khởi tạo đối tượng tầng DAO để gọi các hàm xử lý database
        private DAO_QLCuoc daoQLCuoc = new DAO_QLCuoc();

        /// <summary>
        /// Lấy danh sách dịch vụ từ tầng DAO để hiển thị lên GUI (ví dụ: ComboBox)
        /// </summary>
        public DataTable LayDanhSachDichVu()
        {
            return daoQLCuoc.GetDanhSachDichVu();
        }

        /// <summary>
        /// Hàm xử lý logic: Tính toán tổng cước dựa trên công thức logistic và các thông số dịch vụ
        /// </summary>
        /// <param name="trongLuong">W_actual (kg)</param>
        /// <param name="dai">L (cm)</param>
        /// <param name="rong">W (cm)</param>
        /// <param name="cao">H (cm)</param>
        /// <param name="khoangCach">K_dist (km)</param>
        /// <param name="giaTheoKg">Đơn giá theo trọng lượng từ bảng DichVu</param>
        /// <param name="giaTheoKm">U_price từ bảng DichVu</param>
        /// <param name="phiCoBan">P_base từ bảng DichVu</param>
        /// <param name="phuPhi">S_serv từ bảng DichVu</param>
        /// <returns>Tổng tiền cước (decimal)</returns>
        public decimal TinhTongCuoc(double trongLuong, double dai, double rong, double cao, double khoangCach,
                                    decimal giaTheoKg, decimal giaTheoKm, decimal phiCoBan, decimal phuPhi)
        {
            // 1. Tính trọng lượng quy đổi thể tích (W_vol) theo chuẩn logistic đường bộ: (Dài x Rộng x Cao) / 5000
            double trongLuongQuyDoi = (dai * rong * cao) / 5000.0;

            // 2. Trọng lượng tính cước là số lớn hơn giữa Trọng lượng thực tế (W_actual) và Trọng lượng quy đổi (W_vol)
            double trongLuongTinhToan = Math.Max(trongLuong, trongLuongQuyDoi);

            // 3. Tính toán các thành phần cước
            // Cước trọng lượng = Trọng lượng tính toán * Đơn giá theo Kg
            decimal cuocTrongLuong = (decimal)trongLuongTinhToan * giaTheoKg;

            // Cước khoảng cách = Khoảng cách (K_dist) * Đơn giá theo Km (U_price)
            decimal cuocKhoangCach = (decimal)khoangCach * giaTheoKm;

            // 4. Áp dụng công thức tổng: Total Fee = Cước Trọng Lượng + Cước Khoảng Cách + P_base + S_serv
            decimal tongCuoc = cuocTrongLuong + cuocKhoangCach + phiCoBan + phuPhi;

            return tongCuoc;
        }

        /// <summary>
        /// Tiếp nhận yêu cầu thêm đơn hàng từ GUI, kiểm tra ràng buộc logic rồi chuyển xuống DAO để lưu
        /// </summary>
        public bool ThemDonVanChuyenMoi(string maDon, int maNguoiGui, int maNguoiNhan, int maDV,
                                        double trongLuong, double dai, double rong, double cao,
                                        double khoangCach, decimal tongCuoc, string trangThai)
        {
            // Kiểm tra ràng buộc logic dữ liệu đầu vào (Validation) trước khi lưu
            if (string.IsNullOrEmpty(maDon))
            {
                return false; // Mã đơn không được để trống
            }

            if (trongLuong <= 0 || khoangCach <= 0)
            {
                return false; // Khối lượng và khoảng cách phải lớn hơn 0
            }

            // Nếu mọi logic hợp lệ, gọi tầng DAO để chèn vào cơ sở dữ liệu SQL Server
            return daoQLCuoc.ThemDonVanChuyen(maDon, maNguoiGui, maNguoiNhan, maDV, trongLuong, dai, rong, cao, khoangCach, tongCuoc, trangThai);
        }
        public DataTable TranferDanhSachTheoDoi(string maDon, string trangThai)
        {
            // Bốc dữ liệu từ GUI và chuyển thẳng xuống DAO xử lý
            return daoQLCuoc.LayDanhSachTheoDoi(maDon.Trim(), trangThai);
        }
    }
}
