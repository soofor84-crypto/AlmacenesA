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
    public partial class frmPermisos : Form
    {
        private int _usuarioId;
        private UsuarioManejador _usuarioManejador;
        public frmPermisos(int usuarioId, string nombre)
        {
           

            InitializeComponent();
            _usuarioId = usuarioId;
            // lblUsuario.Text = nombre;
            _usuarioManejador = new UsuarioManejador();
            CmbAccesos.SelectedIndex = 0;
        }

        private void frmPermisos_Load(object sender, EventArgs e)
        {

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string modulo = CmbAccesos.SelectedItem.ToString();
            bool escritura = rbtEscritura.Checked;
            bool leer = rbtLeerAbrir.Checked;

            _usuarioManejador.GuardarPermiso(_usuarioId, modulo, escritura, leer);
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
