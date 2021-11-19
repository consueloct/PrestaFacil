﻿
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
    public class LoanApplicationChildRepository : ILoanApplicationChildRepository
    {
        private readonly PrestaFacilDbContext _db;

        public LoanApplicationChildRepository(PrestaFacilDbContext db)
        {
            _db = db;
        }
        public IQueryable<LoanApplicationChild> TraerTodos()
        {
            return _db.LoanApplicationChilds.AsQueryable();
        }
        public LoanApplicationChild TraerPorId(int id)
        {
            return _db.LoanApplicationChilds.Find(id);
        }

        public void Agregar(LoanApplicationChild loanApplicationChild)
        {
            _db.Add<LoanApplicationChild>(loanApplicationChild);
        }

        public void Editar(LoanApplicationChild loanApplicationChild)
        {
            _db.LoanApplicationChilds.Attach(loanApplicationChild).State = EntityState.Modified;
        }

        public void Eliminar(int id)
        {
            var loanApplicationChild = TraerPorId(id);
            if (loanApplicationChild != null)
            {
                _db.Remove<LoanApplicationChild>(loanApplicationChild);
            }
        }


        public async Task GuardarAsync()
        {
            await _db.SaveChangesAsync();
        }

        //public async Task<int> AgregarSPAsync(LoanApplication loanApplication)
        //{
        //    var output = new SqlParameter();
        //    output.ParameterName = "@Id";
        //    output.SqlDbType = System.Data.SqlDbType.Int;
        //    output.Direction = System.Data.ParameterDirection.Output;
        //    string sp = "uspLoanApplicationInsertar";
        //    FormattableString sql = $@"{sp} {output} out, {loanApplication.FechaRegistro},{loanApplication.Cliente},{loanApplication.MontoSolicitado}";
        //    await _db.Database.ExecuteSqlInterpolatedAsync(sql);
        //    return (int)output.Value;
        //}

        //public async Task EditarSPAsync(LoanApplication loanApplication)
        //{
        //    string sp = "uspLoanApplicationActualizar";
        //    FormattableString sql =$@"{sp} {loanApplication.Id}, {loanApplication.FechaRegistro},{loanApplication.Cliente},{loanApplication.MontoSolicitado}";
        //    await _db.Database.ExecuteSqlInterpolatedAsync(sql);

        //}

        //public async Task EliminarSPAsync(int id)
        //{
        //    string sp = "uspLoanApplicationEliminar";
        //    FormattableString sql = $@"{sp} {id}";
        //    await _db.Database.ExecuteSqlInterpolatedAsync(sql);
        //}
    }
}
