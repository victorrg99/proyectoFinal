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
    public partial class ModificarGrupo : Form
    {
        String nombre;
        int idA;
        int idP;
        int idG;
        ConnectOracle co;
        public ModificarGrupo(int idG)
        {
            InitializeComponent();
            co = new ConnectOracle();
            Grupo gr = co.buscarGrupo(idG);
            co.getAsignaturas();
            ConnectOracle.AsigList.ForEach(x => this.cbAsig.Items.Add(x.DESCRIPCION));
            cbAsig.SelectedIndex = gr.idAsig -1;
            co.getProfesores();
            ConnectOracle.ProfeList.ForEach(x => this.cbProf.Items.Add(x.NOMBRE));
            cbProf.SelectedIndex = gr.idProf -1;
            this.nombre = gr.nombre;
            tbNom.Text = nombre;
            this.idG = gr.id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Util.Util.validarNombreApellido(tbNom.Text))
            {
                if (!co.buscarGrupoPorNombre(tbNom.Text) || tbNom.Text==nombre)
                {
                    if (cbAsig.SelectedIndex >= 0)
                    {
                        if (cbProf.SelectedIndex >= 0)
                        {
                            nombre = tbNom.Text;
                            idA = cbAsig.SelectedIndex + 1;
                            idP = cbProf.SelectedIndex + 1;
                            co.ModificarGrupo(idG,nombre, idA, idP);
                            MessageBox.Show("Grupo modificado correctamente");
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Debes seleccionar un Profesor primero");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debes seleccionar una asignatura primero");
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe un Grupo con ese nombre, prueba con otro nombre");
                }
            }
            else
            {
                MessageBox.Show("EL formato del Nombre es inválido");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
