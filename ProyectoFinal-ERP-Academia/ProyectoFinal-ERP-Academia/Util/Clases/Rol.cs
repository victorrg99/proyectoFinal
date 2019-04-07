using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ERP_Academia.Util.Clases
{
    public class Rol
    {
        private int idRol;
        private String nombreRol;

        public Rol(String roleName)
        {
            this.nombreRol = roleName;
        }
        public int IdRol
        {
            get
            {
                return idRol;
            }

            set
            {
                idRol = value;
            }
        }
        public String NombreRol
        {
            get
            {
                return nombreRol;
            }

            set
            {
                nombreRol = value;
            }
        }
    }
}
