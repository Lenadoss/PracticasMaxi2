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
            try
            {
                if(dgvAlbumes.CurrentRow != null)
                {
                    Album seleccionado = (Album)dgvAlbumes.CurrentRow.DataBoundItem;
                    string imagen = seleccionado.UrlImagenCover;
                    CargarImagen(imagen);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void Cargar()
        {
            AlbumNegocio negocio = new AlbumNegocio();
            try
            {
                listaAlbumes = negocio.listar();
                dgvAlbumes.DataSource = listaAlbumes;
                ocultarColumnas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ocultarColumnas()
        {
            try
            {
                dgvAlbumes.Columns["UrlImagenCover"].Visible = false;
                dgvAlbumes.Columns["id"].Visible = false;
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
            cbBoxCampo.Items.Clear();
            cbBoxCampo.Items.Add("Id");
            cbBoxCampo.Items.Add("Titulo");
            cbBoxCampo.Items.Add("Genero");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvAlbumes.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un album a modificar.", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Album seleccionado = (Album)dgvAlbumes.CurrentRow.DataBoundItem;
                frmAgregarAlbum frmModificarAlbum = new frmAgregarAlbum(seleccionado);
                frmModificarAlbum.ShowDialog();
                Cargar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAlbumes.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un album a eliminar fisico.", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Eliminar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAlbumes.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un album a modificar.", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Eliminar(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Eliminar(bool logico = false)
        {
            try
            {
                DialogResult Respuesta = MessageBox.Show("Are you sure you want to delete it?", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Respuesta == DialogResult.Yes)
                {
                    Album seleccionado = (Album)dgvAlbumes.CurrentRow.DataBoundItem;
                    AlbumNegocio negocio = new AlbumNegocio();
                    if (logico)
                        negocio.EliminarLogico(seleccionado.Id);
                    else
                        negocio.Eliminar(seleccionado.Id);
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string Filtro = txtFiltro.Text;
            List<Album> listaFiltrada;
            try
            {
                if (Filtro.Length > 2)
                {
                    listaFiltrada = listaAlbumes.FindAll(x => x.Titulo.ToUpper().Contains(Filtro.ToUpper()) || x.Genero.Descripcion.ToUpper().Contains(Filtro.ToUpper()));
                }
                else
                {
                    listaFiltrada = listaAlbumes;
                }
                dgvAlbumes.DataSource = null;
                dgvAlbumes.DataSource = listaFiltrada;
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
                if (campo == "Id")
                {
                    cbBoxCriterio.Items.Clear();
                    cbBoxCriterio.Items.Add("Mayor que");
                    cbBoxCriterio.Items.Add("Menor que");
                    cbBoxCriterio.Items.Add("Igual que");
                }
                else
                {
                    cbBoxCriterio.Items.Clear();
                    cbBoxCriterio.Items.Add("Contiene");
                    cbBoxCriterio.Items.Add("Empieza con");
                    cbBoxCriterio.Items.Add("Termina con");
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
                if (validarFiltro())
                    return;
                string campo = cbBoxCampo.SelectedItem.ToString();
                string criterio = cbBoxCriterio.SelectedItem.ToString();
                string filtro = txtFiltrar.Text;
                AlbumNegocio negocio = new AlbumNegocio();
                dgvAlbumes.DataSource = negocio.Filtrar(campo,criterio,filtro);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool validarFiltro()
        {
            if(cbBoxCampo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione campo a filtrar.", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            } 
            if(cbBoxCriterio.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione criterio a filtrar.", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            if (cbBoxCampo.SelectedItem.ToString() == "Id")
            {
                if (string.IsNullOrEmpty(txtFiltrar.Text))
                {
                    MessageBox.Show("No puede dejar el filtro vacio para filtrar por Id.", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                if (soloNumeros(txtFiltrar.Text))
                {
                    MessageBox.Show("Solo puede digitar numeros si filtra por Id.", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return false;
        }

        private bool soloNumeros(string cadena)
        {
            foreach(char caracter in cadena)
            {
                if (char.IsNumber(caracter))
                    return false;
            }
            return true;
        }
    }
}
