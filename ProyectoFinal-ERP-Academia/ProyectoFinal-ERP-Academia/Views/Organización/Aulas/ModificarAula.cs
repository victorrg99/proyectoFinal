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

namespace ProyectoFinal_ERP_Academia.Views.Organización.Aulas
{
    public partial class ModificarAula : Form
    {
        ConnectOracle co;
        int idA;
        Aula aula;
        String nombre;
        int capacidad;
        public ModificarAula(int id)
        {
            InitializeComponent();
            co = new ConnectOracle();
            this.idA = id;
            aula = co.buscarAula(idA);
            cbNom.Text = aula.NOMBRE;
            numCap.Value = aula.CAPACIDAD;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Util.Util.validarNombreApellido(cbNom.Text))
            {
                if (Util.Util.isNumeric(int.Parse(numCap.Value.ToString()).ToString()))
                {
                    nombre = cbNom.Text;
                    capacidad = int.Parse(numCap.Value.ToString());
                    if (!co.encontradoAula(nombre) || aula.NOMBRE == nombre)
                    {
                        co.ModificarAula(idA,nombre, capacidad);
                        MessageBox.Show("Aula modificada correctamente");
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
