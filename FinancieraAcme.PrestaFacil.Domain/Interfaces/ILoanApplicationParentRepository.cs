using FinancieraAcme.PrestaFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancieraAcme.PrestaFacil.Domain.Interfaces
{
    public interface ILoanApplicationParentRepository
    {
        IQueryable<LoanApplicationParent> TraerTodos();
        LoanApplicationParent TraerPorId(int id);
        void Agregar(LoanApplicationParent loanApplicationParent);
        void Editar(LoanApplicationParent loanApplicationParent);
        void Eliminar(int id);
        Task GuardarAsync();

        //Task<int> AgregarSPAsync(LoanApplicationMain loanApplication);
        //Task EditarSPAsync(LoanApplicationMain loanApplicationMain);
        //Task EliminarSPAsync(int id);
    }
}
