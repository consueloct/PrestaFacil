using System;
using System.Collections.Generic;
using System.Text;

namespace FinancieraAcme.PrestaFacil.Domain
{
    public interface IUnitOfWork
    {
        ILoanApplicationMainRepository LoanApplicationMainRepository { get; }
        ILoanApplicationDetailRepository LoanApplicationDetailRepository { get; }

        Task GuardarAsync();

    }
}
