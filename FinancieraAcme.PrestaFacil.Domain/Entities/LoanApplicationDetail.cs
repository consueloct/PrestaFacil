using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinancieraAcme.PrestaFacil.Domain.Entities
{
    public class LoanApplicationMainDetail
    {
        
        public int LoanApplicationMainId { get; set; }
        public int Item { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Producto { get; set; }

        public LoanApplicationMain LoanApplicationMain { get; set; }
    }
}
