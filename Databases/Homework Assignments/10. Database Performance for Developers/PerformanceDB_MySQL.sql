/*Task 4
Create the same table in MySQL and partition it by date (1990, 2000, 2010). Fill 1 000 000 log entries. 
Compare the searching speed in all partitions (random dates) to certain partition (e.g. year 1995).
*/
CREATE DATABASE PerformanceDb;

USE PerformanceDb;
CREATE TABLE Logs(
  LogId int NOT NULL AUTO_INCREMENT,
  LogText nvarchar(100),
  LogDate datetime,
  PRIMARY KEY (LogId, LogDate)
)PARTITION BY RANGE(YEAR(LogDate)) (
	PARTITION p0 VALUES LESS THAN (1990),
	PARTITION p1 VALUES LESS THAN (2000),
	PARTITION p2 VALUES LESS THAN (2010),
	PARTITION p3 VALUES LESS THAN MAXVALUE
); 

DELIMITER $$

CREATE PROCEDURE `performancedb`.`up_FillLogs` (LogsCount int)
BEGIN

DECLARE RowsCount INT DEFAULT LogsCount;
DECLARE TextValue NVARCHAR(100);
DECLARE DateValue DATETIME;

START TRANSACTION;
WHILE RowsCount > 0 DO
	SET TextValue = CONCAT('Text ', CAST(10 AS NCHAR(100)), ': ', CAST(UUID() AS NCHAR(100)));
	SET DateValue = CURRENT_TIMESTAMP - INTERVAL FLOOR(RAND() * 100) YEAR;
	INSERT INTO Logs(LogText, LogDate) Values(TextValue, DateValue);
	SET RowsCount = RowsCount - 1;
END WHILE;
COMMIT;
END$$

DELIMITER ;


call up_FillLogs(1000000);

SELECT * FROM Logs PARTITION (p0);
SELECT * FROM Logs PARTITION (p1);
SELECT * FROM Logs PARTITION (p2);
SELECT * FROM Logs PARTITION (p3);

-- Select from all partittions
SELECT * FROM Logs;

-- Select from a single partition
SELECT * FROM Logs WHERE YEAR(LogDate) > 2000;


