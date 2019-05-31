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
    public partial class VentanaTest : Form
    {
        ConnectOracle co;
        public VentanaTest()
        {
            InitializeComponent();
            co = new ConnectOracle();
            co.getAsignaturas();
            this.cbAsig.Items.Add("Todos");
            ConnectOracle.AsigList.ForEach(x => this.cbAsig.Items.Add(x.DESCRIPCION));
            this.cbAsig.SelectedIndex = 0;
            RefrescarTabla(cbAsig.SelectedIndex);
        }
        public void RefrescarTabla(int idAsig)
        {
            if (idAsig == 0)
            {
                co.LeerTodosTest();
                tablaTest.DataSource = co.TablaTest;
            }
            else
            {
                co.LeerTodosTest(idAsig);
                tablaTest.DataSource = co.TablaTest;
            }
        }

        private void cbAsig_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarTabla(cbAsig.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarTest at = new AgregarTest();
            at.FormClosed += At_FormClosed;
            at.ShowDialog();
        }

        private void At_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla(cbAsig.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tablaTest.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaTest.Rows[tablaTest.CurrentRow.Index].Cells[3].Value.ToString());
                if (elim == 1)
                {
                    MessageBox.Show("El registro seleccionado ya está eliminado");
                }
                else
                {
                    int idT = int.Parse(tablaTest.Rows[tablaTest.CurrentRow.Index].Cells[0].Value.ToString());
                    EliminarRegistro eu = new EliminarRegistro("TEST", "ID_TEST", idT);
                    eu.FormClosed += Eu_FormClosed;
                    eu.ShowDialog();
                }
            }
        }

        private void Eu_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla(cbAsig.SelectedIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tablaTest.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaTest.Rows[tablaTest.CurrentRow.Index].Cells[3].Value.ToString());
                if (elim == 0)
                {
                    MessageBox.Show("El registro seleccionado no está eliminado");
                }
                else
                {
                    int idT = int.Parse(tablaTest.Rows[tablaTest.CurrentRow.Index].Cells[0].Value.ToString());
                    RestaurarRegistro ru = new RestaurarRegistro("TEST", "ID_TEST", idT);
                    ru.FormClosed += Ru_FormClosed;
                    ru.ShowDialog();
                }
            }
        }

        private void Ru_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla(cbAsig.SelectedIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaTest.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int idTest = int.Parse(tablaTest.Rows[tablaTest.CurrentRow.Index].Cells[0].Value.ToString());
                AgregarPreguntasATest apt = new AgregarPreguntasATest(idTest);
                apt.FormClosed += Apt_FormClosed;
                apt.ShowDialog();
            }
        }

        private void Apt_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla(cbAsig.SelectedIndex);
        }
    }
}
