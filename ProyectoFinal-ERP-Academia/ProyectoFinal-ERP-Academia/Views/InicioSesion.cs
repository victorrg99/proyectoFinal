using ProyectoFinal_ERP_Academia.Conexion;
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
        String dni;
        String nombre;
        String clave;
        ConnectOracle co;
        Form1 ventanaPrincipal;
        public InicioSesion()
        {
            InitializeComponent();
            co = new ConnectOracle();
            ventanaPrincipal = new Form1();
        }

        private void btInSes_Click(object sender, EventArgs e)
        {
            if (!Util.Util.validarDNI(tbDNI.Text))
            {
                MessageBox.Show("Formato del DNI inválido");
            }
            else
            {
                if (!Util.Util.validarNombreApellido(tbNombre.Text))
                {
                    MessageBox.Show("Formato del NOMBRE inválido");
                }
                else
                {
                    dni = tbDNI.Text;
                    nombre = tbNombre.Text;
                    clave = tbClave.Text;
                    Boolean inicioSesion = co.IniciarSesion(dni, nombre, clave);
                    if (inicioSesion)
                    {
                       ventanaPrincipal.Show();
                       ventanaPrincipal.FormClosed += VentanaPrincipal_FormClosed;
                    }
                    else
                    {
                        MessageBox.Show("Datos Incorrectos - Prueba Otra Vez");
                    }
                    
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
