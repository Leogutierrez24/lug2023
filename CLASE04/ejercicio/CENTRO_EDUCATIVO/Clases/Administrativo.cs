using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENTRO_EDUCATIVO.Clases
{
    public class Administrativo : Personal
    {
        public Administrativo(int id, string nombre, int documento, List<Telefono> listaContacto = null) : base(id, nombre, documento, listaContacto)
        {

        }
    }
}
