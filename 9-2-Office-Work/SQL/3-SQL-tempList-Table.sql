  WITH TableList AS
( SELECT TableName, ParentTableName, WhereClause, PrimaryKey
  FROM DBO.MOBYLB_ArchivingConfiguration_Current
  WHERE TableName = 'MOBYLB_Trip_NA'

  UNION ALL

  SELECT a.TableName, b.ParentTableName, a.WhereClause, a.PrimaryKey
  FROM DBO.MOBYLB_ArchivingConfiguration_Current AS a
  inner join TableList AS b ON a.ParentTableName = b.TableName
)

SELECT *
INTO #tempList
FROM TableList
ORDER BY TableName

DELETE FROM #tempList WHERE TableName = 'MOBYLB_Trip_NA';

WHILE(exists(SELECT 1 FROM #tempList ))
BEGIN
  DECLARE @sql NVARCHAR(2000);
  DECLARE @tbl NVARCHAR(64);
       
  SELECT TOP 1 @sql = TableName , @tbl = TableName  FROM #tempList
  ORDER by TableName
 
       
  PRINT @sql;
 
  DELETE FROM #tempList WHERE TableName = @tbl;

  SELECT @sql = '';
  SELECT @tbl = '';
END
DROP TABLE #tempList