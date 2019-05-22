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

namespace ProyectoFinal_ERP_Academia.Views.Organización.Alumnos
{
    public partial class VentanaAlumnos : Form
    {
        ConnectOracle co;
        public VentanaAlumnos()
        {
            InitializeComponent();
            co = new ConnectOracle();
            RefrescarTabla();
        }
        private void RefrescarTabla()
        {
            co.LeerTodosAlumnos();
            tablaAlumnos.DataSource = co.TablaAlumnos;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaAlumnos.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int idA = int.Parse(tablaAlumnos.Rows[tablaAlumnos.CurrentRow.Index].Cells[0].Value.ToString());
                ModificarAlumno ma = new ModificarAlumno(idA);
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
            if (tablaAlumnos.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaAlumnos.Rows[tablaAlumnos.CurrentRow.Index].Cells[5].Value.ToString());
                if (elim == 1)
                {
                    MessageBox.Show("El usuario seleccionado ya está eliminado");
                }
                else
                {
                    int idA = int.Parse(tablaAlumnos.Rows[tablaAlumnos.CurrentRow.Index].Cells[0].Value.ToString());
                    EliminarRegistro eu = new EliminarRegistro("ALUMNOS", "ID_ALUMNO", idA);
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
            if (tablaAlumnos.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaAlumnos.Rows[tablaAlumnos.CurrentRow.Index].Cells[5].Value.ToString());
                if (elim == 0)
                {
                    MessageBox.Show("El usuario seleccionado no está eliminado");
                }
                else
                {
                    int idA = int.Parse(tablaAlumnos.Rows[tablaAlumnos.CurrentRow.Index].Cells[0].Value.ToString());
                    RestaurarRegistro ru = new RestaurarRegistro("ALUMNOS", "ID_ALUMNO", idA);
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
