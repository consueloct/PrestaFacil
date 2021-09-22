
using FinancieraAcme.PrestaFacil.Domain.Entities;
using FinancieraAcme.PrestaFacil.Domain.Interfaces;
using FinancieraAcme.PrestaFacil.Infrastructure.Data.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancieraAcme.PrestaFacil.Infrastructure.Data.Repository
{
    public class LoanApplicationRepository : ILoanApplication
    {
        private readonly PrestaFacilDbContext _db;

        public LoanApplicationRepository(PrestaFacilDbContext db)
        {
            _db = db;
        }
        public IQueryable<LoanApplication> TraerTodos()
        {
            return _db.LoanApplications.AsQueryable();
        }
        public LoanApplication TraerPorId(int id)
        {
            return _db.LoanApplications.Find(id);
        }

        public void Agregar(LoanApplication loanApplication)
        {
            _db.Add<LoanApplication>(loanApplication);
        }

        public void Editar(LoanApplication loanApplication)
        {
            _db.LoanApplications.Attach(loanApplication).State = EntityState.Modified;
        }

        public void Eliminar(int id)
        {
            var loanApplication = TraerPorId(id);
            if (loanApplication != null)
            {
                _db.Remove<LoanApplication>(loanApplication);
            }
        }


        public async Task GuardarAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<int> AgregarSPAsync(LoanApplication loanApplication)
        {
            var output = new SqlParameter();
            output.ParameterName = "@Id";
            output.SqlDbType = System.Data.SqlDbType.Int;
            output.Direction = System.Data.ParameterDirection.Output;
            string sp = "uspLoanApplicationInsertar";
            FormattableString sql = $@"{sp} {output} out, {loanApplication.FechaRegistro},{loanApplication.Cliente},{loanApplication.MontoSolicitado}";
            await _db.Database.ExecuteSqlInterpolatedAsync(sql);
            return (int)output.Value;
        }

        public async Task EditarSPAsync(LoanApplication loanApplication)
        {
            string sp = "uspLoanApplicationActualizar";
            FormattableString sql =$@"{sp} {loanApplication.Id}, {loanApplication.FechaRegistro},{loanApplication.Cliente},{loanApplication.MontoSolicitado}";
            await _db.Database.ExecuteSqlInterpolatedAsync(sql);

        }

        public async Task EliminarSPAsync(int id)
        {
            string sp = "uspLoanApplicationEliminar";
            FormattableString sql = $@"{sp} {id}";
            await _db.Database.ExecuteSqlInterpolatedAsync(sql);
        }
    }
}
