create database ruiMvcFramework
GO
USE [ruiMvcFramework]
GO
/****** Object:  Table [dbo].[bks_Book]    Script Date: 2020/2/19 19:40:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bks_Book](
	[rowNum] [bigint] IDENTITY(1,1) NOT NULL,
	[rowID] [nchar](32) NULL,
	[bookCode] [nvarchar](50) NOT NULL,
	[bookName] [nvarchar](100) NULL,
	[isbnNO] [nvarchar](100) NULL,
	[price] [decimal](18, 2) NULL,
	[authorName] [nvarchar](100) NULL,
	[authorIntroduce] [nvarchar](max) NULL,
	[bookIntroduce] [nvarchar](max) NULL,
	[bookDirectory] [nvarchar](max) NULL,
	[bookTypeCode] [nvarchar](50) NULL,
	[pressCode] [nvarchar](50) NULL,
	[pressDate] [date] NULL,
	[release] [nvarchar](100) NULL,
	[surfacePic] [nvarchar](200) NULL,
	[isSell] [nchar](1) NULL,
	[stockSum] [int] NULL,
	[sellSum] [int] NULL,
	[remark] [nvarchar](500) NULL,
 CONSTRAINT [PK__bks_Book__3BB8DAE793C24461] PRIMARY KEY CLUSTERED 
(
	[bookCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bks_BookStock]    Script Date: 2020/2/19 19:40:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bks_BookStock](
	[rowNum] [bigint] IDENTITY(1,1) NOT NULL,
	[rowID] [nchar](32) NULL,
	[stockCode] [nvarchar](50) NOT NULL,
	[stockDate] [datetime] NULL,
	[userCode] [nvarchar](50) NULL,
	[supplierCode] [nvarchar](50) NULL,
	[status] [nvarchar](10) NULL,
	[remark] [nvarchar](500) NULL,
 CONSTRAINT [PK__bks_Book__F476A7E3C5AA7D34] PRIMARY KEY CLUSTERED 
(
	[stockCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bks_BookStockDetail]    Script Date: 2020/2/19 19:40:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bks_BookStockDetail](
	[rowNum] [bigint] IDENTITY(1,1) NOT NULL,
	[rowID] [nchar](32) NULL,
	[stockCode] [nvarchar](50) NOT NULL,
	[detailNo] [int] NOT NULL,
	[bookCode] [nvarchar](50) NOT NULL,
	[quantity] [int] NULL,
	[sellQuantity] [int] NULL,
	[price] [decimal](18, 2) NULL,
	[remark] [nvarchar](500) NULL,
 CONSTRAINT [PK__bks_Book__97CD2A4D1A4C798A] PRIMARY KEY CLUSTERED 
(
	[stockCode] ASC,
	[detailNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bks_BookType]    Script Date: 2020/2/19 19:40:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bks_BookType](
	[rowNum] [bigint] IDENTITY(1,1) NOT NULL,
	[rowID] [nchar](32) NULL,
	[bookTypeCode] [nvarchar](50) NOT NULL,
	[bookTypeName] [nvarchar](100) NULL,
	[showOrder] [int] NULL,
	[remark] [nvarchar](500) NULL,
 CONSTRAINT [PK__bks_Book__6F8ADFA12614DB1E] PRIMARY KEY CLUSTERED 
(
	[bookTypeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bks_Customer]    Script Date: 2020/2/19 19:40:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bks_Customer](
	[rowNum] [bigint] IDENTITY(1,1) NOT NULL,
	[rowID] [nchar](32) NULL,
	[customerCode] [nvarchar](50) NOT NULL,
	[cusomterName] [nvarchar](50) NULL,
	[password] [nchar](32) NULL,
	[telphone] [nvarchar](20) NULL,
	[email] [nvarchar](50) NULL,
	[remark] [nvarchar](500) NULL,
 CONSTRAINT [PK__bks_Cust__47BC9F2C1466A378] PRIMARY KEY CLUSTERED 
(
	[customerCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bks_CustomerAddress]    Script Date: 2020/2/19 19:40:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bks_CustomerAddress](
	[rowNum] [bigint] IDENTITY(1,1) NOT NULL,
	[rowID] [nchar](32) NULL,
	[addressCode] [uniqueidentifier] NULL,
	[customerCode] [nvarchar](50) NOT NULL,
	[addressName] [nvarchar](500) NULL,
	[isDefault] [bit] NULL,
	[remark] [nvarchar](500) NULL,
 CONSTRAINT [PK_bks_CustomerAddress] PRIMARY KEY CLUSTERED 
(
	[rowNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bks_OrderDetail]    Script Date: 2020/2/19 19:40:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bks_OrderDetail](
	[rowNum] [bigint] IDENTITY(1,1) NOT NULL,
	[rowID] [nchar](32) NULL,
	[orderCode] [uniqueidentifier] NOT NULL,
	[bookCode] [nvarchar](50) NOT NULL,
	[quantity] [int] NULL,
	[price] [decimal](18, 2) NULL,
	[costPrice] [decimal](18, 2) NULL,
	[subTotal] [decimal](18, 2) NULL,
	[isComment] [bit] NULL,
	[commentDate] [datetime] NULL,
	[commentContent] [nvarchar](max) NULL,
 CONSTRAINT [PK__bks_Orde__40D210C7EEC11709] PRIMARY KEY CLUSTERED 
(
	[orderCode] ASC,
	[bookCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bks_OrderInfo]    Script Date: 2020/2/19 19:40:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bks_OrderInfo](
	[rowNum] [bigint] IDENTITY(1,1) NOT NULL,
	[rowID] [nchar](32) NULL,
	[orderCode] [uniqueidentifier] NOT NULL,
	[customerCode] [nvarchar](50) NULL,
	[addressCode] [uniqueidentifier] NULL,
	[orderDate] [datetime] NULL,
	[totalPrice] [decimal](18, 2) NULL,
	[status] [nvarchar](10) NULL,
	[employeeCode] [nvarchar](50) NULL,
	[remark] [nvarchar](500) NULL,
 CONSTRAINT [PK__bks_Orde__23699D6991B2797A] PRIMARY KEY CLUSTERED 
(
	[orderCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bks_Press]    Script Date: 2020/2/19 19:40:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bks_Press](
	[rowNum] [bigint] IDENTITY(1,1) NOT NULL,
	[rowID] [nchar](32) NULL,
	[pressCode] [nvarchar](50) NOT NULL,
	[pressName] [nvarchar](100) NULL,
	[showOrder] [int] NULL,
	[remark] [nvarchar](500) NULL,
 CONSTRAINT [PK__bks_Pres__3FDC40D0CA4EE686] PRIMARY KEY CLUSTERED 
(
	[pressCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bks_ShoppingTrolley]    Script Date: 2020/2/19 19:40:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bks_ShoppingTrolley](
	[rowNum] [bigint] IDENTITY(1,1) NOT NULL,
	[rowID] [nchar](32) NULL,
	[customerCode] [nvarchar](100) NOT NULL,
	[bookCode] [nvarchar](50) NOT NULL,
	[quantity] [int] NULL,
	[remark] [nvarchar](500) NULL,
 CONSTRAINT [PK__bks_Shop__24071282E91D23B3] PRIMARY KEY CLUSTERED 
(
	[customerCode] ASC,
	[bookCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bks_Supplier]    Script Date: 2020/2/19 19:40:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bks_Supplier](
	[rowNum] [bigint] IDENTITY(1,1) NOT NULL,
	[rowID] [nchar](32) NULL,
	[supplierCode] [nvarchar](50) NOT NULL,
	[supplierName] [nvarchar](100) NULL,
	[contactUser] [nvarchar](10) NULL,
	[contactPhone] [nvarchar](20) NULL,
	[remark] [nvarchar](500) NULL,
 CONSTRAINT [PK__bks_Supp__35C84801CD56DEBC] PRIMARY KEY CLUSTERED 
(
	[supplierCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [ruiMvcFramework]
GO
SET IDENTITY_INSERT [dbo].[bks_Book] ON 

GO
INSERT [dbo].[bks_Book] ([rowNum], [rowID], [bookCode], [bookName], [isbnNO], [price], [authorName], [authorIntroduce], [bookIntroduce], [bookDirectory], [bookTypeCode], [pressCode], [pressDate], [release], [surfacePic], [isSell], [stockSum], [sellSum], [remark]) VALUES (1, N'0ceb8c0955e64c55aa60d020b486a15e', N'B001', N'测试01', N'1001', CAST(20.00 AS Decimal(18, 2)), N'张琳', N'', N'', N'', N'B001', N'P001', CAST(0x3C450B00 AS Date), N'', N'', N'否', 0, 0, N'')
GO
INSERT [dbo].[bks_Book] ([rowNum], [rowID], [bookCode], [bookName], [isbnNO], [price], [authorName], [authorIntroduce], [bookIntroduce], [bookDirectory], [bookTypeCode], [pressCode], [pressDate], [release], [surfacePic], [isSell], [stockSum], [sellSum], [remark]) VALUES (2, N'8693220165224589bf244e92863fbe28', N'B002', N'测试02', N'1001', CAST(21.00 AS Decimal(18, 2)), N'张琳', N'', N'', N'', N'B001', N'P001', CAST(0x3C450B00 AS Date), N'', N'', N'否', 0, 0, N'')
GO
INSERT [dbo].[bks_Book] ([rowNum], [rowID], [bookCode], [bookName], [isbnNO], [price], [authorName], [authorIntroduce], [bookIntroduce], [bookDirectory], [bookTypeCode], [pressCode], [pressDate], [release], [surfacePic], [isSell], [stockSum], [sellSum], [remark]) VALUES (3, N'f0834df5f5ca4a58a4c6513d32d09887', N'B003', N'测试03', N'1001', CAST(23.00 AS Decimal(18, 2)), N'张琳', N'', N'', N'', N'B001', N'P001', CAST(0x3C450B00 AS Date), N'', N'', N'否', 0, 0, N'')
GO
INSERT [dbo].[bks_Book] ([rowNum], [rowID], [bookCode], [bookName], [isbnNO], [price], [authorName], [authorIntroduce], [bookIntroduce], [bookDirectory], [bookTypeCode], [pressCode], [pressDate], [release], [surfacePic], [isSell], [stockSum], [sellSum], [remark]) VALUES (4, N'a4d7a3c08d4b456a84a88f6980eded70', N'B004', N'测试04', N'1004', CAST(24.00 AS Decimal(18, 2)), N'张琳', N'', N'', N'', N'B001', N'P001', CAST(0x3C450B00 AS Date), N'', N'', N'否', 0, 0, N'')
GO
INSERT [dbo].[bks_Book] ([rowNum], [rowID], [bookCode], [bookName], [isbnNO], [price], [authorName], [authorIntroduce], [bookIntroduce], [bookDirectory], [bookTypeCode], [pressCode], [pressDate], [release], [surfacePic], [isSell], [stockSum], [sellSum], [remark]) VALUES (5, N'0bf45b7f771f4aaeaf1562043e02f23d', N'B005', N'测试05', N'1005', CAST(25.00 AS Decimal(18, 2)), N'张琳', N'', N'', N'', N'B001', N'P001', CAST(0x3C450B00 AS Date), N'', N'', N'否', 0, 0, N'')
GO
INSERT [dbo].[bks_Book] ([rowNum], [rowID], [bookCode], [bookName], [isbnNO], [price], [authorName], [authorIntroduce], [bookIntroduce], [bookDirectory], [bookTypeCode], [pressCode], [pressDate], [release], [surfacePic], [isSell], [stockSum], [sellSum], [remark]) VALUES (6, N'5d0636c48e72407b944e874e0a829298', N'B006', N'测试06', N'1006', CAST(26.00 AS Decimal(18, 2)), N'张琳', N'', N'', N'', N'B001', N'P001', CAST(0x3C450B00 AS Date), N'', N'', N'否', 0, 0, N'')
GO
INSERT [dbo].[bks_Book] ([rowNum], [rowID], [bookCode], [bookName], [isbnNO], [price], [authorName], [authorIntroduce], [bookIntroduce], [bookDirectory], [bookTypeCode], [pressCode], [pressDate], [release], [surfacePic], [isSell], [stockSum], [sellSum], [remark]) VALUES (7, N'1955aecabfac4679b076b4c3bad01f1a', N'B007', N'测试07', N'1007', CAST(27.00 AS Decimal(18, 2)), N'张琳', N'', N'', N'', N'B001', N'P001', CAST(0x3C450B00 AS Date), N'', N'', N'否', 0, 0, N'')
GO
INSERT [dbo].[bks_Book] ([rowNum], [rowID], [bookCode], [bookName], [isbnNO], [price], [authorName], [authorIntroduce], [bookIntroduce], [bookDirectory], [bookTypeCode], [pressCode], [pressDate], [release], [surfacePic], [isSell], [stockSum], [sellSum], [remark]) VALUES (8, N'a5e39c1df9b040929f2a532e70304d54', N'B008', N'测试08', N'1008', CAST(28.00 AS Decimal(18, 2)), N'张琳', N'', N'', N'', N'B001', N'P001', CAST(0x3C450B00 AS Date), N'', N'', N'否', 0, 0, N'')
GO
INSERT [dbo].[bks_Book] ([rowNum], [rowID], [bookCode], [bookName], [isbnNO], [price], [authorName], [authorIntroduce], [bookIntroduce], [bookDirectory], [bookTypeCode], [pressCode], [pressDate], [release], [surfacePic], [isSell], [stockSum], [sellSum], [remark]) VALUES (9, N'1ec258fc021941808497993ddd504183', N'B009', N'测试09', N'1009', CAST(29.00 AS Decimal(18, 2)), N'张琳', N'', N'', N'', N'B001', N'P001', CAST(0x3C450B00 AS Date), N'', N'', N'否', 0, 0, N'')
GO
INSERT [dbo].[bks_Book] ([rowNum], [rowID], [bookCode], [bookName], [isbnNO], [price], [authorName], [authorIntroduce], [bookIntroduce], [bookDirectory], [bookTypeCode], [pressCode], [pressDate], [release], [surfacePic], [isSell], [stockSum], [sellSum], [remark]) VALUES (10, N'b12a7f8cd9d145faa99d53f82de5dd3d', N'B010', N'测试10', N'1010', CAST(30.00 AS Decimal(18, 2)), N'张琳', N'', N'', N'', N'B001', N'P001', CAST(0x3C450B00 AS Date), N'', N'', N'否', 0, 0, N'')
GO
INSERT [dbo].[bks_Book] ([rowNum], [rowID], [bookCode], [bookName], [isbnNO], [price], [authorName], [authorIntroduce], [bookIntroduce], [bookDirectory], [bookTypeCode], [pressCode], [pressDate], [release], [surfacePic], [isSell], [stockSum], [sellSum], [remark]) VALUES (11, N'18c11ef0646a43c380f39c67f58b64cd', N'B011', N'测试11', N'1011', CAST(31.00 AS Decimal(18, 2)), N'张琳', N'', N'', N'', N'B001', N'P001', CAST(0x3C450B00 AS Date), N'', N'', N'否', 0, 0, N'')
GO
SET IDENTITY_INSERT [dbo].[bks_Book] OFF
GO
SET IDENTITY_INSERT [dbo].[bks_BookType] ON 

GO
INSERT [dbo].[bks_BookType] ([rowNum], [rowID], [bookTypeCode], [bookTypeName], [showOrder], [remark]) VALUES (1, N'831552b4dfd44914badb287bcf4f778f', N'B001', N'计算机', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[bks_BookType] OFF
GO
SET IDENTITY_INSERT [dbo].[bks_Press] ON 

GO
INSERT [dbo].[bks_Press] ([rowNum], [rowID], [pressCode], [pressName], [showOrder], [remark]) VALUES (1, N'fd35b542dc62471884c55e3498016851', N'P001', N'清华大学出版社', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[bks_Press] OFF
GO

