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
    public partial class FormStock : Form
    {
        RepuestoNegocio _repuestoNegocio;
        public FormStock()
        {
            this._repuestoNegocio = new RepuestoNegocio();
            InitializeComponent();
        }

        private void FormStock_Load(object sender, EventArgs e)
        {
            CargarRepuestos();
        }

        private void CargarRepuestos()
        {
            try
            {
                cmbStock.DataSource = null;
                cmbStock.DataSource = this._repuestoNegocio.Traer();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbStock.DataSource!=null)
                {
                    Repuesto repuestoSeleccionado = (Repuesto)cmbStock.SelectedItem;
                    Validar();
                    TransactionResult resultado = this._repuestoNegocio.AgregarStock(repuestoSeleccionado, int.Parse(txtCantidad.Text));
                    MessageBox.Show(resultado.ToString());
                    CargarRepuestos();
                }
                Limpiar();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void Validar()
        {
            if (!int.TryParse(txtCantidad.Text, out int cantidad))
                throw new Exception("Debe ingresar un número");
        }

        private void Limpiar()
        {
            txtCantidad.Text = string.Empty;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStock.DataSource != null)
                {
                    Repuesto repuestoSeleccionado = (Repuesto)cmbStock.SelectedItem;
                    Validar();

                    TransactionResult resultado = this._repuestoNegocio.QuitarStock(repuestoSeleccionado, int.Parse(txtCantidad.Text));
                    MessageBox.Show(resultado.ToString());
                    CargarRepuestos();
                }
                Limpiar();
            }
            catch (StockInsuficienteException stockExe)
            {
                MessageBox.Show(stockExe.Message);
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
