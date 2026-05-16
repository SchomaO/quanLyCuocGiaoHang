using DTO_QuanLyCuocGiaoHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_QuanLyCuocGiaoHang
{
    public class DAO_KhachHang : DBConnect
    {
        // 1. Hàm lấy danh sách khách hàng lên DataGridView
        public DataTable GetKhachHang()
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM KhachHang", _conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            finally { CloseConnection(); }
            return dt;
        }

        // 2. Hàm thêm khách hàng
        public bool AddKhachHang(DTO_KhachHang kh)
        {
            try
            {
                OpenConnection();
                string sql = "INSERT INTO KhachHang(HoTen, SDT, DiaChi) VALUES(@HoTen, @SDT, @DiaChi)";
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@HoTen", kh.HoTen);
                cmd.Parameters.AddWithValue("@SDT", kh.SDT);
                cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
            finally { CloseConnection(); }
        }
        // 3. Hàm Sửa (Cập nhật) thông tin khách hàng
        public bool UpdateKhachHang(DTO_KhachHang kh)
        {
            try
            {
                OpenConnection();
                // Câu lệnh UPDATE dựa vào MaKH
                string sql = "UPDATE KhachHang SET HoTen = @HoTen, SDT = @SDT, DiaChi = @DiaChi WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(sql, _conn);

                cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
                cmd.Parameters.AddWithValue("@HoTen", kh.HoTen);
                cmd.Parameters.AddWithValue("@SDT", kh.SDT);
                cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
            finally { CloseConnection(); }
        }

        // 4. Hàm Xóa khách hàng
        public bool DeleteKhachHang(int maKH)
        {
            try
            {
                OpenConnection();
                // Câu lệnh DELETE dựa vào MaKH
                string sql = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                SqlCommand cmd = new SqlCommand(sql, _conn);

                cmd.Parameters.AddWithValue("@MaKH", maKH);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch
            {
                // Lỗi thường xảy ra ở đây do dính Khóa Ngoại (Khách hàng này đã có đơn vận chuyển)
                return false;
            }
            finally { CloseConnection(); }
        }
        public DataTable SearchKhachHang(string keyword)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                // Tìm những khách hàng có Họ Tên hoặc SĐT chứa từ khóa
                string sql = "SELECT * FROM KhachHang WHERE HoTen LIKE @Keyword OR SDT LIKE @Keyword";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                // Thêm dấu % ở hai đầu để tìm kiếm chứa chuỗi (chữ hoa/thường đều được)
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {
                // Bỏ qua lỗi nếu có
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

    }
}
