Create function DangNhap
(
@Username Varchar(128)= null,
@Password Varchar(128) = null
)
returns @new_table table (CMND varchar(15), VaiTro varchar (20))
AS BEGIN
declare @CMND varchar(15);
declare @vaitro varchar(20);

set @CMND = (Select d.CMND From [dbo].[NguoiDung] d where d.UserName=@Username
and d.Pass=@Password);
if (Exists(select * from [dbo].[NguoiBan] b where b.CMND=@CMND))
    begin
		set @vaitro='NguoiBan';
	end;
if (Exists(select * from [dbo].[KhachHang] b where b.CMND=@CMND))
	begin
		set @vaitro='KhachHang';
	end;
if (Exists(select * from [dbo].[KhachHang] b where b.CMND=@CMND))
	begin
		set @vaitro='admin';
	end;
insert into @new_table values(@CMND, @vaitro)
return
END
go
---select* from [dbo].[DangNhap] ('duc123', '1234')
