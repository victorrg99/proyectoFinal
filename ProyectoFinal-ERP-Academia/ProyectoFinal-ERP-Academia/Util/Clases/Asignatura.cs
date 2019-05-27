using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ERP_Academia.Util.Clases
{
    class Asignatura
    {
        int id;
        String descripcion;
        float precio;
        int eliminado;

        public Asignatura()
        {

        }
        public Asignatura(int id, String descripcion,float precio,int eliminado)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.precio = precio;
            this.eliminado = eliminado;
        }

        public Asignatura(string v)
        {
            this.descripcion = v;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public String DESCRIPCION
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public float PRECIO
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        public int ELIMINADO
        {
            get
            {
                return eliminado;
            }

            set
            {
                eliminado = value;
            }
        }
    }
}
