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

namespace ProyectoFinal_ERP_Academia.Views.ZonaAlumnos.GestionPreguntas
{
    public partial class AgregarPregunta : Form
    {
        String pregunta;
        String res1;
        String res2;
        String res3;
        int idA;
        int resC;
        ConnectOracle co;
        public AgregarPregunta()
        {
            InitializeComponent();
            co = new ConnectOracle();
            co.getAsignaturas();
            ConnectOracle.AsigList.ForEach(x => this.cbAsig.Items.Add(x.DESCRIPCION));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbAsig.SelectedIndex >= 0)
            {
                if (Util.Util.validarRespuestaYPregunta(tbPreg.Text))
                {
                    if (Util.Util.validarRespuestaYPregunta(tbRes1.Text))
                    {
                        if (Util.Util.validarRespuestaYPregunta(tbRes2.Text))
                        {
                            if (Util.Util.validarRespuestaYPregunta(tbRes3.Text))
                            {
                                if (cbResC.SelectedIndex >= 0)
                                {
                                    idA = cbAsig.SelectedIndex + 1;
                                    resC = int.Parse(cbResC.SelectedItem.ToString());
                                    pregunta = tbPreg.Text;
                                    res1 = tbRes1.Text;
                                    res2 = tbRes2.Text;
                                    res3 = tbRes3.Text;
                                    co.AgregarPregunta(idA,pregunta,res1,res2,res3,resC);
                                    MessageBox.Show("Pregunta agregada correctamente");
                                    this.Dispose();
                                }
                                else
                                {
                                    MessageBox.Show("Debes seleccionar una Respuesta Correcta primero");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Formato de Respuesta3 inválido");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Formato de Respuesta2 inválido");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Formato de Respuesta1 inválido");
                    }
                }
                else
                {
                    MessageBox.Show("Formato de Pregunta inválido");
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar una Asignatura primero");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
