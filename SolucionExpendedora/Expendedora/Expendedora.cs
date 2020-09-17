using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejExpendedora
{
    class Expendedora
    {
        List<Lata> _latas;
        string _proveedor;
        int _capacidad;
        double _dinero;
        bool _encendida;

        public bool Encendida
        {
            get { return this._encendida; }
        }
        public Expendedora()
        {
            this._encendida = false;
            this._capacidad = 10;
            this._latas = new List<Lata>();
            this.InicializarBebidas();
            this._dinero = 0;
        }

        public void AgregarLata(Lata lata)
        {
            if (this._latas.Count >= this._capacidad)
            {
                throw new CapacidadInsuficienteException();
            }
            else
            {
                this._latas.Add(lata);
            }
        }
        public Lata ExtraerLata(string texto, double importe)
        {
            Lata retorno = null;
            this._dinero += importe;
            retorno = BuscarLata(texto);
            this._latas.Remove(retorno);
            return retorno;
        }
        public string GetBalance()
        {            
            return string.Format("Dinero disponible: {0}",this._dinero);
        }
        public int GetCapacidadRestante()
        {
            int retorno=0;
            return retorno;
        }
        public void EncenderMaquina()
        {
            this._encendida = true;
        }
        public bool EstaVacia()
        {
            bool retorno=false;
            if (this._latas.Count == 0)
                retorno = true;
            else
                retorno = false;
            return retorno;
        }

        private void InicializarBebidas()
        {
            this._latas.Add(new Lata("CO1", "Coca Cola", "Regular",10,220));
            this._latas.Add(new Lata("CO2", "Coca Cola", "Zero",11, 220));
            this._latas.Add(new Lata("SP1", "Sprite", "Regular",12, 220));
            this._latas.Add(new Lata("SP1", "Sprite", "Zero",13, 220));
            this._latas.Add(new Lata("FA1", "Fanta", "Regular",13, 220));
            this._latas.Add(new Lata("FA2", "Fanta", "Zero",14, 220));
        }
        public string Listado()
        {
            string retorno="";
            foreach (Lata a in _latas)
                retorno += a.ToString()+"\n";
            return retorno;
        }
        public string ListadoStock()
        {
            string retorno = "";
            foreach (Lata a in _latas)
                retorno += a.GetLatasConMedidas() + "\n";
            return retorno;
        }
        public Lata BuscarLata(string cod)
        {
            Lata lata = null;

            foreach (Lata a in _latas)
            {
                if (a.Codigo == cod)
                    lata = a;
            }

            return lata;
        }
    }
}
