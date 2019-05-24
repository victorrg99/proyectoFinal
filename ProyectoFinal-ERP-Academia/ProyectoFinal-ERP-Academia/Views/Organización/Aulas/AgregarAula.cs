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

namespace ProyectoFinal_ERP_Academia.Views.Organización.Aulas
{
    public partial class AgregarAula : Form
    {
        ConnectOracle co;
        String nombre;
        int capacidad;
        public AgregarAula()
        {
            InitializeComponent();
            co = new ConnectOracle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Util.Util.validarNombreApellido(cbNom.Text))
            {
                if (Util.Util.isNumeric(int.Parse(numCap.Value.ToString()).ToString()))
                {
                    nombre = cbNom.Text;
                    capacidad = int.Parse(numCap.Value.ToString());
                    if (!co.encontradoAula(nombre))
                    {
                        co.AgregarAula(nombre, capacidad);
                        MessageBox.Show("Aula añadida correctamente");
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un aula con ese nombre");
                    }
                }
                else
                {
                    MessageBox.Show("Formato de Capacidad inválido");
                }
            }
            else
            {
                MessageBox.Show("Formato de Nombre inválido");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
