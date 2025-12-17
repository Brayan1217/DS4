namespace Proyecto1
{
    partial class Calculadora
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
            Pantalla = new TextBox();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnSum = new Button();
            btnRes = new Button();
            btnDivi = new Button();
            btn0 = new Button();
            btnBorrarTodo = new Button();
            btnIgual = new Button();
            btnMultipli = new Button();
            btnPotenci = new Button();
            btnRaiz = new Button();
            btnBorrar = new Button();
            SuspendLayout();
            // 
            // Pantalla
            // 
            Pantalla.Font = new Font("Consolas", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Pantalla.Location = new Point(12, 12);
            Pantalla.Name = "Pantalla";
            Pantalla.Size = new Size(311, 63);
            Pantalla.TabIndex = 0;
            Pantalla.Text = "   ";
            Pantalla.TextAlign = HorizontalAlignment.Right;
            // 
            // btn1
            // 
            btn1.Location = new Point(12, 209);
            btn1.Name = "btn1";
            btn1.Size = new Size(73, 68);
            btn1.TabIndex = 1;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(91, 209);
            btn2.Name = "btn2";
            btn2.Size = new Size(73, 68);
            btn2.TabIndex = 2;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(170, 209);
            btn3.Name = "btn3";
            btn3.Size = new Size(73, 68);
            btn3.TabIndex = 3;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn3_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(12, 283);
            btn4.Name = "btn4";
            btn4.Size = new Size(73, 68);
            btn4.TabIndex = 4;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btn4_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(91, 283);
            btn5.Name = "btn5";
            btn5.Size = new Size(73, 68);
            btn5.TabIndex = 5;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btn5_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(171, 283);
            btn6.Name = "btn6";
            btn6.Size = new Size(73, 68);
            btn6.TabIndex = 6;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btn6_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(12, 357);
            btn7.Name = "btn7";
            btn7.Size = new Size(73, 68);
            btn7.TabIndex = 7;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btn7_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(91, 357);
            btn8.Name = "btn8";
            btn8.Size = new Size(73, 68);
            btn8.TabIndex = 8;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btn8_Click;
            // 
            // btn9
            // 
            btn9.Location = new Point(170, 357);
            btn9.Name = "btn9";
            btn9.Size = new Size(73, 68);
            btn9.TabIndex = 9;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btn9_Click;
            // 
            // btnSum
            // 
            btnSum.Location = new Point(250, 209);
            btnSum.Name = "btnSum";
            btnSum.Size = new Size(73, 68);
            btnSum.TabIndex = 10;
            btnSum.Text = "+";
            btnSum.UseVisualStyleBackColor = true;
            btnSum.Click += btnSum_Click;
            // 
            // btnRes
            // 
            btnRes.Location = new Point(250, 283);
            btnRes.Name = "btnRes";
            btnRes.Size = new Size(73, 68);
            btnRes.TabIndex = 11;
            btnRes.Text = "-";
            btnRes.UseVisualStyleBackColor = true;
            btnRes.Click += btnRes_Click;
            // 
            // btnDivi
            // 
            btnDivi.Location = new Point(250, 357);
            btnDivi.Name = "btnDivi";
            btnDivi.Size = new Size(73, 68);
            btnDivi.TabIndex = 12;
            btnDivi.Text = "/";
            btnDivi.UseVisualStyleBackColor = true;
            btnDivi.Click += btnDivi_Click;
            // 
            // btn0
            // 
            btn0.Location = new Point(91, 431);
            btn0.Name = "btn0";
            btn0.Size = new Size(73, 68);
            btn0.TabIndex = 13;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += btn0_Click;
            // 
            // btnBorrarTodo
            // 
            btnBorrarTodo.Location = new Point(250, 135);
            btnBorrarTodo.Name = "btnBorrarTodo";
            btnBorrarTodo.Size = new Size(73, 68);
            btnBorrarTodo.TabIndex = 14;
            btnBorrarTodo.Text = "CE";
            btnBorrarTodo.UseVisualStyleBackColor = true;
            btnBorrarTodo.Click += btnBorrarTodo_Click;
            // 
            // btnIgual
            // 
            btnIgual.Location = new Point(170, 431);
            btnIgual.Name = "btnIgual";
            btnIgual.Size = new Size(73, 68);
            btnIgual.TabIndex = 15;
            btnIgual.Text = "=";
            btnIgual.UseVisualStyleBackColor = true;
            btnIgual.Click += btnIgual_Click;
            // 
            // btnMultipli
            // 
            btnMultipli.Location = new Point(250, 431);
            btnMultipli.Name = "btnMultipli";
            btnMultipli.Size = new Size(73, 68);
            btnMultipli.TabIndex = 16;
            btnMultipli.Text = "*";
            btnMultipli.UseVisualStyleBackColor = true;
            btnMultipli.Click += btnMultipli_Click;
            // 
            // btnPotenci
            // 
            btnPotenci.Location = new Point(12, 135);
            btnPotenci.Name = "btnPotenci";
            btnPotenci.Size = new Size(73, 68);
            btnPotenci.TabIndex = 17;
            btnPotenci.Text = "^";
            btnPotenci.UseVisualStyleBackColor = true;
            btnPotenci.Click += btnPotenci_Click;
            // 
            // btnRaiz
            // 
            btnRaiz.Location = new Point(91, 135);
            btnRaiz.Name = "btnRaiz";
            btnRaiz.Size = new Size(73, 68);
            btnRaiz.TabIndex = 18;
            btnRaiz.Text = "√";
            btnRaiz.UseVisualStyleBackColor = true;
            btnRaiz.Click += btnRaiz_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(170, 135);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(73, 68);
            btnBorrar.TabIndex = 19;
            btnBorrar.Text = "C";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // Calculadora
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(335, 511);
            Controls.Add(btnBorrar);
            Controls.Add(btnRaiz);
            Controls.Add(btnPotenci);
            Controls.Add(btnMultipli);
            Controls.Add(btnIgual);
            Controls.Add(btnBorrarTodo);
            Controls.Add(btn0);
            Controls.Add(btnDivi);
            Controls.Add(btnRes);
            Controls.Add(btnSum);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Controls.Add(Pantalla);
            Name = "Calculadora";
            Text = "Calculadora";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Pantalla;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btnSum;
        private Button btnRes;
        private Button btnDivi;
        private Button btn0;
        private Button btnBorrarTodo;
        private Button btnIgual;
        private Button btnMultipli;
        private Button btnPotenci;
        private Button btnRaiz;
        private Button btnBorrar;
    }
}
