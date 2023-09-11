using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLASE01
{
    public partial class Form1 : Form
    {
        public List<Alumno> alumnos = new List<Alumno>();

        public Form1()
        {
            InitializeComponent();
        }

        private void CargarAlumnos()
        {
            Alumnos_dataGridView.DataSource = null;
            alumnos = Alumno.ObtenerAlumnos();
            Alumnos_dataGridView.DataSource = alumnos;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarAlumnos();
        }

        private void Alumnos_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Alumno toUpdate = Alumnos_dataGridView.Rows[e.RowIndex].DataBoundItem as Alumno;
            Nombre_textBox.Text = toUpdate.Nombre;
            Edad_textBox.Text = toUpdate.Edad.ToString();
            ID_textBox.Text = toUpdate.Id.ToString();
        }

        private void button1_Click(object sender, EventArgs e) // create
        {
            Alumno alumno = new Alumno()
            {
                Nombre = Nombre_textBox.Text,
                Edad = int.Parse(Edad_textBox.Text),
            };

            alumno.Agregar();
            CargarAlumnos();
        }

        private void button2_Click(object sender, EventArgs e) // delete
        {
            if (Alumnos_dataGridView.SelectedRows.Count == 1)
            {
                Alumno toDelete = Alumnos_dataGridView.SelectedRows[0].DataBoundItem as Alumno;
                toDelete.Eliminar();
                CargarAlumnos();
            } else
            {
                MessageBox.Show("Seleccioná un alumno para poder borrar!");
            }
        }

        private void button3_Click(object sender, EventArgs e) // update
        {
            Alumno alumno = new Alumno()
            {
                Nombre = Nombre_textBox.Text,
                Edad = int.Parse(Edad_textBox.Text),
                Id = int.Parse(ID_textBox.Text)
            };

            alumno.Actualizar();
            CargarAlumnos();
        }

        
    }
}
