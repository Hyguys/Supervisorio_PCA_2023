﻿namespace Supervisório_PCA_2._0
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conexãoComArduinoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conectarAoArduinoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coletaDeDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarColetaDeDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalizarColetaDeDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tomadaDeDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesDeControleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesDosGráficosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualDeOperaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treinamentoDoSupervisórioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreOProjetoPCAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreOMóduloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreODesenvolvedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowPlot = new ScottPlot.FormsPlot();
            this.tempPlot = new ScottPlot.FormsPlot();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.searchPorts = new System.Windows.Forms.Button();
            this.portsBox = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.disconnectPort = new System.Windows.Forms.Button();
            this.connectPort = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
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
            this.ajudaToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(857, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conexãoComArduinoToolStripMenuItem,
            this.coletaDeDadosToolStripMenuItem});
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
            this.tomadaDeDadosToolStripMenuItem,
            this.configuraçõesDeControleToolStripMenuItem,
            this.configuraçõesDosGráficosToolStripMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(122, 25);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // tomadaDeDadosToolStripMenuItem
            // 
            this.tomadaDeDadosToolStripMenuItem.Name = "tomadaDeDadosToolStripMenuItem";
            this.tomadaDeDadosToolStripMenuItem.Size = new System.Drawing.Size(309, 26);
            this.tomadaDeDadosToolStripMenuItem.Text = "Tomada de Dados e Amostragem";
            // 
            // configuraçõesDeControleToolStripMenuItem
            // 
            this.configuraçõesDeControleToolStripMenuItem.Name = "configuraçõesDeControleToolStripMenuItem";
            this.configuraçõesDeControleToolStripMenuItem.Size = new System.Drawing.Size(309, 26);
            this.configuraçõesDeControleToolStripMenuItem.Text = "Configurações de Controle";
            // 
            // configuraçõesDosGráficosToolStripMenuItem
            // 
            this.configuraçõesDosGráficosToolStripMenuItem.Name = "configuraçõesDosGráficosToolStripMenuItem";
            this.configuraçõesDosGráficosToolStripMenuItem.Size = new System.Drawing.Size(309, 26);
            this.configuraçõesDosGráficosToolStripMenuItem.Text = "Configurações dos Gráficos";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualDeOperaçãoToolStripMenuItem,
            this.treinamentoDoSupervisórioToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(62, 25);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // manualDeOperaçãoToolStripMenuItem
            // 
            this.manualDeOperaçãoToolStripMenuItem.Name = "manualDeOperaçãoToolStripMenuItem";
            this.manualDeOperaçãoToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.manualDeOperaçãoToolStripMenuItem.Text = "Manual de Operação";
            // 
            // treinamentoDoSupervisórioToolStripMenuItem
            // 
            this.treinamentoDoSupervisórioToolStripMenuItem.Name = "treinamentoDoSupervisórioToolStripMenuItem";
            this.treinamentoDoSupervisórioToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.treinamentoDoSupervisórioToolStripMenuItem.Text = "Treinamento do Supervisório";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreOProjetoPCAToolStripMenuItem,
            this.sobreOMóduloToolStripMenuItem,
            this.sobreODesenvolvedorToolStripMenuItem});
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(63, 25);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // sobreOProjetoPCAToolStripMenuItem
            // 
            this.sobreOProjetoPCAToolStripMenuItem.Name = "sobreOProjetoPCAToolStripMenuItem";
            this.sobreOProjetoPCAToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.sobreOProjetoPCAToolStripMenuItem.Text = "Sobre o Projeto PCA";
            // 
            // sobreOMóduloToolStripMenuItem
            // 
            this.sobreOMóduloToolStripMenuItem.Name = "sobreOMóduloToolStripMenuItem";
            this.sobreOMóduloToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.sobreOMóduloToolStripMenuItem.Text = "Sobre o Módulo";
            // 
            // sobreODesenvolvedorToolStripMenuItem
            // 
            this.sobreODesenvolvedorToolStripMenuItem.Name = "sobreODesenvolvedorToolStripMenuItem";
            this.sobreODesenvolvedorToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.sobreODesenvolvedorToolStripMenuItem.Text = "Sobre o Desenvolvedor";
            // 
            // flowPlot
            // 
            this.flowPlot.AutoSize = true;
            this.flowPlot.Location = new System.Drawing.Point(415, 34);
            this.flowPlot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowPlot.Name = "flowPlot";
            this.flowPlot.Size = new System.Drawing.Size(427, 221);
            this.flowPlot.TabIndex = 1;
            // 
            // tempPlot
            // 
            this.tempPlot.Location = new System.Drawing.Point(415, 251);
            this.tempPlot.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.tempPlot.Name = "tempPlot";
            this.tempPlot.Size = new System.Drawing.Size(427, 240);
            this.tempPlot.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Conexão com a Porta:";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(179, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(126, 22);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Não conectado!";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Supervisório_PCA_2._0.Properties.Resources.logoextensa;
            this.pictureBox1.Location = new System.Drawing.Point(12, 432);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(252, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // searchPorts
            // 
            this.searchPorts.Location = new System.Drawing.Point(12, 62);
            this.searchPorts.Name = "searchPorts";
            this.searchPorts.Size = new System.Drawing.Size(151, 32);
            this.searchPorts.TabIndex = 6;
            this.searchPorts.Text = "Buscar Portas COM";
            this.searchPorts.UseVisualStyleBackColor = true;
            this.searchPorts.Click += new System.EventHandler(this.searchPorts_Click);
            // 
            // portsBox
            // 
            this.portsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portsBox.FormattingEnabled = true;
            this.portsBox.Location = new System.Drawing.Point(169, 65);
            this.portsBox.Name = "portsBox";
            this.portsBox.Size = new System.Drawing.Size(136, 29);
            this.portsBox.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.textBox3.Location = new System.Drawing.Point(651, 482);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(194, 15);
            this.textBox3.TabIndex = 8;
            this.textBox3.Text = "Desenvolvido por Leandro Favaretto";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // disconnectPort
            // 
            this.disconnectPort.Location = new System.Drawing.Point(12, 100);
            this.disconnectPort.Name = "disconnectPort";
            this.disconnectPort.Size = new System.Drawing.Size(151, 30);
            this.disconnectPort.TabIndex = 9;
            this.disconnectPort.Text = "Desconectar";
            this.disconnectPort.UseVisualStyleBackColor = true;
            this.disconnectPort.Click += new System.EventHandler(this.disconnectPort_Click);
            // 
            // connectPort
            // 
            this.connectPort.Location = new System.Drawing.Point(169, 100);
            this.connectPort.Name = "connectPort";
            this.connectPort.Size = new System.Drawing.Size(136, 30);
            this.connectPort.TabIndex = 10;
            this.connectPort.Text = "Conectar";
            this.connectPort.UseVisualStyleBackColor = true;
            this.connectPort.Click += new System.EventHandler(this.connectPort_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(857, 509);
            this.Controls.Add(this.connectPort);
            this.Controls.Add(this.disconnectPort);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.portsBox);
            this.Controls.Add(this.searchPorts);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tempPlot);
            this.Controls.Add(this.flowPlot);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SUPERVISÓRIO 2.0 PROJETO DE CONTROLE COM ARDUINO by Hyguys";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreOProjetoPCAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreOMóduloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreODesenvolvedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tomadaDeDadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesDeControleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualDeOperaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treinamentoDoSupervisórioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesDosGráficosToolStripMenuItem;
        private ScottPlot.FormsPlot flowPlot;
        private ScottPlot.FormsPlot tempPlot;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button searchPorts;
        private System.Windows.Forms.ComboBox portsBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button disconnectPort;
        private System.Windows.Forms.Button connectPort;
    }
}

