using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace DISCOS
{
    public partial class frmAltaDisco : Form
    {
        public frmAltaDisco()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Disco nuevoDisco = new Disco();
                nuevoDisco.Titulo = txtTitulo.Text;
                nuevoDisco.FechaLanzamiento = dtpFecha.Value;
                nuevoDisco.CantidadCanciones = int.Parse(txtCantidad.Text);
                nuevoDisco.Estilo = (Estilo)cboxEstilo.SelectedItem;
                nuevoDisco.Edicion = (Edicion)cboxEdicion.SelectedItem;
                DiscoNegocio discoNegocio = new DiscoNegocio();
                discoNegocio.Agregar(nuevoDisco);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaDisco_Load(object sender, EventArgs e)
        {
            EdicionNegocio edicionNegocio = new EdicionNegocio();
            EstiloNegocio estiloNegocio = new EstiloNegocio();
            try
            {
                cboxEdicion.DataSource = edicionNegocio.listar();
                cboxEstilo.DataSource = estiloNegocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
