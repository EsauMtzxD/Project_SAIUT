using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Maestros
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuarios")]
        public int Id_Usuario { get; set; }
        public Usuarios Usuarios { get; set; }

        [ForeignKey("Carrera")]
        public int Id_Carrera { get; set; }
        public Carrera Carrera { get; set; }

        public ICollection<Materia> Materias { get; set; }

    }
}
