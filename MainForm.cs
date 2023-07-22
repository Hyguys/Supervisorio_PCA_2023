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

namespace Supervisório_PCA_2._0
{
    public partial class MainForm : Form
    {
        private StreamWriter dataStreamWriter; // Variável local para armazenar o objeto StreamWriter


        public MainForm()
        {
            InitializeComponent();
            Globals.serialPort = new SerialPort(); // linha para inicializar o objeto serialPort 
            Globals.serialPort.BaudRate = 115200;
            Globals.serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
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
                // Verifica se o formulário não foi descartado e se a invocação é necessária
                if (!IsDisposed && InvokeRequired)
                {
                    try
                    {
                        // Invoca o método novamente na thread da UI principal
                        Invoke(new MethodInvoker(() => ProcessData(subStrings)));
                    }
                    catch (ObjectDisposedException)
                    {
                        // Trate a exceção ObjectDisposedException, se necessário
                        // ou apenas retorne do método
                        return;
                    }
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
                var scatterFlowPlot = flowPlot.Plot.AddScatter(Globals.timeFlowData.ToArray(), Globals.flowData.ToArray(),label: "Vazão");
                flowPlot.Plot.Grid(Globals.ExibirGridVazao);
                flowPlot.Plot.XAxis.MajorGrid(Globals.ExibirGridVazao, color: Color.FromArgb(30,Color.Black));
                flowPlot.Plot.YAxis.MajorGrid(Globals.ExibirGridVazao, color: Color.FromArgb(30, Color.Black));
                flowPlot.Plot.SetAxisLimitsY(-3, 70); 
                flowPlot.Plot.SetAxisLimitsY(-3, 110,flowPlot.Plot.RightAxis.AxisIndex);
                flowPlot.Plot.Title("Controle de Vazão");
                flowPlot.Plot.YAxis.Label("Vazão (L/h)");
                var flowLegend = flowPlot.Plot.Legend(Globals.ExibirLegendaVazao);
                flowLegend.Location = Alignment.UpperLeft;
                scatterFlowPlot.MarkerColor = Globals.CorVazao;
                scatterFlowPlot.LineColor = Globals.CorVazao;
                scatterFlowPlot.MarkerSize = Globals.MarkerSizeVazao;
                scatterFlowPlot.LineWidth = Globals.LineSizeVazao;
                

                // Limpa o gráfico de temperatura e adiciona os pontos correspondentes aos dados
                tempPlot.Plot.Clear();
                var scatterTempPlot = tempPlot.Plot.AddScatter(Globals.timeTempData.ToArray(), Globals.tempOutData.ToArray(), label: "Temperatura");
                tempPlot.Plot.Grid(Globals.ExibirGridTemp);
                tempPlot.Plot.XAxis.MajorGrid(Globals.ExibirGridTemp, color: Color.FromArgb(30, Color.Black));
                tempPlot.Plot.YAxis.MajorGrid(Globals.ExibirGridTemp, color: Color.FromArgb(30, Color.Black));
                tempPlot.Plot.SetAxisLimitsY(-3, Math.Max(Globals.tempOutData.Max() * 1.25, 40));
                tempPlot.Plot.SetAxisLimitsY(-3, 110, tempPlot.Plot.RightAxis.AxisIndex);
                tempPlot.Plot.Title("Controle de Temperatura");
                tempPlot.Plot.YAxis.Label("Temperatura (°C)");
                var tempLegend = tempPlot.Plot.Legend(Globals.ExibirLegendaTemp);
                tempLegend.Location = Alignment.UpperLeft;
                scatterTempPlot.MarkerColor = Globals.CorTemp;
                scatterTempPlot.LineColor = Globals.CorTemp;
                scatterTempPlot.MarkerSize = Globals.MarkerSizeTemp;
                scatterTempPlot.LineWidth = Globals.LineSizeTemp;

                if (Globals.showHysteresisVazao == true)
                {
                    var scatterHysteresisFlowUpperLimit = flowPlot.Plot.AddScatter(Globals.timeFlowData.ToArray(), Globals.hysteresisFlowUpperLimitData.ToArray());
                    var scatterHysteresisFlowLowerLimit = flowPlot.Plot.AddScatter(Globals.timeFlowData.ToArray(), Globals.hysteresisFlowLowerLimitData.ToArray());
                    scatterHysteresisFlowUpperLimit.LineStyle = LineStyle.Dash;
                    scatterHysteresisFlowLowerLimit.LineStyle = LineStyle.Dash;
                    scatterHysteresisFlowUpperLimit.LineColor = Globals.CorSPVazao;
                    scatterHysteresisFlowLowerLimit.LineColor = Globals.CorSPVazao;

                    scatterHysteresisFlowUpperLimit.MarkerSize = 0;
                    scatterHysteresisFlowLowerLimit.MarkerSize = 0;
                }
             
                if (Globals.showHysteresisTemp == true)
                {
                    var scatterHysteresisTempUpperLimit = tempPlot.Plot.AddScatter(Globals.timeTempData.ToArray(), Globals.hysteresisTempUpperLimitData.ToArray());
                    var scatterHysteresisTempLowerLimit = tempPlot.Plot.AddScatter(Globals.timeTempData.ToArray(), Globals.hysteresisTempLowerLimitData.ToArray());
                    scatterHysteresisTempUpperLimit.LineStyle = LineStyle.Dash;
                    scatterHysteresisTempLowerLimit.LineStyle = LineStyle.Dash;
                    scatterHysteresisTempUpperLimit.LineColor = Globals.CorSPTemp;
                    scatterHysteresisTempLowerLimit.LineColor = Globals.CorSPTemp;

                    scatterHysteresisTempUpperLimit.MarkerSize = 0;
                    scatterHysteresisTempLowerLimit.MarkerSize = 0;
                }

                if (Globals.showSPVazao == true)
                {
                    var scatterSPVazao = flowPlot.Plot.AddScatter(Globals.timeFlowData.ToArray(), Globals.flowSPData.ToArray(),label: "SP Vazão");
                    scatterSPVazao.LineColor = Globals.CorSPVazao;
                    scatterSPVazao.MarkerColor = Globals.CorSPVazao;
                    scatterSPVazao.MarkerSize = Globals.MarkerSizeVazao;
                    scatterSPVazao.LineWidth = Globals.LineSizeVazao;
                }
                
                if (Globals.showSPTemp)
                {
                    var scatterSPTemp = tempPlot.Plot.AddScatter(Globals.timeTempData.ToArray(), Globals.tempSPData.ToArray(), label: "SP Temp.");
                    scatterSPTemp.LineColor = Globals.CorSPTemp;
                    scatterSPTemp.MarkerColor = Globals.CorSPTemp;
                    scatterSPTemp.MarkerSize = Globals.MarkerSizeTemp;
                    scatterFlowPlot.LineWidth = Globals.LineSizeTemp;
                }

                if (Globals.ExibirPotenciaBomba)
                {
                    var scatterPumpPower = flowPlot.Plot.AddScatter(Globals.timeFlowData.ToArray(), Globals.pumpPowerData.ToArray(), label: "Pot. Bomba");
                    scatterPumpPower.LineColor = Globals.CorPotenciaBomba;
                    scatterPumpPower.MarkerColor = Globals.CorPotenciaBomba;
                    scatterPumpPower.MarkerSize = Globals.MarkerSizeVazao;
                    scatterPumpPower.LineWidth = Globals.LineSizeVazao;
                    scatterPumpPower.YAxisIndex = flowPlot.Plot.RightAxis.AxisIndex;
                    flowPlot.Plot.RightAxis.Ticks(true);
                    flowPlot.Plot.YAxis2.Label("Potência Bomba (%)");
                    flowPlot.Plot.YAxis2.SetBoundary(0, 100);
                }
                else
                {
                    flowPlot.Plot.RightAxis.Ticks(false);
                    flowPlot.Plot.YAxis2.Label("");
                }

                if (Globals.ExibirPotenciaResistencia)
                {
                    var scatterResPower = tempPlot.Plot.AddScatter(Globals.timeTempData.ToArray(), Globals.resPowerData.ToArray(), label: "Pot. Resistência");
                    scatterResPower.LineColor = Globals.CorPotenciaRes;
                    scatterResPower.MarkerColor = Globals.CorPotenciaRes;
                    scatterResPower.MarkerSize = Globals.MarkerSizeTemp;
                    scatterResPower.LineWidth = Globals.LineSizeTemp;
                    scatterResPower.YAxisIndex = 1;
                    scatterResPower.YAxisIndex = tempPlot.Plot.RightAxis.AxisIndex;
                    tempPlot.Plot.RightAxis.Ticks(true);
                    tempPlot.Plot.YAxis2.Label("Potência Resistência (%)");
                    tempPlot.Plot.YAxis2.SetBoundary(0, 100);
                }
                else
                {
                    tempPlot.Plot.RightAxis.Ticks(false);
                    tempPlot.Plot.YAxis2.Label("");
                }

                if (Globals.ExibirVazaoPreFiltragem)
                {
                    var scatterTrueFlow = flowPlot.Plot.AddScatter(Globals.timeFlowData.ToArray(), Globals.pureFlowData.ToArray(), label: "Vazão Pré-filtro");
                    scatterTrueFlow.LineColor = Globals.CorVazaoPrefiltragem;
                    scatterTrueFlow.MarkerColor = Globals.CorVazaoPrefiltragem;
                    scatterTrueFlow.MarkerSize = Globals.MarkerSizeVazao;
                    scatterTrueFlow.LineWidth = Globals.LineSizeVazao;
                }

                if (Globals.ExibirTempPreFiltragem)
                {
                    var scatterTrueTemp = tempPlot.Plot.AddScatter(Globals.timeTempData.ToArray(), Globals.pureTempOutData.ToArray(), label: "Temp. Pré-filtro");
                    scatterTrueTemp.LineColor = Globals.CorTempPrefiltragem;
                    scatterTrueTemp.MarkerColor = Globals.CorTempPrefiltragem;
                    scatterTrueTemp.MarkerSize = Globals.MarkerSizeTemp;
                    scatterTrueTemp.LineWidth = Globals.LineSizeTemp;
                }

                if (Globals.ExibirTempEntrada)
                {
                    var scatterTempIn = tempPlot.Plot.AddScatter(Globals.timeTempData.ToArray(), Globals.tempInData.ToArray(), label: "Temp. Entrada");
                    scatterTempIn.LineColor = Globals.CorTempEntrada;
                    scatterTempIn.MarkerColor = Globals.CorTempEntrada;
                    scatterTempIn.MarkerSize = Globals.MarkerSizeTemp;
                    scatterTempIn.LineWidth = Globals.LineSizeTemp;
                }

                flowPlot.Render();
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

                if (ex.Message == "Sequence contains no elements")
                {
                    return;
                }

                // Exibe uma MessageBox com a mensagem de exceção em caso de outros erros
                MessageBox.Show("Ocorreu um erro ao realizar a plotagem: " + ex.Message + "\nO arduino será desconectado, e os dados de leitura recentes serão apagados.", "Erro na plotagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(Globals.isRecordingData == true)
                {
                    finalizarColetaDeDadosToolStripMenuItem.PerformClick();
                }
                GlobalMethods.ClearLists();
                disconnectPort.PerformClick();
                throw;
            }
        }


        private void AssignSubstringsToLists(string[] subStrings)
        {
            // Verifique se o número de substrings é igual ao número de listas
            if (subStrings.Length != Globals.globalListsNumber)
            {
                // Se o número estiver incorreto, exiba uma mensagem de erro ou tome a ação necessária
                Console.WriteLine("Número incorreto de substrings!");
                GlobalMethods.ClearLists();
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

                Globals.hysteresisFlowLowerLimitData.Add(double.Parse(subStrings[2], culture) - double.Parse(subStrings[4], culture));
                Globals.hysteresisFlowUpperLimitData.Add(double.Parse(subStrings[2], culture) + double.Parse(subStrings[4], culture));


                Globals.tempInData.Add(double.Parse(subStrings[5], culture));
                Globals.tempOutData.Add(double.Parse(subStrings[6], culture));
                Globals.tempSPData.Add(double.Parse(subStrings[7], culture));
                Globals.resPowerData.Add(double.Parse(subStrings[8].Replace("%", ""), culture));
                Globals.hysteresisTempData.Add(double.Parse(subStrings[9], culture));

                Globals.hysteresisTempLowerLimitData.Add(double.Parse(subStrings[7], culture) - double.Parse(subStrings[9], culture));
                Globals.hysteresisTempUpperLimitData.Add(double.Parse(subStrings[7], culture) + double.Parse(subStrings[9], culture));

                Globals.pureFlowData.Add(double.Parse(subStrings[10], culture));
                Globals.pureTempOutData.Add(double.Parse(subStrings[11], culture));

                // Verifique se a lista `Globals.timeTempData` excede o número máximo de pontos
                if (Globals.timeTempData.Count > Globals.numberTempPoints)
                {
                    int excessCount = Globals.tempOutData.Count - Globals.numberTempPoints;
                    Globals.tempOutData.RemoveRange(0, excessCount);
                    Globals.tempInData.RemoveRange(0, excessCount);
                    Globals.tempSPData.RemoveRange(0, excessCount);
                    Globals.resPowerData.RemoveRange(0, excessCount);
                    Globals.hysteresisTempData.RemoveRange(0, excessCount);
                    Globals.hysteresisTempLowerLimitData.RemoveRange(0, excessCount);
                    Globals.hysteresisTempUpperLimitData.RemoveRange(0, excessCount);
                    Globals.timeTempData.RemoveRange(0, excessCount);
                    Globals.pureTempOutData.RemoveRange(0,excessCount);
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
                    Globals.hysteresisFlowLowerLimitData.RemoveRange(0, excessCount);
                    Globals.hysteresisFlowUpperLimitData.RemoveRange(0, excessCount);
                    Globals.pureFlowData.RemoveRange(0, excessCount);

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
                    string header = "Tempo (segundos),Vazão medida (L/hr),Setpoint da Vazão (L/hr),Potência da Bomba (%),Histerese da Vazão (L/hr),Temperatura de Entrada (°C),Temperatura de Saída (°C),Setpoint da Temperatura de Saída (°C),Potência da Resistência (%),Histerese da Temperatura (°C),Vazão Pura Pré-Filtro (L/hr), Temperatura de Saída Pura Pré-Filtro (°C)";
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

                    GlobalMethods.ClearLists();
                    GlobalMethods.ResetGlobalVariables();
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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
            SubFormAutoTuningFOPTD subFOPTD = new SubFormAutoTuningFOPTD();
            subFOPTD.Show();
        }
    }
}
