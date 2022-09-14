using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Edmsoft.Models
{
    public class StudentGrade
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Required.")]
        public decimal PrimerCorte { get; set; }

        [Required(ErrorMessage = "Required.")]
        public decimal SegundoCorte { get; set; }

        [Required(ErrorMessage = "Required.")]
        public decimal TercerCorte { get; set; }

        public string Comentarios { get; set; }
        public decimal NotaFinal { get { return (((PrimerCorte * 15) / 100) + ((SegundoCorte * 35) / 100) + ((TercerCorte * 50) / 100)); } }
    }
}
