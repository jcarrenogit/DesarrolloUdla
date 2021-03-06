USE [cat_servicios]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 11/22/2014 02:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuario](
	[usr_id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [nchar](10) NULL,
	[Email] [varchar](50) NULL,
	[Estado] [nchar](10) NULL,
	[Fecha_creacion] [datetime] NULL,
	[Fecha_Modificacion] [datetime] NULL,
	[Cod_area] [int] NULL,
	[Cod_cargo] [int] NULL,
	[Cod_rol] [int] NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[usr_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Solicitud]    Script Date: 11/22/2014 02:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud](
	[id_solicitud] [int] IDENTITY(900800,1) NOT NULL,
	[id_servicio] [int] NULL,
	[id_usuario] [int] NULL,
	[Estado] [int] NULL,
	[Detalle_Solicitud] [nvarchar](50) NULL,
	[Detalle_Rechazo] [nvarchar](50) NULL,
	[Fecha_creacion] [datetime] NULL,
	[Fecha_modificacion] [datetime] NULL,
 CONSTRAINT [PK_Solicitud] PRIMARY KEY CLUSTERED 
(
	[id_solicitud] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 11/22/2014 02:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Servicio](
	[id_servicio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](500) NULL,
	[Estado] [int] NULL,
	[id_usr] [int] NULL,
	[id_area] [int] NULL,
	[id_usuario_ult_modif] [int] NULL,
	[fecha_creacion] [datetime] NULL,
	[fecha_modificacion] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 11/22/2014 02:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rol](
	[Cod_rol] [char](10) NULL,
	[Descripcion] [nvarchar](50) NULL,
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[activo] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 11/22/2014 02:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perfil](
	[id_rol] [varchar](50) NULL,
	[Funcionalidad] [varchar](50) NULL,
	[Fecha_creacion] [smalldatetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Funcionalidad]    Script Date: 11/22/2014 02:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Funcionalidad](
	[id_funcionalidad] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion_funcionalidad] [varchar](50) NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[id_funcionalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 11/22/2014 02:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cargo](
	[id_cargo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Area]    Script Date: 11/22/2014 02:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Area](
	[id_area] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario_jefe] [nvarchar](40) NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[id_area] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_Rol_activo]    Script Date: 11/22/2014 02:05:52 ******/
ALTER TABLE [dbo].[Rol] ADD  CONSTRAINT [DF_Rol_activo]  DEFAULT ((1)) FOR [activo]
GO
/****** Object:  Default [DF_Servicio_fecha_creacion]    Script Date: 11/22/2014 02:05:52 ******/
ALTER TABLE [dbo].[Servicio] ADD  CONSTRAINT [DF_Servicio_fecha_creacion]  DEFAULT (getdate()) FOR [fecha_creacion]
GO
/****** Object:  Default [DF_Servicio_fecha_modificacion]    Script Date: 11/22/2014 02:05:52 ******/
ALTER TABLE [dbo].[Servicio] ADD  CONSTRAINT [DF_Servicio_fecha_modificacion]  DEFAULT (getdate()) FOR [fecha_modificacion]
GO
/****** Object:  Default [DF_Usuarios_Fecha_creacion]    Script Date: 11/22/2014 02:05:52 ******/
ALTER TABLE [dbo].[usuario] ADD  CONSTRAINT [DF_Usuarios_Fecha_creacion]  DEFAULT (getdate()) FOR [Fecha_creacion]
GO
/****** Object:  Default [DF_Usuarios_Fecha_Modificacion]    Script Date: 11/22/2014 02:05:52 ******/
ALTER TABLE [dbo].[usuario] ADD  CONSTRAINT [DF_Usuarios_Fecha_Modificacion]  DEFAULT (getdate()) FOR [Fecha_Modificacion]
GO
