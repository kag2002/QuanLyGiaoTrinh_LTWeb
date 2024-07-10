--drop database [QuanLyGiaoTrinh]
--create database [QuanLyGiaoTrinh7]
--use [QuanLyGiaoTrinh7]



GO
/****** Object:  Table [dbo].[tChiTietNhanVien]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE TABLE [dbo].[TacGia](
	[MaTacGia] [nvarchar](30) NOT NULL,
	[TenTacGia] [nvarchar](30),
	[MaKhoa] [nvarchar](30) NULL,
	[NamSinh] [int] NULL,
	[MaTrinhDo] [nvarchar](30) NULL,

 CONSTRAINT [PK_TacGia] PRIMARY KEY CLUSTERED 
(
	[MaTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tNhanVien]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[Khoa](
	
	[MaKhoa] [nvarchar](30) NOT NULL,
	[TenKhoa] [nvarchar](30),
	[SDT][nvarchar](30),
	

 CONSTRAINT [PK_Khoa] PRIMARY KEY CLUSTERED 
(
	[MaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPhongBan]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[TrinhDo](
	[MaTrinhDo] [nvarchar](30) NOT NULL,
	[TenTrinhDo] [nvarchar](30)  NULL,

	
 CONSTRAINT [PK_TrinhDo] PRIMARY KEY CLUSTERED 
(
	[MaTrinhDo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPhongBan]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE TABLE [dbo].[ViPham](
	[MaViPham] [nvarchar](30) NOT NULL,
	[TenViPham] [nvarchar](30) NULL,


 CONSTRAINT [PK_ViPham] PRIMARY KEY CLUSTERED 
(
	[MaViPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPhongBan]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE TABLE [dbo].[Lop](
	[MaLop] [nvarchar](30) NOT NULL,
	[TenLop] [nvarchar](30)  NULL,
	[MaKhoa] [nvarchar](30)  NULL,



 CONSTRAINT [PK_Lop] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPhongBan]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE TABLE [dbo].[ChuyenNganh](

	[MaChuyenNganh] [nvarchar](30) NOT NULL,
	[TenChuyenNganh] [nvarchar](100)  NULL,


 CONSTRAINT [PK_ChuyenNganh] PRIMARY KEY CLUSTERED 
(
	[MaChuyenNganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPhongBan]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE TABLE [dbo].[DMGiaoTrinh](
	[MaGT] [nvarchar](30) NOT NULL,
	[TenGT] [nvarchar](200) NULL,
	[MaTacGia] [nvarchar](30) NULL,
	[NamXB] [int] NULL,
	[LanTB] [int] NULL,
	[MaChuyenNganh] [nvarchar](30) NULL,
	[SoTrang] [int] NULL,
	[TomTatND] [nvarchar](300) NULL,
	[SoLuongGT] [int] NULL,

 CONSTRAINT [PK_DMGiaoTrinh] PRIMARY KEY CLUSTERED 
(
	[MaGT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPhongBan]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE TABLE [dbo].[ThuThu](
	[MaThuThu] [nvarchar](30) NOT NULL,
	[TenThuThu] [nvarchar](30)  NULL,
	[DiaChi] [nvarchar](30)  NULL,
	[DienThoaiCD] [nvarchar](30)  NULL,
	[DienThoaiDD] [nvarchar](30)  NULL,	
	[MaQue][nvarchar](30) NULL,

 CONSTRAINT [PK_ThuThu] PRIMARY KEY CLUSTERED 
(
	[MaThuThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPhongBan]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE TABLE [dbo].[HoSoTra](
	[MaHSTra] [nvarchar](30) NOT NULL,
	[MaHSM] [nvarchar](30)  NULL,
    [NgayTra] datetime  NULL,
	[TongTienPhat] money NULL,
	[NgayNopPhat] datetime  NULL,
    [MaThuThu] [nvarchar](30)  NULL,
	

 CONSTRAINT [PK_HoSoTra] PRIMARY KEY CLUSTERED 
(
	[MaHSTra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPhongBan]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE TABLE [dbo].[ChiTietHSTra](
	[MaHSTra] [nvarchar](30) NOT NULL,
	[MaGT] [nvarchar](30) NOT NULL,
	[MaViPham] [nvarchar](30)  NULL,
	[MaPhat] [nvarchar](30)  NULL,

 CONSTRAINT [PK_ChiTietHSTra] PRIMARY KEY CLUSTERED 
(
	[MaHSTra] ASC,
	[MaGT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPhongBan]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE TABLE [dbo].[Phat](
	[MaPhat] [nvarchar](30) NOT NULL,
	[TienPhat] money  NULL,

 CONSTRAINT [PK_Phat] PRIMARY KEY CLUSTERED 
(
	[MaPhat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPhongBan]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE TABLE [dbo].[Que](
	[MaQue] [nvarchar](30) NOT NULL,
	[TenQue] [nvarchar](30)  NULL,

 CONSTRAINT [PK_Que] PRIMARY KEY CLUSTERED 
(
	[MaQue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPhongBan]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE TABLE [dbo].[TheMuon](
	[MaThe] [nvarchar](30) NOT NULL,
    [HoTen] [nvarchar](30)  NULL,
    [GioiTinh] [nvarchar](30)  NULL,
	[MaLop] [nvarchar](30)  NULL,
	[MaKhoa] [nvarchar](30)  NULL,
	[KhoaThe] [nchar](30)  NULL,
	[SLMuon] int  NULL,	
	

 CONSTRAINT [PK_TheMuon] PRIMARY KEY CLUSTERED 
(
	[MaThe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPhongBan]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE TABLE [dbo].[HSMuon](
	[MaHSM] [nvarchar](30) NOT NULL,
	[MaThe] [nvarchar](30)  NULL,
	[MaThuThu] [nvarchar](30)  NULL,
	[NgayMuon] datetime  NULL,
	[NgayTra] datetime  NULL,
	[TinhTrangMuon] [nvarchar](30)  NULL,
	
	

 CONSTRAINT [PK_HSMuon] PRIMARY KEY CLUSTERED 
(
	[MaHSM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPhongBan]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE TABLE [dbo].[ChiTietHSMuon](
	[MaHSM] [nvarchar](30) NOT NULL,
	[MaGT] [nvarchar] (30) NOT NULL,
	[ChuaTra] [nchar](30)  NULL,

 CONSTRAINT [PK_ChiTietHSMuon] PRIMARY KEY CLUSTERED 
(
	[MaHSM] ASC,
	[MaGT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tPhongBan]    Script Date: 03-Oct-22 11:07:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








--TacGia->Khoa--
ALTER TABLE [dbo].[tacgia]  WITH CHECK ADD CONSTRAINT [FK_tacgia_khoa] FOREIGN KEY([Makhoa])
REFERENCES [dbo].[khoa] ([MaKhoa])
go
ALTER TABLE [dbo].[tacgia] CHECK CONSTRAINT [FK_tacgia_khoa]
GO

--TacGia->TrinhDo--
ALTER TABLE [dbo].[tacgia]  WITH CHECK ADD CONSTRAINT [FK_tacgia_trinhdo] FOREIGN KEY([MaTrinhDo])
REFERENCES [dbo].[trinhdo] ([MaTrinhDo])
go
ALTER TABLE [dbo].[tacgia] CHECK CONSTRAINT [FK_tacgia_trinhdo]
GO



--ChiTietHSTra->ViPham--
ALTER TABLE [dbo].[ChiTietHSTra]  WITH CHECK ADD CONSTRAINT [FK_ChiTietHSTra_ViPham] FOREIGN KEY([MaViPham])
REFERENCES [dbo].[ViPham] ([MaViPham])
go
ALTER TABLE [dbo].[ChiTietHSTra] CHECK CONSTRAINT [FK_ChiTietHSTra_ViPham]
GO


--TheMuon->Lop--
ALTER TABLE [dbo].[TheMuon]  WITH CHECK ADD CONSTRAINT [FK_TheMuon_Lop] FOREIGN KEY([MaLop])
REFERENCES [dbo].[Lop] ([MaLop])
go
ALTER TABLE [dbo].[TheMuon] CHECK CONSTRAINT [FK_TheMuon_Lop]
GO

--DMGiaoTrinh->ChuyenNganh--
ALTER TABLE [dbo].[DMGiaoTrinh]  WITH CHECK ADD CONSTRAINT [FK_DMGiaoTrinh_ChuyenNganh] FOREIGN KEY([MaChuyenNganh])
REFERENCES [dbo].[ChuyenNganh] ([MaChuyenNganh])
go
ALTER TABLE [dbo].[DMGiaoTrinh] CHECK CONSTRAINT [FK_DMGiaoTrinh_ChuyenNganh]
GO

--DMGiaoTrinh->TacGia--
ALTER TABLE [dbo].[DMGiaoTrinh]  WITH CHECK ADD CONSTRAINT [FK_DMGiaoTrinh_TacGia] FOREIGN KEY([MaTacGia])
REFERENCES [dbo].[TacGia] ([MaTacGia])
go
ALTER TABLE [dbo].[DMGiaoTrinh] CHECK CONSTRAINT [FK_DMGiaoTrinh_TacGia]
GO


--2 khoa chinh voi nhau		DMGiaoTrinh->ChiTietHSMuon--
ALTER TABLE [dbo].[ChiTietHSMuon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHSMuon_DMGiaoTrinh] FOREIGN KEY([MaGT])
REFERENCES [dbo].[DMGiaoTrinh] ([MaGT])
GO
ALTER TABLE [dbo].[ChiTietHSMuon] CHECK CONSTRAINT [FK_ChiTietHSMuon_DMGiaoTrinh]



--HSMuon->ThuThu--
ALTER TABLE [dbo].[HSMuon]  WITH CHECK ADD CONSTRAINT [FK_HSMuon_ThuThu] FOREIGN KEY([MaThuThu])
REFERENCES [dbo].[ThuThu] ([MaThuThu])
go
ALTER TABLE [dbo].[HSMuon] CHECK CONSTRAINT [FK_HSMuon_ThuThu]
GO


--ThuThu->Que--
ALTER TABLE [dbo].[ThuThu]  WITH CHECK ADD CONSTRAINT [FK_ThuThu_Que] FOREIGN KEY([MaQue])
REFERENCES [dbo].[Que] ([MaQue])
go
ALTER TABLE [dbo].[ThuThu] CHECK CONSTRAINT [FK_ThuThu_Que]
GO


--2 khoa chinh voi nhau		HoSoTra->ChiTietHSTra--
ALTER TABLE [dbo].[ChiTietHSTra]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHSTra_HoSoTra] FOREIGN KEY([MaHSTra])
REFERENCES [dbo].[HoSoTra] ([MaHSTra])
GO
ALTER TABLE [dbo].[ChiTietHSTra] CHECK CONSTRAINT [FK_ChiTietHSTra_HoSoTra]




--ChiTietHSTra->Phat--
ALTER TABLE [dbo].[ChiTietHSTra]  WITH CHECK ADD CONSTRAINT [FK_ChiTietHSTra_Phat] FOREIGN KEY([MaPhat])
REFERENCES [dbo].[Phat] ([MaPhat])
go
ALTER TABLE [dbo].[ChiTietHSTra] CHECK CONSTRAINT [FK_ChiTietHSTra_Phat]
GO



--HoSoTra->ThuThu--
ALTER TABLE [dbo].[HoSoTra]  WITH CHECK ADD CONSTRAINT [FK_HoSoTra_ThuThu] FOREIGN KEY([MaThuThu])
REFERENCES [dbo].[ThuThu] ([MaThuThu])
go
ALTER TABLE [dbo].[HoSoTra] CHECK CONSTRAINT [FK_HoSoTra_ThuThu]
GO



--TheMuon->HSMuon--
ALTER TABLE [dbo].[HSMuon]  WITH CHECK ADD CONSTRAINT [FK_HSMuon_TheMuon] FOREIGN KEY([MaThe])
REFERENCES [dbo].[TheMuon] ([MaThe])
go
ALTER TABLE [dbo].[HSMuon] CHECK CONSTRAINT [FK_HSMuon_TheMuon]
GO


Alter table DMGiaoTrinh
Add Anh nvarchar(300) null


alter table ThuThu
add Quyen int
alter table ThuThu
add Username nvarchar(50)
alter table ThuThu
add MatKhau nvarchar(50)


--2 khoa chinh voi nhau		HSMuon->ChiTietHSMuon--
ALTER TABLE [dbo].[ChiTietHSMuon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHSMuon_HSMuon] FOREIGN KEY([MaHSM])
REFERENCES [dbo].[HSMuon] ([MaHSM])
GO
ALTER TABLE [dbo].[ChiTietHSMuon] CHECK CONSTRAINT [FK_ChiTietHSMuon_HSMuon]

insert into Khoa values(N'KH1',N'KHOA CÔNG TRÌNH',N'0981234000')
insert into Khoa values(N'KH2',N'KHOA QUẢN LÝ XÂY DỰNG',N'0981231234')
insert into Khoa values(N'KH3',N'KHOA VẬN TẢI KINH TẾ',N'0983591955')
insert into Khoa values(N'KH4',N'KHOA ĐIỆN - ĐIỆN TỬ',N'0985554377')
insert into Khoa values(N'KH5',N'KHOA CƠ KHÍ',N'0981299109')
insert into Khoa values(N'KH6',N'KHOA CÔNG NGHỆ THÔNG TIN',N'0981302817')

insert into TrinhDo values(N'AA',N'Xuất sắc')
insert into TrinhDo values(N'A',N'Tốt')
insert into TrinhDo values(N'B',N'Khá')
insert into TrinhDo values(N'C',N'Trung bình')
insert into TrinhDo values(N'D',N'Đạt yêu cầu')

insert into TacGia values(N'TG1',N'Bùi Trọng Trang',N'KH1',1970,N'A')
insert into TacGia values(N'TG2',N'Vũ Trọng Hoàng',N'KH2',1975,N'B')
insert into TacGia values(N'TG3',N'Lê Văn Nam',N'KH3',1972,N'A')
insert into TacGia values(N'TG4',N'Đinh Thị Dậu',N'KH4',1974,N'AA')
insert into TacGia values(N'TG5',N'Hoàng Đắc Khôi',N'KH5',1976,N'C')
insert into TacGia values(N'TG6',N'Lý Hoàng Cường',N'KH6',1971,N'B')
insert into TacGia values(N'TG7',N'Ngô Thành An',N'KH1',1969,N'B')
insert into TacGia values(N'TG8',N'Phương Quân Bảo',N'KH2',1977,N'D')
insert into TacGia values(N'TG9',N'Nguyễn Văn Tùng',N'KH6',1968,N'A')

insert into ViPham values(N'VIPH1',N'Làm mất')
insert into ViPham values(N'VIPH2',N'Tự ý sửa đổi')
insert into ViPham values(N'VIPH3',N'Trả muộn')
insert into ViPham values(N'VIPH4',N'Làm hư, hỏng')

insert into Lop values(N'ML1',N'CNTT1',N'KH6')
insert into Lop values(N'ML2',N'CNTT2',N'KH6')
insert into Lop values(N'ML3',N'CNTT3',N'KH6')
insert into Lop values(N'ML4',N'Cơ khí 1',N'KH5')
insert into Lop values(N'ML5',N'Cơ Khí 2',N'KH5')
insert into Lop values(N'ML6',N'Cơ khí 3',N'KH5')
insert into Lop values(N'ML7',N'OTO 1',N'KH5')
insert into Lop values(N'ML8',N'OTO 2',N'KH5')
insert into Lop values(N'ML9',N'OTO 3',N'KH5')
insert into Lop values(N'ML10',N'KT Điện 1',N'KH4')
insert into Lop values(N'ML11',N'KT Điện 2',N'KH4')
insert into Lop values(N'ML12',N'KT Điện 3',N'KH4')
insert into Lop values(N'ML13',N'Tự động hóa 1',N'KH4')
insert into Lop values(N'ML14',N'Tự động hóa 2',N'KH4')
insert into Lop values(N'ML15',N'Tự động hóa 3',N'KH4')
insert into Lop values(N'ML16',N'Xây Dựng 1',N'KH1')
insert into Lop values(N'ML17',N'Xây Dựng 2',N'KH1')
insert into Lop values(N'ML18',N'QL Xây Dựng 1',N'KH2')
insert into Lop values(N'ML19',N'QL Xây Dựng 2',N'KH2')
insert into Lop values(N'ML20',N'TC và QL vận tải 1',N'KH3')
insert into Lop values(N'ML21',N'TC và QL vận tải 2',N'KH3')

insert into ChuyenNganh values(N'CN1',N'Kỹ thuật xây dựng Cầu - Đường bộ')
insert into ChuyenNganh values(N'CN2',N'Kỹ thuật xây dựng Cầu hầm')
insert into ChuyenNganh values(N'CN3',N'Công trình Giao thông đô thị')

insert into ChuyenNganh values(N'CN4',N'Kinh tế quản lý khai thác cầu đường')
insert into ChuyenNganh values(N'CN5',N'Quản lý xây dựng')
insert into ChuyenNganh values(N'CN6',N'Kinh tế xây dựng Công trình giao thông')

insert into ChuyenNganh values(N'CN7',N'Logistics')
insert into ChuyenNganh values(N'CN8',N'Vận tải kinh tế đường bộ và thành phố')
insert into ChuyenNganh values(N'CN9',N'Vận tải đa phương thức')

insert into ChuyenNganh values(N'CN10',N'Tự động hóa')
insert into ChuyenNganh values(N'CN11',N'Kỹ thuật thông tin và truyền thông')
insert into ChuyenNganh values(N'CN12',N'Hệ thống điện Giao thông và Công nghiệp')

insert into ChuyenNganh values(N'CN13',N'Kỹ thuật ô tô')
insert into ChuyenNganh values(N'CN14',N'Cơ giới hóa xây dựng cầu đường')
insert into ChuyenNganh values(N'CN15',N'Cơ điện tử')

insert into ChuyenNganh values(N'CN16',N'Công nghệ thông tin')
insert into ChuyenNganh values(N'CN17',N'Mạng máy tính')
insert into ChuyenNganh values(N'CN18',N'Cơ sở dữ liệu')

insert into DMGiaoTrinh values(N'GT1',N'Giáo trình kỹ thuật xây dựng Cầu - Đường bộ',N'TG1',2005,4,N'CN1',80,N'Các kỹ thuật xây dựng Cầu - Đường bộ',9,N'1.jpg')
insert into DMGiaoTrinh values(N'GT2',N'Giáo trình kỹ thuật xây dựng Cầu hầm',N'TG1',2003,6,N'CN2',60,N'Các kỹ thuật xây dựng Cầu hầm',8,N'2.jpg')
insert into DMGiaoTrinh values(N'GT3',N'Giáo trình công trình Giao thông đô thị',N'TG7',2007,7,N'CN3',70,N'Công trình giao thông đô thị',7,N'3.jpg')
insert into DMGiaoTrinh values(N'GT4',N'Giáo trình Kinh tế quản lý khai thác cầu đường',N'TG2',2005,4,N'CN4',82,N'Kinh tế quản lý khai thác cầu đường',10,N'4.jpg')
insert into DMGiaoTrinh values(N'GT5',N'Giáo trình Quản lý xây dựng',N'TG8',2003,6,N'CN5',62,N'Quản lý xây dựng',11,N'5.jpg')
insert into DMGiaoTrinh values(N'GT6',N'Giáo trình Kinh tế xây dựng Công trình giao thông',N'TG8',2007,7,N'CN6',72,N'Kinh tế xây dựng Công trình giao thông',5,N'6.jpg')
insert into DMGiaoTrinh values(N'GT7',N'Giáo trình Logistics',N'TG3',2007,4,N'CN7',72,N'Logistics',10,N'7.jpg')
insert into DMGiaoTrinh values(N'GT8',N'Giáo trình Vận tải kinh tế đường bộ và thành phố',N'TG3',2008,6,N'CN8',66,N'Vận tải kinh tế đường bộ và thành phố',6,N'8.jpg')
insert into DMGiaoTrinh values(N'GT9',N'Giáo trình Vận tải đa phương thức',N'TG3',2009,7,N'CN9',99,N'Vận tải đa phương thức',8,N'9.jpg')

insert into DMGiaoTrinh values(N'GT10',N'Giáo trình Tự động hóa',N'TG4',2009,4,N'CN10',72,N'Tự động hóa',6,N'10.jpg')
insert into DMGiaoTrinh values(N'GT11',N'Giáo trình Kỹ thuật thông tin và truyền thông',N'TG4',2005,5,N'CN11',89,N'Kỹ thuật thông tin và truyền thông',9,N'11.jpg')
insert into DMGiaoTrinh values(N'GT12',N'Giáo trình Hệ thống điện Giao thông và Công nghiệp',N'TG4',20011,3,N'CN12',109,N'Hệ thống điện Giao thông và Công nghiệp',3,N'12.jpg')

insert into DMGiaoTrinh values(N'GT13',N'Giáo trình Kỹ thuật ô tô',N'TG5',2009,4,N'CN13',92,N'Kỹ thuật ô tô',4,N'13.jpg')
insert into DMGiaoTrinh values(N'GT14',N'Giáo trình Cơ giới hóa xây dựng cầu đường',N'TG5',2008,4,N'CN14',99,N'Cơ giới hóa xây dựng cầu đường',6,N'14.jpg')
insert into DMGiaoTrinh values(N'GT15',N'Giáo trình Cơ điện tử',N'TG5',20010,3,N'CN15',110,N'Cơ điện tử',5,N'15.jpg')

insert into DMGiaoTrinh values(N'GT16',N'Giáo trình Công nghệ thông tin',N'TG6',2011,3,N'CN16',108,N'Công nghệ thông tin',5,N'16.jpg')
insert into DMGiaoTrinh values(N'GT17',N'Giáo trình Mạng máy tính',N'TG9',2012,2,N'CN17',109,N'Mạng máy tính',3,N'17.jpg')
insert into DMGiaoTrinh values(N'GT18',N'Giáo trình Cơ sở dữ liệu',N'TG9',20010,3,N'CN18',112,N'Cơ sở dữ liệu',6,N'18.jpg')

insert into Que values(N'HN',N'Hà Nội')
insert into Que values(N'HP',N'Hải Phòng')
insert into Que values(N'ND',N'Nam Định')
insert into Que values(N'HD',N'Hải Dương')

insert into ThuThu values(N'TT1',N'Lê Phương',N'1',N'root',N'123',N'225 Cầu Diễm',N'0385119766',N'0985119766',N'HN')
insert into ThuThu values(N'TT2',N'Vũ Đức',N'0',N'Duc',N'123',N'2325 Cầu Giấy',N'0385765766',N'0985117656',N'HP')
insert into ThuThu values(N'TT3',N'Trần Minh',N'0',N'Minh',N'123',N'349 Đống Đa',N'0385109283',N'0985107264',N'ND')
insert into ThuThu values(N'TT4',N'Nguyễn Phóng',N'0',N'Phong',N'123',N'119 Cầu Diễm',N'0382758990',N'0982758990',N'HD')

insert into Phat values(N'PH1',100000)
insert into Phat values(N'PH2',200000)
insert into Phat values(N'PH3',300000)
insert into Phat values(N'PH4',400000)
insert into Phat values(N'PH5',500000)

insert into TheMuon values(N'MaThe1',N'Vũ Hoàng',N'Nam',N'ML2',N'KH6','false',0)
insert into TheMuon values(N'MaThe2',N'Trần Nhất Việt',N'Nữ',N'ML5',N'KH5','true',0)
insert into TheMuon values(N'MaThe3',N'Lê Thành Thật',N'Nam',N'ML9',N'KH5','false',3)
insert into TheMuon values(N'MaThe4',N'Nguyễn Thanh Như',N'Nữ',N'ML15',N'KH4','false',1)
insert into TheMuon values(N'MaThe5',N'Vũ Minh Hoàng',N'Nam',N'ML2',N'KH6','false',2)

insert into HSMuon values(N'HSM1',N'MaThe3',N'TT2','11/2/2022','11/30/2022','')
insert into HSMuon values(N'HSM2',N'MaThe4',N'TT2','11/8/2022','12/3/2022','')
insert into HSMuon values(N'HSM3',N'MaThe5',N'TT3','11/8/2022','12/3/2022','')
insert into HSMuon values(N'HSM4',N'MaThe2',N'TT1','10/8/2022','10/25/2022','')

insert into ChiTietHSMuon values(N'HSM1',N'GT13','true')
insert into ChiTietHSMuon values(N'HSM1',N'GT14','true')
insert into ChiTietHSMuon values(N'HSM1',N'GT15','true')
insert into ChiTietHSMuon values(N'HSM2',N'GT11','true')
insert into ChiTietHSMuon values(N'HSM3',N'GT17','true')
insert into ChiTietHSMuon values(N'HSM3',N'GT18','true')
insert into ChiTietHSMuon values(N'HSM4',N'GT14','false')

insert into HoSoTra values(N'HST1',N'HSM4','11/5/2022',100000,'',N'TT1' )
insert into ChiTietHSTra values(N'HST1',N'GT14',N'VIPH3',N'PH1')

