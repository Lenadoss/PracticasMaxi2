using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominioo;
using negocioo;
using helpers;

namespace presentacion
{
    public partial class frmPrincipal : Form
    {
        private List<Pelicula> listaPeliculas;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar Agregar = new frmAgregar();
            Agregar.ShowDialog();
            Cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Pelicula Seleccionado = (Pelicula)dgvPelicula.CurrentRow.DataBoundItem;
            frmAgregar Modificar = new frmAgregar(Seleccionado);
            Modificar.ShowDialog();
            Cargar();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Cargar();
            cbBoxCampo.Items.Add("Id");
            cbBoxCampo.Items.Add("Titulo");
            cbBoxCampo.Items.Add("Genero");
        }

        private void Cargar()
        {
            NegocioPelicula NegocioPelicula = new NegocioPelicula();
            listaPeliculas = NegocioPelicula.listar();
            dgvPelicula.DataSource = listaPeliculas;
            dgvPelicula.Columns["urlimagen"].Visible = false;
        }

        private void CargarImagen(string Imagen)
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

        private void dgvPelicula_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvPelicula.CurrentRow != null)
            {
                Pelicula Seleccionado = (Pelicula)dgvPelicula.CurrentRow.DataBoundItem;
                string Imagen = Seleccionado.UrlImagen;
                CargarImagen(Imagen);
            }
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
                    Pelicula seleccionado = (Pelicula)dgvPelicula.CurrentRow.DataBoundItem;
                    NegocioPelicula negocio = new NegocioPelicula();
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

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            List<Pelicula> listaFiltrada;
            try
            {
                if(filtro != "")
                {
                    listaFiltrada = listaPeliculas.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()) || x.Genero.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                }
                else
                {
                    listaFiltrada = listaPeliculas;
                }
                dgvPelicula.DataSource = null;
                dgvPelicula.DataSource = listaFiltrada;
                ocultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            try
            {
                dgvPelicula.Columns["urlimagen"].Visible = false;
                dgvPelicula.Columns["id"].Visible = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            List<Pelicula> listaFiltrada;
            try
            {
                if (filtro.Length > 2)
                {
                    listaFiltrada = listaPeliculas.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()) || x.Genero.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                }
                else
                {
                    listaFiltrada = listaPeliculas;
                }
                dgvPelicula.DataSource = null;
                dgvPelicula.DataSource = listaFiltrada;
                ocultarColumnas();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void cbBoxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = cbBoxCampo.SelectedItem.ToString();
                if(campo == "Id")
                {
                    cbBoxcriterio.Items.Clear();
                    cbBoxcriterio.Items.Add("Mayor que");
                    cbBoxcriterio.Items.Add("Menor que");
                    cbBoxcriterio.Items.Add("Igual que");
                }
                else
                {
                    cbBoxcriterio.Items.Clear();
                    cbBoxcriterio.Items.Add("Contiene");
                    cbBoxcriterio.Items.Add("Empieza con");
                    cbBoxcriterio.Items.Add("Termina con");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                string campo = cbBoxCampo.SelectedItem.ToString();
                string criterio = cbBoxcriterio.SelectedItem.ToString();
                string filtro = txtFiltrar.Text;
                NegocioPelicula negocio = new NegocioPelicula();
                dgvPelicula.DataSource = negocio.Filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
