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
    public partial class FrmUsuarios : Form
    {
        private Usuario _usuario;
private UsuarioManejador _usuarioManejador;

        public FrmUsuarios(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            _usuarioManejador = new UsuarioManejador();
        }

        private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarUsuario.Text.Trim();
            DtgDatos.DataSource = _usuarioManejador.BuscarUsuarios(filtro);
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            BtnNuevoUsuario.Enabled = _usuario.Permisos.Exists(p => p.NombreModulo.Equals("usuarios", StringComparison.OrdinalIgnoreCase) && p.PermisoEscritura);

            if (!DtgDatos.Columns.Contains("AsignarPermiso"))
            {
                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn
                {
                    Name = "AsignarPermiso",
                    HeaderText = "Asignar Permisos",
                    Text = "Permisos",
                    UseColumnTextForButtonValue = true
                };
                DtgDatos.Columns.Add(btnColumn);
            }
            DtgDatos.AllowUserToAddRows = false;
        }
        private void CargarUsuarios()
        {
            DataTable dt = _usuarioManejador.ObtenerUsuarios();
            DtgDatos.DataSource = dt;

            // Ocultar columna Id
            if (DtgDatos.Columns.Contains("Id"))
                DtgDatos.Columns["Id"].Visible = false;
        }

        private void BtnNuevoUsuario_Click(object sender, EventArgs e)
        {
            AgregarUsuario frm = new AgregarUsuario();
            if (frm.ShowDialog() == DialogResult.OK)
                CargarUsuarios();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

            if (DtgDatos.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(DtgDatos.SelectedRows[0].Cells["Id"].Value);

                // Protege al admin
                if (id == 1)
                {
                    MessageBox.Show("No se puede eliminar al usuario admin.");
                    return;
                }

                MessageBox.Show(_usuarioManejador.EliminarUsuario(id));
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para eliminar.");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DtgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DtgDatos.Columns[e.ColumnIndex].Name == "AsignarPermiso" && e.RowIndex >= 0)
            {
                int usuarioId = Convert.ToInt32(DtgDatos.Rows[e.RowIndex].Cells["Id"].Value);
                string nombre = DtgDatos.Rows[e.RowIndex].Cells["NombreUsuario"].Value.ToString();

                frmPermisos frm = new frmPermisos(usuarioId, nombre);
                if (frm.ShowDialog() == DialogResult.OK)
                    MessageBox.Show("Permisos actualizados correctamente");
            }
        }
    }
}
