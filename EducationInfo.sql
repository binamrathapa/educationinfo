USE [EducationInfo]
GO

/****** Object:  Table [dbo].[Assignment]    Script Date: 10/30/2018 9:40:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Assignment](
	[Id] [int] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [text] NULL,
	[BatchId] [int] NULL,
	[SemesterId] [int] NULL,
	[CollegeId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[SubmitDate] [datetime] NULL,
	[AssignmentLocation] [varchar](250) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Assignment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[AssignmentSubmittedByStudent]    Script Date: 10/30/2018 9:40:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AssignmentSubmittedByStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[AssignmentId] [int] NULL,
	[SubmittedDate] [datetime] NULL,
	[AssignmentMarks] [decimal](18, 0) NULL,
	[ProjectLocation] [varchar](250) NULL,
 CONSTRAINT [PK_AssignmentSubmittedByStudent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Batch]    Script Date: 10/30/2018 9:40:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Batch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[BatchDate] [date] NULL,
 CONSTRAINT [PK_Batch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[College]    Script Date: 10/30/2018 9:40:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[College](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[AffiliatedBy] [varchar](150) NULL,
	[UniversityId] [int] NULL,
 CONSTRAINT [PK_College] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Course]    Script Date: 10/30/2018 9:40:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[PublishDate] [datetime] NULL,
	[IsPublish] [bit] NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[CoursesPerUniversity]    Script Date: 10/30/2018 9:40:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CoursesPerUniversity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NULL,
	[UniversityId] [int] NULL,
 CONSTRAINT [PK_CoursesPerUniversity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[NoteDownloadInfo]    Script Date: 10/30/2018 9:40:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NoteDownloadInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NoteId] [int] NULL,
	[StudentId] [int] NULL,
	[DownloadDate] [datetime] NULL,
 CONSTRAINT [PK_NoteDownloadInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[NoteInfo]    Script Date: 10/30/2018 9:40:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NoteInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[NoteLocation] [varchar](250) NULL,
	[CourseId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[PublishDate] [datetime] NULL,
	[IsPublish] [bit] NULL,
 CONSTRAINT [PK_Note_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Semester]    Script Date: 10/30/2018 9:40:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Semester](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Student]    Script Date: 10/30/2018 9:40:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[CollegeId] [int] NULL,
	[BatchId] [int] NULL,
	[SemesterId] [int] NULL,
	[UserId] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[University]    Script Date: 10/30/2018 9:40:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[University](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_University] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[User]    Script Date: 10/30/2018 9:40:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[UsetType] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Assignment]  WITH CHECK ADD  CONSTRAINT [FK_Assignment_Batch] FOREIGN KEY([BatchId])
REFERENCES [dbo].[Batch] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Assignment] CHECK CONSTRAINT [FK_Assignment_Batch]
GO

ALTER TABLE [dbo].[Assignment]  WITH CHECK ADD  CONSTRAINT [FK_Assignment_College] FOREIGN KEY([CollegeId])
REFERENCES [dbo].[College] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Assignment] CHECK CONSTRAINT [FK_Assignment_College]
GO

ALTER TABLE [dbo].[Assignment]  WITH CHECK ADD  CONSTRAINT [FK_Assignment_Semester] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Assignment] CHECK CONSTRAINT [FK_Assignment_Semester]
GO

ALTER TABLE [dbo].[AssignmentSubmittedByStudent]  WITH CHECK ADD  CONSTRAINT [FK_AssignmentSubmittedByStudent_Assignment] FOREIGN KEY([AssignmentId])
REFERENCES [dbo].[Assignment] ([Id])
GO

ALTER TABLE [dbo].[AssignmentSubmittedByStudent] CHECK CONSTRAINT [FK_AssignmentSubmittedByStudent_Assignment]
GO

ALTER TABLE [dbo].[AssignmentSubmittedByStudent]  WITH CHECK ADD  CONSTRAINT [FK_AssignmentSubmittedByStudent_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO

ALTER TABLE [dbo].[AssignmentSubmittedByStudent] CHECK CONSTRAINT [FK_AssignmentSubmittedByStudent_Student]
GO

ALTER TABLE [dbo].[College]  WITH CHECK ADD  CONSTRAINT [FK_College_University] FOREIGN KEY([UniversityId])
REFERENCES [dbo].[University] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[College] CHECK CONSTRAINT [FK_College_University]
GO

ALTER TABLE [dbo].[CoursesPerUniversity]  WITH CHECK ADD  CONSTRAINT [FK_CoursesPerUniversity_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CoursesPerUniversity] CHECK CONSTRAINT [FK_CoursesPerUniversity_Course]
GO

ALTER TABLE [dbo].[CoursesPerUniversity]  WITH CHECK ADD  CONSTRAINT [FK_CoursesPerUniversity_University] FOREIGN KEY([UniversityId])
REFERENCES [dbo].[University] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CoursesPerUniversity] CHECK CONSTRAINT [FK_CoursesPerUniversity_University]
GO

ALTER TABLE [dbo].[NoteDownloadInfo]  WITH CHECK ADD  CONSTRAINT [FK_NoteDownloadInfo_NoteDownloadInfo] FOREIGN KEY([NoteId])
REFERENCES [dbo].[NoteInfo] ([Id])
GO

ALTER TABLE [dbo].[NoteDownloadInfo] CHECK CONSTRAINT [FK_NoteDownloadInfo_NoteDownloadInfo]
GO

ALTER TABLE [dbo].[NoteDownloadInfo]  WITH CHECK ADD  CONSTRAINT [FK_NoteDownloadInfo_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO

ALTER TABLE [dbo].[NoteDownloadInfo] CHECK CONSTRAINT [FK_NoteDownloadInfo_Student]
GO

ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Batch] FOREIGN KEY([BatchId])
REFERENCES [dbo].[Batch] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Batch]
GO

ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Semester] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester] ([Id])
GO

ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Semester]
GO

ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_User]
GO


