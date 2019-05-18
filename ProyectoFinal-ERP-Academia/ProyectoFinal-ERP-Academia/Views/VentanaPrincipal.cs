using ProyectoFinal_ERP_Academia.Conexion;
using ProyectoFinal_ERP_Academia.Util.Clases;
using ProyectoFinal_ERP_Academia.Views;
using ProyectoFinal_ERP_Academia.Views.Matriculas;
using ProyectoFinal_ERP_Academia.Views.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_ERP_Academia
{
    public partial class Form1 : Form
    {
        Usuario usuarioConectado;
        ConnectOracle co;
        
        public Form1(String dni)
        {
            InitializeComponent();
            co = new ConnectOracle();
            usuarioConectado = co.buscarUsuario(dni);
            label1.Text = usuarioConectado.NOMBRE+ " "+ usuarioConectado.APELLIDO;
            //usuariosToolStripMenuItem1.Visible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VentanaUsuario us = new VentanaUsuario();
            us.ShowDialog();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VentanaUsuario us = new VentanaUsuario();
            us.MdiParent = this;
            us.Activate();
            us.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaSalir vs = new VentanaSalir();
            vs.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            VentanaUsuario us = new VentanaUsuario();
            us.MdiParent = this;
            us.Activate();
            us.Show();
        }

        private void matrículasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VentanaMatriculas vm = new VentanaMatriculas();
            vm.MdiParent = this;
            vm.Activate();
            vm.Show();
        }

        private void verResultadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
