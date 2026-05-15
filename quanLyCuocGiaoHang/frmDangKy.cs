using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanLyCuocGiaoHang
{
    public partial class frmDangKy : Form
    {
        frmMain formChinh;
        public frmDangKy(frmMain mainForm)
        {
            InitializeComponent();
            this.formChinh = mainForm;
        }

        private void lnDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formChinh.HienThiDangNhap(); // Quay lại màn hình đăng nhập
        }
    }
}
