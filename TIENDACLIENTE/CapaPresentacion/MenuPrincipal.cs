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
            customizeDesing();
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
            Frm_Contenedor(new frmVenta());
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
            if (MessageBox.Show("¿Estas Seguro de cerrar el programa?", "¡Alerta!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Contenedor(new FrmRubroProducto());
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            Frm_Contenedor(new frmCliente());
        }
        private void customizeDesing()
        {
            panelSubMenuProducto.Visible = false;
            panelSubMenuClientes.Visible = false;   
            panelSubMenuRubros.Visible = false; 
            panelSubMenuVentas.Visible = false; 
        }
        private void hideSubMenu()
        {
            if (panelSubMenuProducto.Visible == true)
                panelSubMenuProducto.Visible = false;
            if (panelSubMenuRubros.Visible == true)
                panelSubMenuRubros.Visible = false;
            if (panelSubMenuClientes.Visible == true)
                panelSubMenuClientes.Visible = false;
            if (panelSubMenuVentas.Visible == true)
                panelSubMenuVentas.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true; 
            }
            else
                subMenu.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuProducto);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MtnProducto mtnprod = new();
            mtnprod.ShowDialog();
            hideSubMenu();  
        }

        private void Btn_Producto_Click_1(object sender, EventArgs e)
        {
            Frm_Contenedor(new FrmProducto());
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mtnRubroProducto mtnrubprod = new();
            mtnrubprod.ShowDialog();
            hideSubMenu();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuRubros);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuClientes);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mtnCliente mtnclient = new();
            mtnclient.ShowDialog();
            hideSubMenu();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Frm_Contenedor(new frmCliente());
            hideSubMenu();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Frm_Contenedor(new FrmRubroProducto());
            hideSubMenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuVentas);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Frm_Contenedor(new frmVenta());
            hideSubMenu();
        }
    }
}
