USE [DoAn]
GO
/****** Object:  UserDefinedTableType [dbo].[t_AttachedFile]    Script Date: 9/20/2024 10:55:57 AM ******/
CREATE TYPE [dbo].[t_AttachedFile] AS TABLE(
	[Id] [uniqueidentifier] NULL,
	[FileGroupCode] [nvarchar](50) NULL,
	[ProductID] [int] NULL,
	[FileKey] [nvarchar](50) NULL,
	[FileName] [nvarchar](255) NULL,
	[FileType] [nvarchar](50) NULL,
	[FileSize] [bigint] NULL,
	[FilePath] [nvarchar](255) NULL
)
GO
/****** Object:  UserDefinedFunction [dbo].[SplitString]    Script Date: 9/20/2024 10:55:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[SplitString] 
(
    -- Add the parameters for the function here
    @myString varchar(4000),
    @deliminator varchar(10)
)
RETURNS 
@ReturnTable TABLE 
(
    -- Add the column definitions for the TABLE variable here
    --[id] [int] IDENTITY(1,1) NOT NULL,
    [ID_] NVARCHAR(100) NULL
)
AS
BEGIN
	Declare @iSpaces INT
	Declare @part varchar(50)
	
	--initialize spaces
	Select @iSpaces = charindex(@deliminator,@myString,0)
	While @iSpaces > 0
	
	BEGIN
		Select @part = substring(@myString,0,charindex(@deliminator,@myString,0))
			Insert Into @ReturnTable(ID_)
			Select @part
			Select @myString = substring(@mystring,charindex(@deliminator,@myString,0)+ len(@deliminator),len(@myString) - charindex(' ',@myString,0))
			Select @iSpaces = charindex(@deliminator,@myString,0)
	END
	
    If len(@myString) > 0
    Insert Into @ReturnTable
    Select @myString
    
    RETURN 
END



GO
/****** Object:  UserDefinedFunction [dbo].[SplitStringTable]    Script Date: 9/20/2024 10:55:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[SplitStringTable] 
(
    -- Add the parameters for the function here
    @myString nvarchar(Max),
    @deliminator varchar(10)
)
RETURNS 
@ReturnTable TABLE 
(
    -- Add the column definitions for the TABLE variable here
    --[id] [int] IDENTITY(1,1) NOT NULL,
    [ID_] NVARCHAR(50) NULL
)
AS
BEGIN
	Declare @iSpaces INT
	Declare @part varchar(50)
	
	--initialize spaces
	Select @iSpaces = charindex(@deliminator,@myString,0)
	While @iSpaces > 0
	
	BEGIN
		Select @part = substring(@myString,0,charindex(@deliminator,@myString,0))
			Insert Into @ReturnTable(ID_)
			Select @part
			Select @myString = substring(@mystring,charindex(@deliminator,@myString,0)+ len(@deliminator),len(@myString) - charindex(' ',@myString,0))
			Select @iSpaces = charindex(@deliminator,@myString,0)
	END
	
    If len(@myString) > 0
    Insert Into @ReturnTable
    Select @myString
    
    RETURN 
END
GO
/****** Object:  Table [dbo].[AttachedFile]    Script Date: 9/20/2024 10:55:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttachedFile](
	[Id] [uniqueidentifier] NOT NULL,
	[FileGroupCode] [nvarchar](50) NULL,
	[ProductID] [int] NULL,
	[FileKey] [nvarchar](100) NULL,
	[FileName] [nvarchar](500) NULL,
	[FileType] [nvarchar](500) NULL,
	[FileSize] [int] NULL,
	[FilePath] [nvarchar](2000) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_AttachedFile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaiViet]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiViet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenBaiViet] [nvarchar](200) NULL,
	[ThongTin] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[DeletedBy] [nvarchar](150) NULL,
	[DeletedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[PhanHoi] [nvarchar](150) NULL,
 CONSTRAINT [PK_BaiViet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMucSanPham]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucSanPham](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMucSP] [nvarchar](100) NOT NULL,
	[MaDanhMucSP] [nvarchar](50) NULL,
	[MoTa] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[GroupFile] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[Status] [int] NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedBy] [nvarchar](150) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_DanhMucSanPham] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DatHang]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatHang](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaDon] [nvarchar](50) NULL,
	[TenKhachHang] [nvarchar](250) NULL,
	[SoDT] [nvarchar](200) NULL,
	[Email] [nvarchar](250) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[TongDon] [float] NULL,
	[Quantity] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[StatusId] [int] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedBy] [nvarchar](250) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_DatHang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DM_Module]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DM_Module](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModuleCode] [nvarchar](100) NULL,
	[ModuleName] [nvarchar](100) NULL,
	[TenViet] [nvarchar](100) NULL,
	[MoTa] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedBy] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[PhanHoi] [nvarchar](max) NULL,
 CONSTRAINT [PK_DM_Module] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[TenViet] [nvarchar](80) NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedBy] [nvarchar](150) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](150) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](100) NOT NULL,
	[DanhMucId] [int] NULL,
	[MaSanPham] [nvarchar](50) NULL,
	[MoTa] [nvarchar](100) NULL,
	[ThongTin] [nvarchar](max) NULL,
	[GiaGoc] [float] NULL,
	[IsSale] [bit] NULL,
	[PhanTramGiam] [float] NULL,
	[IsActive] [bit] NULL,
	[ModuleName] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[Status] [int] NULL,
	[Nam] [int] NULL,
	[DeletedBy] [nvarchar](150) NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[LinkAnh] [nvarchar](max) NULL,
	[PhanHoi] [nvarchar](max) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinDatHang]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinDatHang](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DatHangId] [int] NULL,
	[SanPhamId] [int] NULL,
	[Gia] [float] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_ThongTinDatHang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrangThai]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThai](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenTrangThai] [nvarchar](80) NULL,
 CONSTRAINT [PK_TrangThai] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[HoTen] [nvarchar](500) NULL,
	[Password] [nvarchar](max) NULL,
	[IsDisabled] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[Email] [nvarchar](max) NULL,
	[SoDT] [nvarchar](150) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[RoleId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AttachedFile] ([Id], [FileGroupCode], [ProductID], [FileKey], [FileName], [FileType], [FileSize], [FilePath], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy]) VALUES (N'284fc0d4-1775-ef11-8ccb-aced5cd62909', N'SanPham', 2017, N'FileAnh', N'product_7.png', N'image/png', 40641, N'~/FileUploaded/SanPham/20240918/1337106666925735439b6f8d76-99b8-4c5d-8c2e-5024c12c95b7.png', CAST(N'2024-09-18T00:11:09.583' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[AttachedFile] ([Id], [FileGroupCode], [ProductID], [FileKey], [FileName], [FileType], [FileSize], [FilePath], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy]) VALUES (N'66e39328-1875-ef11-8ccb-aced5cd62909', N'SanPham', 2018, N'FileAnh', N'product_10.png', N'image/png', 28748, N'~/FileUploaded/SanPham/20240918/133710668101506904cba44be6-807f-40d0-8bbc-df9c790fec11.png', CAST(N'2024-09-18T00:13:30.220' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[AttachedFile] ([Id], [FileGroupCode], [ProductID], [FileKey], [FileName], [FileType], [FileSize], [FilePath], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy]) VALUES (N'f0092869-1875-ef11-8ccb-aced5cd62909', N'SanPham', 2019, N'FileAnh', N'product_5.png', N'image/png', 18503, N'~/FileUploaded/SanPham/20240918/133710669184842068386d2e99-22f1-47fc-9fee-96d8c4d5064a.png', CAST(N'2024-09-18T00:15:18.567' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[AttachedFile] ([Id], [FileGroupCode], [ProductID], [FileKey], [FileName], [FileType], [FileSize], [FilePath], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy]) VALUES (N'72f8dbc2-1875-ef11-8ccb-aced5cd62909', N'SanPham', 2020, N'FileAnh', N'desc_2.jpg', N'image/jpeg', 39432, N'~/FileUploaded/SanPham/20240918/133710670690059059fff4e6b6-7371-4338-8ea8-0df47aa413c6.jpg', CAST(N'2024-09-18T00:17:49.060' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[AttachedFile] ([Id], [FileGroupCode], [ProductID], [FileKey], [FileName], [FileType], [FileSize], [FilePath], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy]) VALUES (N'73f8dbc2-1875-ef11-8ccb-aced5cd62909', N'SanPham', 2020, N'FileAnh', N'desc_1.jpg', N'image/jpeg', 21145, N'~/FileUploaded/SanPham/20240918/13371067069006528970e40eea-5dd5-470b-bd32-093d4515f737.jpg', CAST(N'2024-09-18T00:17:49.060' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[AttachedFile] ([Id], [FileGroupCode], [ProductID], [FileKey], [FileName], [FileType], [FileSize], [FilePath], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy]) VALUES (N'74f8dbc2-1875-ef11-8ccb-aced5cd62909', N'SanPham', 2020, N'FileAnh', N'desc_3.jpg', N'image/jpeg', 24243, N'~/FileUploaded/SanPham/20240918/133710670690075290af11f526-8d76-403f-8506-c480a01d4038.jpg', CAST(N'2024-09-18T00:17:49.060' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[AttachedFile] ([Id], [FileGroupCode], [ProductID], [FileKey], [FileName], [FileType], [FileSize], [FilePath], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy]) VALUES (N'28d629f1-1875-ef11-8ccb-aced5cd62909', N'SanPham', 2021, N'FileAnh', N'product_4.png', N'image/png', 31138, N'~/FileUploaded/SanPham/20240918/13371067146690040574b2b131-2665-494b-adf3-2dccdcea8afa.png', CAST(N'2024-09-18T00:19:06.747' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[AttachedFile] ([Id], [FileGroupCode], [ProductID], [FileKey], [FileName], [FileType], [FileSize], [FilePath], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy]) VALUES (N'2a7ae918-1975-ef11-8ccb-aced5cd62909', N'SanPham', 2022, N'FileAnh', N'product_6.png', N'image/png', 15393, N'~/FileUploaded/SanPham/20240918/133710672133815980fa165c5b-db1c-4b6c-a43b-ea227e0f8e48.png', CAST(N'2024-09-18T00:20:13.433' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[AttachedFile] ([Id], [FileGroupCode], [ProductID], [FileKey], [FileName], [FileType], [FileSize], [FilePath], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy]) VALUES (N'db37d043-1975-ef11-8ccb-aced5cd62909', N'SanPham', 2023, N'FileAnh', N'product_1.png', N'image/png', 27794, N'~/FileUploaded/SanPham/20240918/133710672853510794bae127ef-ce02-478a-930c-c16079e3a518.png', CAST(N'2024-09-18T00:21:25.410' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[AttachedFile] ([Id], [FileGroupCode], [ProductID], [FileKey], [FileName], [FileType], [FileSize], [FilePath], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy]) VALUES (N'ed3e73d7-1975-ef11-8ccb-aced5cd62909', N'SanPham', 2024, N'FileAnh', N'aocappy.jpg', N'image/jpeg', 7370, N'~/FileUploaded/SanPham/20240918/133710675330472050bdbbe351-e959-428b-bac2-3f157f222e25.jpg', CAST(N'2024-09-18T00:25:33.103' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[AttachedFile] ([Id], [FileGroupCode], [ProductID], [FileKey], [FileName], [FileType], [FileSize], [FilePath], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy]) VALUES (N'0ff9de03-1a75-ef11-8ccb-aced5cd62909', N'SanPham', 2025, N'FileAnh', N'aothunhoavan.jpg', N'image/jpeg', 5332, N'~/FileUploaded/SanPham/20240918/1337106760756501603baf8d35-676d-4bac-9c5a-a00414ef89af.jpg', CAST(N'2024-09-18T00:26:47.630' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[AttachedFile] ([Id], [FileGroupCode], [ProductID], [FileKey], [FileName], [FileType], [FileSize], [FilePath], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy]) VALUES (N'c23eff2f-1b75-ef11-8ccb-aced5cd62909', N'SanPham', 2026, N'FileAnh', N'aonu.jpg', N'image/jpeg', 36180, N'~/FileUploaded/SanPham/20240918/1337106811099860473c621b76-b29a-423b-bcb3-4d9ffbbd229e.jpg', CAST(N'2024-09-18T00:35:11.160' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[AttachedFile] ([Id], [FileGroupCode], [ProductID], [FileKey], [FileName], [FileType], [FileSize], [FilePath], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy]) VALUES (N'1e815cfd-2075-ef11-8ccb-aced5cd62909', N'BaiViet', 1, N'FileAnh', N'tin1.jpg', N'image/jpeg', 130579, N'~/FileUploaded/BaiViet/20240918/133710706028666054d0bde725-3ee6-40de-87dd-c04542a2a41a.jpg', CAST(N'2024-09-18T01:16:43.187' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[AttachedFile] ([Id], [FileGroupCode], [ProductID], [FileKey], [FileName], [FileType], [FileSize], [FilePath], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy]) VALUES (N'b0141d37-2175-ef11-8ccb-aced5cd62909', N'BaiViet', 2, N'FileAnh', N'tin2.jpeg', N'image/jpeg', 51274, N'~/FileUploaded/BaiViet/20240918/133710707000199355135a5eac-0e75-4b61-b079-25a1756c47e4.jpeg', CAST(N'2024-09-18T01:18:20.077' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[AttachedFile] ([Id], [FileGroupCode], [ProductID], [FileKey], [FileName], [FileType], [FileSize], [FilePath], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy]) VALUES (N'0a78f95c-2175-ef11-8ccb-aced5cd62909', N'BaiViet', 3, N'FileAnh', N'tin3.jpeg', N'image/jpeg', 102203, N'~/FileUploaded/BaiViet/20240918/13371070763547378710bac599-1a40-4330-932b-ab1103457087.jpeg', CAST(N'2024-09-18T01:19:23.597' AS DateTime), NULL, NULL, NULL, 0, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[BaiViet] ON 

INSERT [dbo].[BaiViet] ([Id], [TenBaiViet], [ThongTin], [MoTa], [NoiDung], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedBy], [DeletedDate], [IsActive], [IsDeleted], [PhanHoi]) VALUES (1, N'Nhiều học sinh nhập viện sau khi uống trà sữa liên hoan Trung thu', N'Sau khi uống trà sữa liên hoan dịp Trung thu, 21 học sinh có biểu hiện đau bụng, buồn nôn phải nhập viện.', N'Sau khi uống trà sữa liên hoan dịp Trung thu, 21 học sinh có biểu hiện đau bụng, buồn nôn phải nhập viện.', N'Chiều 16/9, trao đổi với Người Đưa Tin, bác sĩ Lê Thiện Thanh, Giám đốc Trung tâm Y tế Tp.Pleiku (tỉnh Gia Lai) cho biết, Trung tâm Y tế đã có báo cáo sơ bộ trường hợp nghi ngờ do ngộ độc thực phẩm xảy ra tại lớp 7.1 Trường trung học cơ sơ Tôn Đức Thắng (phường Thống nhất).

Hiện, Trung tâm Y tế Tp.Pleiku đã lấy mẫu trà sữa, niêm phong mẫu để phục vụ công tác xác minh nguyên nhân.

Theo bác sĩ Thanh, vào lúc 8h ngày 16/9, lớp 7.1 (Trường THCS Tôn Đức Thắng, địa chỉ 55 Phan Đăng Lưu, phường Thống Nhất, Tp.Pleiku) tổ chức liên hoan nhân ngày Tết Trung thu với tổng số 45 học sinh tham gia.

Trong đó, có 34/45 học sinh uống trà sữa do Hội phụ huynh lớp mua từ một cơ sở trà sữa ở Phùng Hưng, phường Hội Thương, Tp.Pleiku.

Nhiều học sinh nhập viện sau khi uống trà sữa liên hoan Trung thu- Ảnh 1.
Nhiều học sinh nghi bị ngộ độc do uống trà sữa. (Ảnh: BVCC).

Đến 9h sáng cùng ngày, 21/34 học sinh xuất hiện triệu chứng nghi đau bụng, buồn nôn. Trong đó, một học sinh nhập viện điều trị tại Bệnh viện Đại học Y Dược, Hoàng Anh Gia Lai, một học sinh đến khám tại Trạm Y tế phường Thống Nhất, đã uống Oresol và về nhà, 19 học sinh còn lại có biểu hiện nhẹ được phụ huynh đưa về nhà theo dõi.

Trung tâm Y tế Tp.Pleiku sẽ tiếp tục theo dõi sức khỏe của các học sinh có triệu chứng nghi ngờ ngộ độc thực phẩm, cũng như các học sinh có tham gia buổi liên hoan tại lớp 7.1 để có hướng giải quyết, xử lý kịp thời.

Bên cạnh đó, đơn vị tuyên truyền, hướng dẫn nhà trường tuân thủ các quy định của pháp luật về an toàn thực phẩm, đảm bảo sức khỏe học sinh, đặc biệt trong các hoạt động tổ chức Tết trung thu năm 2024 cho học sinh của trường.', CAST(N'2024-09-18T01:16:42.837' AS DateTime), N'admin', CAST(N'2024-09-18T01:16:53.503' AS DateTime), N'admin', NULL, NULL, 1, 0, NULL)
INSERT [dbo].[BaiViet] ([Id], [TenBaiViet], [ThongTin], [MoTa], [NoiDung], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedBy], [DeletedDate], [IsActive], [IsDeleted], [PhanHoi]) VALUES (2, N'[Info]: Khuyến cáo phòng chống dịch bệnh mùa bão lũ', N'Sau bão lụt và mưa lũ, dịch bệnh rất dễ bùng phát, dưới đây là khuyến cáo từ Bộ Y tế về phòng chống dịch bệnh mùa bão lũ.', N'Sau bão lụt và mưa lũ, dịch bệnh rất dễ bùng phát, dưới đây là khuyến cáo từ Bộ Y tế về phòng chống dịch bệnh mùa bão lũ.', N'Sau bão lụt và mưa lũ, dịch bệnh rất dễ bùng phát, dưới đây là khuyến cáo từ Bộ Y tế về phòng chống dịch bệnh mùa bão lũ.
[Info]: Khuyến cáo phòng chống dịch bệnh mùa bão lũ- Ảnh 1.
[Info]: Khuyến cáo phòng chống dịch bệnh mùa bão lũ- Ảnh 2.
[Info]: Khuyến cáo phòng chống dịch bệnh mùa bão lũ- Ảnh 3.
[Info]: Khuyến cáo phòng chống dịch bệnh mùa bão lũ- Ảnh 4.', CAST(N'2024-09-18T01:18:19.980' AS DateTime), N'admin', CAST(N'2024-09-18T01:18:19.980' AS DateTime), N'admin', NULL, NULL, 1, 0, NULL)
INSERT [dbo].[BaiViet] ([Id], [TenBaiViet], [ThongTin], [MoTa], [NoiDung], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedBy], [DeletedDate], [IsActive], [IsDeleted], [PhanHoi]) VALUES (3, N'Bộ Y tế: Phòng chống ngộ độc thực phẩm, khắc phục hậu quả bão số 3', N'Tại khu vực ngập lụt, sạt lở gây chia cắt, Cục An toàn thực phẩm (Bộ Y tế) khuyến khích người dân sử dụng thực phẩm chế biến sẵn, ăn ngay như: Lương khô, mỳ gói, nước uống đóng chai...', N'Tại khu vực ngập lụt, sạt lở gây chia cắt, Cục An toàn thực phẩm (Bộ Y tế) khuyến khích người dân sử dụng thực phẩm chế biến sẵn, ăn ngay như: Lương khô, mỳ gói, nước uống đóng chai...', N'Cục An toàn thực phẩm (Bộ Y tế) đã ban hành công văn số 2316 đề nghị Sở Y tế, Ban quản lý an toàn thực phẩm, Chi cục an toàn thực phẩm các tỉnh, thành phố khu vực miền Bắc bị ảnh hưởng trực tiếp của cơn bão số 3 thực hiện tăng cường công tác bảo đảm an toàn thực phẩm, phòng chống ngộ độc thực phẩm, khắc phục hậu quả cơn bão số 3.

Theo đó, Cục An toàn thực phẩm đề nghị đối với những khu vực bị ngập lụt, sạt lở gây chia cắt, có phương án đảm bảo cung cấp lương thực, thực phẩm, nước uống đảm bảo an toàn.

Khuyến khích người dân sử dụng thực phẩm chế biến sẵn, ăn ngay như: Lương khô, mỳ gói, nước uống đóng chai...

Bộ Y tế: Phòng chống ngộ độc thực phẩm, khắc phục hậu quả bão số 3- Ảnh 1.
Tăng cường công tác bảo đảm an toàn thực phẩm, phòng chống ngộ độc thực phẩm, khắc phục hậu quả cơn bão số 3.

Đồng thời, tuyên truyền, hướng dẫn người dân trong việc lựa chọn, chế biến và sử dụng thực phẩm an toàn. 

Tuyệt đối không sử dụng gia súc, gia cầm chết làm thức ăn hoặc chế biến thực phẩm. Trường hợp các nguồn cấp nước như: Giếng khoan, giếng khơi bị ngập úng thì phải được lọc và khử trùng trước khi sử dụng.

Bộ Y tế: Phòng chống ngộ độc thực phẩm, khắc phục hậu quả bão số 3- Ảnh 2.
Xử lý nước ăn, uống trong mùa lũ lụt.

Cục An toàn thực phẩm cũng đề nghị các đơn vị chỉ đạo, hướng dẫn và phối hợp với các đơn vị y tế dự phòng, các cơ sở điều trị và trạm y tế tăng cường công tác giám sát ngộ độc thực phẩm, bệnh truyền qua thực phẩm tại cộng đồng.', CAST(N'2024-09-18T01:19:23.500' AS DateTime), N'admin', CAST(N'2024-09-18T01:19:23.500' AS DateTime), N'admin', NULL, NULL, 1, 0, NULL)
SET IDENTITY_INSERT [dbo].[BaiViet] OFF
GO
SET IDENTITY_INSERT [dbo].[DanhMucSanPham] ON 

INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMucSP], [MaDanhMucSP], [MoTa], [IsActive], [GroupFile], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [DeletedDate], [DeletedBy], [IsDeleted]) VALUES (1, N'Áo nam', N'dm1', N'phong cách nam', 1, N'DanhMucSanPham', CAST(N'2024-07-29T22:13:32.473' AS DateTime), N'hoangdieu', CAST(N'2024-09-18T00:08:39.157' AS DateTime), N'admin', 1, CAST(N'2024-08-17T09:40:42.133' AS DateTime), NULL, 0)
INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMucSP], [MaDanhMucSP], [MoTa], [IsActive], [GroupFile], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [DeletedDate], [DeletedBy], [IsDeleted]) VALUES (8, N'Áo nữ', N'dm2', N'đồ dùng', 1, NULL, CAST(N'2024-08-06T00:23:00.577' AS DateTime), NULL, CAST(N'2024-09-18T00:08:30.760' AS DateTime), N'admin', 0, NULL, NULL, 0)
INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMucSP], [MaDanhMucSP], [MoTa], [IsActive], [GroupFile], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [DeletedDate], [DeletedBy], [IsDeleted]) VALUES (9, N'Áo đôi', N'dm3', N'áo đôi nam nữ mặc đều được', 1, NULL, CAST(N'2024-08-06T00:32:29.137' AS DateTime), NULL, CAST(N'2024-09-18T00:08:44.620' AS DateTime), N'admin', 0, NULL, NULL, 0)
INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMucSP], [MaDanhMucSP], [MoTa], [IsActive], [GroupFile], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [DeletedDate], [DeletedBy], [IsDeleted]) VALUES (1027, N'Phụ kiện', N'dm4', N'phụ kiện đi kèm', 1, NULL, CAST(N'2024-09-03T16:14:19.697' AS DateTime), N'admin', CAST(N'2024-09-18T00:05:11.680' AS DateTime), N'admin', NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[DanhMucSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[DatHang] ON 

INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (3, N'1dba7a78-c93c-4b0f-8ad9-fdccc380b056', N'hoangdieu', N'0896578568', N'hoangdieu2123@gmail.com', N'Hà Nội', 330000, 4, CAST(N'2024-08-28T16:56:40.347' AS DateTime), N'hoangdieu', NULL, NULL, 1, 0, NULL, NULL, NULL)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (4, N'a5c607db-5919-46a5-991c-7dd5773cb0e9', N'hoangdieu308', N'0896578568', N'hoangdieu2123@gmail.com', N'Hà Nội', 210000, 3, CAST(N'2024-08-30T22:59:25.973' AS DateTime), N'hoangdieu308', NULL, NULL, 2, 0, NULL, NULL, NULL)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (5, N'1ebd56a5-b218-4ff8-b4d4-9d1e3cca6f9b', N'Nguyễn Hoàng Kim', N'01248327534', N'admin123@gmail.com', N'Hòa bình', 200000, 2, CAST(N'2024-08-31T00:16:11.337' AS DateTime), N'Nguyễn Hoàng Kim', NULL, NULL, 4, 0, NULL, NULL, NULL)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (6, N'b7176b64-7696-4351-b445-682c6642a152', N'Nguyễn Hoàng Kim', N'01248327534', N'admin123@gmail.com', N'Hà Nội', 160000, 3, CAST(N'2024-08-31T00:28:02.430' AS DateTime), N'Nguyễn Hoàng Kim', NULL, NULL, 2, 0, NULL, NULL, 1)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (7, N'ad2e0f3e-039f-43d7-a999-76e637ad3bd0', N'Nguyễn Hoàng Kim', N'01248327534', N'admin123@gmail.com', N'Hà Nội', 30000, 2, CAST(N'2024-09-02T10:05:48.997' AS DateTime), N'Nguyễn Hoàng Kim', NULL, NULL, 2, 0, NULL, NULL, 1)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (8, N'ae858a18-e3ec-4946-becf-57ef8d448cba', N'Nguyen Hoang Dieu', N'0843429074', N'Thutrale156@gmail.com', N'Ha Noi', 240000, 2, CAST(N'2024-09-19T09:36:05.807' AS DateTime), N'Nguyen Hoang Dieu', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (9, N'172085df-960c-4135-98dd-3e750fc7c912', N'ThuTraLe', N'083453425', N'Thutrale156@gmail.com', N'Hà Nam', 2899000, 2, CAST(N'2024-09-19T09:48:20.747' AS DateTime), N'ThuTraLe', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (10, N'eb0331fd-7d26-4c15-b46e-6ef0d66b3819', N'NguyenHoangDieu', N'09759789789', N'hoangdieu61102@gmail.com', N'Hà Nội', 90000, 1, CAST(N'2024-09-19T09:53:32.117' AS DateTime), N'NguyenHoangDieu', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (11, N'c50a0b00-42f9-4907-9fb7-ecff69236a46', N'hoangdieu', N'06747635745', N'hoangdieu61102@gmail.com', N'Hà Nội', 350000, 1, CAST(N'2024-09-19T10:37:31.120' AS DateTime), N'hoangdieu', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (12, N'df7cb1c3-3498-4452-85d7-5c8df1757c46', N'nguyenhoangdieu', N'0768568755', N'hoangdieu61102@gmail.com', N'Ninh Binh', 300000, 1, CAST(N'2024-09-19T16:40:34.760' AS DateTime), N'nguyenhoangdieu', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (13, N'beff64a8-dc5f-4fa1-8a7e-9b4584ed2b53', N'hoangdieu', N'066786785', N'hoangdieu61102@gmail.com', N'Hà Tây', 150000, 1, CAST(N'2024-09-19T16:59:41.770' AS DateTime), N'hoangdieu', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (14, N'ce2f3627-ecdb-4f8e-a3c2-69b08a1ed534', N'hoangle', N'06474676', N'hoangdieu61102@gmail.com', N'Phú Yên', 350000, 1, CAST(N'2024-09-19T17:07:04.823' AS DateTime), N'hoangle', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (15, N'5f15fd32-5827-4267-b93c-c686b9050894', N'letien', N'0678568568', N'hoangdieu61102@gmail.com', N'Nam Định', 899000, 1, CAST(N'2024-09-19T17:15:47.323' AS DateTime), N'letien', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (16, N'1d5e03cb-acee-4bbb-822b-252bc938bd59', N'huyền trượng', N'0597897456', N'Thutrale156@gmail.com', N'Thái Bình', 120000, 1, CAST(N'2024-09-19T17:18:29.910' AS DateTime), N'huyền trượng', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (17, N'431e9f30-bb1a-4aca-9251-af44bf3c3b0d', N'tien cuong', N'068689860', N'daolien123@gmail.com', N'Phú Thọ', 120000, 1, CAST(N'2024-09-19T17:22:11.420' AS DateTime), N'tien cuong', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (18, N'2045b9ea-95d7-4564-87ec-8f7e47857bd1', N'pham tien', N'056785875856', N'hoangdieu61102@gmail.com', N'Sơn La', 150000, 1, CAST(N'2024-09-19T17:31:58.557' AS DateTime), N'pham tien', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (19, N'6df8782f-d7f1-49ef-b4a1-e694732be880', N'Hà', N'04684678658', N'daolien123@gmail.com', N'Vĩnh Phúc', 899000, 1, CAST(N'2024-09-19T17:39:15.240' AS DateTime), N'Hà', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (20, N'd1b0b556-f64a-4f5c-add8-5a0c3761d3c5', N'test1909', N'07855787665', N'daolien123@gmail.com', N'Hà Nội', 150000, 1, CAST(N'2024-09-19T17:50:26.227' AS DateTime), N'test1909', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (21, N'5f799bb2-6fa8-43dd-afab-80f59297f5ee', N'lu khach qua duong', N'0956745756', N'daolien123@gmail.com', N'Hà Văn', 150000, 1, CAST(N'2024-09-19T18:07:26.647' AS DateTime), N'lu khach qua duong', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (22, N'c1af9896-ad6c-4c29-bf34-a1d069f1be99', N'hihi', N'0124235355', N'hoangdieu61102@gmail.com', N'Hải Phòng', 490000, 1, CAST(N'2024-09-19T18:12:59.400' AS DateTime), N'hihi', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (23, N'62c79a2b-3dce-4b45-8712-6625b7dd9829', N'lu khach qua duong 1', N'078676543', N'hoangdieu61102@gmail.com', N'Hải Dương', 899000, 1, CAST(N'2024-09-19T18:14:17.503' AS DateTime), N'lu khach qua duong 1', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (24, N'31c0048a-c207-44a2-869b-1cfd674998ab', N'lu khach 3', N'056745757', N'hoangdieu61102@gmail.com', N'Hồ Chí Minh', 150000, 1, CAST(N'2024-09-19T18:45:42.360' AS DateTime), N'lu khach 3', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (25, N'74c41125-996c-4dd0-9dad-f6fff9f5c7e7', N'lk3', N'0456654', N'hoangdieu61102@gmail.com', N'Hy', 150000, 1, CAST(N'2024-09-19T18:52:17.710' AS DateTime), N'lk3', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (26, N'9541afcf-c782-47f1-98aa-906b51ff7bc5', N'lk4', N'0865636456', N'hoangdieu61102@gmail.com', N'Hưng Yên', 120000, 1, CAST(N'2024-09-19T18:54:18.510' AS DateTime), N'lk4', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (27, N'22611f29-26c9-4eeb-8c2a-6687a686fb2c', N'lk5', N'03534654634', N'hoangdieu61102@gmail.com', N'Thái Nguyên', 350000, 1, CAST(N'2024-09-19T18:56:42.527' AS DateTime), N'lk5', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (28, N'd0f3d456-1598-499b-b32e-0e1efb6867de', N'Nguyễn Hoàng Kim', N'01248327534', N'admin123@gmail.com', N'Hà Nội', 150000, 1, CAST(N'2024-09-20T08:22:19.640' AS DateTime), N'Nguyễn Hoàng Kim', NULL, NULL, 2, 0, NULL, NULL, 1)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (29, N'7f58049d-2d3b-40b0-92be-dd375ff33294', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 250000, 1, CAST(N'2024-09-20T08:29:55.267' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (30, N'161c342d-d654-45a6-a019-41bb4cb3f168', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 350000, 1, CAST(N'2024-09-20T08:39:31.000' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (31, N'34479329-f887-4ae0-85b6-1a1e75ddf888', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 899000, 1, CAST(N'2024-09-20T08:44:00.937' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (32, N'd580dc8e-f574-4c3c-9661-48d4ff941db0', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 300000, 1, CAST(N'2024-09-20T08:48:04.763' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (33, N'b7077918-3cfd-40a8-8bdf-6e1b2f31d6d4', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 300000, 1, CAST(N'2024-09-20T08:50:17.497' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (34, N'dfad0bfe-85e9-4436-af93-d2db1f4f02ac', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han Sing', 2000000, 1, CAST(N'2024-09-20T09:12:15.220' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (35, N'3938dcca-ddb3-43e4-a657-e8801f820ad9', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 490000, 1, CAST(N'2024-09-20T09:13:29.817' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (36, N'1b93f9f6-d3d2-4f50-bb38-208ba8a1e437', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 120000, 1, CAST(N'2024-09-20T09:15:58.123' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (37, N'43bcefd4-9675-496e-95bc-f932bd46094a', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 350000, 1, CAST(N'2024-09-20T09:29:14.340' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (38, N'd9e63112-aa5d-4fb5-8aed-20c8ae0d7b13', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 399000, 1, CAST(N'2024-09-20T09:32:10.320' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (39, N'97f43bb3-58b9-4080-a556-832edaaa7a6d', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 350000, 1, CAST(N'2024-09-20T09:38:52.507' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (40, N'5556c33d-d0b9-40e4-9acd-63545a3ccdbd', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 490000, 1, CAST(N'2024-09-20T09:42:25.187' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (41, N'2556a23d-2f17-4fd2-8174-a3106c5958aa', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 899000, 1, CAST(N'2024-09-20T09:48:55.720' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (42, N'37792d1c-f653-4b56-826b-abeebdb3d367', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 350000, 1, CAST(N'2024-09-20T09:52:59.650' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (43, N'81d6affb-0618-41ce-ae11-6ad429b76f31', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 2000000, 1, CAST(N'2024-09-20T09:55:36.373' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (44, N'a3e48701-d234-4525-b8ad-4cc53624f857', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 120000, 1, CAST(N'2024-09-20T10:06:13.507' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (45, N'2c710249-b5c6-43c3-8859-5a750d04302b', N'lk6', N'0356246426', N'hoangdieu61102@gmail.com', N'Quảng Bình', 90000, 1, CAST(N'2024-09-20T10:18:00.177' AS DateTime), N'lk6', NULL, NULL, 2, 0, NULL, NULL, 0)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (46, N'0dc4a2fe-6acb-45e0-ade8-15a8fae8270c', N'LeThiLai', N'01348327599', N'lelai123@gmail.com', N'Han', 899000, 1, CAST(N'2024-09-20T10:31:47.130' AS DateTime), N'LeThiLai', NULL, NULL, 2, 0, NULL, NULL, 7)
INSERT [dbo].[DatHang] ([Id], [MaDon], [TenKhachHang], [SoDT], [Email], [DiaChi], [TongDon], [Quantity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [StatusId], [IsDeleted], [DeletedDate], [DeletedBy], [UserId]) VALUES (47, N'1d4cf5d2-8c98-4e83-b103-173245337d2b', N'Hoàng Vũ Biên', N'06857858979', N'vubien@gmail.com', N'Hà Nội', 90000, 1, CAST(N'2024-09-20T10:43:27.977' AS DateTime), N'Hoàng Vũ Biên', NULL, NULL, 2, 0, NULL, NULL, 20)
SET IDENTITY_INSERT [dbo].[DatHang] OFF
GO
SET IDENTITY_INSERT [dbo].[DM_Module] ON 

INSERT [dbo].[DM_Module] ([Id], [ModuleCode], [ModuleName], [TenViet], [MoTa], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy], [IsActive], [PhanHoi]) VALUES (4, N'san-pham', N'SanPham', N'Sản phẩm', N'chứa các sản phẩm', CAST(N'2024-08-23T22:42:16.957' AS DateTime), N'admin', CAST(N'2024-08-23T22:42:16.957' AS DateTime), N'admin', 0, NULL, NULL, 1, NULL)
INSERT [dbo].[DM_Module] ([Id], [ModuleCode], [ModuleName], [TenViet], [MoTa], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy], [IsActive], [PhanHoi]) VALUES (5, N'bai-viet', N'BaiViet', N'Bài viết', N'Chứa bài viết', CAST(N'2024-08-23T20:43:03.350' AS DateTime), N'admin', CAST(N'2024-08-19T14:07:46.650' AS DateTime), N'admin', 0, NULL, NULL, 1, NULL)
INSERT [dbo].[DM_Module] ([Id], [ModuleCode], [ModuleName], [TenViet], [MoTa], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy], [IsActive], [PhanHoi]) VALUES (6, N'danh-muc-san-pham', N'DMSanPham', N'Danh mục sản phẩm', N'Chứa danh mục sản phẩm', CAST(N'2024-08-23T20:44:04.090' AS DateTime), N'admin', CAST(N'2024-09-02T17:31:19.533' AS DateTime), N'admin', 0, NULL, NULL, 0, N'chỉ dùng để lấy dữ liệu')
INSERT [dbo].[DM_Module] ([Id], [ModuleCode], [ModuleName], [TenViet], [MoTa], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy], [IsActive], [PhanHoi]) VALUES (7, N'trang-chu', N'Home', N'Trang chủ', N'Trang chủ người dùng', CAST(N'2024-08-24T00:38:49.893' AS DateTime), N'admin', CAST(N'2024-08-19T14:07:46.650' AS DateTime), N'admin', 0, NULL, NULL, 1, NULL)
INSERT [dbo].[DM_Module] ([Id], [ModuleCode], [ModuleName], [TenViet], [MoTa], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy], [IsActive], [PhanHoi]) VALUES (8, N'gioi-thieu', N'GioiThieu', N'Giới thiệu', N'Chứa thông tin, giới thiệu về shop', CAST(N'2024-09-02T23:12:05.160' AS DateTime), N'admin', CAST(N'2024-09-02T23:12:19.660' AS DateTime), N'admin', 0, NULL, NULL, 1, N'hiển thị trang chủ')
INSERT [dbo].[DM_Module] ([Id], [ModuleCode], [ModuleName], [TenViet], [MoTa], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy], [IsActive], [PhanHoi]) VALUES (9, N'lien-he', N'LienHe', N'Liên hệ', N'Chứa thông tin liên hệ', CAST(N'2024-09-02T23:22:37.480' AS DateTime), N'admin', CAST(N'2024-09-02T23:12:19.660' AS DateTime), N'admin', 0, NULL, NULL, 1, N'hiển thị trang chủ')
INSERT [dbo].[DM_Module] ([Id], [ModuleCode], [ModuleName], [TenViet], [MoTa], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [DeletedDate], [DeletedBy], [IsActive], [PhanHoi]) VALUES (10, N'test', N'test', N'test', N'testgdffdgdfgdgdfg', CAST(N'2024-09-02T23:39:46.840' AS DateTime), N'admin', CAST(N'2024-09-02T23:48:47.573' AS DateTime), N'admin', 1, CAST(N'2024-09-02T23:49:19.943' AS DateTime), NULL, 1, N'sfgsdgsdf')
SET IDENTITY_INSERT [dbo].[DM_Module] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [RoleName], [TenViet], [DeletedDate], [DeletedBy], [CreatedDate], [CreatedBy], [IsDeleted]) VALUES (1, N'Admin', N'Admin', NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Role] ([Id], [RoleName], [TenViet], [DeletedDate], [DeletedBy], [CreatedDate], [CreatedBy], [IsDeleted]) VALUES (2, N'Customer', N'Khách hàng', NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Role] ([Id], [RoleName], [TenViet], [DeletedDate], [DeletedBy], [CreatedDate], [CreatedBy], [IsDeleted]) VALUES (3, N'Staff', N'Nhân viên', NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([Id], [TenSanPham], [DanhMucId], [MaSanPham], [MoTa], [ThongTin], [GiaGoc], [IsSale], [PhanTramGiam], [IsActive], [ModuleName], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [Nam], [DeletedBy], [DeletedDate], [IsDeleted], [LinkAnh], [PhanHoi]) VALUES (2017, N'Áo len nam', 1, N'sp1', N'Áo Len Nam Nữ Cổ Lọ SUKIYA Chất Sợi Len Lông Thỏ mềm mại kiểu dáng Hàn Quốc AL14', N'Áo Len Nam Nữ Cổ Lọ SUKIYA Chất Sợi Len Lông Thỏ mềm mại kiểu dáng Hàn Quốc AL14', 200000, 0, 150000, 1, NULL, CAST(N'2024-09-18T00:11:09.237' AS DateTime), N'admin', CAST(N'2024-09-18T00:11:09.237' AS DateTime), N'admin', 0, 2023, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [DanhMucId], [MaSanPham], [MoTa], [ThongTin], [GiaGoc], [IsSale], [PhanTramGiam], [IsActive], [ModuleName], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [Nam], [DeletedBy], [DeletedDate], [IsDeleted], [LinkAnh], [PhanHoi]) VALUES (2018, N'Áo phông tay dài', 9, N'sp2', N'Áo thun gân nam dài tay unisex cổ tròn kiểu dáng trẻ trung năng động ELNIDO ED-01', N'Áo thun gân nam dài tay unisex cổ tròn kiểu dáng trẻ trung năng động ELNIDO ED-01', 100000, 0, 90000, 1, NULL, CAST(N'2024-09-18T00:13:30.110' AS DateTime), N'admin', CAST(N'2024-09-18T00:13:30.110' AS DateTime), N'admin', 0, 2023, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [DanhMucId], [MaSanPham], [MoTa], [ThongTin], [GiaGoc], [IsSale], [PhanTramGiam], [IsActive], [ModuleName], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [Nam], [DeletedBy], [DeletedDate], [IsDeleted], [LinkAnh], [PhanHoi]) VALUES (2019, N'Giày nam ', 1027, N'sp3', N'CS16 - Đen Nâu - Giày nam da bò - Xưởng Sản Xuất Chu Nam', N'CS16 - Đen Nâu - Giày nam da bò - Xưởng Sản Xuất Chu Nam', 400000, 0, 350000, 1, NULL, CAST(N'2024-09-18T00:15:18.470' AS DateTime), N'admin', CAST(N'2024-09-18T00:15:18.470' AS DateTime), N'admin', 0, 2021, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [DanhMucId], [MaSanPham], [MoTa], [ThongTin], [GiaGoc], [IsSale], [PhanTramGiam], [IsActive], [ModuleName], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [Nam], [DeletedBy], [DeletedDate], [IsDeleted], [LinkAnh], [PhanHoi]) VALUES (2020, N'Áo Khoác Cardigan', 9, N'sp4', N'Áo Khoác Cardigan Len Mỏng Jussy Fashion Phong Cách Áo Len Ulzzang Cho Nữ Nhiều Màu Hot', N'Áo Khoác Cardigan Len Mỏng Jussy Fashion Phong Cách Áo Len Ulzzang Cho Nữ Nhiều Màu Hot', 500000, 0, 490000, 1, NULL, CAST(N'2024-09-18T00:17:49.003' AS DateTime), N'admin', CAST(N'2024-09-18T00:17:49.003' AS DateTime), N'admin', 0, 2020, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [DanhMucId], [MaSanPham], [MoTa], [ThongTin], [GiaGoc], [IsSale], [PhanTramGiam], [IsActive], [ModuleName], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [Nam], [DeletedBy], [DeletedDate], [IsDeleted], [LinkAnh], [PhanHoi]) VALUES (2021, N'Túi sách trắng', 1027, N'sp5', N'Túi đeo vai gradient màu trắng tinh tế và sành điệu', N'Túi đeo vai gradient màu trắng tinh tế và sành điệu', 500000, 0, 399000, 1, NULL, CAST(N'2024-09-18T00:19:06.670' AS DateTime), N'admin', CAST(N'2024-09-18T00:19:06.670' AS DateTime), N'admin', 0, 2024, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [DanhMucId], [MaSanPham], [MoTa], [ThongTin], [GiaGoc], [IsSale], [PhanTramGiam], [IsActive], [ModuleName], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [Nam], [DeletedBy], [DeletedDate], [IsDeleted], [LinkAnh], [PhanHoi]) VALUES (2022, N'Kính dâm', 1027, N'sp6', N'Kính râm thời trang vuông KATELUO dành cho nam và nữ Kính râm phân cực khung TR Thích hợp để lái xe ', N'Kính râm thời trang vuông KATELUO dành cho nam và nữ Kính râm phân cực khung TR Thích hợp để lái xe và đi chơi 5803', 2000000, 0, 120000, 1, NULL, CAST(N'2024-09-18T00:20:13.370' AS DateTime), N'admin', CAST(N'2024-09-18T00:20:13.370' AS DateTime), N'admin', 0, 2024, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [DanhMucId], [MaSanPham], [MoTa], [ThongTin], [GiaGoc], [IsSale], [PhanTramGiam], [IsActive], [ModuleName], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [Nam], [DeletedBy], [DeletedDate], [IsDeleted], [LinkAnh], [PhanHoi]) VALUES (2023, N'Áo Hoodie', 9, N'sp7', N'Áo Hoodie Nỉ Bông Unisex in logo BAMIHOME Cao Cấp Form Basic AHD01', N'Áo Hoodie Nỉ Bông Unisex in logo BAMIHOME Cao Cấp Form Basic AHD01', 300000, 0, 0, 1, NULL, CAST(N'2024-09-18T00:21:25.313' AS DateTime), N'admin', CAST(N'2024-09-18T01:10:06.963' AS DateTime), N'admin', 0, 2024, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [DanhMucId], [MaSanPham], [MoTa], [ThongTin], [GiaGoc], [IsSale], [PhanTramGiam], [IsActive], [ModuleName], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [Nam], [DeletedBy], [DeletedDate], [IsDeleted], [LinkAnh], [PhanHoi]) VALUES (2024, N'Áo CappyBara', 1, N'sp10', N'Áo thun FIDE CAPYBARA unisex form rộng cổ tròn CAPYBARA - AT57 Cotton', N'Áo thun FIDE CAPYBARA unisex form rộng cổ tròn CAPYBARA - AT57 Cotton', 1000000, 0, 899000, 1, NULL, CAST(N'2024-09-18T00:25:33.037' AS DateTime), N'admin', CAST(N'2024-09-18T00:25:33.037' AS DateTime), N'admin', 0, 2024, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [DanhMucId], [MaSanPham], [MoTa], [ThongTin], [GiaGoc], [IsSale], [PhanTramGiam], [IsActive], [ModuleName], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [Nam], [DeletedBy], [DeletedDate], [IsDeleted], [LinkAnh], [PhanHoi]) VALUES (2025, N'Áo thun in ', 1, N'sp9', N'Áo thun Paradox® THE REVERIE', N'Áo thun Paradox® THE REVERIE', 2000000, 0, 0, 1, NULL, CAST(N'2024-09-18T00:26:47.557' AS DateTime), N'admin', CAST(N'2024-09-18T00:26:47.557' AS DateTime), N'admin', 0, 2022, NULL, NULL, 0, NULL, NULL)
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [DanhMucId], [MaSanPham], [MoTa], [ThongTin], [GiaGoc], [IsSale], [PhanTramGiam], [IsActive], [ModuleName], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Status], [Nam], [DeletedBy], [DeletedDate], [IsDeleted], [LinkAnh], [PhanHoi]) VALUES (2026, N'Áo nữ sơ mi', 8, N'sp10', N'Áo sơ mi nữ form rộng vải Kate siêu mịn, Trắng, M
', N'Áo sơ mi nữ form rộng vải Kate siêu mịn, Trắng, M
', 250000, 0, 0, 1, NULL, CAST(N'2024-09-18T00:35:10.987' AS DateTime), N'admin', CAST(N'2024-09-18T00:35:10.987' AS DateTime), N'admin', 0, 2023, NULL, NULL, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[ThongTinDatHang] ON 

INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (1, 3, 1, 10000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (2, 3, 5, 100000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (3, 3, 4, 100000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (4, 3, 1015, 120000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (5, 4, 1, 10000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (6, 4, 4, 100000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (7, 4, 1017, 100000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (8, 5, 4, 100000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (9, 5, 5, 100000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (11, 6, 1, 10000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (12, 6, 2, 50000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (13, 6, 4, 100000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (14, 7, 1, 10000, 2)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (15, 7, 1016, 10000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (16, 8, 2017, 150000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (17, 8, 2018, 90000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (18, 9, 2024, 899000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (19, 9, 2025, 2000000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (20, 10, 2018, 90000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (21, 11, 2019, 350000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (22, 12, 2017, 150000, 2)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (23, 13, 2017, 150000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (24, 14, 2019, 350000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (25, 15, 2024, 899000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (26, 16, 2022, 120000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (27, 18, 2017, 150000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (28, 0, 2023, 300000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (29, 0, 2017, 150000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (30, 19, 2024, 899000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (31, 20, 2017, 150000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (32, 21, 2017, 150000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (33, 22, 2020, 490000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (34, 23, 2024, 899000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (35, 24, 2017, 150000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (36, 25, 2017, 150000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (37, 26, 2022, 120000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (38, 27, 2019, 350000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (39, 28, 2017, 150000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (40, 29, 2026, 250000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (41, 30, 2019, 350000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (42, 31, 2024, 899000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (43, 32, 2023, 300000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (44, 33, 2023, 300000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (45, 34, 2025, 2000000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (46, 35, 2020, 490000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (47, 36, 2022, 120000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (48, 37, 2019, 350000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (49, 38, 2021, 399000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (50, 39, 2019, 350000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (51, 40, 2020, 490000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (52, 41, 2024, 899000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (53, 42, 2019, 350000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (54, 43, 2025, 2000000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (55, 44, 2022, 120000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (56, 45, 2018, 90000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (57, 46, 2024, 899000, 1)
INSERT [dbo].[ThongTinDatHang] ([Id], [DatHangId], [SanPhamId], [Gia], [Quantity]) VALUES (58, 47, 2018, 90000, 1)
SET IDENTITY_INSERT [dbo].[ThongTinDatHang] OFF
GO
SET IDENTITY_INSERT [dbo].[TrangThai] ON 

INSERT [dbo].[TrangThai] ([Id], [TenTrangThai]) VALUES (1, N'Đã thanh toán')
INSERT [dbo].[TrangThai] ([Id], [TenTrangThai]) VALUES (2, N'Chưa thanh toán')
INSERT [dbo].[TrangThai] ([Id], [TenTrangThai]) VALUES (3, N'Đang xử lý')
INSERT [dbo].[TrangThai] ([Id], [TenTrangThai]) VALUES (4, N'Đã hủy')
SET IDENTITY_INSERT [dbo].[TrangThai] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserName], [HoTen], [Password], [IsDisabled], [IsDeleted], [Email], [SoDT], [DiaChi], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (1, N'admin', N'Nguyễn Hoàng Kim', N'admin123', 0, 0, N'admin123@gmail.com', N'01248327534', N'Hà Nội', CAST(N'2024-08-15T17:21:08.460' AS DateTime), N'hoangdieu', NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [UserName], [HoTen], [Password], [IsDisabled], [IsDeleted], [Email], [SoDT], [DiaChi], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (2, N'admin2', N'Lê Văn Đạt', N'admin456', 0, 0, N'admin456@gmail.com', N'01348327599', N'Hà Nội', CAST(N'2024-08-19T17:21:08.460' AS DateTime), N'hoangdieu', NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [UserName], [HoTen], [Password], [IsDisabled], [IsDeleted], [Email], [SoDT], [DiaChi], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (7, N'lelai123', N'LeThiLai', N'lelai123', 0, 1, N'lelai123@gmail.com', N'01348327599', N'Han', CAST(N'2024-08-19T16:44:50.090' AS DateTime), NULL, NULL, NULL, CAST(N'2024-08-21T14:05:46.830' AS DateTime), NULL)
INSERT [dbo].[User] ([Id], [UserName], [HoTen], [Password], [IsDisabled], [IsDeleted], [Email], [SoDT], [DiaChi], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (13, N'daohoa123', N'DaoThiHoa', N'daohoa2123', 0, 1, N'daohoa123@gmail.com', N'01348327599', N'Haà nội', CAST(N'2024-08-19T23:42:49.590' AS DateTime), NULL, NULL, NULL, CAST(N'2024-08-20T10:18:50.160' AS DateTime), NULL)
INSERT [dbo].[User] ([Id], [UserName], [HoTen], [Password], [IsDisabled], [IsDeleted], [Email], [SoDT], [DiaChi], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (14, N'daohoa123', N'DaoNhuHoa', N'daohoa2123', 0, 1, N'daohoa123@gmail.com', N'01348327599', N'Haà nội', CAST(N'2024-08-19T23:51:37.787' AS DateTime), NULL, NULL, NULL, CAST(N'2024-08-20T10:25:28.133' AS DateTime), NULL)
INSERT [dbo].[User] ([Id], [UserName], [HoTen], [Password], [IsDisabled], [IsDeleted], [Email], [SoDT], [DiaChi], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (16, N'daotien123', N'DaoNhuTien', N'daotien2123', NULL, 0, N'daotien123@gmail.com', NULL, N'Hà Nội', CAST(N'2024-08-21T14:07:35.500' AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [UserName], [HoTen], [Password], [IsDisabled], [IsDeleted], [Email], [SoDT], [DiaChi], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (17, N'test', N'test', N'test1', NULL, 0, N'daotien123@gmail.com', NULL, N'Hà Nội', CAST(N'2024-08-21T14:20:23.573' AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [UserName], [HoTen], [Password], [IsDisabled], [IsDeleted], [Email], [SoDT], [DiaChi], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (18, N'hoangtu', N'hoang van tu', N'admin123', 0, 0, N'hoangtu@gmail.com', NULL, N'Hà Nam ', CAST(N'2024-08-29T16:32:10.720' AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [UserName], [HoTen], [Password], [IsDisabled], [IsDeleted], [Email], [SoDT], [DiaChi], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (19, N'hoangtu2', N'hoang van tu', N'hoangtu2123', 0, 1, N'hoangtu2@gmail.com', NULL, N'Hà Nam ', CAST(N'2024-08-29T16:35:37.483' AS DateTime), NULL, NULL, NULL, CAST(N'2024-09-03T16:08:53.780' AS DateTime), N'admin')
INSERT [dbo].[User] ([Id], [UserName], [HoTen], [Password], [IsDisabled], [IsDeleted], [Email], [SoDT], [DiaChi], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (20, N'vubien', N'Hoàng Vũ Biên', N'vubien123', 0, 0, N'vubien@gmail.com', N'06857858979', N'Hà Nội', CAST(N'2024-09-03T16:11:19.463' AS DateTime), N'admin', NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([Id], [UserName], [HoTen], [Password], [IsDisabled], [IsDeleted], [Email], [SoDT], [DiaChi], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (25, N'thutra', N'Thu Tra Le', N'thutra123', 0, 0, N'Thutrale156@gmail.com', N'0345834275', N'Hà Nam ', CAST(N'2024-09-18T22:51:27.950' AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [UserId], [RoleId], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (1, 1, 1, CAST(N'2024-08-15T17:23:02.763' AS DateTime), N'admin', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserRole] ([Id], [UserId], [RoleId], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (2, 2, 3, CAST(N'2024-08-19T17:23:02.763' AS DateTime), N'admin', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserRole] ([Id], [UserId], [RoleId], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (7, 16, 2, CAST(N'2024-08-21T14:07:39.990' AS DateTime), NULL, NULL, N'a', NULL, NULL)
INSERT [dbo].[UserRole] ([Id], [UserId], [RoleId], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (8, 17, 1, CAST(N'2024-08-21T14:20:26.017' AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserRole] ([Id], [UserId], [RoleId], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (9, 18, 3, CAST(N'2024-08-29T16:32:25.250' AS DateTime), NULL, NULL, N'a', NULL, NULL)
INSERT [dbo].[UserRole] ([Id], [UserId], [RoleId], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (11, 20, 1, CAST(N'2024-09-03T16:11:19.873' AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserRole] ([Id], [UserId], [RoleId], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [DeletedDate], [DeletedBy]) VALUES (16, 25, 2, CAST(N'2024-09-18T22:51:30.450' AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
ALTER TABLE [dbo].[AttachedFile] ADD  CONSTRAINT [DF_AttachedFile_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[AttachedFile] ADD  CONSTRAINT [DF_AttachedFile_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[AttachedFile] ADD  CONSTRAINT [DF_AttachedFile_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[DM_Module] ADD  CONSTRAINT [DF_DM_Module_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[DM_Module] ADD  CONSTRAINT [DF_DM_Module_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  StoredProcedure [dbo].[AttachedFile_Delete]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[AttachedFile_Delete]
	@Id UNIQUEIDENTIFIER,
	@DeletedBy NVARCHAR(50)
AS
BEGIN
	UPDATE dbo.AttachedFile
	SET IsDeleted = 1,
	DeletedDate = GETDATE(),
	DeletedBy = @DeletedBy
	WHERE Id = @Id

	SELECT @@ROWCOUNT
END


GO
/****** Object:  StoredProcedure [dbo].[AttachedFile_GetAll]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AttachedFile_GetAll]
	@Keywords NVARCHAR(MAX),
	@FileGroupID INT,
	@Start INT,
	@Length INT,
	@Count INT = 0 OUTPUT
AS
BEGIN
	IF @Length > 0
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY af.CreatedDate DESC) AS Stt, af.*, 1 AS IsUploaded
		FROM dbo.AttachedFile af
		LEFT JOIN dbo.DM_Module m ON m.ModuleCode = af.FileGroupCode
		WHERE af.IsDeleted = 0
		AND (@Keywords = '' OR @Keywords IS NULL OR LOWER(af.[FileName]) LIKE N'%' + LOWER(@Keywords) + '%')
		AND (@FileGroupID = 0 OR m.Id = @FileGroupID)
		ORDER BY Stt OFFSET @Start ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY af.CreatedDate DESC) AS Stt, af.*, 1 AS IsUploaded
		FROM dbo.AttachedFile af
		LEFT JOIN dbo.DM_Module m ON m.ModuleCode = af.FileGroupCode
		WHERE af.IsDeleted = 0
		AND (@Keywords = '' OR @Keywords IS NULL OR LOWER(af.[FileName]) LIKE N'%' + LOWER(@Keywords) + '%')
		AND (@FileGroupID = 0 OR m.Id = @FileGroupID)
	END

	SET @Count = (
		SELECT COUNT(*) 
		FROM dbo.AttachedFile af
		LEFT JOIN dbo.DM_Module m ON m.ModuleCode = af.FileGroupCode
		WHERE af.IsDeleted = 0
		AND (@Keywords = '' OR @Keywords IS NULL OR LOWER(af.[FileName]) LIKE N'%' + LOWER(@Keywords) + '%')
		AND (@FileGroupID = 0 OR m.Id = @FileGroupID)
	)
END

GO
/****** Object:  StoredProcedure [dbo].[AttachedFile_GetByGroupProduct]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AttachedFile_GetByGroupProduct]
	@FileGroupCode NVARCHAR(50),
	@ProductIds NVARCHAR(MAX)
AS
BEGIN
	SELECT *, 1 AS IsUploaded
	FROM dbo.AttachedFile 
	WHERE IsDeleted = 0 AND FileGroupCode = @FileGroupCode
	AND ProductID IN (
		SELECT ID_ FROM dbo.SplitString(@ProductIds, ',')
	)
END


GO
/****** Object:  StoredProcedure [dbo].[AttachedFile_GetById]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AttachedFile_GetById]
	@Id	UNIQUEIDENTIFIER
AS
BEGIN
	SELECT * FROM dbo.AttachedFile
	WHERE Id = @Id
END



GO
/****** Object:  StoredProcedure [dbo].[AttachedFile_Insert]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AttachedFile_Insert]
	@ListFiles t_AttachedFile READONLY,
	@CreatedBy NVARCHAR(50)
AS
BEGIN

	-- Chèn dữ liệu vào bảng
	INSERT INTO dbo.AttachedFile
	        ( FileGroupCode ,
	          ProductID ,
	          FileKey ,
	          [FileName] ,
			  FileType,
			  FileSize,
	          FilePath ,
			  CreatedBy
	        )
	SELECT a.FileGroupCode, 
	a.ProductID, 
	a.FileKey,
	a.[FileName],
	a.FileType,
	a.FileSize, 
	a.FilePath,
	 @CreatedBy
	FROM @ListFiles a
	-- Trả về số lượng hàng đã chèn
	SELECT @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[BaiViet_Creat]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BaiViet_Creat]
    @TenBaiViet NVARCHAR(200),
    @ThongTin NVARCHAR(MAX),
    @MoTa NVARCHAR(MAX),
    @NoiDung NVARCHAR(MAX),
    @IsActive bit,
    @CreatedBy NVARCHAR(100)
AS
BEGIN
    INSERT INTO dbo.BaiViet
    (
        TenBaiViet,
        ThongTin,
        MoTa,
        NoiDung,
        IsActive,
        CreatedDate,
        CreatedBy,
        UpdatedDate,
        UpdatedBy,
		IsDeleted
    )
    VALUES
    (
        @TenBaiViet,
        @ThongTin,
        @MoTa,
        @NoiDung,
        1,
        GETDATE(),
        @CreatedBy,
        GETDATE(),
        @CreatedBy,
		0
    )
    SELECT @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[BaiViet_Delete]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BaiViet_Delete]
	@Ids NVARCHAR(MAX),
	@DeletedBy NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.BaiViet
	SET 
	IsDeleted = 1,
	DeletedDate = GETDATE(),
	DeletedBy = @DeletedBy
	WHERE Id IN(
		SELECT ID_ FROM dbo.SplitString(@Ids,',')
	)
	SELECT @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[BaiViet_GetAll]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BaiViet_GetAll]
	@Keywords NVARCHAR(200),
	@Start INT,
	@Length INT,
	@Count INT = 0 OUTPUT
AS
BEGIN
	IF OBJECT_ID(N'tempdb..#TempTable') IS NOT NULL DROP TABLE #TempTable
	SELECT DISTINCT bv.*
	INTO #TempTable 
	FROM BaiViet as bv
	LEFT JOIN AttachedFile as f on f.ProductID = bv.Id
	WHERE bv.IsDeleted = 0
		AND (ISNULL(@Keywords,'') ='' OR bv.TenBaiViet LIKE N'%' + @Keywords + '%')
	--check paging
	IF(@Length > 0) 
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate ) AS Stt, * FROM #TempTable
		ORDER BY Stt OFFSET @Start ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate )  AS  Stt, * FROM #TempTable
	END
	--Total Records 
	SET @Count = (SELECT COUNT(*) FROM #TempTable)

END
GO
/****** Object:  StoredProcedure [dbo].[BaiViet_GetAllActive]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BaiViet_GetAllActive]
@Keywords NVARCHAR(200),
	@Start INT,
	@Length INT,
	@Count INT = 0 OUTPUT
AS
BEGIN
	IF OBJECT_ID(N'tempdb..#TempTable') IS NOT NULL DROP TABLE #TempTable
	SELECT DISTINCT bv.*, f.FilePath
	INTO #TempTable 
	FROM BaiViet as bv
	LEFT JOIN AttachedFile as f on f.ProductID = bv.Id
	WHERE bv.IsDeleted = 0 AND bv.IsActive = 1
		AND (ISNULL(@Keywords,'') ='' OR bv.TenBaiViet LIKE N'%' + @Keywords + '%')
	--check paging
	IF(@Length > 0) 
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate ) AS Stt, * FROM #TempTable
		ORDER BY Stt OFFSET @Start ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate )  AS  Stt, * FROM #TempTable
	END
	--Total Records 
	SET @Count = (SELECT COUNT(*) FROM #TempTable)

END
GO
/****** Object:  StoredProcedure [dbo].[BaiViet_GetById]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BaiViet_GetById] 
	@Id int 
AS
BEGIN
	Select distinct bv.*
	from dbo.BaiViet as bv
	where bv.Id = @Id and bv.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[BaiViet_Update]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BaiViet_Update]
	@Id int,
	@TenBaiViet nvarchar(200),
	@NoiDung nvarchar(max),
	@MoTa nvarchar(max),
	@ThongTin nvarchar(max),
	@IsActive bit,
	@UpdatedBy nvarchar(200)
AS
BEGIN
	UPDATE dbo.BaiViet
	Set 
	TenBaiViet  = @TenBaiViet,
	MoTa = @MoTa,
	ThongTin = @ThongTin,
	NoiDung = @NoiDung,
	IsActive = 1,
	UpdatedBy = @UpdatedBy,
	UpdatedDate = GETDATE()
	WHERE Id = @Id
	Select @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[BaiViet_UpdateActive]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BaiViet_UpdateActive]
	@Ids NVARCHAR(MAX),
	@IsActive bit,
	@PhanHoi NVARCHAR(MAX),
	@UpdatedBy NVARCHAR(50)
AS
BEGIN
	UPDATE dbo.BaiViet
	SET [IsActive] = @IsActive,
	PhanHoi = @PhanHoi,
	UpdatedDate = GETDATE(),
	UpdatedBy = @UpdatedBy
	WHERE Id IN (
		SELECT ID_ FROM dbo.SplitString(@Ids, ',')
	)

	SELECT @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[DanhMucSanPham_Creat]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DanhMucSanPham_Creat] 
	@TenDanhMucSP NVARCHAR(100),
	@MaDanhMucSP NVARCHAR(200),
	@MoTa NVARCHAR(200),
	@IsActive Bit,
	@CreatedBy NVARCHAR(100)
AS
BEGIN
	INSERT INTO DanhMucSanPham
	(
		TenDanhMucSP
		,MaDanhMucSP 
		,MoTa 
		,IsActive 
		,CreatedBy 
		,CreatedDate
		,UpdatedBy
		,UpdatedDate
		,IsDeleted
	)
	VALUES
	(
		@TenDanhMucSP
		,@MaDanhMucSP
		,@MoTa
		,1
		,@CreatedBy
		,GETDATE()
		,@CreatedBy
		,GETDATE()
		,0
	)
	SELECT @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[DanhMucSanPham_Delete]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DanhMucSanPham_Delete]
	@Ids NVARCHAR(MAX),
	@DeletedBy NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.DanhMucSanPham
	SET 
	IsDeleted = 1,
	DeletedDate = GETDATE(),
	DeletedBy = @DeletedBy
	WHERE Id IN(
		SELECT ID_ FROM dbo.SplitString(@Ids,',')
	)
	SELECT @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[DanhMucSanPham_GetAll]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DanhMucSanPham_GetAll]
	@Keywords NVARCHAR(200)
	,@Start INT
	,@Length INT
	,@Count INT = 0 OUTPUT
AS
BEGIN
	IF OBJECT_ID(N'tempdb..#TempTable') IS NOT NULL DROP TABLE #TempTable
	SELECT DISTINCT dmsp.*
	INTO #TempTable
	FROM DanhMucSanPham AS dmsp
	WHERE IsDeleted = 0
	AND(ISNULL(@Keywords, '') = '' OR dmsp.TenDanhMucSP LIKE N'%' + @Keywords + '%')
	--check paging
	IF(@Length > 0)
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate) AS Stt, * FROM #TempTable
		ORDER BY Stt OFFSET @Start ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate) AS Stt, * FROM #TempTable
	END
	--Total Records
	SET @Count = (SELECT COUNT(*) FROM #TempTable)
END
GO
/****** Object:  StoredProcedure [dbo].[DanhMucSanPham_GetById]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DanhMucSanPham_GetById]
	@Id INT
AS
BEGIN
	SELECT * FROM DanhMucSanPham AS dmsp
	WHERE Id = @Id  
	AND dmsp.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[DanhMucSanPham_SelectList]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DanhMucSanPham_SelectList]
	@Keywords NVARCHAR(200)
AS
BEGIN
	SELECT DISTINCT dmsp.*
	FROM DanhMucSanPham AS dmsp
	WHERE dmsp.IsActive = 1
	AND (ISNULL(@Keywords,'') = '' OR dmsp.TenDanhMucSP LIKE N'%'+ @Keywords +'%')
END
GO
/****** Object:  StoredProcedure [dbo].[DanhMucSanPham_Update]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DanhMucSanPham_Update]
	@Id INT,
	@TenDanhMucSP NVARCHAR(200),
	@MaDanhMucSP NVARCHAR(100),
	@MoTa NVARCHAR(200),
	@IsActive BIT,
	@UpdatedBy NVARCHAR(200)
AS
BEGIN
	UPDATE DanhMucSanPham
	SET TenDanhMucSP = @TenDanhMucSP
	,MaDanhMucSP = @MaDanhMucSP
	,MoTa = @MoTa
	,IsActive = 1
	,UpdatedBy = @UpdatedBy
	,UpdatedDate = GETDATE()
	WHERE Id = @Id
	SELECT @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[DatHang_Creat]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DatHang_Creat]
	@MaDon NVARCHAR(300),
	@TenKhachHang NVARCHAR(300),
	@UserId INT,
	@SoDT NVARCHAR(MAX),
	@Email NVARCHAR(MAX) ,
	@DiaChi NVARCHAR(MAX),
	@TongDon FLOAT,
	@Quantity INT
	--@Status INT
AS
BEGIN
	INSERT INTO dbo.[DatHang]
	(
		MaDon,
		TenKhachHang,
		SoDT,
		Email,
		DiaChi,
		TongDon,
		Quantity,
		[StatusId],
		CreatedDate,
		CreatedBy,
		IsDeleted,
		UserId
	)
	VALUES
	(
		@MaDon,
		@TenKhachHang,
		@SoDT,
		@Email,
		@DiaChi,
		@TongDon,
		@Quantity,
		2,
		GETDATE(),
		@TenKhachHang,
		0,
		@UserId
	)
 SELECT @@IDENTITY AS 'Identity'
END
GO
/****** Object:  StoredProcedure [dbo].[DatHang_Delete]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[DatHang_Delete]
	@Ids NVARCHAR(MAX),
	@DeletedBy NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.DatHang
	SET 
	IsDeleted = 1,
	DeletedDate = GETDATE(),
	DeletedBy = @DeletedBy
	WHERE Id IN(
		SELECT ID_ FROM dbo.SplitString(@Ids,',')
	)
	SELECT @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[DatHang_GetAll]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DatHang_GetAll]
	@Keywords NVARCHAR(200)
	,@Start INT
	,@Length INT
	,@Count INT = 0 OUTPUT
AS
BEGIN
	IF OBJECT_ID(N'tempdb..#TempTable') IS NOT NULL DROP TABLE #TempTable
	SELECT DISTINCT dh.*, tt.TenTrangThai
	INTO #TempTable
	FROM DatHang AS dh
	LEFT JOIN TrangThai AS tt ON dh.StatusId = tt.Id
	WHERE IsDeleted = 0
	AND(ISNULL(@Keywords, '') = '' OR dh.TenKhachHang LIKE N'%' + @Keywords + '%')
	--check paging
	IF(@Length > 0)
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate) AS Stt, * FROM #TempTable
		ORDER BY Stt OFFSET @Start ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate) AS Stt, * FROM #TempTable
	END
	--Total Records
	SET @Count = (SELECT COUNT(*) FROM #TempTable)
END
GO
/****** Object:  StoredProcedure [dbo].[DatHang_GetById]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DatHang_GetById]
	@Id INT
AS
BEGIN
	SELECT DISTINCT dh.*,tt.TenTrangThai FROM DatHang AS dh
	LEFT JOIN TrangThai AS tt ON dh.StatusId = tt.Id
	WHERE dh.Id = @Id  
	AND dh.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[DatHang_Update]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DatHang_Update]
	@Id INT,
	@MaDon NVARCHAR(200), 
	@TenKhachHang NVARCHAR(200),
	@SoDT NVARCHAR(200), 
	@DiaChi NVARCHAR(200),
	@Email NVARCHAR(200), 
	@TongDon FLOAT,
	@Quantity INT,
	@Status INT,
	@UpdatedBy NVARCHAR(250)
AS	
BEGIN
	UPDATE dbo.DatHang
	Set MaDon = @MaDon,
	TenKhachHang = @TenKhachHang,
	SoDT = @SoDT,
	DiaChi = @DiaChi,
	Email =@Email,
	TongDon = @TongDon,
	Quantity = @Quantity,
	Status = @Status,
	UpdatedBy = @UpdatedBy,
	UpdatedDate = GETDATE()
	WHERE Id = @Id
	Select @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[DM_Module_GetAll]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DM_Module_GetAll]
	@Keywords NVARCHAR(200)
	,@Start INT
	,@Length INT
	,@Count INT = 0 OUTPUT
AS
BEGIN
	IF OBJECT_ID(N'tempdb..#TempTable') IS NOT NULL DROP TABLE #TempTable
	SELECT DISTINCT dm.*
	INTO #TempTable
	FROM DM_Module AS dm
	WHERE IsDeleted = 0
	AND(ISNULL(@Keywords, '') = '' OR dm.ModuleName LIKE N'%' + @Keywords + '%')
	--check paging
	IF(@Length > 0)
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate) AS Stt, * FROM #TempTable
		ORDER BY Stt OFFSET @Start ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate) AS Stt, * FROM #TempTable
	END
	--Total Records
	SET @Count = (SELECT COUNT(*) FROM #TempTable)
END
GO
/****** Object:  StoredProcedure [dbo].[DM_Module_GetAllActive]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DM_Module_GetAllActive]
	@Keywords NVARCHAR(200)
	,@Start INT
	,@Length INT
	,@Count INT = 0 OUTPUT
AS
BEGIN
	IF OBJECT_ID(N'tempdb..#TempTable') IS NOT NULL DROP TABLE #TempTable
	SELECT DISTINCT dm.*
	INTO #TempTable
	FROM DM_Module AS dm
	WHERE IsDeleted = 0
	AND IsActive = 1
	AND(ISNULL(@Keywords, '') = '' OR dm.ModuleName LIKE N'%' + @Keywords + '%')
	--check paging
	IF(@Length > 0)
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate) AS Stt, * FROM #TempTable
		ORDER BY Stt OFFSET @Start ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate) AS Stt, * FROM #TempTable
	END
	--Total Records
	SET @Count = (SELECT COUNT(*) FROM #TempTable)
END

GO
/****** Object:  StoredProcedure [dbo].[DMModule_Creat]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DMModule_Creat] 
	@ModuleName NVARCHAR(100),
	@TenViet NVARCHAR(200),
	@ModuleCode NVARCHAR(200),
	@CreatedBy NVARCHAR(100),
	@MoTa  NVARCHAR(250)
AS
BEGIN
	INSERT INTO DM_Module
	(
		ModuleName
		,ModuleCode
		,TenViet
		,CreatedBy 
		,CreatedDate
		,UpdatedBy
		,UpdatedDate
		,IsDeleted
		,MoTa
	)
	VALUES
	(
		@ModuleName
		,@ModuleCode
		,@TenViet
		,@CreatedBy
		,GETDATE()
		,@CreatedBy
		,GETDATE()
		,0
		,@MoTa
	)
	SELECT @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[DMModule_Delete]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[DMModule_Delete]
	@Ids NVARCHAR(MAX),
	@DeletedBy NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.DM_Module
	SET 
	IsDeleted = 1,
	DeletedDate = GETDATE(),
	DeletedBy = @DeletedBy
	WHERE Id IN(
		SELECT ID_ FROM dbo.SplitString(@Ids,',')
	)
	SELECT @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[DMModule_GetById]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DMModule_GetById]
	@Id INT
AS
BEGIN
	SELECT * FROM DM_Module AS dm
	WHERE Id = @Id  
	AND dm.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[DMModule_Update]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DMModule_Update]
	@Id int,
	@ModuleName nvarchar(100),
	@ModuleCode nvarchar(100),
	@TenViet nvarchar(100),
	@UpdatedBy nvarchar(200)
	,@MoTa nvarchar(200)
AS
BEGIN
	UPDATE dbo.DM_Module
	Set ModuleName = @ModuleName,
	ModuleCode = @ModuleCode,
	TenViet = @TenViet,
	UpdatedBy = @UpdatedBy,
	UpdatedDate = GETDATE(),
	MoTa = @MoTa
	WHERE Id = @Id
	Select @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[DMModule_UpdateActive]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DMModule_UpdateActive]
	@Ids NVARCHAR(MAX),
	@IsActive bit,
	@PhanHoi NVARCHAR(MAX),
	@UpdatedBy NVARCHAR(50)
AS
BEGIN
	UPDATE dbo.DM_Module
	SET [IsActive] = @IsActive,
	PhanHoi = @PhanHoi,
	UpdatedDate = GETDATE(),
	UpdatedBy = @UpdatedBy
	WHERE Id IN (
		SELECT ID_ FROM dbo.SplitString(@Ids, ',')
	)

	SELECT @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[Role_Creat]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Role_Creat]
	-- Add the parameters for the stored procedure here
	@RoleName NVARCHAR(50),
	@TenViet NVARCHAR(80),
	@CreatedBy NVARCHAR(150)
AS
BEGIN
	INSERT INTO dbo.[Role](
	RoleName,
	TenViet,
	CreatedBy,
	CreatedDate,
	IsDeleted
	)
	VALUES
	(
	@RoleName,
	@TenViet,
	@CreatedBy,
	GETDATE(),
	0
	)
	SELECT @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[Role_CreatRole]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Role_CreatRole]
	 @RoleName NVARCHAR(150),
	 @TenViet NVARCHAR(150),
    @CreatedBy NVARCHAR(100)
AS
BEGIN
    INSERT INTO dbo.[Role]
    (
        RoleName
		,TenViet
		,CreatedBy
		,CreatedDate
		,IsDeleted
    )
    VALUES
    (
        @RoleName,
		@TenViet,
		@CreatedBy,
		GETDATE(),
        0
    )
    SELECT @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[Role_Delete]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Role_Delete]
	@Ids NVARCHAR(MAX),
	@DeletedBy NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.[Role]
	SET 
	IsDeleted = 1,
	DeletedDate = GETDATE(),
	DeletedBy = @DeletedBy
	WHERE Id IN(
		SELECT ID_ FROM dbo.SplitString(@Ids,',')
	)
	SELECT @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[Role_GetAll]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Role_GetAll]
AS
BEGIN
	SELECT DISTINCT r.*
	FROM dbo.[Role] as r
END
GO
/****** Object:  StoredProcedure [dbo].[Role_GetAllPaging]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Role_GetAllPaging]
	@Keywords NVARCHAR(200)
	,@Start INT
	,@Length INT
	,@Count INT = 0 OUTPUT
AS
BEGIN
	IF OBJECT_ID(N'tempdb..#TempTable') IS NOT NULL DROP TABLE #TempTable
	SELECT DISTINCT r.*
	INTO #TempTable
	FROM dbo.[Role] AS r
	WHERE (ISNULL(@Keywords, '') = '' OR r.TenViet LIKE N'%' + @Keywords + '%')
	AND IsDeleted = 0
	--check paging
	IF(@Length > 0)
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate) AS Stt, * FROM #TempTable
		ORDER BY Stt OFFSET @Start ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate) AS Stt, * FROM #TempTable
	END
	--Total Records
	SET @Count = (SELECT COUNT(*) FROM #TempTable)
END
GO
/****** Object:  StoredProcedure [dbo].[Role_GetById]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Role_GetById]
	@Id int
AS
BEGIN
	Select * From dbo.[Role]
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Role_GetByUser]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Role_GetByUser]
	@UserId NVARCHAR(50)
AS
BEGIN
	SELECT ur.UserId, ur.RoleId, r.RoleName, r.TenViet
	FROM UserRole ur
	LEFT JOIN [Role] AS  r ON r.Id= ur.RoleId
	WHERE ur.UserId = @UserId
END

GO
/****** Object:  StoredProcedure [dbo].[SanPham_Creat]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SanPham_Creat]
	@Nam Int,
	@DanhMucId int,
	@TenSanPham NVARCHAR(200),
	@MaSanPham NVARCHAR(50),
	@MoTa NVARCHAR(100),
	@ThongTin NVARCHAR(MAX),
	@GiaGoc FLOAT,
	@PhanTramGiam FLOAT,
	@IsSale Bit,
	@IsActive bit,
	@CreatedBy NVARCHAR(100)
AS
BEGIN
	INSERT INTO dbo.SanPham
	(
	Nam,
	DanhMucId,
	TenSanPham,
	MaSanPham,
	MoTa,
	ThongTin,
	GiaGoc,
	PhanTramGiam,
	IsSale,
	IsActive,
	Status,
	CreatedDate,
	CreatedBy ,
	UpdatedDate ,
	UpdatedBy ,
	IsDeleted
	)
	VALUES
	(
		@Nam,
		@DanhMucId,
		@TenSanPham,
		@MaSanPham,
		@MoTa,
		@ThongTin,
		@GiaGoc,
		@PhanTramGiam,
		@IsSale,
		1,
		0,
		GETDATE(),
		@CreatedBy,
		GETDATE(),
		@CreatedBy,
		0
	)
 SELECT @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[SanPham_Delete]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SanPham_Delete]
	@Ids NVARCHAR(MAX),
	@DeletedBy NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.SanPham
	SET 
	IsDeleted = 1,
	DeletedDate = GETDATE(),
	DeletedBy = @DeletedBy
	WHERE Id IN(
		SELECT ID_ FROM dbo.SplitString(@Ids,',')
	)
	SELECT @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[SanPham_GetAll]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SanPham_GetAll]
	@Keywords NVARCHAR(200),
	@Start INT,
	@Length INT,
	@DanhMucId INT,
	@Nam INT,
	@Count INT = 0 OUTPUT
AS
BEGIN
	IF OBJECT_ID(N'tempdb..#TempTable') IS NOT NULL DROP TABLE #TempTable
	SELECT DISTINCT sp.*, dmsp.TenDanhMucSP,dmsp.MaDanhMucSP 
	INTO #TempTable 
	FROM SanPham as sp
		LEFT JOIN dbo.DanhMucSanPham as dmsp on sp.DanhMucId = dmsp.Id
		LEFT JOIN dbo.AttachedFile as f on f.ProductID = sp.Id
	WHERE sp.IsDeleted = 0
	AND (ISNULL(@Keywords,'') ='' OR sp.TenSanPham  LIKE N'%' + @Keywords + '%'
	OR dmsp.TenDanhMucSP  LIKE N'%' + @Keywords + '%')
	AND (@DanhMucId = 0 OR dmsp.Id = @DanhMucId)
	AND (@Nam = 0 OR sp.Nam = @Nam)
	--check paging
	IF(@Length > 0) 
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate ) AS Stt, * FROM #TempTable
		ORDER BY Stt OFFSET @Start ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate )  AS  Stt, * FROM #TempTable
	END
	--Total Records 
	SET @Count = (SELECT COUNT(*) FROM #TempTable)

END

GO
/****** Object:  StoredProcedure [dbo].[SanPham_GetAllActive]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SanPham_GetAllActive]
	@Keywords NVARCHAR(200),
	@Start INT,
	@Length INT,
	@DanhMucId INT,
	@Nam INT,
	@Count INT = 0 OUTPUT
AS
BEGIN
	IF OBJECT_ID(N'tempdb..#TempTable') IS NOT NULL DROP TABLE #TempTable
	SELECT DISTINCT sp.*, dmsp.TenDanhMucSP,dmsp.MaDanhMucSP, f.FilePath 
	INTO #TempTable 
	FROM SanPham as sp
		LEFT JOIN dbo.DanhMucSanPham as dmsp on sp.DanhMucId = dmsp.Id
		LEFT JOIN dbo.AttachedFile as f on f.ProductID = sp.Id
	WHERE sp.IsDeleted = 0
	AND sp.IsActive =1
	AND (ISNULL(@Keywords,'') ='' OR sp.TenSanPham  LIKE N'%' + @Keywords + '%'
	OR dmsp.TenDanhMucSP  LIKE N'%' + @Keywords + '%')
	AND (@DanhMucId = 0 OR dmsp.Id = @DanhMucId)
	AND (@Nam = 0 OR sp.Nam = @Nam)
	--check paging
	IF(@Length > 0) 
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate ) AS Stt, * FROM #TempTable
		ORDER BY Stt OFFSET @Start ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate )  AS  Stt, * FROM #TempTable
	END
	--Total Records 
	SET @Count = (SELECT COUNT(*) FROM #TempTable)

END

GO
/****** Object:  StoredProcedure [dbo].[SanPham_GetById]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SanPham_GetById] 
	@Id int 
AS
BEGIN
	Select distinct sp.*, dmsp.TenDanhMucSP
	from dbo.SanPham as sp
	left join dbo.DanhMucSanPham as dmsp on dmsp.Id = sp.DanhMucId
	where sp.[Status] !=9  AND sp.Id = @Id AND sp.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[SanPham_SelectList]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SanPham_SelectList]
	@Keywords NVARCHAR(200)
AS
BEGIN
	SELECT DISTINCT sp.*, dmsp.TenDanhMucSP
	FROM SanPham AS sp
	LEFT JOIN DanhMucSanPham AS dmsp ON dmsp.Id = sp.DanhMucId
	WHERE sp.IsActive = 1
		AND  (ISNULL(@Keywords, '') = '' OR sp.TenSanPham = @Keywords)
END
GO
/****** Object:  StoredProcedure [dbo].[SanPham_Update]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SanPham_Update]
	@Id int,
	@Nam int,
	@TenSanPham nvarchar(200),
	@DanhMucId int,
	@MaSanPham nvarchar(100),
	@MoTa nvarchar(200),
	@ThongTin nvarchar(max),
	@GiaGoc float,
	@PhanTramGiam float,
	@IsSale bit,
	@IsActive bit,
	@UpdatedBy nvarchar(200)
AS
BEGIN
	UPDATE dbo.SanPham 
	Set Nam = @Nam,
	TenSanPham  = @TenSanPham,
	DanhMucId = @DanhMucId,
	MaSanPham = @MaSanPham,
	MoTa = @MoTa,
	ThongTin = @ThongTin,
	GiaGoc = @GiaGoc,
	PhanTramGiam = @PhanTramGiam,
	IsActive = 1,
	IsSale = @IsSale,
	UpdatedBy = @UpdatedBy,
	UpdatedDate = GETDATE()
	WHERE Id = @Id
	Select @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[SanPham_UpdateActive]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SanPham_UpdateActive]
	@Ids NVARCHAR(MAX),
	@IsActive bit,
	@PhanHoi NVARCHAR(MAX),
	@UpdatedBy NVARCHAR(50)
AS
BEGIN
	UPDATE dbo.SanPham
	SET [IsActive] = @IsActive,
	PhanHoi = @PhanHoi,
	UpdatedDate = GETDATE(),
	UpdatedBy = @UpdatedBy
	WHERE Id IN (
		SELECT ID_ FROM dbo.SplitString(@Ids, ',')
	)

	SELECT @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[ThongTinDatHang_Creat]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ThongTinDatHang_Creat] 
	@DatHangId INT,
	@SanPhamId INT,
	@Gia FLOAT,
	@Quantity int
AS
BEGIN
	INSERT INTO ThongTinDatHang
	(
		DatHangId
		,SanPhamId
		,Gia
		,Quantity
	)
	VALUES
	(
		@DatHangId,
		@SanPhamId,
		@Gia,
		@Quantity
	)
	SELECT @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[ThongTinDatHang_GetByDatHangId]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ThongTinDatHang_GetByDatHangId]
	@DatHangId INT
	,@Start INT
	,@Length INT
	,@Count INT = 0 OUTPUT
AS
BEGIN
	IF OBJECT_ID(N'tempdb..#TempTable') IS NOT NULL DROP TABLE #TempTable
	SELECT DISTINCT ttdh.*, sp.TenSanPham
	INTO #TempTable
	FROM ThongTinDatHang AS ttdh
	LEFT JOIN SanPham AS sp ON ttdh.SanPhamId = sp.Id
	WHERE DatHangId = @DatHangId
	--check paging
	IF(@Length > 0)
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY Id) AS Stt, * FROM #TempTable
		ORDER BY Stt OFFSET @Start ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY Id) AS Stt, * FROM #TempTable
	END
	--Total Records
	SET @Count = (SELECT COUNT(*) FROM #TempTable)
END

GO
/****** Object:  StoredProcedure [dbo].[TrangThai_GetAll]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TrangThai_GetAll]
	@Keywords NVARCHAR(200)
	,@Start INT
	,@Length INT
	,@Count INT = 0 OUTPUT
AS
BEGIN
	IF OBJECT_ID(N'tempdb..#TempTable') IS NOT NULL DROP TABLE #TempTable
	SELECT DISTINCT tt.*
	INTO #TempTable
	FROM TrangThai AS tt
	WHERE 
	(ISNULL(@Keywords, '') = '' OR tt.TenTrangThai LIKE N'%' + @Keywords + '%')
	--check paging
	IF(@Length > 0)
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY Id) AS Stt, * FROM #TempTable
		ORDER BY Stt OFFSET @Start ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY Id) AS Stt, * FROM #TempTable
	END
	--Total Records
	SET @Count = (SELECT COUNT(*) FROM #TempTable)
END


GO
/****** Object:  StoredProcedure [dbo].[TrangThai_GetByDatHangId]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TrangThai_GetByDatHangId]
	@DatHangId int
AS
BEGIN
	SELECT DISTINCT dh.*,tt.TenTrangThai
	FROM DatHang as dh
	LEFT JOIN TrangThai as tt on tt.Id = dh.StatusId
	WHERE dh.Id = @DatHangId
END
GO
/****** Object:  StoredProcedure [dbo].[TrangThai_SelectList]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TrangThai_SelectList]
	@Keywords NVARCHAR(200)
AS
BEGIN
	SELECT DISTINCT tt.*
	FROM TrangThai AS tt
	WHERE (ISNULL(@Keywords,'') = '' OR tt.TenTrangThai LIKE N'%'+ @Keywords +'%')
END

GO
/****** Object:  StoredProcedure [dbo].[TrangThai_Update]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TrangThai_Update]
	@DatHangId INT,
	@StatusId INT
AS
BEGIN
		UPDATE dbo.[DatHang]
		SET StatusId =@StatusId
		WHERE Id = @DatHangId
		SELECT @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[User_Creat]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_Creat]
	@UserName NVARCHAR(100),
	@HoTen NVARCHAR(300),
	@Password NVARCHAR(MAX),
	@Email NVARCHAR(MAX) ,
	@DiaChi NVARCHAR(MAX),
	@SoDT NVARCHAR(150),
	@CreatedBy NVARCHAR(100)
AS
BEGIN
	INSERT INTO dbo.[User]
	(
		UserName,
		HoTen,
		Password,
		Email,
		DiaChi,
		SoDT,
		CreatedBy,
		CreatedDate,
		IsDeleted,
		IsDisabled
	)
	VALUES
	(
		@UserName,
		@HoTen,
		@Password,
		@Email,
		@DiaChi,
		@SoDT,
		@CreatedBy,
		GETDATE(),
		0,
		0
	)
 SELECT @@IDENTITY AS 'Identity'
END
GO
/****** Object:  StoredProcedure [dbo].[User_CreatUserRole]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_CreatUserRole]
	@UserId int,
	@RoleId int,
	@CreatedBy NVARCHAR(150)
AS
BEGIN
	INSERT INTO dbo.UserRole
	(
	UserId,
	RoleId,
	CreatedBy,
	CreatedDate
	)
	Values(
	@UserId,
	@RoleId,
	@CreatedBy,
	GETDATE()
	)
	 SELECT @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[User_Delete]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_Delete]
	@Ids NVARCHAR(MAX),
	@DeletedBy NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.[User]
	SET 
	IsDeleted = 1,
	DeletedDate = GETDATE(),
	DeletedBy = @DeletedBy
	WHERE Id IN(
		SELECT ID_ FROM dbo.SplitString(@Ids,',')
	)
	SELECT @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[User_GetAll]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_GetAll]
	@Keywords NVARCHAR(200),
	@Start INT,
	@Length INT,
	@Count INT = 0 OUTPUT
AS
BEGIN
	IF OBJECT_ID(N'tempdb..#TempTable') IS NOT NULL DROP TABLE #TempTable
	SELECT DISTINCT u.*,r.TenViet,r.RoleName
	INTO #TempTable 
	FROM dbo.[User] as u
		LEFT JOIN dbo.UserRole AS us on us.UserId = u.Id
		LEFT JOIN dbo.[Role] AS r on us.RoleId = r.Id
	WHERE u.IsDeleted = 0
	AND (ISNULL(@Keywords,'') ='' OR u.HoTen LIKE N'%' + @Keywords + '%')
	--check paging
	IF(@Length > 0) 
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate ) AS Stt, * FROM #TempTable
		ORDER BY Stt OFFSET @Start ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT ROW_NUMBER() OVER(ORDER BY CreatedDate )  AS  Stt, * FROM #TempTable
	END
	--Total Records 
	SET @Count = (SELECT COUNT(*) FROM #TempTable)

END

GO
/****** Object:  StoredProcedure [dbo].[User_GetByUserId]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_GetByUserId]
	@UserId int
AS
BEGIN
	SELECT DiSTINCT us.* ,r.TenViet,r.RoleName,us.RoleId,us.UserId,u.*
	FROM 
	dbo.[UserRole] AS us
	LEFT JOIN dbo.[User] AS u ON us.UserId = u.Id
	LEFT JOIN dbo.[Role] AS r ON r.Id = us.RoleId
	WHERE us.UserId = @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetByUserName_Password]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_GetByUserName_Password]
	-- Add the parameters for the stored procedure here
		@UserName NVARCHAR(100),
		@Password NVARCHAR(200)
AS
BEGIN
	SELECT DISTINCT u.*, r.TenViet, r.RoleName, ur.RoleId
	FROM dbo.[User] as u
	LEFT JOIN dbo.[UserRole] as ur on ur.UserId = u.Id
	LEFT JOIN dbo.[Role] as r on r.Id = ur.RoleId 
	WHERE u.UserName = @UserName AND u.Password = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[User_Update]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_Update]
	@Id INT,
	@UserName NVARCHAR(200),
	@HoTen NVARCHAR(200),
	@Password NVARCHAR(150),
	@Email NVARCHAR(250),
	@DiaChi NVARCHAR(200),
	@SoDT NVARCHAR(200),
	@UpdatedBy NVARCHAR(200)
AS
BEGIN
	UPDATE dbo.[User]
	SET
	UserName = @UserName,
	HoTen = @HoTen,
	Password = @Password,
	Email = @Email,
	DiaChi = @DiaChi,
	SoDt = @SoDT,
	UpdatedBy = @UpdatedBy,
	UpdatedDate = GETDATE()
	WHERE Id= @Id
	SELECT @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[UserRole_Delete]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UserRole_Delete]
	@UserId NVARCHAR(MAX)
AS
BEGIN
	DELETE FROM  dbo.[UserRole] 
	WHERE dbo.[UserRole].UserId = @UserId
	SELECT @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[UserRole_Update]    Script Date: 9/20/2024 10:55:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UserRole_Update]
	@UserId NVARCHAR(50),
	@RoleId INT,
	@UpdatedBy NVARCHAR
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM dbo.UserRole WHERE UserId = @UserId)
	BEGIN
		INSERT INTO dbo.[UserRole] ( UserId, RoleId ) VALUES(@UserId, @RoleId)
		SELECT @@ROWCOUNT
	END
    ELSE
    BEGIN
		UPDATE dbo.[UserRole]
		SET RoleId = @RoleId,
		UpdatedBy =@UpdatedBy
		WHERE UserId = @UserId
		SELECT @@ROWCOUNT
	END
END

GO
