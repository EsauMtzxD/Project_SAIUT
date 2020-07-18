using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Colegiatura
    {

        [Key]
        public int Id { get; set; }

        public string Mensualidad { get; set; }

        public Decimal CantidadTotal { get; set; }

        public Decimal Pagado { get; set; }

        public bool isPagado { get; set; }

        [ForeignKey("Alumno")]
        public int Id_Alumno { get; set; }
        public Alumno Alumno { get; set; }

    }
}
