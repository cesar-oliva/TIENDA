using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CapaPresentacion
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Pnl_BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Btn_Producto_Click(object sender, EventArgs e)
        {
            Frm_Contenedor(new FrmProducto());
        }
        private void Btn_Venta_Click(object sender, EventArgs e)
        {
            frmVenta vta = new();
            Frm_Contenedor(vta);
        }
        private void Frm_Contenedor(Object formulario)
        {
            if (this.pnlContenedor.Controls.Count > 0)
                this.pnlContenedor.Controls.RemoveAt(0);
            Form frm = formulario as Form;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(frm);
            this.pnlContenedor.Tag = frm;
            frm.Show();
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            frmMensaje msj = new();
            DialogResult respuesta = msj.MsjInformacion("Desea cerrar la aplicación?","MSG-INFORMACION","CONFIRMAR","CANCELAR");
            if (respuesta.Equals(DialogResult.OK)) Environment.Exit(0); 
        }

        private void Btn_RubroProducto_Click(object sender, EventArgs e)
        {
            Frm_Contenedor(new FrmRubroProducto());
        }

        private void Btn_Cliente_Click(object sender, EventArgs e)
        {
            Frm_Contenedor(new frmCliente());
        }
    }
}
