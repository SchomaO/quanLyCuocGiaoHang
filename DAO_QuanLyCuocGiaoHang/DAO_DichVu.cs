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
    }
}