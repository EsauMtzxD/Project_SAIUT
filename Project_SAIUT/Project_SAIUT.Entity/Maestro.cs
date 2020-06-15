using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Maestro
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [StringLength(150, ErrorMessage = "El campo Nombre solo tiene 150 caracteres")]
        [DataType(DataType.Text, ErrorMessage = "El campo Nombre solo permite texto")]
        public string Nombre { get; set; }

    }
}
