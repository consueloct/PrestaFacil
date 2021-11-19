using FinancieraAcme.PrestaFacil.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinancieraAcme.PrestaFacil.Domain
{
    public interface IUnitOfWork
    {
        ILoanApplicationParentRepository LoanApplicationParentRepository { get; }
        ILoanApplicationChildRepository LoanApplicationChildRepository { get; }

        Task GuardarAsync();

    }
}
