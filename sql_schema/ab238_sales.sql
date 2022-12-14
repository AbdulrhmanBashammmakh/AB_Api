USE [master]
GO
/****** Object:  Database [Ab238_sales]    Script Date: 21/09/2022 01:18:19 ص ******/
CREATE DATABASE [Ab238_sales]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ab238_sales', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Ab238_sales.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ab238_sales_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Ab238_sales_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Ab238_sales] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ab238_sales].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ab238_sales] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ab238_sales] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ab238_sales] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ab238_sales] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ab238_sales] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ab238_sales] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ab238_sales] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ab238_sales] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ab238_sales] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ab238_sales] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ab238_sales] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ab238_sales] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ab238_sales] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ab238_sales] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ab238_sales] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ab238_sales] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ab238_sales] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ab238_sales] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ab238_sales] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ab238_sales] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ab238_sales] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ab238_sales] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ab238_sales] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Ab238_sales] SET  MULTI_USER 
GO
ALTER DATABASE [Ab238_sales] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ab238_sales] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ab238_sales] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ab238_sales] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Ab238_sales] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Ab238_sales] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Ab238_sales] SET QUERY_STORE = OFF
GO
USE [Ab238_sales]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 21/09/2022 01:18:20 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cate] [varchar](50) NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[current_products]    Script Date: 21/09/2022 01:18:20 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[current_products](
	[id_product] [int] NOT NULL,
	[detials] [varchar](100) NULL,
	[qty_avaliabe] [int] NULL,
	[price_buy] [decimal](18, 2) NULL,
	[price_sale] [decimal](18, 2) NULL,
	[upd_date] [datetime] NULL,
 CONSTRAINT [PK_current_products] PRIMARY KEY CLUSTERED 
(
	[id_product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 21/09/2022 01:18:20 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name_cust] [varchar](50) NULL,
	[phone_cust] [varchar](50) NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoice]    Script Date: 21/09/2022 01:18:20 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoice](
	[id_invoice] [int] IDENTITY(1,1) NOT NULL,
	[total] [decimal](18, 2) NULL,
	[discount] [decimal](18, 2) NULL,
	[net] [decimal](18, 2) NULL,
	[payment] [nchar](10) NULL,
	[id_cust] [int] NULL,
 CONSTRAINT [PK_invoice] PRIMARY KEY CLUSTERED 
(
	[id_invoice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 21/09/2022 01:18:20 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cust_id] [int] NULL,
	[cr_date] [datetime] NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orderlines]    Script Date: 21/09/2022 01:18:20 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderlines](
	[order_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[qty] [int] NULL,
	[price] [decimal](18, 2) NULL,
	[subtotal] [decimal](18, 2) NULL,
 CONSTRAINT [PK_orderlines] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 21/09/2022 01:18:20 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NULL,
	[unit_id] [int] NULL,
	[cate_id] [int] NULL,
	[code] [varchar](100) NULL,
	[cr_date] [datetime] NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Qty_new_addition]    Script Date: 21/09/2022 01:18:20 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qty_new_addition](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_product] [int] NOT NULL,
	[qty_add] [int] NOT NULL,
	[note] [varchar](50) NULL,
	[cr_date] [datetime] NULL,
 CONSTRAINT [PK_Qty_new_addition] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[return_sales]    Script Date: 21/09/2022 01:18:20 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[return_sales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_order] [int] NOT NULL,
	[cr_date] [datetime] NULL,
 CONSTRAINT [PK_return_sales] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[returnlines]    Script Date: 21/09/2022 01:18:20 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[returnlines](
	[id_product] [int] NOT NULL,
	[id_return] [int] NOT NULL,
	[qty_return] [int] NULL,
	[price] [decimal](18, 2) NULL,
	[subtotal_return] [decimal](18, 2) NULL,
 CONSTRAINT [PK_returnlines] PRIMARY KEY CLUSTERED 
(
	[id_product] ASC,
	[id_return] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[units]    Script Date: 21/09/2022 01:18:20 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[units](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[unit] [varchar](50) NULL,
 CONSTRAINT [PK_units] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 21/09/2022 01:18:20 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](max) NOT NULL,
	[is_admin] [int] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[invoice]  WITH NOCHECK ADD  CONSTRAINT [FK_invoice_customer] FOREIGN KEY([id_cust])
REFERENCES [dbo].[customer] ([id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[invoice] NOCHECK CONSTRAINT [FK_invoice_customer]
GO
ALTER TABLE [dbo].[order]  WITH NOCHECK ADD  CONSTRAINT [FK_order_customer] FOREIGN KEY([cust_id])
REFERENCES [dbo].[customer] ([id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[order] NOCHECK CONSTRAINT [FK_order_customer]
GO
ALTER TABLE [dbo].[orderlines]  WITH NOCHECK ADD  CONSTRAINT [FK_orderlines_order] FOREIGN KEY([order_id])
REFERENCES [dbo].[order] ([id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[orderlines] NOCHECK CONSTRAINT [FK_orderlines_order]
GO
ALTER TABLE [dbo].[orderlines]  WITH NOCHECK ADD  CONSTRAINT [FK_orderlines_products] FOREIGN KEY([product_id])
REFERENCES [dbo].[products] ([id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[orderlines] NOCHECK CONSTRAINT [FK_orderlines_products]
GO
ALTER TABLE [dbo].[products]  WITH NOCHECK ADD  CONSTRAINT [FK_products_categories] FOREIGN KEY([cate_id])
REFERENCES [dbo].[categories] ([id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[products] NOCHECK CONSTRAINT [FK_products_categories]
GO
ALTER TABLE [dbo].[products]  WITH NOCHECK ADD  CONSTRAINT [FK_products_units] FOREIGN KEY([unit_id])
REFERENCES [dbo].[units] ([id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[products] NOCHECK CONSTRAINT [FK_products_units]
GO
ALTER TABLE [dbo].[returnlines]  WITH NOCHECK ADD  CONSTRAINT [FK_returnlines_return_sales] FOREIGN KEY([id_return])
REFERENCES [dbo].[return_sales] ([id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[returnlines] NOCHECK CONSTRAINT [FK_returnlines_return_sales]
GO
USE [master]
GO
ALTER DATABASE [Ab238_sales] SET  READ_WRITE 
GO
