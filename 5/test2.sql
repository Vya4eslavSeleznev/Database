USE test_copy
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'V1', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V1'
GO
IF  EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'V1', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V1'
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Staff]') AND type in (N'U'))
ALTER TABLE [dbo].[Staff] DROP CONSTRAINT IF EXISTS [CK_Staff_1]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Staff]') AND type in (N'U'))
ALTER TABLE [dbo].[Staff] DROP CONSTRAINT IF EXISTS [CK_Staff]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Staff]') AND type in (N'U'))
ALTER TABLE [dbo].[Staff] DROP CONSTRAINT IF EXISTS [FK_Staff_Post]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Staff]') AND type in (N'U'))
ALTER TABLE [dbo].[Staff] DROP CONSTRAINT IF EXISTS [FK_Staff_Dept]
GO
/****** Object:  Table [dbo].[T1]    Script Date: 25.09.2020 17:20:20 ******/
DROP TABLE IF EXISTS [dbo].[T1]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 25.09.2020 17:20:20 ******/
DROP TABLE IF EXISTS [dbo].[Post]
GO
/****** Object:  View [dbo].[V1]    Script Date: 25.09.2020 17:20:20 ******/
DROP VIEW IF EXISTS [dbo].[V1]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 25.09.2020 17:20:20 ******/
DROP TABLE IF EXISTS [dbo].[Staff]
GO
/****** Object:  Table [dbo].[Dept]    Script Date: 25.09.2020 17:20:20 ******/
DROP TABLE IF EXISTS [dbo].[Dept]
GO
/****** Object:  UserDefinedDataType [dbo].[Phone]    Script Date: 25.09.2020 17:20:20 ******/
DROP TYPE IF EXISTS [dbo].[Phone]
GO
/****** Object:  UserDefinedDataType [dbo].[Age]    Script Date: 25.09.2020 17:20:20 ******/
DROP TYPE IF EXISTS [dbo].[Age]
GO

DECLARE @RoleName sysname
set @RoleName = N'New_Role'

IF @RoleName <> N'public' and (select is_fixed_role from sys.database_principals where name = @RoleName) = 0
BEGIN
    DECLARE @RoleMemberName sysname
    DECLARE Member_Cursor CURSOR FOR
    select [name]
    from sys.database_principals 
    where principal_id in ( 
        select member_principal_id
        from sys.database_role_members
        where role_principal_id in (
            select principal_id
            FROM sys.database_principals where [name] = @RoleName AND type = 'R'))

    OPEN Member_Cursor;

    FETCH NEXT FROM Member_Cursor
    into @RoleMemberName
    
    DECLARE @SQL NVARCHAR(4000)

    WHILE @@FETCH_STATUS = 0
    BEGIN
        
        SET @SQL = 'ALTER ROLE '+ QUOTENAME(@RoleName,'[') +' DROP MEMBER '+ QUOTENAME(@RoleMemberName,'[')
        EXEC(@SQL)
        
        FETCH NEXT FROM Member_Cursor
        into @RoleMemberName
    END;

    CLOSE Member_Cursor;
    DEALLOCATE Member_Cursor;
END
/****** Object:  DatabaseRole [New_Role]    Script Date: 25.09.2020 17:20:20 ******/
DROP ROLE IF EXISTS [New_Role]
GO
/****** Object:  User [test]    Script Date: 25.09.2020 17:20:20 ******/
DROP USER IF EXISTS [test]
GO
/****** Object:  User [test]    Script Date: 25.09.2020 17:20:20 ******/
CREATE USER [test] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [New_Role]    Script Date: 25.09.2020 17:20:20 ******/
CREATE ROLE [New_Role]
GO
ALTER ROLE [New_Role] ADD MEMBER [test]
GO
ALTER ROLE [db_datareader] ADD MEMBER [test]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [test]
GO
/****** Object:  UserDefinedDataType [dbo].[Age]    Script Date: 25.09.2020 17:20:20 ******/
CREATE TYPE [dbo].[Age] FROM [smallint] NULL
GO
/****** Object:  UserDefinedDataType [dbo].[Phone]    Script Date: 25.09.2020 17:20:20 ******/
CREATE TYPE [dbo].[Phone] FROM [char](15) NULL
GO
/****** Object:  Table [dbo].[Dept]    Script Date: 25.09.2020 17:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dept](
	[IdDept] [int] IDENTITY(1,1) NOT NULL,
	[DepName] [varchar](20) NULL,
	[Chief] [int] NULL,
 CONSTRAINT [PK_Dept] PRIMARY KEY CLUSTERED 
(
	[IdDept] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 25.09.2020 17:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[IdPerson] [int] IDENTITY(1,1) NOT NULL,
	[Dept] [int] NULL,
	[Name] [varchar](30) NOT NULL,
	[Age] [smallint] NULL,
	[Oklad] [int] NOT NULL,
	[Nalog] [int] NOT NULL,
	[Summa]  AS ([Oklad]-([Oklad]*[Nalog])/(100)),
	[PostId] [int] NOT NULL,
	[Phone] [dbo].[Phone] NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[IdPerson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V1]    Script Date: 25.09.2020 17:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V1]
AS
SELECT dbo.Staff.Name, dbo.Staff.Phone, dbo.Dept.DepName
FROM     dbo.Staff INNER JOIN
                  dbo.Dept ON dbo.Staff.Dept = dbo.Dept.IdDept
GO
/****** Object:  Table [dbo].[Post]    Script Date: 25.09.2020 17:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[IdPost] [int] IDENTITY(1,1) NOT NULL,
	[Post] [char](20) NULL,
	[Money] [int] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[IdPost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T1]    Script Date: 25.09.2020 17:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T1](
	[C1] [int] NOT NULL,
	[C2] [char](10) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Dept] FOREIGN KEY([Dept])
REFERENCES [dbo].[Dept] ([IdDept])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Dept]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Post] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([IdPost])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Post]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [CK_Staff] CHECK  (([Age]>=(15) AND [Age]<=(80)))
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [CK_Staff]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [CK_Staff_1] CHECK  (([Age]>=(15) AND [Age]<=(80)))
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [CK_Staff_1]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Staff"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 267
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Dept"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 148
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V1'
GO
