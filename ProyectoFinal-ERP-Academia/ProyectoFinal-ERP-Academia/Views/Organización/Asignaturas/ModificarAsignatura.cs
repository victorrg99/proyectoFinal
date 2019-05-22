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

namespace ProyectoFinal_ERP_Academia.Views.Organización.Asignaturas
{
    public partial class ModificarAsignatura : Form
    {
        int idA;
        String descripcion;
        float precio;
        ConnectOracle co;
        Asignatura asig = new Asignatura();

        public ModificarAsignatura(int id)
        {
            InitializeComponent();
            co = new ConnectOracle();
            this.idA = id;
            asig = co.buscarAsignatura(idA);
            cbDescripcion.Text = asig.DESCRIPCION;
            cbPrecio.Text = asig.PRECIO.ToString().Replace(",", ".");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Util.Util.validarDescripcion(cbDescripcion.Text))
            {
                if (Util.Util.validarCantidad(cbPrecio.Text))
                {
                    descripcion = cbDescripcion.Text;
                    precio = float.Parse(cbPrecio.Text.Replace(".", ","));
                    if (!co.encontradoAsignatura(descripcion) || asig.DESCRIPCION == descripcion)
                    {
                        co.ModificarAsignatura(idA,descripcion, precio);
                        MessageBox.Show("Asignatura modificada correctamente");
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe una asignatura con esa descripcion, prueba otra vez");
                    }

                }
                else
                {
                    MessageBox.Show("Formato de Precio inválido");
                }
            }
            else
            {
                MessageBox.Show("Formato de Descripcion inválido");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
