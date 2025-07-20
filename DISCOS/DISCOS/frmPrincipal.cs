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
            DiscoNegocio negocio = new DiscoNegocio();  
            Discos = negocio.Listar();
            dgvDiscos.DataSource = Discos;
            dgvDiscos.Columns["urlimagentapa"].Visible = false;
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
            frmAltaDisco PokeAlta = new frmAltaDisco();
            PokeAlta.ShowDialog();
        }
    }
}
