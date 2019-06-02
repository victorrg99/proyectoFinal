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

namespace ProyectoFinal_ERP_Academia.Views.Matriculas
{
    public partial class VentanaMatriculas : Form
    {
        ConnectOracle co;
        public VentanaMatriculas()
        {
            InitializeComponent();
            co = new ConnectOracle();
            RefrescarTabla();
        }

        private void RefrescarTabla()
        {
            co.LeerTodasMatriculas();
            tablaMatriculas.DataSource = co.TablaMatriculas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearMatricula cm = new CrearMatricula();
            cm.FormClosed += Cm_FormClosed;
            cm.ShowDialog();
        }

        private void Cm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaMatriculas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int idM = int.Parse(tablaMatriculas.Rows[tablaMatriculas.CurrentRow.Index].Cells[0].Value.ToString());
                ModificarMatricula mm = new ModificarMatricula(idM);
                mm.FormClosed += Mm_FormClosed;
                mm.ShowDialog();
            }
            
        }

        private void Mm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tablaMatriculas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaMatriculas.Rows[tablaMatriculas.CurrentRow.Index].Cells[5].Value.ToString());
                if (elim == 1)
                {
                    MessageBox.Show("El registro seleccionado ya está eliminado");
                }
                else
                {
                    int idP = int.Parse(tablaMatriculas.Rows[tablaMatriculas.CurrentRow.Index].Cells[0].Value.ToString());
                    EliminarRegistro eu = new EliminarRegistro("MATRICULAS", "ID_MATRICULA", idP);
                    eu.FormClosed += Eu_FormClosed;
                    eu.ShowDialog();
                }
            }
        }

        private void Eu_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tablaMatriculas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaMatriculas.Rows[tablaMatriculas.CurrentRow.Index].Cells[5].Value.ToString());
                if (elim == 0)
                {
                    MessageBox.Show("El registro seleccionado no está eliminado");
                }
                else
                {
                    int idP = int.Parse(tablaMatriculas.Rows[tablaMatriculas.CurrentRow.Index].Cells[0].Value.ToString());
                    RestaurarRegistro ru = new RestaurarRegistro("MATRICULAS", "ID_MATRICULA", idP);
                    ru.FormClosed += Ru_FormClosed;
                    ru.ShowDialog();
                }
            }
        }

        private void Ru_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }
    }
}
