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
        public DataTable LayDanhSachTheoDoi(string maDon, string trangThai)
        {
            string query = "SELECT MaDon AS [Mã Đơn], MocTrangThai AS [Mốc Trạng Thái], ThoiGian AS [Thời Gian], GhiChu AS [Ghi Chú] FROM LichSuTrangThai WHERE 1=1 ";

            // 2. Nếu người dùng nhập mã đơn -> Ghép thêm điều kiện lọc mã đơn
            if (!string.IsNullOrEmpty(maDon))
            {
                query += " AND MaDon = @MaDon";
            }

            // 3. Nếu người dùng chọn một trạng thái cụ thể (khác "Tất cả trạng thái") -> Ghép thêm điều kiện lọc trạng thái
            if (!string.IsNullOrEmpty(trangThai) && trangThai != "  -- Tất cả trạng thái --")
            {
                query += " AND MocTrangThai = @TrangThai";
            }

            // 4. Sắp xếp mốc mới nhất lên đầu
            query += " ORDER BY ThoiGian DESC";

            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    // Nạp tham số an toàn (SQL sẽ tự bỏ qua nếu trong query không chứa tham số đó)
                    cmd.Parameters.AddWithValue("@MaDon", maDon);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConnection();
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
        // Hàm tìm kiếm thông tin đơn hàng cụ thể để hiển thị lên Form Giao Hàng
        public DataTable TimDonHangDeGiao(string maDon)
        {
            // Lấy thông tin người nhận và trạng thái hiện tại từ bảng gốc DonVanChuyen
            string query = @"SELECT dv.TrangThai, k.MaKH, k.HoTen, k.SDT, k.DiaChi 
                     FROM DonVanChuyen dv
                     INNER JOIN KhachHang k ON dv.MaNguoiNhan = k.MaKH
                     WHERE dv.MaDon = @MaDon";
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@MaDon", maDon);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception) { return null; }
            finally { CloseConnection(); }
            return dt;
        }

        // Hàm cập nhật kép: Đổi trạng thái ở DonVanChuyen và chèn vết mới vào LichSuTrangThai
        public bool UpdateTrangThaiThucTe(string maDon, string trangThaiMoi, string ghiChu)
        {
            string query = @"
        UPDATE DonVanChuyen SET TrangThai = @TrangThaiMoi WHERE MaDon = @MaDon;
        INSERT INTO LichSuTrangThai (MaDon, MocTrangThai, ThoiGian, GhiChu) 
        VALUES (@MaDon, @TrangThaiMoi, GETDATE(), @GhiChu);";
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@MaDon", maDon);
                    cmd.Parameters.AddWithValue("@TrangThaiMoi", trangThaiMoi);
                    cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrEmpty(ghiChu) ? (object)DBNull.Value : ghiChu);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception) { return false; }
            finally { CloseConnection(); }
        }
    }
}
