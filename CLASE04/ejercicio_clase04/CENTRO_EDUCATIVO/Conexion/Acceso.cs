using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CENTRO_EDUCATIVO.Conexion
{
    public class Acceso
    {
        private SqlConnection _conexion;

        public void Abrir()
        {
            _conexion = new SqlConnection();
            _conexion.ConnectionString = "Initial Catalog=; Data Source=.; Integrated Security=SSPI";
            _conexion.Open();            
        }

        public void Cerrar()
        {
            _conexion.Close();
            _conexion = null;
            GC.Collect();
        }

        public DataTable Leer(string query, List<SqlParameter> parametros = null)
        {
            DataTable tabla = new DataTable();

            using (SqlDataAdapter adaptador = new SqlDataAdapter())
            {
                adaptador.SelectCommand = CrearComando(query, parametros);
            }

            return tabla;
        }

        public int Escribir(string query, List<SqlParameter> parametros = null)
        {
            SqlCommando comando = CrearComando(query, parametros);
        }


        // private methods 

        private SqlCommand CrearComando(string query, List<SqlParameter> parametros = null)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = query;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = _conexion;

            if (parametros != null)
            {
                parametros.ForEach(parametro =>
                {
                    comando.Parameters.Add(parametro);
                });
            }

            return comando;
        }

        private SqlParameter CrearParametro(string nombre, string valor)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombre;
            parametro.Value = valor;
            parametro.DbType = DbType.String;

            return parametro;
        }
    }
}
