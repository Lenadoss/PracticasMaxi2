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
        }

        private void dgvPokemon_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = new Pokemon();
            seleccionado = (Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
            string imagen = seleccionado.UrlImagen;
            CargarImagen(imagen);
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
                dgvPokemon.Columns["urlimagen"].Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarPokemon agregarPokemon = new frmAgregarPokemon();
            agregarPokemon.ShowDialog();
            Cargar();
        }
    }
}
