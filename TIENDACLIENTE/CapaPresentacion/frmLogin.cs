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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            while (true)
            {
                if (txtNombreUsuario.Text.Trim() == "")
                {
                    lblUsuario.Text = "El campo usuario no puede estar vacio";
                    lblUsuario.Visible = true;
                    break;
                }
                if (txtContraseña.Text.Trim() == "")
                {
                    lblMensajeLogin.Text = "El campo contraseña no puede estar vacio";
                    lblMensajeLogin.Visible = true;
                    break;
                }
                else
                {
                    using (ServiceUsuario.ServiceUsuarioClient client = new ServiceUsuario.ServiceUsuarioClient())
                    {
                        bool respuesta = false;
                        string NombreUsuario = txtNombreUsuario.Text.Trim(); ;
                        string Clave = txtContraseña.Text.Trim();
                        respuesta = client.LoginUsuario(NombreUsuario, Clave);
                        if (respuesta == true)
                        {                       
                            frmBienvenida frm = new frmBienvenida();
                            frm.Show();
                            this.Visible = false;
                            break;

                        }
                        else
                        {
                            txtNombreUsuario.ResetText();
                            txtContraseña.ResetText();
                            lblMensajeLogin.Text = "Usuario o Contraseña mal ingresados";
                            lblMensajeLogin.Visible = true;
                            break;
                        }

                    }
                }
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            while (true)
            {
                if (txtNombreUsuario.Text.Trim() == "")
                {
                    lblUsuario.Text="Debe ingresar el nombre del usuario";
                    lblUsuario.Visible = true;
                    break;
                }
                using (ServiceUsuario.ServiceUsuarioClient client = new ServiceUsuario.ServiceUsuarioClient())
                {
                    string NombreUsuario = txtNombreUsuario.Text.Trim(); ;
                    client.RecuperarContraseña(NombreUsuario);
                    break;
                }
            }
        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {
            lblMensajeLogin.ResetText();
            lblUsuario.ResetText();
        }
    }
}
