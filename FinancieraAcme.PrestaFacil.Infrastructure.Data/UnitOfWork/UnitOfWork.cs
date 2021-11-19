using FinancieraAcme.PrestaFacil.Domain;
using FinancieraAcme.PrestaFacil.Domain.Interfaces;
using FinancieraAcme.PrestaFacil.Infrastructure.Data.Model;
using FinancieraAcme.PrestaFacil.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinancieraAcme.PrestaFacil.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly PrestaFacilDbContext _db;
        private ILoanApplicationParentRepository _loanApplicationParent;
        private ILoanApplicationChildRepository _loanApplicationChild;

        public UnitOfWork(PrestaFacilDbContext db)
        {
            _db = db;
        }
        public ILoanApplicationParentRepository LoanApplicationParentRepository
        {
            get
            {
                if (this._loanApplicationParent == null)
                    this._loanApplicationParent = new LoanApplicationParentRepository(_db);
                return _loanApplicationParent;
            }
        }
        public ILoanApplicationChildRepository LoanApplicationChildRepository
        {
            get
            {
                if (this._loanApplicationChild == null)
                    this._loanApplicationChild = new LoanApplicationChildRepository(_db);
                return _loanApplicationChild;
            }
        }

        public async Task GuardarAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
