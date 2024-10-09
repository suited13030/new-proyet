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
