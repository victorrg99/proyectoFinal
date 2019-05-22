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

namespace ProyectoFinal_ERP_Academia.Views.Organización.Profesores
{
    public partial class AgregarProfesor : Form
    {
        int idU;
        String dni;
        String nombre;
        String apellidos;
        String titulacion;
        ConnectOracle co;
        public AgregarProfesor(int id)
        {
            InitializeComponent();
            co = new ConnectOracle();
            this.idU = id;
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
                            co.AgregarProfesor(dni, nombre, apellidos, titulacion,idU);
                            MessageBox.Show("Profesor creado correctamente");
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
    
    }
}
