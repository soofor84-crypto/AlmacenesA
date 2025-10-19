namespace AlmacenesA
{
    partial class frmPermisos
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
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.rbtLeerAbrir = new System.Windows.Forms.RadioButton();
            this.rbtEscritura = new System.Windows.Forms.RadioButton();
            this.CmbAccesos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.Red;
            this.BtnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCancelar.Location = new System.Drawing.Point(372, 155);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(119, 44);
            this.BtnCancelar.TabIndex = 35;
            this.BtnCancelar.Text = "CANCELAR";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.BackColor = System.Drawing.Color.DarkGreen;
            this.BtnAceptar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnAceptar.Location = new System.Drawing.Point(157, 155);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(111, 44);
            this.BtnAceptar.TabIndex = 34;
            this.BtnAceptar.Text = "ACEPTAR";
            this.BtnAceptar.UseVisualStyleBackColor = false;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // rbtLeerAbrir
            // 
            this.rbtLeerAbrir.AutoSize = true;
            this.rbtLeerAbrir.Location = new System.Drawing.Point(379, 87);
            this.rbtLeerAbrir.Name = "rbtLeerAbrir";
            this.rbtLeerAbrir.Size = new System.Drawing.Size(112, 24);
            this.rbtLeerAbrir.TabIndex = 33;
            this.rbtLeerAbrir.TabStop = true;
            this.rbtLeerAbrir.Text = "Leer y abrir";
            this.rbtLeerAbrir.UseVisualStyleBackColor = true;
            // 
            // rbtEscritura
            // 
            this.rbtEscritura.AutoSize = true;
            this.rbtEscritura.Location = new System.Drawing.Point(261, 83);
            this.rbtEscritura.Name = "rbtEscritura";
            this.rbtEscritura.Size = new System.Drawing.Size(97, 24);
            this.rbtEscritura.TabIndex = 32;
            this.rbtEscritura.TabStop = true;
            this.rbtEscritura.Text = "Escritura";
            this.rbtEscritura.UseVisualStyleBackColor = true;
            // 
            // CmbAccesos
            // 
            this.CmbAccesos.FormattingEnabled = true;
            this.CmbAccesos.Items.AddRange(new object[] {
            "Productos",
            "Usuarios"});
            this.CmbAccesos.Location = new System.Drawing.Point(35, 83);
            this.CmbAccesos.Name = "CmbAccesos";
            this.CmbAccesos.Size = new System.Drawing.Size(165, 28);
            this.CmbAccesos.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Accesos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Permisos";
            // 
            // frmPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 239);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.rbtLeerAbrir);
            this.Controls.Add(this.rbtEscritura);
            this.Controls.Add(this.CmbAccesos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "frmPermisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPermisos";
            this.Load += new System.EventHandler(this.frmPermisos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.RadioButton rbtLeerAbrir;
        private System.Windows.Forms.RadioButton rbtEscritura;
        private System.Windows.Forms.ComboBox CmbAccesos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}