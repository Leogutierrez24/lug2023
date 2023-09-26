using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CENTRO_EDUCATIVO.DB
{
    public class Conexion
    {
        private SqlConnection _conexion;

        private SqlTransaction _transaccion;

        private EstadoConexion _estado = EstadoConexion.Desconectado;
        public EstadoConexion Estado
        {
            get { return _estado; }
        }

        public Conexion()
        { }

        // Conexión

        public void Abrir()
        {
            _conexion = new SqlConnection()
            { 
                ConnectionString = "Data Source=LEO; Initial Catalog=CENTRO_EDUCATIVO;  Integrated Security=SSPI"
            };
            _conexion.Open();
            _estado = EstadoConexion.Conectado;
        }

        public void Cerrar()
        {
            _conexion.Close();
            _conexion = null;
            GC.Collect();
            _estado = EstadoConexion.Desconectado;
        }

        // Transacciones

        public void IniciarTransaccion()
        {
            if (_conexion?.State == ConnectionState.Open) _transaccion = _conexion.BeginTransaction();
        }

        public void ConfirmarTransaccion()
        {
            _transaccion.Commit();
            _transaccion = null;
        }

        public void CancelarTransaccion()
        {
            _transaccion.Rollback();
            _transaccion = null;
        }


        // Operaciones

        public DataTable Leer(string query, List<SqlParameter> parametros = null)
        {
            DataTable tabla = new DataTable();
            using(SqlDataAdapter adapter = new SqlDataAdapter())
            {
                adapter.SelectCommand = CrearComando(query, parametros);
                adapter.Fill(tabla);
                adapter.Dispose();
            }

            return tabla;
        }

        public int Escribir(string query, List<SqlParameter> parametros = null)
        {
            SqlCommand comando = CrearComando(query, parametros);
            int filasAfectadas;

            try
            {
                if (_conexion?.State == ConnectionState.Open) filasAfectadas = comando.ExecuteNonQuery();
                else filasAfectadas = 0;
            } catch (SqlException ex)
            {
                filasAfectadas = -1;
            }

            return filasAfectadas;
        }

        // Commands y params

        private SqlCommand CrearComando(string query, List<SqlParameter> parametros = null)
        {
            SqlCommand comando = new SqlCommand
            {
                Connection = _conexion,
                CommandType = CommandType.StoredProcedure,
                CommandText = query
            };

            if (_transaccion != null) comando.Transaction = _transaccion;

            parametros?.ForEach(parametro => comando.Parameters.Add(parametro));

            return comando;
        }
        
        public SqlParameter CrearParametro(string nombre, string valor)
        {
            SqlParameter parametro = new SqlParameter
            {
                ParameterName = nombre,
                Value = valor,
                DbType = DbType.String
            };
            
            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, int valor)
        {
            SqlParameter parametro = new SqlParameter
            {
                ParameterName = nombre,
                Value = valor,
                DbType = DbType.Int32
            };

            return parametro;
        }

        
    }
}
