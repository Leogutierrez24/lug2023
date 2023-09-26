using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENTRO_EDUCATIVO.Clases
{
    public abstract class Personal
    {
        private int _id;
        public int Id 
        { 
            get { return _id; } 
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
        }

        private int _documento;
        public int Documento
        {
            get { return _documento; }
        }

        private List<Telefono> _contacto = new List<Telefono>();
        public List<Telefono> Contacto
        {
            get { return _contacto; }
        }

        public Personal(int id, string nombre, int documento, List<Telefono> listaContacto) 
        {
            _id = id;
            _nombre = nombre;
            _documento = documento;
            _contacto = listaContacto;
        }
    }
}
