using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinancieraAcme.PrestaFacil.Domain.Entities
{
    public class LoanApplicationMain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int ClientId { get; set; }
        //navigation
        public Client Client { get; set; }

        public List<LoanApplicationMainDetail> LoanApplicationMainDetails { get; set; }


    }
}
