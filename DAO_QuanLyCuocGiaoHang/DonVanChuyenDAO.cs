using DTO_QuanLyCuocGiaoHang;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_QuanLyCuocGiaoHang
{
    public class DonVanChuyenDAO: DBConnect
    {
        public bool ThemDonHangMoi(DonVanChuyenDTO dh)
        {
            string query = @"
    -- 1. TÌM MÃ ĐƠN HÀNG LỚN NHẤT HIỆN CÓ
    DECLARE @NextID INT = 0;
    
    SELECT @NextID = ISNULL(MAX(CAST(SUBSTRING(MaDon, 3, 20) AS INT)), 0)
    FROM DonVanChuyen 
    WHERE MaDon LIKE 'HD%' AND ISNUMERIC(SUBSTRING(MaDon, 3, 20)) = 1;

    SET @NextID = @NextID + 1;
    DECLARE @MaDonMoi VARCHAR(20) = 'HD' + RIGHT('000' + CAST(@NextID AS VARCHAR), 3);

    -- VÒNG LẶP CHỐNG TRÙNG LẶP (Chìa khóa sửa lỗi)
    -- Nếu phát hiện mã đã tồn tại, tự động cộng thêm 1 số nữa
    WHILE EXISTS (SELECT 1 FROM DonVanChuyen WHERE MaDon = @MaDonMoi)
    BEGIN
        SET @NextID = @NextID + 1;
        SET @MaDonMoi = 'HD' + RIGHT('000' + CAST(@NextID AS VARCHAR), 3);
    END

    -- 2. XỬ LÝ KHÁCH GỬI (Nếu trống -> Tạo mới, Nếu có mã -> Dùng mã cũ)
    DECLARE @IDGui INT;
    IF @MaKH = '' OR @MaKH = '-1' 
    BEGIN
        INSERT INTO KhachHang (HoTen, SDT, DiaChi) VALUES (@HoTenGui, @SDTGui, @DiaChiGui);
        SET @IDGui = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        SET @IDGui = CAST(@MaKH AS INT);
    END

    -- 3. XỬ LÝ KHÁCH NHẬN (Luôn tạo mới)
    INSERT INTO KhachHang (HoTen, SDT, DiaChi) VALUES (@HoTenNhan, @SDTNhan, @DiaChiNhan);
    DECLARE @IDNhan INT = SCOPE_IDENTITY();

    -- 4. LƯU VÀO ĐƠN VẬN CHUYỂN
    INSERT INTO DonVanChuyen 
    (MaDon, MaNguoiGui, MaNguoiNhan, MaDV, TrongLuong, ChieuDai, ChieuRong, ChieuCao, KhoangCach, TongCuoc, TrangThai, NgayTao) 
    VALUES 
    (@MaDonMoi, @IDGui, @IDNhan, @MaDV, @TrongLuong, @ChieuDai, @ChieuRong, @ChieuCao, @KhoangCach, @TongCuoc, N'Chưa xử lý', GETDATE());
";

            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    // Tham số Khách Gửi
                    cmd.Parameters.AddWithValue("@HoTenGui", dh.HoTenGui);
                    cmd.Parameters.AddWithValue("@SDTGui", dh.SDTGui);
                    cmd.Parameters.AddWithValue("@DiaChiGui", dh.DiaChiGui);
                    cmd.Parameters.AddWithValue("@MaKH", string.IsNullOrEmpty(dh.MaKH) ? "" : dh.MaKH);

                    // Tham số Khách Nhận
                    cmd.Parameters.AddWithValue("@HoTenNhan", dh.HoTenNhan);
                    cmd.Parameters.AddWithValue("@SDTNhan", dh.SDTNhan);
                    cmd.Parameters.AddWithValue("@DiaChiNhan", dh.DiaChiNhan);

                    // Tham số Đơn hàng
                    cmd.Parameters.AddWithValue("@MaDV", dh.MaDV);
                    cmd.Parameters.AddWithValue("@TrongLuong", dh.TrongLuong);
                    cmd.Parameters.AddWithValue("@ChieuDai", dh.ChieuDai);
                    cmd.Parameters.AddWithValue("@ChieuRong", dh.ChieuRong);
                    cmd.Parameters.AddWithValue("@ChieuCao", dh.ChieuCao);
                    cmd.Parameters.AddWithValue("@KhoangCach", dh.KhoangCach);
                    cmd.Parameters.AddWithValue("@TongCuoc", dh.TongCuoc);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi Database: " + ex.Message);
            }
            finally { CloseConnection(); }
        }
    }
}
