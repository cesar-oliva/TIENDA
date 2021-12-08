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
using ServiceRubroProducto;
using ServiceMarca;
using ServiceColor;

namespace CapaPresentacion
{
    public partial class MtnProducto : Form
    {
        private bool modoEditar = false;
        frmMensaje msj = new();
        public MtnProducto(DtoProducto pProducto = null)
        {
            InitializeComponent();
            CargarCombosSeleccion();
            ServiceProductoClient client_prod = new();
            var producto = client_prod.ListaProducto();
            var IdProducto = 0;
            foreach (var item in producto)
            {
                if (item.IdProducto >= IdProducto) IdProducto = item.IdProducto + 1;
            }
            if (pProducto != null)
            {
                modoEditar = true;
                cmbEstado.Enabled = true;
                txtId.Text = pProducto.IdProducto.ToString();
                txtCodigo.Text = pProducto.Codigo;
                txtDescripcion.Text = pProducto.Descripcion;
                cmbGenero.Text = pProducto.OGeneroProducto.ToString();
                cmbRubro.Text = pProducto.ORubroProducto.DescripcionRubroProducto.ToString();
                cmbMarca.Text = pProducto.OMarca.Descripcion.ToString();
                cmbColor.Text = pProducto.OColor.DescripcionColor.ToString();
                cmbTalle.Text = pProducto.OTalle.DescripcionTalle.ToString();
                txtCosto.Text = pProducto.Costo.ToString();
                cmbEstado.Text = pProducto.OEstado.ToString();
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

            using (ServiceRubroProducto.ServiceRubroProductoClient client = new ())
            {
                var oListaRubro = client.ListaRubroProducto();
                foreach (var item in oListaRubro)
                {
                    if (item.OEstado.Equals(ServiceRubroProducto.Estado.Activo)) cmbRubro.Items.Add(item.DescripcionRubroProducto);
                }
                cmbRubro.DisplayMember = "Text";
                cmbRubro.ValueMember = "Value";
                client.Close();
            }
            using (ServiceColor.ServiceColorClient client = new())
            {
                var oListaColor = client.ListaColor();
                foreach (var item in oListaColor)
                {
                    if (item.OEstado.Equals(ServiceColor.Estado.Activo)) cmbColor.Items.Add(item.DescripcionColor);
                }
                cmbColor.DisplayMember = "Text";
                cmbColor.ValueMember = "Value";
                client.Close();
            }
            using (ServiceTalle.ServiceTalleClient client = new())
            {
                var oListaTalle = client.ListaTalle();
                foreach (var item in oListaTalle)
                {
                    if (item.OEstado.Equals(ServiceTalle.Estado.Activo)) cmbTalle.Items.Add(item.DescripcionTalle);
                }
                cmbTalle.DisplayMember = "Text";
                cmbTalle.ValueMember = "Value";
                client.Close();
            }
            using (ServiceColor.ServiceColorClient client = new())
            {
                var oListaColor = client.ListaColor();
                foreach (var item in oListaColor)
                {
                    if (item.OEstado.Equals(ServiceImpuesto.Estado.Inactivo))
                    {
                        cmbColor.Items.Add(item.DescripcionColor);
                    }
                }
                cmbColor.DisplayMember = "Text";
                cmbColor.ValueMember = "Value";
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
            var Codigo = txtCodigo.Text.Trim();
            var Descripcion = txtDescripcion.Text.Trim();
            var oGeneroProducto = client_prod.ObtenerGeneroProducto(cmbGenero.Items[cmbGenero.SelectedIndex].ToString());
            var Rubro = client_prod.ObtenerRubroProducto(cmbRubro.Items[cmbRubro.SelectedIndex].ToString());
            var Marca = client_prod.ObtenerMarca(cmbMarca.Items[cmbMarca.SelectedIndex].ToString());
            var Color = client_prod.ObtenerColor(cmbColor.Items[cmbColor.SelectedIndex].ToString());
            var Talle = client_prod.ObtenerTalle(cmbTalle.Items[cmbTalle.SelectedIndex].ToString());
            var Costo = Math.Round(Convert.ToDouble(txtCosto.Text.Trim()), 2);
            var oEstado = client_prod.ObtenerEstado(cmbEstado.Items[cmbEstado.SelectedIndex].ToString());
            DtoProducto prod = new()
            {
                Codigo = Codigo,
                Descripcion = Descripcion,
                OGeneroProducto = oGeneroProducto,
                ORubroProducto = Rubro,
                OMarca = Marca,
                OColor = Color,
                OTalle = Talle, 
                Costo = Costo,
                OEstado = oEstado
            };
            bool Respuesta;
            string msgSuccess;
            string msgError;
            if (modoEditar)
            {
                prod.IdProducto = Convert.ToInt32(txtId.Text.Trim());
                Respuesta = client_prod.ModificarProducto(prod);
                msgSuccess = "Producto Modificado exitosamente";
                msgError = "No se pudo modificar el Producto, \nes posible que ya se encuentre registrado";
            }
            else
            {

                Respuesta = client_prod.IngresarProducto(prod);
                msgSuccess = "Producto Registrado exitosamente";
                msgError = "No se pudo registrar el Producto, \nes posible que ya se encuentre registrado";

            }
            if (Respuesta)
            {
                this.Close();
                DialogResult resmsj = msj.MsjInformacion(msgSuccess, "MSG-INFORMACION", "ACEPTAR");
                if (resmsj.Equals(DialogResult.OK))
                {
                    txtId.Text = "";
                    txtCodigo.Text = "";
                    txtDescripcion.Text = "";
                    cmbGenero.SelectedIndex = 0;
                    cmbRubro.SelectedIndex = 0;
                    cmbMarca.SelectedIndex = 0;
                    cmbColor.SelectedIndex = 0;
                    cmbTalle.SelectedIndex = 0;
                    txtCosto.Text = "";
                    cmbEstado.SelectedIndex = 0;
                    modoEditar = false;
                    txtCodigo.Focus();
                    msj.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                DialogResult resmsj = msj.MsjExclamacion(msgError, "MSG-ATENCION", "ACEPTAR"); ;
            }
            client_prod.Close();
            client_imp.Close();

        }

    }   
}
    
