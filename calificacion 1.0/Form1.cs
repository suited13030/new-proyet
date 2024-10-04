using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calificacion_1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void VerMateria(object sender, EventArgs e) 
        {
            Materia _materia = new Materia();
            _materia.Show();
        }
        private void VerAlumnos(object sender, EventArgs e)
        {
            FormAlumnos _alumno = new FormAlumnos();
            _alumno.Show();
        }
    }
}
