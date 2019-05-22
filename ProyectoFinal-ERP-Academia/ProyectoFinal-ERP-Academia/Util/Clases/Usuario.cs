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
        String usuario;
        String clave;
        int rol;
        int eliminado;

        public Usuario() {
                
        }

        public Usuario(int id,String usuario, String clave,int rol,int eliminado)
        {

            this.id=id;
            this.usuario = usuario;
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
        public String USUARIO
        {
            get 
            {
                return usuario;
            }

            set
            {
                usuario = value;
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
