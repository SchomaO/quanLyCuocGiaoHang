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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace quanLyCuocGiaoHang
{
    public partial class frmBaoCao : Form
    {
        // Khai báo đối tượng tầng BUS
        private BaoCaoBUS _baoCaoBUS = new BaoCaoBUS();
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvBaoCao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            // Nạp dữ liệu ban đầu cho ComboBox loại dịch vụ
            cboLoaiDichVu.Items.Clear();
            cboLoaiDichVu.Items.Add("Tất cả");
            cboLoaiDichVu.Items.Add("Chuyển phát tiêu chuẩn");
            cboLoaiDichVu.Items.Add("Chuyển phát nhanh");
            cboLoaiDichVu.Items.Add("Hỏa tốc nội đô");

            cboLoaiDichVu.SelectedIndex = 0;
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy các giá trị người dùng vừa chọn trên Form
                DateTime tuNgay = dtpTuNgay.Value;
                DateTime denNgay = dtpDenNgay.Value;
                string loaiDichVu = cboLoaiDichVu.SelectedItem?.ToString();

                // 1. Gọi BUS để lấy dữ liệu đơn hàng
                List<BaoCaoDTO> danhSach = _baoCaoBUS.LayDanhSachBaoCao(tuNgay, denNgay, loaiDichVu);
                // 2. Đổ danh sách tìm được lên lưới dữ liệu DataGridView
                dgvBaoCao.DataSource = danhSach;
                dgvBaoCao.AutoGenerateColumns = true;
                // 1. Đổi tên tiêu đề cột sang Tiếng Việt có dấu
                dgvBaoCao.Columns["MaDon"].HeaderText = "Mã Đơn";
                dgvBaoCao.Columns["NgayTao"].HeaderText = "Ngày Tạo";
                dgvBaoCao.Columns["TenDV"].HeaderText = "Dịch Vụ";
                dgvBaoCao.Columns["KhoangCach"].HeaderText = "Khoảng Cách (km)";
                dgvBaoCao.Columns["TongCuoc"].HeaderText = "Tổng Cước (VNĐ)";

                /* NẾU BẠN ĐÃ LÀM BƯỚC THÊM CỘT SQL Ở TIN NHẮN TRƯỚC, HÃY BỎ DẤU // Ở 3 DÒNG DƯỚI NÀY:
                dgvBaoCao.Columns["TenNguoiGui"].HeaderText = "Người Gửi";
                dgvBaoCao.Columns["TenNguoiNhan"].HeaderText = "Người Nhận";
                dgvBaoCao.Columns["TrangThai"].HeaderText = "Trạng Thái";
                */

                // 2. Định dạng Ngày tháng và Tiền tệ
                // Ngày tháng chuẩn Việt Nam (Ngày/Tháng/Năm Giờ:Phút)
                dgvBaoCao.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                // Tiền tệ có dấu phẩy ngăn cách hàng nghìn (VD: 246,600)
                dgvBaoCao.Columns["TongCuoc"].DefaultCellStyle.Format = "N0";

                // 3. Căn lề cho chuyên nghiệp (Kế toán thích điều này)
                // Số tiền luôn phải căn phải
                dgvBaoCao.Columns["TongCuoc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // Tiêu đề cột tiền cũng căn phải cho đồng bộ
                dgvBaoCao.Columns["TongCuoc"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Khoảng cách căn giữa
                dgvBaoCao.Columns["KhoangCach"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // 4. Chỉnh kích thước cột tự động giãn đều lấp đầy form (không bị cắt chữ nữa)
                dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // (Tùy chọn) Có thể ép cột Mã Đơn nhỏ lại một chút cho đẹp
                dgvBaoCao.Columns["MaDon"].FillWeight = 80;

                // ================= KẾT THÚC ĐOẠN CODE LÀM ĐẸP =================

                // 3. Gọi BUS để tính toán các con số tổng kết ở dưới... (code tiếp theo của bạn)
                // 3. Gọi BUS để tính toán các con số tổng kết ở dưới
                ThongKeTongKetDTO thongKe = _baoCaoBUS.TinhToanThongKe(danhSach);
                dgvBaoCao.DataSource = danhSach;
                // 4. In các con số đã tính lên các Label trên giao diện
                lblTongSoDon.Text = $"Tổng số đơn : {thongKe.TongSoDon}";
                lblTongDoanhThu.Text = $"Tổng Doanh Thu : {thongKe.TongDoanhThu:N0} VNĐ";
                lblSoDonThanhCong.Text = $"Số Đơn Thành Công : {thongKe.SoDonThanhCong} đơn";
            }
            catch (ArgumentException ex)
            {
                // Hiển thị cảnh báo nếu người dùng nhập sai logic ngày tháng
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi hệ thống nếu mất kết nối SQL hoặc sai tên cột...
                MessageBox.Show("Lỗi hệ thống khi tải báo cáo: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem trên lưới DataGridView đã có dữ liệu chưa
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu hiển thị trên lưới để xuất file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Khởi tạo công cụ chọn nơi lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xls)|*.xls"; // Chỉ cho phép đuôi .xls
            saveFileDialog.FileName = "BaoCaoDoanhThu_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xls"; // Tên file gợi ý sẵn

            // 3. Nếu người dùng chọn chỗ lưu và bấm nút [Save] trên cửa sổ Windows
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // Ép Excel đọc font UTF-8 để không bị lỗi font Tiếng Việt có dấu
                    sb.AppendLine("<meta http-equiv='Content-Type' content='text/html; charset=utf-8'/>");
                    sb.AppendLine("<table border='1' style='font-family:Arial; border-collapse:collapse;'>");

                    // Tạo dòng tiêu đề cột (Header) có màu nền cho đẹp
                    sb.AppendLine("<tr style='background-color:#3b82f6; color:white; font-weight:bold;'>");
                    foreach (DataGridViewColumn col in dgvBaoCao.Columns)
                    {
                        sb.AppendLine($"<th style='padding:5px;'>{col.HeaderText}</th>");
                    }
                    sb.AppendLine("</tr>");

                    // Duyệt qua từng dòng dữ liệu trên lưới để đổ vào file
                    foreach (DataGridViewRow row in dgvBaoCao.Rows)
                    {
                        if (row.IsNewRow) continue; // Bỏ qua dòng trống cuối cùng của lưới

                        sb.AppendLine("<tr>");
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            sb.AppendLine($"<td style='padding:5px;'>{cell.Value?.ToString()}</td>");
                        }
                        sb.AppendLine("</tr>");
                    }
                    sb.AppendLine("</table>");

                    // Tiến hành ghi file xuống ổ đĩa tại đường dẫn mà người dùng đã chọn
                    System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("Xuất báo cáo Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi ghi file Excel: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất file PDF!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.FileName = "BaoCaoBưuCục_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 1. Khởi tạo Document PDF khổ giấy A4
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

                    // 2. Tạo luồng ghi file vào đường dẫn người dùng chọn
                    PdfWriter.GetInstance(pdfDoc, new FileStream(saveFileDialog.FileName, FileMode.Create));

                    pdfDoc.Open();

                    // Mẹo xử lý lỗi font Tiếng Việt trong PDF: Lấy font Arial có sẵn của hệ điều hành Windows
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");
                    BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontBody = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                    // 3. Thêm tiêu đề trang báo cáo
                    Paragraph title = new Paragraph("BÁO CÁO KINH DOANH & HOẠT ĐỘNG BƯU CỤC\n\n", fontTitle);
                    title.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(title);

                    // 4. Tạo bảng PDF chứa số lượng cột bằng đúng DataGridView
                    PdfPTable pdfTable = new PdfPTable(dgvBaoCao.Columns.Count);
                    pdfTable.WidthPercentage = 100; // Giãn rộng lấp đầy trang giấy

                    // Đổ tên cột vào hàng đầu tiên của bảng PDF
                    foreach (DataGridViewColumn col in dgvBaoCao.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText, fontBody));
                        cell.BackgroundColor = new BaseColor(240, 240, 240); // Đổi nền xám nhạt cho cột tiêu đề
                        pdfTable.AddCell(cell);
                    }

                    // Đổ dữ liệu từ lưới vào bảng PDF
                    foreach (DataGridViewRow row in dgvBaoCao.Rows)
                    {
                        if (row.IsNewRow) continue;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(new Phrase(cell.Value?.ToString(), fontBody));
                        }
                    }

                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();

                    MessageBox.Show("Xuất file PDF thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file PDF: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    }
