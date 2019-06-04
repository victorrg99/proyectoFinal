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

namespace ProyectoFinal_ERP_Academia.Views.ZonaAlumnos
{
    public partial class VentanaSelecTest : Form
    {
        ConnectOracle co;
        int idA;
        public VentanaSelecTest(int al)
        {
            InitializeComponent();
            co = new ConnectOracle();
            this.idA = al;
            MessageBox.Show(""+idA);
            RefrescarTabla();
        }
        public void RefrescarTabla()
        {
            co.LeerTestCompletos();
            tablaTestDisponibles.DataSource = co.TablaTest;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tablaTestDisponibles.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int idT = int.Parse(tablaTestDisponibles.Rows[tablaTestDisponibles.CurrentRow.Index].Cells[0].Value.ToString());
                VentanaHacerTest vht = new VentanaHacerTest(idT,idA);
                vht.FormClosed += Vht_FormClosed;
                vht.ShowDialog();
            }
        }

        private void Vht_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }
    }
}
