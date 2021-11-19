using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinancieraAcme.PrestaFacil.Domain.Entities
{
    public class LoanApplicationChild
    {
        
        public int LoanApplicationParentId { get; set; }
        public int Item { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Producto { get; set; }

        public LoanApplicationParent LoanApplicationParent { get; set; }
    }
}
