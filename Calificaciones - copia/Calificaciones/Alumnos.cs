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
    public partial class Alumnos : Form
    {
        public Alumnos()
        {
            InitializeComponent();
        }

        private void AgregarAlumno(object sender, EventArgs e)
        {
            RegistrarAlumno reg = new RegistrarAlumno();
            reg.Show();
        }
    }
}
