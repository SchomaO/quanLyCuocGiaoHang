using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO_QuanLyCuocGiaoHang;

namespace DAO_QuanLyCuocGiaoHang    
{
    public partial class frmTheodoi : Form
    {
        BUS_QuanLyCuocGiaoHang.BUS_QLCuoc busQLCuoc = new BUS_QuanLyCuocGiaoHang.BUS_QLCuoc();
       
        public frmTheodoi()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string maDonInput = txtMadon.Text.Trim();

            // Lấy chữ đang hiển thị trong ComboBox trạng thái
            string trangThaiSelect = cbStatus.Text;

            // Gọi BUS truyền cả 2 điều kiện lọc
            DataTable dt = busQLCuoc.TranferDanhSachTheoDoi(maDonInput, trangThaiSelect);

            if (dt != null && dt.Rows.Count > 0)
            {
                dgvDanhsach.DataSource = dt;

                // Giữ nguyên 2 dòng chống tràn chữ của bạn ở đây
                dgvDanhsach.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDanhsach.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                dgvDanhsach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                dgvDanhsach.DataSource = null;
                MessageBox.Show("Không tìm thấy lịch sử vận chuyển khớp với điều kiện lọc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmTheodoi_Load(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = 0;
            // Đổi thành TRUE để DataGridView tự sinh cột tự động từ SQL, bách phát bách trúng
            dgvDanhsach.AutoGenerateColumns = true;

            // Gọi hàm tải toàn bộ dữ liệu ban đầu lên
            LoadDanhSach();
        }
        private void LoadDanhSach()
        {
            // Mới mở lên thì mã đơn để trống "", trạng thái là "Tất cả trạng thái" -> SQL sẽ tự hiểu lấy HẾT
            DataTable dt = busQLCuoc.TranferDanhSachTheoDoi("", "  -- Tất cả trạng thái --");

            if (dt != null && dt.Rows.Count > 0)
            {
                dgvDanhsach.DataSource = dt;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMadon.Clear();
        }
    }
}
