using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Alumno
    {

        [Key]
        public int Id { get; set; }

        public string Matricula { get; set; }

        [ForeignKey("Usuarios")]
        public int Id_Usario { get; set; }
        public Usuarios Usuarios { get; set; }

        [ForeignKey("Grupo")]
        public int Id_Grupo { get; set; }
        public Grupo Grupo { get; set; }

        [ForeignKey("Carrera")]
        public int Id_Carrera { get; set; }
        public Carrera Carrera { get; set; }

        public ICollection<Calificaciones> Calificaciones { get; set; }
        public ICollection<Colegiatura> Colegiaturas { get; set; }

    }
}
