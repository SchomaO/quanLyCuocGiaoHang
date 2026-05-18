using DTO_QuanLyCuocGiaoHang;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_QuanLyCuocGiaoHang
{
    public class DonVanChuyenDAO
    {
        // Nhớ đổi tên DESKTOP-5K1RTK0 thành tên SQL Server trên máy của bạn nếu cần
        private string connectionString = @"Data Source=DESKTOP-5K1RTK0;Initial Catalog=QuanLyCuoc;Integrated Security=True";

        public bool ThemDonHang(DonVanChuyenDTO don)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Gán cứng số 0 vào vị trí cột TrongLuong trong câu lệnh INSERT
                string query = @"INSERT INTO DonVanChuyen (MaDon, MaNguoiGui, MaNguoiNhan, MaDV, TrongLuong, ChieuDai, ChieuRong, ChieuCao, KhoangCach, TongCuoc, TrangThai) 
                                 VALUES (@MaDon, @MaNguoiGui, @MaNguoiNhan, @MaDV, 0, @ChieuDai, @ChieuRong, @ChieuCao, @KhoangCach, @TongCuoc, @TrangThai)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDon", don.MaDon);
                    cmd.Parameters.AddWithValue("@MaNguoiGui", don.MaNguoiGui);
                    cmd.Parameters.AddWithValue("@MaNguoiNhan", don.MaNguoiNhan);
                    cmd.Parameters.AddWithValue("@MaDV", don.MaDV);
                    cmd.Parameters.AddWithValue("@ChieuDai", don.ChieuDai);
                    cmd.Parameters.AddWithValue("@ChieuRong", don.ChieuRong);
                    cmd.Parameters.AddWithValue("@ChieuCao", don.ChieuCao);
                    cmd.Parameters.AddWithValue("@KhoangCach", don.KhoangCach);
                    cmd.Parameters.AddWithValue("@TongCuoc", don.TongCuoc);
                    cmd.Parameters.AddWithValue("@TrangThai", don.TrangThai);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
    }
}
