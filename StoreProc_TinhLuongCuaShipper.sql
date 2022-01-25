Create proc TinhLuongShipper
(@IDShipper int, @Thang int, @Nam int)
AS 
BEGIN
declare @SoDonHang int;
declare @tienthem float=0;
declare @TongLuong float;
set @SoDonHang= (Select count(dh.IDDonHang) 
				from [dbo].[DonHang] dh 
				where dh.IDShipper=@IDShipper 
				and Month (dh.NgayDat)=@Thang and Year (dh.NgayDat)=@Nam)
if(@SoDonHang>600)
	Set @TongLuong= (600*15000 + (600-@SoDonHang)*20000);
else
	Set @TongLuong=@SoDonHang*15000;
	
insert into [dbo].[LuongShipper] (Thang, Nam, TongLuong, TrangThai, NgayNhan, IDShipper)
 values (@Thang,@Nam,@TongLuong,Null, Null,@IDShipper)

 Select ng.HoTen, l.Thang, l.Nam, l.TongLuong from [dbo].[LuongShipper] l, [dbo].[Shipper] s, [dbo].[NguoiDung] ng
 where l.IDShipper=s.IDShipper and s.IDShipper=@IDShipper and s.CMND=ng.CMND

END
--exec TinhLuongShipper 1, 1, 2022