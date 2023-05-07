USE [master]
GO
/****** Object:  Database [QUANLYQUANCAPHE]    Script Date: 10/04/23 1:43:03 PM ******/
CREATE DATABASE [QUANLYQUANCAPHE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QUANLYQUANCAPHE', FILENAME = N'D:\Study\LT Windows\DBBANCAPHE\QUANLYQUANCAPHE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QUANLYQUANCAPHE_log', FILENAME = N'D:\Study\LT Windows\DBBANCAPHE\QUANLYQUANCAPHE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QUANLYQUANCAPHE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET ARITHABORT OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET  MULTI_USER 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QUANLYQUANCAPHE]
GO
/****** Object:  Table [dbo].[BAN]    Script Date: 10/04/23 1:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BAN](
	[MABAN] [nvarchar](50) NOT NULL,
	[TENBAN] [nvarchar](10) NULL,
	[TRANGTHAI] [varchar](50) NULL,
 CONSTRAINT [PK_BAN] PRIMARY KEY CLUSTERED 
(
	[MABAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHITIETHDB]    Script Date: 10/04/23 1:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHITIETHDB](
	[MACTHD] [varchar](20) NOT NULL,
	[MAHDB] [varchar](5) NOT NULL,
	[MACTSP] [varchar](5) NOT NULL,
	[GIAVON] [money] NULL,
	[GIABAN] [money] NULL,
	[GIABANSAUKHIGIAM] [money] NULL,
	[SOLUONG] [int] NULL,
	[TRANGTHAI] [nvarchar](20) NOT NULL CONSTRAINT [DF__CHITIETHD__TRANG__267ABA7A]  DEFAULT ((1)),
 CONSTRAINT [PK_CHITIETHD] PRIMARY KEY CLUSTERED 
(
	[MACTHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHITIETHDN]    Script Date: 10/04/23 1:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHITIETHDN](
	[MACTHDN] [varchar](50) NULL,
	[MAHDN] [char](3) NULL,
	[MACTSP] [varchar](5) NULL,
	[SOLUONG] [int] NULL,
	[DONGIA] [money] NULL,
	[TRANGTHAI] [nvarchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHITIETKM]    Script Date: 10/04/23 1:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHITIETKM](
	[MACTKM] [varchar](15) NOT NULL,
	[MACTHDB] [varchar](20) NULL,
	[MAKM] [varchar](10) NULL,
	[GIATIENSAUKHIGIAM] [money] NULL,
 CONSTRAINT [PK_CHITIETKM] PRIMARY KEY CLUSTERED 
(
	[MACTKM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHITIETSANPHAM]    Script Date: 10/04/23 1:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHITIETSANPHAM](
	[MACTSP] [varchar](5) NOT NULL,
	[MASP] [varchar](5) NOT NULL,
	[MASIZE] [char](1) NOT NULL,
	[SOLUONG] [int] NULL,
	[MOTA] [nvarchar](255) NULL,
	[GIABAN] [money] NULL,
	[GIAVON] [money] NULL,
	[TRANGTHAI] [nvarchar](20) NULL CONSTRAINT [DF__CHITIETSA__TRANG__276EDEB3]  DEFAULT ((1)),
 CONSTRAINT [PK_CHITIETSANPHAM] PRIMARY KEY CLUSTERED 
(
	[MACTSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DATBAN]    Script Date: 10/04/23 1:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DATBAN](
	[MABAN] [varchar](50) NOT NULL,
	[MAKH] [varchar](5) NOT NULL,
	[NGAYDAT] [datetime] NULL,
	[TRANGTHAI] [varchar](50) NULL,
	[MADATBAN] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HOADONBAN]    Script Date: 10/04/23 1:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOADONBAN](
	[MAHDB] [varchar](5) NOT NULL,
	[MAKH] [varchar](5) NULL,
	[TONGTIENTHANHTOAN] [money] NULL,
	[MANV_LAP] [varchar](5) NULL,
	[NGAYLAPHD] [datetime] NULL,
	[TRANGTHAI] [nvarchar](50) NULL CONSTRAINT [DF__HOADONBAN__TRANG__286302EC]  DEFAULT ((1)),
 CONSTRAINT [PK__HOADONBA__78C57A9BF50A65FE] PRIMARY KEY CLUSTERED 
(
	[MAHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HOADONNHAP]    Script Date: 10/04/23 1:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOADONNHAP](
	[MAHDN] [varchar](5) NOT NULL,
	[NGAYLAP] [datetime] NOT NULL,
	[MANV_LAP] [varchar](5) NOT NULL,
	[MANCC] [varchar](3) NULL,
	[TRANGTHAI] [nvarchar](20) NULL,
	[THANHTIEN] [money] NULL,
 CONSTRAINT [PK__HOADONNH__78C57AAFCB73AEEF] PRIMARY KEY CLUSTERED 
(
	[MAHDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 10/04/23 1:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MAKH] [varchar](5) NOT NULL,
	[TENKH] [nvarchar](255) NULL,
	[DIACHI] [nvarchar](255) NULL,
	[SDT] [char](10) NULL,
	[NGAYSINH] [datetime] NULL,
	[TRANGTHAI] [nvarchar](50) NULL CONSTRAINT [DF__KHACHHANG__TRANG__58D1301D]  DEFAULT ((1)),
 CONSTRAINT [PK__KHACHHAN__603F592C437B2FCC] PRIMARY KEY CLUSTERED 
(
	[MAKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHUYENMAI]    Script Date: 10/04/23 1:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHUYENMAI](
	[MAKM] [varchar](10) NOT NULL,
	[LOAIKHUYENMAI] [nvarchar](50) NULL,
	[TENKM] [nvarchar](50) NULL,
	[NGAYBATDAU] [datetime] NULL CONSTRAINT [DF__KHUYENMAI__NGAYT__2A4B4B5E]  DEFAULT (getdate()),
	[NGAYHETHAN] [datetime] NULL,
	[GIAMTHEOPHANTRAM] [float] NULL,
	[GIAMTIENTRUCTIEP] [money] NULL,
	[SUAGIA] [money] NULL,
	[TRANGTHAI] [nvarchar](50) NULL CONSTRAINT [DF__KHUYENMAI__TRANG__2B3F6F97]  DEFAULT ((0)),
 CONSTRAINT [PK__KHUYENMA__603F592B24047972] PRIMARY KEY CLUSTERED 
(
	[MAKM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHACC]    Script Date: 10/04/23 1:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHACC](
	[MANCC] [varchar](3) NOT NULL,
	[TENNCC] [nvarchar](50) NULL,
	[SDT] [char](10) NULL,
	[DIACHI] [nvarchar](100) NULL,
	[MOTA] [nvarchar](200) NULL,
	[TRANGTHAI] [nvarchar](50) NULL CONSTRAINT [DF__NHACC__TRANGTHAI__2D27B809]  DEFAULT ((1)),
 CONSTRAINT [PK__NHACC__7ABEA582FAACDC62] PRIMARY KEY CLUSTERED 
(
	[MANCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 10/04/23 1:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [varchar](5) NOT NULL,
	[TENNV] [nvarchar](255) NULL,
	[DIACHI] [nvarchar](255) NULL,
	[SDT] [char](10) NULL,
	[CHUCVU] [nvarchar](255) NULL,
	[NGAYVAOLAM] [datetime] NULL,
	[GIOITINH] [nvarchar](3) NULL,
	[NGAYSINH] [datetime] NULL,
	[TRANGTHAI] [nvarchar](50) NULL CONSTRAINT [DF__NHANVIEN__TRANGT__2E1BDC42]  DEFAULT ((1)),
 CONSTRAINT [PK__NHANVIEN__603F5114F0996120] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 10/04/23 1:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[MASP] [varchar](5) NOT NULL,
	[TENSP] [nvarchar](255) NULL,
	[LINK_IMG] [varchar](255) NULL,
	[DONVITINH] [nvarchar](25) NULL,
	[MOTA] [nvarchar](255) NULL,
	[TRANGTHAI] [nvarchar](20) NULL CONSTRAINT [DF__SANPHAM__TRANGTH__2F10007B]  DEFAULT ((1)),
	[MANCC] [char](3) NULL,
 CONSTRAINT [PK__SANPHAM__60228A3200703CE7] PRIMARY KEY CLUSTERED 
(
	[MASP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SIZE]    Script Date: 10/04/23 1:43:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SIZE](
	[MASIZE] [char](1) NOT NULL,
	[MOTA] [nvarchar](255) NULL,
	[TRANGTHAI] [bit] NOT NULL,
 CONSTRAINT [PK_SIZE] PRIMARY KEY CLUSTERED 
(
	[MASIZE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CHITIETHDB]  WITH CHECK ADD  CONSTRAINT [FK__CHITIETHD__MAHDB__76969D2E] FOREIGN KEY([MAHDB])
REFERENCES [dbo].[HOADONBAN] ([MAHDB])
GO
ALTER TABLE [dbo].[CHITIETHDB] CHECK CONSTRAINT [FK__CHITIETHD__MAHDB__76969D2E]
GO
ALTER TABLE [dbo].[CHITIETKM]  WITH CHECK ADD  CONSTRAINT [FK__CHITIETKM__MACTH__70DDC3D8] FOREIGN KEY([MACTHDB])
REFERENCES [dbo].[CHITIETHDB] ([MACTHD])
GO
ALTER TABLE [dbo].[CHITIETKM] CHECK CONSTRAINT [FK__CHITIETKM__MACTH__70DDC3D8]
GO
ALTER TABLE [dbo].[CHITIETKM]  WITH CHECK ADD  CONSTRAINT [FK__CHITIETKM__MAKM__6EF57B66] FOREIGN KEY([MAKM])
REFERENCES [dbo].[KHUYENMAI] ([MAKM])
GO
ALTER TABLE [dbo].[CHITIETKM] CHECK CONSTRAINT [FK__CHITIETKM__MAKM__6EF57B66]
GO
ALTER TABLE [dbo].[CHITIETSANPHAM]  WITH CHECK ADD  CONSTRAINT [FK__CHITIETSA__MASIZ__6E01572D] FOREIGN KEY([MASIZE])
REFERENCES [dbo].[SIZE] ([MASIZE])
GO
ALTER TABLE [dbo].[CHITIETSANPHAM] CHECK CONSTRAINT [FK__CHITIETSA__MASIZ__6E01572D]
GO
ALTER TABLE [dbo].[CHITIETSANPHAM]  WITH CHECK ADD  CONSTRAINT [FK__CHITIETSAN__MASP__7E37BEF6] FOREIGN KEY([MASP])
REFERENCES [dbo].[SANPHAM] ([MASP])
GO
ALTER TABLE [dbo].[CHITIETSANPHAM] CHECK CONSTRAINT [FK__CHITIETSAN__MASP__7E37BEF6]
GO
ALTER TABLE [dbo].[HOADONBAN]  WITH CHECK ADD  CONSTRAINT [FK__HOADONBAN__MAKH__5D95E53A] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KHACHHANG] ([MAKH])
GO
ALTER TABLE [dbo].[HOADONBAN] CHECK CONSTRAINT [FK__HOADONBAN__MAKH__5D95E53A]
GO
ALTER TABLE [dbo].[HOADONBAN]  WITH CHECK ADD  CONSTRAINT [FK__HOADONBAN__MANV___68487DD7] FOREIGN KEY([MANV_LAP])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[HOADONBAN] CHECK CONSTRAINT [FK__HOADONBAN__MANV___68487DD7]
GO
ALTER TABLE [dbo].[HOADONBAN]  WITH CHECK ADD  CONSTRAINT [FK_HOADONBAN_HOADONBAN] FOREIGN KEY([MAHDB])
REFERENCES [dbo].[HOADONBAN] ([MAHDB])
GO
ALTER TABLE [dbo].[HOADONBAN] CHECK CONSTRAINT [FK_HOADONBAN_HOADONBAN]
GO
ALTER TABLE [dbo].[HOADONNHAP]  WITH CHECK ADD FOREIGN KEY([MANCC])
REFERENCES [dbo].[NHACC] ([MANCC])
GO
ALTER TABLE [dbo].[HOADONNHAP]  WITH CHECK ADD FOREIGN KEY([MANV_LAP])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
USE [master]
GO
ALTER DATABASE [QUANLYQUANCAPHE] SET  READ_WRITE 
GO
