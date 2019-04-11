using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ERP_Academia.Util.Clases
{
    class Usuario
    {
        int id;
        String dni;
        String nombre;
        String apellido;
        String clave;
        int rol;
        int eliminado;

        public Usuario() {
                
        }

        public Usuario(int id,String dni, String nombre, String apellido, String clave,int rol,int eliminado)
        {

            this.id=id;
            this.dni=dni;
            this.nombre=nombre;
            this.apellido=apellido;
            this.clave=clave;
            this.rol=rol;
            this.eliminado=eliminado;

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
                return dni ;
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

        public String CLAVE 
        {
            get
            {
                return clave;
            }

            set
            {
                clave = value;
            }
        }

        public int ROL
        {
            get
            {
                return rol;
            }

            set
            {
                rol = value;
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
