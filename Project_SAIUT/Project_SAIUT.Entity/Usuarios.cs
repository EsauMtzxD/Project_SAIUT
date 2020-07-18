using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Usuarios
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string App { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Apm { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string login { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Curp { get; set; }

        [ForeignKey("Perfiles")]
        public int Id_Perfil { get; set; }
        public Perfiles Perfiles { get; set; }

        public ICollection<Alumno> Alumnos { get; set; }
        public ICollection<Usuarios> _Usuarios { get; set; }

    }
}
