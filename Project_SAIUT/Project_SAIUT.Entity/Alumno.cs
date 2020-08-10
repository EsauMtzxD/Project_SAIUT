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
    public class Alumno
    {

        [Key]
        public int Id { get; set; }

        public string Matricula { get; set; }

        [ForeignKey("Usuarios")]
        public int Id_Usario { get; set; }
        public Usuarios Usuarios { get; set; }

        [ForeignKey("Grupo")]
        public int Id_Grupo { get; set; }
        public Grupo Grupo { get; set; }

        [ForeignKey("Carrera")]
        public int Id_Carrera { get; set; }
        public Carrera Carrera { get; set; }

        public ICollection<Calificaciones> Calificaciones { get; set; }
        public ICollection<Colegiatura> Colegiaturas { get; set; }

        private readonly static string ConnectionString = "Data Source=(local);Initial Catalog=Saiut;Integrated Security=True";

        public static int GetMatricula(int Id)
        {

            DataTable dt = new DataTable();

            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {

                try
                {

                    conn.Open();

                    string sql = "select matricula, cuatrimestre from alumno where Id = @id order by cuatrimestre desc";

                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@id", Id);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            da.Fill(dt);

                        }

                    }

                    conn.Close();

                    return (dt != null && dt.Rows.Count > 0) ? Convert.ToInt32(dt.Rows[0]["Matricula"].ToString()) : 0;

                }
                catch(Exception ex)
                {

                    if(conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    return 0;

                }

            }

        }

        public static int GetCuatri(int Id)
        {

            DataTable dt = new DataTable();

            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {

                try
                {

                    conn.Open();

                    string sql = "select matricula, cuatrimestre from alumno where Id = @id order by cuatrimestre desc";

                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@id", Id);

                        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            da.Fill(dt);

                        }

                    }

                    return (dt != null && dt.Rows.Count > 0) ? Convert.ToInt32(dt.Rows[0]["Cuatrimestre"].ToString()) : 0;

                }
                catch(Exception ex)
                {

                    if(conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    return 0;

                }

            }

        }

    }
}
