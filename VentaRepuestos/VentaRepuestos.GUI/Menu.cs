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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnABM_Click(object sender, EventArgs e)
        {
            FormABM frmABM = new FormABM();
            frmABM.Owner = this;
            frmABM.Show();
            this.Hide();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            FormListar frmListar = new FormListar();
            frmListar.Owner = this;
            frmListar.Show();
            this.Hide();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            FormStock frmStock = new FormStock();
            frmStock.Owner = this;
            frmStock.Show();
            this.Hide();
        }
    }
}
