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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Album seleccionado = (Album)dgvAlbumes.CurrentRow.DataBoundItem;
            frmAgregarAlbum frmModificarAlbum = new frmAgregarAlbum(seleccionado);
            frmModificarAlbum.ShowDialog();
            Cargar();
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Respuesta = MessageBox.Show("Are you sure you want to delete it?", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(Respuesta == DialogResult.Yes)
                {
                    Album seleccionado = (Album)dgvAlbumes.CurrentRow.DataBoundItem;
                    AlbumNegocio negocio = new AlbumNegocio();
                    negocio.Eliminar(seleccionado.Id);
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
