using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Carrera
    {

        [Key]
        public int Id_Carrera { get; set; }

        public string descripcion { get; set; }

        public ICollection<Alumno> Alumnos { get; set; }
        public ICollection<Maestros> Maestros { get; set; }

    }
}
