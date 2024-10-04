namespace calificacion_1._0
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Materia = new System.Windows.Forms.Button();
            this.Alumno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Materia
            // 
            this.Materia.AccessibleName = "Materia ";
            this.Materia.Location = new System.Drawing.Point(31, 40);
            this.Materia.Name = "Materia";
            this.Materia.Size = new System.Drawing.Size(147, 57);
            this.Materia.TabIndex = 0;
            this.Materia.Text = "Alunmo ";
            this.Materia.UseVisualStyleBackColor = true;
            this.Materia.Click += new System.EventHandler(this.VerAlumnos);
            // 
            // Alumno
            // 
            this.Alumno.AccessibleName = "Alunmo";
            this.Alumno.Location = new System.Drawing.Point(230, 40);
            this.Alumno.Name = "Alumno";
            this.Alumno.Size = new System.Drawing.Size(156, 57);
            this.Alumno.TabIndex = 1;
            this.Alumno.Text = "Materia ";
            this.Alumno.UseVisualStyleBackColor = true;
            this.Alumno.Click += new System.EventHandler(this.VerMateria);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Alumno);
            this.Controls.Add(this.Materia);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Materia;
        private System.Windows.Forms.Button Alumno;
    }
}

