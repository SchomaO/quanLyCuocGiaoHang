using DTO_QuanLyCuocGiaoHang;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_QuanLyCuocGiaoHang
{
    public class DonVanChuyenDAO: DBConnect
    {
        public bool ThemDonHangMoi(DonVanChuyenDTO dh)
        {
            // Câu lệnh INSERT đẩy đủ các trường thông tin khách hàng và cước phí
            string query = @"INSERT INTO DonHang 
                             (HoTenGui, SDTGui, DiaChiGui, MaKH, HoTenNhan, SDTNhan, DiaChiNhan, TinhThanhNhan, MaDV, KhoangCach, TienCOD, TongCuoc) 
                             VALUES 
                             (@HoTenGui, @SDTGui, @DiaChiGui, @MaKH, @HoTenNhan, @SDTNhan, @DiaChiNhan, @TinhThanhNhan, @MaDV, @KhoangCach, @TienCOD, @TongCuoc)";
            try
            {
                // Mở kết nối dùng chung từ DBConnect
                OpenConnection();

                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    // Tham số người gửi
                    cmd.Parameters.AddWithValue("@HoTenGui", dh.HoTenGui);
                    cmd.Parameters.AddWithValue("@SDTGui", dh.SDTGui);
                    cmd.Parameters.AddWithValue("@DiaChiGui", dh.DiaChiGui);
                    cmd.Parameters.AddWithValue("@MaKH", string.IsNullOrEmpty(dh.MaKH) ? (object)DBNull.Value : dh.MaKH);

                    // Tham số người nhận
                    cmd.Parameters.AddWithValue("@HoTenNhan", dh.HoTenNhan);
                    cmd.Parameters.AddWithValue("@SDTNhan", dh.SDTNhan);
                    cmd.Parameters.AddWithValue("@DiaChiNhan", dh.DiaChiNhan);
                    cmd.Parameters.AddWithValue("@TinhThanhNhan", dh.TinhThanhNhan);

                    // Tham số cước phí (Lấy từ kết quả tính cước)
                    cmd.Parameters.AddWithValue("@MaDV", dh.MaDV);
                    cmd.Parameters.AddWithValue("@KhoangCach", dh.KhoangCach);
                    cmd.Parameters.AddWithValue("@TienCOD", dh.TienCOD);
                    cmd.Parameters.AddWithValue("@TongCuoc", dh.TongCuoc);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0; // Trả về true nếu chèn thành công dòng dữ liệu
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi Database khi thực hiện tạo đơn: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối an toàn
                CloseConnection();
            }
        }
    }
}
