using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Grupo
    {

        [Key]
        public int Id { get; set; }

        public int Grado { get; set; }

        public string _Grupo { get; set; }

        public ICollection<Alumno> Alumnos { get; set; }

    }
}
