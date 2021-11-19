using FinancieraAcme.PrestaFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancieraAcme.PrestaFacil.Domain.Interfaces
{
    public interface ILoanApplicationChildRepository
    {
        IQueryable<LoanApplicationChild> TraerTodos();
        LoanApplicationChild TraerPorId(int id);
        void Agregar(LoanApplicationChild loanApplicationChild);
        void Editar(LoanApplicationChild loanApplicationChild);
        void Eliminar(int id);
        Task GuardarAsync();

    }
}
