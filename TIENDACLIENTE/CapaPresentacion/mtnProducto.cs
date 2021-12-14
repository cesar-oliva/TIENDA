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
        DataTable TablaProductoVenta = new();
        List<string> TablaColor = new();
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
                //cmbColor.Text = pProducto.OColor.DescripcionColor.ToString();
                cmbTipoTalle.Text = pProducto.OTipoTalle.Descripcion.ToString();
                //txtCosto.Text = pProducto.Costo.ToString();
                cmbEstado.Text = pProducto.OEstado.ToString();
            }
            ServiceColorClient client_color = new();
            foreach (var item in client_color.ListaColor())
            {
                TablaColor.Add(item.DescripcionColor);
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
            cmbEstado.SelectedIndex = 1;
            groupBoxVariante.Enabled = false;   

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
            using (ServiceTipoTalle.ServiceTipoTalleClient client = new())
            {
                var oListaTipoTalle = client.ListaTipoTalle();
                foreach (var item in oListaTipoTalle)
                {
                    if (item.OEstado.Equals(ServiceTipoTalle.Estado.Activo)) cmbTipoTalle.Items.Add(item.Descripcion);
                }
                cmbTipoTalle.DisplayMember = "Text";
                cmbTipoTalle.ValueMember = "Value";
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
            CargarDatosColor();
            dataGridProductoVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProductoVenta.MultiSelect = false;
            dataGridProductoVenta.ReadOnly = true;
            dataGridProductoVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProductoVenta.AllowUserToAddRows = false;
        }
        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            ServiceProductoClient client_prod = new();
            _ = client_prod.ListaProducto();
            var Codigo = txtCodigo.Text.Trim();
            var Descripcion = txtDescripcion.Text.Trim();
            var oGeneroProducto = client_prod.ObtenerGeneroProducto(cmbGenero.Items[cmbGenero.SelectedIndex].ToString());
            var Rubro = client_prod.ObtenerRubroProducto(cmbRubro.Items[cmbRubro.SelectedIndex].ToString());
            var Marca = client_prod.ObtenerMarca(cmbMarca.Items[cmbMarca.SelectedIndex].ToString());
            var TipoTalle = client_prod.ObtenerTipoTalle(cmbTipoTalle.Items[cmbTipoTalle.SelectedIndex].ToString());
            var oEstado = client_prod.ObtenerEstado(cmbEstado.Items[cmbEstado.SelectedIndex].ToString());
            List<ProductoVenta> prodventa = new();
            DtoProducto prod = new()
            {
                Codigo = Codigo,
                Descripcion = Descripcion,
                OGeneroProducto = oGeneroProducto,
                ORubroProducto = Rubro,
                OMarca = Marca,
                OTipoTalle = TipoTalle, 
                OEstado = oEstado
            };

            //for (int i = 0; i < dataGridProductoVenta.RowCount; i++)
            //{
            //    Producto oProducto = prod;
            //    Color oColor = client_prod.ObtenerColor(dataGridProductoVenta.Rows[i].Cells[1].Value.ToString());
            //    prodventa[i] = dataGridProductoVenta.Rows[i].Cells[0].Value.ToString();
            //}


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
                    cmbTipoTalle.SelectedIndex = 0;
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

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            using ServiceColor.ServiceColorClient client = new();
            using ServiceTalle.ServiceTalleClient client_t = new();
            string Color = client.ObtenerColor(cmbColor.Items[cmbColor.SelectedIndex].ToString()).DescripcionColor;
            dataGridProductoVenta.Rows.Add(txtCodigo.Text.Trim(), Color , client_t.ObtenerTalle(cmbTalle.Items[cmbTalle.SelectedIndex].ToString()).CodigoTalle,txtCosto.Text.Trim(),txtCantidad.Text.Trim());
            cmbColor.Items.Clear();
            TablaColor.Remove(Color);
            foreach (var item in TablaColor)
            {
                cmbColor.Items.Add(item);
            }         
            cmbColor.DisplayMember = "Text";
            cmbColor.ValueMember = "Value";
            cmbColor.SelectedIndex = -1;
            txtCantidad.Text="";
            txtCosto.Text = "";
            cmbColor.Text = "Color";
            cmbTalle.Text = "Talle";
            
        }
        private void CargarDatosColor()
        {
            dataGridProductoVenta.AutoResizeColumns();
            dataGridProductoVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridProductoVenta.Columns.Add("Codigo", "Codigo");
            dataGridProductoVenta.Columns.Add("Color", "Color");
            dataGridProductoVenta.Columns.Add("Talle", "Talle");
            dataGridProductoVenta.Columns.Add("Costo", "Costo");
            dataGridProductoVenta.Columns.Add("Cantidad", "Cantidad");
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbEstado.SelectedIndex == 0)
            {
                groupBoxVariante.Enabled = true;
            }
            else
            {
                groupBoxVariante.Enabled = false;
            }
            
        }

        private void cmbTipoTalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTalle.Items.Clear();
            using (ServiceTalle.ServiceTalleClient client = new())
            {
                var oListaTalle = client.ListaTalle();
                foreach (var item in oListaTalle)
                {
                    if (item.OEstado.Equals(ServiceTalle.Estado.Activo) && item.OTipoTalle.Descripcion.Equals(cmbTipoTalle.SelectedItem.ToString())) cmbTalle.Items.Add(item.CodigoTalle);
                }
                cmbTipoTalle.DisplayMember = "Text";
                cmbTipoTalle.ValueMember = "Value";
                client.Close();
            }
        }
        private void CargarDatosProductosVenta()
        {
            using ServiceProducto.ServiceProductoClient client = new();
            var oListaProducto = client.ListaProducto();
            if (oListaProducto.Count() > 0 && oListaProducto != null)
            {
                //lblTotalRegistros.Text = oListaProducto.Count().ToString();
                TablaProductoVenta = new DataTable();
                TablaProductoVenta.Columns.Clear();
                TablaProductoVenta.Rows.Clear();
                TablaProductoVenta.Columns.Add("IdProducto", typeof(int));
                TablaProductoVenta.Columns.Add("Color", typeof(string));
                TablaProductoVenta.Columns.Add("Talle", typeof(string));
                TablaProductoVenta.Columns.Add("Costo", typeof(string));
                TablaProductoVenta.Columns.Add("Cantidad", typeof(string));

                foreach (DtoProducto row in oListaProducto)
                {
                    if (row.OEstado.Equals(ServiceProducto.Estado.Activo))
                    {
                        foreach (var item in row.OProductoVenta)
                        {
                            TablaProductoVenta.Rows.Add(row.IdProducto, item.OColor.DescripcionColor, item.OTalle.CodigoTalle, item.Costo, item.Cantidad);
                        }
                    }
                }
                dataGridProductoVenta.DataSource = TablaProductoVenta;
                dataGridProductoVenta.AutoResizeColumns();
                dataGridProductoVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridProductoVenta.Columns["IdProducto"].Visible = false;
                dataGridProductoVenta.Columns["Color"].Visible = true;
                dataGridProductoVenta.Columns["Talle"].Visible = true;
                dataGridProductoVenta.Columns["Costo"].Visible = true;
                dataGridProductoVenta.Columns["Cantidad"].Visible = true;
    
            }
        }

        private void groupBoxVariante_Enter(object sender, EventArgs e)
        {
            groupBoxProducto.Enabled = false;
        }
    }
}
    
