CREATE PROCEDURE [dbo].[uspLoanApplicationEliminar]
	@Id int
AS
	DELETE LoanApplications
	WHERE Id=@Id
RETURN 0
