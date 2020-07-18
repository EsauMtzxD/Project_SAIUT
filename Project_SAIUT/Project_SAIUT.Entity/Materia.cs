using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Materia
    {

        [Key]
        public int Id { get; set; }

        public int Descripcion { get; set; }

        [ForeignKey("Maestros")]
        public int Id_Maestro { get; set; }
        public Maestros Maestros { get; set; }

        public ICollection<Calificaciones> Calificaciones { get; set; }

    }
}
