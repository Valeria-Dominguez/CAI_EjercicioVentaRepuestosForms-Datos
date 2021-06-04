using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentaRepuestos.Negocio;

namespace VentaRepuestos.GUI
{
    public partial class FormListar : Form
    {
        RepuestoNegocio _repuestoNegocio;
        public FormListar()
        {
            this._repuestoNegocio = new RepuestoNegocio();
            InitializeComponent();
        }

        private void FormListar_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            try
            {
                listBox1.DataSource = null;
                listBox1.DataSource = _repuestoNegocio.Traer();
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty)
                CargarLista();
            else
                CargarListaCategoria();
        }
        private void CargarListaCategoria()
        {
            try
            {
                Validar();
                listBox1.DataSource = null;
                listBox1.DataSource = _repuestoNegocio.TraerPorCateogria(int.Parse(txtID.Text));
                LimpiarCasillero();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void LimpiarCasillero()
        {
            txtID.Text = string.Empty;
        }

        private void Validar()
        {
            if (txtID.Text == string.Empty)
                throw new Exception("Debe ingresar un código");            
        }
    }
}
