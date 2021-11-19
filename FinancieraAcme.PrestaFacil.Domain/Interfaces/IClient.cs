using FinancieraAcme.PrestaFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinancieraAcme.PrestaFacil.Domain.Interfaces
{
    public interface IClient
    {
        IQueryable<Client> TraerTodos();
        Client TraerPorId(int id);
    }
}
