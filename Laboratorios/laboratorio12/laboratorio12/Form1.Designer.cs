namespace laboratorio12
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Calcular = new Button();
            btn_limpiar = new Button();
            btn_salir = new Button();
            lblVelocidad = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // btn_Calcular
            // 
            btn_Calcular.Location = new Point(96, 192);
            btn_Calcular.Name = "btn_Calcular";
            btn_Calcular.Size = new Size(75, 23);
            btn_Calcular.TabIndex = 0;
            btn_Calcular.Text = "Calcular";
            btn_Calcular.UseVisualStyleBackColor = true;
            btn_Calcular.Click += button1_Click;
            // 
            // btn_limpiar
            // 
            btn_limpiar.Location = new Point(216, 192);
            btn_limpiar.Name = "btn_limpiar";
            btn_limpiar.Size = new Size(75, 23);
            btn_limpiar.TabIndex = 1;
            btn_limpiar.Text = "Limpiar";
            btn_limpiar.UseVisualStyleBackColor = true;
            btn_limpiar.Click += btn_limpiar_Click;
            // 
            // btn_salir
            // 
            btn_salir.Location = new Point(328, 192);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(75, 23);
            btn_salir.TabIndex = 2;
            btn_salir.Text = "Salir";
            btn_salir.UseVisualStyleBackColor = true;
            btn_salir.Click += btn_salir_Click;
            // 
            // lblVelocidad
            // 
            lblVelocidad.AutoSize = true;
            lblVelocidad.Location = new Point(182, 20);
            lblVelocidad.Name = "lblVelocidad";
            lblVelocidad.Size = new Size(58, 15);
            lblVelocidad.TabIndex = 3;
            lblVelocidad.Text = "Velocidad";
            lblVelocidad.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(96, 75);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 4;
            label2.Text = "Velocidad";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(97, 144);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 5;
            label3.Text = "Tiempo";
            label3.Click += label3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(216, 67);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(216, 136);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(216, 235);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(119, 243);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 11;
            label4.Text = "Resultado";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblVelocidad);
            Controls.Add(btn_salir);
            Controls.Add(btn_limpiar);
            Controls.Add(btn_Calcular);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Calcular;
        private Button btn_limpiar;
        private Button btn_salir;
        private Label lblVelocidad;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label4;
    }
}
