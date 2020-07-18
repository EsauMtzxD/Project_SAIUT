using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Perfiles
    {

        [Key]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Perfil { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
