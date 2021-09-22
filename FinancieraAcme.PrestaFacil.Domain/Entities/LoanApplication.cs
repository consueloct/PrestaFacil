using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinancieraAcme.PrestaFacil.Domain.Entities
{
    public class LoanApplication
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }//Id nombre de prop PK
        public DateTime  FechaRegistro{ get; set; }

        [Required(ErrorMessage ="Name needed")]
        [Column(TypeName ="varchar(500)")]
        public string Cliente { get; set; }

        [Required]
        [Range(1, 50000)]
        public decimal MontoSolicitado{ get; set; }

        public LoanApplication()
        {
            this.FechaRegistro = DateTime.Now;
            this.MontoSolicitado = 1;
        }   

}
}
