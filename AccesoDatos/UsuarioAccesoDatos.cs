﻿using Org.BouncyCastle.Crypto.Prng.Drbg;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class UsuarioAccesoDatos
    {
        private Conexion _conexion;
        private const string ConnectionStringName = "MySQLConexion";
        public UsuarioAccesoDatos()
        {
            _conexion=new Conexion(ConnectionStringName);
        }

        public DataSet ValidarCredenciales(string nombreUsuario,string clave)
        {
            string query = $"SELECT\r\n    u.Id AS ID_Usuario,\r\n    u.NombreUsuario,\r\n    u.Email,\r\n    m.nombre AS Nombre_Modulo,\r\n    up.permiso_escritura AS Permiso_Escritura,\r\n    up.permiso_leer_abrir AS Permiso_Leer_Abrir\r\nFROM\r\n    usuarios u\r\nJOIN\r\n    usuarios_permisos up ON u.Id = up.usuario_id\r\nJOIN\r\n    modulos m ON up.modulo_id = m.id\r\nWHERE\r\n    u.NombreUsuario = '{nombreUsuario}' AND u.Clave = '{clave}'\r\nORDER BY\r\n    u.NombreUsuario, m.nombre;";
            return _conexion.Consulta(query,"usuarios");
        }

    }
}
