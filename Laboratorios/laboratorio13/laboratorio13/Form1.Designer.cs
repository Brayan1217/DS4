namespace laboratorio13
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
            btn_sql = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // btn_sql
            // 
            btn_sql.Location = new Point(12, 12);
            btn_sql.Name = "btn_sql";
            btn_sql.Size = new Size(161, 105);
            btn_sql.TabIndex = 0;
            btn_sql.Text = "Conectar y desconectar de SQL Server";
            btn_sql.UseVisualStyleBackColor = true;
            btn_sql.Click += btn_sql_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(302, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(250, 184);
            listBox1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox1);
            Controls.Add(btn_sql);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_sql;
        private ListBox listBox1;
    }
}
