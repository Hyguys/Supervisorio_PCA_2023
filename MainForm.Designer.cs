using System.Windows.Forms;

namespace Supervisório_PCA_2._0
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conexãoComArduinoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conectarAoArduinoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coletaDeDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarColetaDeDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalizarColetaDeDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesDeControleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesDosGráficosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limitesDaBombaEDaResistênciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tomadaDeDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentasAvançadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sintoniaAutomáticaDeFOPTDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testeDeDegrauEmMalhaAbertaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testeEmMalhaFechadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testeEmMalhaFechadaPPIPIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeModeloFOPTDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualDeOperaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowPlot = new ScottPlot.FormsPlot();
            this.tempPlot = new ScottPlot.FormsPlot();
            this.searchPorts = new System.Windows.Forms.Button();
            this.portsBox = new System.Windows.Forms.ComboBox();
            this.disconnectPort = new System.Windows.Forms.Button();
            this.connectPort = new System.Windows.Forms.Button();
            this.resetPort = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.textBox1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.leiturasInstantâneasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.configuraçõesToolStripMenuItem,
            this.ferramentasAvançadasToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conexãoComArduinoToolStripMenuItem,
            this.coletaDeDadosToolStripMenuItem,
            this.leiturasInstantâneasToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(59, 25);
            this.arquivoToolStripMenuItem.Text = "Geral";
            // 
            // conexãoComArduinoToolStripMenuItem
            // 
            this.conexãoComArduinoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectarAoArduinoToolStripMenuItem});
            this.conexãoComArduinoToolStripMenuItem.Name = "conexãoComArduinoToolStripMenuItem";
            this.conexãoComArduinoToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.conexãoComArduinoToolStripMenuItem.Text = "Conexão com Arduino";
            // 
            // conectarAoArduinoToolStripMenuItem
            // 
            this.conectarAoArduinoToolStripMenuItem.Name = "conectarAoArduinoToolStripMenuItem";
            this.conectarAoArduinoToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.conectarAoArduinoToolStripMenuItem.Text = "Configurar Conexão";
            this.conectarAoArduinoToolStripMenuItem.Click += new System.EventHandler(this.conectarAoArduinoToolStripMenuItem_Click);
            // 
            // coletaDeDadosToolStripMenuItem
            // 
            this.coletaDeDadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarColetaDeDadosToolStripMenuItem,
            this.finalizarColetaDeDadosToolStripMenuItem});
            this.coletaDeDadosToolStripMenuItem.Name = "coletaDeDadosToolStripMenuItem";
            this.coletaDeDadosToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.coletaDeDadosToolStripMenuItem.Text = "Coleta de Dados";
            // 
            // iniciarColetaDeDadosToolStripMenuItem
            // 
            this.iniciarColetaDeDadosToolStripMenuItem.Name = "iniciarColetaDeDadosToolStripMenuItem";
            this.iniciarColetaDeDadosToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.iniciarColetaDeDadosToolStripMenuItem.Text = "Iniciar Coleta de Dados";
            this.iniciarColetaDeDadosToolStripMenuItem.Click += new System.EventHandler(this.iniciarColetaDeDadosToolStripMenuItem_Click);
            // 
            // finalizarColetaDeDadosToolStripMenuItem
            // 
            this.finalizarColetaDeDadosToolStripMenuItem.Name = "finalizarColetaDeDadosToolStripMenuItem";
            this.finalizarColetaDeDadosToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.finalizarColetaDeDadosToolStripMenuItem.Text = "Finalizar Coleta de Dados";
            this.finalizarColetaDeDadosToolStripMenuItem.Click += new System.EventHandler(this.finalizarColetaDeDadosToolStripMenuItem_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõesDeControleToolStripMenuItem,
            this.configuraçõesDosGráficosToolStripMenuItem,
            this.limitesDaBombaEDaResistênciaToolStripMenuItem,
            this.tomadaDeDadosToolStripMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(122, 25);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // configuraçõesDeControleToolStripMenuItem
            // 
            this.configuraçõesDeControleToolStripMenuItem.Name = "configuraçõesDeControleToolStripMenuItem";
            this.configuraçõesDeControleToolStripMenuItem.Size = new System.Drawing.Size(438, 26);
            this.configuraçõesDeControleToolStripMenuItem.Text = "Parâmetros de Controle (P/PI/PID/Manual/ON-OFF)";
            this.configuraçõesDeControleToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesDeControleToolStripMenuItem_Click);
            // 
            // configuraçõesDosGráficosToolStripMenuItem
            // 
            this.configuraçõesDosGráficosToolStripMenuItem.Name = "configuraçõesDosGráficosToolStripMenuItem";
            this.configuraçõesDosGráficosToolStripMenuItem.Size = new System.Drawing.Size(438, 26);
            this.configuraçõesDosGráficosToolStripMenuItem.Text = "Customização dos Gráficos";
            this.configuraçõesDosGráficosToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesDosGráficosToolStripMenuItem_Click);
            // 
            // limitesDaBombaEDaResistênciaToolStripMenuItem
            // 
            this.limitesDaBombaEDaResistênciaToolStripMenuItem.Name = "limitesDaBombaEDaResistênciaToolStripMenuItem";
            this.limitesDaBombaEDaResistênciaToolStripMenuItem.Size = new System.Drawing.Size(438, 26);
            this.limitesDaBombaEDaResistênciaToolStripMenuItem.Text = "Limites da Bomba e da Resistência";
            this.limitesDaBombaEDaResistênciaToolStripMenuItem.Click += new System.EventHandler(this.limitesDaBombaEDaResistênciaToolStripMenuItem_Click);
            // 
            // tomadaDeDadosToolStripMenuItem
            // 
            this.tomadaDeDadosToolStripMenuItem.Name = "tomadaDeDadosToolStripMenuItem";
            this.tomadaDeDadosToolStripMenuItem.Size = new System.Drawing.Size(438, 26);
            this.tomadaDeDadosToolStripMenuItem.Text = "Tomada de Dados, Amostragem e Filtragem";
            this.tomadaDeDadosToolStripMenuItem.Click += new System.EventHandler(this.tomadaDeDadosToolStripMenuItem_Click);
            // 
            // ferramentasAvançadasToolStripMenuItem
            // 
            this.ferramentasAvançadasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sintoniaAutomáticaDeFOPTDToolStripMenuItem,
            this.cadastroDeModeloFOPTDToolStripMenuItem});
            this.ferramentasAvançadasToolStripMenuItem.Name = "ferramentasAvançadasToolStripMenuItem";
            this.ferramentasAvançadasToolStripMenuItem.Size = new System.Drawing.Size(187, 25);
            this.ferramentasAvançadasToolStripMenuItem.Text = "Ferramentas Avançadas";
            this.ferramentasAvançadasToolStripMenuItem.Click += new System.EventHandler(this.ferramentasAvançadasToolStripMenuItem_Click);
            // 
            // sintoniaAutomáticaDeFOPTDToolStripMenuItem
            // 
            this.sintoniaAutomáticaDeFOPTDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testeDeDegrauEmMalhaAbertaToolStripMenuItem,
            this.testeEmMalhaFechadaToolStripMenuItem,
            this.testeEmMalhaFechadaPPIPIDToolStripMenuItem});
            this.sintoniaAutomáticaDeFOPTDToolStripMenuItem.Name = "sintoniaAutomáticaDeFOPTDToolStripMenuItem";
            this.sintoniaAutomáticaDeFOPTDToolStripMenuItem.Size = new System.Drawing.Size(348, 26);
            this.sintoniaAutomáticaDeFOPTDToolStripMenuItem.Text = "Identificador e Sintonizador de FOPTD ";
            this.sintoniaAutomáticaDeFOPTDToolStripMenuItem.Click += new System.EventHandler(this.sintoniaAutomáticaDeFOPTDToolStripMenuItem_Click);
            // 
            // testeDeDegrauEmMalhaAbertaToolStripMenuItem
            // 
            this.testeDeDegrauEmMalhaAbertaToolStripMenuItem.Name = "testeDeDegrauEmMalhaAbertaToolStripMenuItem";
            this.testeDeDegrauEmMalhaAbertaToolStripMenuItem.Size = new System.Drawing.Size(320, 26);
            this.testeDeDegrauEmMalhaAbertaToolStripMenuItem.Text = "Teste de Degrau em Malha Aberta";
            this.testeDeDegrauEmMalhaAbertaToolStripMenuItem.Click += new System.EventHandler(this.testeDeDegrauEmMalhaAbertaToolStripMenuItem_Click);
            // 
            // testeEmMalhaFechadaToolStripMenuItem
            // 
            this.testeEmMalhaFechadaToolStripMenuItem.Name = "testeEmMalhaFechadaToolStripMenuItem";
            this.testeEmMalhaFechadaToolStripMenuItem.Size = new System.Drawing.Size(320, 26);
            this.testeEmMalhaFechadaToolStripMenuItem.Text = "Teste em Malha Fechada (On-Off)";
            this.testeEmMalhaFechadaToolStripMenuItem.Click += new System.EventHandler(this.testeEmMalhaFechadaToolStripMenuItem_Click);
            // 
            // testeEmMalhaFechadaPPIPIDToolStripMenuItem
            // 
            this.testeEmMalhaFechadaPPIPIDToolStripMenuItem.Name = "testeEmMalhaFechadaPPIPIDToolStripMenuItem";
            this.testeEmMalhaFechadaPPIPIDToolStripMenuItem.Size = new System.Drawing.Size(320, 26);
            this.testeEmMalhaFechadaPPIPIDToolStripMenuItem.Text = "Teste em Malha Fechada (P/PI/PID)";
            this.testeEmMalhaFechadaPPIPIDToolStripMenuItem.Click += new System.EventHandler(this.testeEmMalhaFechadaPPIPIDToolStripMenuItem_Click);
            // 
            // cadastroDeModeloFOPTDToolStripMenuItem
            // 
            this.cadastroDeModeloFOPTDToolStripMenuItem.Name = "cadastroDeModeloFOPTDToolStripMenuItem";
            this.cadastroDeModeloFOPTDToolStripMenuItem.Size = new System.Drawing.Size(348, 26);
            this.cadastroDeModeloFOPTDToolStripMenuItem.Text = "Cadastro de Modelo Preditivo FOPTD";
            this.cadastroDeModeloFOPTDToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeModeloFOPTDToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualDeOperaçãoToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(62, 25);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // manualDeOperaçãoToolStripMenuItem
            // 
            this.manualDeOperaçãoToolStripMenuItem.Name = "manualDeOperaçãoToolStripMenuItem";
            this.manualDeOperaçãoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.manualDeOperaçãoToolStripMenuItem.Text = "Manual de Operação";
            this.manualDeOperaçãoToolStripMenuItem.Click += new System.EventHandler(this.manualDeOperaçãoToolStripMenuItem_Click);
            // 
            // flowPlot
            // 
            this.flowPlot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowPlot.AutoSize = true;
            this.flowPlot.Location = new System.Drawing.Point(0, 60);
            this.flowPlot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowPlot.Name = "flowPlot";
            this.flowPlot.Size = new System.Drawing.Size(435, 406);
            this.flowPlot.TabIndex = 1;
            // 
            // tempPlot
            // 
            this.tempPlot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tempPlot.Location = new System.Drawing.Point(436, 57);
            this.tempPlot.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.tempPlot.Name = "tempPlot";
            this.tempPlot.Size = new System.Drawing.Size(430, 409);
            this.tempPlot.TabIndex = 2;
            // 
            // searchPorts
            // 
            this.searchPorts.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.searchPorts.Location = new System.Drawing.Point(8, 32);
            this.searchPorts.Name = "searchPorts";
            this.searchPorts.Size = new System.Drawing.Size(151, 28);
            this.searchPorts.TabIndex = 6;
            this.searchPorts.Text = "Buscar Portas COM";
            this.searchPorts.UseVisualStyleBackColor = true;
            this.searchPorts.Click += new System.EventHandler(this.searchPorts_Click);
            // 
            // portsBox
            // 
            this.portsBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.portsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portsBox.FormattingEnabled = true;
            this.portsBox.Location = new System.Drawing.Point(170, 31);
            this.portsBox.Name = "portsBox";
            this.portsBox.Size = new System.Drawing.Size(97, 29);
            this.portsBox.TabIndex = 7;
            // 
            // disconnectPort
            // 
            this.disconnectPort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.disconnectPort.Location = new System.Drawing.Point(382, 29);
            this.disconnectPort.Name = "disconnectPort";
            this.disconnectPort.Size = new System.Drawing.Size(104, 30);
            this.disconnectPort.TabIndex = 8;
            this.disconnectPort.Text = "Desconectar";
            this.disconnectPort.UseVisualStyleBackColor = true;
            this.disconnectPort.Click += new System.EventHandler(this.disconnectPort_Click);
            // 
            // connectPort
            // 
            this.connectPort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.connectPort.Location = new System.Drawing.Point(273, 29);
            this.connectPort.Name = "connectPort";
            this.connectPort.Size = new System.Drawing.Size(104, 30);
            this.connectPort.TabIndex = 9;
            this.connectPort.Text = "Conectar";
            this.connectPort.UseVisualStyleBackColor = true;
            this.connectPort.Click += new System.EventHandler(this.connectPort_Click);
            // 
            // resetPort
            // 
            this.resetPort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.resetPort.AutoSize = true;
            this.resetPort.Location = new System.Drawing.Point(487, 29);
            this.resetPort.Name = "resetPort";
            this.resetPort.Size = new System.Drawing.Size(104, 31);
            this.resetPort.TabIndex = 10;
            this.resetPort.Text = "Reiniciar";
            this.resetPort.UseVisualStyleBackColor = true;
            this.resetPort.Click += new System.EventHandler(this.resetPort_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textBox1,
            this.textBox2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 457);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(866, 26);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(199, 21);
            this.textBox1.Text = "Conexão com a Porta COM:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(123, 21);
            this.textBox2.Text = "Desconectado!";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.textBox3.Location = new System.Drawing.Point(672, 468);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(194, 15);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "Desenvolvido por Leandro Favaretto";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // leiturasInstantâneasToolStripMenuItem
            // 
            this.leiturasInstantâneasToolStripMenuItem.Name = "leiturasInstantâneasToolStripMenuItem";
            this.leiturasInstantâneasToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.leiturasInstantâneasToolStripMenuItem.Text = "Leituras Instantâneas";
            this.leiturasInstantâneasToolStripMenuItem.Click += new System.EventHandler(this.leiturasInstantâneasToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Supervisório_PCA_2023.Properties.Resources.logoextensa;
            this.pictureBox1.Location = new System.Drawing.Point(694, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(365, 448);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 35);
            this.button1.TabIndex = 13;
            this.button1.Text = "Visão de Supervisório";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(866, 483);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.resetPort);
            this.Controls.Add(this.connectPort);
            this.Controls.Add(this.disconnectPort);
            this.Controls.Add(this.portsBox);
            this.Controls.Add(this.searchPorts);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tempPlot);
            this.Controls.Add(this.flowPlot);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "SUPERVISÓRIO PROJETO DE CONTROLE COM ARDUINO por Leandro Favaretto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conexãoComArduinoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conectarAoArduinoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coletaDeDadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarColetaDeDadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finalizarColetaDeDadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tomadaDeDadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesDeControleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualDeOperaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesDosGráficosToolStripMenuItem;
        private ScottPlot.FormsPlot flowPlot;
        private ScottPlot.FormsPlot tempPlot;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button searchPorts;
        private System.Windows.Forms.ComboBox portsBox;
        private System.Windows.Forms.Button disconnectPort;
        private System.Windows.Forms.Button connectPort;
        private ToolStripMenuItem ferramentasAvançadasToolStripMenuItem;
        private ToolStripMenuItem sintoniaAutomáticaDeFOPTDToolStripMenuItem;
        private ToolStripMenuItem testeDeDegrauEmMalhaAbertaToolStripMenuItem;
        private ToolStripMenuItem testeEmMalhaFechadaToolStripMenuItem;
        private ToolStripMenuItem limitesDaBombaEDaResistênciaToolStripMenuItem;
        private ToolStripMenuItem cadastroDeModeloFOPTDToolStripMenuItem;
        private ToolStripMenuItem testeEmMalhaFechadaPPIPIDToolStripMenuItem;
        private Button resetPort;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel textBox1;
        private ToolStripStatusLabel textBox2;
        private TextBox textBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripMenuItem leiturasInstantâneasToolStripMenuItem;
        private Button button1;
    }
}

