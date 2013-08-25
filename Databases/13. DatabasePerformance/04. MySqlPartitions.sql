
CREATE DATABASE PerhormanceHomeworkDb;

USE PerhormanceHomeworkDb;


DROP TABLE DateAndTextTable
CREATE TABLE DateAndTextTable(
  ItemId int NOT NULL AUTO_INCREMENT,
  TextColumn varchar(100),
  DateColumn datetime NOT NULL,
  PRIMARY KEY (ItemId, DateColumn)
)PARTITION BY RANGE(YEAR(DateColumn)) (
    PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p1 VALUES LESS THAN (1995),
    PARTITION p2 VALUES LESS THAN (2000),
    PARTITION p3 VALUES LESS THAN (2005),
    PARTITION p4 VALUES LESS THAN MAXVALUE
)


INSERT INTO DateAndTextTable(TextColumn, DateColumn) 
VALUES
  ('Some text', '2003-8-11'),
  ('Some text', '1985-7-25'),
  ('Some text', '2011-3-31'),
  ('Some text', '1992-1-1'),
  ('Some text', '1994-9-21'),
  ('Some text', '2013-1-31'),
  ('Some text', '2012-1-31'),
  ('Some text', '2004-7-27'),
  ('Some text', '2008-1-24');

SELECT * FROM DateAndTextTable
WHERE YEAR(DateColumn) > 2000;
