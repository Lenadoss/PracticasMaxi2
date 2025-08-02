using dominioo;
using negocioo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace presentacion
{
    public partial class frmAgregar : Form
    {
        private Pelicula pelicula = null;
        private OpenFileDialog archivo = null;
        public frmAgregar()
        {
            InitializeComponent();
        }

        public frmAgregar(Pelicula pelicula)
        {
            InitializeComponent();
            this.pelicula = pelicula;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            NegocioPelicula negocio = new NegocioPelicula();
            try
            {
                if(pelicula == null)// if it is null it means that it wasnt passed as a parameter, so you create the instance with the same name of the private atribute so you dont have to do all that twice, at the same time it is important to clarify that you need to instance pelicula because if you dont you will be trying to assign values to the properties of variable that is null, you need to instance it to do that.
                    pelicula = new Pelicula();
                
                pelicula.Titulo = txtTitulo.Text;
                pelicula.FechaLanzamiento = dtpFecha.Value;
                pelicula.UrlImagen = txtUrl.Text;
                pelicula.Genero = (Genero)cbboxGenero.SelectedItem;
                pelicula.Edicion = (Edicion)(cbboxEdicion.SelectedItem);
                
                if(pelicula.Id == 0) //If it is equal to 0 it means that it doesnt exist in the db, so you assume that you want to add it up to the database.
                {
                    negocio.Agregar(pelicula);
                    MessageBox.Show("Pelicula agregada exitosamente!");
                }
                else //if it is not equal it means that you want to modify something that already exists.
                {
                    negocio.Modificar(pelicula);
                    MessageBox.Show("Pelicula modificada exitosamente!");
                }

                if (archivo != null && !(txtUrl.Text.ToUpper().Contains("HTTP")))
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            NegocioGenero NegocioGenero = new NegocioGenero();
            NegocioEdicion NegocioEdicion = new NegocioEdicion();
            try
            {
                cbboxGenero.DataSource = NegocioGenero.listar();
                cbboxGenero.ValueMember = "Id";
                cbboxGenero.DisplayMember = "Descripcion";
                cbboxEdicion.DataSource = NegocioEdicion.listar();
                cbboxEdicion.ValueMember = "Id";
                cbboxEdicion.DisplayMember = "Descripcion";

                if (pelicula != null)
                {
                    Text = "Modificar Pelicula";
                    btnAgregar.Text = "Modificar";
                    txtTitulo.Text = pelicula.Titulo;
                    dtpFecha.Value = pelicula.FechaLanzamiento;
                    txtUrl.Text = pelicula.UrlImagen;
                    CargarImagen(pelicula.UrlImagen);
                    cbboxGenero.SelectedValue = pelicula.Genero.Id;
                    cbboxEdicion.SelectedValue = pelicula.Edicion.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtUrl.Text);
        }

        private void CargarImagen (string Imagen)
        {
            try
            {
                pcboxPelicula.Load(Imagen);
            }
            catch (Exception)
            {
                pcboxPelicula.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
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
