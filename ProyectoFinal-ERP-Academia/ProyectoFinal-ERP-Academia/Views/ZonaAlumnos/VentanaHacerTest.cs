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
        List<int> respuestas;
        int acierto = 1;
        int fallo = 2;
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
            respuestas = new List<int>();
            for (int i = 0; i < listaP.Count;i++) { respuestas.Add(0); }
            ActualizarDatos(p);
        }
        private void ActualizarDatos(Pregunta pr)
        {
            lbPreg.Text = pr.pregunta;
            lbA.Text = pr.respuesta1;
            lbB.Text = pr.respuesta2;
            lbC.Text = pr.respuesta3;
            if (pr.contestado == true) { lbContestada.Visible = true; }
            if (pr.contestado == false) { lbContestada.Visible = false; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (p.resCorrecta == 3)
            {
                respuestas[pos] = acierto;
            }
            else
            {
                respuestas[pos] = fallo;
            }
            p.contestado = true;
            ActualizarDatos(p);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (p.resCorrecta == 2)
            {
                respuestas[pos] = acierto;
            }
            else
            {
                respuestas[pos] = fallo;
            }
            p.contestado = true;
            ActualizarDatos(p);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (p.resCorrecta == 1)
            {
                respuestas[pos] = acierto;
            }
            else
            {
                respuestas[pos] = fallo;
            }
            p.contestado = true;
            ActualizarDatos(p);
        }

        private void anterior_Click(object sender, EventArgs e)
        {
            if (pos > 0)
            {
                pos -= 1;
                p = listaP.ElementAt(pos);
                ActualizarDatos(p);
            }
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            if (pos < listaP.Count-1)
            {
                pos += 1;
                p = listaP.ElementAt(pos);
                ActualizarDatos(p);
            }
        }

        private void btFin_Click(object sender, EventArgs e)
        {
            

            if (!respuestas.Contains(0))
            {
                int a = 0;
                int f = 0;
                for (int i = 0; i < respuestas.Count; i++)
                {
                    if (respuestas.ElementAt(i) == 1) { a++; }
                    if (respuestas.ElementAt(i) == 2) { f++; }
                }
                co.AñadirResultados(idTest,idAlum,a,f);
                MessageBox.Show("Test finalizado, Aciertos: "+a+" Fallos: "+f);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Aun faltan preguntas por contestar, si sales se perderan los datos");
            }
        }
    }
}
