using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENTRO_EDUCATIVO.Clases
{
    public class Autoridad : Empleado
    {
        private int _antiguedad;
        public int Antiguedad
        {
            get { return _antiguedad; }
        }

        public Autoridad(string nombre, long documento, List<long> contactos, int antiguedad) : base (nombre, documento, contactos)
        {
            _antiguedad = antiguedad;
        }
    }
}
