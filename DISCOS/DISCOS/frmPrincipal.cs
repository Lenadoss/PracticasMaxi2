using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;

namespace DISCOS
{
    public partial class frmPrincipal : Form
    {
        private List<Disco> Discos;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            DiscoNegocio negocio = new DiscoNegocio();
            try
            {
                Discos = negocio.Listar();
                dgvDiscos.DataSource = Discos;
                dgvDiscos.Columns["urlimagentapa"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Disco DiscoSeleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            CargarImagen(DiscoSeleccionado.UrlImagenTapa);
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                pbxDiscos.Load(imagen);
            }
            catch (Exception)
            {
                pbxDiscos.Load("https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAltaDisco DiscoAlta = new frmAltaDisco();
            DiscoAlta.ShowDialog();
            Cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            frmAltaDisco DiscoModificar = new frmAltaDisco(seleccionado);
            DiscoModificar.ShowDialog();
            Cargar();
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar(bool logico = false)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("Are you sure you want to delete it?", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                    DiscoNegocio negocio = new DiscoNegocio();
                    if (logico)
                        negocio.EliminarLogico(seleccionado.Id);
                    else
                        negocio.Eliminar(seleccionado.Id);
                    Cargar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            Eliminar(true);
        }
    }
}
