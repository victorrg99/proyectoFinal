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

namespace ProyectoFinal_ERP_Academia.Views.ZonaAlumnos.GestionPreguntas
{
    public partial class VentanaPreguntas : Form
    {
        ConnectOracle co;
        public VentanaPreguntas()
        {
            InitializeComponent();
            co = new ConnectOracle();
            RefrescarTabla();
        }
        public void RefrescarTabla()
        {
            co.LeerTodasPreguntas();
            tablaPreguntas.DataSource = co.TablaPreguntas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarPregunta ap = new AgregarPregunta();
            ap.FormClosed += Ap_FormClosed;
            ap.ShowDialog();
        }

        private void Ap_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefrescarTabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaPreguntas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int id = int.Parse(tablaPreguntas.Rows[tablaPreguntas.CurrentRow.Index].Cells[0].Value.ToString());
                ModificarPregunta mp = new ModificarPregunta(id);
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
            if (tablaPreguntas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaPreguntas.Rows[tablaPreguntas.CurrentRow.Index].Cells[7].Value.ToString());
                if (elim == 1)
                {
                    MessageBox.Show("El registro seleccionado ya está eliminado");
                }
                else
                {
                    int idP = int.Parse(tablaPreguntas.Rows[tablaPreguntas.CurrentRow.Index].Cells[0].Value.ToString());
                    EliminarRegistro eu = new EliminarRegistro("PREGUNTAS", "ID_PREGUNTA", idP);
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
            if (tablaPreguntas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una fila primero");
            }
            else
            {
                int elim = int.Parse(tablaPreguntas.Rows[tablaPreguntas.CurrentRow.Index].Cells[7].Value.ToString());
                if (elim == 0)
                {
                    MessageBox.Show("El registro seleccionado no está eliminado");
                }
                else
                {
                    int idP = int.Parse(tablaPreguntas.Rows[tablaPreguntas.CurrentRow.Index].Cells[0].Value.ToString());
                    RestaurarRegistro ru = new RestaurarRegistro("PREGUNTAS", "ID_PREGUNTA", idP);
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
