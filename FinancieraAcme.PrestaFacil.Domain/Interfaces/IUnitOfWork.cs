using System;
using System.Collections.Generic;
using System.Text;

namespace FinancieraAcme.PrestaFacil.Domain
{
    public interface IUnitOfWork
    {
        Task GuardarAsync();
    }
}
