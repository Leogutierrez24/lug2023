using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CLASE01
{
    public class ConexionSQL
    {
        private SqlConnection _conexion;

        private SqlCommand _comando;

        public void Conectar()
        {
            _conexion = new SqlConnection();
            _conexion.ConnectionString = "Data Source=LEO;Initial Catalog=CLASE01;Integrated Security=SSPI";
            _conexion.Open();
        }

        public void Desconectar()
        {
            _conexion.Close();
            _conexion = null;
            GC.Collect();
        }

        public int Escribir(string query)
        {
            _comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = query,
                Connection = _conexion
            };

            int filasAfectadas;

            try
            {
                filasAfectadas = _comando.ExecuteNonQuery();
            } catch
            {
                filasAfectadas = -1;
            }

            _comando = null;
            GC.Collect();
            return filasAfectadas;
        }

        public int ObtenerEscalar(string query)
        {
            _comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = query,
                Connection = _conexion
            };

            int valor = int.Parse(_comando.ExecuteScalar().ToString());

            _comando = null;
            GC.Collect();
            return valor;
        }

        public SqlDataReader Leer(string query)
        {
            _comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = query,
                Connection = _conexion
            };

            SqlDataReader reader = _comando.ExecuteReader();

            _comando = null;
            GC.Collect();
            return reader;
        }
    }
}
