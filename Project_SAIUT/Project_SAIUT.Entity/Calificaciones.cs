using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Calificaciones
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Alumno")]
        public int Id_Alumno { get; set; }
        public Alumno Alumno { get; set; }

        [ForeignKey("Materia")]
        public int Id_Materia { get; set; }
        public Materia Materia { get; set; }

    }
}
