namespace laboratorio14
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tsbNuevo = new Button();
            tsbGuardar = new Button();
            tsbCancelar = new Button();
            tsbEliminar = new Button();
            tsbBuscar = new Button();
            btnSalir = new Button();
            txtPrecio = new TextBox();
            txtStock = new TextBox();
            txtNombre = new TextBox();
            txtId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tsdId = new Label();
            textBox5 = new TextBox();
            SuspendLayout();
            // 
            // tsbNuevo
            // 
            tsbNuevo.BackgroundImage = (Image)resources.GetObject("tsbNuevo.BackgroundImage");
            tsbNuevo.BackgroundImageLayout = ImageLayout.Stretch;
            tsbNuevo.Location = new Point(2, 2);
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(31, 23);
            tsbNuevo.TabIndex = 0;
            tsbNuevo.UseVisualStyleBackColor = true;
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbGuardar
            // 
            tsbGuardar.BackgroundImage = (Image)resources.GetObject("tsbGuardar.BackgroundImage");
            tsbGuardar.BackgroundImageLayout = ImageLayout.Stretch;
            tsbGuardar.Location = new Point(39, 3);
            tsbGuardar.Name = "tsbGuardar";
            tsbGuardar.Size = new Size(33, 23);
            tsbGuardar.TabIndex = 1;
            tsbGuardar.UseVisualStyleBackColor = true;
            tsbGuardar.Click += tsbGuardar_Click;
            // 
            // tsbCancelar
            // 
            tsbCancelar.BackgroundImage = (Image)resources.GetObject("tsbCancelar.BackgroundImage");
            tsbCancelar.BackgroundImageLayout = ImageLayout.Stretch;
            tsbCancelar.Location = new Point(78, 3);
            tsbCancelar.Name = "tsbCancelar";
            tsbCancelar.Size = new Size(25, 23);
            tsbCancelar.TabIndex = 2;
            tsbCancelar.UseVisualStyleBackColor = true;
            // 
            // tsbEliminar
            // 
            tsbEliminar.BackgroundImage = (Image)resources.GetObject("tsbEliminar.BackgroundImage");
            tsbEliminar.BackgroundImageLayout = ImageLayout.Stretch;
            tsbEliminar.Location = new Point(109, 3);
            tsbEliminar.Name = "tsbEliminar";
            tsbEliminar.Size = new Size(21, 23);
            tsbEliminar.TabIndex = 3;
            tsbEliminar.UseVisualStyleBackColor = true;
            // 
            // tsbBuscar
            // 
            tsbBuscar.BackgroundImage = (Image)resources.GetObject("tsbBuscar.BackgroundImage");
            tsbBuscar.BackgroundImageLayout = ImageLayout.Stretch;
            tsbBuscar.Location = new Point(370, 2);
            tsbBuscar.Name = "tsbBuscar";
            tsbBuscar.Size = new Size(24, 23);
            tsbBuscar.TabIndex = 4;
            tsbBuscar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(21, 277);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(21, 204);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 6;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(199, 204);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 7;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(233, 93);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(344, 23);
            txtNombre.TabIndex = 8;
            // 
            // txtId
            // 
            txtId.Location = new Point(21, 93);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 75);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 10;
            label1.Text = "ID";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(257, 68);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 11;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 180);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 12;
            label3.Text = "Precio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(212, 182);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 13;
            label4.Text = "Stock";
            // 
            // tsdId
            // 
            tsdId.AutoSize = true;
            tsdId.Location = new Point(147, 7);
            tsdId.Name = "tsdId";
            tsdId.Size = new Size(79, 15);
            tsdId.TabIndex = 15;
            tsdId.Text = "Buscar por id:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(233, 3);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(131, 23);
            textBox5.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox5);
            Controls.Add(tsdId);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtId);
            Controls.Add(txtNombre);
            Controls.Add(txtStock);
            Controls.Add(txtPrecio);
            Controls.Add(btnSalir);
            Controls.Add(tsbBuscar);
            Controls.Add(tsbEliminar);
            Controls.Add(tsbCancelar);
            Controls.Add(tsbGuardar);
            Controls.Add(tsbNuevo);
            Name = "Form1";
            Text = "frmProductos";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button tsbNuevo;
        private Button tsbGuardar;
        private Button tsbCancelar;
        private Button tsbEliminar;
        private Button tsbBuscar;
        private Button btnSalir;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private TextBox txtNombre;
        private TextBox txtId;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label tsdId;
        private TextBox textBox5;
    }
}
