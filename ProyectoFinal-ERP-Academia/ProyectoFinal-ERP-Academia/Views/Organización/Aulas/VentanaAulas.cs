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

namespace ProyectoFinal_ERP_Academia.Views.Organización.Aulas
{
    public partial class VentanaAulas : Form
    {
        ConnectOracle co;
        public VentanaAulas()
        {
            InitializeComponent();
            co = new ConnectOracle();
            RefrescarTabla();
        }

        public void RefrescarTabla()
        {
            co.LeerTodasAulas();
            tablaAulas.DataSource = co.TablaAulas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarAula aa = new AgregarAula();
            aa.FormClosed += Aa_FormClosed;
            aa.ShowDialog();
        }

        private void Aa_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaAulas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int idA = int.Parse(tablaAulas.Rows[tablaAulas.CurrentRow.Index].Cells[0].Value.ToString());
                ModificarAula ma = new ModificarAula(idA);
                ma.FormClosed += Ma_FormClosed;
                ma.ShowDialog();
            }
        }

        private void Ma_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tablaAulas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaAulas.Rows[tablaAulas.CurrentRow.Index].Cells[3].Value.ToString());
                if (elim == 1)
                {
                    MessageBox.Show("El registro seleccionado ya está eliminado");
                }
                else
                {
                    int idP = int.Parse(tablaAulas.Rows[tablaAulas.CurrentRow.Index].Cells[0].Value.ToString());
                    EliminarRegistro eu = new EliminarRegistro("AULAS", "ID_AULA", idP);
                    eu.FormClosed += Eu_FormClosed;
                    eu.ShowDialog();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tablaAulas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaAulas.Rows[tablaAulas.CurrentRow.Index].Cells[3].Value.ToString());
                if (elim == 0)
                {
                    MessageBox.Show("El registro seleccionado no está eliminado");
                }
                else
                {
                    int idP = int.Parse(tablaAulas.Rows[tablaAulas.CurrentRow.Index].Cells[0].Value.ToString());
                    RestaurarRegistro ru = new RestaurarRegistro("AULAS", "ID_AULA", idP);
                    ru.FormClosed += Ru_FormClosed;
                    ru.ShowDialog();
                }
            }
        }

        private void Ru_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void Eu_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }
    }
}
