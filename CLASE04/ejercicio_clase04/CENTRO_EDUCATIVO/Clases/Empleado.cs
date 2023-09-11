using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENTRO_EDUCATIVO.Clases
{
    public abstract class Empleado
    {
        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
        }

        private long _documento;
        public long Documento
        {
            get { return _documento; }
        }

        private List<long> _contactos = new List<long>();
        public List<long> Contactos
        {
            get { return _contactos; }
        }

        public Empleado() { }

        public Empleado(string nombre, long documento, List<long> contactos)
        {
            _nombre = nombre;
            _documento = documento;
            _contactos = contactos;
        }
    }
}
