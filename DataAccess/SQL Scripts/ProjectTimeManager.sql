--***You must create the database in order to execute the reading content in this file.
--CREATE DATABASE ProjectTimeManager;

USE [ProjectTimeManager]
GO

/****** Object:  Table [dbo].[Project]    Script Date: 1/21/2017 5:19:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Project](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Employee]    Script Date: 1/21/2017 5:19:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](25) NOT NULL,
	[LastName] [nvarchar](25) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[TimeLog]    Script Date: 1/21/2017 5:20:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TimeLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Employee_EmployeeId] [int] NOT NULL,
	[Project_ProjectId] [int] NOT NULL,
	[LogDescription] [nvarchar](100) NOT NULL,
	[LogStartTime] [time](7) NOT NULL,
	[LogEndTime] [time](7) NOT NULL,
	[LogDate] [date] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TimeLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TimeLog] ADD  CONSTRAINT [DF__TimeLog__TimeStamp]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[TimeLog]  WITH CHECK ADD  CONSTRAINT [FK_Employee] FOREIGN KEY([Employee_EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO

ALTER TABLE [dbo].[TimeLog] CHECK CONSTRAINT [FK_Employee]
GO

ALTER TABLE [dbo].[TimeLog]  WITH CHECK ADD  CONSTRAINT [FK_Project] FOREIGN KEY([Project_ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO

ALTER TABLE [dbo].[TimeLog] CHECK CONSTRAINT [FK_Project]
GO
