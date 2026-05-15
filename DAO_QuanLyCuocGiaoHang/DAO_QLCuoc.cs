using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLyCuocGiaoHang;

namespace DAO_QuanLyCuocGiaoHang
{
    public class DAO_QLCuoc : DBConnect
    {
        // 1. Hàm lấy danh sách Dịch Vụ (để hiển thị lên ComboBox hoặc DataGridView)
        public DataTable GetDanhSachDichVu()
        {
            DataTable dt = new DataTable();
            try
            {
                _conn.Open();
                string query = "SELECT * FROM DichVu";
                SqlDataAdapter da = new SqlDataAdapter(query, _conn);
                da.Fill(dt);
            }
            catch (Exception)
            {
                // Xử lý lỗi nếu có
            }
            finally
            {
                _conn.Close(); // Đảm bảo luôn đóng kết nối
            }
            return dt;
        }

        // 2. Hàm Thêm một Đơn Vận Chuyển mới vào Database
        public bool ThemDonVanChuyen(string maDon, int maNguoiGui, int maNguoiNhan, int maDV,
                                     double trongLuong, double dai, double rong, double cao,
                                     double khoangCach, decimal tongCuoc, string trangThai)
        {
            string query = @"INSERT INTO DonVanChuyen (MaDon, MaNguoiGui, MaNguoiNhan, MaDV, TrongLuong, ChieuDai, ChieuRong, ChieuCao, KhoangCach, TongCuoc, TrangThai) 
                             VALUES (@MaDon, @MaNguoiGui, @MaNguoiNhan, @MaDV, @TrongLuong, @ChieuDai, @ChieuRong, @ChieuCao, @KhoangCach, @TongCuoc, @TrangThai)";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaDon", maDon);
                cmd.Parameters.AddWithValue("@MaNguoiGui", maNguoiGui);
                cmd.Parameters.AddWithValue("@MaNguoiNhan", maNguoiNhan);
                cmd.Parameters.AddWithValue("@MaDV", maDV);
                cmd.Parameters.AddWithValue("@TrongLuong", trongLuong);
                cmd.Parameters.AddWithValue("@ChieuDai", dai);
                cmd.Parameters.AddWithValue("@ChieuRong", rong);
                cmd.Parameters.AddWithValue("@ChieuCao", cao);
                cmd.Parameters.AddWithValue("@KhoangCach", khoangCach);
                cmd.Parameters.AddWithValue("@TongCuoc", tongCuoc);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                int result = cmd.ExecuteNonQuery();
                return result > 0; // Trả về true nếu thêm thành công
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
