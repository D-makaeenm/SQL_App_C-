create database thi;
use thi;
create table khachhang
(
	makhachhang nvarchar(20) not null
	--CONSTRAINT 	pk_khachhang
	primary key (makhachhang),
	hoten nvarchar(20) not null,
	diachi nvarchar(20) null,
	gioitinh nvarchar(10) null,
	dienthoai nvarchar(20) null
)

-- không thấy cho khóa ngoại vào khả thi vì khi nhập cần nhập 2 bảng cùng lúc
-- nhưng trong c# để nhập 2 bảng cùng lúc chưa làm được nên chỉ dùng bảng không có khóa ngoại

create table nhacc
(
	mancc nvarchar(20) not null
	--constraint pk_nhacc
	primary key(mancc),
	tenncc nvarchar(20) not null,
	diachi nvarchar(20) null,
	email nvarchar(20) null,
)

create table mathang
(
	mahang nvarchar(20) not null
	--constraint pk_mathang
	primary key (mahang),
	tenhang nvarchar(20) not null,
	loaihang nvarchar(20) null,
	mancc nvarchar(20) not null,
	soluong int null,
	dvt nvarchar(10) null
)

create table hdnhap
(
	mahdn nvarchar(20) not null
	--constraint pk_hdnhap
	primary key(mahdn),
	mahang nvarchar(20) not null,
	mancc nvarchar(20) not null,
	soluong int null,
	dvt nvarchar(10) null,
)

create table hdxuat
(
	mahdx nvarchar(20) not null
	--constraint pk_hdxuat
	primary key(mahdx),
	mahang nvarchar(20) not null,
	makhachhang nvarchar(20) not null,
	soluong int null,
	dvt nvarchar(10) null,
)

create table dondathang
(
	madon nvarchar(20) not null
	--constraint pk_dondathang
	primary key(madon),
	makhachhang nvarchar(20) not null,
	manv nvarchar(20) not null,
	ngaydh datetime null,
	diachigiao nvarchar(20) null,
)

create table nhanvien
(
	manv nvarchar(20) not null
	--constraint pk_nhanvien
	primary key(manv),
	tennv nvarchar(20) not null,
	gioitinh nvarchar(10) null,
	ngaysinh datetime null,
	ngaylamviec datetime null,
	diachi nvarchar(20) null,
	dienthoai nvarchar(20) null,
	luongcoban money null,
	phucap money null
)
