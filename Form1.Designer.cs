namespace SmartGym2
{
      #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion
    
    {
        partial class Form1
        {
            private System.ComponentModel.IContainer components = null;
            private Button btnEjecutarLógica; // El botón para ejecutar la lógica

            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            private void InitializeComponent()
            {
                this.btnEjecutarLógica = new System.Windows.Forms.Button();
                this.SuspendLayout();

                // 
                // btnEjecutarLógica
                // 
                this.btnEjecutarLógica.Location = new System.Drawing.Point(100, 100); // Ubicación del botón
                this.btnEjecutarLógica.Name = "btnEjecutarLógica";
                this.btnEjecutarLógica.Size = new System.Drawing.Size(150, 30);
                this.btnEjecutarLógica.TabIndex = 0;
                this.btnEjecutarLógica.Text = "Ejecutar Lógica";
                this.btnEjecutarLógica.UseVisualStyleBackColor = true;
                this.btnEjecutarLógica.Click += new System.EventHandler(this.btnEjecutarLógica_Click); // Evento del clic

                // 
                // Form1
                // 
                this.ClientSize = new System.Drawing.Size(800, 450);
                this.Controls.Add(this.btnEjecutarLógica);
                this.Name = "Form1";
                this.Text = "SmartGym";
                this.ResumeLayout(false);
            }
        }
    }

}
