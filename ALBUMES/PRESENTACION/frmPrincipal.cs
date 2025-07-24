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

namespace PRESENTACION
{
    public partial class frmPrincipal : Form
    {
        private List<Album> listaAlbumes;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarAlbum frmAgregarAlbum = new frmAgregarAlbum();
            frmAgregarAlbum.ShowDialog();
            Cargar();
        }

        private void dgvAlbumes_SelectionChanged(object sender, EventArgs e)
        {
            Album seleccionado = (Album)dgvAlbumes.CurrentRow.DataBoundItem;
            string imagen = seleccionado.UrlImagenCover;
            CargarImagen(imagen);
        }

        private void Cargar()
        {
            AlbumNegocio negocio = new AlbumNegocio();
            try
            {
                listaAlbumes = negocio.listar();
                dgvAlbumes.DataSource = listaAlbumes;
                dgvAlbumes.Columns["UrlImagenCover"].Visible=false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                pbxAlbumes.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxAlbumes.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
