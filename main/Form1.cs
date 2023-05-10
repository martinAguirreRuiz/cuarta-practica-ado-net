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

namespace main
{
    public partial class Form1 : Form
    {
        List<Pokemon> listaPokemons = new List<Pokemon>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PokemonNegocio pokemonNegocio = new PokemonNegocio();
            listaPokemons = pokemonNegocio.listarPokemons();
            dgvPokemons.DataSource = listaPokemons;
            cargarImagen(listaPokemons[0].UrlImagen);
            dgvPokemons.Columns["UrlImagen"].Visible = false;
        }
        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbPokemons.Load(imagen);
            }
            catch (Exception)
            {
                pbPokemons.Load("https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png");
            }
        }

        private void btnAgregarPokemon_Click(object sender, EventArgs e)
        {
            frmAltaPokemon formAltaPokemon = new frmAltaPokemon();
            formAltaPokemon.ShowDialog();
        }
    }
}
