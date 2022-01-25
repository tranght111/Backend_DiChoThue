create Function LayTrangThaiDonHang
(@DonHangId int)
returns nvarchar(max)
AS BEGIN
declare @TrangThai varchar(30);
declare @IDMax int;
set @IDMax= (select Max(IDTrangThai) from TrangThaiDonHang where @DonHangId=DonHangId);
Set @TrangThai= (Select TrangThai from TrangThaiDonHang where IDTrangThai=@IDMax)
return @TrangThai
END

select dbo.LayTrangThaiDonHang (2)