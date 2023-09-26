using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENTRO_EDUCATIVO.Clases
{
    public class Docente : Personal
    {
        private CategoriaDocente _categoria;
        public CategoriaDocente Categoria
        {
            get { return _categoria; }
        }

        public Docente(int id, string nombre, int documento, CategoriaDocente categoria, List<Telefono> listaContacto = null) : base (id, nombre, documento, listaContacto)
        {
            _categoria = categoria;
        }
    }
}
