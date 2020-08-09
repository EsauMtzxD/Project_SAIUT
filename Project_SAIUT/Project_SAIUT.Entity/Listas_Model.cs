using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Listas_Model
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string App { get; set; }
        public string Apm { get; set; }

        private readonly static string ConnectionString = "Data Source=(local);Initial Catalog=Saiut;Integrated Security=True";

        public static List<Listas_Model> GetGrupoListas(int grado)
        {

            DataTable dt = new DataTable();
            List<Listas_Model> lst = new List<Listas_Model>();

            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {

                try
                {

                    conn.Open();

                    string sql = "select u.Nombre, u.App, u.Apm from Usuarios u join Alumno a on u.Id = a.Id_Usario join Grupo g on a.Id_Grupo = g.Id where Grado = @g";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@g", grado);

                        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            da.Fill(dt);

                        }

                    }

                    for(int i = 0; i < dt.Rows.Count; i++)
                    {

                        Listas_Model l = new Listas_Model();
                        l.Nombre = dt.Rows[i]["Nombre"].ToString();
                        l.App = dt.Rows[i]["App"].ToString();
                        l.Apm = dt.Rows[i]["Apm"].ToString();
                        lst.Add(l);

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
