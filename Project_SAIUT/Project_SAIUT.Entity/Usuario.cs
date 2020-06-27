using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Usuario
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Login es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo Login solo permite 50 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "El campo Password es Obligatorio")]
        [StringLength(50)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        public string Password { get; set; }

        [ForeignKey("Tipo_Usuario")]
        [Required]
        [Range(0, int.MaxValue)]
        public int Tipo_Usuario { get; set; }
        public Tipo_Usuario Tipo_UsuarioId { get; set; }

    }
}
