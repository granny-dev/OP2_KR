USE [TaskTrackerDB]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 19.05.2023 18:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Name] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TasksTable]    Script Date: 19.05.2023 18:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TasksTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Priority] [nvarchar](50) NOT NULL,
	[Executor] [nvarchar](50) NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Estimate] [nvarchar](50) NULL,
 CONSTRAINT [PK_TasksTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[TasksTable_AddTask]    Script Date: 19.05.2023 18:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TasksTable_AddTask]
	
	@Title nvarchar(50),
	@Status nvarchar(50),
	@Priority nvarchar(50),
	@Author nvarchar(50),
	@Executor nvarchar(50),
	@Estimate nvarchar(50),
	@Description nvarchar(50)
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
	insert into TasksTable (title, status, priority, author, executor, estimate, description)
   values( @Title, @Status, @Priority, @Author, @Executor,@Estimate, @Description)
END
GO
/****** Object:  StoredProcedure [dbo].[TasksTable_UpdateTask]    Script Date: 19.05.2023 18:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TasksTable_UpdateTask]
 
@Title nvarchar(50), 
@Status nvarchar(50), 
@Priority nvarchar(50), 
@Author nvarchar(50), 
@Executor nvarchar(50),
@Estimate nvarchar(50),
@Description nvarchar(50)
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   update TasksTable set 
    
   title = @Title, 
   status = @Status, 
   priority = @Priority, 
   author = @Author, 
   executor = @Executor, 
   estimate = @Estimate,
   description = @Description
   where title = @Title
   
END
GO
