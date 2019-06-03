using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ERP_Academia.Util.Clases
{
    class Pregunta
    {
        public int idPregunta { get; set; }
        public int idAsignatura { get; set; }
        public String pregunta { get; set; }
        public String respuesta1 { get; set; }
        public String respuesta2 { get; set; }
        public String respuesta3 { get; set; }
        public int resCorrecta { get; set; }
        public int eliminado { get; set; }

        public Boolean contestado { get; set; }

        public Pregunta() { contestado = false; }

    }
}
