using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaRepuestos.Entidades.Dominio;
using VentaRepuestos.Entidades.Modelos;
using VentaRepuestos.Negocio;
using VentaRepuestos.Negocio.Excepciones;

namespace VentaRepuestos.GUI
{
    public partial class FormABM : Form
    {
        RepuestoNegocio _repuestoNegocio;
        public FormABM()
        {
            this._repuestoNegocio = new RepuestoNegocio();
            InitializeComponent();
        }

        private void FormABM_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            try
            {
                lstRepuestos.DataSource = null;
                lstRepuestos.DataSource = _repuestoNegocio.Traer();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void lstRepuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosRepuesto();
            DeshabilitarCampos();
        }

        private void DeshabilitarCampos()
        {
            txtNombre.Enabled = false;
            txtCategoriaID.Enabled = false;
        }

        private void CargarDatosRepuesto()
        {
            if(lstRepuestos.DataSource!=null)
            {
                Repuesto repuestoSeleccionado = (Repuesto)lstRepuestos.SelectedItem;
                txtCod.Text = repuestoSeleccionado.Codigo.ToString();
                txtNombre.Text = repuestoSeleccionado.Nombre;
                txtPrecio.Text = repuestoSeleccionado.Precio.ToString();
                txtCategoriaID.Text = repuestoSeleccionado.IdCategoria.ToString();
                txtStock.Text = repuestoSeleccionado.Stock.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtCod.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtPrecio.Text = String.Empty;
            txtCategoriaID.Text = String.Empty;
            txtStock.Text = String.Empty;
            HabilitarCampos();
        }

        private void HabilitarCampos()
        {
            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtCategoriaID.Enabled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();
                string nombre = txtNombre.Text;
                double precio = double.Parse(txtPrecio.Text);
                int categoriaId = int.Parse(txtCategoriaID.Text);
                Repuesto repuesto = new Repuesto(0, nombre, precio, 0, categoriaId);
                TransactionResult resultado = _repuestoNegocio.AgregarRepuesto(repuesto);
                MessageBox.Show(resultado.ToString());
                CargarLista();
                LimpiarCampos();
            }
            catch (RepuestoExistenteException repExe)
            {
                MessageBox.Show(repExe.Message);
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void Validar()
        {
            if (
                txtNombre.Text == String.Empty ||
                txtCategoriaID.Text == String.Empty
                )
                throw new Exception("Ningún campo puede estar vacío");

            if (!int.TryParse(txtCategoriaID.Text, out int id))
                throw new Exception("Id Categoría: Debe ingresar un número");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarPrecio();
                Repuesto repuestoSeleccionado = (Repuesto)lstRepuestos.SelectedItem;
                double precio = double.Parse(txtPrecio.Text);
                TransactionResult resultado = _repuestoNegocio.ModificarPrecio(repuestoSeleccionado, precio);
                MessageBox.Show(resultado.ToString());
                CargarLista();
                LimpiarCampos();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void ValidarPrecio()
        {
            if (!double.TryParse(txtCod.Text, out double precio))
                throw new Exception("Precio: Debe ingresar un número");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Repuesto repuestoSeleccionado = (Repuesto)lstRepuestos.SelectedItem;

                TransactionResult resultado = _repuestoNegocio.QuitarRepuesto(repuestoSeleccionado);
                MessageBox.Show(resultado.ToString());
                CargarLista();
                LimpiarCampos();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }
    }
}
