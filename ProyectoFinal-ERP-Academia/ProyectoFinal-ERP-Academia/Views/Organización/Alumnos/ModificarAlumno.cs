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

namespace ProyectoFinal_ERP_Academia.Views.Organización.Alumnos
{
    public partial class ModificarAlumno : Form
    {
        int id;
        String dni;
        String nombre;
        String apellidos;
        ConnectOracle co;
        Alumno al;
        public ModificarAlumno(int idA)
        {
            InitializeComponent();
            this.id = idA;
            co = new ConnectOracle();
            al = co.buscarAlumno(id);
            cbDNI.Text = al.DNI;
            cbNom.Text = al.NOMBRE;
            cbAp.Text = al.APELLIDO;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Util.Util.validarDNI(cbDNI.Text))
            {
                if (!co.ExisteAlumno(cbDNI.Text) || cbDNI.Text == al.DNI)
                {
                    if (Util.Util.validarNombreApellido(cbNom.Text))
                    {
                        if (Util.Util.validarNombreApellido(cbAp.Text))
                        {
                            dni = cbDNI.Text;
                            nombre = cbNom.Text;
                            apellidos = cbAp.Text;
                            co.ModificarAlumno(id, dni, nombre, apellidos);
                            MessageBox.Show("Alumno modificado correctamente");
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Formato de Apellidos inválido");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Formato de Nombre inválido");
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe un alumno con ese DNI");
                }
            }
            else
            {
                MessageBox.Show("Formato de DNI inválido");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
