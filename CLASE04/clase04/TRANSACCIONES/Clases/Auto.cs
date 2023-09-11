using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRANSACCIONES.Clases
{
    public class Auto
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _matricula;
        public string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }

        private Marca _marca;
        public Marca Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }
    }
}
