using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejExpendedora
{
    static class Validaciones
    {
        const int _minimo = 0;
        const int _maximo = 999999;
        public static int Numero(string mensaje, int min, int max)
        {
            int retorno;
            do
            {
                Console.WriteLine("Ingrese "+mensaje+": ");
                if (!int.TryParse(Console.ReadLine(), out retorno))
                {
                    Console.WriteLine("Error. Ingrese un valor numerico. Reintente...");
                }
                else if (retorno < min || retorno > max)
                {
                    Console.WriteLine("Error. El numero debe estar entre "+min+" y "+max+". Reintente...");
                }
            } while (retorno < min || retorno > max);
            return retorno;
        }

        public static double Importe(string mensaje)
        {
            return Importe(mensaje, _minimo, _maximo);
        }
        public static double Importe(string mensaje, double min, double max)
        {
            double retorno;
            do
            {
                Console.WriteLine("Ingrese " + mensaje + ": ");
                if (!double.TryParse(Console.ReadLine(), out retorno))
                {
                    Console.WriteLine("Error. Ingrese un valor numerico. Reintente...");
                }
                else if (retorno < min || retorno > max)
                {
                    Console.WriteLine("Error. El numero debe estar entre " + min + " y " + max + ". Reintente...");
                }
            } while (retorno < min || retorno > max);
            return retorno;
        }

        public static int Numero(string mensaje)
        {
            return Numero(mensaje, _minimo, _maximo);
        }

        public static string Texto(string mensaje)
        {
            string retorno;
            do
            {
                Console.WriteLine("Ingrese "+mensaje+": ");
                retorno = Console.ReadLine();
                if (string.IsNullOrEmpty(retorno))
                    Console.WriteLine("Error. No puede quedar vacio. Reintente...");
            } while (string.IsNullOrEmpty(retorno));
            return retorno;
        }
        public static string Caracter(string mensaje)
        {
            string retorno;
            bool estaOk = false;
            do
            {
                Console.WriteLine("Ingrese " + mensaje + ": ");
                retorno = Texto(mensaje).ToUpper();
                if (retorno =="S")
                    estaOk=true;
            } while (!estaOk);
            return retorno;
        }
    }
}
