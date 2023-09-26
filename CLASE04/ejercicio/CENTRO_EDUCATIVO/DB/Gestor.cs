using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CENTRO_EDUCATIVO.Clases;

namespace CENTRO_EDUCATIVO.DB
{

    // Queda traer la tabla de Teléfonos y las categorias para los docentes.
    public class Gestor
    {
        public Conexion conexion = new Conexion();

        private List<Telefono> _telefonos = new List<Telefono>();
        public List<Telefono> Administrativos
        {
            get { return _telefonos; }
        }

        public Gestor()
        {

        }

        public List<Administrativo> ObtenerAdministrativos()
        {
            List<Administrativo> administrativos = new List<Administrativo>();
            DataTable tabla = conexion.Leer("OBTENER_ADMINISTRATIVOS");
            foreach (DataRow row in tabla.Rows)
            {
                Administrativo admin = new Administrativo(
                        int.Parse(row["ID"].ToString()),
                        row["NOMBRE"].ToString(),
                        int.Parse(row["DOCUMENTO"].ToString())
                    );
            }

            return administrativos;
        }

        public List<Docente> ObtenerDocentes()
        {
            List<Docente> docentes = new List<Docente>();
            DataTable tabla = conexion.Leer("OBTENER_DOCENTES");
            foreach(DataRow row in tabla.Rows)
            {
                Docente docente = new Docente(
                        int.Parse(row["ID"].ToString()),
                        row["NOMBRE"].ToString(),
                        int.Parse(row["DOCUMENTO"].ToString()),
                        
                    );
            }

            return docentes;
        }

        public List<Autoridad> ObtenerAutoridades()
        {
            List<Autoridad> autoridades = new List<Autoridad>();
            DataTable tabla = conexion.Leer("OBTENER_DOCENTES");
            foreach (DataRow row in tabla.Rows)
            {
                Autoridad docente = new Autoridad(
                        int.Parse(row["ID"].ToString()),
                        row["NOMBRE"].ToString(),
                        int.Parse(row["DOCUMENTO"].ToString()),
                        int.Parse(row["ANTIGUEDAD"].ToString())
                    );
            }

            return autoridades;
        }
    }
}
