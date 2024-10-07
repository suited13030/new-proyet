using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calificacion_1._0.Entidades
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

        private void Alumnos_Load(object sender, EventArgs e)
        {
            gvalumnos.DataSource = Central.CaragarAlumnos();
        }
    }
}