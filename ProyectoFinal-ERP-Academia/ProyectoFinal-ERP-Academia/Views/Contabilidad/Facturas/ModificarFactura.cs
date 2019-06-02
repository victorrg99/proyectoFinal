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

namespace ProyectoFinal_ERP_Academia.Views.Contabilidad.Facturas
{
    public partial class ModificarFactura : Form
    {
        ConnectOracle co;
        Alumno al = new Alumno();
        int idAlum;
        int idU;
        float cantidad;
        Factura f = new Factura();
        public ModificarFactura(int idF)
        {
            InitializeComponent();
            co = new ConnectOracle();
            f = co.buscarFactura(idF);
            tbCant.Text = f.cantidadSinImpuesto.ToString();
            cbAlum.Items.Clear();
            co.getAlumnos();
            ConnectOracle.AlumList.ForEach(x => this.cbAlum.Items.Add(x.DNI));
            cbAlum.SelectedIndex = f.idAlumno -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbAlum.SelectedIndex >= 0)
            {
                if (Util.Util.validarCantidad(tbCant.Text))
                {
                    idAlum = cbAlum.SelectedIndex + 1;
                    idU = f.idUsuario;
                    cantidad = float.Parse(tbCant.Text.Replace(".", ","));
                    co.ModificarFactura(f.id,idU, idAlum, cantidad);
                    MessageBox.Show("Factura modificada con éxito");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Formato de cantidad inválido");
                }
            }
            else
            {
                MessageBox.Show("Tienes que seleccionar un alumno primero");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
