using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Grupo
    {

        [Key]
        public int Id { get; set; }

        public int Grado { get; set; }

        public string _Grupo { get; set; }

        public ICollection<Alumno> Alumnos { get; set; }

        private readonly static string ConnectionString = "Data Source=(local);Initial Catalog=Saiut;Integrated Security=True";

        public static DataTable ListadeGrupos()
        {

            DataTable dt = new DataTable();

            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {

                try
                {

                    conn.Open();

                    string sql = "select CONCAT(Grado, '° ', _Grupo) as Grupos, Id from Grupo";

                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            da.Fill(dt);

                        }

                    }

                    conn.Close();

                    return dt;


                }
                catch(Exception ex)
                {

                    if(conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    return dt;

                }

            }

        }

        public static List<Grupo> GetGrupos()
        {

            DataTable dt = new DataTable();
            List<Grupo> lst = new List<Grupo>();
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {

                try
                {

                    conn.Open();

                    string sql = "select *from grupo";

                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            da.Fill(dt);

                        }

                    }

                    for(int i = 0; i < dt.Rows.Count; i++)
                    {

                        Grupo g = new Grupo();
                        g.Grado = Convert.ToInt32(dt.Rows[i]["Grado"].ToString());
                        g._Grupo = dt.Rows[i]["_Grupo"].ToString();

                        lst.Add(g);

                    }

                    conn.Close();

                    return lst;

                }
                catch(Exception ex)
                {

                    if(conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    return lst;

                }

            }

        }


    }
}
