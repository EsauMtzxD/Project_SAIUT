using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        public string Grupo { get; set; }
        public string Grado { get; set; }
        public string Carrera { get; set; }

        public ICollection<Alumno> Alumnos { get; set; }
        public ICollection<Maestros> Maestros { get; set; }

        private readonly static string ConnectionString = "Data Source=(local);Initial Catalog=Saiut;Integrated Security=True";

        public static DataTable GetUsuarioByUsr(string usr)
        {

            DataTable dt = new DataTable();

            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {

                try
                {

                    conn.Open();

                    string sql = "select *from usuarios where login = @usr";
                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@usr", usr);

                        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                    }

                    return (dt != null && dt.Rows.Count > 0) ? dt : null;

                }
                catch(Exception ex)
                {

                    if(conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    return null;

                }

            }

        }

        public static DataTable GetUsuario(string usr, string pass)
        {

            DataTable dt = new DataTable();

            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {

                try
                {
                    conn.Open();

                    string SQL = "select *from usuarios where login = @usr and password = @pass";
                    using (SqlCommand cmd = new SqlCommand(SQL, conn))
                    {

                        cmd.Parameters.AddWithValue("@usr", usr);
                        cmd.Parameters.AddWithValue("@pass", pass);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                    }
                                        
                    conn.Close();

                    return dt;

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());

                    if(conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    return null;

                }

            }

        }

        public static int GetPerfil(string Usr)
        {

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {

                try
                {

                    conn.Open();

                    string sql = "select *from usuarios where login = @usr";
                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@usr", Usr);

                        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            da.Fill(dt);

                        }

                    }

                    conn.Close();

                    int id = 0;
                    foreach(DataRow dr in dt.Rows)
                    {

                        id = Convert.ToInt32(dr["Id_Perfil"].ToString());

                    }

                    return id;

                }
                catch(Exception ex)
                {

                    Console.Write(ex.Message.ToString());

                    if(conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    return 0;

                }

            }

        }

        public static Usuarios GetDatUsuario(string usr)
        {

            Usuarios u = new Usuarios();
            SqlDataReader _reader;
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {

                conn.Open();

                try
                {

                    string sql = "select CONCAT(u.Nombre, ' ', u.App, ' ', u.Apm) as Nombre, u.Curp, g.Grado, " +
                                 " g._Grupo, c.descripcion as Carrera " + 
                                 "from Usuarios u inner join Alumno a on u.Id = a.Id_Usario " + 
                                 "inner join Grupo g on g.Id = a.Id_Grupo " +
                                 "inner join Carrera c on c.Id_Carrera = a.Id_Carrera where u.login = @usr";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.Parameters.Add(new SqlParameter("@usr", usr));

                        _reader = cmd.ExecuteReader();

                        while (_reader.Read())
                        {
                            u.Nombre = _reader["Nombre"].ToString();
                            u.Curp = _reader["Curp"].ToString();
                            u.Grado = _reader["Grado"].ToString();
                            u.Grupo = _reader["_Grupo"].ToString();
                            u.Carrera = _reader["Carrera"].ToString();

                        }

                    }

                    conn.Close();

                    return u;

                }
                catch(Exception ex)
                {

                    Console.WriteLine(ex.Message.ToString());
                    if(conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    return null;

                }

            }

        }

        public static Usuarios GetMaestro(string usr)
        {

            Usuarios u = new Usuarios();
            SqlDataReader _reader;
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {

                try
                {

                    conn.Open();

                    string sql = "select CONCAT(u.Nombre, ' ', u.App, ' ', u.Apm) as Nombre, u.Curp, c.descripcion" +
                                 "from Usuarios u inner" +
                                 "join Maestros m on u.Id = m.Id_Usuario" +
                                 "inner join Carrera c on c.Id_Carrera = m.Id_Carrera where u.login = @usr";

                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@usr", usr);

                        _reader = cmd.ExecuteReader();

                        while (_reader.Read())
                        {

                            u.Nombre = _reader["Nombre"].ToString();
                            u.Curp = _reader["Curp"].ToString();
                            u.Carrera = _reader["descripcion"].ToString();

                        }

                    }

                    conn.Close();

                    return u;

                }
                catch (Exception ex)
                {

                    if(conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    return null;

                }

            }

        }

        public static DataTable GetCalificaciones(int id, string cuatri)
        {



        }

    }
}
