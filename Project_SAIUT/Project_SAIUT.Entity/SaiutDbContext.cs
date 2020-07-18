using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class SaiutDbContext : DbContext
    {

        public SaiutDbContext() : base(SaiutDbContext.getConnectionStringName()) { }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Calificaciones> Calificaciones { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Colegiatura> Colegiaturas { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Maestros> Maestros { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Perfiles> Perfiles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }

        private static string getConnectionStringName()
        {
            ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
            String CONNECTIONSTRING = String.Empty;

            if (connections.Count != 0)
            {
                foreach (ConnectionStringSettings connection in connections)
                {
                    CONNECTIONSTRING = connection.Name;
                }
            }

            return CONNECTIONSTRING;
        }

    }
}
