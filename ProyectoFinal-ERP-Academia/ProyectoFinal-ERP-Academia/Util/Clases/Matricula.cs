using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ERP_Academia.Util.Clases
{
    class Matricula
    {
        public int id { get; set; }
        public int idAlumno { get; set; }
        public int idGrupo { get; set; }
        public  float precio { get; set; }
        public String fecha { get; set; }
        public int eliminado { get; set; }
    }
}
