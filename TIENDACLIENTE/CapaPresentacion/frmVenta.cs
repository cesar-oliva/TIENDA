using ServiceCliente;
using ServiceHomologacionAfip;
using ServiceProducto;
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
    public partial class frmVenta : Form
    {
        DataTable TablaDetalleProducto = new();
        int id = 0;
        public frmVenta()
        {
            InitializeComponent();
            //CargarDatosProductos();
            dataGridLineaVenta.AutoResizeColumns();
            dataGridLineaVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridLineaVenta.Columns.Add("NºdeLinea", "NºdeLinea");
            dataGridLineaVenta.Columns.Add("Codigo", "Codigo");
            dataGridLineaVenta.Columns.Add("Descripcion", "Descripcion");
            dataGridLineaVenta.Columns.Add("PrecioVenta","PrecioVenta");
            dataGridLineaVenta.Columns.Add("IVA", "IVA");
            dataGridLineaVenta.Columns.Add("Cantidad","Cantidad");
            dataGridLineaVenta.Columns.Add("TotalLinea","TotalLinea");
            using ServiceCliente.ServiceClienteClient client = new();
            var oListaCliente = client.ListaCliente();
            foreach (var item in oListaCliente)
            {
                if (mtxtCuit.Text.Trim().ToString().Equals(item.Cuit.ToString()))
                {
                    txtRazonSocial.Text = item.RazonSocial.ToString();
                    txtDomicilio.Text = item.DomicilioFiscal.ToString();
                    txtCondicion.Text = item.OCondicionTributaria.CodigoCondicionTributaria.ToString();
                }
            }

        }
        private void mtxtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            using ServiceCliente.ServiceClienteClient client = new();
            var oListaCliente = client.ListaCliente();
            bool bandera = false;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                foreach (var item in oListaCliente)
                {
                    if (mtxtCuit.Text.Trim().ToString().Equals(item.Cuit.ToString()))
                    {
                        txtRazonSocial.Text = item.RazonSocial.ToString();
                        txtDomicilio.Text = item.DomicilioFiscal.ToString();
                        txtCondicion.Text = item.OCondicionTributaria.CodigoCondicionTributaria.ToString();
                        bandera = true;
                        txtCodigo.Focus();
                    }
                }
                if (bandera == false)
                {
                    MessageBox.Show("El Cuit ingresado no corresponde a un Cliente activo");
                    mtxtCuit.Text = "00-00000000-0";
                    foreach (var item in oListaCliente)
                    {
                        if (mtxtCuit.Text.Trim().ToString().Equals(item.Cuit.ToString()))
                        {
                            txtRazonSocial.Text = item.RazonSocial.ToString();
                            txtDomicilio.Text = item.DomicilioFiscal.ToString();
                            txtCondicion.Text = item.OCondicionTributaria.CodigoCondicionTributaria.ToString();
                            bandera = true;
                            txtCodigo.Focus();
                        }
                    }
                }
            }
        }
        private void txtCuit_Click(object sender, EventArgs e)
        {
            mtxtCuit.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmDetalleProducto fdp = new();
            fdp.ShowDialog();   
        }

        private void txtCuit_TextChanged(object sender, EventArgs e)
        {

        }

        private void mtxtCuit_MouseClick(object sender, MouseEventArgs e)
        {
            mtxtCuit.Focus();
            mtxtCuit.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmCliente fdc = new();
            fdc.ShowDialog();   
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            using ServiceProducto.ServiceProductoClient client = new();
            using ServiceRubroProducto.ServiceRubroProductoClient client_rub = new();
            var oListaProducto = client.ListaProducto();
            bool bandera = false;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                foreach (var item in oListaProducto)
                {
                    foreach (var pv in item.OProductoVenta)
                    {
                        if (txtCodigo.Text.Trim().ToString().Equals(item.CodigoProducto.ToString()))
                        {
                            txtDescripcion.Text = item.DescripcionProducto.ToString();
                            txtPrecioVenta.Text = Convert.ToString((pv.Costo * (((client_rub.ObtenerRubroProductoById(item.ORubroProducto.IdRubroProducto).MargenGanancia) / 100) + 1)));
                            txtStock.Text = "25";
                            bandera = true;
                            txtCantidad.Focus();
                            id = client_rub.ObtenerRubroProductoById(item.ORubroProducto.IdRubroProducto).OImpuesto.IdImpuesto;
                        }
                    }
                }
                if (bandera == false)
                {
                    MessageBox.Show("El Codigo ingresado no corresponde a un Producto activo");
                    txtCodigo.Text = "";
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using ServiceRubroProducto.ServiceRubroProductoClient client_rub = new();
            dataGridLineaVenta.Rows.Add(Convert.ToString(dataGridLineaVenta.Rows.Count), txtCodigo.Text.Trim(), txtDescripcion.Text.Trim(), txtPrecioVenta.Text.Trim(), client_rub.ObtenerImpuestoById(id).Alicuota.ToString(), txtCantidad.Text.Trim(), Convert.ToString(Convert.ToDouble(txtPrecioVenta.Text.Trim()) * Convert.ToInt32(txtCantidad.Text.Trim())));
            lblCantidad.Text = Convert.ToString(dataGridLineaVenta.Rows.Count - 1);
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtPrecioVenta.Text = "";
            txtStock.Text = "";
            txtCantidad.Text = "";
            txtCodigo.Focus();
            cargarSubtotales();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            dataGridLineaVenta.Rows.RemoveAt(dataGridLineaVenta.CurrentRow.Index);
            cargarSubtotales();
        }
        private void cargarSubtotales()
        {
            double suma = 0;
            double IVA = 0;
            foreach (DataGridViewRow row in dataGridLineaVenta.Rows)
            {
                suma += Convert.ToDouble(row.Cells[6].Value);
                IVA += (Convert.ToDouble(row.Cells[4].Value) / 100) * Convert.ToDouble(row.Cells[6].Value);
            }
            double total = suma + IVA;
            txtSubtotal.Text = suma.ToString();
            txtIVA.Text = IVA.ToString();
            txtTotal.Text = total.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using ServiceWrapper.LoginServiceClient client = new();
            var autorizacion = client.SolicitarAutorizacionAsync("EE6477E1-4BB2-4667-B3D0-C71F67AFED36").Result;
            using ServiceSoapClient clientAfip = new(ServiceSoapClient.EndpointConfiguration.ServiceSoap);

            //Autorización WSAA, firma y token
            var authRequest = new FEAuthRequest()
            {
                Cuit = autorizacion.Cuit,
                Token = autorizacion.Token,
                Sign = autorizacion.Sign
            };

            //Cabecera
            var cabecera = new FECAECabRequest()
            {
                CantReg = 1, // cantidad de registros del detalle del comprobante de ingreso
                CbteTipo = 1, //Factura A
                PtoVta = 6 //Punto de venta del comprobante que se está informando
            };

            //Alicuotas
            var alicuota = new AlicIva()
            {
                Id = 5, //código de tipo de iva. 5 -> 21%
                BaseImp = Convert.ToDouble(100),//base imponible para la determinación de la alícuota
                Importe = Convert.ToDouble(21),//importe
            };

            //Detalle
            int lastRes = clientAfip.FECompUltimoAutorizadoAsync(authRequest, cabecera.PtoVta, 1).Result.Body.FECompUltimoAutorizadoResult.CbteNro;
            var detalle = new FECAEDetRequest()
            {
                Concepto = 1, //Concepto del comprobante. 1 -> Productos
                DocTipo = 80, //Código de documento identificatorio del comprador. 80 -> CUIT
                DocNro = 20331441112, // nro de identificacion del comprador
                CbteDesde = lastRes + 1, // nro de comprobante desde. Rango: 1-99999999
                CbteHasta = lastRes + 1, // nro de comprobante hasta. Rango: 1-99999999
                CbteFch = DateTime.Now.ToString("yyyyMMdd"), //"20220111"; 
                ImpTotal = Convert.ToDouble(121), // Importe total del comprobante
                ImpTotConc = 0, // importe neto no gravado
                ImpNeto = Convert.ToDouble(100), // importe neto gravado
                ImpOpEx = 0, // importe exento
                ImpIVA = Convert.ToDouble(21), //suma de los importes del array de IVA 
                ImpTrib = Convert.ToDouble(0), //suma de los importes del array de tributos 
                FchServDesde = "",
                FchServHasta = "",
                FchVtoPago = "",
                MonId = "PES", // código de moneda del comprobante
                MonCotiz = 1, // cotización de la moneda
                Iva = new AlicIva[] { alicuota }
            };

            //Definición de la factura
            var caeRequest = new FECAERequest()
            {
                FeDetReq = new FECAEDetRequest[] { detalle },
                FeCabReq = cabecera //Asigno a la cabecera de la factura
            };

            var response = clientAfip.FECAESolicitarAsync(authRequest, caeRequest).Result;
            if (response.Body.FECAESolicitarResult.FeCabResp.Resultado.Equals("A"))
            {
                MessageBox.Show("factura de venta aprobada");
                frmMedioPago frm = new();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("la factura de venta no fue aprobada");
            }
            
        }
    }

}
