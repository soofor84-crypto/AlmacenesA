using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Prng.Drbg;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class UsuarioAccesoDatos
    {
        public Conexion _conexion;
        private const string ConnectionStringName = "MySQLConexion";
        public DataSet ValidarCredenciales(string nombreUsuario, string clave)
        {
            string query = $@"
        SELECT 
            u.Id AS ID_Usuario,
            u.NombreUsuario,
            u.Email,
            m.nombre AS Nombre_Modulo,
            up.permiso_escritura AS Permiso_Escritura,
            up.permiso_leer_abrir AS Permiso_Leer_Abrir
        FROM 
            usuarios u
        LEFT JOIN 
            usuarios_permisos up ON u.Id = up.usuario_id
        LEFT JOIN 
            modulos m ON up.modulo_id = m.id
        WHERE 
            u.NombreUsuario = '{nombreUsuario}' AND u.Clave = '{clave}'
        ORDER BY 
            u.NombreUsuario, m.nombre;
    ";

            return _conexion.Consulta(query, "usuarios");
        }

        public UsuarioAccesoDatos()
        {
            _conexion = new Conexion(ConnectionStringName);
        }

        public DataSet ListarUsuarios()
        {
            string query = "SELECT Id, NombreUsuario, Email FROM usuarios";
            return _conexion.Consulta(query, "usuarios");
        }

        public DataSet BuscarUsuarios(string filtro)
        {
            string query = $"SELECT Id, NombreUsuario, Email FROM usuarios WHERE NombreUsuario LIKE '%{filtro}%'";
            return _conexion.Consulta(query, "usuarios");
        }

        public int AgregarUsuario(string nombre, string email, string clave)
        {
            string query = $"INSERT INTO usuarios(NombreUsuario, Email, Clave) VALUES('{nombre}','{email}','{clave}')";
            string connectionString = ConfigurationManager.ConnectionStrings["MySQLConexion"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                    return (int)cmd.LastInsertedId; // Devuelve el ID autoincremental
                }
            }
        }

        public string EliminarUsuario(int idUsuario)
        {
            try
            {
                // Primero eliminar permisos asociados
                string queryPermisos = $"DELETE FROM usuarios_permisos WHERE usuario_id={idUsuario}";
                _conexion.Comando(queryPermisos);

                // Luego eliminar el usuario
                string queryUsuario = $"DELETE FROM usuarios WHERE Id={idUsuario}";
                return _conexion.Comando(queryUsuario);
            }
            catch (Exception ex)
            {
                return $"Error al eliminar usuario: {ex.Message}";
            }
        }

        public int ObtenerModuloId(string modulo)
        {
            string query = $"SELECT id FROM modulos WHERE nombre='{modulo}'";
            DataSet ds = _conexion.Consulta(query, "modulos");
            if (ds.Tables["modulos"].Rows.Count > 0)
                return Convert.ToInt32(ds.Tables["modulos"].Rows[0]["id"]);
            return 0;
        }

        public void AsignarPermiso(int usuarioId, int moduloId, bool escritura, bool leer)
        {
            string query = $"INSERT INTO usuarios_permisos(usuario_id, modulo_id, permiso_escritura, permiso_leer_abrir) VALUES({usuarioId},{moduloId},{(escritura ? 1 : 0)},{(leer ? 1 : 0)})";
            _conexion.Comando(query);
        }

        public void ActualizarPermiso(int usuarioId, int moduloId, bool escritura, bool leer)
        {
            string query = $"UPDATE usuarios_permisos SET permiso_escritura={(escritura ? 1 : 0)}, permiso_leer_abrir={(leer ? 1 : 0)} WHERE usuario_id={usuarioId} AND modulo_id={moduloId}";
            _conexion.Comando(query);
        }

        public DataRow ObtenerPermiso(int usuarioId, int moduloId)
        {
            string query = $"SELECT * FROM usuarios_permisos WHERE usuario_id={usuarioId} AND modulo_id={moduloId}";
            DataSet ds = _conexion.Consulta(query, "usuarios_permisos");
            if (ds.Tables["usuarios_permisos"].Rows.Count > 0)
                return ds.Tables["usuarios_permisos"].Rows[0];
            return null;
        }
    }
}
