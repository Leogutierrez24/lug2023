using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENTRO_EDUCATIVO.Clases
{
    public class Autoridad : Personal
    {
        private int _antiguedad;
        public int Antiguedad
        {
            get { return _antiguedad; }
        }

        public Autoridad(int id, string nombre, int documento, int antiguedad, List<Telefono> listaContacto = null) : base(id, nombre, documento, listaContacto)
        {
            _antiguedad = antiguedad;
        }
    }
}
