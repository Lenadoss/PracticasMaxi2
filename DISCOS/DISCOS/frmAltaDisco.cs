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
                DiscoNegocio discoNegocio = new DiscoNegocio();
                discoNegocio.Agregar(nuevoDisco);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
