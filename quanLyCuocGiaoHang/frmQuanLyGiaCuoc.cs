using BUS_QuanLyCuocGiaoHang;
using DTO_QuanLyCuocGiaoHang;
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
    public partial class frmQuanLyGiaCuoc : Form
    {
        BUS_DichVu busDV = new BUS_DichVu();
        public frmQuanLyGiaCuoc()
        {
            InitializeComponent();
        }

        private void frmQuanLyGiaCuoc_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
            ResetForm();
        }
        private void LoadDanhSach()
        {
            dgvDichVu.DataSource = busDV.GetDanhSachDichVu();

            // Format cột tiền tệ trên GridView (Tuỳ chọn để đẹp hơn)
            dgvDichVu.Columns["GiaTheoKg"].DefaultCellStyle.Format = "N0";
            dgvDichVu.Columns["GiaTheoKm"].DefaultCellStyle.Format = "N0";
            dgvDichVu.Columns["PhiCoBan"].DefaultCellStyle.Format = "N0";
            dgvDichVu.Columns["PhuPhi"].DefaultCellStyle.Format = "N0";
        }

        private void ResetForm()
        {
            txtMaDV.Clear();
            txtTenDV.Clear();
            txtGiaTheoKg.Clear();
            txtGiaTheoKm.Clear();
            txtPhiCoBan.Clear();
            txtPhuPhi.Clear();

            btnSua.Enabled = false;
            btnSua.BackColor = Color.Gray;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int i = dgvDichVu.CurrentRow.Index;
                txtMaDV.Text = dgvDichVu.Rows[i].Cells["MaDV"].Value.ToString();
                txtTenDV.Text = dgvDichVu.Rows[i].Cells["TenDV"].Value.ToString();

                // Loại bỏ phần thập phân .00 khi đẩy lên TextBox để dễ nhìn
                txtGiaTheoKg.Text = Convert.ToDouble(dgvDichVu.Rows[i].Cells["GiaTheoKg"].Value).ToString("G");
                txtGiaTheoKm.Text = Convert.ToDouble(dgvDichVu.Rows[i].Cells["GiaTheoKm"].Value).ToString("G");
                txtPhiCoBan.Text = Convert.ToDouble(dgvDichVu.Rows[i].Cells["PhiCoBan"].Value).ToString("G");
                txtPhuPhi.Text = Convert.ToDouble(dgvDichVu.Rows[i].Cells["PhuPhi"].Value).ToString("G");

                btnSua.Enabled = true;
                btnSua.BackColor = Color.RoyalBlue;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDV.Text))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần điều chỉnh giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Đóng gói dữ liệu vào DTO
                int ma = Convert.ToInt32(txtMaDV.Text);
                string ten = txtTenDV.Text;
                double giaKg = Convert.ToDouble(txtGiaTheoKg.Text);
                double giaKm = Convert.ToDouble(txtGiaTheoKm.Text);
                double phiCB = Convert.ToDouble(txtPhiCoBan.Text);
                double phuPhi = Convert.ToDouble(txtPhuPhi.Text);

                DTO_DichVu dv = new DTO_DichVu(ma, ten, giaKg, giaKm, phiCB, phuPhi);

                // Gọi BUS xử lý
                if (busDV.UpdateGiaCuoc(dv))
                {
                    MessageBox.Show("Đã cập nhật bảng giá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSach();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Lỗi cập nhật. Vui lòng kiểm tra lại số liệu (không nhập số âm).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng chỉ nhập số vào các ô giá tiền!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
