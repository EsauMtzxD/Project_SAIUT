using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Adeudo
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Cantidad es obligatorio")]
        [DataType(DataType.Currency)]
        public double Cantidad { get; set; }

        //Id_alumno

        //Id_escolar

    }
}
