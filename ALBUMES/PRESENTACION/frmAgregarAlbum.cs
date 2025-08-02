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
using System.IO;
using System.Configuration;

namespace PRESENTACION
{
    public partial class frmAgregarAlbum : Form
    {
        private Album album = null;
        private OpenFileDialog archivo = null;
        public frmAgregarAlbum()
        {
            InitializeComponent();
        }
        public frmAgregarAlbum(Album album)
        {
            InitializeComponent();
            this.album = album;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AlbumNegocio negocio = new AlbumNegocio();
            try
            {
                if (album == null)
                    album = new Album();
                album.Titulo = txtTitulo.Text;
                album.FechaLanzamiento = dtpFechaLanzamiento.Value;
                album.UrlImagenCover = txtUrl.Text;
                album.Genero = (Genero)cboxGenero.SelectedItem;
                album.Edicion = (Edicion)cboxEdicion.SelectedItem;
                
                if(album.Id == 0)
                {
                    negocio.Agregar(album);
                    MessageBox.Show("Album agregado exitosamente");
                }
                else
                {
                    negocio.Modificar(album);
                    MessageBox.Show("Album Modificado exitosamente");
                }
                if (archivo != null && !(txtUrl.Text.ToUpper().Contains("HTTP")))
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
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
                cboxGenero.ValueMember = "Id";
                cboxGenero.DisplayMember = "Descripcion";

                cboxEdicion.DataSource = edicionnegocio.listar();
                cboxEdicion.ValueMember = "Id";
                cboxEdicion.DisplayMember = "Descripcion";

                if(album!=null)
                {
                    txtTitulo.Text = album.Titulo;
                    dtpFechaLanzamiento.Value = album.FechaLanzamiento;

                    txtUrl.Text = album.UrlImagenCover;
                    CargarImagen(album.UrlImagenCover);

                    cboxGenero.SelectedValue = album.Genero.Id;
                    cboxEdicion.SelectedValue = album.Edicion.Id;

                    Text = "Modificar Album";
                    btnAgregar.Text = "Modificar";
                }
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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                archivo = new OpenFileDialog();
                archivo.Filter = "jpg|*.jpg;|png|*.png;|jpeg Image|*.jpeg";
                if(archivo.ShowDialog() == DialogResult.OK)
                {
                    txtUrl.Text = archivo.FileName;
                    CargarImagen(archivo.FileName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
