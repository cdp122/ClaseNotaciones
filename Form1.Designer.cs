namespace ClaseNotaciones
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInfija = new System.Windows.Forms.TextBox();
            this.txtPosfija = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTransformar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnValidar = new System.Windows.Forms.Button();
            this.btnEvaluar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Notaciones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MV Boli", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 170);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Expresión Infija";
            // 
            // txtInfija
            // 
            this.txtInfija.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfija.Location = new System.Drawing.Point(263, 170);
            this.txtInfija.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtInfija.Name = "txtInfija";
            this.txtInfija.Size = new System.Drawing.Size(375, 37);
            this.txtInfija.TabIndex = 2;
            this.txtInfija.Enter += new System.EventHandler(this.Focus_Enter);
            this.txtInfija.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyEnter);
            // 
            // txtPosfija
            // 
            this.txtPosfija.BackColor = System.Drawing.Color.White;
            this.txtPosfija.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosfija.Location = new System.Drawing.Point(262, 223);
            this.txtPosfija.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPosfija.Name = "txtPosfija";
            this.txtPosfija.ReadOnly = true;
            this.txtPosfija.Size = new System.Drawing.Size(375, 37);
            this.txtPosfija.TabIndex = 4;
            this.txtPosfija.Enter += new System.EventHandler(this.Focus_Enter);
            this.txtPosfija.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MV Boli", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 223);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Expresión Posfija";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MV Boli", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(165, 66);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "Realizado Por:";
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.BackColor = System.Drawing.Color.White;
            this.txtRespuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRespuesta.Location = new System.Drawing.Point(263, 270);
            this.txtRespuesta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.ReadOnly = true;
            this.txtRespuesta.Size = new System.Drawing.Size(375, 37);
            this.txtRespuesta.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MV Boli", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(46, 274);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 32);
            this.label6.TabIndex = 10;
            this.label6.Text = "Resultado";
            // 
            // btnTransformar
            // 
            this.btnTransformar.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransformar.Location = new System.Drawing.Point(644, 221);
            this.btnTransformar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTransformar.Name = "btnTransformar";
            this.btnTransformar.Size = new System.Drawing.Size(115, 37);
            this.btnTransformar.TabIndex = 11;
            this.btnTransformar.Text = "Transformar";
            this.btnTransformar.UseVisualStyleBackColor = true;
            this.btnTransformar.Click += new System.EventHandler(this.btnTransformar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MV Boli", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(349, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 96);
            this.label4.TabIndex = 12;
            this.label4.Text = "Kevin Arteaga\r\nCarlos Puentestar\r\nAdrián Urresta";
            // 
            // btnValidar
            // 
            this.btnValidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnValidar.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidar.Location = new System.Drawing.Point(645, 172);
            this.btnValidar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(114, 37);
            this.btnValidar.TabIndex = 13;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // btnEvaluar
            // 
            this.btnEvaluar.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvaluar.Location = new System.Drawing.Point(644, 267);
            this.btnEvaluar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEvaluar.Name = "btnEvaluar";
            this.btnEvaluar.Size = new System.Drawing.Size(115, 37);
            this.btnEvaluar.TabIndex = 14;
            this.btnEvaluar.Text = "Evaluar";
            this.btnEvaluar.UseVisualStyleBackColor = true;
            this.btnEvaluar.Click += new System.EventHandler(this.btnEvaluar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(797, 348);
            this.Controls.Add(this.btnEvaluar);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTransformar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRespuesta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPosfija);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInfija);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Notaciones";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInfija;
        private System.Windows.Forms.TextBox txtPosfija;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTransformar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Button btnEvaluar;
    }
}

