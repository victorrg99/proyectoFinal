using ProyectoFinal_ERP_Academia.Conexion;
using ProyectoFinal_ERP_Academia.Views.Organización.Alumnos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_ERP_Academia.Views.Organización.Profesores
{
    public partial class VentanaProfesor : Form
    {
        ConnectOracle co;
        public VentanaProfesor()
        {
            InitializeComponent();
            co = new ConnectOracle();
            RefrescarTabla();
        }
        private void RefrescarTabla()
        {
            co.LeerTodosProfesores();
            tablaProfesores.DataSource = co.TablaProfesores;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaProfesores.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int idP = int.Parse(tablaProfesores.Rows[tablaProfesores.CurrentRow.Index].Cells[0].Value.ToString());
                ModificarProfesor mp = new ModificarProfesor(idP);
                mp.FormClosed += Mp_FormClosed;
                mp.ShowDialog();
            }
        }

        private void Mp_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tablaProfesores.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaProfesores.Rows[tablaProfesores.CurrentRow.Index].Cells[6].Value.ToString());
                if (elim == 1)
                {
                    MessageBox.Show("El usuario seleccionado ya está eliminado");
                }
                else
                {
                    int idP = int.Parse(tablaProfesores.Rows[tablaProfesores.CurrentRow.Index].Cells[0].Value.ToString());
                    EliminarRegistro eu = new EliminarRegistro("PROFESORES", "ID_PROFESOR", idP);
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
            if (tablaProfesores.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaProfesores.Rows[tablaProfesores.CurrentRow.Index].Cells[6].Value.ToString());
                if (elim == 0)
                {
                    MessageBox.Show("El usuario seleccionado no está eliminado");
                }
                else
                {
                    int idP = int.Parse(tablaProfesores.Rows[tablaProfesores.CurrentRow.Index].Cells[0].Value.ToString());
                    RestaurarRegistro ru = new RestaurarRegistro("PROFESORES", "ID_PROFESOR", idP);
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
