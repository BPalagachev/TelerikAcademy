-- Task 1
USE TransactSqlHomeworkDB
GO

CREATE PROC usp_SelectFullNames
AS
	SELECT FirstName + ' ' + LastName AS FullName
	FROM Persons
GO

EXEC usp_SelectFullNames
GO

-- Task 2
USE TransactSqlHomeworkDB
GO

CREATE PROC usp_AllWithHigherBalance
@amount int
AS
	SELECT *
	FROM Persons p
	JOIN Accounts a
	ON  p.Id = a.PersonID
	WHERE a.Balance >= @amount
GO

EXEC usp_AllWithHigherBalance 100
GO

-- Task 3
USE TransactSqlHomeworkDB
GO

ALTER FUNCTION ufn_CalcInterest(@salary money, @interestRate real, @numberOfMonths int)
  RETURNS money
AS
BEGIN
  DECLARE @interest money;
  SET @interest = @salary*(@interestRate*(@numberOfMonths/12.0))
  RETURN @interest;
END
GO


USE TransactSqlHomeworkDB
SELECT dbo.ufn_CalcInterest(Balance,0.5, 12)
FROM Accounts
GO

-- Task 4
USE TransactSqlHomeworkDB
GO

ALTER PROC usp_GetMonthlyInterest
@AccountID int,
@YearlyInterestRate real
AS
	SELECT dbo.ufn_CalcInterest(Balance,@YearlyInterestRate, 1)
	FROM Accounts a
	WHERE Id = @AccountID
GO

EXEC usp_GetMonthlyInterest 3, 0.5
GO

SELECT *
FROM Accounts
GO
-- Task 5
CREATE PROC usp_WithdrawMoney
@AccountID int,
@amount money
AS
BEGIN
DECLARE @AccountBalance money
	BEGIN TRAN WithdrowTran
		SELECT @AccountBalance = Balance
		FROM Accounts
		WHERE Id = @AccountID
		IF @AccountBalance - @amount >= 0
			BEGIN
				UPDATE Accounts
				SET Balance = (@AccountBalance - @amount)
				WHERE Id = @AccountID
			END
		ELSE
			RAISERROR(N'Insufficient Funds', 10, 1)
	COMMIT 
END
GO

CREATE PROC usp_DepositMoney
@AccountID int,
@amount money
AS
BEGIN TRAN DepositTran	
	UPDATE Accounts
	SET Balance = (Balance + @amount)
	WHERE Id = @AccountID
	COMMIT 
GO

EXEC usp_DepositMoney 3, 1500
SELECT * FROM Accounts WHERE id = 3

EXEC usp_WithdrawMoney 3, 1000
SELECT * FROM Accounts WHERE id = 3

-- Task 6
USE TransactSqlHomeworkDB
GO

CREATE TABLE Logs (
  LogID int IDENTITY PRIMARY KEY,
  AccountID int NOT NULL,
  OldSum money NOT NULL,
  NewSum money NOT NULL
)
GO

ALTER TRIGGER LogTransactions ON Accounts
FOR UPDATE
AS
BEGIN
	DECLARE @AccountID int;
	DECLARE @OldAmount money;
	DECLARE @NewAmount money;

	
	SELECT @AccountID = i.Id, @NewAmount = i.Balance
	FROM inserted i
	SELECT @OldAmount = d.Balance
	FROM deleted d

	IF @OldAmount <> @NewAmount
	BEGIN
		Insert INTO Logs(AccountID, OldSum, NewSum) 
		VALUES (@AccountID, @OldAmount, @NewAmount)
	END
END
GO 

EXEC usp_DepositMoney 3, 3500
EXEC usp_WithdrawMoney 3, 1000

UPDATE Accounts
		SET PersonID = 3
		WHERE PersonID = 2


SELECT *
FROM Logs

SELECT *
FROM Accounts

-- Task 7
USE TelerikAcademy
GO

ALTER FUNCTION ufn_IsNameComposedOf(@Name nvarchar(MAX), @Substring nvarchar(MAX))
  RETURNS nvarchar(500)
AS
BEGIN
  DECLARE @position int = 1;
  DECLARE @CurrentChar nvarchar(1);
  DECLARE @NameContainsChar BIT = 1;
  WHILE @position <= DATALENGTH(@Name)
	BEGIN
		SELECT @CurrentChar = SUBSTRING(@Name, @position, 1)
		IF CHARINDEX(@CurrentChar, @Substring) < 0
		BEGIN
			SET @NameContainsChar = 0;
			BREAK;
		END
		SET @position = @position + 1
    END
	IF @NameContainsChar = 1
		RETURN @Name
	RETURN NULL
END
GO

SELECT dbo.ufn_IsNameComposedOf( FirstName + ' ' + LastName, 'Syed Abbas')
FROM Employees


-- Task 9
DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT t.Name AS Town, e.FirstName + ' ' + e.LastName As Employee
	FROM Employees e
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
	GROUP BY t.Name, e.FirstName, e.LastName

OPEN empCursor
DECLARE @CurrentTown nvarchar(MAX);
DECLARE @ToBePrinted nvarchar(MAX);
DECLARE @Town nvarchar(50), @Emplyee nvarchar(50)
FETCH NEXT FROM empCursor
INTO @Town, @Emplyee

SET @ToBePrinted = @Town + ': -> ';
SET @CurrentTown = @Town;

WHILE @@FETCH_STATUS = 0
  BEGIN
    SET @ToBePrinted = @ToBePrinted + @Emplyee +', '
    FETCH NEXT FROM empCursor 
    INTO @Town, @Emplyee
	IF @Town != @CurrentTown
		BEGIN
			PRINT @ToBePrinted
			SET @ToBePrinted = @Town + ': -> ';
			SET @CurrentTown = @Town;
		END
  END

CLOSE empCursor
DEALLOCATE empCursor
GO


-- Task 10
USE TelerikAcademy
GO
ALTER FUNCTION ABCDEFG()
RETURNS @tbl_Concated TABLE
  (Concated Nvarchar(MAX) )
AS
BEGIN
DECLARE @Name nvarchar(50) = 'gosho'
DECLARE @Result nvarchar(MAX);
	SELECT @Result = Concated
	FROM @tbl_Concated
	IF(@Result IS NULL)
		INSERT INTO  @tbl_Concated (Concated) VALUES (@Name);
	ELSE
		UPDATE @tbl_Concated
		SET Concated = @Result + ', ' + @Name

	RETURN
END
GO 




SELECT dbo.ABCDEFG()


DROP FUNCTION ufn_StrConcat


DECLARE @test int;
SELECT @test = ManagerID
from Employees
WHERE EmployeeID = '5555'

IF @test is NULL
SELECT 'OK'