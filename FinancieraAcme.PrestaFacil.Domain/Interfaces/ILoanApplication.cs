using FinancieraAcme.PrestaFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancieraAcme.PrestaFacil.Domain.Interfaces
{
    public interface ILoanApplication
    {
        IQueryable<LoanApplication> TraerTodos();
        LoanApplication TraerPorId(int id);
        void Agregar(LoanApplication loanApplication);
        void Editar(LoanApplication loanApplication);
        void Eliminar(int id);
        Task GuardarAsync();

        Task<int> AgregarSPAsync(LoanApplication loanApplication);
        Task EditarSPAsync(LoanApplication loanApplication);
        Task EliminarSPAsync(int id);
    }
}
