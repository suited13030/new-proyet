using Calificaciones.Entidades;
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
    public partial class RegistrarAlumno : Form
    {
        public RegistrarAlumno()
        {
            InitializeComponent();
        }

        private void Registar(object sender, EventArgs e)
        {
            //forma 1
            Alumno alumno = new Alumno();
            alumno.Nombre = tbnombre.Text;
            alumno.Apellidos = tbapellidos.Text;
            alumno.Matricula = tbmatricula.Text;

            //forma 2
            Alumno alumno2 = new Alumno()
            {
                Nombre = tbnombre.Text,
                Apellidos = tbapellidos.Text,
                Matricula = tbmatricula.Text
            };

            Central.RegistrarAlumno(alumno);
        }
    }
}
