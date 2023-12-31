﻿namespace Supervisório_PCA_2._0
{
    partial class SubFormStepTuningFOPTD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPotenciaBomba = new System.Windows.Forms.TextBox();
            this.lblDegrau = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.tabela = new System.Windows.Forms.DataGridView();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Theta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Determinação = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sp = new ScottPlot.FormsPlot();
            this.lblEquilibrium = new System.Windows.Forms.Label();
            this.tabelaControle = new System.Windows.Forms.DataGridView();
            this.Método = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPotenciaInicial = new System.Windows.Forms.TextBox();
            this.lblPotenciaInicial = new System.Windows.Forms.Label();
            this.lblResidualType = new System.Windows.Forms.Label();
            this.cbResidualType = new System.Windows.Forms.ComboBox();
            this.btnReotimizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaControle)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(12, 138);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(73, 27);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(348, 75);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 21);
            this.label16.TabIndex = 23;
            this.label16.Text = "%";
            // 
            // txtPotenciaBomba
            // 
            this.txtPotenciaBomba.AcceptsReturn = true;
            this.txtPotenciaBomba.Location = new System.Drawing.Point(236, 72);
            this.txtPotenciaBomba.MaxLength = 4;
            this.txtPotenciaBomba.Name = "txtPotenciaBomba";
            this.txtPotenciaBomba.Size = new System.Drawing.Size(106, 29);
            this.txtPotenciaBomba.TabIndex = 0;
            this.txtPotenciaBomba.Text = "0";
            this.txtPotenciaBomba.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDegrau
            // 
            this.lblDegrau.AutoSize = true;
            this.lblDegrau.Location = new System.Drawing.Point(12, 75);
            this.lblDegrau.Name = "lblDegrau";
            this.lblDegrau.Size = new System.Drawing.Size(218, 21);
            this.lblDegrau.TabIndex = 24;
            this.lblDegrau.Text = "Degrau de Potência da Bomba";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(87, 138);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(76, 27);
            this.btnFinalizar.TabIndex = 2;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabela
            // 
            this.tabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index,
            this.Kp,
            this.tau,
            this.Theta,
            this.Determinação});
            this.tabela.Location = new System.Drawing.Point(12, 171);
            this.tabela.Name = "tabela";
            this.tabela.RowHeadersVisible = false;
            this.tabela.RowHeadersWidth = 51;
            this.tabela.Size = new System.Drawing.Size(353, 142);
            this.tabela.TabIndex = 3;
            this.tabela.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabela_CellContentClick);
            this.tabela.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabela_CellEndEdit);
            // 
            // index
            // 
            this.index.HeaderText = "ID";
            this.index.MinimumWidth = 6;
            this.index.Name = "index";
            this.index.Width = 30;
            // 
            // Kp
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Kp.DefaultCellStyle = dataGridViewCellStyle1;
            this.Kp.HeaderText = "Kp [L/% h]";
            this.Kp.MinimumWidth = 6;
            this.Kp.Name = "Kp";
            this.Kp.Width = 90;
            // 
            // tau
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tau.DefaultCellStyle = dataGridViewCellStyle2;
            this.tau.HeaderText = "τ [s]";
            this.tau.MinimumWidth = 6;
            this.tau.Name = "tau";
            this.tau.Width = 90;
            // 
            // Theta
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Theta.DefaultCellStyle = dataGridViewCellStyle3;
            this.Theta.HeaderText = "θ [s]";
            this.Theta.MinimumWidth = 6;
            this.Theta.Name = "Theta";
            this.Theta.Width = 70;
            // 
            // Determinação
            // 
            this.Determinação.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Determinação.HeaderText = "R²";
            this.Determinação.Name = "Determinação";
            // 
            // sp
            // 
            this.sp.Location = new System.Drawing.Point(372, 6);
            this.sp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sp.Name = "sp";
            this.sp.Size = new System.Drawing.Size(422, 453);
            this.sp.TabIndex = 27;
            this.sp.Load += new System.EventHandler(this.sp_Load);
            // 
            // lblEquilibrium
            // 
            this.lblEquilibrium.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEquilibrium.ForeColor = System.Drawing.Color.Blue;
            this.lblEquilibrium.Location = new System.Drawing.Point(292, 135);
            this.lblEquilibrium.Name = "lblEquilibrium";
            this.lblEquilibrium.Size = new System.Drawing.Size(73, 33);
            this.lblEquilibrium.TabIndex = 28;
            this.lblEquilibrium.Text = "Estabilidade detectada!";
            this.lblEquilibrium.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEquilibrium.Visible = false;
            // 
            // tabelaControle
            // 
            this.tabelaControle.AllowUserToAddRows = false;
            this.tabelaControle.AllowUserToOrderColumns = true;
            this.tabelaControle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaControle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Método,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.tabelaControle.Location = new System.Drawing.Point(12, 319);
            this.tabelaControle.Name = "tabelaControle";
            this.tabelaControle.RowHeadersVisible = false;
            this.tabelaControle.RowHeadersWidth = 51;
            this.tabelaControle.Size = new System.Drawing.Size(353, 140);
            this.tabelaControle.TabIndex = 29;
            // 
            // Método
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Método.DefaultCellStyle = dataGridViewCellStyle4;
            this.Método.HeaderText = "Método";
            this.Método.MinimumWidth = 6;
            this.Método.Name = "Método";
            this.Método.ReadOnly = true;
            this.Método.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Método.Width = 140;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Kc [% h/L]";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "τI [s]";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "τD [s]";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Vazão",
            "Temperatura",
            "Sensor de Temperatura"});
            this.comboBox1.Location = new System.Drawing.Point(236, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(106, 29);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.Text = "Vazão";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 21);
            this.label1.TabIndex = 31;
            this.label1.Text = "Sistema a ser identificado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 21);
            this.label2.TabIndex = 33;
            this.label2.Text = "%";
            // 
            // txtPotenciaInicial
            // 
            this.txtPotenciaInicial.AcceptsReturn = true;
            this.txtPotenciaInicial.Location = new System.Drawing.Point(236, 40);
            this.txtPotenciaInicial.MaxLength = 4;
            this.txtPotenciaInicial.Name = "txtPotenciaInicial";
            this.txtPotenciaInicial.ReadOnly = true;
            this.txtPotenciaInicial.Size = new System.Drawing.Size(106, 29);
            this.txtPotenciaInicial.TabIndex = 32;
            this.txtPotenciaInicial.Text = "0";
            this.txtPotenciaInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPotenciaInicial.TextChanged += new System.EventHandler(this.txtPotenciaInicial_TextChanged);
            // 
            // lblPotenciaInicial
            // 
            this.lblPotenciaInicial.AutoSize = true;
            this.lblPotenciaInicial.Location = new System.Drawing.Point(12, 43);
            this.lblPotenciaInicial.Name = "lblPotenciaInicial";
            this.lblPotenciaInicial.Size = new System.Drawing.Size(186, 21);
            this.lblPotenciaInicial.TabIndex = 34;
            this.lblPotenciaInicial.Text = "Potência da Bomba Inicial";
            // 
            // lblResidualType
            // 
            this.lblResidualType.AutoSize = true;
            this.lblResidualType.Location = new System.Drawing.Point(12, 108);
            this.lblResidualType.Name = "lblResidualType";
            this.lblResidualType.Size = new System.Drawing.Size(194, 21);
            this.lblResidualType.TabIndex = 36;
            this.lblResidualType.Text = "Tipo de Resíduo Estatístico";
            // 
            // cbResidualType
            // 
            this.cbResidualType.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbResidualType.FormattingEnabled = true;
            this.cbResidualType.Items.AddRange(new object[] {
            "Quadrático (SRQ)",
            "Absoluto (SRA)"});
            this.cbResidualType.Location = new System.Drawing.Point(235, 105);
            this.cbResidualType.Name = "cbResidualType";
            this.cbResidualType.Size = new System.Drawing.Size(107, 29);
            this.cbResidualType.TabIndex = 35;
            this.cbResidualType.Text = "Absoluto (SRA)";
            this.cbResidualType.SelectedIndexChanged += new System.EventHandler(this.cbResidualType_SelectedIndexChanged);
            // 
            // btnReotimizar
            // 
            this.btnReotimizar.Location = new System.Drawing.Point(166, 138);
            this.btnReotimizar.Name = "btnReotimizar";
            this.btnReotimizar.Size = new System.Drawing.Size(97, 27);
            this.btnReotimizar.TabIndex = 37;
            this.btnReotimizar.Text = "Reotimizar";
            this.btnReotimizar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReotimizar.UseVisualStyleBackColor = true;
            this.btnReotimizar.Click += new System.EventHandler(this.btnReotimizar_Click);
            // 
            // SubFormStepTuningFOPTD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(802, 473);
            this.Controls.Add(this.btnReotimizar);
            this.Controls.Add(this.lblResidualType);
            this.Controls.Add(this.cbResidualType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPotenciaInicial);
            this.Controls.Add(this.lblPotenciaInicial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tabelaControle);
            this.Controls.Add(this.lblEquilibrium);
            this.Controls.Add(this.sp);
            this.Controls.Add(this.tabela);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtPotenciaBomba);
            this.Controls.Add(this.lblDegrau);
            this.Controls.Add(this.btnIniciar);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SubFormStepTuningFOPTD";
            this.Text = "Identificação e Sintonia de FOPTD (sistema de primeira ordem com atraso no tempo)" +
    " por meio da resposta à um degrau";
            this.Load += new System.EventHandler(this.SubFormAutoTuningFOPTD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaControle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtPotenciaBomba;
        private System.Windows.Forms.Label lblDegrau;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.DataGridView tabela;
        private ScottPlot.FormsPlot sp;
        private System.Windows.Forms.Label lblEquilibrium;
        private System.Windows.Forms.DataGridView tabelaControle;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Método;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPotenciaInicial;
        private System.Windows.Forms.Label lblPotenciaInicial;
        private System.Windows.Forms.Label lblResidualType;
        private System.Windows.Forms.ComboBox cbResidualType;
        private System.Windows.Forms.Button btnReotimizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kp;
        private System.Windows.Forms.DataGridViewTextBoxColumn tau;
        private System.Windows.Forms.DataGridViewTextBoxColumn Theta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Determinação;
    }
}