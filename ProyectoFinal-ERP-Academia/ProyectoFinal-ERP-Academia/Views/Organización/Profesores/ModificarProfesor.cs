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
    public partial class ModificarProfesor : Form
    {
        int id;
        String dni;
        String nombre;
        String apellidos;
        String titulacion;
        ConnectOracle co;
        Profesor pr;
        public ModificarProfesor(int idA)
        {
            InitializeComponent();
            this.id = idA;
            co = new ConnectOracle();
            pr = co.buscarProfesor(id);
            cbDNI.Text = pr.DNI;
            cbNom.Text = pr.NOMBRE;
            cbAp.Text = pr.APELLIDO;
            cbTitu.Text = pr.TITULACION;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Util.Util.validarDNI(cbDNI.Text))
            {
                if (Util.Util.validarNombreApellido(cbNom.Text))
                {
                    if (Util.Util.validarNombreApellido(cbAp.Text))
                    {
                        if (Util.Util.validarDescripcion(cbTitu.Text))
                        {
                            dni = cbDNI.Text;
                            nombre = cbNom.Text;
                            apellidos = cbAp.Text;
                            titulacion = cbTitu.Text;
                            co.ModificarProfesor(id, dni, nombre, apellidos,titulacion);
                            MessageBox.Show("Profesor modificado correctamente");
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Formato de Titulación inválido");
                        }
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
                MessageBox.Show("Formato de DNI inválido");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
