namespace Supervisório_PCA_2._0
{
    partial class SubFormONOFFTuningZieglerNichols
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblUnitHisterese = new System.Windows.Forms.Label();
            this.txtHysteresis = new System.Windows.Forms.TextBox();
            this.lblHisterese = new System.Windows.Forms.Label();
            this.lblUnitSP = new System.Windows.Forms.Label();
            this.txtSetpoint = new System.Windows.Forms.TextBox();
            this.lblSetpoint = new System.Windows.Forms.Label();
            this.btnVazao = new System.Windows.Forms.Button();
            this.tabelaControle = new System.Windows.Forms.DataGridView();
            this.Método = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUnitAmplitude = new System.Windows.Forms.Label();
            this.txtAmplitude = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sistemaSelecionado = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaControle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUnitHisterese
            // 
            this.lblUnitHisterese.AutoSize = true;
            this.lblUnitHisterese.Location = new System.Drawing.Point(393, 101);
            this.lblUnitHisterese.Name = "lblUnitHisterese";
            this.lblUnitHisterese.Size = new System.Drawing.Size(41, 21);
            this.lblUnitHisterese.TabIndex = 29;
            this.lblUnitHisterese.Text = "L / h";
            // 
            // txtHysteresis
            // 
            this.txtHysteresis.AcceptsReturn = true;
            this.txtHysteresis.Location = new System.Drawing.Point(263, 96);
            this.txtHysteresis.MaxLength = 3;
            this.txtHysteresis.Name = "txtHysteresis";
            this.txtHysteresis.Size = new System.Drawing.Size(124, 29);
            this.txtHysteresis.TabIndex = 26;
            this.txtHysteresis.Text = "0";
            this.txtHysteresis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHysteresis.TextChanged += new System.EventHandler(this.txtHysteresisVazao_TextChanged);
            this.txtHysteresis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHysteresisVazao_KeyDown);
            // 
            // lblHisterese
            // 
            this.lblHisterese.AutoSize = true;
            this.lblHisterese.Location = new System.Drawing.Point(12, 96);
            this.lblHisterese.Name = "lblHisterese";
            this.lblHisterese.Size = new System.Drawing.Size(140, 21);
            this.lblHisterese.TabIndex = 30;
            this.lblHisterese.Text = "Histerese da Vazão";
            // 
            // lblUnitSP
            // 
            this.lblUnitSP.AutoSize = true;
            this.lblUnitSP.Location = new System.Drawing.Point(393, 54);
            this.lblUnitSP.Name = "lblUnitSP";
            this.lblUnitSP.Size = new System.Drawing.Size(41, 21);
            this.lblUnitSP.TabIndex = 27;
            this.lblUnitSP.Text = "L / h";
            // 
            // txtSetpoint
            // 
            this.txtSetpoint.AcceptsReturn = true;
            this.txtSetpoint.Location = new System.Drawing.Point(263, 51);
            this.txtSetpoint.MaxLength = 3;
            this.txtSetpoint.Name = "txtSetpoint";
            this.txtSetpoint.Size = new System.Drawing.Size(124, 29);
            this.txtSetpoint.TabIndex = 25;
            this.txtSetpoint.Text = "0";
            this.txtSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSetpoint.TextChanged += new System.EventHandler(this.txtSetpointVazao_TextChanged);
            this.txtSetpoint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSetpointVazao_KeyDown);
            // 
            // lblSetpoint
            // 
            this.lblSetpoint.AutoSize = true;
            this.lblSetpoint.Location = new System.Drawing.Point(12, 54);
            this.lblSetpoint.Name = "lblSetpoint";
            this.lblSetpoint.Size = new System.Drawing.Size(221, 21);
            this.lblSetpoint.TabIndex = 28;
            this.lblSetpoint.Text = "Vazão de Referência (Setpoint)";
            // 
            // btnVazao
            // 
            this.btnVazao.Location = new System.Drawing.Point(16, 232);
            this.btnVazao.Name = "btnVazao";
            this.btnVazao.Size = new System.Drawing.Size(93, 34);
            this.btnVazao.TabIndex = 31;
            this.btnVazao.Text = "Iniciar";
            this.btnVazao.UseVisualStyleBackColor = true;
            this.btnVazao.Click += new System.EventHandler(this.btnVazao_Click);
            // 
            // tabelaControle
            // 
            this.tabelaControle.AllowUserToAddRows = false;
            this.tabelaControle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaControle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Método,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.tabelaControle.Location = new System.Drawing.Point(16, 272);
            this.tabelaControle.Name = "tabelaControle";
            this.tabelaControle.RowHeadersVisible = false;
            this.tabelaControle.Size = new System.Drawing.Size(457, 202);
            this.tabelaControle.TabIndex = 32;
            // 
            // Método
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Método.DefaultCellStyle = dataGridViewCellStyle5;
            this.Método.HeaderText = "Método";
            this.Método.Name = "Método";
            this.Método.ReadOnly = true;
            this.Método.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Método.Width = 170;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "Kc [% h/L]";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "τI [s]";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "τD [s]";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 21);
            this.label1.TabIndex = 33;
            this.label1.Text = "Período da Oscilação";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 21);
            this.label2.TabIndex = 35;
            this.label2.Text = "s";
            // 
            // txtPeriod
            // 
            this.txtPeriod.AcceptsReturn = true;
            this.txtPeriod.BackColor = System.Drawing.Color.White;
            this.txtPeriod.Location = new System.Drawing.Point(263, 140);
            this.txtPeriod.MaxLength = 3;
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.ReadOnly = true;
            this.txtPeriod.Size = new System.Drawing.Size(124, 29);
            this.txtPeriod.TabIndex = 34;
            this.txtPeriod.Text = "0";
            this.txtPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPeriod.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 21);
            this.label3.TabIndex = 36;
            this.label3.Text = "Amplitude da Oscilação";
            // 
            // lblUnitAmplitude
            // 
            this.lblUnitAmplitude.AutoSize = true;
            this.lblUnitAmplitude.Location = new System.Drawing.Point(393, 187);
            this.lblUnitAmplitude.Name = "lblUnitAmplitude";
            this.lblUnitAmplitude.Size = new System.Drawing.Size(41, 21);
            this.lblUnitAmplitude.TabIndex = 38;
            this.lblUnitAmplitude.Text = "L / h";
            // 
            // txtAmplitude
            // 
            this.txtAmplitude.AcceptsReturn = true;
            this.txtAmplitude.BackColor = System.Drawing.Color.White;
            this.txtAmplitude.Location = new System.Drawing.Point(263, 184);
            this.txtAmplitude.MaxLength = 3;
            this.txtAmplitude.Name = "txtAmplitude";
            this.txtAmplitude.ReadOnly = true;
            this.txtAmplitude.Size = new System.Drawing.Size(124, 29);
            this.txtAmplitude.TabIndex = 37;
            this.txtAmplitude.Text = "0";
            this.txtAmplitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 21);
            this.label5.TabIndex = 40;
            this.label5.Text = "Sistema a ser identificado";
            // 
            // sistemaSelecionado
            // 
            this.sistemaSelecionado.FormattingEnabled = true;
            this.sistemaSelecionado.Items.AddRange(new object[] {
            "Vazão",
            "Temperatura"});
            this.sistemaSelecionado.Location = new System.Drawing.Point(263, 12);
            this.sistemaSelecionado.Name = "sistemaSelecionado";
            this.sistemaSelecionado.Size = new System.Drawing.Size(124, 29);
            this.sistemaSelecionado.TabIndex = 39;
            this.sistemaSelecionado.Text = "Vazão";
            this.sistemaSelecionado.SelectedIndexChanged += new System.EventHandler(this.sistemaSelecionado_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 34);
            this.button1.TabIndex = 41;
            this.button1.Text = "Finalizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SubFormONOFFTuningZieglerNichols
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(490, 486);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sistemaSelecionado);
            this.Controls.Add(this.lblUnitAmplitude);
            this.Controls.Add(this.txtAmplitude);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPeriod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabelaControle);
            this.Controls.Add(this.btnVazao);
            this.Controls.Add(this.lblUnitHisterese);
            this.Controls.Add(this.txtHysteresis);
            this.Controls.Add(this.lblHisterese);
            this.Controls.Add(this.lblUnitSP);
            this.Controls.Add(this.txtSetpoint);
            this.Controls.Add(this.lblSetpoint);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SubFormONOFFTuningZieglerNichols";
            this.Text = "Sintonia por método do Relay Auto-Tuning com controlador ON-OFF";
            this.Load += new System.EventHandler(this.SubFormONOFFTuningZieglerNichols_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaControle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUnitHisterese;
        private System.Windows.Forms.TextBox txtHysteresis;
        private System.Windows.Forms.Label lblHisterese;
        private System.Windows.Forms.Label lblUnitSP;
        private System.Windows.Forms.TextBox txtSetpoint;
        private System.Windows.Forms.Label lblSetpoint;
        private System.Windows.Forms.Button btnVazao;
        private System.Windows.Forms.DataGridView tabelaControle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUnitAmplitude;
        private System.Windows.Forms.TextBox txtAmplitude;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox sistemaSelecionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Método;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button button1;
    }
}