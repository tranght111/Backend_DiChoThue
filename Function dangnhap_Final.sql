Create function DangNhap
(
@Username Varchar(128)= null,
@Password Varchar(128) = null
)
returns @new_table table (CMND varchar(15), VaiTro varchar (20), IDnguoiDung int)
AS BEGIN
declare @CMND varchar(15);
declare @vaitro varchar(20);
declare @IDNguoiDung int;

set @CMND = (Select d.CMND From [dbo].[NguoiDung] d where d.UserName=@Username
and d.Pass=@Password);
if (Exists(select * from [dbo].[NguoiBan] b where b.CMND=@CMND))
    begin
		set @vaitro='NguoiBan';
		set @IDNguoiDung = (select IDNguoiBan from [dbo].[NguoiBan] b where b.CMND=@CMND)
	end;
if (Exists(select * from [dbo].[KhachHang] b where b.CMND=@CMND))
	begin
		set @vaitro='KhachHang';
		set @IDNguoiDung = (select IDKhachHang from [dbo].[KhachHang] b where b.CMND=@CMND)
	end;
if (Exists(select * from [dbo].[NhanVien] b where b.CMND=@CMND))
	begin
		set @vaitro='admin';
		set @IDNguoiDung = (select IDNhanVien from [dbo].[NhanVien] b where b.CMND=@CMND)
	end;
 if (Exists(select * from [dbo].[Shipper] b where b.CMND=@CMND))
	begin
		set @vaitro='shipper';
		set @IDNguoiDung = (select IDShipper from [dbo].[Shipper] b where b.CMND=@CMND)
	end;
insert into @new_table values(@CMND, @vaitro, @IDNguoiDung)
return
END
go
--select* from [dbo].[DangNhap] ('duc123', '1235')
