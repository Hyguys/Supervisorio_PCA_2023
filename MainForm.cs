using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using ScottPlot;
using System.Globalization;
using System.IO;
using System.Threading;
using Supervisório_PCA_2023;
using System.Diagnostics;

namespace Supervisório_PCA_2._0
{
    public partial class MainForm : Form
    {
        private void CheckAndSetCustomCulture()
        {
            CultureInfo systemCulture = CultureInfo.CurrentCulture;

            // Verifica se o separador decimal é diferente do ponto e o separador de milhar é diferente da vírgula
            if (systemCulture.NumberFormat.NumberDecimalSeparator != "." && systemCulture.NumberFormat.NumberGroupSeparator != ",")
            {
                // Define uma cultura personalizada para a formatação
                CultureInfo customCulture = new CultureInfo("pt-BR");
                customCulture.NumberFormat.NumberDecimalSeparator = ".";
                customCulture.NumberFormat.NumberGroupSeparator = ",";

                // Define a cultura personalizada apenas para o contexto do programa
                System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

                // Exibe a mensagem informando que a cultura foi alterada
                MessageBox.Show("O separador decimal e o separador de milhar do sistema foram alterados para garantir o correto funcionamento do programa.\n\nAo digitar dados, use o PONTO como separador decimal e a VÍRGULA como separador de milhar.\n\nSe ainda assim, mesmo lendo essa mensagem, o tempo continua sendo plotado de maneira esquisita, sugere-se fazer a mudança no sistema operacional como um todo.", "Atenção - SEPARADOR DECIMAL ALTERADO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public MainForm()
        {
            InitializeComponent();
            SubFormGraficos subFormGraficos = new SubFormGraficos(this);
            Globals.serialPort = new SerialPort(); // linha para inicializar o objeto serialPort 
            Globals.serialPort.BaudRate = 115200;
            Globals.serialPort.DataReceived += new SerialDataReceivedEventHandler(subFormGraficos.DataReceivedHandler);
            CheckAndSetCustomCulture();

        }
        private void searchPorts_Click(object sender, EventArgs e)
        {
            string[] ports = GlobalMethods.SearchSerialPorts();

            if (ports != null)
            {
                portsBox.Items.Clear();
                portsBox.Items.AddRange(ports);
                portsBox.SelectedIndex = 0; // Definir a primeira porta como selecionada
            }
        }

        private void disconnectPort_Click(object sender, EventArgs e)
        {
            GlobalMethods.DisconnectSerialPort();
            textBox2.Text = "Desconectado!";
            textBox2.ForeColor = Color.Black;
        }

        private void connectPort_Click(object sender, EventArgs e)
        {
            if (portsBox.SelectedItem != null) // Verifica se um item foi selecionado na combobox
            {
                string selectedPort = portsBox.SelectedItem.ToString();
                GlobalMethods.ConnectSerialPort(selectedPort);
                if (Globals.serialConnected)
                {
                    textBox2.Text = "Conectado!";
                    textBox2.ForeColor = Color.Blue;
                }
            }
        }

        private void conectarAoArduinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubFormConnectArduino subFormConnectArduino = new SubFormConnectArduino();
            subFormConnectArduino.ShowDialog();
            if (Globals.serialConnected == true)
            {
                textBox2.Text = "Conectado!";
                textBox2.ForeColor = Color.Blue;
            }
            else
            {
                textBox2.Text = "Disconectado!";
                textBox2.ForeColor = Color.Black;
            }
        }
        private void iniciarColetaDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verifica se a porta serial está conectada
            if (Globals.serialConnected == false)
            {
                MessageBox.Show("Não há nenhuma porta serial conectada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Globals.isRecordingData == true)
            {
                MessageBox.Show("Já há uma gravação de dados em andamento. Antes de iniciar outra, certifique-se de finalizar a anterior.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            // Exibe uma caixa de diálogo de confirmação
            DialogResult result = MessageBox.Show("Deseja começar a gravação dos dados atuais em um arquivo CSV?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Exibe uma caixa de diálogo para o usuário fornecer o nome do arquivo e o local de salvamento
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Arquivo CSV|*.csv";
                saveFileDialog.Title = "Salvar arquivo CSV";
                saveFileDialog.ShowDialog();

                // Verifica se o usuário selecionou um local e nome de arquivo válido
                if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                {
                    string filePath = saveFileDialog.FileName;

                    // Cria o arquivo CSV e escreve o cabeçalho
                    Globals.dataStreamWriter = new StreamWriter(filePath);
                    string header = "Tempo (segundos),PV Vazão medida (L/hr),SP Setpoint da Vazão (L/hr),MV Potência da Bomba (%),Histerese da Vazão (L/hr),DV Temperatura de Entrada (°C),PV Temperatura de Saída (°C),SP Setpoint da Temperatura de Saída (°C),MV Potência da Resistência (%),Histerese da Temperatura (°C),PV Vazão Pura Pré-Filtro (L/hr),PV Temperatura de Saída Pura Pré-Filtro (°C)";
                    Globals.dataStreamWriter.WriteLine(header);

                    // Define a flag global como TRUE para indicar que a gravação de dados está ocorrendo
                    Globals.isRecordingData = true;

                    MessageBox.Show("Gravação dos dados iniciada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void finalizarColetaDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalMethods.FinalizarColetaDeDados();
        }
        private void tomadaDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubFormConfigSampling subFormConfigSampling = new SubFormConfigSampling();
            subFormConfigSampling.Show();
        }
        private void configuraçõesDeControleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubFormConfigControl subFormConfigControl = new SubFormConfigControl();
            subFormConfigControl.Show();
        }


        private void configuraçõesDosGráficosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubFormConfigGraficos subFormConfigGraficos = new SubFormConfigGraficos();
            subFormConfigGraficos.Show();
        }

        private void ferramentasAvançadasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sintoniaAutomáticaDeFOPTDToolStripMenuItem_Click(object sender, EventArgs e)
        {
  
        }

        private void testeDeDegrauEmMalhaAbertaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubFormStepTuningFOPTD subFOPTD = new SubFormStepTuningFOPTD();
            subFOPTD.Show();
        }

        private void testeEmMalhaFechadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubFormONOFFTuningZieglerNichols subONOFF = new SubFormONOFFTuningZieglerNichols();
            subONOFF.Show();
        }

        private void limitesDaBombaEDaResistênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubFormLimitsResPump subForm = new SubFormLimitsResPump();
            //fazer esse subForm aparecer dentro do container MDI do MainForm 
            subForm.MdiParent = this;
            subForm.Show();

        }

        private void manualDeOperaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            string url = "https://docs.google.com/document/d/1VZLoLYIvWTJcpwHPKLnaq9GY4QwbK-XSpFI_VM4r4gc/edit?usp=sharing";

            try
            {
                Process.Start(url);
                MessageBox.Show("O manual técnico será aberto no seu navegador padrão.", "Abrir Manual", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir o navegador: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void cadastroDeModeloFOPTDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Essa função ainda não está pronta!", "Em desenvolvimento!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            //SubFormConfigModeloFOPTD subForm = new SubFormConfigModeloFOPTD();
            //subForm.Show();
        }

        private void testeEmMalhaFechadaPPIPIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Essa função ainda não está pronta!", "Em desenvolvimento!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

        }

        private void resetPort_Click(object sender, EventArgs e)
        {
            GlobalMethods.DisconnectSerialPort();
            textBox2.Text = "Disconectado!";
            textBox2.ForeColor = Color.Black;
            if (portsBox.SelectedItem != null) // Verifica se um item foi selecionado na combobox
            {
                string selectedPort = portsBox.SelectedItem.ToString();
                GlobalMethods.ConnectSerialPort(selectedPort);
                if (Globals.serialConnected)
                {
                    textBox2.Text = "Conectado!";
                    textBox2.ForeColor = Color.Blue;
                }
            }
        }

        private void leiturasInstantâneasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SubFormInstantReads subForm = new SubFormInstantReads();
            subForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SubFormInstantReads subForm = new SubFormInstantReads();
            subForm.Show();
        }

        private void portsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPort = portsBox.SelectedItem.ToString();
            Globals.selectedPort = selectedPort;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
