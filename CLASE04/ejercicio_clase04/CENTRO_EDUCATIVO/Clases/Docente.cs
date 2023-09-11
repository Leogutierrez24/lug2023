using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENTRO_EDUCATIVO.Clases
{
    public enum CategoriaDocente
    {
        Titular = 0,
        Adjunto = 1,
    }

    public class Docente : Empleado
    {
        private CategoriaDocente _categoria;
        public CategoriaDocente Categoria
        {
            get { return _categoria; }
        }
        
        public Docente(string nombre, long documento, List<long> contactos, CategoriaDocente categoria) : base (nombre, documento, contactos)
        {
            _categoria = categoria;
        }
    }

}
