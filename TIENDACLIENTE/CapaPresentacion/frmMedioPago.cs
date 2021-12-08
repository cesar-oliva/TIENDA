using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmMedioPago : Form
    {
        public frmMedioPago()
        {
            InitializeComponent();
        }

        private void txtNombreTitular_Leave(object sender, EventArgs e)
        {
            lblNombre.Text = txtNombreTitular.Text.Trim();
        }

        private void mtxtExpiracion_Leave(object sender, EventArgs e)
        {
            lblFecha.Text = mtxtExpiracion.Text.Trim();
        }
        private void mtxtNumero_Leave(object sender, EventArgs e)
        {
            lblNumeroTarjeta.Text = mtxtNumero.Text.Trim();
        }

        private void txtCodigoSeguridad_Leave(object sender, EventArgs e)
        {
            lblCodigoSeguridad.Text = txtCodigoSeguridad.Text.Trim();
        }
    }
}
