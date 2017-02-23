USE [master]
GO

/****** Object:  StoredProcedure [dbo].[proc_reindex]    Script Date: 02/23/2017 15:09:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Skrypt pobrany ze strony http://strefa.guzowski.info
-- Opis do kodu:
-- http://strefa.guzowski.info/archives/43,2007,02,13.html
-- ale musia³a byæ trochê poprawiona przeze mnie o wskazanie schematu tabeli
-- Stefan Soliñski (Galsoft s.c.)

CREATE PROCEDURE [dbo].[proc_reindex]
	@database_name sysname,
	@min_fragmentation_level numeric(5,2) = 0
AS
BEGIN

	SET NOCOUNT ON

	DECLARE
		@dbid int,
		@object_id int,
		@index_id int,
		@sql_batch nvarchar(1000);
	
	DECLARE @licznik int	
	set @licznik = 0

	DECLARE
		@indexes TABLE (obj_id int, ind_id int);                        
       
	IF @min_fragmentation_level IS NULL OR @min_fragmentation_level NOT BETWEEN 0 AND 100
	BEGIN
		RAISERROR (N'Minimum fragmentation level is invalid. Try better next time.', 10, 1);
		RETURN 1;
	END

	SET @dbid = (SELECT database_id from sys.databases WHERE [name] = @database_name);
       
	IF @dbid IS NULL
	BEGIN
		RAISERROR (N'Database name ''%s'' is invalid. Try better next time.', 10, 1, @database_name);
		RETURN 2;
	END

	INSERT INTO @indexes (obj_id, ind_id)
	SELECT [object_id], [index_id] 
	FROM sys.dm_db_index_physical_stats (@dbid, NULL, NULL, NULL, NULL)
	WHERE 
		index_type_desc <> 'HEAP' 
		AND avg_fragmentation_in_percent >= @min_fragmentation_level;

	DECLARE ci CURSOR FOR
	SELECT obj_id, ind_id FROM @indexes;

	OPEN ci;
	FETCH NEXT FROM ci INTO @object_id, @index_id;

	WHILE @@FETCH_STATUS = 0
	BEGIN
        set @licznik = @licznik + 1
	
		SET @sql_batch = N'DECLARE @index_name sysname, @sql nvarchar(1000); '+
			'USE '+QUOTENAME(ISNULL(CAST(@database_name as nvarchar(128)),''))+
			'; SET @index_name = (SELECT [name] FROM sys.indexes WHERE object_id = '+
			ISNULL(CAST(@object_id as nvarchar(128)),'')+
			' AND index_id = '+ISNULL(CAST(@index_id as nvarchar(128)),'')+
			'); SET @sql = N''ALTER INDEX ''+QUOTENAME(@index_name)+'' ON ''+QUOTENAME(OBJECT_SCHEMA_NAME('+
			ISNULL(CAST(@object_id as nvarchar(128)),'')+
			'))	+''.''+QUOTENAME(OBJECT_NAME('+
			ISNULL(CAST(@object_id as nvarchar(128)),'')+
			'))+'' REBUILD''; EXEC sp_executesql @sql;';
		
		EXEC sp_executesql @sql_batch
		PRINT cast(@licznik as char(6)) + @sql_batch -- debug ;)

		FETCH NEXT FROM ci INTO @object_id, @index_id;

	END

	CLOSE ci;
	DEALLOCATE ci;

	PRINT 'Zakonczono odbudowe indeksow w bazie '+@database_name;
	RETURN 0;

END

GO


