namespace Supervisório_PCA_2023
{
    partial class SubFormConfigModeloFOPTD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabelaVazao = new System.Windows.Forms.DataGridView();
            this.Kp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Theta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabelaTemperatura = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.btnVazao = new System.Windows.Forms.Button();
            this.btnTemp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaVazao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaTemperatura)).BeginInit();
            this.SuspendLayout();
            // 
            // tabelaVazao
            // 
            this.tabelaVazao.AllowUserToAddRows = false;
            this.tabelaVazao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaVazao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Kp,
            this.tau,
            this.Theta});
            this.tabelaVazao.Location = new System.Drawing.Point(17, 40);
            this.tabelaVazao.Name = "tabelaVazao";
            this.tabelaVazao.RowHeadersVisible = false;
            this.tabelaVazao.RowHeadersWidth = 51;
            this.tabelaVazao.Size = new System.Drawing.Size(353, 142);
            this.tabelaVazao.TabIndex = 4;
            this.tabelaVazao.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelaVazao_CellContentClick);
            // 
            // Kp
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Kp.DefaultCellStyle = dataGridViewCellStyle13;
            this.Kp.HeaderText = "Ganho do Processo (Kp) [L/% h]";
            this.Kp.MinimumWidth = 6;
            this.Kp.Name = "Kp";
            this.Kp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Kp.Width = 120;
            // 
            // tau
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tau.DefaultCellStyle = dataGridViewCellStyle14;
            this.tau.HeaderText = "Constante de tempo (τ) [s]";
            this.tau.MinimumWidth = 6;
            this.tau.Name = "tau";
            this.tau.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tau.Width = 120;
            // 
            // Theta
            // 
            this.Theta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Theta.DefaultCellStyle = dataGridViewCellStyle15;
            this.Theta.HeaderText = "Atraso (θ) [s]";
            this.Theta.MinimumWidth = 6;
            this.Theta.Name = "Theta";
            this.Theta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sistema de Controle de Vazão";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 28);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sistema de Controle de Temperatura";
            // 
            // tabelaTemperatura
            // 
            this.tabelaTemperatura.AllowUserToAddRows = false;
            this.tabelaTemperatura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaTemperatura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.tabelaTemperatura.Location = new System.Drawing.Point(17, 300);
            this.tabelaTemperatura.Name = "tabelaTemperatura";
            this.tabelaTemperatura.RowHeadersVisible = false;
            this.tabelaTemperatura.RowHeadersWidth = 51;
            this.tabelaTemperatura.Size = new System.Drawing.Size(353, 142);
            this.tabelaTemperatura.TabIndex = 6;
            this.tabelaTemperatura.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelaTemperatura_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn1.HeaderText = "Ganho do Processo (Kp) [L/% h]";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn2.HeaderText = "Constante de tempo (τ) [s]";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn3.HeaderText = "Atraso (θ) [s]";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 188);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(217, 32);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Exibir Previsão Vazão";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(17, 448);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(274, 32);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Exibir Previsão Temperatura";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // btnVazao
            // 
            this.btnVazao.Location = new System.Drawing.Point(17, 226);
            this.btnVazao.Name = "btnVazao";
            this.btnVazao.Size = new System.Drawing.Size(101, 30);
            this.btnVazao.TabIndex = 10;
            this.btnVazao.Text = "Cadastrar";
            this.btnVazao.UseVisualStyleBackColor = true;
            this.btnVazao.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTemp
            // 
            this.btnTemp.Location = new System.Drawing.Point(17, 486);
            this.btnTemp.Name = "btnTemp";
            this.btnTemp.Size = new System.Drawing.Size(101, 30);
            this.btnTemp.TabIndex = 11;
            this.btnTemp.Text = "Cadastrar";
            this.btnTemp.UseVisualStyleBackColor = true;
            this.btnTemp.Click += new System.EventHandler(this.btnTemp_Click);
            // 
            // SubFormConfigModeloFOPTD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(387, 524);
            this.Controls.Add(this.btnTemp);
            this.Controls.Add(this.btnVazao);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabelaTemperatura);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabelaVazao);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SubFormConfigModeloFOPTD";
            this.Text = "Cadastramento de Modelo FOPTD";
            this.Load += new System.EventHandler(this.SubFormConfigModeloFOPTD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaVazao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaTemperatura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tabelaVazao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kp;
        private System.Windows.Forms.DataGridViewTextBoxColumn tau;
        private System.Windows.Forms.DataGridViewTextBoxColumn Theta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tabelaTemperatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button btnVazao;
        private System.Windows.Forms.Button btnTemp;
    }
}