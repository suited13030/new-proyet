using calificacion_1._0.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calificacion_1._0
{
    public partial class RegistrarAlumnos : Form
    {
        public RegistrarAlumnos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alumnos alumnos = new Alumnos()
            {
                Nombre = nombre1.Text,
                Apellido = Apellido1.Text,
                Matricula = Matricula1.Text,
            };
            Central.RegistrarAlumnos(alumnos);
        }
    }
}

