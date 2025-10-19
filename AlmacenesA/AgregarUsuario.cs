using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlmacenesA
{
    public partial class AgregarUsuario : Form
    {
        private Usuario _usuarioActual;
        private UsuarioManejador _usuarioManejador;

        public AgregarUsuario()
        {
            InitializeComponent();
            _usuarioManejador = new UsuarioManejador();
        }

        private void AgregarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = TxtNombre.Text.Trim();
            string email = TxtEmail.Text.Trim();
            string clave = TxtClave.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Ingrese nombre y clave.");
                return;
            }

            MessageBox.Show(_usuarioManejador.CrearUsuario(nombre, email, clave));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
