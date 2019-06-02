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

namespace ProyectoFinal_ERP_Academia.Views.Matriculas
{
    public partial class ModificarMatricula : Form
    {
        ConnectOracle co;
        Alumno al;
        Alumno a;
        Matricula m;
        Grupo g;
        int idA;
        int idG;
        float precio;
        public ModificarMatricula(int idM)
        {
            InitializeComponent();
            co = new ConnectOracle();
            m = co.BuscarMatricula(idM);
            a = co.buscarAlumno(m.idAlumno);
            co.getAlumnos();
            ConnectOracle.AlumList.ForEach(x => this.cbAlum.Items.Add(x.DNI));
            cbAlum.SelectedItem = a.DNI;

            al = co.buscarAlumno(cbAlum.SelectedItem.ToString());
            co.getGrupos(al.Id);
            cbGrup.Items.Clear();
            ConnectOracle.GrupList.ForEach(x => this.cbGrup.Items.Add(x.nombre));
        }

        private void cbAlum_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbGrup.Items.Clear();
            al = co.buscarAlumno(cbAlum.SelectedItem.ToString());
            co.getGrupos(al.Id);
            ConnectOracle.GrupList.ForEach(x => this.cbGrup.Items.Add(x.nombre));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbAlum.SelectedIndex >= 0)
            {
                if (cbGrup.SelectedIndex >= 0)
                {
                    idA = cbAlum.SelectedIndex + 1;
                    g = co.buscarGrupo(cbGrup.SelectedItem.ToString());
                    idG = g.id;
                    precio = co.getPrecioGrupo(idG);
                    co.ModificarMatricula(m.id,idA, idG, precio);
                    MessageBox.Show("Matricula modificada correctamente");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Debes seleccionar un grupo primero");
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un alumno primero");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
