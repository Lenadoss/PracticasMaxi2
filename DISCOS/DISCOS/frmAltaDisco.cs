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
using System.Configuration;
using System.IO;

namespace DISCOS
{
    public partial class frmAltaDisco : Form
    {
        private Disco disco = null;
        private OpenFileDialog archivo = null;
        public frmAltaDisco()
        {
            InitializeComponent();
        }
        public frmAltaDisco(Disco disco)
        {
            InitializeComponent();
            this.disco = disco;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(disco == null)
                    disco = new Disco();
                disco.Titulo = txtTitulo.Text;
                disco.FechaLanzamiento = dtpFecha.Value;
                disco.CantidadCanciones = int.Parse(txtCantidad.Text);
                disco.UrlImagenTapa = txtUrlImagenTapa.Text;
                disco.Estilo = (Estilo)cboxEstilo.SelectedItem;
                disco.Edicion = (Edicion)cboxEdicion.SelectedItem;
                DiscoNegocio discoNegocio = new DiscoNegocio();

                if(disco.Id == 0)
                {
                    discoNegocio.Agregar(disco);
                    MessageBox.Show("Disco agregado correctamente!");
                }
                else
                {
                    discoNegocio.Modificar(disco);
                    MessageBox.Show("Disco modificado correctamente!");
                }

                if (archivo != null && !(txtUrlImagenTapa.Text.ToUpper().Contains("HTTP")))
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);

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
                cboxEdicion.ValueMember = "Id";
                cboxEdicion.DisplayMember = "Descripcion";
                cboxEstilo.DataSource = estiloNegocio.listar();
                cboxEstilo.ValueMember = "Id";
                cboxEstilo.DisplayMember = "Descripcion";

                if(disco != null)
                {
                    txtTitulo.Text = disco.Titulo;
                    dtpFecha.Value = disco.FechaLanzamiento;
                    txtCantidad.Text = disco.CantidadCanciones.ToString();
                    txtUrlImagenTapa.Text = disco.UrlImagenTapa;
                    cboxEstilo.SelectedValue = disco.Estilo.Id;
                    cboxEdicion.SelectedValue = disco.Edicion.Id;
                    CargarImagen(txtUrlImagenTapa.Text);
                    Text = "Modificar Disco";
                    btnAgregar.Text = "Modificar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImagenTapa_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtUrlImagenTapa.Text);
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                pbxUrlImagenTapa.Load(imagen);
            }
            catch (Exception)
            {
                pbxUrlImagenTapa.Load("https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png");
            }
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                archivo = new OpenFileDialog();
                archivo.Filter = "jpg|*.jpg;|png|*.png;|jpeg Image|*.jpeg";
                if(archivo.ShowDialog() == DialogResult.OK)
                {
                    txtUrlImagenTapa.Text = archivo.FileName;
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
