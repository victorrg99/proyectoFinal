using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ERP_Academia.Util.Clases
{
    class Alumno
    {
        int id;
        String dni;
        String nombre;
        String apellido;
        int horario;
        int eliminado;

        public Alumno()
        {

        }

        public Alumno(int id, String dni, String nombre, String apellido, int horario, int eliminado)
        {

            this.id = id;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.horario = horario;
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
        public String DNI
        {
            get
            {
                return dni;
            }

            set
            {
                dni = value;
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
        public String APELLIDO
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public int HORARIO
        {
            get
            {
                return horario;
            }

            set
            {
                horario = value;
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
