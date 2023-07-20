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
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPotenciaBomba = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabela = new System.Windows.Forms.DataGridView();
            this.Kp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Theta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sp = new ScottPlot.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(12, 47);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(84, 33);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(307, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 21);
            this.label16.TabIndex = 23;
            this.label16.Text = "%";
            // 
            // txtPotenciaBomba
            // 
            this.txtPotenciaBomba.AcceptsReturn = true;
            this.txtPotenciaBomba.Location = new System.Drawing.Point(236, 10);
            this.txtPotenciaBomba.MaxLength = 4;
            this.txtPotenciaBomba.Name = "txtPotenciaBomba";
            this.txtPotenciaBomba.Size = new System.Drawing.Size(65, 29);
            this.txtPotenciaBomba.TabIndex = 22;
            this.txtPotenciaBomba.Text = "0";
            this.txtPotenciaBomba.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(218, 21);
            this.label17.TabIndex = 24;
            this.label17.Text = "Degrau de Potência da Bomba";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(102, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 33);
            this.button1.TabIndex = 25;
            this.button1.Text = "Finalizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabela
            // 
            this.tabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Kp,
            this.tau,
            this.Theta});
            this.tabela.Location = new System.Drawing.Point(12, 95);
            this.tabela.Name = "tabela";
            this.tabela.Size = new System.Drawing.Size(353, 170);
            this.tabela.TabIndex = 26;
            this.tabela.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabela_CellContentClick);
            // 
            // Kp
            // 
            this.Kp.HeaderText = "Ganho do Processo (Kp) [L/% hr]";
            this.Kp.Name = "Kp";
            this.Kp.ReadOnly = true;
            // 
            // tau
            // 
            this.tau.HeaderText = "Constante de tempo (tau) [s]";
            this.tau.Name = "tau";
            this.tau.ReadOnly = true;
            // 
            // Theta
            // 
            this.Theta.HeaderText = "Atraso (theta) [s]";
            this.Theta.Name = "Theta";
            this.Theta.ReadOnly = true;
            // 
            // sp
            // 
            this.sp.Location = new System.Drawing.Point(372, 14);
            this.sp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sp.Name = "sp";
            this.sp.Size = new System.Drawing.Size(477, 407);
            this.sp.TabIndex = 27;
            // 
            // SubFormAutoTuningFOPTD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(862, 427);
            this.Controls.Add(this.sp);
            this.Controls.Add(this.tabela);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtPotenciaBomba);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnIniciar);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SubFormAutoTuningFOPTD";
            this.Text = "SubFormAutoTuningFOPTD";
            this.Load += new System.EventHandler(this.SubFormAutoTuningFOPTD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtPotenciaBomba;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView tabela;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kp;
        private System.Windows.Forms.DataGridViewTextBoxColumn tau;
        private System.Windows.Forms.DataGridViewTextBoxColumn Theta;
        private ScottPlot.FormsPlot sp;
    }
}