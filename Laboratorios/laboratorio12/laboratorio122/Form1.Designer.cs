namespace laboratorio122
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            btn_calcularPromedio = new Button();
            btn_limpiar = new Button();
            btn_salir = new Button();
            label4 = new Label();
            label5 = new Label();
            textBox4 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 77);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Nota No 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 110);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Nota No 2";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 144);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 2;
            label3.Text = "Nota No 3";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(113, 69);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(113, 107);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(113, 141);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 5;
            // 
            // btn_calcularPromedio
            // 
            btn_calcularPromedio.Location = new Point(38, 195);
            btn_calcularPromedio.Name = "btn_calcularPromedio";
            btn_calcularPromedio.Size = new Size(75, 23);
            btn_calcularPromedio.TabIndex = 6;
            btn_calcularPromedio.Text = "Promedio";
            btn_calcularPromedio.UseVisualStyleBackColor = true;
            btn_calcularPromedio.Click += btn_calcularPromedio_Click;
            // 
            // btn_limpiar
            // 
            btn_limpiar.Location = new Point(138, 195);
            btn_limpiar.Name = "btn_limpiar";
            btn_limpiar.Size = new Size(58, 23);
            btn_limpiar.TabIndex = 7;
            btn_limpiar.Text = "Reset";
            btn_limpiar.UseVisualStyleBackColor = true;
            btn_limpiar.Click += btn_limpiar_Click;
            // 
            // btn_salir
            // 
            btn_salir.Location = new Point(230, 195);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(58, 23);
            btn_salir.TabIndex = 8;
            btn_salir.Text = "Salir";
            btn_salir.UseVisualStyleBackColor = true;
            btn_salir.Click += btn_salir_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(139, 15);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 9;
            label4.Text = "label4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 252);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 10;
            label5.Text = "label5";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(113, 244);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(120, 23);
            textBox4.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 450);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btn_salir);
            Controls.Add(btn_limpiar);
            Controls.Add(btn_calcularPromedio);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button btn_calcularPromedio;
        private Button btn_limpiar;
        private Button btn_salir;
        private Label label4;
        private Label label5;
        private TextBox textBox4;
    }
}
