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

namespace Presentacion
{
    public partial class frmPrincipal : Form
    {
        private List<Pokemon> listaPokemons = new List<Pokemon>();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Cargar();
            cbBoxCampo.Items.Add("Numero");
            cbBoxCampo.Items.Add("Nombre");
            cbBoxCampo.Items.Add("Descripcion");
        }

        private void dgvPokemon_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvPokemon.CurrentRow != null)
            {
                Pokemon seleccionado;
                seleccionado = (Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
                string imagen = seleccionado.UrlImagen;
                CargarImagen(imagen);
            }
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                pbxPokemon.Load(imagen);
            }
            catch (Exception)
            {
                pbxPokemon.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void Cargar()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                listaPokemons = negocio.listar();
                dgvPokemon.DataSource = listaPokemons;
                ocultarColumnas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmAgregarPokemon agregarPokemon = new frmAgregarPokemon();
                agregarPokemon.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void tablaNula()
        {
            if (dgvPokemon.CurrentRow == null)
            {
                MessageBox.Show("Selecciona pokemon a modificar", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvPokemon.CurrentRow == null)
                {
                    MessageBox.Show("Selecciona pokemon a modificar", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Pokemon seleccionado = (Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
                frmAgregarPokemon modificarPokemon = new frmAgregarPokemon(seleccionado);
                modificarPokemon.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            if (dgvPokemon.CurrentRow == null)
            {
                MessageBox.Show("Selecciona pokemon a eliminar fisico", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Eliminar();
        }

        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            if (dgvPokemon.CurrentRow == null)
            {
                MessageBox.Show("Selecciona pokemon a eliminar logico", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Eliminar(true);
        }

        private void Eliminar(bool logico = false)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("Are you sure you want to delete it?", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    Pokemon seleccionado = (Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
                    PokemonNegocio negocio = new PokemonNegocio();
                    if (logico)
                        negocio.EliminarLogico(seleccionado.Id);
                    else
                        negocio.EliminarFisico(seleccionado.Id);
                    Cargar();
                }
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
                dgvPokemon.Columns["urlimagen"].Visible = false;
                dgvPokemon.Columns["id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            List<Pokemon> listaFiltrada;
            string filtro = txtFiltro.Text;
            try
            {
                if (filtro != "")
                {
                    listaFiltrada = listaPokemons.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                }
                else
                {
                    listaFiltrada = listaPokemons;
                }
                dgvPokemon.DataSource = listaFiltrada;
                ocultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string Filtro = txtFiltro.Text;
            List<Pokemon> listaFiltrada;
            try
            {
                if (Filtro.Length > 2)
                {
                    listaFiltrada = listaPokemons.FindAll(x => x.Nombre.ToUpper().Contains(Filtro.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(Filtro.ToUpper()));
                }
                else
                {
                    listaFiltrada = listaPokemons;
                }
                dgvPokemon.DataSource = null;
                dgvPokemon.DataSource = listaFiltrada;
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
                string opcion = cbBoxCampo.SelectedItem.ToString();
                if (opcion == "Numero")
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

        private bool validarFiltro()
        {
            if(cbBoxCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione campo a filtrar.", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            if(cbBoxCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona criterio a filtrar.", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            if(cbBoxCampo.SelectedItem.ToString() == "Numero")
            {
                if (string.IsNullOrEmpty(txtBuscarAvanzado.Text))
                {
                    MessageBox.Show("Debes cargar el fitro para numericos.", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                if (soloNumeros(txtBuscarAvanzado.Text))
                {
                    MessageBox.Show("Solo se pueden cargar numeros para filtrar por numero..", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarFiltro())
                    return;

                string campo = cbBoxCampo.SelectedItem.ToString();
                string criterio = cbBoxCriterio.SelectedItem.ToString();
                string filtro = txtBuscarAvanzado.Text;
                PokemonNegocio negocio = new PokemonNegocio();
                dgvPokemon.DataSource = negocio.Filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
