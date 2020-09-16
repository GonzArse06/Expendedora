using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejExpendedora
{
    class Lata
    {
        string _codigo, _nombre, _sabor;
        double _precio, _volumen;

        public string Codigo
        {
            get { return this._codigo; }
        }
        public string Nombre
        {
            get { return this._nombre; }
        }
        public string Sabor
        {
            get { return this._sabor; }
        }
        public double Precio
        {
            get { return this._precio; }
        }

        public Lata(string codigo,string nombre,string sabor)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._sabor = sabor;
        }
        public Lata(string codigo, string nombre, string sabor, double precio, double volumen):this(codigo,nombre,sabor)
        {
            this._precio = precio;
            this._volumen = volumen;
        }

        public double GetPrecioPorLitro()
        {
            double retorno = 0;
            return retorno;
        }
        public override string ToString()
        {
            return string.Format("{0}-{1} {2}",this._codigo,this._nombre,this._sabor);
        }
        

    }
}
