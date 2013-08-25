--
-- Task 1
--

---------------------------------------------------------------------
-- Create database PerformanceHomeworkDb
---------------------------------------------------------------------

USE master
GO

CREATE DATABASE PerformanceHomeworkDb
GO

USE PerformanceHomeworkDb
GO

---------------------------------------------------------------------
-- Create table and populate 111111 Rows
---------------------------------------------------------------------

CREATE TABLE DateAndTextTable(
  ItemId int NOT NULL PRIMARY KEY IDENTITY,
  TextColumn varchar(100),
  DateColumn datetime
)


declare @FromDate date = '2011-01-01'
declare @ToDate date = '2015-12-31'
DECLARE @RandomDate date
DECLARE @Counter int = 0
DECLARE @TextField varchar(100)

WHILE (SELECT COUNT(*) FROM DateAndTextTable) < 111111
BEGIN
select @RandomDate = dateadd(day, rand(checksum(newid()))*(1+datediff(day, @FromDate, @ToDate)), @FromDate)
SET @TextField = 'TEXT';
INSERT INTO DateAndTextTable(TextColumn, DateColumn)
VALUES (@TextField, @RandomDate);  
  SET @Counter = @Counter + 1
END

SELECT *  FROM DateAndTextTable

----------------------------------------------------------------------
-- Search in the table by date range. Check the speed (without caching).
----------------------------------------------------------------------

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM DateAndTextTable
WHERE DateColumn > '2011-01-01' and DateColumn < '2013-01-01'

--
-- Task 2
--

----------------------------------------------------------------------
-- Create index to speed-up the search by date
----------------------------------------------------------------------

CREATE INDEX IDX_DateAndTextTable_DateColumn ON DateAndTextTable(DateColumn)

SELECT * FROM DateAndTextTable
WHERE DateColumn > '2011-01-01' and DateColumn < '2013-01-01'

DROP INDEX IDX_DateAndTextTable_DateColumn ON DateAndTextTable

--
-- Task 3
--
----------------------------------------------------------------------
-- Create full text index for the text column
----------------------------------------------------------------------

CREATE FULLTEXT CATALOG DateAndTextTableFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON DateAndTextTable(TextColumn)
KEY INDEX PK__DateAndTime
ON DateAndTextTableFullTextCatalog
WITH CHANGE_TRACKING AUTO

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM DateAndTextTable
WHERE CONTAINS(TextColumn, 'TEXT')

DROP FULLTEXT INDEX ON DateAndTextTable
DROP FULLTEXT CATALOG DateAndTextTableFullTextCatalog

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT * FROM DateAndTextTable
WHERE TextColumn LIKE 'TEXT'

