USE [master]
GO
/****** Object:  Database [Inventory_Management_systeam]    Script Date: 30-11-2022 04:21:54 ******/
CREATE DATABASE [Inventory_Management_systeam]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Inventory_Management_systeam', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Inventory_Management_systeam.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Inventory_Management_systeam_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Inventory_Management_systeam_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Inventory_Management_systeam] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Inventory_Management_systeam].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Inventory_Management_systeam] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET ARITHABORT OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Inventory_Management_systeam] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Inventory_Management_systeam] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Inventory_Management_systeam] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Inventory_Management_systeam] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET RECOVERY FULL 
GO
ALTER DATABASE [Inventory_Management_systeam] SET  MULTI_USER 
GO
ALTER DATABASE [Inventory_Management_systeam] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Inventory_Management_systeam] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Inventory_Management_systeam] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Inventory_Management_systeam] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Inventory_Management_systeam] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Inventory_Management_systeam] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Inventory_Management_systeam', N'ON'
GO
ALTER DATABASE [Inventory_Management_systeam] SET QUERY_STORE = OFF
GO
USE [Inventory_Management_systeam]
GO
/****** Object:  Table [dbo].[tbItemMaster]    Script Date: 30-11-2022 04:21:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbItemMaster](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](50) NOT NULL,
	[ItemDescription] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Unit] [int] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[StockQty] [int] NOT NULL,
	[UniqueId] [bigint] NULL,
 CONSTRAINT [PK_tbItemMaster] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbPurchase]    Script Date: 30-11-2022 04:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbPurchase](
	[PurchaseId] [int] IDENTITY(1,1) NOT NULL,
	[Purchased_Item] [nvarchar](50) NULL,
	[Purchased_Qty] [int] NULL,
	[Purchased_Date] [datetime] NULL,
 CONSTRAINT [PK_tbPurchase] PRIMARY KEY CLUSTERED 
(
	[PurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbSale]    Script Date: 30-11-2022 04:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbSale](
	[SaleId] [int] IDENTITY(1,1) NOT NULL,
	[Sale_Item] [nvarchar](50) NULL,
	[Sale_Qty] [int] NULL,
	[Sale_Date] [datetime] NULL,
 CONSTRAINT [PK_tbSale] PRIMARY KEY CLUSTERED 
(
	[SaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbUser]    Script Date: 30-11-2022 04:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](20) NULL,
	[Password] [nvarchar](12) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tbUser] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbWarehouse]    Script Date: 30-11-2022 04:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbWarehouse](
	[WarehouseId] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseDescription] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_tbWarehouse] PRIMARY KEY CLUSTERED 
(
	[WarehouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbItemMaster] ON 

INSERT [dbo].[tbItemMaster] ([ItemId], [ItemName], [ItemDescription], [Price], [Unit], [WarehouseId], [StockQty], [UniqueId]) VALUES (2, N'Cake', N'Cake desc', CAST(50 AS Decimal(18, 0)), 2, 1, 360, NULL)
INSERT [dbo].[tbItemMaster] ([ItemId], [ItemName], [ItemDescription], [Price], [Unit], [WarehouseId], [StockQty], [UniqueId]) VALUES (4, N'Pen', N'writing pen', CAST(12 AS Decimal(18, 0)), 119, 1, 1000, NULL)
INSERT [dbo].[tbItemMaster] ([ItemId], [ItemName], [ItemDescription], [Price], [Unit], [WarehouseId], [StockQty], [UniqueId]) VALUES (5, N'Book', N'UPSC books', CAST(120 AS Decimal(18, 0)), 10, 2, 667, NULL)
INSERT [dbo].[tbItemMaster] ([ItemId], [ItemName], [ItemDescription], [Price], [Unit], [WarehouseId], [StockQty], [UniqueId]) VALUES (6, N'Pen', N'writing pen', CAST(12 AS Decimal(18, 0)), 119, 2, 200, NULL)
INSERT [dbo].[tbItemMaster] ([ItemId], [ItemName], [ItemDescription], [Price], [Unit], [WarehouseId], [StockQty], [UniqueId]) VALUES (7, N'Book', N'UPSC books', CAST(120 AS Decimal(18, 0)), 10, 1, 333, NULL)
INSERT [dbo].[tbItemMaster] ([ItemId], [ItemName], [ItemDescription], [Price], [Unit], [WarehouseId], [StockQty], [UniqueId]) VALUES (8, N'Bottel', N'Water Bottle', CAST(35 AS Decimal(18, 0)), 10, 1, 360, 375119)
SET IDENTITY_INSERT [dbo].[tbItemMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[tbUser] ON 

INSERT [dbo].[tbUser] ([UserId], [FirstName], [LastName], [Email], [Password], [IsActive]) VALUES (1, N'Hamed', N'Deshmukh', N'sajedd333@gmail.com', N'Test@1234', 1)
SET IDENTITY_INSERT [dbo].[tbUser] OFF
GO
SET IDENTITY_INSERT [dbo].[tbWarehouse] ON 

INSERT [dbo].[tbWarehouse] ([WarehouseId], [WarehouseDescription], [IsActive]) VALUES (1, N'Shop Warehouse', 1)
INSERT [dbo].[tbWarehouse] ([WarehouseId], [WarehouseDescription], [IsActive]) VALUES (2, N'Better Bulk', 1)
SET IDENTITY_INSERT [dbo].[tbWarehouse] OFF
GO
ALTER TABLE [dbo].[tbUser] ADD  CONSTRAINT [DF_tbUser_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
USE [master]
GO
ALTER DATABASE [Inventory_Management_systeam] SET  READ_WRITE 
GO
