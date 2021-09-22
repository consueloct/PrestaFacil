using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinancieraAcme.PrestaFacil.Domain.Entities
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }//Id nombre de prop PK
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public string DocumentoIdentidad { get; set; }

        public List<LoanApplicationMain> LoanApplicationMains { get; set; }
        
    }
}
