using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calificaciones
{
    public partial class Form1 : Form
    {
        //TAREA:
        //En la pantalla de alumnos crear metodo para cargar alumnos usando Central
        //En la pantalla de materias crear el diseno de la pantalla con sus botones y cualquier elemento
        //En la pantalla de materias crear formulario para dar de alta materias y usar Central
        //En la pantalla de materias crear los metodos que sean necesarios
        public Form1()
        {
            InitializeComponent();
        }

      
        private void VerMaterias(object sender, EventArgs e)
        {
            Materias _materias = new Materias();
            _materias.Show();
        }
        private void VerAlumnos(object sender, EventArgs e)
        {
            Alumnos _alumnos = new Alumnos();
            _alumnos.Show();
        }


    }
}
