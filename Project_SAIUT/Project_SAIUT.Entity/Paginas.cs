using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SAIUT.Entity
{
    public class Paginas
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string URL { get; set; }

        public string icon { get; set; }

        private readonly static string ConnectionString = "Data Source=(local);Initial Catalog=Saiut;Integrated Security=True";

        public static List<Paginas> GetPaginas(int idPerfil)
        {

            DataTable dt = new DataTable();

            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {

                try
                {

                    string SQL = "select p.Nombre, p.URL, p.Icon from Paginas p inner join Paginas_Perfiles pp on p.Id = pp.Id_Pagina where pp.Id_Perfil = @IdPerfil";

                    using(SqlCommand cmd = new SqlCommand(SQL, conn))
                    {

                        cmd.Parameters.AddWithValue("@IdPerfil", idPerfil);

                        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            da.Fill(dt);

                        }

                    }

                    List<Paginas> lst = new List<Paginas>();
                    lst = (from DataRow dr in dt.Rows
                           select new Paginas()
                           {
                               Nombre = dr["Nombre"].ToString(),
                               URL = dr["URL"].ToString(),
                               icon = dr["Icon"].ToString()

                           }).ToList();

                    return lst;

                }
                catch(Exception ex)
                {

                    Console.WriteLine(ex.Message.ToString());

                    if(conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    return null;

                }

            }

        }

    }
}
