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
        protected readonly string strConn = ConfigurationManager.ConnectionStrings["QL_CuocGiaoHang"]?.ConnectionString;
        protected SqlConnection _conn;

        public DBConnect()
        {
            if (string.IsNullOrEmpty(strConn))
            {
                throw new Exception("Chưa cấu hình chuỗi kết nối 'QL_CuocGiaoHang' trong App.config!");
            }
            _conn = new SqlConnection(strConn);
        }
        protected void OpenConnection()
        {
            if (_conn.State == ConnectionState.Closed)
                _conn.Open();
        }

        protected void CloseConnection()
        {
            if (_conn.State == ConnectionState.Open)
                _conn.Close();
        }
    }
}
