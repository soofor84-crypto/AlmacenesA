using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using Org.BouncyCastle.Bcpg;

namespace LogicaNegocio
{
    public class UsuarioManejador
    {
        private UsuarioAccesoDatos _usuarioAccesoDatos;

        public UsuarioManejador()
        {
            _usuarioAccesoDatos = new UsuarioAccesoDatos();

        }

        public DataTable ObtenerUsuarios()
        {
            return _usuarioAccesoDatos.ListarUsuarios().Tables["usuarios"];
        }

        public DataTable BuscarUsuarios(string filtro)
        {
            return _usuarioAccesoDatos.BuscarUsuarios(filtro).Tables["usuarios"];
        }

        public string CrearUsuario(string nombre, string email, string clave)
        {
            int usuarioId = _usuarioAccesoDatos.AgregarUsuario(nombre, email, clave);
            return $"Usuario creado correctamente. ID: {usuarioId}";
        }

        public string EliminarUsuario(int idUsuario)
        {
            return _usuarioAccesoDatos.EliminarUsuario(idUsuario);
        }

        public void GuardarPermiso(int usuarioId, string modulo, bool escritura, bool leer)
        {
            int moduloId = _usuarioAccesoDatos.ObtenerModuloId(modulo);
            if (moduloId <= 0) return;

            var permisoExistente = _usuarioAccesoDatos.ObtenerPermiso(usuarioId, moduloId);
            if (permisoExistente != null)
                _usuarioAccesoDatos.ActualizarPermiso(usuarioId, moduloId, escritura, leer);
            else
                _usuarioAccesoDatos.AsignarPermiso(usuarioId, moduloId, escritura, leer);
        }
        // Valida el login y carga los permisos del usuario
        public (bool EsValido, string Mensaje, Usuario usuarioEncontrado) ValidarLogin(string usuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
                return (false, "Por favor, ingrese usuario y contraseña", null);

            DataSet ds = _usuarioAccesoDatos.ValidarCredenciales(usuario, clave);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                Usuario user = new Usuario();

                foreach (DataRow row in dt.Rows)
                {
                    if (user.Id == 0)
                    {
                        user.Id = Convert.ToInt32(row["ID_Usuario"]);
                        user.NombreUsuario = row["NombreUsuario"].ToString();
                        user.Email = row["Email"].ToString();
                    }

                    // Cargar permisos
                    Permisos permiso = new Permisos
                    {
                        NombreModulo = row["Nombre_Modulo"].ToString(),
                        PermisoEscritura = Convert.ToBoolean(row["Permiso_Escritura"]),
                        PermisoLeerAbrir = Convert.ToBoolean(row["Permiso_Leer_Abrir"])
                    };
                    user.Permisos.Add(permiso);
                }

                return (true, "Inicio de sesión exitoso", user);
            }

            return (false, "Credenciales incorrectas", null);
        }
    }
}
