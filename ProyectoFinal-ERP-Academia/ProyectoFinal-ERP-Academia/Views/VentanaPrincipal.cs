using ProyectoFinal_ERP_Academia.Conexion;
using ProyectoFinal_ERP_Academia.Util.Clases;
using ProyectoFinal_ERP_Academia.Views;
using ProyectoFinal_ERP_Academia.Views.Contabilidad.Abonos;
using ProyectoFinal_ERP_Academia.Views.Contabilidad.Facturas;
using ProyectoFinal_ERP_Academia.Views.Contabilidad.Transacciones;
using ProyectoFinal_ERP_Academia.Views.Matriculas;
using ProyectoFinal_ERP_Academia.Views.Organización.Alumnos;
using ProyectoFinal_ERP_Academia.Views.Organización.Asignaturas;
using ProyectoFinal_ERP_Academia.Views.Organización.Aulas;
using ProyectoFinal_ERP_Academia.Views.Organización.Grupos;
using ProyectoFinal_ERP_Academia.Views.Organización.Profesores;
using ProyectoFinal_ERP_Academia.Views.Usuarios;
using ProyectoFinal_ERP_Academia.Views.ZonaAlumnos.GestionPreguntas;
using ProyectoFinal_ERP_Academia.Views.ZonaAlumnos.GestionTest;
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
        
        public Form1(int id)
        {
            InitializeComponent();
            co = new ConnectOracle();
            usuarioConectado = co.buscarUsuario(id);
            label1.Text = usuarioConectado.USUARIO;            
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

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaAlumnos va = new VentanaAlumnos();
            va.MdiParent = this;
            va.Activate();
            va.Show();
        }

        private void profesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaProfesor vp = new VentanaProfesor();
            vp.MdiParent = this;
            vp.Activate();
            vp.Show();
        }

        private void asignaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaAsignaturas vas = new VentanaAsignaturas();
            vas.MdiParent = this;
            vas.Activate();
            vas.Show();
        }

        private void aulasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaAulas vau = new VentanaAulas();
            vau.MdiParent = this;
            vau.Activate();
            vau.Show();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarClave cc = new CambiarClave(usuarioConectado.Id);
            cc.MdiParent = this;
            cc.Activate();
            cc.Show();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaGrupos vgs = new VentanaGrupos();
            vgs.MdiParent = this;
            vgs.Activate();
            vgs.Show();
        }

        private void ventanaPreguntasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaPreguntas vp = new VentanaPreguntas();
            vp.MdiParent = this;
            vp.Activate();
            vp.Show();
        }

        private void ventanaTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaTest vt = new VentanaTest();
            vt.MdiParent = this;
            vt.Activate();
            vt.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaFacturas vf = new VentanaFacturas(usuarioConectado.Id);
            vf.MdiParent = this;
            vf.Activate();
            vf.Show();
        }

        private void abonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaAbonos vab = new VentanaAbonos();
            vab.MdiParent = this;
            vab.Activate();
            vab.Show();
        }

        private void transaccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaTransacciones vts = new VentanaTransacciones();
            vts.MdiParent = this;
            vts.Activate();
            vts.Show();
        }
    }
}
