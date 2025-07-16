using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokedex
{
    public partial class frmPokemons : Form
    {
        private List<Pokemon> listaPokemon;
        public frmPokemons()
        {
            InitializeComponent();
        }

        private void frmPokemons_Load(object sender, EventArgs e)
        {
            PokemonNegocio Negocio = new PokemonNegocio();
            listaPokemon = Negocio.Listar();
            dgvPokemons.DataSource = listaPokemon;
            dgvPokemons.Columns["urlimagen"].Visible = false;
        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon Seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            CargarImagen(Seleccionado.UrlImagen);
        }

        private void CargarImagen (string Imagen)
        {
            try
            {
                pbxPokemon.Load(Imagen);
            }
            catch (Exception)
            {
                pbxPokemon.Load("https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png");
            }
        }
    }
}
