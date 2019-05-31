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

namespace ProyectoFinal_ERP_Academia.Views.ZonaAlumnos.GestionTest
{
    public partial class AgregarPreguntasATest : Form
    {
        ConnectOracle co;
        Test test;
        public AgregarPreguntasATest(int idT)
        {
            InitializeComponent();
            co = new ConnectOracle();
            test = co.buscarTest(idT);
            RefrescarTabla();
        }
        public void RefrescarTabla()
        {
            co.LeerTodasPreguntasDeAsignatura(test.idAsignatura);
            tablaPreguntas.DataSource = co.TablaPreguntas;

            co.LeerTodasPreguntasDeTest(test.idTest);
            tablaPregTest.DataSource = co.TablaTestPreg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tablaPreguntas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una pregunta primero");
            }
            else
            {
                int idPreg = int.Parse(tablaPreguntas.Rows[tablaPreguntas.CurrentRow.Index].Cells[0].Value.ToString());
                if (!co.BuscarTestPregunta(test.idTest, idPreg))
                {
                    if (!co.TestCompleto(test.idTest))
                    {
                        co.AgregarTestPregunta(test.idTest, idPreg);
                        RefrescarTabla();
                    }
                    else
                    {
                        MessageBox.Show("El test está completo, no puedes añadir más preguntas");
                    }
                }
                else
                {
                    MessageBox.Show("El test ya contiene esta pregunta");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaPregTest.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar una pregunta primero");
            }
            else
            {
                int idPreg = int.Parse(tablaPregTest.Rows[tablaPregTest.CurrentRow.Index].Cells[0].Value.ToString());
                co.EliminarTestPregunta(test.idTest,idPreg);
                RefrescarTabla();
            }
        }
    }
}
