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

namespace ProyectoFinal_ERP_Academia.Views.Organización.Grupos
{
    public partial class AgregarAlumnosAGrupo : Form
    {
        ConnectOracle co;
        Grupo grupo;
        public AgregarAlumnosAGrupo(int idG)
        {
            InitializeComponent();
            co = new ConnectOracle();
            grupo = co.buscarGrupo(idG);
            RefrescarTabla();
        }
        public void RefrescarTabla()
        {
            
            co.LeerTodosAlumnos();
            tablaPreguntas.DataSource = co.TablaAlumnos;

            co.LeerTodosAlumnosDeGrupo(grupo.id);
            tablaPregTest.DataSource = co.TablaGrupAlumno;
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            if (tablaPreguntas.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar un alumno primero");
            }
            else
            {
                int idAl = int.Parse(tablaPreguntas.Rows[tablaPreguntas.CurrentRow.Index].Cells[0].Value.ToString());
                if (!co.BuscarAlumnoGrupo(idAl,grupo.id))
                {
                    if (!co.GrupoCompleto(grupo.id))
                    {
                        co.AgregarAlumnoGrupo(idAl,grupo.id);
                        RefrescarTabla();
                    }
                    else
                    {
                        MessageBox.Show("El grupo está completo, no puedes añadir más alumnos");
                    }
                }
                else
                {
                    MessageBox.Show("El grupo ya contiene este alumno");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaPregTest.RowCount <= 0)
            {
                MessageBox.Show("Debes seleccionar un alumno primero");
            }
            else
            {
                int idAl = int.Parse(tablaPregTest.Rows[tablaPregTest.CurrentRow.Index].Cells[0].Value.ToString());
                co.EliminarAlumnoGrupo(idAl,grupo.id);
                RefrescarTabla();
            }
        }
    }
}
