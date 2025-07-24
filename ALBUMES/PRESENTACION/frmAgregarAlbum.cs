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
    public partial class frmAgregarAlbum : Form
    {
        public frmAgregarAlbum()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Album NuevoAlbum = new Album();
                NuevoAlbum.Titulo = txtTitulo.Text;
                NuevoAlbum.FechaLanzamiento = dtpFechaLanzamiento.Value;
                NuevoAlbum.UrlImagenCover = txtUrl.Text;
                NuevoAlbum.Genero = (Genero)cboxGenero.SelectedItem;
                NuevoAlbum.Edicion = (Edicion)cboxEdicion.SelectedItem;
                AlbumNegocio negocio = new AlbumNegocio();
                negocio.Agregar(NuevoAlbum);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAgregarAlbum_Load(object sender, EventArgs e)
        {
            GeneroNegocio generonegocio = new GeneroNegocio();
            EdicionNegocio edicionnegocio = new EdicionNegocio();

            try
            {
                cboxGenero.DataSource = generonegocio.listar();
                cboxEdicion.DataSource = edicionnegocio.listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtUrl.Text);
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                pbxCover.Load(imagen);
            }
            catch (Exception)
            {
                pbxCover.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }
    }
}
