namespace Supervisório_PCA_2._0
{
    partial class SubFormAutoTuningFOPTD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPotenciaBomba = new System.Windows.Forms.TextBox();
            this.lblDegrau = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabela = new System.Windows.Forms.DataGridView();
            this.sp = new ScottPlot.FormsPlot();
            this.lblEquilibrium = new System.Windows.Forms.Label();
            this.tabelaControle = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Método = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Theta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaControle)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(12, 47);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(84, 33);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(384, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 21);
            this.label16.TabIndex = 23;
            this.label16.Text = "%";
            // 
            // txtPotenciaBomba
            // 
            this.txtPotenciaBomba.AcceptsReturn = true;
            this.txtPotenciaBomba.Location = new System.Drawing.Point(313, 13);
            this.txtPotenciaBomba.MaxLength = 4;
            this.txtPotenciaBomba.Name = "txtPotenciaBomba";
            this.txtPotenciaBomba.Size = new System.Drawing.Size(65, 29);
            this.txtPotenciaBomba.TabIndex = 0;
            this.txtPotenciaBomba.Text = "0";
            this.txtPotenciaBomba.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDegrau
            // 
            this.lblDegrau.AutoSize = true;
            this.lblDegrau.Location = new System.Drawing.Point(12, 13);
            this.lblDegrau.Name = "lblDegrau";
            this.lblDegrau.Size = new System.Drawing.Size(218, 21);
            this.lblDegrau.TabIndex = 24;
            this.lblDegrau.Text = "Degrau de Potência da Bomba";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(102, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Finalizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabela
            // 
            this.tabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index,
            this.Kp,
            this.tau,
            this.Theta});
            this.tabela.Location = new System.Drawing.Point(12, 95);
            this.tabela.Name = "tabela";
            this.tabela.RowHeadersVisible = false;
            this.tabela.Size = new System.Drawing.Size(353, 163);
            this.tabela.TabIndex = 3;
            this.tabela.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabela_CellContentClick);
            this.tabela.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabela_CellEndEdit);
            // 
            // sp
            // 
            this.sp.Location = new System.Drawing.Point(372, 53);
            this.sp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sp.Name = "sp";
            this.sp.Size = new System.Drawing.Size(477, 413);
            this.sp.TabIndex = 27;
            this.sp.Load += new System.EventHandler(this.sp_Load);
            // 
            // lblEquilibrium
            // 
            this.lblEquilibrium.AutoSize = true;
            this.lblEquilibrium.ForeColor = System.Drawing.Color.Blue;
            this.lblEquilibrium.Location = new System.Drawing.Point(196, 53);
            this.lblEquilibrium.Name = "lblEquilibrium";
            this.lblEquilibrium.Size = new System.Drawing.Size(169, 21);
            this.lblEquilibrium.TabIndex = 28;
            this.lblEquilibrium.Text = "Estabilidade detectada!";
            this.lblEquilibrium.Visible = false;
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
            this.tabelaControle.Location = new System.Drawing.Point(12, 264);
            this.tabelaControle.Name = "tabelaControle";
            this.tabelaControle.RowHeadersVisible = false;
            this.tabelaControle.Size = new System.Drawing.Size(353, 202);
            this.tabelaControle.TabIndex = 29;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Vazão",
            "Temperatura"});
            this.comboBox1.Location = new System.Drawing.Point(638, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 29);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.Text = "Vazão";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(445, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 21);
            this.label1.TabIndex = 31;
            this.label1.Text = "Sistema a ser identificado";
            // 
            // Método
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Método.DefaultCellStyle = dataGridViewCellStyle8;
            this.Método.HeaderText = "Método";
            this.Método.Name = "Método";
            this.Método.ReadOnly = true;
            this.Método.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Método.Width = 140;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn1.HeaderText = "Kc [% h/L]";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn2.HeaderText = "τI [s]";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn3.HeaderText = "τD [s]";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // index
            // 
            this.index.HeaderText = "ID";
            this.index.Name = "index";
            this.index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.index.Width = 30;
            // 
            // Kp
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Kp.DefaultCellStyle = dataGridViewCellStyle12;
            this.Kp.HeaderText = "Ganho do Processo (Kp) [L/% hr]";
            this.Kp.Name = "Kp";
            this.Kp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Kp.Width = 120;
            // 
            // tau
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tau.DefaultCellStyle = dataGridViewCellStyle13;
            this.tau.HeaderText = "Constante de tempo (τ) [s]";
            this.tau.Name = "tau";
            this.tau.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tau.Width = 120;
            // 
            // Theta
            // 
            this.Theta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Theta.DefaultCellStyle = dataGridViewCellStyle14;
            this.Theta.HeaderText = "Atraso (θ) [s]";
            this.Theta.Name = "Theta";
            this.Theta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SubFormAutoTuningFOPTD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(862, 480);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tabelaControle);
            this.Controls.Add(this.lblEquilibrium);
            this.Controls.Add(this.sp);
            this.Controls.Add(this.tabela);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtPotenciaBomba);
            this.Controls.Add(this.lblDegrau);
            this.Controls.Add(this.btnIniciar);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SubFormAutoTuningFOPTD";
            this.Text = "SubFormAutoTuningFOPTD";
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
        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kp;
        private System.Windows.Forms.DataGridViewTextBoxColumn tau;
        private System.Windows.Forms.DataGridViewTextBoxColumn Theta;
    }
}