using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_QuanLyCuocGiaoHang
{
    public class DBConnect
    {
        // Khai báo đối tượng kết nối dùng chung cho các lớp con kế thừa
        protected SqlConnection _conn;
        // Chuỗi kết nối chuẩn, tinh gọn, chạy mượt trên mọi phiên bản .NET Framework
        private string strConnect = @"Data Source=LAPTOP-T27N71PS\MSSQLSERVER02;Initial Catalog=QuanLyCuoc;Integrated Security=True;Connect Timeout=30;"; public DBConnect()
        {
            // Khởi tạo đối tượng kết nối
            _conn = new SqlConnection(strConnect);
        }

        // Hàm hỗ trợ mở kết nối an toàn
        protected void OpenConnection()
        {
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }
        }

        // Hàm hỗ trợ đóng kết nối an toàn
        protected void CloseConnection()
        {
            if (_conn.State == ConnectionState.Open)
            {
                _conn.Close();
            }
        }
    }
}