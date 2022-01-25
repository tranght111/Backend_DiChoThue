

Create proc DatHang
(
@PhiShip float,
@HinhThucThanhToan varchar(50),
@IDNguoiBan int,
@IDKhachHang int,
@SoLuong int,
@IDSanPham int
)
AS BEGIN
declare @IDDonHang varchar(15);
declare @TongTien varchar(20);
insert into DonHang (NgayDat,PhiShip,TongTien,HinhThucThanhToan,IDNguoiBan,IDKhachHang) 
values(getdate(),@PhiShip,NULL,@HinhThucThanhToan, @IDNguoiBan,@IDKhachHang);
set @IDDonHang=(SELECT SCOPE_IDENTITY());
insert into ChiTietDonHang (SoLuong,IDDonHang,IDSanPham) values (@SoLuong,@IDDonHang,@IDSanPham);
Set @TongTien=(select Sum((sp.GiaSP)*(ct.SoLuong))
from ChiTietDonHang ct, SanPham sp
where ct.IDSanPham = sp.IDSanPham and ct.IDDonHang=@IDDonHang);
update DonHang set TongTien = @TongTien where IDDonHang=@IDDonHang;
END
--exec DatHang 20000, TrucTiep, 5, 2, 3, 1