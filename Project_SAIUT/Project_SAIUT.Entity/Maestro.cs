using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required(ErrorMessage = "El campo App es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo App Solo permite 50 Caracteres")]
        [DataType(DataType.Text, ErrorMessage = "El campo App solo permite texto")]
        public string App { get; set; }

        [Required(ErrorMessage = "El campo Apm es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo Apm solo permite 50 caracteres.")]
        [DataType(DataType.Text, ErrorMessage = "El campo Apm solo permite texto")]
        public string Apm { get; set; }

        [ForeignKey("Tipo_Usuario")]
        [Required]
        [Range(0, int.MaxValue)]
        public int Tipo_UsuarioId { get; set; }
        public Tipo_Usuario Tipo_Usuario { get; set; }

    }
}
