using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ERP_Academia.Util.Clases
{
    class Profesor
    {

        int id;
        String dni;
        String nombre;
        String apellido;
        String titulacion;
        int idUsuario;
        int eliminado;
        private string v;

        public Profesor()
        {

        }

        public Profesor(int id, String dni, String nombre, String apellido, String titulacion, int idUsuario, int eliminado)
        {

            this.id = id;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.titulacion = titulacion;
            this.idUsuario = idUsuario;
            this.eliminado = eliminado;

        }

        public Profesor(string v)
        {
            this.nombre = v;
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

        public String TITULACION
        {
            get
            {
                return titulacion;
            }

            set
            {
                titulacion = value;
            }
        }

        public int USUARIO
        {
            get
            {
                return idUsuario;
            }

            set
            {
                idUsuario = value;
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
