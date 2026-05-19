using DTO_QuanLyCuocGiaoHang;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_QuanLyCuocGiaoHang
{
    public class BaoCaoDAO
    {
        // Nhớ đổi chuỗi kết nối này trùng với tên SQL Server trên máy của bạn nhé
        private string connectionString = "Data Source=DESKTOP-5K1RTKO;Initial Catalog=QuanLyCuoc;Integrated Security=True";

        public List<BaoCaoDTO> LayDanhSachBaoCao(DateTime tuNgay, DateTime denNgay, string loaiDichVu)
        {
            List<BaoCaoDTO> danhSach = new List<BaoCaoDTO>();

            // Câu lệnh truy vấn SQL JOIN 2 bảng để lấy TenDV từ bảng DichVu
            string query = "SELECT dv.MaDon, dv.NgayTao, d.TenDV, dv.KhoangCach, dv.TongCuoc " +
                           "FROM DonVanChuyen dv INNER JOIN DichVu d ON dv.MaDV = d.MaDV " +
                           "WHERE dv.NgayTao BETWEEN @TuNgay AND @DenNgay";

            // Nếu người dùng chọn một dịch vụ cụ thể (khác "Tất cả") thì thêm điều kiện lọc
            if (!string.IsNullOrEmpty(loaiDichVu) && loaiDichVu != "Tất cả")
            {
                query += " AND d.TenDV = @TenDV";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Truyền tham số để tránh SQL Injection
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay.Date);

                    // Lấy đến cuối ngày hôm đó (23 giờ 59 phút 59 giây) để không sót đơn hàng
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay.Date.AddDays(1).AddTicks(-1));

                    if (!string.IsNullOrEmpty(loaiDichVu) && loaiDichVu != "Tất cả")
                    {
                        cmd.Parameters.AddWithValue("@TenDV", loaiDichVu);
                    }

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BaoCaoDTO item = new BaoCaoDTO
                            {
                                MaDon = reader["MaDon"].ToString(),
                                NgayTao = Convert.ToDateTime(reader["NgayTao"]),
                                TenDV = reader["TenDV"].ToString(),
                                KhoangCach = Convert.ToDouble(reader["KhoangCach"]),
                                TongCuoc = Convert.ToDecimal(reader["TongCuoc"])
                            };
                            danhSach.Add(item);
                        }
                    }
                }
            }
            return danhSach;
        }
    }
}
