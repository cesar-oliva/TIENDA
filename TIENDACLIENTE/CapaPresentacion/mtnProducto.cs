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
        frmMensaje msj = new();
        public MtnProducto(DtoProducto pProducto = null)
        {
            InitializeComponent();
            CargarCombosSeleccion();
            groupBoxVariante.Enabled = false;
            ServiceProductoClient client_prod = new();
            var producto = client_prod.ListaProducto();
            int IdProducto = producto.Count()+1;
            txtId.Text = IdProducto.ToString();
            if (pProducto != null)
            {
                modoEditar = true;
                txtId.Text = pProducto.IdProducto.ToString();
                txtCodigo.Text = pProducto.CodigoProducto;
                txtDescripcion.Text = pProducto.DescripcionProducto;
                cmbGenero.Text = pProducto.OGeneroProducto.ToString();
                cmbRubro.Text = pProducto.ORubroProducto.DescripcionRubroProducto.ToString();
                cmbMarca.Text = pProducto.OMarca.DescripcionMarca.ToString();
                //cmbColor.Text = pProducto.OColor.DescripcionColor.ToString();
                cmbTipoTalle.Text = pProducto.OTipoTalle.DescripcionTipoTalle.ToString();
                //txtCosto.Text = pProducto.Costo.ToString();
            }
        }
        private void CargarCombosSeleccion()
        {
            cmbEstadoVariante.Items.Add("Activo");
            cmbEstadoVariante.Items.Add("Inactivo");
            groupBoxVariante.Enabled = false;

           
            using (ServiceRubroProducto.ServiceRubroProductoClient client = new ())
            {
                var oListaRubroProducto = client.ListaRubroProducto();
                foreach (var item in oListaRubroProducto)
                {
                    if (item.OEstado.Equals(ServiceRubroProducto.Estado.Activo)) cmbRubro.Items.Add(item.DescripcionRubroProducto);
                }
                cmbRubro.DisplayMember = "Text";
                cmbRubro.ValueMember = "Value";
                client.Close();
            }
            using (ServiceGeneroProducto.ServiceGeneroProductoClient client = new())
            {
                var oListaGeneroProducto = client.ListaGeneroProducto();
                foreach (var item in oListaGeneroProducto)
                {
                    if (item.OEstado.Equals(ServiceGeneroProducto.Estado.Activo)) cmbGenero.Items.Add(item.DescripcionGeneroProducto);
                }
                cmbGenero.DisplayMember = "Text";
                cmbGenero.ValueMember = "Value";
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
            using (ServiceTipoTalle.ServiceTipoTalleClient client = new())
            {
                var oListaTipoTalle = client.ListaTipoTalle();
                foreach (var item in oListaTipoTalle)
                {
                    if (item.OEstado.Equals(ServiceTipoTalle.Estado.Activo)) cmbTipoTalle.Items.Add(item.DescripcionTipoTalle);
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
                    if (item.OEstado.Equals(ServiceColor.Estado.Activo))
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

                var oListaMarca = client.ListaMarca();
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
            DtoProducto prod = new DtoProducto();
            prod.CodigoProducto = txtCodigo.Text.Trim();
            prod.DescripcionProducto = txtDescripcion.Text.Trim();
            prod.OGeneroProducto = client_prod.ObtenerGeneroProducto(cmbGenero.Items[cmbGenero.SelectedIndex].ToString());
            prod.ORubroProducto = client_prod.ObtenerRubroProducto(cmbRubro.Items[cmbRubro.SelectedIndex].ToString());
            prod.OMarca = client_prod.ObtenerMarca(cmbMarca.Items[cmbMarca.SelectedIndex].ToString());
            prod.OTipoTalle = client_prod.ObtenerTipoTalle(cmbTipoTalle.Items[cmbTipoTalle.SelectedIndex].ToString());
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
                //this.Close();
                DialogResult respuesta = msj.MsjInformacion(msgSuccess+"\n Desea cargar una variante del producto?", "MSG-CONSULTA", "CONFIRMAR", "CANCELAR");
                if (respuesta.Equals(DialogResult.OK))
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
                    modoEditar = false;
                    txtCodigo.Focus();
                    msj.Close();
                    groupBoxVariante.Enabled = true;
                    groupBoxProducto.Enabled = false;    

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
            dataGridProductoVenta.Rows.Add(txtCodigo.Text.Trim(), Color, client_t.ObtenerTalle(cmbTalle.Items[cmbTalle.SelectedIndex].ToString()).DescripcionTalle, txtCosto.Text.Trim(), txtCantidad.Text.Trim(), cmbEstadoVariante.SelectedItem.ToString());        
            cmbColor.DisplayMember = "Text";
            cmbColor.ValueMember = "Value";
            cmbColor.SelectedIndex = -1;
            txtCantidad.Text="";
            txtCosto.Text = "";
            cmbColor.Text = "Color";
            cmbTalle.Text = "Talle";
            cmbColor.Focus();
            lblCantidadColores.Text = dataGridProductoVenta.Rows.Count.ToString();


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
            dataGridProductoVenta.Columns.Add("Estado", "Estado");
        }
        private void cmbTipoTalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTalle.Items.Clear();
            using (ServiceTalle.ServiceTalleClient client = new())
            {
                var oListaTalle = client.ListaTalle();
                foreach (var item in oListaTalle)
                {
                    if (item.OEstado.Equals(ServiceTalle.Estado.Activo) && item.OTipoTalle.DescripcionTipoTalle.Equals(cmbTipoTalle.SelectedItem.ToString())) cmbTalle.Items.Add(item.DescripcionTalle);
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
                            TablaProductoVenta.Rows.Add(row.IdProducto, item.OColor.DescripcionColor, item.OTalle.DescripcionTalle, item.Costo, item.Cantidad);
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            dataGridProductoVenta.Rows.RemoveAt(dataGridProductoVenta.CurrentRow.Index);
            //cargarSubtotales();
        }
    }
}
    
