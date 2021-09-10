Create or Alter procedure spGetAllEmployee
as 
begin try
select * from employee_payroll
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH 

CREATE OR ALTER procedure spInsertEmployeeDetails
(
	@Name VARCHAR(255),
	@Gender VARCHAR(1),
	@phone_Number VARCHAR(12),
	@Address VARCHAR(40),
	@Department VARCHAR(15),
	@BasicPay INT,
	@Deduction FLOAT,
	@TaxablePay FLOAT,
	@Tax FLOAT,
	@NetPay FLOAT,
	@StartDate date	
)
AS
	Begin Try
			INSERT Into employee_payroll(Name,Gender,phone_Number, Address,Department,BasicPay,TaxablePay,Tax, NetPay, StartDate) VALUES (@Name,@Gender,@phone_Number, @Address,@Department,@BasicPay,@TaxablePay,@Tax, @NetPay, @StartDate)
	End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH 

CREATE OR ALTER procedure spUpdateEmployee
(
	@BasicPay INT,
	@Name VARCHAR(255)
)
AS
Begin Try
UPDATE employee_payroll
SET BasicPay = @BasicPay
WHERE Name = @Name
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH

CREATE OR ALTER procedure spGetDataByDate
(
	@StartDate date,
	@EndDate date
)
AS
Begin Try
SELECT * FROM employee_payroll
WHERE StartDate BETWEEN CAST('10-01-1997' AS DATE ) AND GETDATE();
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH
