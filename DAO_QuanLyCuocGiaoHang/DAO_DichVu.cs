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
    public class DAO_DichVu : DBConnect
    {
        // Lấy danh sách dịch vụ để đổ vào ComboBox
        public DataTable GetDanhSachDichVu()
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                string sql = "SELECT * FROM DichVu";
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public bool UpdateGiaCuoc(DTO_DichVu dv)
        {
            try
            {
                OpenConnection();
                string sql = "UPDATE DichVu SET TenDV = @TenDV, GiaTheoKg = @GiaTheoKg, GiaTheoKm = @GiaTheoKm, PhiCoBan = @PhiCoBan, PhuPhi = @PhuPhi WHERE MaDV = @MaDV";
                SqlCommand cmd = new SqlCommand(sql, _conn);

                cmd.Parameters.AddWithValue("@MaDV", dv.MaDV);
                cmd.Parameters.AddWithValue("@TenDV", dv.TenDV);
                cmd.Parameters.AddWithValue("@GiaTheoKg", dv.GiaTheoKg);
                cmd.Parameters.AddWithValue("@GiaTheoKm", dv.GiaTheoKm);
                cmd.Parameters.AddWithValue("@PhiCoBan", dv.PhiCoBan);
                cmd.Parameters.AddWithValue("@PhuPhi", dv.PhuPhi);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
            finally { CloseConnection(); }
        }
    }
}