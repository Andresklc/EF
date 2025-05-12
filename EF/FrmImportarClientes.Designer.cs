namespace EF
{
    partial class FrmImportarClientes
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
            this.btnImportar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDireccionPC = new System.Windows.Forms.TextBox();
            this.btnSelecion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(363, 73);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(76, 24);
            this.btnImportar.TabIndex = 20;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(139, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "Importar Clientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nombre del archivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Direccion";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(143, 73);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(214, 20);
            this.txtNombre.TabIndex = 14;
            this.txtNombre.Text = "Cliente";
            // 
            // txtDireccionPC
            // 
            this.txtDireccionPC.Location = new System.Drawing.Point(143, 47);
            this.txtDireccionPC.Name = "txtDireccionPC";
            this.txtDireccionPC.Size = new System.Drawing.Size(214, 20);
            this.txtDireccionPC.TabIndex = 15;
            // 
            // btnSelecion
            // 
            this.btnSelecion.Location = new System.Drawing.Point(363, 43);
            this.btnSelecion.Name = "btnSelecion";
            this.btnSelecion.Size = new System.Drawing.Size(76, 26);
            this.btnSelecion.TabIndex = 13;
            this.btnSelecion.Text = "Navegar..";
            this.btnSelecion.UseVisualStyleBackColor = true;
            this.btnSelecion.Click += new System.EventHandler(this.btnSelecion_Click);
            // 
            // FrmImportarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(501, 126);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtDireccionPC);
            this.Controls.Add(this.btnSelecion);
            this.Name = "FrmImportarClientes";
            this.Text = "FrmImportarClientecs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDireccionPC;
        private System.Windows.Forms.Button btnSelecion;
    }
}