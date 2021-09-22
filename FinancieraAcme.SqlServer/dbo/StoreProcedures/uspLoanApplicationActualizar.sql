CREATE PROCEDURE [dbo].[uspLoanApplicationActualizar]
	@Id int output,
	@FechaRegistro datetime,
	@Cliente varchar(500),
	@MontoSolicitado decimal(7,2)
AS
	UPDATE LoanApplications
	SET FechaRegistro=@FechaRegistro,
		Cliente=@Cliente,
		MontoSolicitado=@MontoSolicitado
	WHERE Id=@Id;
RETURN 0
