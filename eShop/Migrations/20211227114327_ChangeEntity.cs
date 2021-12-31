using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.Migrations
{
    public partial class ChangeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_DonHang_DonHangId",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_SanPham_SanPhamId",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DoanhThuNguoiBan_NguoiBan_NguoiBanId",
                table: "DoanhThuNguoiBan");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_KhachHang_KhachHangId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_NguoiBan_NguoiBanId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageSanPham_SanPham_SanPhamId",
                table: "ImageSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_LuongShipper_Shipper_ShipperId",
                table: "LuongShipper");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiBan_User_CMNND",
                table: "NguoiBan");

            migrationBuilder.DropForeignKey(
                name: "FK_PhiHoaHongNguoiBan_NguoiBan_NguoiBanId",
                table: "PhiHoaHongNguoiBan");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_LoaiSanPham_LoaiSanPhamIDLoaiSP",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_NguoiBan_NguoiBanId",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanhToan_User_NguoiDungCMND",
                table: "ThanhToan");

            migrationBuilder.DropForeignKey(
                name: "FK_TrangThaiDonHang_DonHang_DonHangId",
                table: "TrangThaiDonHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrangThaiDonHang",
                table: "TrangThaiDonHang");

            migrationBuilder.DropIndex(
                name: "IX_TrangThaiDonHang_DonHangId",
                table: "TrangThaiDonHang");

            migrationBuilder.DropIndex(
                name: "IX_ThanhToan_NguoiDungCMND",
                table: "ThanhToan");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_LoaiSanPhamIDLoaiSP",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhiHoaHongNguoiBan",
                table: "PhiHoaHongNguoiBan");

            migrationBuilder.DropIndex(
                name: "IX_NguoiBan_CMNND",
                table: "NguoiBan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LuongShipper",
                table: "LuongShipper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiSanPham",
                table: "LoaiSanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageSanPham",
                table: "ImageSanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoanhThuNguoiBan",
                table: "DoanhThuNguoiBan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhGiaSanPham",
                table: "DanhGiaSanPham");

            migrationBuilder.DropColumn(
                name: "IDTrangThai",
                table: "TrangThaiDonHang");

            migrationBuilder.DropColumn(
                name: "IDDonHang",
                table: "TrangThaiDonHang");

            migrationBuilder.DropColumn(
                name: "NguoiDungCMND",
                table: "ThanhToan");

            migrationBuilder.DropColumn(
                name: "IDLoaiSP",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "IDNguoiBan",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "LoaiSanPhamIDLoaiSP",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "IDPhiHoaHong",
                table: "PhiHoaHongNguoiBan");

            migrationBuilder.DropColumn(
                name: "IDNguoiBan",
                table: "PhiHoaHongNguoiBan");

            migrationBuilder.DropColumn(
                name: "CMNND",
                table: "NguoiBan");

            migrationBuilder.DropColumn(
                name: "IDLuong",
                table: "LuongShipper");

            migrationBuilder.DropColumn(
                name: "IDShipper",
                table: "LuongShipper");

            migrationBuilder.DropColumn(
                name: "IDLoaiSP",
                table: "LoaiSanPham");

            migrationBuilder.DropColumn(
                name: "IDImageSP",
                table: "ImageSanPham");

            migrationBuilder.DropColumn(
                name: "IDSanPham",
                table: "ImageSanPham");

            migrationBuilder.DropColumn(
                name: "IDKhachHang",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "IDNguoiBan",
                table: "DonHang");

            migrationBuilder.DropColumn(
                name: "IDDoanhThu",
                table: "DoanhThuNguoiBan");

            migrationBuilder.DropColumn(
                name: "IDNguoiBan",
                table: "DoanhThuNguoiBan");

            migrationBuilder.DropColumn(
                name: "IDDanhGiaSP",
                table: "DanhGiaSanPham");

            migrationBuilder.DropColumn(
                name: "IDDonHang",
                table: "ChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "IDSanPham",
                table: "ChiTietDonHang");

            migrationBuilder.AlterColumn<string>(
                name: "DonHangId",
                table: "TrangThaiDonHang",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrangThaiDonHangId",
                table: "TrangThaiDonHang",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DonHangId1",
                table: "TrangThaiDonHang",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CMND",
                table: "ThanhToan",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NguoiBanId",
                table: "SanPham",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoaiSanPhamId",
                table: "SanPham",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "NguoiBanId",
                table: "PhiHoaHongNguoiBan",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhiHoaHongNguoiBanId",
                table: "PhiHoaHongNguoiBan",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CMND",
                table: "NguoiBan",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShipperId",
                table: "LuongShipper",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LuongShipperId",
                table: "LuongShipper",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LoaiSanPhamId",
                table: "LoaiSanPham",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "SanPhamId",
                table: "ImageSanPham",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageSanPhamId",
                table: "ImageSanPham",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "NguoiBanId",
                table: "DonHang",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KhachHangId",
                table: "DonHang",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NguoiBanId",
                table: "DoanhThuNguoiBan",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoanhThuNguoiBanId",
                table: "DoanhThuNguoiBan",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DanhGiaSanPhamId",
                table: "DanhGiaSanPham",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "SanPhamId",
                table: "ChiTietDonHang",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DonHangId",
                table: "ChiTietDonHang",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrangThaiDonHang",
                table: "TrangThaiDonHang",
                column: "TrangThaiDonHangId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhiHoaHongNguoiBan",
                table: "PhiHoaHongNguoiBan",
                column: "PhiHoaHongNguoiBanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LuongShipper",
                table: "LuongShipper",
                column: "LuongShipperId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiSanPham",
                table: "LoaiSanPham",
                column: "LoaiSanPhamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageSanPham",
                table: "ImageSanPham",
                column: "ImageSanPhamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoanhThuNguoiBan",
                table: "DoanhThuNguoiBan",
                column: "DoanhThuNguoiBanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhGiaSanPham",
                table: "DanhGiaSanPham",
                column: "DanhGiaSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiDonHang_DonHangId1",
                table: "TrangThaiDonHang",
                column: "DonHangId1");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_CMND",
                table: "ThanhToan",
                column: "CMND");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_LoaiSanPhamId",
                table: "SanPham",
                column: "LoaiSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiBan_CMND",
                table: "NguoiBan",
                column: "CMND",
                unique: true,
                filter: "[CMND] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_DonHang_DonHangId",
                table: "ChiTietDonHang",
                column: "DonHangId",
                principalTable: "DonHang",
                principalColumn: "DonHangId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_SanPham_SanPhamId",
                table: "ChiTietDonHang",
                column: "SanPhamId",
                principalTable: "SanPham",
                principalColumn: "SanPhamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoanhThuNguoiBan_NguoiBan_NguoiBanId",
                table: "DoanhThuNguoiBan",
                column: "NguoiBanId",
                principalTable: "NguoiBan",
                principalColumn: "NguoiBanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_KhachHang_KhachHangId",
                table: "DonHang",
                column: "KhachHangId",
                principalTable: "KhachHang",
                principalColumn: "KhachHangId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_NguoiBan_NguoiBanId",
                table: "DonHang",
                column: "NguoiBanId",
                principalTable: "NguoiBan",
                principalColumn: "NguoiBanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageSanPham_SanPham_SanPhamId",
                table: "ImageSanPham",
                column: "SanPhamId",
                principalTable: "SanPham",
                principalColumn: "SanPhamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LuongShipper_Shipper_ShipperId",
                table: "LuongShipper",
                column: "ShipperId",
                principalTable: "Shipper",
                principalColumn: "ShipperId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiBan_User_CMND",
                table: "NguoiBan",
                column: "CMND",
                principalTable: "User",
                principalColumn: "CMND",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhiHoaHongNguoiBan_NguoiBan_NguoiBanId",
                table: "PhiHoaHongNguoiBan",
                column: "NguoiBanId",
                principalTable: "NguoiBan",
                principalColumn: "NguoiBanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_LoaiSanPham_LoaiSanPhamId",
                table: "SanPham",
                column: "LoaiSanPhamId",
                principalTable: "LoaiSanPham",
                principalColumn: "LoaiSanPhamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_NguoiBan_NguoiBanId",
                table: "SanPham",
                column: "NguoiBanId",
                principalTable: "NguoiBan",
                principalColumn: "NguoiBanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhToan_User_CMND",
                table: "ThanhToan",
                column: "CMND",
                principalTable: "User",
                principalColumn: "CMND",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrangThaiDonHang_DonHang_DonHangId1",
                table: "TrangThaiDonHang",
                column: "DonHangId1",
                principalTable: "DonHang",
                principalColumn: "DonHangId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_DonHang_DonHangId",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_SanPham_SanPhamId",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DoanhThuNguoiBan_NguoiBan_NguoiBanId",
                table: "DoanhThuNguoiBan");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_KhachHang_KhachHangId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_NguoiBan_NguoiBanId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageSanPham_SanPham_SanPhamId",
                table: "ImageSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_LuongShipper_Shipper_ShipperId",
                table: "LuongShipper");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiBan_User_CMND",
                table: "NguoiBan");

            migrationBuilder.DropForeignKey(
                name: "FK_PhiHoaHongNguoiBan_NguoiBan_NguoiBanId",
                table: "PhiHoaHongNguoiBan");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_LoaiSanPham_LoaiSanPhamId",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_NguoiBan_NguoiBanId",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanhToan_User_CMND",
                table: "ThanhToan");

            migrationBuilder.DropForeignKey(
                name: "FK_TrangThaiDonHang_DonHang_DonHangId1",
                table: "TrangThaiDonHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrangThaiDonHang",
                table: "TrangThaiDonHang");

            migrationBuilder.DropIndex(
                name: "IX_TrangThaiDonHang_DonHangId1",
                table: "TrangThaiDonHang");

            migrationBuilder.DropIndex(
                name: "IX_ThanhToan_CMND",
                table: "ThanhToan");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_LoaiSanPhamId",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhiHoaHongNguoiBan",
                table: "PhiHoaHongNguoiBan");

            migrationBuilder.DropIndex(
                name: "IX_NguoiBan_CMND",
                table: "NguoiBan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LuongShipper",
                table: "LuongShipper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiSanPham",
                table: "LoaiSanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageSanPham",
                table: "ImageSanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoanhThuNguoiBan",
                table: "DoanhThuNguoiBan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhGiaSanPham",
                table: "DanhGiaSanPham");

            migrationBuilder.DropColumn(
                name: "TrangThaiDonHangId",
                table: "TrangThaiDonHang");

            migrationBuilder.DropColumn(
                name: "DonHangId1",
                table: "TrangThaiDonHang");

            migrationBuilder.DropColumn(
                name: "LoaiSanPhamId",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "PhiHoaHongNguoiBanId",
                table: "PhiHoaHongNguoiBan");

            migrationBuilder.DropColumn(
                name: "CMND",
                table: "NguoiBan");

            migrationBuilder.DropColumn(
                name: "LuongShipperId",
                table: "LuongShipper");

            migrationBuilder.DropColumn(
                name: "LoaiSanPhamId",
                table: "LoaiSanPham");

            migrationBuilder.DropColumn(
                name: "ImageSanPhamId",
                table: "ImageSanPham");

            migrationBuilder.DropColumn(
                name: "DoanhThuNguoiBanId",
                table: "DoanhThuNguoiBan");

            migrationBuilder.DropColumn(
                name: "DanhGiaSanPhamId",
                table: "DanhGiaSanPham");

            migrationBuilder.AlterColumn<int>(
                name: "DonHangId",
                table: "TrangThaiDonHang",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDTrangThai",
                table: "TrangThaiDonHang",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "IDDonHang",
                table: "TrangThaiDonHang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CMND",
                table: "ThanhToan",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiDungCMND",
                table: "ThanhToan",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NguoiBanId",
                table: "SanPham",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IDLoaiSP",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDNguoiBan",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoaiSanPhamIDLoaiSP",
                table: "SanPham",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NguoiBanId",
                table: "PhiHoaHongNguoiBan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IDPhiHoaHong",
                table: "PhiHoaHongNguoiBan",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IDNguoiBan",
                table: "PhiHoaHongNguoiBan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CMNND",
                table: "NguoiBan",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShipperId",
                table: "LuongShipper",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IDLuong",
                table: "LuongShipper",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IDShipper",
                table: "LuongShipper",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDLoaiSP",
                table: "LoaiSanPham",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "SanPhamId",
                table: "ImageSanPham",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IDImageSP",
                table: "ImageSanPham",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IDSanPham",
                table: "ImageSanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "NguoiBanId",
                table: "DonHang",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "KhachHangId",
                table: "DonHang",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IDKhachHang",
                table: "DonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDNguoiBan",
                table: "DonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "NguoiBanId",
                table: "DoanhThuNguoiBan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IDDoanhThu",
                table: "DoanhThuNguoiBan",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IDNguoiBan",
                table: "DoanhThuNguoiBan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDDanhGiaSP",
                table: "DanhGiaSanPham",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "SanPhamId",
                table: "ChiTietDonHang",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DonHangId",
                table: "ChiTietDonHang",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IDDonHang",
                table: "ChiTietDonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDSanPham",
                table: "ChiTietDonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrangThaiDonHang",
                table: "TrangThaiDonHang",
                column: "IDTrangThai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhiHoaHongNguoiBan",
                table: "PhiHoaHongNguoiBan",
                column: "IDPhiHoaHong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LuongShipper",
                table: "LuongShipper",
                column: "IDLuong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiSanPham",
                table: "LoaiSanPham",
                column: "IDLoaiSP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageSanPham",
                table: "ImageSanPham",
                column: "IDImageSP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoanhThuNguoiBan",
                table: "DoanhThuNguoiBan",
                column: "IDDoanhThu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhGiaSanPham",
                table: "DanhGiaSanPham",
                column: "IDDanhGiaSP");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiDonHang_DonHangId",
                table: "TrangThaiDonHang",
                column: "DonHangId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_NguoiDungCMND",
                table: "ThanhToan",
                column: "NguoiDungCMND");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_LoaiSanPhamIDLoaiSP",
                table: "SanPham",
                column: "LoaiSanPhamIDLoaiSP");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiBan_CMNND",
                table: "NguoiBan",
                column: "CMNND",
                unique: true,
                filter: "[CMNND] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_DonHang_DonHangId",
                table: "ChiTietDonHang",
                column: "DonHangId",
                principalTable: "DonHang",
                principalColumn: "DonHangId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_SanPham_SanPhamId",
                table: "ChiTietDonHang",
                column: "SanPhamId",
                principalTable: "SanPham",
                principalColumn: "SanPhamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoanhThuNguoiBan_NguoiBan_NguoiBanId",
                table: "DoanhThuNguoiBan",
                column: "NguoiBanId",
                principalTable: "NguoiBan",
                principalColumn: "NguoiBanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_KhachHang_KhachHangId",
                table: "DonHang",
                column: "KhachHangId",
                principalTable: "KhachHang",
                principalColumn: "KhachHangId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_NguoiBan_NguoiBanId",
                table: "DonHang",
                column: "NguoiBanId",
                principalTable: "NguoiBan",
                principalColumn: "NguoiBanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageSanPham_SanPham_SanPhamId",
                table: "ImageSanPham",
                column: "SanPhamId",
                principalTable: "SanPham",
                principalColumn: "SanPhamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LuongShipper_Shipper_ShipperId",
                table: "LuongShipper",
                column: "ShipperId",
                principalTable: "Shipper",
                principalColumn: "ShipperId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiBan_User_CMNND",
                table: "NguoiBan",
                column: "CMNND",
                principalTable: "User",
                principalColumn: "CMND",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhiHoaHongNguoiBan_NguoiBan_NguoiBanId",
                table: "PhiHoaHongNguoiBan",
                column: "NguoiBanId",
                principalTable: "NguoiBan",
                principalColumn: "NguoiBanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_LoaiSanPham_LoaiSanPhamIDLoaiSP",
                table: "SanPham",
                column: "LoaiSanPhamIDLoaiSP",
                principalTable: "LoaiSanPham",
                principalColumn: "IDLoaiSP",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_NguoiBan_NguoiBanId",
                table: "SanPham",
                column: "NguoiBanId",
                principalTable: "NguoiBan",
                principalColumn: "NguoiBanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhToan_User_NguoiDungCMND",
                table: "ThanhToan",
                column: "NguoiDungCMND",
                principalTable: "User",
                principalColumn: "CMND",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrangThaiDonHang_DonHang_DonHangId",
                table: "TrangThaiDonHang",
                column: "DonHangId",
                principalTable: "DonHang",
                principalColumn: "DonHangId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
