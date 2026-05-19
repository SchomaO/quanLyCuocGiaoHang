using DTO_QuanLyCuocGiaoHang;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_QuanLyCuocGiaoHang
{
    public class BaoCaoDAO : DBConnect
    {
        public List<BaoCaoDTO> LayDanhSachBaoCao(DateTime tuNgay, DateTime denNgay, string loaiDichVu)
        {
            List<BaoCaoDTO> danhSach = new List<BaoCaoDTO>();

            // Câu lệnh truy vấn SQL JOIN 2 bảng để lấy TenDV từ bảng DichVu
            string query = @"
                SELECT 
                    dv.MaDon, 
                    dv.NgayTao, 
                    gui.HoTen AS NguoiGui, 
                    nhan.HoTen AS NguoiNhan, 
                    d.TenDV, 
                    dv.TrangThai, 
                    dv.TongCuoc
                FROM DonVanChuyen dv
                JOIN DichVu d ON dv.MaDV = d.MaDV
                JOIN KhachHang gui ON dv.MaNguoiGui = gui.MaKH
                JOIN KhachHang nhan ON dv.MaNguoiNhan = nhan.MaKH
                WHERE dv.NgayTao BETWEEN @TuNgay AND @DenNgay";

            // Nếu người dùng chọn một dịch vụ cụ thể (khác "Tất cả") thì thêm điều kiện lọc
            if (!string.IsNullOrEmpty(loaiDichVu) && loaiDichVu != "Tất cả")
            {
                query += " AND d.TenDV = @TenDV";
            }

            try
            {
                // BƯỚC 1: Gọi hàm mở kết nối từ lớp cha DBConnect
                OpenConnection();

                // BƯỚC 2: Truyền thẳng biến _conn của lớp cha vào đây
                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    // Truyền tham số để tránh SQL Injection
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                    // Lấy đến cuối ngày hôm đó (23:59:59) để không sót đơn hàng
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay.Date.AddDays(1).AddTicks(-1));

                    if (!string.IsNullOrEmpty(loaiDichVu) && loaiDichVu != "Tất cả")
                    {
                        cmd.Parameters.AddWithValue("@TenDV", loaiDichVu);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BaoCaoDTO item = new BaoCaoDTO
                            {
                                MaDon = reader["MaDon"].ToString(),
                                NgayTao = Convert.ToDateTime(reader["NgayTao"]),
                                TenNguoiGui = reader["NguoiGui"].ToString(),   // Lấy từ SQL
                                TenNguoiNhan = reader["NguoiNhan"].ToString(), // Lấy từ SQL
                                TenDV = reader["TenDV"].ToString(),
                                TrangThai = reader["TrangThai"].ToString(),    // Lấy từ SQL
                                TongCuoc = Convert.ToDecimal(reader["TongCuoc"])
                            };
                            danhSach.Add(item);
                        }
                    }
                } // Đóng using SqlCommand
            } // Đóng try
            catch (Exception ex)
            {
                // Ném lỗi lên tầng BUS để hiển thị bằng MessageBox, dễ tìm lỗi hơn là Console
                throw new Exception("Lỗi khi tải dữ liệu báo cáo từ Database: " + ex.Message);
            }
            finally
            {
                // BƯỚC 3: Đảm bảo luôn luôn đóng kết nối an toàn dù có lỗi hay không
                CloseConnection();
            }

            return danhSach;
        }
    }
}
