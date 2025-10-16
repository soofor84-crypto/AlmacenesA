using Entidades;
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
    public partial class MenuPrincipal : Form
    {
        private Usuario _usuario;
        public MenuPrincipal(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            LblUsuario.Text = _usuario.NombreUsuario;
            productoToolStripMenuItem.Enabled = false;
            usuariosToolStripMenuItem.Enabled = false;
            salirToolStripMenuItem.Enabled = true;

            foreach (var permiso in _usuario.Permisos)
            {
                if (permiso.NombreModulo.Equals("productos", StringComparison.OrdinalIgnoreCase))
                {
                    productoToolStripMenuItem.Enabled = permiso.PermisoLeerAbrir;
                }
                if (permiso.NombreModulo.Equals("usuarios", StringComparison.OrdinalIgnoreCase))
                {
                    usuariosToolStripMenuItem.Enabled = permiso.PermisoLeerAbrir;
                }
            }

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Entro a productos");
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Entro a usuarios");
        }
    }
}
