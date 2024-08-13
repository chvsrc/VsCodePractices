-- SQL Stored Procedure Logical Children Delete
/****** Object:  StoredProcedure [dbo].[SP_LogicalChildrenDelete]    Script Date: 9/18/2019 10:39:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_LogicalChildrenDelete] @parentTable NVARCHAR(64),  @whereClause NVARCHAR(128),  @version VARCHAR(50)
AS
BEGIN
WITH TableList AS
( SELECT TableName, ParentTableName, WhereClause, PrimaryKey
  FROM DBO.MOBYLB_ArchivingConfiguration_Current
  WHERE TableName = @parentTable

  UNION ALL

  SELECT a.TableName, b.ParentTableName, a.WhereClause, a.PrimaryKey
  FROM DBO.MOBYLB_ArchivingConfiguration_Current AS a
  inner join TableList AS b ON a.ParentTableName = b.TableName
)

SELECT *
INTO #tempList
FROM TableList
ORDER BY TableName

DELETE FROM #tempList WHERE TableName = @parentTable;

WHILE(exists(SELECT 1 FROM #tempList ))
BEGIN
  DECLARE @sql NVARCHAR(2000);
  DECLARE @tbl NVARCHAR(64);
       
  SELECT TOP 1 @sql = 'UPDATE ' + TableName  +'_'+ @version + ' SET Deleted = 1 WHERE ' + @whereClause, @tbl = TableName  FROM #tempList
  ORDER by TableName

  PRINT @sql;
  EXEC(@sql);
  DELETE FROM #tempList WHERE TableName = @tbl;

  SELECT @sql = '';
  SELECT @tbl = '';
END
DROP TABLE #tempList
END

-- SQL TRIGGER
/****** Object:  Trigger [dbo].[TR_dbo_MOBYLB_Trip_NA_4_0_UpdateDataArchiving]    Script Date: 9/18/2019 10:42:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER TRIGGER [dbo].[TR_dbo_MOBYLB_Trip_NA_4_0_UpdateDataArchiving] ON [dbo].[MOBYLB_Trip_NA_4_0]
AFTER UPDATE
AS
BEGIN
IF EXISTS(SELECT 1 from INSERTED as a INNER JOIN DELETED as b ON a.Id = b.Id AND a.Deleted = 1 AND a.Deleted != b.Deleted)
BEGIN
DECLARE @TripIdn varchar(6), @CorporateIdn varchar(6)
SELECT @TripIdn = a.TripIdn, @CorporateIdn = a.CorporateIdn from INSERTED as a
INNER JOIN DELETED as b ON a.Id = b.Id
AND a.Deleted = 1

DECLARE @Data varchar(180)
SELECT @Data = 'TripIdn = ' + '''' + @TripIdn + '''' +' AND CorporateIdn = ' + '''' + @CorporateIdn + ''''
EXEC SP_LogicalChildrenDelete 'MOBYLB_Trip_NA', @Data ,'4_0'
END
END