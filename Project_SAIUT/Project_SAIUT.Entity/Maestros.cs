using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Maestros
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuarios")]
        public int Id_Usuario { get; set; }
        public Usuarios Usuarios { get; set; }

        [ForeignKey("Carrera")]
        public int Id_Carrera { get; set; }
        public Carrera Carrera { get; set; }

        public ICollection<Materia> Materias { get; set; }

        private readonly static string ConnectionString = "Data Source=(local);Initial Catalog=Saiut;Integrated Security=True";

        public static int SubirCalificaciones(string Materia, int cuatri, int Matricula, string Maestro, decimal calf)
        {

            int rowsAffected = 0;

            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {

                try
                {

                    conn.Open();

                    string sql = "insert into calf values(@maestro, @materia, @calf, @cuatri, @mat)";

                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@maestro", Maestro);
                        cmd.Parameters.AddWithValue("@materia", Materia);
                        cmd.Parameters.AddWithValue("@calf", calf);
                        cmd.Parameters.AddWithValue("@cuatri", cuatri);
                        cmd.Parameters.AddWithValue("@mat", Matricula);

                        rowsAffected = cmd.ExecuteNonQuery();

                    }

                    conn.Close();

                    return rowsAffected;

                }
                catch(Exception ex)
                {

                    if(conn.State == ConnectionState.Open)
                    {

                        conn.Close();

                    }

                    return rowsAffected;

                }

            }

        }

        public static string GetMateria(string login)
        {

            DataTable dt = new DataTable();

            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {

                try
                {

                    conn.Open();

                    string sql = " select CONCAT(u.Nombre, ' ', u.App, ' ', u.Apm) as Maestro, " +
                                 " ma.Descripcion as Materia from Usuarios u inner join Maestros m on u.Id = m.Id_Usuario  " +
                                 "inner join Materia ma on m.Id = ma.Id_Maestro where u.login = @login ";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@login", login);

                        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            da.Fill(dt);

                        }

                    }

                    conn.Close();

                    return (dt != null && dt.Rows.Count > 0) ? dt.Rows[0]["Materia"].ToString() : string.Empty;

                }
                catch(Exception ex)
                {

                    if(conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    return string.Empty;

                }

            }

        }

    }
}
