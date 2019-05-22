using ProyectoFinal_ERP_Academia.Conexion;
using ProyectoFinal_ERP_Academia.Util.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_ERP_Academia.Views
{
    public partial class InicioSesion : Form
    {
        String usuario;
        String clave;
        ConnectOracle co;
        Form1 ventanaPrincipal;
        public InicioSesion()
        {
            InitializeComponent();
            co = new ConnectOracle();
        }

        private void btInSes_Click(object sender, EventArgs e)
        {
            if (!Util.Util.validarNombreApellido(tbUsuario.Text))
            {
                MessageBox.Show("Formato del USUARIO inválido");
            }
            else
            {
                usuario = tbUsuario.Text;
                clave = tbClave.Text;
                Boolean inicioSesion = co.IniciarSesion(usuario, clave);
                if (inicioSesion)
                {
                    ventanaPrincipal = new Form1(usuario);
                    ventanaPrincipal.Show();
                    ventanaPrincipal.FormClosed += VentanaPrincipal_FormClosed;
                }
                else
                {
                    MessageBox.Show("Datos Incorrectos - Prueba Otra Vez");
                }
            }
        }

        private void VentanaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btCnl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
