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
        private Pokemon pokemon = null;
        public frmAgregarPokemon()
        {
            InitializeComponent();
        }
        public frmAgregarPokemon(Pokemon pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                if (pokemon == null) 
                    pokemon = new Pokemon();
                pokemon.Numero = int.Parse(txtNumero.Text);
                pokemon.Nombre = txtNombre.Text;
                pokemon.Descripcion = txtDescripcion.Text;
                pokemon.UrlImagen = txtUrlImagen.Text;
                pokemon.Tipo = (Elemento)cbBoxTipo.SelectedItem;
                pokemon.Debilidad = (Elemento)cbBoxDebilidad.SelectedItem;

                if(pokemon.Id == 0)
                {
                    negocio.Agregar(pokemon);
                    MessageBox.Show("Pokemon agregado correctamente");
                }
                else
                {
                    negocio.Modificar(pokemon);
                    MessageBox.Show("Pokemon modificado correctamente");
                }
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
            cbBoxDebilidad.ValueMember = "Id";
            cbBoxDebilidad.DisplayMember = "Descripcion";
            cbBoxTipo.DataSource = negocio.listar();
            cbBoxTipo.ValueMember = "Id";
            cbBoxTipo.DisplayMember = "Descripcion";

            if(pokemon != null)
            {
                txtNumero.Text = pokemon.Numero.ToString();
                txtNombre.Text = pokemon.Nombre;
                txtDescripcion.Text = pokemon.Descripcion;
                txtUrlImagen.Text = pokemon.UrlImagen;
                CargarImagen(pokemon.UrlImagen);
                cbBoxTipo.SelectedValue = pokemon.Tipo.Id;
                cbBoxDebilidad.SelectedValue = pokemon.Debilidad.Id;
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

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtUrlImagen.Text);
        }
    }
}
