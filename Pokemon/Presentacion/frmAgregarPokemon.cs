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
    public partial class frmAgregarPokemon : Form
    {
        public frmAgregarPokemon()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Pokemon nuevoPokemon = new Pokemon();
            try
            {
                nuevoPokemon.Numero = int.Parse(txtNumero.Text);
                nuevoPokemon.Nombre = txtNombre.Text;
                nuevoPokemon.Descripcion = txtDescripcion.Text;
                nuevoPokemon.UrlImagen = txtUrlImagen.Text;
                nuevoPokemon.Tipo = (Elemento)cbBoxTipo.SelectedItem;
                nuevoPokemon.Debilidad = (Elemento)cbBoxDebilidad.SelectedItem;
                negocio.Agregar(nuevoPokemon);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAgregarPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio negocio = new ElementoNegocio();
            cbBoxDebilidad.DataSource = negocio.listar();
            cbBoxTipo.DataSource = negocio.listar();
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

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtUrlImagen.Text);
        }
    }
}
