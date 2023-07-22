using System.Windows.Forms;

namespace Supervisório_PCA_2._0
{
    partial class SubFormConfigSampling
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
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.grGeral = new System.Windows.Forms.GroupBox();
            this.lblUnitInterval = new System.Windows.Forms.Label();
            this.grVazao = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEWMAVazao = new System.Windows.Forms.Label();
            this.txtEWMAVazao = new System.Windows.Forms.TextBox();
            this.lblUnitMMVazao = new System.Windows.Forms.Label();
            this.lblMMvazao = new System.Windows.Forms.Label();
            this.txtMMVazao = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEWMATemp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMMTemp = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.grGeral.SuspendLayout();
            this.grVazao.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInterval
            // 
            this.txtInterval.AcceptsReturn = true;
            this.txtInterval.Location = new System.Drawing.Point(258, 22);
            this.txtInterval.MaxLength = 5;
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(100, 29);
            this.txtInterval.TabIndex = 0;
            this.txtInterval.Text = "500";
            this.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInterval.TextChanged += new System.EventHandler(this.txtInterval_TextChanged);
            this.txtInterval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInterval_KeyDown);
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(15, 25);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(186, 21);
            this.lblInterval.TabIndex = 1;
            this.lblInterval.Text = "Intervalo de Amostragem";
            // 
            // grGeral
            // 
            this.grGeral.Controls.Add(this.lblUnitInterval);
            this.grGeral.Controls.Add(this.lblInterval);
            this.grGeral.Controls.Add(this.txtInterval);
            this.grGeral.Location = new System.Drawing.Point(12, 12);
            this.grGeral.Name = "grGeral";
            this.grGeral.Size = new System.Drawing.Size(449, 66);
            this.grGeral.TabIndex = 2;
            this.grGeral.TabStop = false;
            this.grGeral.Text = "Geral";
            // 
            // lblUnitInterval
            // 
            this.lblUnitInterval.AutoSize = true;
            this.lblUnitInterval.Location = new System.Drawing.Point(412, 25);
            this.lblUnitInterval.Name = "lblUnitInterval";
            this.lblUnitInterval.Size = new System.Drawing.Size(31, 21);
            this.lblUnitInterval.TabIndex = 2;
            this.lblUnitInterval.Text = "ms";
            // 
            // grVazao
            // 
            this.grVazao.Controls.Add(this.label1);
            this.grVazao.Controls.Add(this.lblEWMAVazao);
            this.grVazao.Controls.Add(this.txtEWMAVazao);
            this.grVazao.Controls.Add(this.lblUnitMMVazao);
            this.grVazao.Controls.Add(this.lblMMvazao);
            this.grVazao.Controls.Add(this.txtMMVazao);
            this.grVazao.Location = new System.Drawing.Point(12, 84);
            this.grVazao.Name = "grVazao";
            this.grVazao.Size = new System.Drawing.Size(449, 118);
            this.grVazao.TabIndex = 3;
            this.grVazao.TabStop = false;
            this.grVazao.Text = "Parâmetros da Filtragem da Tomada de Vazão";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 21);
            this.label1.TabIndex = 5;
            // 
            // lblEWMAVazao
            // 
            this.lblEWMAVazao.AutoSize = true;
            this.lblEWMAVazao.Location = new System.Drawing.Point(15, 60);
            this.lblEWMAVazao.Name = "lblEWMAVazao";
            this.lblEWMAVazao.Size = new System.Drawing.Size(178, 42);
            this.lblEWMAVazao.TabIndex = 4;
            this.lblEWMAVazao.Text = "Parâmetro (α) da Média \r\nMóvel Exponencial";
            // 
            // txtEWMAVazao
            // 
            this.txtEWMAVazao.AcceptsReturn = true;
            this.txtEWMAVazao.Location = new System.Drawing.Point(258, 68);
            this.txtEWMAVazao.MaxLength = 5;
            this.txtEWMAVazao.Name = "txtEWMAVazao";
            this.txtEWMAVazao.Size = new System.Drawing.Size(100, 29);
            this.txtEWMAVazao.TabIndex = 2;
            this.txtEWMAVazao.Text = "0.4";
            this.txtEWMAVazao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEWMAVazao.TextChanged += new System.EventHandler(this.txtEWMAVazao_TextChanged);
            this.txtEWMAVazao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEWMAVazao_KeyDown);
            // 
            // lblUnitMMVazao
            // 
            this.lblUnitMMVazao.AutoSize = true;
            this.lblUnitMMVazao.Location = new System.Drawing.Point(385, 25);
            this.lblUnitMMVazao.Name = "lblUnitMMVazao";
            this.lblUnitMMVazao.Size = new System.Drawing.Size(58, 21);
            this.lblUnitMMVazao.TabIndex = 2;
            this.lblUnitMMVazao.Text = "pontos";
            // 
            // lblMMvazao
            // 
            this.lblMMvazao.AutoSize = true;
            this.lblMMvazao.Location = new System.Drawing.Point(15, 25);
            this.lblMMvazao.Name = "lblMMvazao";
            this.lblMMvazao.Size = new System.Drawing.Size(188, 21);
            this.lblMMvazao.TabIndex = 1;
            this.lblMMvazao.Text = "Tamanho da Média Móvel";
            this.lblMMvazao.Click += new System.EventHandler(this.lblMMvazao_Click);
            // 
            // txtMMVazao
            // 
            this.txtMMVazao.AcceptsReturn = true;
            this.txtMMVazao.Location = new System.Drawing.Point(258, 24);
            this.txtMMVazao.MaxLength = 5;
            this.txtMMVazao.Name = "txtMMVazao";
            this.txtMMVazao.Size = new System.Drawing.Size(100, 29);
            this.txtMMVazao.TabIndex = 1;
            this.txtMMVazao.Text = "5";
            this.txtMMVazao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMMVazao.TextChanged += new System.EventHandler(this.txtMMVazao_TextChanged);
            this.txtMMVazao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMMVazao_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEWMATemp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMMTemp);
            this.groupBox1.Location = new System.Drawing.Point(12, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 118);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parâmetros da Filtragem da Tomada de Temperatura";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 21);
            this.label2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 42);
            this.label3.TabIndex = 4;
            this.label3.Text = "Parâmetro (α) da Média \r\nMóvel Exponencial";
            // 
            // txtEWMATemp
            // 
            this.txtEWMATemp.AcceptsReturn = true;
            this.txtEWMATemp.Location = new System.Drawing.Point(258, 68);
            this.txtEWMATemp.MaxLength = 5;
            this.txtEWMATemp.Name = "txtEWMATemp";
            this.txtEWMATemp.Size = new System.Drawing.Size(100, 29);
            this.txtEWMATemp.TabIndex = 4;
            this.txtEWMATemp.Text = "0.1";
            this.txtEWMATemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEWMATemp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEWMATemp_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "pontos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tamanho da Média Móvel";
            // 
            // txtMMTemp
            // 
            this.txtMMTemp.AcceptsReturn = true;
            this.txtMMTemp.Location = new System.Drawing.Point(258, 24);
            this.txtMMTemp.MaxLength = 5;
            this.txtMMTemp.Name = "txtMMTemp";
            this.txtMMTemp.Size = new System.Drawing.Size(100, 29);
            this.txtMMTemp.TabIndex = 3;
            this.txtMMTemp.Text = "5";
            this.txtMMTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMMTemp.TextChanged += new System.EventHandler(this.txtMMTemp_TextChanged);
            this.txtMMTemp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMMTemp_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Ajuda";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.textBox3.Location = new System.Drawing.Point(267, 333);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(194, 31);
            this.textBox3.TabIndex = 9;
            this.textBox3.Text = "Recomenda-se a leitura do apêndice A.1 do manual de operação do PCA";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SubFormConfigSampling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(473, 369);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grVazao);
            this.Controls.Add(this.grGeral);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SubFormConfigSampling";
            this.Text = "Configurações de Amostragem";
            this.Load += new System.EventHandler(this.SubFormConfigSampling_Load);
            this.grGeral.ResumeLayout(false);
            this.grGeral.PerformLayout();
            this.grVazao.ResumeLayout(false);
            this.grVazao.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.GroupBox grGeral;
        private System.Windows.Forms.Label lblUnitInterval;
        private GroupBox grVazao;
        private Label lblUnitMMVazao;
        private Label lblMMvazao;
        private TextBox txtMMVazao;
        private Label label1;
        private Label lblEWMAVazao;
        private TextBox txtEWMAVazao;
        private GroupBox groupBox1;
        private Label label2;
        private Label label3;
        private TextBox txtEWMATemp;
        private Label label4;
        private Label label5;
        private TextBox txtMMTemp;
        private Button button1;
        private TextBox textBox3;
    }
}