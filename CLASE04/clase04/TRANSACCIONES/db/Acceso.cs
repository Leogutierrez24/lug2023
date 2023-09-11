using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TRANSACCIONES.db
{
    public class Acceso
    {
        private SqlConnection _conexion;

        private readonly string _catalog;

        private readonly string _source;

        public void Abrir()
        {
            _conexion = new SqlConnection();
            _conexion.ConnectionString = $"Initial Catalog: {_catalog};Data Source: {_source};Integrated Security: SSPI";
            _conexion.Open();
        }

        public void Cerrar()
        {
            _conexion.Close();
            _conexion = null;
            GC.Collect();
        }

        public Acceso(string catalog, string source)
        {
            _catalog = catalog;
            _source = source;
        }
    }
}
