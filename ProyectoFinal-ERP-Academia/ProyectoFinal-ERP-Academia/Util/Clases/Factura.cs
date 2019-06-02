using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ERP_Academia.Util.Clases
{
    class Factura
    {
        public int id { get; set; }
        public String codigo { get; set; }
        public String fecha { get; set; }
        public int idUsuario { get; set; }
        public int idAlumno { get; set; }
        public float cantidadSinImpuesto { get; set; }
        public float impuesto { get; set; }
        public float cantidadTotal { get; set; }
        public int confirmado { get; set; }
        public Factura(){ }
    }
}
