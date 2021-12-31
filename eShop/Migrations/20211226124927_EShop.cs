using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.Migrations
{
    public partial class EShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoSoDangKyBanHang",
                columns: table => new
                {
                    HoSoDangKyBanHangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(nullable: true),
                    CMND = table.Column<string>(nullable: true),
                    TenCuaHang = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SDT = table.Column<string>(nullable: true),
                    ImageGiayPhepKD = table.Column<string>(nullable: true),
                    ImageGiayCNATVSTP = table.Column<string>(nullable: true),
                    TrangThai = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoDangKyBanHang", x => x.HoSoDangKyBanHangId);
                });

            migrationBuilder.CreateTable(
                name: "HoSoDangKyShipper",
                columns: table => new
                {
                    HoSoDangKyShipperId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(nullable: true),
                    CMND = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SDT = table.Column<string>(nullable: true),
                    ImagesGiayXN = table.Column<string>(nullable: true),
                    ImagesChungNhanTiemVX = table.Column<string>(nullable: true),
                    TrangThai = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoDangKyShipper", x => x.HoSoDangKyShipperId);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPham",
                columns: table => new
                {
                    IDLoaiSP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiSP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPham", x => x.IDLoaiSP);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    CMND = table.Column<string>(nullable: false),
                    HoTen = table.Column<string>(nullable: true),
                    NgayCapCMND = table.Column<DateTime>(nullable: false),
                    NoiCapCMND = table.Column<string>(nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    DiaChi = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SoDienThoai = table.Column<string>(nullable: true),
                    CapDoVung = table.Column<string>(nullable: true),
                    GioiTinh = table.Column<string>(nullable: true),
                    ImageAvatar = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TrangThai = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.CMND);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    KhachHangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CMND = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.KhachHangId);
                    table.ForeignKey(
                        name: "FK_KhachHang_User_CMND",
                        column: x => x.CMND,
                        principalTable: "User",
                        principalColumn: "CMND",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NguoiBan",
                columns: table => new
                {
                    NguoiBanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCuaHang = table.Column<string>(nullable: true),
                    HoSoDangKyBanHangId = table.Column<int>(nullable: false),
                    CMNND = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiBan", x => x.NguoiBanId);
                    table.ForeignKey(
                        name: "FK_NguoiBan_User_CMNND",
                        column: x => x.CMNND,
                        principalTable: "User",
                        principalColumn: "CMND",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NguoiBan_HoSoDangKyBanHang_HoSoDangKyBanHangId",
                        column: x => x.HoSoDangKyBanHangId,
                        principalTable: "HoSoDangKyBanHang",
                        principalColumn: "HoSoDangKyBanHangId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    IDNhanVien = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChucVu = table.Column<string>(nullable: true),
                    CMND = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.IDNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanVien_User_CMND",
                        column: x => x.CMND,
                        principalTable: "User",
                        principalColumn: "CMND",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shipper",
                columns: table => new
                {
                    ShipperId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoSoDangKyShipperId = table.Column<int>(nullable: false),
                    CMND = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipper", x => x.ShipperId);
                    table.ForeignKey(
                        name: "FK_Shipper_User_CMND",
                        column: x => x.CMND,
                        principalTable: "User",
                        principalColumn: "CMND",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipper_HoSoDangKyShipper_HoSoDangKyShipperId",
                        column: x => x.HoSoDangKyShipperId,
                        principalTable: "HoSoDangKyShipper",
                        principalColumn: "HoSoDangKyShipperId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoanhThuNguoiBan",
                columns: table => new
                {
                    IDDoanhThu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNguoiBan = table.Column<int>(nullable: false),
                    NguoiBanId = table.Column<int>(nullable: true),
                    Thang = table.Column<int>(nullable: false),
                    Nam = table.Column<int>(nullable: false),
                    DoanhThu = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanhThuNguoiBan", x => x.IDDoanhThu);
                    table.ForeignKey(
                        name: "FK_DoanhThuNguoiBan_NguoiBan_NguoiBanId",
                        column: x => x.NguoiBanId,
                        principalTable: "NguoiBan",
                        principalColumn: "NguoiBanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    DonHangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDat = table.Column<DateTime>(nullable: false),
                    PhiShip = table.Column<float>(nullable: false),
                    TongTien = table.Column<float>(nullable: false),
                    HinhThucThanhToan = table.Column<string>(nullable: true),
                    IDNguoiBan = table.Column<int>(nullable: false),
                    NguoiBanId = table.Column<int>(nullable: true),
                    IDKhachHang = table.Column<int>(nullable: false),
                    KhachHangId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.DonHangId);
                    table.ForeignKey(
                        name: "FK_DonHang_KhachHang_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHang",
                        principalColumn: "KhachHangId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonHang_NguoiBan_NguoiBanId",
                        column: x => x.NguoiBanId,
                        principalTable: "NguoiBan",
                        principalColumn: "NguoiBanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhiHoaHongNguoiBan",
                columns: table => new
                {
                    IDPhiHoaHong = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhiHoaHong = table.Column<float>(nullable: false),
                    Thang = table.Column<int>(nullable: false),
                    Nam = table.Column<int>(nullable: false),
                    IDNguoiBan = table.Column<int>(nullable: false),
                    NguoiBanId = table.Column<int>(nullable: true),
                    TrangThai = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhiHoaHongNguoiBan", x => x.IDPhiHoaHong);
                    table.ForeignKey(
                        name: "FK_PhiHoaHongNguoiBan_NguoiBan_NguoiBanId",
                        column: x => x.NguoiBanId,
                        principalTable: "NguoiBan",
                        principalColumn: "NguoiBanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    SanPhamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSP = table.Column<string>(nullable: true),
                    GiaSP = table.Column<float>(nullable: false),
                    DonViTinh = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(nullable: true),
                    SoLuongTon = table.Column<int>(nullable: false),
                    DiemTB = table.Column<float>(nullable: false),
                    IDLoaiSP = table.Column<int>(nullable: false),
                    LoaiSanPhamIDLoaiSP = table.Column<int>(nullable: true),
                    IDNguoiBan = table.Column<int>(nullable: false),
                    NguoiBanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.SanPhamId);
                    table.ForeignKey(
                        name: "FK_SanPham_LoaiSanPham_LoaiSanPhamIDLoaiSP",
                        column: x => x.LoaiSanPhamIDLoaiSP,
                        principalTable: "LoaiSanPham",
                        principalColumn: "IDLoaiSP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanPham_NguoiBan_NguoiBanId",
                        column: x => x.NguoiBanId,
                        principalTable: "NguoiBan",
                        principalColumn: "NguoiBanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LuongShipper",
                columns: table => new
                {
                    IDLuong = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Thang = table.Column<int>(nullable: false),
                    Nam = table.Column<int>(nullable: false),
                    TongLuong = table.Column<float>(nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    NgayNhan = table.Column<DateTime>(nullable: false),
                    IDShipper = table.Column<int>(nullable: false),
                    ShipperId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuongShipper", x => x.IDLuong);
                    table.ForeignKey(
                        name: "FK_LuongShipper_Shipper_ShipperId",
                        column: x => x.ShipperId,
                        principalTable: "Shipper",
                        principalColumn: "ShipperId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhGiaDonHang",
                columns: table => new
                {
                    DanhGiaDonHangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDanhGia = table.Column<DateTime>(nullable: false),
                    NoiDung = table.Column<string>(nullable: true),
                    Diem = table.Column<int>(nullable: false),
                    DonHangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGiaDonHang", x => x.DanhGiaDonHangId);
                    table.ForeignKey(
                        name: "FK_DanhGiaDonHang_DonHang_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "DonHang",
                        principalColumn: "DonHangId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThanhToan",
                columns: table => new
                {
                    ThanhToanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CMND = table.Column<string>(nullable: true),
                    NguoiDungCMND = table.Column<string>(nullable: true),
                    STK = table.Column<string>(nullable: true),
                    NgayThanhToan = table.Column<DateTime>(nullable: false),
                    DonHangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhToan", x => x.ThanhToanId);
                    table.ForeignKey(
                        name: "FK_ThanhToan_DonHang_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "DonHang",
                        principalColumn: "DonHangId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThanhToan_User_NguoiDungCMND",
                        column: x => x.NguoiDungCMND,
                        principalTable: "User",
                        principalColumn: "CMND",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiDonHang",
                columns: table => new
                {
                    IDTrangThai = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayCapNhat = table.Column<DateTime>(nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    IDDonHang = table.Column<string>(nullable: true),
                    DonHangId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiDonHang", x => x.IDTrangThai);
                    table.ForeignKey(
                        name: "FK_TrangThaiDonHang_DonHang_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "DonHang",
                        principalColumn: "DonHangId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHang",
                columns: table => new
                {
                    ChiTietDonHangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(nullable: false),
                    IDSanPham = table.Column<int>(nullable: false),
                    SanPhamId = table.Column<int>(nullable: true),
                    IDDonHang = table.Column<int>(nullable: false),
                    DonHangId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHang", x => x.ChiTietDonHangId);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_DonHang_DonHangId",
                        column: x => x.DonHangId,
                        principalTable: "DonHang",
                        principalColumn: "DonHangId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietDonHang_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "SanPhamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietGioHang",
                columns: table => new
                {
                    ChiTietGioHangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhachHangId = table.Column<int>(nullable: false),
                    SanPhamId = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietGioHang", x => x.ChiTietGioHangId);
                    table.ForeignKey(
                        name: "FK_ChiTietGioHang_KhachHang_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHang",
                        principalColumn: "KhachHangId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietGioHang_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "SanPhamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageSanPham",
                columns: table => new
                {
                    IDImageSP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameImageSP = table.Column<string>(nullable: true),
                    UrlImage = table.Column<string>(nullable: true),
                    IDSanPham = table.Column<int>(nullable: false),
                    SanPhamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageSanPham", x => x.IDImageSP);
                    table.ForeignKey(
                        name: "FK_ImageSanPham_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "SanPhamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhGiaSanPham",
                columns: table => new
                {
                    IDDanhGiaSP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDanhGia = table.Column<DateTime>(nullable: false),
                    NoiDung = table.Column<string>(nullable: true),
                    Diem = table.Column<float>(nullable: false),
                    ChiTietDonHangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhGiaSanPham", x => x.IDDanhGiaSP);
                    table.ForeignKey(
                        name: "FK_DanhGiaSanPham_ChiTietDonHang_ChiTietDonHangId",
                        column: x => x.ChiTietDonHangId,
                        principalTable: "ChiTietDonHang",
                        principalColumn: "ChiTietDonHangId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_DonHangId",
                table: "ChiTietDonHang",
                column: "DonHangId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_SanPhamId",
                table: "ChiTietDonHang",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGioHang_KhachHangId",
                table: "ChiTietGioHang",
                column: "KhachHangId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietGioHang_SanPhamId",
                table: "ChiTietGioHang",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhGiaDonHang_DonHangId",
                table: "DanhGiaDonHang",
                column: "DonHangId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhGiaSanPham_ChiTietDonHangId",
                table: "DanhGiaSanPham",
                column: "ChiTietDonHangId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoanhThuNguoiBan_NguoiBanId",
                table: "DoanhThuNguoiBan",
                column: "NguoiBanId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_KhachHangId",
                table: "DonHang",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_NguoiBanId",
                table: "DonHang",
                column: "NguoiBanId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageSanPham_SanPhamId",
                table: "ImageSanPham",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_CMND",
                table: "KhachHang",
                column: "CMND",
                unique: true,
                filter: "[CMND] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LuongShipper_ShipperId",
                table: "LuongShipper",
                column: "ShipperId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiBan_CMNND",
                table: "NguoiBan",
                column: "CMNND",
                unique: true,
                filter: "[CMNND] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiBan_HoSoDangKyBanHangId",
                table: "NguoiBan",
                column: "HoSoDangKyBanHangId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_CMND",
                table: "NhanVien",
                column: "CMND",
                unique: true,
                filter: "[CMND] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PhiHoaHongNguoiBan_NguoiBanId",
                table: "PhiHoaHongNguoiBan",
                column: "NguoiBanId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_LoaiSanPhamIDLoaiSP",
                table: "SanPham",
                column: "LoaiSanPhamIDLoaiSP");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_NguoiBanId",
                table: "SanPham",
                column: "NguoiBanId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipper_CMND",
                table: "Shipper",
                column: "CMND",
                unique: true,
                filter: "[CMND] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Shipper_HoSoDangKyShipperId",
                table: "Shipper",
                column: "HoSoDangKyShipperId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_DonHangId",
                table: "ThanhToan",
                column: "DonHangId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_NguoiDungCMND",
                table: "ThanhToan",
                column: "NguoiDungCMND");

            migrationBuilder.CreateIndex(
                name: "IX_TrangThaiDonHang_DonHangId",
                table: "TrangThaiDonHang",
                column: "DonHangId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietGioHang");

            migrationBuilder.DropTable(
                name: "DanhGiaDonHang");

            migrationBuilder.DropTable(
                name: "DanhGiaSanPham");

            migrationBuilder.DropTable(
                name: "DoanhThuNguoiBan");

            migrationBuilder.DropTable(
                name: "ImageSanPham");

            migrationBuilder.DropTable(
                name: "LuongShipper");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "PhiHoaHongNguoiBan");

            migrationBuilder.DropTable(
                name: "ThanhToan");

            migrationBuilder.DropTable(
                name: "TrangThaiDonHang");

            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "Shipper");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "HoSoDangKyShipper");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "LoaiSanPham");

            migrationBuilder.DropTable(
                name: "NguoiBan");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "HoSoDangKyBanHang");
        }
    }
}
