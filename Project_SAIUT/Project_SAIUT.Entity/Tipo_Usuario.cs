using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Tipo_Usuario
    {

        [Key]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        public string Tipo { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }

        public virtual ICollection<Maestro> Maestros { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}
