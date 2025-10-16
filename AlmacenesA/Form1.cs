using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;

namespace AlmacenesA
{
    public partial class Login : Form
    {
        private UsuarioManejador _usuarioManejador;
        public Login()
        {
            InitializeComponent();
            _usuarioManejador = new UsuarioManejador();
        }

        private void TxtSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string usuario=TxtUsuario.Text;
            string clave=TxtContrasena.Text;
            var resultado=_usuarioManejador.ValidarLogin(usuario, clave);
            if (resultado.EsValido)
            {
                MenuPrincipal menuP=new MenuPrincipal(resultado.usuarioEncontrado);
                menuP.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(resultado.Mensaje,"Error Login",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
