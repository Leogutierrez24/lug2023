using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CLASE01
{
    public class Alumno
    {
		private int _id;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _nombre;

		public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}

		private int _edad;

		public int Edad
		{
			get { return _edad; }
			set { _edad = value; }
		}

		private ConexionSQL _conexion;

		public Alumno()
		{
			_conexion = new ConexionSQL();
		}

		~Alumno()
		{
			_conexion = null;
		}

		public void Agregar()
		{
			_conexion.Conectar();
			string query = "SELECT ISNULL(MAX(ID),0) +1 FROM ALUMNO";
			_id = _conexion.ObtenerEscalar(query);

			query = $"INSERT INTO ALUMNO (ID, NOMBRE, EDAD) VALUES ({_id}, '{_nombre}', {_edad})";
			_conexion.Escribir(query);
			_conexion.Desconectar();
		}

		public void Actualizar()
		{
            _conexion.Conectar();
            string query = $"UPDATE ALUMNO SET nombre = '{_nombre}', edad = {_edad} WHERE id = {_id}";
            _conexion.Escribir(query);
            _conexion.Desconectar();
        }

		public void Eliminar()
		{
            _conexion.Conectar();
            string query = $"DELETE FROM ALUMNO WHERE ID={_id}";
			_conexion.Escribir(query);
            _conexion.Desconectar();
        }

		public static List<Alumno> ObtenerAlumnos()
		{
			ConexionSQL conexion = new ConexionSQL();
			conexion.Conectar();
			SqlDataReader reader = conexion.Leer("SELECT id, nombre, edad FROM ALUMNO");

			List<Alumno> listaAlumnos = new List<Alumno>();
			while (reader.Read())
			{
				listaAlumnos.Add(new Alumno()
				{
					_id = reader.GetInt32(0),
					_nombre = reader["NOMBRE"].ToString(),
					_edad = reader.GetInt32(2)
				});
			}

			conexion.Desconectar();
			return listaAlumnos;
		}
	}
}
