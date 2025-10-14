namespace laboratorio123
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
            btn_semiP = new Button();
            btn_area = new Button();
            btn_limpiar = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            btn_salir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 36);
            label1.Name = "label1";
            label1.Size = new Size(161, 15);
            label1.TabIndex = 0;
            label1.Text = "Ingrese la longitud del lado A";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 67);
            label2.Name = "label2";
            label2.Size = new Size(160, 15);
            label2.TabIndex = 1;
            label2.Text = "Ingrese la longitud del lado B";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 98);
            label3.Name = "label3";
            label3.Size = new Size(161, 15);
            label3.TabIndex = 2;
            label3.Text = "Ingrese la longitud del lado C";
            // 
            // btn_semiP
            // 
            btn_semiP.Location = new Point(12, 142);
            btn_semiP.Name = "btn_semiP";
            btn_semiP.Size = new Size(103, 23);
            btn_semiP.TabIndex = 3;
            btn_semiP.Text = "Semiperimetro";
            btn_semiP.UseVisualStyleBackColor = true;
            btn_semiP.Click += btn_semiP_Click;
            // 
            // btn_area
            // 
            btn_area.Location = new Point(152, 142);
            btn_area.Name = "btn_area";
            btn_area.Size = new Size(75, 23);
            btn_area.TabIndex = 4;
            btn_area.Text = "Area";
            btn_area.UseVisualStyleBackColor = true;
            btn_area.Click += btn_area_Click;
            // 
            // btn_limpiar
            // 
            btn_limpiar.Location = new Point(260, 142);
            btn_limpiar.Name = "btn_limpiar";
            btn_limpiar.Size = new Size(75, 23);
            btn_limpiar.TabIndex = 5;
            btn_limpiar.Text = "Reset";
            btn_limpiar.UseVisualStyleBackColor = true;
            btn_limpiar.Click += btn_limpiar_Click_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(247, 98);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(247, 62);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(247, 33);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(166, 185);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 9;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(166, 233);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 193);
            label4.Name = "label4";
            label4.Size = new Size(131, 15);
            label4.TabIndex = 11;
            label4.Text = "Calcular Semiperimetro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 241);
            label5.Name = "label5";
            label5.Size = new Size(103, 15);
            label5.TabIndex = 12;
            label5.Text = "Area del Triangulo";
            // 
            // btn_salir
            // 
            btn_salir.Location = new Point(363, 142);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(75, 23);
            btn_salir.TabIndex = 13;
            btn_salir.Text = "Salida";
            btn_salir.UseVisualStyleBackColor = true;
            btn_salir.Click += btn_salir_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_salir);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(btn_limpiar);
            Controls.Add(btn_area);
            Controls.Add(btn_semiP);
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
        private Button btn_semiP;
        private Button btn_area;
        private Button btn_limpiar;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label4;
        private Label label5;
        private Button btn_salir;
    }
}
