using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENTRO_EDUCATIVO.Clases
{
    public class Administrativo : Empleado
    {
        public Administrativo(string nombre, long documento, List<long> contactos) : base (nombre, documento, contactos) { }
    }
}
