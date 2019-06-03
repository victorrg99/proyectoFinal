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

namespace ProyectoFinal_ERP_Academia.Views.ZonaAlumnos
{
    public partial class VentanaHacerTest : Form
    {
        ConnectOracle co;
        List<Pregunta> listaP;
        Pregunta p;
        int pos = 0;
        int idTest;
        int aciertos = 0;
        int fallos = 0;
        int idAlum;
        public VentanaHacerTest(int idT,int idA)
        {
            InitializeComponent();
            lbContestada.Visible = false;
            this.idTest = idT;
            this.idAlum = idA;
            co = new ConnectOracle();
            listaP = co.getPreguntas(idTest);
            p = listaP.ElementAt(pos);
            ActualizarDatos(p);
        }
        private void ActualizarDatos(Pregunta pr)
        {
            lbPreg.Text = pr.pregunta;
            lbA.Text = pr.respuesta1;
            lbB.Text = pr.respuesta2;
            lbC.Text = pr.respuesta3;
            if (pr.contestado == true) { lbContestada.Visible = true; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (p.resCorrecta == 3)
            {
                aciertos += 1;
            }
            else
            {
                fallos += 1;
            }
            p.contestado = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (p.resCorrecta == 2)
            {
                aciertos += 1;
            }
            else
            {
                fallos += 1;
            }
            p.contestado = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (p.resCorrecta == 1)
            {
                aciertos += 1;
            }
            else
            {
                fallos += 1;
            }
            p.contestado = true;
        }

        private void anterior_Click(object sender, EventArgs e)
        {
            if (pos >= 0)
            {
                pos -= 1;
                p = listaP.ElementAt(pos);
                ActualizarDatos(p);
            }
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            if (pos <= listaP.Count)
            {
                pos += 1;
                p = listaP.ElementAt(pos);
                ActualizarDatos(p);
            }
        }

        private void btFin_Click(object sender, EventArgs e)
        {
            if (aciertos + fallos == listaP.Count())
            {

            }
            else
            {
                MessageBox.Show("Aun faltan preguntas por contestar, si sales se perderan los datos");
            }
        }
    }
}
