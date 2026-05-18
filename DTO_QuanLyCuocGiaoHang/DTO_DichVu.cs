using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyCuocGiaoHang
{
    public class DTO_DichVu
    {
        public int MaDV { get; set; }
        public string TenDV { get; set; }
        public double GiaTheoKg { get; set; }
        public double GiaTheoKm { get; set; }
        public double PhiCoBan { get; set; }
        public double PhuPhi { get; set; }

        // Constructor mặc định
        public DTO_DichVu() { }

        // Constructor đầy đủ
        public DTO_DichVu(int maDV, string tenDV, double giaTheoKg, double giaTheoKm, double phiCoBan, double phuPhi)
        {
            this.MaDV = maDV;
            this.TenDV = tenDV;
            this.GiaTheoKg = giaTheoKg;
            this.GiaTheoKm = giaTheoKm;
            this.PhiCoBan = phiCoBan;
            this.PhuPhi = phuPhi;
        }
    }
}