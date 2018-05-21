USE [FeatureTogglesSqlData]
GO
/****** Object:  Table [dbo].[FeatureTogglesSqlData]    Script Date: 5/21/2018 7:27:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeatureTogglesSqlData](
	[Name] [varchar](50) NOT NULL,
	[Value] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[pr_FeatureTogglesAlterar]    Script Date: 5/21/2018 7:27:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[pr_FeatureTogglesAlterar]
	@Name VARCHAR(50),
	@Value VARCHAR(50)
AS
BEGIN
	UPDATE FeatureTogglesSqlData 
	SET Value=@Value
	WHERE Name = @Name
END
GO
/****** Object:  StoredProcedure [dbo].[pr_FeatureTogglesConsultar]    Script Date: 5/21/2018 7:27:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[pr_FeatureTogglesConsultar]
	@Name VARCHAR(50)
AS
BEGIN
	SELECT Value
	FROM FeatureTogglesSqlData
	WHERE Name = @Name
END
GO
/****** Object:  StoredProcedure [dbo].[pr_FeatureTogglesIncluir]    Script Date: 5/21/2018 7:27:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[pr_FeatureTogglesIncluir]
	@Name VARCHAR(50),
	@Value VARCHAR(50)
AS
BEGIN
	INSERT INTO FeatureTogglesSqlData 
		(Name
		,Value)
	VALUES(@Name
		,@Value)
END
GO
/****** Object:  StoredProcedure [dbo].[pr_FeatureTogglesInserir]    Script Date: 5/21/2018 7:27:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[pr_FeatureTogglesInserir]
	@Name VARCHAR(50),
	@Value VARCHAR(50)
AS
BEGIN
	INSERT INTO FeatureTogglesSqlData 
		(Name
		,Value)
	VALUES(@Name
		,@Value)
END
GO
