using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProyectoFinal_ERP_Academia.Util
{
    class Util
    {
        //Método que tomando por parametro una cadena de texto valida si es una Descripción con un formato correcto
        public static bool validarDescripcion(String cadena)
        {
            if (cadena.Contains("'"))
            {
                return false;
            }
            return Regex.IsMatch(cadena, "^[a-zA-Z][a-zA-Z0-9]{1,199}");
        }
        //Método que tomando por parametro una cadena de texto valida si es un Nombre o Apellido con un formato correcto
        public static bool validarNombreApellido(String cadena)
        {

            if (cadena.Equals("") || cadena.Trim().Equals("") || cadena.Contains("'"))
            {
                return false;
            }
            return Regex.IsMatch(cadena, "^[a-z-A-Z]{1,199}");
        }
        public static bool validarRespuestaYPregunta(String cadena)
        {

            if (cadena.Equals("") || cadena.Trim().Equals("") || cadena.Contains("'"))
            {
                return false;
            }
            return true;
        }
        //Método que tomando por parametro una cadena de texto valida si es un DNI con un formato correcto
        public static bool validarDNI(String cadena)
        {
            if (cadena.Contains("'"))
            {
                return false;
            }

            return Regex.IsMatch(cadena, "^[0-9]{8}[A-Z]{1}");
            
        }
        //Método que tomando por parametro una cadena de texto valida si es un Precio con un formato correcto, tanto si es número entero como si tiene una parte decimal
        public static bool validarPrecio(String cadena)
        {
            if (cadena.Length > 0)
            {
                if (cadena[0] == ',' || cadena[0] == '.')
                {
                    return false;
                }
            }
            if (cadena.Length == 0)
            {
                return false;
            }
            if (cadena.Contains("'") || cadena.Contains(","))
            {
                return false;
            }
            if (cadena.Contains("."))
            {
                String[] parts = cadena.Split('.');
                if (parts[0].Length > 4)
                {
                    return false;
                }
                if (parts[1].Length > 2)
                {
                    return false;
                }
            }
            else
            {
                if (cadena.Length > 4)
                {
                    return false;
                }
            }
            return Regex.IsMatch(cadena, @"^[0-9]+([.][0-9]+)?$");
        }
        

        //Método que tomando por parametro una cadena de texto valida si es numérico
        public static bool isNumeric(string cadena)
        {
            foreach (char ch in cadena)
            {
                if (!Char.IsNumber(ch) && ch != 32 && ch != '.')
                {
                    return false;
                }
            }
            return true;
        }
        //Método que tomando por parametro una cadena de texto valida si es una Cantidad con un formato correcto
        public static bool validarCantidad(String cadena)
        {
            cadena = cadena.Trim();
            if (cadena.Length > 0)
            {
                if (cadena[0] == ',' || cadena[0] == '.')
                {
                    return false;
                }
            }
            if (cadena.Length == 0 || cadena == "")
            {
                return false;
            }
            if (cadena.Contains("'"))
            {
                return false;
            }
            if (cadena.Contains(","))
            {
                cadena.Replace(',', '.');
            }

            return Regex.IsMatch(cadena, @"^[0-9]{1,}?([. ,][0-9]{1,2})?$");
        }
    }
}
