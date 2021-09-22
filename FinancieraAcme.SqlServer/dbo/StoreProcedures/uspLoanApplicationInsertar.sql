CREATE PROCEDURE [dbo].[uspLoanApplicationInsertar]
	@Id int output,--
	@FechaRegistro datetime,
	@Cliente varchar(500),
	@MontoSolicitado decimal(7,2)
AS
	INSERT LoanApplications
	values (@FechaRegistro,@Cliente,@MontoSolicitado);
	select @Id=SCOPE_IDENTITY();--last Id generated in the scope you are working
RETURN 0
