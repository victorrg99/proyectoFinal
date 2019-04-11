using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_ERP_Academia.Util.Clases
{
    class Falta
    {
        int id;
        int alumno;
        int profesor;
        int grupo;
        String fecha;
        int eliminado;

        public Falta()
        {

        }
        public Falta(int id,int alumno,int profesor,int grupo,String fecha, int eliminado)
        {
            this.id = id;
            this.alumno = alumno;
            this.profesor = profesor;
            this.grupo = grupo;
            this.fecha = fecha;
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
        public int ALUMNO
        {
            get
            {
                return alumno;
            }

            set
            {
                alumno = value;
            }
        }
        public int PROFESOR
        {
            get
            {
                return profesor;
            }

            set
            {
                profesor = value;
            }
        }
        public int GRUPO
        {
            get
            {
                return grupo;
            }

            set
            {
                grupo = value;
            }
        }
        public String FECHA
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
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
