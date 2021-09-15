using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Reutilizable;
using ServiceProducto;
using ServiceImpuesto;
using ServiceRubro;
using ServiceMarca;
namespace CapaPresentacion
{
    public partial class MtnProducto : Form
    {
        private bool modoEditar = false;
        public MtnProducto(DtoProducto pProducto = null)
        {
            InitializeComponent();
            CargarCombosSeleccion();
            ServiceProductoClient client_prod = new();
            List<DtoProducto> producto = client_prod.ListaProducto();
            var IdProducto = 0;
            foreach (var item in producto)
            {
                if (item.IdProducto >= IdProducto) IdProducto = item.IdProducto + 1;
            }
            if (pProducto != null)
            {
                ServiceImpuestoClient client_imp = new();
                List<DtoImpuesto> imp = client_imp.ListaImpuesto();
                var Impuesto =0;
                foreach (var item in imp)
                {
                    if (item.Alicuota.Equals(pProducto.Impuesto)) Impuesto = item.IdImpuesto;
                }
                modoEditar = true;
                cmbEstado.Enabled = true;
                txtCodigo.Text = pProducto.Codigo;
                txtDescripcion.Text = pProducto.Descripcion;
                txtCosto.Text = pProducto.Costo.ToString();
                cmbGenero.Text = pProducto.OGeneroProducto.ToString();
                txtUtilidad.Text = pProducto.MargenGanancia.ToString();
                txtPrecioVenta.Text = pProducto.PrecioVenta.ToString();
                txtNetoGravado.Text = pProducto.NetoGravado.ToString();
                txtUtilidad.Text = pProducto.MargenGanancia.ToString();
                cmbRubro.Text = pProducto.ORubroProducto.Descripcion.ToString();
                cmbEstado.Text = pProducto.OEstado.ToString();
                cmbImpuesto.SelectedIndex = Impuesto;
                cmbMarca.Text = pProducto.OMarca.Descripcion.ToString();
            }

        }
        private void CargarCombosSeleccion()
        {
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            cmbGenero.Items.Add("Unisex");
            cmbGenero.Items.Add("Masculino");
            cmbGenero.Items.Add("Femenino");
            cmbEstado.DisplayMember = "Text";
            cmbEstado.ValueMember = "Value";
            cmbEstado.SelectedIndex = 0;
            using (ServiceRubro.ServiceRubroClient client = new ())
            {
                List<DtoRubro> oListaRubro = client.ListaRubro();
                foreach (var item in oListaRubro)
                {
                    if (item.OEstado.Equals(ServiceRubro.Estado.Activo)) cmbRubro.Items.Add(item.Descripcion);
                }
                cmbRubro.DisplayMember = "Text";
                cmbRubro.ValueMember = "Value";
                client.Close();
            }
            using (ServiceImpuesto.ServiceImpuestoClient client = new())
            {
                List<DtoImpuesto> oListaImpuesto = client.ListaImpuesto();
                foreach (var item in oListaImpuesto)
                {
                    if (item.OEstado.Equals("Activo"))
                    {
                        cmbImpuesto.Items.Add(item.Descripcion);
                    }
                }
                cmbImpuesto.DisplayMember = "Text";
                cmbImpuesto.ValueMember = "Value";
                client.Close();
            }
            using (ServiceMarca.ServiceMarcaClient client = new())
            {

                List<DtoMarca> oListaMarca = client.ListaMarca();
                foreach (var item in oListaMarca)
                {
                    if (item.OEstado.ToString().Equals("Activo")) cmbMarca.Items.Add(item.Descripcion);
                }
                cmbMarca.DisplayMember = "Text";
                cmbMarca.ValueMember = "Value";
                client.Close();
            }
        }

        private void Mtn_Producto_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }

        private void Txt_Utilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }
        
        private void Cmb_Impuesto_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ServiceImpuestoClient client_imp = new();
            List<DtoImpuesto> imp = client_imp.ListaImpuesto();
            var Impuesto = 0.00;
            foreach (var item in imp)
            {
                if (item.Descripcion.Equals(cmbImpuesto.Items[cmbImpuesto.SelectedIndex].ToString())) Impuesto = item.Alicuota;
            }
            double Costo = Math.Round(Convert.ToDouble(txtCosto.Text.Trim()), 2);
            double MargenGanancia = Math.Round(Convert.ToDouble(txtUtilidad.Text.Trim()), 2);
            var NetoGravado = Math.Round(Costo * Math.Round(((MargenGanancia / 100) + 1), 2), 2);
            var PrecioVenta = Math.Round(NetoGravado * ((Impuesto / 100) + 1), 2);
            txtNetoGravado.Text = NetoGravado.ToString();
            txtPrecioVenta.Text = PrecioVenta.ToString();

        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            ServiceProductoClient client_prod = new();
            ServiceImpuestoClient client_imp = new();
            List<DtoImpuesto> imp = client_imp.ListaImpuesto();
            _ = client_prod.ListaProducto();

            if (txtCodigo.Text.Trim() == "" && txtDescripcion.Text.Trim() == "" && txtCosto.Text.Trim() == "" && txtUtilidad.Text.Trim() == "")
            {
                MessageBox.Show("Debe completar todos los campos", "Mensaje");
                return;
            }
            var Codigo = txtCodigo.Text.Trim();
            var Descripcion = txtDescripcion.Text.Trim();
            var oGeneroProducto = client_prod.ObtenerGeneroProducto(cmbGenero.Items[cmbGenero.SelectedIndex].ToString());
            var Rubro = client_prod.ObtenerRubroProducto(cmbRubro.Items[cmbRubro.SelectedIndex].ToString());
            var Marca = client_prod.ObtenerMarca(cmbMarca.Items[cmbMarca.SelectedIndex].ToString());
            var Impuesto = 0.00;
            foreach (var item in imp)
            {
                if (item.Descripcion.Equals(cmbImpuesto.Items[cmbImpuesto.SelectedIndex].ToString())) Impuesto = item.Alicuota;
            }
            var Costo = Math.Round(Convert.ToDouble(txtCosto.Text.Trim()), 2);
            var MargenGanancia = Math.Round(Convert.ToDouble(txtUtilidad.Text.Trim()), 2);
            var NetoGravado = Costo * Math.Round(((MargenGanancia / 100) + 1), 2);
            var PrecioVenta = NetoGravado * Math.Round(((Impuesto / 100) + 1), 2);
            var oEstado = client_prod.ObtenerEstado(cmbEstado.Items[cmbEstado.SelectedIndex].ToString());
            DtoProducto prod = new()
            {
                Codigo = Codigo,
                Descripcion = Descripcion,
                OGeneroProducto = oGeneroProducto,
                ORubroProducto = Rubro,
                OMarca = Marca,
                Impuesto = Impuesto,
                Costo = Costo,
                MargenGanancia = MargenGanancia,
                NetoGravado = NetoGravado,
                PrecioVenta = PrecioVenta,
                OEstado = oEstado
            };
            bool Respuesta;
            string msgSuccess;
            string msgError;
            if (modoEditar)
            {
                Respuesta = client_prod.ModificarProducto(prod);
                msgSuccess = "Producto Modificado \n¿Desea modificar otro Producto ahora?";
                msgError = "No se pudo modificar el Producto, \nes posible que ya se encuentre registrado";
            }
            else
            {

                Respuesta = client_prod.IngresarProducto(prod);
                msgSuccess = "Producto Registrado \n¿Desea registrar un nuevo Producto ahora?";
                msgError = "No se pudo registrar el Producto, \nes posible que ya se encuentre registrado";

            }
            if (Respuesta)
            {
                if (MessageBox.Show(msgSuccess, "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtCodigo.Text = "";
                    txtCodigo.ForeColor = Color.Red;
                    txtDescripcion.Text = "";
                    cmbGenero.SelectedIndex = 0;
                    cmbRubro.SelectedIndex = 0;
                    cmbMarca.SelectedIndex = 0;
                    cmbImpuesto.SelectedIndex = 0;
                    txtCosto.Text = "";
                    txtUtilidad.Text = "";
                    txtPrecioVenta.Text = "";
                    cmbEstado.SelectedIndex = 0;
                    modoEditar = false;
                    txtCodigo.Focus();
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
            client_prod.Close();
            client_imp.Close();

        }
    }   
}
    
