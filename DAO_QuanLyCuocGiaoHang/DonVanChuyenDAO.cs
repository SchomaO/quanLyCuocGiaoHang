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
            // 1. Câu lệnh SQL khớp hoàn toàn với các Parameters ở dưới
            string query = @"INSERT INTO DonVanChuyen 
                     (MaDon, MaNguoiGui, MaNguoiNhan, MaDV, TrongLuong, ChieuDai, ChieuRong, ChieuCao, KhoangCach, TongCuoc, TrangThai, NgayTao) 
                     VALUES 
                     (@MaDon, @MaNguoiGui, @MaNguoiNhan, @MaDV, @TrongLuong, @ChieuDai, @ChieuRong, @ChieuCao, @KhoangCach, @TongCuoc, N'Chờ xử lý', GETDATE())";
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    // 2. Phải thêm ĐỦ và ĐÚNG tên tham số như trong câu lệnh SQL ở trên
                    cmd.Parameters.AddWithValue("@MaDon", "HD" + DateTime.Now.Ticks.ToString().Substring(10));

                    // LƯU Ý: Đây là ID (INT), bạn phải có logic lấy ID từ tên khách hàng 
                    // Nếu bảng DonVanChuyen của bạn đã được thiết kế lại để lưu tên trực tiếp, hãy đổi @MaNguoiGui thành @HoTenGui
                    cmd.Parameters.AddWithValue("@MaNguoiGui", 1); // Thay 1 bằng biến ID thực tế của bạn
                    cmd.Parameters.AddWithValue("@MaNguoiNhan", 2); // Thay 2 bằng biến ID thực tế của bạn

                    cmd.Parameters.AddWithValue("@MaDV", dh.MaDV);
                    cmd.Parameters.AddWithValue("@TrongLuong", dh.TrongLuong);
                    cmd.Parameters.AddWithValue("@ChieuDai", dh.ChieuDai);
                    cmd.Parameters.AddWithValue("@ChieuRong", dh.ChieuRong);
                    cmd.Parameters.AddWithValue("@ChieuCao", dh.ChieuCao);
                    cmd.Parameters.AddWithValue("@KhoangCach", dh.KhoangCach);
                    cmd.Parameters.AddWithValue("@TongCuoc", dh.TongCuoc);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi Database: " + ex.Message);
            }
            finally { CloseConnection(); }
        }
    }
}
