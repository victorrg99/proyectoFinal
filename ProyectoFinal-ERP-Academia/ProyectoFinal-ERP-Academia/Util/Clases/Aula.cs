using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ERP_Academia.Util.Clases
{
    class Aula
    {

        int id;
        String nombre;
        int capacidad;
        int eliminado;

        public Aula()
        {

        }
        public Aula(int id, String nombre, int capacidad, int eliminado)
        {
            this.id = id;
            this.nombre = nombre;
            this.capacidad = capacidad;
            this.eliminado = eliminado;
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

        public String NOMBRE
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public int CAPACIDAD
        {
            get
            {
                return capacidad;
            }

            set
            {
                capacidad = value;
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
