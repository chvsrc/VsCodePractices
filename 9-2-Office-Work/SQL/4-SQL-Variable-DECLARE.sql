DECLARE @TripIdn varchar(6), @CorporateIdn varchar(6)
DECLARE @Data varchar(180)
SELECT @TripIdn=568
SELECT @CorporateIdn=5618
SELECT @Data = 'UPDATE MOBYLB_TripActuals_EU_3_9 SET Deleted=1 WHERE TripIdn = ' + '''' + @TripIdn + '''' +' AND CorporateIdn = ' + '''' + @CorporateIdn + ''''
PRINT @Data