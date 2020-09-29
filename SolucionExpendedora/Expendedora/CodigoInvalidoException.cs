using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejExpendedora
{
    class CodigoInvalidoException:Exception
    {
        public CodigoInvalidoException() : base("El codigo ingresado es invalido. Se cancela operacion.")
        { }
    }
}
