USE [MVMovies]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 3.06.2019 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[refID] [nvarchar](50) NULL,
	[Title] [nvarchar](500) NULL,
	[Year] [nvarchar](4) NULL,
	[Rated] [nvarchar](500) NULL,
	[Rating] [nvarchar](500) NULL,
	[Votes] [nvarchar](500) NULL,
	[Released] [nvarchar](500) NULL,
	[Runtime] [nvarchar](500) NULL,
	[Director] [nvarchar](500) NULL,
	[Writer] [nvarchar](500) NULL,
	[Actors] [nvarchar](500) NULL,
	[Plot] [nvarchar](500) NULL,
	[Language] [nvarchar](500) NULL,
	[Country] [nvarchar](500) NULL,
	[Awards] [nvarchar](500) NULL,
	[Poster] [nvarchar](500) NULL,
	[LastUpdateTime] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 3.06.2019 16:34:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Movies] ON 

GO
INSERT [dbo].[Movies] ([ID], [refID], [Title], [Year], [Rated], [Rating], [Votes], [Released], [Runtime], [Director], [Writer], [Actors], [Plot], [Language], [Country], [Awards], [Poster], [LastUpdateTime], [IsDeleted], [DeletedTime]) VALUES (4, N'tt1300854', N'Iron Man 3', N'2013', N'PG-13', N'7.2', N'687,797', N'03 May 2013', N'130 min', N'Shane Black', N'Drew Pearce (screenplay by), Shane Black (screenplay by), Stan Lee (based on the Marvel comic book by), Don Heck (based on the Marvel comic book by), Larry Lieber (based on the Marvel comic book by), Jack Kirby (based on the Marvel comic book by), Warren Ellis (based on the "Extremis" mini-series written by), Adi Granov (based on the "Extremis" mini-series illustrated by)', N'Robert Downey Jr., Gwyneth Paltrow, Don Cheadle, Guy Pearce', N'When Tony Stark''s world is torn apart by a formidable terrorist called the Mandarin, he starts an odyssey of rebuilding and retribution.', N'English', N'USA', N'Nominated for 1 Oscar. Another 17 wins & 61 nominations.', N'https://m.media-amazon.com/images/M/MV5BMjE5MzcyNjk1M15BMl5BanBnXkFtZTcwMjQ4MjcxOQ@@._V1_SX300.jpg', CAST(N'2019-06-03 13:26:22.353' AS DateTime), 0, CAST(N'2019-06-01 05:51:56.263' AS DateTime))
GO
INSERT [dbo].[Movies] ([ID], [refID], [Title], [Year], [Rated], [Rating], [Votes], [Released], [Runtime], [Director], [Writer], [Actors], [Plot], [Language], [Country], [Awards], [Poster], [LastUpdateTime], [IsDeleted], [DeletedTime]) VALUES (5, N'tt0499549', N'Avatar', N'2009', N'PG-13', N'7.8', N'1,038,709', N'18 Dec 2009', N'162 min', N'James Cameron', N'James Cameron', N'Sam Worthington, Zoe Saldana, Sigourney Weaver, Stephen Lang', N'A paraplegic marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home.', N'English, Spanish', N'UK, USA', N'Won 3 Oscars. Another 85 wins & 128 nominations.', N'https://m.media-amazon.com/images/M/MV5BMTYwOTEwNjAzMl5BMl5BanBnXkFtZTcwODc5MTUwMw@@._V1_SX300.jpg', CAST(N'2019-06-03 13:26:22.540' AS DateTime), 0, CAST(N'2019-06-01 21:16:04.573' AS DateTime))
GO
INSERT [dbo].[Movies] ([ID], [refID], [Title], [Year], [Rated], [Rating], [Votes], [Released], [Runtime], [Director], [Writer], [Actors], [Plot], [Language], [Country], [Awards], [Poster], [LastUpdateTime], [IsDeleted], [DeletedTime]) VALUES (20, N'tt0289968', N'Hababam Sinifi Dokuz Doguruyor', N'1978', N'N/A', N'7.5', N'5,289', N'01 Nov 1978', N'88 min', N'Kartal Tibet', N'Rifat Ilgaz (novel), Sadik Sendil', N'Münir Özkul, Adile Nasit, Sener Sen, Perran Kutman', N'A son of a tribe chef comes to the class, and he declares himself as a landowner. At the same time, a girl who has a boyfriend in the class gets pregnant. This is the funny and dramatic story of a class.', N'Turkish', N'Turkey', N'N/A', N'https://images-na.ssl-images-amazon.com/images/M/MV5BMjUwNDlmZDEtZmE0OS00OTk2LWIzYTAtYTVmYzI5MmM4ZjQ2XkEyXkFqcGdeQXVyNjUxNDU0MjM@._V1_SX300.jpg', CAST(N'2019-06-03 13:26:22.780' AS DateTime), 0, CAST(N'2019-06-02 15:03:05.553' AS DateTime))
GO
INSERT [dbo].[Movies] ([ID], [refID], [Title], [Year], [Rated], [Rating], [Votes], [Released], [Runtime], [Director], [Writer], [Actors], [Plot], [Language], [Country], [Awards], [Poster], [LastUpdateTime], [IsDeleted], [DeletedTime]) VALUES (25, N'tt0371746', N'Iron Man', N'2008', N'PG-13', N'7.9', N'854,168', N'02 May 2008', N'126 min', N'Jon Favreau', N'Mark Fergus (screenplay), Hawk Ostby (screenplay), Art Marcum (screenplay), Matt Holloway (screenplay), Stan Lee (characters), Don Heck (characters), Larry Lieber (characters), Jack Kirby (characters)', N'Robert Downey Jr., Terrence Howard, Jeff Bridges, Gwyneth Paltrow', N'After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.', N'English, Persian, Urdu, Arabic, Hungarian', N'USA, Canada', N'Nominated for 2 Oscars. Another 20 wins & 65 nominations.', N'https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_SX300.jpg', CAST(N'2019-06-03 13:26:23.013' AS DateTime), 0, CAST(N'2019-06-03 11:30:16.203' AS DateTime))
GO
INSERT [dbo].[Movies] ([ID], [refID], [Title], [Year], [Rated], [Rating], [Votes], [Released], [Runtime], [Director], [Writer], [Actors], [Plot], [Language], [Country], [Awards], [Poster], [LastUpdateTime], [IsDeleted], [DeletedTime]) VALUES (29, N'tt0371746', N'Iron Man', N'2008', N'PG-13', N'7.9', N'854,168', N'02 May 2008', N'126 min', N'Jon Favreau', N'Mark Fergus (screenplay), Hawk Ostby (screenplay), Art Marcum (screenplay), Matt Holloway (screenplay), Stan Lee (characters), Don Heck (characters), Larry Lieber (characters), Jack Kirby (characters)', N'Robert Downey Jr., Terrence Howard, Jeff Bridges, Gwyneth Paltrow', N'After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.', N'English, Persian, Urdu, Arabic, Hungarian', N'USA, Canada', N'Nominated for 2 Oscars. Another 20 wins & 65 nominations.', N'https://m.media-amazon.com/images/M/MV5BMTczNTI2ODUwOF5BMl5BanBnXkFtZTcwMTU0NTIzMw@@._V1_SX300.jpg', CAST(N'2019-06-03 13:26:23.283' AS DateTime), 0, CAST(N'2019-06-03 11:38:09.810' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([ID], [UserName], [Password], [IsDeleted], [DeletedTime]) VALUES (1, N'turkmen', N'123456', 0, CAST(N'2019-06-02 00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
