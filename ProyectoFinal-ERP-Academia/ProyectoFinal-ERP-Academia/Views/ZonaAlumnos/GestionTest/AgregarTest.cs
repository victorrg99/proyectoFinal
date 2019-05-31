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

namespace ProyectoFinal_ERP_Academia.Views.ZonaAlumnos.GestionTest
{
    public partial class AgregarTest : Form
    {
        ConnectOracle co;
        int idA;
        int dif;
        public AgregarTest()
        {
            InitializeComponent();
            co = new ConnectOracle();
            co.getAsignaturas();
            ConnectOracle.AsigList.ForEach(x => this.cbAsig.Items.Add(x.DESCRIPCION));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cbAsig.SelectedIndex >= 0)
            {
                if (cbDif.SelectedIndex >= 0)
                {
                    idA = cbAsig.SelectedIndex + 1;
                    dif = int.Parse(cbDif.SelectedItem.ToString());
                    co.AgregarTest(idA, dif);
                    MessageBox.Show("Test creado con exito");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Debes seleccionar una dificultad primero");
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar una asignatura primero");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
