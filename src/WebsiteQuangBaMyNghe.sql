Create Database WebsiteQuangBaMyNghe
Use WebsiteQuangBaMyNghe
create table Admin(
	TaiKhoan_AD varchar(50) PRIMARY KEY,
	MatKhau_AD varchar(50) NOT NULL,
)

create table KhachHang(
	Ma_KH int PRIMARY KEY IDENTITY(1,1),
	TaiKhoan_KH varchar(50) NOT NULL UNIQUE,
	MatKhau_KH varchar(50) NOT NULL,
	HoTen nvarchar(150) NOT NULL,
	Email varchar(250),
	DiaChi nvarchar(200),
	SoDienThoai varchar(15),
)

create table DanhMuc(
	MaDanhMuc int PRIMARY KEY IDENTITY(1,1),
	TenDanhMuc nvarchar(150) NOT NULL,
	MoTaDanhMuc nvarchar(2000),
	Alias nvarchar(500),
	Icon nvarchar(500),
)

create table DiaPhuong(
	MaDiaPhuong varchar(250) PRIMARY KEY,
	TenDiaPhuong nvarchar(250) NOT NULL,
)

create table SanPham(
	MaSanPham int PRIMARY KEY IDENTITY(1,1),
	TenSanPham nvarchar(250) NOT NULL,
	MoTaSanPham nvarchar(4000),
	ThongTinSanPham nvarchar(4000),
	Image nvarchar(2000), 
	Gia DECIMAL(18, 3) NOT NULL,
	GiaKhuyenMai DECIMAL(18, 3),
	SoLuong int,
	Alias nvarchar(500),
	IsActive bit,
	IsHot bit,
	IsSale bit,

	MaDanhMuc int NOT NULL,
	MaDiaPhuong varchar(250) NOT NULL,

	FOREIGN KEY (MaDanhMuc) REFERENCES DanhMuc(MaDanhMuc), 
	FOREIGN KEY (MaDiaPhuong) REFERENCES DiaPhuong(MaDiaPhuong), 
)

create table DonHang(
	MaDonHang int PRIMARY KEY IDENTITY(1,1),
	ThanhTienDH DECIMAL(18, 3),
	SoLuong int,
	PhuongThucThanhToan int,
	NgayDatDH datetime,
	TrangThaiDH int,
	
	Ma_KH int,
	HoTen nvarchar(150),
	Email varchar(250),
	DiaChi nvarchar(200),
	SoDienThoai varchar(15),

	FOREIGN KEY (Ma_KH) REFERENCES KhachHang(Ma_KH), 
)

create table ChiTietDonHang(
	Id int PRIMARY KEY IDENTITY(1,1),
	MaDonHang int,
	MaSanPham int,
	Gia DECIMAL(18, 3),
	Soluong int,

	FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang), 
	FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham), 
)
create table AnhSanPham(
	Id int Primary key IDENTITY(1,1),
	MaSanPham int NOT NULL,
	IsDefault bit,
	Image Nvarchar(2000),

	FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham),
)
create table BinhLuan(
	MaBL int PRIMARY KEY IDENTITY(1,1),
	NoiDungBL nvarchar(2000),
	DanhGia int,
	NgayTao date,
	Ma_KH int,
	MaSanPham int,

	FOREIGN KEY (Ma_KH) REFERENCES KhachHang(Ma_KH),
	FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham), 
)
 insert into Admin values('Admin','123')
 select *
 from Admin

 select*
 from DonHang
 select *
 from BinhLuan