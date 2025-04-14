USE [master]
go
Create database [FELRD]
GO

USE [FELRD]
GO
/****** Object:  Table [dbo].[Certificador]    Script Date: 5/04/2025 18:11:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Certificador]
GO

CREATE TABLE [dbo].[Certificador](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[EndPoint] [varchar](100) NULL,
	[PrintEndPoint] [varchar](100) NULL,
	[CommercialName] [varchar](100) NULL,
	[Nit] [varchar](100) NULL,
	[UsuarioWS] [varchar](100) NULL,
	[PasswordWS] [varchar](100) NULL,
	[Key] [varchar](100) NULL,
	[SecurityKey] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 5/04/2025 18:11:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCertificador] [bigint] NOT NULL,
	[Nit] [varchar](15) NOT NULL,
	[Prefix] [varchar](50) NOT NULL,
	[DTEFolder] [varchar](250) NULL,
	[DBSAE] [varchar](50) NOT NULL,
	[SuffixTable] [varchar](2) NULL,
	[Name] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 5/04/2025 18:11:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyId] [bigint] NOT NULL,
	[SubsidiaryId] [bigint] NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[Result] [varchar](max) NULL,
	[SAEDocumentId] [varchar](50) NOT NULL,
	[SAENumber] [int] NOT NULL,
	[SAESerial] [varchar](50) NOT NULL,
	[SendDate] [datetime] NOT NULL,
	[DocumentType] [varchar](10) NOT NULL,
	[UUID] [varchar](50) NULL,
	[AnnulmentUUID] [varchar](50) NULL,
	[ControlNumber] [varchar](100) NULL,
	[Sign] [nvarchar](max) NULL,
	[ReceivedStamp] [varchar](255) NULL,
 CONSTRAINT [PK__Document__3214EC07199010C1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/04/2025 18:11:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](25) NULL,
	[State] [bit] NOT NULL,
	[CanAccessMonitor] [bit] NOT NULL,
	[CanCancel] [bit] NOT NULL,
	[CanAccessDocuments] [bit] NOT NULL,
	[CanAccessCompanies] [bit] NOT NULL,
	[CanAccessUsers] [bit] NOT NULL,
	[CanAccessLogs] [bit] NOT NULL,
	[CanAccessConfigurations] [bit] NOT NULL,
	[CanSign] [bit] NOT NULL,
	[CanAccessRoles] [bit] NOT NULL,
	[CanAccessCertifiers] [bit] NOT NULL,
 CONSTRAINT [PK__Role__3214EC07B28219BB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 5/04/2025 18:11:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[key] [varchar](25) NULL,
	[value] [varchar](max) NULL,
	[description] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subsidiary]    Script Date: 5/04/2025 18:11:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subsidiary](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EstablishmentName] [varchar](100) NULL,
	[CompanyId] [bigint] NOT NULL,
	[EstablishmentCode] [varchar](5) NOT NULL,
	[PostalCode] [varchar](6) NOT NULL,
	[Country] [varchar](2) NOT NULL,
	[SubsidiaryFolder] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/04/2025 18:11:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdRole] [int] NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[FullName] [varchar](150) NULL,
	[State] [bit] NOT NULL,
 CONSTRAINT [PK__User__3214EC07B52D2175] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_CompanyCertificador] FOREIGN KEY([IdCertificador])
REFERENCES [dbo].[Certificador] ([Id])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_CompanyCertificador]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_DoccumentSubsidiary] FOREIGN KEY([SubsidiaryId])
REFERENCES [dbo].[Subsidiary] ([Id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_DoccumentSubsidiary]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_DocumentCompany] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_DocumentCompany]
GO
ALTER TABLE [dbo].[Subsidiary]  WITH CHECK ADD  CONSTRAINT [FK_CompanySubsidiary] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Subsidiary] CHECK CONSTRAINT [FK_CompanySubsidiary]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_RoleUser] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_RoleUser]
GO

