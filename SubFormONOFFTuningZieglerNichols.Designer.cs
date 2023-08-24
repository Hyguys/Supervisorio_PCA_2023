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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.tabelaSistema = new System.Windows.Forms.DataGridView();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Theta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUpperPump = new System.Windows.Forms.TextBox();
            this.txtLowerPump = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtLowerRes = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUpperRes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblUnitInterval = new System.Windows.Forms.Label();
            this.lblUpperPump = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaControle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaSistema)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUnitHisterese
            // 
            this.lblUnitHisterese.AutoSize = true;
            this.lblUnitHisterese.Location = new System.Drawing.Point(341, 94);
            this.lblUnitHisterese.Name = "lblUnitHisterese";
            this.lblUnitHisterese.Size = new System.Drawing.Size(41, 21);
            this.lblUnitHisterese.TabIndex = 29;
            this.lblUnitHisterese.Text = "L / h";
            // 
            // txtHysteresis
            // 
            this.txtHysteresis.AcceptsReturn = true;
            this.txtHysteresis.Location = new System.Drawing.Point(257, 89);
            this.txtHysteresis.MaxLength = 3;
            this.txtHysteresis.Name = "txtHysteresis";
            this.txtHysteresis.Size = new System.Drawing.Size(78, 29);
            this.txtHysteresis.TabIndex = 26;
            this.txtHysteresis.Text = "0";
            this.txtHysteresis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHysteresis.TextChanged += new System.EventHandler(this.txtHysteresisVazao_TextChanged);
            this.txtHysteresis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHysteresisVazao_KeyDown);
            
            // 
            this.tabelaSistema.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelaSistema_CellEndEdit);
            // lblHisterese
            // 
            this.lblHisterese.AutoSize = true;
            this.lblHisterese.Location = new System.Drawing.Point(12, 87);
            this.lblHisterese.Name = "lblHisterese";
            this.lblHisterese.Size = new System.Drawing.Size(140, 21);
            this.lblHisterese.TabIndex = 30;
            this.lblHisterese.Text = "Histerese da Vazão";
            // 
            // lblUnitSP
            // 
            this.lblUnitSP.AutoSize = true;
            this.lblUnitSP.Location = new System.Drawing.Point(341, 56);
            this.lblUnitSP.Name = "lblUnitSP";
            this.lblUnitSP.Size = new System.Drawing.Size(41, 21);
            this.lblUnitSP.TabIndex = 27;
            this.lblUnitSP.Text = "L / h";
            // 
            // txtSetpoint
            // 
            this.txtSetpoint.AcceptsReturn = true;
            this.txtSetpoint.Location = new System.Drawing.Point(257, 53);
            this.txtSetpoint.MaxLength = 3;
            this.txtSetpoint.Name = "txtSetpoint";
            this.txtSetpoint.Size = new System.Drawing.Size(78, 29);
            this.txtSetpoint.TabIndex = 25;
            this.txtSetpoint.Text = "0";
            this.txtSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSetpoint.TextChanged += new System.EventHandler(this.txtSetpointVazao_TextChanged);
            this.txtSetpoint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSetpointVazao_KeyDown);
            // 
            // lblSetpoint
            // 
            this.lblSetpoint.AutoSize = true;
            this.lblSetpoint.Location = new System.Drawing.Point(12, 53);
            this.lblSetpoint.Name = "lblSetpoint";
            this.lblSetpoint.Size = new System.Drawing.Size(221, 21);
            this.lblSetpoint.TabIndex = 28;
            this.lblSetpoint.Text = "Vazão de Referência (Setpoint)";
            // 
            // btnVazao
            // 
            this.btnVazao.Location = new System.Drawing.Point(395, 9);
            this.btnVazao.Name = "btnVazao";
            this.btnVazao.Size = new System.Drawing.Size(100, 34);
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
            this.tabelaControle.Location = new System.Drawing.Point(16, 195);
            this.tabelaControle.Name = "tabelaControle";
            this.tabelaControle.RowHeadersVisible = false;
            this.tabelaControle.RowHeadersWidth = 51;
            this.tabelaControle.Size = new System.Drawing.Size(366, 206);
            this.tabelaControle.TabIndex = 32;
            // 
            // Método
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Método.DefaultCellStyle = dataGridViewCellStyle15;
            this.Método.HeaderText = "Método";
            this.Método.MinimumWidth = 6;
            this.Método.Name = "Método";
            this.Método.ReadOnly = true;
            this.Método.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn1.HeaderText = "Kc [% h/L]";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn2.HeaderText = "τI [s]";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn3.HeaderText = "τD [s]";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 21);
            this.label1.TabIndex = 33;
            this.label1.Text = "Período da Oscilação";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 21);
            this.label2.TabIndex = 35;
            this.label2.Text = "s";
            // 
            // txtPeriod
            // 
            this.txtPeriod.AcceptsReturn = true;
            this.txtPeriod.BackColor = System.Drawing.Color.White;
            this.txtPeriod.Location = new System.Drawing.Point(257, 124);
            this.txtPeriod.MaxLength = 3;
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.ReadOnly = true;
            this.txtPeriod.Size = new System.Drawing.Size(78, 29);
            this.txtPeriod.TabIndex = 34;
            this.txtPeriod.Text = "0";
            this.txtPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPeriod.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 21);
            this.label3.TabIndex = 36;
            this.label3.Text = "Amplitude da Oscilação";
            // 
            // lblUnitAmplitude
            // 
            this.lblUnitAmplitude.AutoSize = true;
            this.lblUnitAmplitude.Location = new System.Drawing.Point(341, 163);
            this.lblUnitAmplitude.Name = "lblUnitAmplitude";
            this.lblUnitAmplitude.Size = new System.Drawing.Size(41, 21);
            this.lblUnitAmplitude.TabIndex = 38;
            this.lblUnitAmplitude.Text = "L / h";
            // 
            // txtAmplitude
            // 
            this.txtAmplitude.AcceptsReturn = true;
            this.txtAmplitude.BackColor = System.Drawing.Color.White;
            this.txtAmplitude.Location = new System.Drawing.Point(257, 160);
            this.txtAmplitude.MaxLength = 3;
            this.txtAmplitude.Name = "txtAmplitude";
            this.txtAmplitude.ReadOnly = true;
            this.txtAmplitude.Size = new System.Drawing.Size(78, 29);
            this.txtAmplitude.TabIndex = 37;
            this.txtAmplitude.Text = "0";
            this.txtAmplitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
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
            this.sistemaSelecionado.Location = new System.Drawing.Point(205, 12);
            this.sistemaSelecionado.Name = "sistemaSelecionado";
            this.sistemaSelecionado.Size = new System.Drawing.Size(130, 29);
            this.sistemaSelecionado.TabIndex = 39;
            this.sistemaSelecionado.Text = "Vazão";
            this.sistemaSelecionado.SelectedIndexChanged += new System.EventHandler(this.sistemaSelecionado_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(501, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 34);
            this.button1.TabIndex = 41;
            this.button1.Text = "Finalizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabelaSistema
            // 
            this.tabelaSistema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaSistema.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index,
            this.Kp,
            this.tau,
            this.Theta});
            this.tabelaSistema.Location = new System.Drawing.Point(388, 194);
            this.tabelaSistema.Name = "tabelaSistema";
            this.tabelaSistema.RowHeadersVisible = false;
            this.tabelaSistema.RowHeadersWidth = 51;
            this.tabelaSistema.Size = new System.Drawing.Size(366, 207);
            this.tabelaSistema.TabIndex = 42;
            this.tabelaSistema.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelaSistema_CellContentClick);
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
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Kp.DefaultCellStyle = dataGridViewCellStyle19;
            this.Kp.HeaderText = "Ganho do Processo (Kp) [L/% h]";
            this.Kp.MinimumWidth = 6;
            this.Kp.Name = "Kp";
            this.Kp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Kp.Width = 120;
            // 
            // tau
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tau.DefaultCellStyle = dataGridViewCellStyle20;
            this.tau.HeaderText = "Constante de tempo (τ) [s]";
            this.tau.MinimumWidth = 6;
            this.tau.Name = "tau";
            this.tau.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tau.Width = 120;
            // 
            // Theta
            // 
            this.Theta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Theta.DefaultCellStyle = dataGridViewCellStyle21;
            this.Theta.HeaderText = "Atraso (θ) [s]";
            this.Theta.MinimumWidth = 6;
            this.Theta.Name = "Theta";
            this.Theta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(713, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 21);
            this.label4.TabIndex = 55;
            this.label4.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(713, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 21);
            this.label6.TabIndex = 54;
            this.label6.Text = "%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(713, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 21);
            this.label7.TabIndex = 53;
            this.label7.Text = "%";
            // 
            // txtUpperPump
            // 
            this.txtUpperPump.AcceptsReturn = true;
            this.txtUpperPump.Location = new System.Drawing.Point(629, 56);
            this.txtUpperPump.MaxLength = 3;
            this.txtUpperPump.Name = "txtUpperPump";
            this.txtUpperPump.Size = new System.Drawing.Size(78, 29);
            this.txtUpperPump.TabIndex = 44;
            this.txtUpperPump.Text = "0";
            this.txtUpperPump.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUpperPump.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUpperPump_KeyDown);
            // 
            // txtLowerPump
            // 
            this.txtLowerPump.AcceptsReturn = true;
            this.txtLowerPump.Location = new System.Drawing.Point(629, 89);
            this.txtLowerPump.MaxLength = 3;
            this.txtLowerPump.Name = "txtLowerPump";
            this.txtLowerPump.Size = new System.Drawing.Size(78, 29);
            this.txtLowerPump.TabIndex = 45;
            this.txtLowerPump.Text = "0";
            this.txtLowerPump.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLowerPump.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLowerPump_KeyDown);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(393, 92);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(182, 21);
            this.label21.TabIndex = 52;
            this.label21.Text = "Limite Inferior da Bomba";
            // 
            // txtLowerRes
            // 
            this.txtLowerRes.AcceptsReturn = true;
            this.txtLowerRes.Location = new System.Drawing.Point(629, 159);
            this.txtLowerRes.MaxLength = 5;
            this.txtLowerRes.Name = "txtLowerRes";
            this.txtLowerRes.Size = new System.Drawing.Size(78, 29);
            this.txtLowerRes.TabIndex = 47;
            this.txtLowerRes.Text = "0";
            this.txtLowerRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLowerRes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLowerRes_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(393, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(210, 21);
            this.label9.TabIndex = 51;
            this.label9.Text = "Limite Inferior da Resistência";
            // 
            // txtUpperRes
            // 
            this.txtUpperRes.AcceptsReturn = true;
            this.txtUpperRes.Location = new System.Drawing.Point(629, 124);
            this.txtUpperRes.MaxLength = 4;
            this.txtUpperRes.Name = "txtUpperRes";
            this.txtUpperRes.Size = new System.Drawing.Size(78, 29);
            this.txtUpperRes.TabIndex = 46;
            this.txtUpperRes.Text = "0";
            this.txtUpperRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUpperRes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUpperRes_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(393, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(219, 21);
            this.label8.TabIndex = 50;
            this.label8.Text = "Limite Superior da Resistência";
            // 
            // lblUnitInterval
            // 
            this.lblUnitInterval.AutoSize = true;
            this.lblUnitInterval.Location = new System.Drawing.Point(713, 59);
            this.lblUnitInterval.Name = "lblUnitInterval";
            this.lblUnitInterval.Size = new System.Drawing.Size(23, 21);
            this.lblUnitInterval.TabIndex = 48;
            this.lblUnitInterval.Text = "%";
            // 
            // lblUpperPump
            // 
            this.lblUpperPump.AutoSize = true;
            this.lblUpperPump.Location = new System.Drawing.Point(393, 57);
            this.lblUpperPump.Name = "lblUpperPump";
            this.lblUpperPump.Size = new System.Drawing.Size(191, 21);
            this.lblUpperPump.TabIndex = 49;
            this.lblUpperPump.Text = "Limite Superior da Bomba";
            // 
            // SubFormONOFFTuningZieglerNichols
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(772, 419);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUpperPump);
            this.Controls.Add(this.txtLowerPump);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtLowerRes);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtUpperRes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblUnitInterval);
            this.Controls.Add(this.lblUpperPump);
            this.Controls.Add(this.tabelaSistema);
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
            ((System.ComponentModel.ISupportInitialize)(this.tabelaSistema)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Método;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridView tabelaSistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kp;
        private System.Windows.Forms.DataGridViewTextBoxColumn tau;
        private System.Windows.Forms.DataGridViewTextBoxColumn Theta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUpperPump;
        private System.Windows.Forms.TextBox txtLowerPump;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtLowerRes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUpperRes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblUnitInterval;
        private System.Windows.Forms.Label lblUpperPump;
    }
}