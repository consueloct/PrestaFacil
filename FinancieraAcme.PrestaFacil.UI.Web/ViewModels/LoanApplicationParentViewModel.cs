using FinancieraAcme.PrestaFacil.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancieraAcme.PrestaFacil.UI.Web.ViewModels
{
    public class LoanApplicationParentViewModel
    {
        //public int Id { get; set; }
        //public DateTime FechaSolicitud { get; set; }

        //public int ClientId { get; set; }

        public LoanApplicationParent LoanApplicationParent { get; set; }
        public SelectList Clients { get; set; }


        public LoanApplicationParentViewModel()
        {
                
        }
        public LoanApplicationParentViewModel(IList<Client> clients)
        {
            this.Clients = new SelectList(clients, "Id", "Apellidos");
        }
    }
}
