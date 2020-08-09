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

        public string maestro { get; set; }
        public string materia { get; set; }
        public decimal calificaciones { get; set; }

    }
}
