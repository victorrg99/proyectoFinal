using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ERP_Academia.Util.Clases
{
    class Grupo
    {

        public int id { get; set;}
        public String nombre { get; set; }
        public int idAsig { get; set; }
        public int idProf { get; set; }
        public int capacidad { get; set; }
        public int eliminado { get; set; }

        public Grupo() { }

        public Grupo(string v)
        {
            this.nombre = v;
        }
    }
}
