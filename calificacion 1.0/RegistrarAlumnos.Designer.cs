namespace calificacion_1._0
{
    partial class RegistrarAlumnos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nombre1 = new System.Windows.Forms.TextBox();
            this.Matricula1 = new System.Windows.Forms.TextBox();
            this.Apellido1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Matricula:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nombre1
            // 
            this.nombre1.Location = new System.Drawing.Point(105, 51);
            this.nombre1.Name = "nombre1";
            this.nombre1.Size = new System.Drawing.Size(100, 20);
            this.nombre1.TabIndex = 4;
            // 
            // Matricula1
            // 
            this.Matricula1.Location = new System.Drawing.Point(105, 165);
            this.Matricula1.Name = "Matricula1";
            this.Matricula1.Size = new System.Drawing.Size(100, 20);
            this.Matricula1.TabIndex = 5;
            // 
            // Apellido1
            // 
            this.Apellido1.Location = new System.Drawing.Point(105, 111);
            this.Apellido1.Name = "Apellido1";
            this.Apellido1.Size = new System.Drawing.Size(100, 20);
            this.Apellido1.TabIndex = 6;
            // 
            // RegistrarAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 301);
            this.Controls.Add(this.Apellido1);
            this.Controls.Add(this.Matricula1);
            this.Controls.Add(this.nombre1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegistrarAlumnos";
            this.Text = "RegistrarAlumnos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nombre1;
        private System.Windows.Forms.TextBox Matricula1;
        private System.Windows.Forms.TextBox Apellido1;
    }
}