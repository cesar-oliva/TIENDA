USE [master]
GO
/****** Object:  Database [DBTIENDA]    Script Date: 08/12/2021 22:10:53 ******/
CREATE DATABASE [DBTIENDA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBTIENDA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBTIENDA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBTIENDA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBTIENDA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBTIENDA] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBTIENDA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBTIENDA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBTIENDA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBTIENDA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBTIENDA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBTIENDA] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBTIENDA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBTIENDA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBTIENDA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBTIENDA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBTIENDA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBTIENDA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBTIENDA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBTIENDA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBTIENDA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBTIENDA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBTIENDA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBTIENDA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBTIENDA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBTIENDA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBTIENDA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBTIENDA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBTIENDA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBTIENDA] SET RECOVERY FULL 
GO
ALTER DATABASE [DBTIENDA] SET  MULTI_USER 
GO
ALTER DATABASE [DBTIENDA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBTIENDA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBTIENDA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBTIENDA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBTIENDA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBTIENDA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBTIENDA', N'ON'
GO
ALTER DATABASE [DBTIENDA] SET QUERY_STORE = OFF
GO
USE [DBTIENDA]
GO
/****** Object:  Table [dbo].[CATEGORIAEMPLEADO]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIAEMPLEADO](
	[IdCategoriaEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_CATEGORIAEMPLEADO] PRIMARY KEY CLUSTERED 
(
	[IdCategoriaEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Cuit] [varchar](30) NOT NULL,
	[RazonSocial] [varchar](50) NOT NULL,
	[IdCondicionTributaria] [int] NOT NULL,
	[DomicilioFiscal] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COLOR]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COLOR](
	[IdColor] [int] IDENTITY(1,1) NOT NULL,
	[CodigoColor] [varchar](10) NOT NULL,
	[DescripcionColor] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_COLOR] PRIMARY KEY CLUSTERED 
(
	[IdColor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COMPRA]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMPRA](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[TipoComprobante] [varchar](50) NOT NULL,
	[NumeroComprobante] [varchar](50) NOT NULL,
	[Impuesto] [float] NULL,
	[TotalDeCompra] [float] NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_COMPRA] PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COMPROBANTE]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMPROBANTE](
	[IdComprobante] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[ContadorNumero] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_COMPROBANTE] PRIMARY KEY CLUSTERED 
(
	[IdComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CONDICIONTRIBUTARIA]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONDICIONTRIBUTARIA](
	[IdCondicionTributaria] [int] IDENTITY(1,1) NOT NULL,
	[CodigoCondicionTributaria] [varchar](50) NOT NULL,
	[DescripcionCondicionTributaria] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_CONDICIONTRIBUTARIA] PRIMARY KEY CLUSTERED 
(
	[IdCondicionTributaria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLEADO]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLEADO](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[Cuil] [varchar](50) NOT NULL,
	[FechaAlta] [nchar](10) NULL,
	[Estado] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_EMPLEADO] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IMPUESTO]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMPUESTO](
	[IdImpuesto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Alicuota] [float] NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_IMPUESTO] PRIMARY KEY CLUSTERED 
(
	[IdImpuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LINEADECOMPRA]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LINEADECOMPRA](
	[IdLineaDeCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdCompra] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [float] NOT NULL,
 CONSTRAINT [PK_LINEADECOMPRA] PRIMARY KEY CLUSTERED 
(
	[IdLineaDeCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LINEADEVENTA]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LINEADEVENTA](
	[IdLineaDeVEnta] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [float] NOT NULL,
	[ImporteSubTital] [float] NOT NULL,
 CONSTRAINT [PK_LINEADEVENTA] PRIMARY KEY CLUSTERED 
(
	[IdLineaDeVEnta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MARCA]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MARCA](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_MARCA] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERSONA]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSONA](
	[IdPersona] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](100) NOT NULL,
	[Apellidos] [varchar](100) NOT NULL,
	[TipoDocumento] [varchar](50) NOT NULL,
	[NumeroDocumento] [varchar](50) NOT NULL,
	[Domicilio] [varchar](100) NOT NULL,
	[Telefono] [varchar](50) NULL,
	[Fechanacimiento] [datetime] NULL,
	[Estado] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_PERSONA] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[GeneroProducto] [varchar](50) NOT NULL,
	[IdRubroProducto] [int] NOT NULL,
	[IdMarca] [int] NOT NULL,
	[IdColor] [int] NOT NULL,
	[IdTalle] [int] NOT NULL,
	[Costo] [float] NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PUNTODEVENTA]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PUNTODEVENTA](
	[IdPuntoDeVenta] [int] IDENTITY(1,1) NOT NULL,
	[idComprobante] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PUNTODEVENTA] PRIMARY KEY CLUSTERED 
(
	[IdPuntoDeVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PUNTODEVENTA_x_COMPROBANTE]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PUNTODEVENTA_x_COMPROBANTE](
	[IdPC] [int] IDENTITY(1,1) NOT NULL,
	[idPuntoVenta] [int] NOT NULL,
	[idComprobante] [int] NOT NULL,
 CONSTRAINT [PK_PUNTODEVENTA_x_COMPROBANTE] PRIMARY KEY CLUSTERED 
(
	[IdPC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROL]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROL](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_ROL] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RUBROPRODUCTO]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RUBROPRODUCTO](
	[IdRubroProducto] [int] IDENTITY(1,1) NOT NULL,
	[CodigoRubroProducto] [varchar](50) NOT NULL,
	[DescripcionRubroProducto] [varchar](50) NOT NULL,
	[MargenGanancia] [decimal](18, 0) NOT NULL,
	[IdImpuesto] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_RUBROPRODUCTO] PRIMARY KEY CLUSTERED 
(
	[IdRubroProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STOCK]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STOCK](
	[idStock] [int] IDENTITY(1,1) NOT NULL,
	[idProducto] [int] NOT NULL,
	[Cantidad] [int] NULL,
 CONSTRAINT [PK_STOCK_1] PRIMARY KEY CLUSTERED 
(
	[idStock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SUCURSAL]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SUCURSAL](
	[IdSucursal] [int] IDENTITY(1,1) NOT NULL,
	[IdTienda] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_SUCURSAL] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TALLE]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TALLE](
	[IdTalle] [int] IDENTITY(1,1) NOT NULL,
	[CodigoTalle] [varchar](10) NOT NULL,
	[DescripcionTalle] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_TALLE] PRIMARY KEY CLUSTERED 
(
	[IdTalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIENDA]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIENDA](
	[IdTienda] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [varchar](100) NOT NULL,
	[CuitTienda] [varchar](50) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Telefono] [varchar](50) NULL,
	[Estado] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_TIENDA] PRIMARY KEY CLUSTERED 
(
	[IdTienda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
	[Idtienda] [int] NOT NULL,
	[IdRol] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VENTA]    Script Date: 08/12/2021 22:10:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENTA](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdPuntoDeVenta] [int] NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[CantidadProducto] [int] NOT NULL,
	[ImporteTotalDeVenta] [float] NOT NULL,
	[IdFormaDePago] [int] NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_VENTA] PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CATEGORIAEMPLEADO] ADD  CONSTRAINT [DF_CATEGORIAEMPLEADO_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[CLIENTE] ADD  CONSTRAINT [DF_CLIENTE_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[COMPRA] ADD  CONSTRAINT [DF_COMPRA_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[COMPROBANTE] ADD  CONSTRAINT [DF_COMPROBANTE_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[CONDICIONTRIBUTARIA] ADD  CONSTRAINT [DF_CONDICIONTRIBUTARIA_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[EMPLEADO] ADD  CONSTRAINT [DF_EMPLEADO_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[IMPUESTO] ADD  CONSTRAINT [DF_IMPUESTO_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[PERSONA] ADD  CONSTRAINT [DF_PERSONA_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  CONSTRAINT [DF_PRODUCTO_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[ROL] ADD  CONSTRAINT [DF_ROL_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[RUBROPRODUCTO] ADD  CONSTRAINT [DF_RUBROPRODUCTO_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[SUCURSAL] ADD  CONSTRAINT [DF_SUCURSAL_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[TIENDA] ADD  CONSTRAINT [DF_TIENDA_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[USUARIO] ADD  CONSTRAINT [DF_USUARIO_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[VENTA] ADD  CONSTRAINT [DF_VENTA_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[CLIENTE]  WITH CHECK ADD  CONSTRAINT [FK_CLIENTE_CONDICIONTRIBUTARIA] FOREIGN KEY([IdCondicionTributaria])
REFERENCES [dbo].[CONDICIONTRIBUTARIA] ([IdCondicionTributaria])
GO
ALTER TABLE [dbo].[CLIENTE] CHECK CONSTRAINT [FK_CLIENTE_CONDICIONTRIBUTARIA]
GO
ALTER TABLE [dbo].[COMPRA]  WITH CHECK ADD  CONSTRAINT [FK_COMPRA_USUARIO] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[USUARIO] ([IdUsuario])
GO
ALTER TABLE [dbo].[COMPRA] CHECK CONSTRAINT [FK_COMPRA_USUARIO]
GO
ALTER TABLE [dbo].[EMPLEADO]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADO_PERSONA] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[PERSONA] ([IdPersona])
GO
ALTER TABLE [dbo].[EMPLEADO] CHECK CONSTRAINT [FK_EMPLEADO_PERSONA]
GO
ALTER TABLE [dbo].[LINEADECOMPRA]  WITH CHECK ADD  CONSTRAINT [FK_LINEADECOMPRA_COMPRA] FOREIGN KEY([IdCompra])
REFERENCES [dbo].[COMPRA] ([IdCompra])
GO
ALTER TABLE [dbo].[LINEADECOMPRA] CHECK CONSTRAINT [FK_LINEADECOMPRA_COMPRA]
GO
ALTER TABLE [dbo].[LINEADEVENTA]  WITH CHECK ADD  CONSTRAINT [FK_LINEADEVENTA_PRODUCTO] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[LINEADEVENTA] CHECK CONSTRAINT [FK_LINEADEVENTA_PRODUCTO]
GO
ALTER TABLE [dbo].[LINEADEVENTA]  WITH CHECK ADD  CONSTRAINT [FK_LINEADEVENTA_VENTA] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[VENTA] ([IdVenta])
GO
ALTER TABLE [dbo].[LINEADEVENTA] CHECK CONSTRAINT [FK_LINEADEVENTA_VENTA]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_COLOR] FOREIGN KEY([IdColor])
REFERENCES [dbo].[COLOR] ([IdColor])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_COLOR]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_MARCA] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[MARCA] ([IdMarca])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_MARCA]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_RUBROPRODUCTO] FOREIGN KEY([IdRubroProducto])
REFERENCES [dbo].[RUBROPRODUCTO] ([IdRubroProducto])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_RUBROPRODUCTO]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_TALLE] FOREIGN KEY([IdTalle])
REFERENCES [dbo].[TALLE] ([IdTalle])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_TALLE]
GO
ALTER TABLE [dbo].[PUNTODEVENTA_x_COMPROBANTE]  WITH CHECK ADD  CONSTRAINT [FK_PUNTODEVENTA_x_COMPROBANTE_COMPROBANTE] FOREIGN KEY([idComprobante])
REFERENCES [dbo].[COMPROBANTE] ([IdComprobante])
GO
ALTER TABLE [dbo].[PUNTODEVENTA_x_COMPROBANTE] CHECK CONSTRAINT [FK_PUNTODEVENTA_x_COMPROBANTE_COMPROBANTE]
GO
ALTER TABLE [dbo].[PUNTODEVENTA_x_COMPROBANTE]  WITH CHECK ADD  CONSTRAINT [FK_PUNTODEVENTA_x_COMPROBANTE_PUNTODEVENTA] FOREIGN KEY([idPuntoVenta])
REFERENCES [dbo].[PUNTODEVENTA] ([IdPuntoDeVenta])
GO
ALTER TABLE [dbo].[PUNTODEVENTA_x_COMPROBANTE] CHECK CONSTRAINT [FK_PUNTODEVENTA_x_COMPROBANTE_PUNTODEVENTA]
GO
ALTER TABLE [dbo].[RUBROPRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_RUBROPRODUCTO_IMPUESTO1] FOREIGN KEY([IdImpuesto])
REFERENCES [dbo].[IMPUESTO] ([IdImpuesto])
GO
ALTER TABLE [dbo].[RUBROPRODUCTO] CHECK CONSTRAINT [FK_RUBROPRODUCTO_IMPUESTO1]
GO
ALTER TABLE [dbo].[STOCK]  WITH CHECK ADD  CONSTRAINT [FK_STOCK_PRODUCTO1] FOREIGN KEY([idProducto])
REFERENCES [dbo].[PRODUCTO] ([IdProducto])
GO
ALTER TABLE [dbo].[STOCK] CHECK CONSTRAINT [FK_STOCK_PRODUCTO1]
GO
ALTER TABLE [dbo].[SUCURSAL]  WITH CHECK ADD  CONSTRAINT [FK_SUCURSAL_TIENDA] FOREIGN KEY([IdTienda])
REFERENCES [dbo].[TIENDA] ([IdTienda])
GO
ALTER TABLE [dbo].[SUCURSAL] CHECK CONSTRAINT [FK_SUCURSAL_TIENDA]
GO
ALTER TABLE [dbo].[SUCURSAL]  WITH CHECK ADD  CONSTRAINT [FK_SUCURSAL_TIENDA1] FOREIGN KEY([IdTienda])
REFERENCES [dbo].[TIENDA] ([IdTienda])
GO
ALTER TABLE [dbo].[SUCURSAL] CHECK CONSTRAINT [FK_SUCURSAL_TIENDA1]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_EMPLEADO] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[EMPLEADO] ([IdEmpleado])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_USUARIO_EMPLEADO]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_ROL] FOREIGN KEY([IdRol])
REFERENCES [dbo].[ROL] ([IdRol])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_USUARIO_ROL]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_TIENDA] FOREIGN KEY([Idtienda])
REFERENCES [dbo].[TIENDA] ([IdTienda])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_USUARIO_TIENDA]
GO
ALTER TABLE [dbo].[VENTA]  WITH CHECK ADD  CONSTRAINT [FK_VENTA_CLIENTE] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[CLIENTE] ([IdCliente])
GO
ALTER TABLE [dbo].[VENTA] CHECK CONSTRAINT [FK_VENTA_CLIENTE]
GO
ALTER TABLE [dbo].[VENTA]  WITH CHECK ADD  CONSTRAINT [FK_VENTA_PUNTODEVENTA] FOREIGN KEY([IdPuntoDeVenta])
REFERENCES [dbo].[PUNTODEVENTA] ([IdPuntoDeVenta])
GO
ALTER TABLE [dbo].[VENTA] CHECK CONSTRAINT [FK_VENTA_PUNTODEVENTA]
GO
ALTER TABLE [dbo].[VENTA]  WITH CHECK ADD  CONSTRAINT [FK_VENTA_SUCURSAL] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[SUCURSAL] ([IdSucursal])
GO
ALTER TABLE [dbo].[VENTA] CHECK CONSTRAINT [FK_VENTA_SUCURSAL]
GO
ALTER TABLE [dbo].[VENTA]  WITH CHECK ADD  CONSTRAINT [FK_VENTA_USUARIO] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[USUARIO] ([IdUsuario])
GO
ALTER TABLE [dbo].[VENTA] CHECK CONSTRAINT [FK_VENTA_USUARIO]
GO
USE [master]
GO
ALTER DATABASE [DBTIENDA] SET  READ_WRITE 
GO
