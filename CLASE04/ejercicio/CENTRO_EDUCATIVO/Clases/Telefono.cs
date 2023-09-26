using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CENTRO_EDUCATIVO.Clases
{
    public class Telefono
    {
        private int _id;
        public int Id
        {
            get { return _id; }
        }

        private long _numero;
        public long Numero
        {
            get { return _numero; }
        }

        private string _referencia;
        public string Referencia
        {
            get { return _referencia; }
            set { _referencia = value; }
        }

        public Telefono(int id, long numero)
        {
            _id = id;
            _numero = numero;
        }
    }
}
