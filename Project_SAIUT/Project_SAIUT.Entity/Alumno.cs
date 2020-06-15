using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Alumno
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [StringLength(150, ErrorMessage = "El campo nombre solo permite 150 caracteres")]
        [DataType(DataType.Text, ErrorMessage = "El campo Nombre solo permite texto")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Fecha_Nacimiento es obligatorio")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha_Nacimiento { get; set; }

        [StringLength(20)]
        public string Estado_Civil { get; set; }

        [Required(ErrorMessage = "El campo RFC es obligatorio")]
        [StringLength(25, ErrorMessage = "El campo RFC solo permite 25 caracteres")]
        public string RFC { get; set; }

        [Required(ErrorMessage = "El campo CURP es obligatorio")]
        [StringLength(25, ErrorMessage = "El campo CURP solo permite 25 caracteres")]
        public string CURP { get; set; }

        [Required(ErrorMessage = "El campo Turno es Obligatorio")]
        [StringLength(1)]
        public string Turno { get; set; }

        //Id_Adeudo?



    }
}
