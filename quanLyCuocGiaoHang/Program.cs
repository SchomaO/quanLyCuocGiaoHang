using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLyCuocGiaoHang;
using DAO_QuanLyCuocGiaoHang;

namespace quanLyCuocGiaoHang
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new frmMain());
=======
            Application.Run(new frmBaoCao());
>>>>>>> 3ee5da530189b270b8fa3463e1d63fe245c795c1
        }
    }
}
