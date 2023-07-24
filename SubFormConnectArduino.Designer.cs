namespace Supervisório_PCA_2._0
{
    partial class SubFormConnectArduino
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.connectPortSub = new System.Windows.Forms.Button();
            this.disconnectPortSub = new System.Windows.Forms.Button();
            this.portsBoxSub = new System.Windows.Forms.ComboBox();
            this.searchPortsSub = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // connectPortSub
            // 
            this.connectPortSub.Location = new System.Drawing.Point(187, 79);
            this.connectPortSub.Name = "connectPortSub";
            this.connectPortSub.Size = new System.Drawing.Size(121, 30);
            this.connectPortSub.TabIndex = 16;
            this.connectPortSub.Text = "Conectar";
            this.connectPortSub.UseVisualStyleBackColor = true;
            this.connectPortSub.Click += new System.EventHandler(this.connectPortSub_Click);
            // 
            // disconnectPortSub
            // 
            this.disconnectPortSub.Location = new System.Drawing.Point(15, 79);
            this.disconnectPortSub.Name = "disconnectPortSub";
            this.disconnectPortSub.Size = new System.Drawing.Size(161, 30);
            this.disconnectPortSub.TabIndex = 15;
            this.disconnectPortSub.Text = "Desconectar";
            this.disconnectPortSub.UseVisualStyleBackColor = true;
            this.disconnectPortSub.Click += new System.EventHandler(this.disconnectPortSub_Click);
            // 
            // portsBoxSub
            // 
            this.portsBoxSub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portsBoxSub.FormattingEnabled = true;
            this.portsBoxSub.Location = new System.Drawing.Point(187, 44);
            this.portsBoxSub.Name = "portsBoxSub";
            this.portsBoxSub.Size = new System.Drawing.Size(121, 29);
            this.portsBoxSub.TabIndex = 14;
            // 
            // searchPortsSub
            // 
            this.searchPortsSub.Location = new System.Drawing.Point(15, 41);
            this.searchPortsSub.Name = "searchPortsSub";
            this.searchPortsSub.Size = new System.Drawing.Size(161, 32);
            this.searchPortsSub.TabIndex = 13;
            this.searchPortsSub.Text = "Buscar Portas COM";
            this.searchPortsSub.UseVisualStyleBackColor = true;
            this.searchPortsSub.Click += new System.EventHandler(this.searchPortsSub_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(15, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 22);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Conexão com Arduino:";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(182, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(126, 22);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "Não conectado!";
            // 
            // SubFormConnectArduino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(330, 125);
            this.Controls.Add(this.connectPortSub);
            this.Controls.Add(this.disconnectPortSub);
            this.Controls.Add(this.portsBoxSub);
            this.Controls.Add(this.searchPortsSub);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SubFormConnectArduino";
            this.Text = "Configurar Conexão com Arduino";
            this.Load += new System.EventHandler(this.SubFormConnectArduino_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button connectPortSub;
        private System.Windows.Forms.Button disconnectPortSub;
        private System.Windows.Forms.ComboBox portsBoxSub;
        private System.Windows.Forms.Button searchPortsSub;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}