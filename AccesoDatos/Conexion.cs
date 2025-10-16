using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class Conexion
    {
        private string _connectionString;
        public Conexion(string nombreCadenaConexion)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[nombreCadenaConexion];
            if(settings == null||string.IsNullOrEmpty(settings.ConnectionString))
            {
                throw new InvalidOperationException("No se encontro la cadena de conexion");
            }
            _connectionString=settings.ConnectionString;
        }

        public string Comando(string q)
        {
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {
                try
                {
                    using (MySqlCommand i = new MySqlCommand(q, con))
                    {
                        con.Open();
                        int filaAfectadas=i.ExecuteNonQuery();
                        con.Close();
                        return $"Correcto, filas afectadas {filaAfectadas}";
                    }
                }
                catch(Exception ex)
                {
                    return $"Error en comando: {ex.Message}";
                }
            }
        }

        public DataSet Consulta(string q, string tabla)
        {
            DataSet ds=new DataSet();
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {
                try
                {
                    using (MySqlDataAdapter da=new MySqlDataAdapter(q,con))
                    {
                        con.Open();
                        da.Fill(ds, tabla);
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error de consulta:{ex.Message}");
                }
            }
            return ds;
        }
    }
}
