using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinancieraAcme.PrestaFacil.Domain
{
    public interface IUnitOfWork
    {
        Task GuardarAsync();
    }
}
