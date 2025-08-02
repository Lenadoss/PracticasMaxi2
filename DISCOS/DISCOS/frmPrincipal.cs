using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;

namespace DISCOS
{
    public partial class frmPrincipal : Form
    {
        private List<Disco> Discos;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Cargar();
            cbBoxCampo.Items.Clear();
            cbBoxCampo.Items.Add("Id");
            cbBoxCampo.Items.Add("Titulo");
            cbBoxCampo.Items.Add("Edicion");
        }

        private void Cargar()
        {
            DiscoNegocio negocio = new DiscoNegocio();
            try
            {
                Discos = negocio.Listar();
                dgvDiscos.DataSource = Discos;
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
                dgvDiscos.Columns["urlimagentapa"].Visible = false;
                dgvDiscos.Columns["id"].Visible = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvDiscos.CurrentRow != null)
            {
                Disco DiscoSeleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                CargarImagen(DiscoSeleccionado.UrlImagenTapa);
            }
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                pbxDiscos.Load(imagen);
            }
            catch (Exception)
            {
                pbxDiscos.Load("https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAltaDisco DiscoAlta = new frmAltaDisco();
            DiscoAlta.ShowDialog();
            Cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvDiscos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un disco a modificar", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                frmAltaDisco DiscoModificar = new frmAltaDisco(seleccionado);
                DiscoModificar.ShowDialog();
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
                if (dgvDiscos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un disco a eliminar fisico", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Eliminar();
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
                DialogResult respuesta = MessageBox.Show("Are you sure you want to delete it?", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                    DiscoNegocio negocio = new DiscoNegocio();
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
            try
            {
                if (dgvDiscos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un disco a eliminar logico", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Eliminar(true);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            List<Disco> listaFiltrada;
            try
            {
                if (filtro.Length > 2)
                {
                    listaFiltrada = Discos.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()) || x.Estilo.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                }
                else
                {
                    listaFiltrada = Discos;
                }
                dgvDiscos.DataSource = null;
                dgvDiscos.DataSource = listaFiltrada;
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
                DiscoNegocio negocio = new DiscoNegocio();
                dgvDiscos.DataSource = negocio.Filtrar(campo, criterio, filtro);
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
                MessageBox.Show("Seleccione un campo a filtrar", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            if(cbBoxCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un criterio a filtrar", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            if(cbBoxCampo.SelectedItem.ToString() == "Id")
            {
                if (string.IsNullOrEmpty(txtFiltrar.Text))
                {
                    MessageBox.Show("No puede filtrar con el campo vacio para filtrar por Id.", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                if (soloNumeros(txtFiltrar.Text))
                {
                    MessageBox.Show("No puedes digitar letras para filtrar por Id.", "Considerando", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                {
                    return false;
                }
            }
            return true;
        }
    }
}
