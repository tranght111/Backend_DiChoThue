alter table [dbo].[DonHang] add IDShipper  int

alter table [dbo].[DonHang] add constraint  DonHang_Shipper_FK
foreign key (IDShipper) references [dbo].[Shipper] (IDShipper)