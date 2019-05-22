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

namespace ProyectoFinal_ERP_Academia.Views.Organización.Asignaturas
{
    public partial class AgregarAsignatura : Form
    {
        String descripcion;
        float precio;
        ConnectOracle co;

        public AgregarAsignatura()
        {
            InitializeComponent();
            co = new ConnectOracle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Util.Util.validarDescripcion(cbDescripcion.Text))
            {
                if (Util.Util.validarCantidad(cbPrecio.Text))
                {
                    descripcion = cbDescripcion.Text;
                    precio = float.Parse(cbPrecio.Text.Replace(".",","));
                    if (!co.encontradoAsignatura(descripcion))
                    {
                        co.AgregarAsignatura(descripcion, precio);
                        MessageBox.Show("Asignatura insertada correctamente");
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
