namespace Supervisório_PCA_2023
{
    partial class SubFormClosedLoopPIDTuning
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabelaControle = new System.Windows.Forms.DataGridView();
            this.Método = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEquilibrium = new System.Windows.Forms.Label();
            this.sp = new ScottPlot.FormsPlot();
            this.tabela = new System.Windows.Forms.DataGridView();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Theta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaControle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 21);
            this.label1.TabIndex = 45;
            this.label1.Text = "Sistema a ser identificado";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Vazão",
            "Temperatura"});
            this.comboBox1.Location = new System.Drawing.Point(278, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(84, 29);
            this.comboBox1.TabIndex = 44;
            this.comboBox1.Text = "Vazão";
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
            this.tabelaControle.Location = new System.Drawing.Point(9, 252);
            this.tabelaControle.Name = "tabelaControle";
            this.tabelaControle.RowHeadersVisible = false;
            this.tabelaControle.RowHeadersWidth = 51;
            this.tabelaControle.Size = new System.Drawing.Size(353, 202);
            this.tabelaControle.TabIndex = 43;
            // 
            // Método
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Método.DefaultCellStyle = dataGridViewCellStyle22;
            this.Método.HeaderText = "Método";
            this.Método.MinimumWidth = 6;
            this.Método.Name = "Método";
            this.Método.ReadOnly = true;
            this.Método.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Método.Width = 140;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewTextBoxColumn1.HeaderText = "Kc [% h/L]";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle24;
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
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridViewTextBoxColumn3.HeaderText = "τD [s]";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblEquilibrium
            // 
            this.lblEquilibrium.AutoSize = true;
            this.lblEquilibrium.ForeColor = System.Drawing.Color.Blue;
            this.lblEquilibrium.Location = new System.Drawing.Point(193, 50);
            this.lblEquilibrium.Name = "lblEquilibrium";
            this.lblEquilibrium.Size = new System.Drawing.Size(169, 21);
            this.lblEquilibrium.TabIndex = 42;
            this.lblEquilibrium.Text = "Estabilidade detectada!";
            this.lblEquilibrium.Visible = false;
            // 
            // sp
            // 
            this.sp.Location = new System.Drawing.Point(371, 14);
            this.sp.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.sp.Name = "sp";
            this.sp.Size = new System.Drawing.Size(442, 440);
            this.sp.TabIndex = 41;
            // 
            // tabela
            // 
            this.tabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index,
            this.Kp,
            this.tau,
            this.Theta});
            this.tabela.Location = new System.Drawing.Point(9, 83);
            this.tabela.Name = "tabela";
            this.tabela.RowHeadersVisible = false;
            this.tabela.RowHeadersWidth = 51;
            this.tabela.Size = new System.Drawing.Size(353, 163);
            this.tabela.TabIndex = 38;
            // 
            // index
            // 
            this.index.HeaderText = "ID";
            this.index.MinimumWidth = 6;
            this.index.Name = "index";
            this.index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.index.Width = 30;
            // 
            // Kp
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Kp.DefaultCellStyle = dataGridViewCellStyle26;
            this.Kp.HeaderText = "Ganho do Processo (Kp) [L/% h]";
            this.Kp.MinimumWidth = 6;
            this.Kp.Name = "Kp";
            this.Kp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Kp.Width = 120;
            // 
            // tau
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tau.DefaultCellStyle = dataGridViewCellStyle27;
            this.tau.HeaderText = "Constante de tempo (τ) [s]";
            this.tau.MinimumWidth = 6;
            this.tau.Name = "tau";
            this.tau.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tau.Width = 120;
            // 
            // Theta
            // 
            this.Theta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Theta.DefaultCellStyle = dataGridViewCellStyle28;
            this.Theta.HeaderText = "Atraso (θ) [s]";
            this.Theta.MinimumWidth = 6;
            this.Theta.Name = "Theta";
            this.Theta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 33);
            this.button1.TabIndex = 37;
            this.button1.Text = "Finalizar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(9, 44);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(84, 33);
            this.btnIniciar.TabIndex = 36;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            // 
            // SubFormClosedLoopPIDTuning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(829, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tabelaControle);
            this.Controls.Add(this.lblEquilibrium);
            this.Controls.Add(this.sp);
            this.Controls.Add(this.tabela);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnIniciar);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SubFormClosedLoopPIDTuning";
            this.Text = "Identificação de Sistemas e Sintonia de Controladores em Malha Fechada";
            this.Load += new System.EventHandler(this.SubFormClosedLoopPIDTuning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaControle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView tabelaControle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Método;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label lblEquilibrium;
        private ScottPlot.FormsPlot sp;
        private System.Windows.Forms.DataGridView tabela;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kp;
        private System.Windows.Forms.DataGridViewTextBoxColumn tau;
        private System.Windows.Forms.DataGridViewTextBoxColumn Theta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIniciar;
    }
}