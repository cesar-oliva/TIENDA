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
using ServiceImpuesto;
using ServiceProducto;
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
        ServiceCrudOf_DtoProductoClient client_prod = new();
        FormularioOf_DtoFormProductoClient formulario_prod = new();
        ServiceCrudOf_DtoRubroProductoClient client_Rub = new();
        ServiceCrudOf_DtoMarcaClient client_Marc = new();

        public MtnProducto(DtoProducto pProducto = null)
        {
            InitializeComponent();
            CargarCombosSeleccion();
            groupBoxVariante.Enabled = false;
            var producto = client_prod.Mostrar();
            int IdProducto = producto.Count()+1;
            txtId.Text = IdProducto.ToString();
            if (pProducto != null)
            {
                modoEditar = true;
                txtId.Text = pProducto.IdProducto.ToString();
                txtCodigo.Text = pProducto.CodigoProducto;
                txtDescripcion.Text = pProducto.DescripcionProducto;
                cmbRubro.Text = pProducto.DescripcionRubroProducto.ToString();
                cmbMarca.Text = pProducto.DescripcionMarcaProducto.ToString();
                txtCosto.Text = pProducto.CostoProducto.ToString();
                cmbEstado.Text = pProducto.DescripcionEstado.ToString();
            }
        }
        private void CargarCombosSeleccion()
        {
            groupBoxVariante.Enabled = false;

            var oFormProducto = formulario_prod.GetFormulario();

            foreach (var item in oFormProducto.ListEstado)
            {
                cmbEstado.Items.Add(item);
            }
            cmbEstado.DisplayMember = "Text";
            cmbEstado.ValueMember = "Value";

            foreach (var item in oFormProducto.ListRubroProducto)
            {
                cmbRubro.Items.Add(item);
            }
            cmbRubro.DisplayMember = "Text";
            cmbRubro.ValueMember = "Value";

            foreach (var item in oFormProducto.ListGeneroProducto)
            {
                cmbGenero.Items.Add(item);
            }
            cmbGenero.DisplayMember = "Text";
            cmbGenero.ValueMember = "Value";

            foreach (var item in oFormProducto.ListTipoTalle)
            {
                cmbTipoTalle.Items.Add(item);
            }
            cmbTipoTalle.DisplayMember = "Text";
            cmbTipoTalle.ValueMember = "Value";

            foreach (var item in oFormProducto.ListColor)
            {
                cmbColor.Items.Add(item);
            }
            cmbColor.DisplayMember = "Text";
            cmbColor.ValueMember = "Value";

            foreach (var item in oFormProducto.ListMarcaProducto)
            {
                cmbMarca.Items.Add(item);
            }
            cmbMarca.DisplayMember = "Text";
            cmbMarca.ValueMember = "Value";
        }

        private void Mtn_Producto_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
            dataGridDetalleProducto.AutoResizeColumns();
            dataGridDetalleProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridDetalleProducto.Columns.Add("IdProducto", "IdProducto");
            dataGridDetalleProducto.Columns.Add("Genero", "Genero");
            dataGridDetalleProducto.Columns.Add("TipoTalle", "TipoTalle");
            dataGridDetalleProducto.Columns.Add("Talle", "Talle");
            dataGridDetalleProducto.Columns.Add("Color", "Color");
            dataGridDetalleProducto.Columns.Add("Stock", "Stock");
            dataGridDetalleProducto.Columns.Add("Estado", "Estado");
            dataGridDetalleProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridDetalleProducto.MultiSelect = false;
            dataGridDetalleProducto.ReadOnly = true;
            dataGridDetalleProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridDetalleProducto.AllowUserToAddRows = false;
        }
        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            _ = client_prod.Mostrar();
            DtoProducto prod = new DtoProducto 
            {
                CodigoProducto = txtCodigo.Text.Trim(),
                DescripcionProducto = txtDescripcion.Text.Trim(),
                DescripcionGeneroProducto = cmbGenero.Text.Trim(),
                DescripcionRubroProducto = cmbRubro.Text.Trim(),
                DescripcionMarcaProducto = cmbMarca.Text.Trim(),
                CostoProducto = Convert.ToDouble(txtCosto.Text.Trim()),
                DescripcionEstado = cmbEstado.Text.Trim(),
            };
            
            bool Respuesta;
            string msgSuccess;
            string msgError;
            if (modoEditar)
            {
                prod.IdProducto = Convert.ToInt32(txtId.Text.Trim());
                Respuesta = client_prod.Actualizar(prod);
                msgSuccess = "Producto Modificado exitosamente";
                msgError = "No se pudo modificar el Producto, \nes posible que ya se encuentre registrado";
            }
            else
            {

                Respuesta = client_prod.Registrar(prod);
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
            dataGridDetalleProducto.Rows.Add(txtId.Text.Trim(),cmbGenero.Text.Trim(),cmbTipoTalle.Text.Trim(), cmbTalle.Text.Trim(),cmbColor.Text.Trim(), txtCantidad.Text.Trim(),cmbEstado.Text.Trim());        
            cmbColor.DisplayMember = "Text";
            cmbColor.ValueMember = "Value";
            cmbColor.SelectedIndex = -1;
            txtCantidad.Text="";
            txtCosto.Text = "";
            cmbColor.Text = "Color";
            cmbTalle.Text = "Talle";
            cmbColor.Focus();
            lblCantidadColores.Text = dataGridDetalleProducto.Rows.Count.ToString();


        }
        private void cmbTipoTalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTalle.Items.Clear();
            var oFormProducto = formulario_prod.GetFormulario();

            foreach (var item in oFormProducto.ListTalle)
            {
                if (cmbTipoTalle.Text.ToString().Equals(item.Item1.ToString()))
                {
                    cmbTalle.Items.Add(item.Item2[0].ToString());
                    cmbTalle.DisplayMember = "Text";
                    cmbTalle.ValueMember = "Value";

                }
            }
        }
        private void CargarDatosDetalleProductos()
        {
            var oListaProducto = client_prod.Mostrar();
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
                    if (row.DescripcionEstado.Equals(ServiceProducto.Estado.Activo.ToString()))
                    {
                        //foreach (var item in row.DetallePoducto)
                        //{
                        //    TablaProductoVenta.Rows.Add(row.IdProducto, item.OColor.DescripcionColor, item.OTalle.DescripcionTalle, item.Costo, item.Cantidad);
                        //}
                    }
                }
                dataGridDetalleProducto.DataSource = TablaProductoVenta;
                dataGridDetalleProducto.AutoResizeColumns();
                dataGridDetalleProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridDetalleProducto.Columns["IdProducto"].Visible = false;
                dataGridDetalleProducto.Columns["Color"].Visible = true;
                dataGridDetalleProducto.Columns["Talle"].Visible = true;
                dataGridDetalleProducto.Columns["Costo"].Visible = true;
                dataGridDetalleProducto.Columns["Cantidad"].Visible = true;
    
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            dataGridDetalleProducto.Rows.RemoveAt(dataGridDetalleProducto.CurrentRow.Index);
            //cargarSubtotales();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstado.Text.Equals("Activo"))
            {
                groupBoxVariante.Enabled = true;
            }
            else
            {
                groupBoxVariante.Enabled = false;
            }
            
        }
    }
}
    
