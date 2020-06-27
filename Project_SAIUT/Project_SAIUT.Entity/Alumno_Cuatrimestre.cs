using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Alumno_Cuatrimestre
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Alumno")]
        [Required]
        [Range(0, int.MaxValue)]
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }

        [ForeignKey("Cuatrimestre")]
        [Required]
        [Range(0, int.MaxValue)]
        public int CuatrimestreId { get; set; }
        public Cuatrimestre Cuatrimestre { get; set; }

    }
}
