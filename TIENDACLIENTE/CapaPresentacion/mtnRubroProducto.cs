using ServiceImpuesto;
using ServiceRubroProducto;
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
    public partial class mtnRubroProducto : Form
    {
        private bool modoEditar = false;
        ServiceCrudOf_DtoRubroProductoClient client_rubr = new();
        public mtnRubroProducto(DtoRubroProducto pRubroProducto = null)
        {
            InitializeComponent();
            CargarCombosSeleccion();
            var DtoRubroProducto = client_rubr.Mostrar();
            var IdRubroProducto = 0;
            foreach (var item in DtoRubroProducto)
            {
                if (item.IdRubroProducto >= IdRubroProducto) IdRubroProducto = item.IdRubroProducto + 1;
            }
            if (pRubroProducto != null)
            {
                modoEditar = true;
                cmbEstado.Enabled = true;
                txtId.Text = pRubroProducto.IdRubroProducto.ToString();
                txtCodigo.Text = pRubroProducto.CodigoRubroProducto;
                txtDescripcion.Text = pRubroProducto.DescripcionRubroProducto;
                txtMargenGanancia.Text = pRubroProducto.MargenGanancia.ToString();
                //CmbImpuesto.Text = pRubroProducto.OImpuesto.Descripcion.ToString();
                cmbEstado.Text = pRubroProducto.DescripcionEstado.ToString();
            }
        }
        private void CargarCombosSeleccion()
        {
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            cmbEstado.DisplayMember = "Text";
            cmbEstado.ValueMember = "Value";
            cmbEstado.SelectedIndex = 0;

            using (ServiceImpuesto.ServiceImpuestoClient client = new())
            {
                var oListaImpuesto = client.ListaImpuesto();
                foreach (var item in oListaImpuesto)
                {
                    if (item.OEstado.Equals(ServiceImpuesto.Estado.Inactivo)) CmbImpuesto.Items.Add(item.Descripcion);
                }
                CmbImpuesto.DisplayMember = "Text";
                CmbImpuesto.ValueMember = "Value";
                client.Close();
            }

        }

        private void mtnRubroProducto_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            ServiceImpuestoClient client_imp = new();
            _ = client_rubr.Mostrar();
            var Codigo = txtCodigo.Text.Trim();
            var Descripcion = txtDescripcion.Text.Trim();
            var margenGanancia = Convert.ToDouble(txtMargenGanancia.Text.Trim());
            var oImpuesto = CmbImpuesto.Items[CmbImpuesto.SelectedIndex].ToString();
            var oEstado = cmbEstado.Items[cmbEstado.SelectedIndex].ToString();
            DtoRubroProducto rub = new()
            {
                CodigoRubroProducto = Codigo,
                DescripcionRubroProducto = Descripcion,
                MargenGanancia = margenGanancia,
                DescripcionImpuesto = oImpuesto,
                DescripcionEstado = oEstado
            };
            bool Respuesta;
            string msgSuccess;
            string msgError;
            if (modoEditar)
            {
                rub.IdRubroProducto = Convert.ToInt32(txtId.Text.Trim());
                Respuesta = client_rubr.Actualizar(rub);
                msgSuccess = "Rubro Modificado \n¿Desea modificar otro Rubro ahora?";
                msgError = "No se pudo modificar el Rubro, \nes posible que ya se encuentre registrado";
            }
            else
            {

                Respuesta = client_rubr.Registrar(rub);
                msgSuccess = "Rubro Registrado \n¿Desea registrar un nuevo Rubro ahora?";
                msgError = "No se pudo registrar el Rubro, \nes posible que ya se encuentre registrado";

            }
            if (Respuesta)
            {
                if (MessageBox.Show(msgSuccess, "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtId.Text = "";
                    txtCodigo.Text = "";
                    txtDescripcion.Text = "";
                    txtMargenGanancia.Text = "";
                    CmbImpuesto.SelectedIndex = 0;
                    cmbEstado.SelectedIndex = 0;
                    modoEditar = false;
                    txtCodigo.Focus();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(msgError, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            client_rubr.Close();
        }
    }
}
