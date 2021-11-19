using FinancieraAcme.PrestaFacil.Domain.Entities;
using FinancieraAcme.PrestaFacil.Domain.Interfaces;
using FinancieraAcme.PrestaFacil.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinancieraAcme.PrestaFacil.Infrastructure.Data.Repository
{
    public class ClientRepository: IClient
    {
        private readonly PrestaFacilDbContext _db;
        public ClientRepository(PrestaFacilDbContext db)//contructor
        {
            _db = db;
        }
        public IQueryable<Client> TraerTodos()
        {
            return _db.Clients.AsQueryable();
        }
        public Client TraerPorId(int id)
        {
            return _db.Clients.Find(id);
        }
    }
}
