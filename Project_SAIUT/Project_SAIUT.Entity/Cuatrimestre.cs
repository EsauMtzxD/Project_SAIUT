using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Cuatrimestre
    {

        [Key]
        public int Id { get; set; }

        public string _Cuatrimestre { get; set; }

        public virtual ICollection<Alumno_Cuatrimestre> Alumno_Cuatrimestres { get; set; }

    }
}
