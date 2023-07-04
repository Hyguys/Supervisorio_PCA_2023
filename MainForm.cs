﻿using System;
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

namespace Supervisório_PCA_2._0
{
    public partial class MainForm : Form
    {
        private StreamWriter dataStreamWriter; // Variável local para armazenar o objeto StreamWriter


        public MainForm()
        {
            InitializeComponent();
            Globals.serialPort = new SerialPort(); // linha para inicializar o objeto serialPort 
            Globals.serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
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
            textBox2.Text = "Disconectado!";
            textBox2.ForeColor = Color.Black;
        }


        private void connectPort_Click(object sender, EventArgs e)
        {
            if (portsBox.SelectedItem != null) // Verifica se um item foi selecionado na combobox
            {
                string selectedPort = portsBox.SelectedItem.ToString();
                GlobalMethods.ConnectSerialPort(selectedPort);
                textBox2.Text = "Conectado!";
                textBox2.ForeColor = Color.Blue;
            }
        }

        // Declare um evento para o recebimento de dados na porta serial
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // Verifica se há dados disponíveis para leitura na porta serial
            if (Globals.serialPort.BytesToRead > 0)
            {
                string lineRead = ReadLineSerialPort();

                Console.WriteLine(lineRead);

                // Verifica se a cadeia de caracteres contém "nan"
                if (lineRead.Contains("nan"))
                {
                    // Exibe uma mensagem informando sobre o erro de leitura dos sensores
                    // e a necessidade de reinicializar o Arduino
                    MessageBox.Show("Erro na leitura dos sensores. Valores não-numéricos (NaN) detectados.\n\nÉ necessário reinicializar o Arduino.", "Erro na leitura dos sensores", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Reinicializa o Arduino
                    ReiniciarArduino();

                    // Retorna para evitar a execução do restante do código
                    return;
                }

                string[] subStrings = GlobalMethods.SplitStringBySpace(lineRead);

                // Grava a linha de dados no StreamWriter caso esteja gravando dados
                if (Globals.isRecordingData)
                {
                    dataStreamWriter.Write(string.Join(",", subStrings));
                }

                // Verifica se a invocação é necessária
                if (InvokeRequired)
                {
                    // Invoca o método novamente na thread da UI principal
                    Invoke(new MethodInvoker(() => ProcessData(subStrings)));
                }
                else
                {
                    // Chama o método diretamente
                    ProcessData(subStrings);
                }
            }
        }

        private void ProcessData(string[] subStrings)
        {
            try
            {
                // Atribui as substrings às listas globais
                AssignSubstringsToLists(subStrings);

                // Limpa o gráfico de fluxo e adiciona os pontos correspondentes aos dados
                flowPlot.Plot.Clear();
                var scatterFlowPlot = flowPlot.Plot.AddScatter(Globals.timeFlowData.ToArray(), Globals.flowData.ToArray());
                flowPlot.Render();

                // Limpa o gráfico de temperatura e adiciona os pontos correspondentes aos dados
                tempPlot.Plot.Clear();
                var scatterTempPlot = tempPlot.Plot.AddScatter(Globals.timeTempData.ToArray(), Globals.tempOutData.ToArray());
                tempPlot.Render();
            }
            catch (InvalidOperationException ex)
            {
                // Verifica se a mensagem da exceção é "xs must contain at least one element"
                if (ex.Message == "xs must contain at least one element")
                {
                    // Ignora a plotagem e pula para a próxima linha
                    return;
                }

                // Exibe uma MessageBox com a mensagem de exceção em caso de outros erros
                MessageBox.Show("Ocorreu um erro ao realizar a plotagem: " + ex.Message, "Erro na plotagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }


        private void AssignSubstringsToLists(string[] subStrings)
        {
            // Verifique se o número de substrings é igual ao número de listas
            if (subStrings.Length != 10)
            {
                // Se o número estiver incorreto, exiba uma mensagem de erro ou tome a ação necessária
                Console.WriteLine("Número incorreto de substrings!");
                return;
            }

            // Use a cultura padrão para conversão de strings em double
            CultureInfo culture = CultureInfo.CurrentCulture;

            // Converta as substrings em double e atribua-as às listas correspondentes
            try
            {
                Globals.timeFlowData.Add(double.Parse(subStrings[0], culture));
                Globals.timeTempData.Add(double.Parse(subStrings[0], culture));
                Globals.flowData.Add(double.Parse(subStrings[1], culture));
                Globals.flowSPData.Add(double.Parse(subStrings[2], culture));
                Globals.pumpPowerData.Add(double.Parse(subStrings[3].Replace("%", ""), culture));
                Globals.hysteresisFlowData.Add(double.Parse(subStrings[4], culture));
                Globals.tempInData.Add(double.Parse(subStrings[5], culture));
                Globals.tempOutData.Add(double.Parse(subStrings[6], culture));
                Globals.tempSPData.Add(double.Parse(subStrings[7], culture));
                Globals.resPowerData.Add(double.Parse(subStrings[8].Replace("%", ""), culture));
                Globals.hysteresisTempData.Add(double.Parse(subStrings[9], culture));

            
                // Verifique se a lista `Globals.timeTempData` excede o número máximo de pontos
                if (Globals.timeTempData.Count > Globals.numberTempPoints)
                {
                    int excessCount = Globals.tempOutData.Count - Globals.numberTempPoints;
                    Globals.tempOutData.RemoveRange(0, excessCount);
                    Globals.tempInData.RemoveRange(0, excessCount);
                    Globals.tempSPData.RemoveRange(0, excessCount);
                    Globals.resPowerData.RemoveRange(0, excessCount);
                    Globals.hysteresisTempData.RemoveRange(0, excessCount);
                    Globals.timeTempData.RemoveRange(0, excessCount);
                }

                // Verifique se a lista `Globals.timeFlowData` excede o número máximo de pontos
                if (Globals.timeFlowData.Count > Globals.numberFlowPoints)
                {
                    int excessCount = Globals.timeFlowData.Count - Globals.numberFlowPoints;
                    Globals.timeFlowData.RemoveRange(0, excessCount);
                    Globals.flowData.RemoveRange(0, excessCount);
                    Globals.flowSPData.RemoveRange(0, excessCount);
                    Globals.pumpPowerData.RemoveRange(0, excessCount); 
                    Globals.hysteresisFlowData.RemoveRange(0, excessCount);
                    
                }
            }
            catch (FormatException ex)
            {
                // Se ocorrer um erro de conversão, exiba uma mensagem de erro ou tome a ação necessária
                Console.WriteLine("Erro na conversão das substrings para double: " + ex.Message);
            }
        }






        private string ReadLineSerialPort()
        {
            try
            {
                string lineRead = Globals.serialPort.ReadLine();  // Lê uma linha da porta serial
                return lineRead;
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Erro ao ler da porta COM: " + ex.Message, "Erro na leitura!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);

                if (result == DialogResult.Abort)
                {
                    // Caso seja necessário abortar, invoca o clique do botão "disconnectPort"
                    if (this.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            disconnectPort.PerformClick();  // Executa o clique do botão "disconnectPort" para desconectar da porta serial
                        });
                    }
                    else
                    {
                        disconnectPort.PerformClick();
                    }
                }
                else if (result == DialogResult.Retry)
                {
                    // Caso seja necessário reconectar, invoca a desconexão do porto serial e o clique do botão "connectPort"
                    if (this.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            GlobalMethods.DisconnectSerialPort();  // Executa a desconexão da porta serial
                            connectPort.PerformClick();  // Executa o clique do botão "connectPort" para reconectar à porta serial
                        });
                    }
                    else
                    {
                        GlobalMethods.DisconnectSerialPort();
                        connectPort.PerformClick();
                    }
                }
                else if (result == DialogResult.Ignore)
                {
                    // Ignorar
                }
            }

            return string.Empty; // Retornar uma string vazia em caso de erro
        }


        private void ReiniciarArduino()
        {
            try
            {
                // Verifica se a porta serial está aberta
                if (Globals.serialPort.IsOpen)
                {
                    // Define o sinal DTR como true por um breve período de tempo
                    Globals.serialPort.DtrEnable = true;
                    Thread.Sleep(500);  // Aguarda 500ms para permitir a reinicialização do Arduino

                    // Limpa as listas globais de dados
                    Globals.timeFlowData.Clear();
                    Globals.timeTempData.Clear();
                    Globals.flowData.Clear();
                    Globals.flowSPData.Clear();
                    Globals.pumpPowerData.Clear();
                    Globals.hysteresisFlowData.Clear();
                    Globals.tempInData.Clear();
                    Globals.tempOutData.Clear();
                    Globals.tempSPData.Clear();
                    Globals.resPowerData.Clear();
                    Globals.hysteresisTempData.Clear();

                    Globals.serialPort.DtrEnable = false;  // Restaura o sinal DTR para false

                    // Executa o clique do botão "disconnectPort" usando BeginInvoke para garantir que seja chamado no thread apropriado
                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            disconnectPort.PerformClick();
                        }));
                    }
                    else
                    {
                        disconnectPort.PerformClick();
                    }

                    MessageBox.Show("Comando de reinicialização enviado para o Arduino e porta serial fechada.", "Reinicialização do Arduino", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Não é possível reinicializar o Arduino. A porta serial não está aberta.", "Erro na reinicialização", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao reinicializar o Arduino: " + ex.Message, "Erro na reinicialização", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Não há nenhuma porta serial conectada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
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
                    dataStreamWriter = new StreamWriter(filePath);
                    string header = "Tempo (segundos),Vazão medida (L/hr),Setpoint da Vazão (L/hr),Potência da Bomba (%),Histerese da Vazão (L/hr),Temperatura de Entrada (°C),Temperatura de Saída (°C),Setpoint da Temperatura de Saída (°C),Potência da Resistência (%),Histerese da Temperatura (°C)";
                    dataStreamWriter.WriteLine(header);

                    // Define a flag global como TRUE para indicar que a gravação de dados está ocorrendo
                    Globals.isRecordingData = true;

                    MessageBox.Show("Gravação dos dados iniciada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void finalizarColetaDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.isRecordingData)
            {
                // Verifica se o objeto StreamWriter está inicializado
                if (dataStreamWriter != null)
                {
                    // Fecha o arquivo e libera os recursos
                    dataStreamWriter.Close();
                    dataStreamWriter = null; // Define como null para indicar que não há um arquivo aberto

                    // Define a flag global como FALSE para indicar que a gravação de dados foi finalizada
                    Globals.isRecordingData = false;

                    MessageBox.Show("Gravação dos dados finalizada e arquivo salvo.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Nenhuma gravação de dados em andamento.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
