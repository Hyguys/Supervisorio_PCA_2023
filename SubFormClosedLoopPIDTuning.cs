using ParticleSwarmOptimization;
using ScottPlot;
using Supervisório_PCA_2._0;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Optimization;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;
using ParticleSwarmOptimization;
using ScottPlot;

namespace Supervisório_PCA_2023
{
    public partial class SubFormClosedLoopPIDTuning : Form
    {
        public SubFormClosedLoopPIDTuning()
        {
            InitializeComponent();
            //Globals.serialPort.DataReceived += new SerialDataReceivedEventHandler(ClosedLoopPIDTuningDataHandler);
        }

        private void SubFormClosedLoopPIDTuning_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

        }

        //private bool experimentRunning = false;

        //private List<double> timeExp = new List<double>();
        //private List<double> flowExp = new List<double>();
        //private List<double> tempExp = new List<double>();

        //private double stepPumpPower = 0;
        //private double stepResPower = 0;

        //private double initialTime = 0.0;
        //private double initialFlow = 0.0;
        //private double initialTemp = 0.0;

        //private string selectedSystem = "Vazão";

        //private bool messageEquilibriumShown = false;



        //// Limite para considerar que o sistema atingiu o equilíbrio (por exemplo, 5%)
        //private double equilibriumThreshold = 0.05;

        //// Número de pontos a serem considerados para verificar a variação, baseados em 2 segundos de pontos
        //private int numPointsToCheck = (int)(2 / ((double)Globals.intervalSampling / 1000));

        //// Função para verificar se o sistema atingiu o equilíbrio
        //private bool HasSystemReachedEquilibrium(List<double> data)
        //{
        //    if (data.Count < numPointsToCheck)
        //        return false;

        //    // Obter os últimos 'numPointsToCheck' valores da lista
        //    var lastValues = data.Skip(data.Count - numPointsToCheck).ToList();

        //    // Verificar se a variação da saída é menor que o limiar de equilíbrio
        //    double average = lastValues.Average();
        //    if (average == 0.0)
        //    {
        //        return false; // Se a média for zero, a lista não está no estado de equilíbrio
        //    }

        //    foreach (double value in lastValues)
        //    {
        //        if (Math.Abs(value - average) / average >= equilibriumThreshold)
        //        {
        //            return false; // Se qualquer valor estiver fora do limiar, a lista não está no estado de equilíbrio
        //        }
        //    }

        //    return true; // Se todos os valores estiverem dentro do limiar, a lista está no estado de equilíbrio

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{

        //    if (Globals.serialConnected == false || Globals.serialPort == null)
        //    {
        //        MessageBox.Show("Não há uma porta serial conectada.", "Porta serial não conectada!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    if (selectedSystem == "Vazão")
        //    {
        //        if (Globals.controlTypePump == 0 || Globals.controlTypePump == 1)
        //        {
        //            MessageBox.Show("Para esse experimento, o tipo de controle deve ser P, PI ou PID. Tente novamente!"
        //                , "Controle não-automático!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        if (Globals.controlTypeRes == 0 || Globals.controlTypeRes == 1)
        //        {
        //            MessageBox.Show("Para esse experimento, o tipo de controle deve ser P, PI ou PID. Tente novamente!"
        //                , "Controle não-automático!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //    }
        //    MessageBox.Show("Armazenamento dos dados em malha fechada iniciado!"
        //        , "Início do experimento!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    /* INICIAR ARMAZENAMENTO DOS DADOS DO EXPERIMENTO */
        //    experimentRunning = true;
        //}



        //private void ClosedLoopPIDTuningDataHandler(object sender, SerialDataReceivedEventArgs e)
        //{

        //    // Verificar se o experimento está em execução
        //    if (experimentRunning)
        //    {
        //        if (selectedSystem == "Vazão")
        //        {

        //            // Obter os dados mais recentes das listas globais (Globals.timeFlowData e Globals.flowData)
        //            // Nota: É importante sincronizar o acesso a essas listas para evitar problemas de concorrência.
        //            // Você pode usar o bloqueio (lock) para garantir que apenas um thread acesse as listas de cada vez.

        //            double timeData;
        //            double flowData;

        //            lock (Globals.timeFlowData) // Bloqueia o acesso à lista Globals.timeFlowData
        //            {
        //                // Obter o valor mais recente de Globals.timeFlowData
        //                if (Globals.timeFlowData.Count > 0)
        //                {
        //                    timeData = Globals.timeFlowData[Globals.timeFlowData.Count - 1];
        //                }
        //                else
        //                {
        //                    // Se a lista estiver vazia, atribuir um valor padrão
        //                    timeData = 0.0;
        //                }
        //            }

        //            lock (Globals.flowData) // Bloqueia o acesso à lista Globals.flowData
        //            {
        //                // Obter o valor mais recente de Globals.flowData
        //                if (Globals.flowData.Count > 0)
        //                {
        //                    flowData = Globals.flowData[Globals.flowData.Count - 1];
        //                }
        //                else
        //                {
        //                    // Se a lista estiver vazia, atribuir um valor padrão
        //                    flowData = 0.0;
        //                }
        //            }

        //            // Se o initialTime ainda não foi definido, atribua o valor do primeiro dado de tempo recebido.
        //            if (initialTime == 0.0)
        //            {
        //                initialTime = timeData;
        //                initialFlow = flowData;
        //            }

        //            // Adicionar o tempo relativo ao initialTime às listas timeExp e flowExp
        //            timeExp.Add(timeData - initialTime);
        //            flowExp.Add(flowData - initialFlow);

        //            // Verificar se o sistema atingiu o equilíbrio na saída
        //            if (HasSystemReachedEquilibrium(flowExp) && messageEquilibriumShown == false)
        //            {
        //                // O sistema atingiu o equilíbrio, você pode fazer alguma ação aqui
        //                MessageBox.Show("Regime permanente/estado estacionário detectado. Você pode finalizar o experimento!", "Estado Estacionário Detectado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                messageEquilibriumShown = true;
        //            }
        //        }

        //        else if (selectedSystem == "Temperatura")
        //        {
        //            double timeData;
        //            double tempData;

        //            lock (Globals.timeTempData) // Bloqueia o acesso à lista Globals.timeTempOutData
        //            {
        //                // Obter o valor mais recente de Globals.timeTempOutData
        //                if (Globals.timeTempData.Count > 0)
        //                {
        //                    timeData = Globals.timeTempData[Globals.timeTempData.Count - 1];
        //                }
        //                else
        //                {
        //                    // Se a lista estiver vazia, atribuir um valor padrão
        //                    timeData = 0.0;
        //                }
        //            }

        //            lock (Globals.tempOutData) // Bloqueia o acesso à lista Globals.tempOutData
        //            {
        //                // Obter o valor mais recente de Globals.tempOutData
        //                if (Globals.tempOutData.Count > 0)
        //                {
        //                    tempData = Globals.tempOutData[Globals.tempOutData.Count - 1];
        //                }
        //                else
        //                {
        //                    // Se a lista estiver vazia, atribuir um valor padrão
        //                    tempData = 0.0;
        //                }
        //            }

        //            // Se o initialTime ainda não foi definido, atribua o valor do primeiro dado de tempo recebido.
        //            if (initialTime == 0.0)
        //            {
        //                initialTime = timeData;
        //                initialTemp = tempData;
        //            }

        //            // Adicionar o tempo relativo ao initialTime às listas timeExp e flowExp
        //            timeExp.Add(timeData - initialTime);
        //            tempExp.Add(tempData - initialTemp);

        //            // Verificar se o sistema atingiu o equilíbrio na saída
        //            if (HasSystemReachedEquilibrium(tempExp) && messageEquilibriumShown == false)
        //            {
        //                // O sistema atingiu o equilíbrio, você pode fazer alguma ação aqui
        //                MessageBox.Show("Regime permanente/estado estacionário detectado. Você pode finalizar o experimento!", "Estado Estacionário Detectado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                messageEquilibriumShown = true;
        //            }
        //        }
        //    }
        //}

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    lblEquilibrium.Visible = false;
        //    if (!experimentRunning)
        //    {
        //        MessageBox.Show("Nenhum experimento está rodando no momento! Clique em Iniciar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    experimentRunning = false;
        //    messageEquilibriumShown = false;
        //    sp.Plot.Clear();
        //    string command;

        //    if (selectedSystem=="Vazão")
        //    {
        //        command = "CTP 0";
        //        Globals.serialPort.WriteLine(command);
        //        command = "PP 0";
        //        Globals.serialPort.WriteLine(command);
        //    }
        //    else
        //    {
        //        command = "CTR 0";
        //        Globals.serialPort.WriteLine(command);
        //        command = "RP 0";
        //        Globals.serialPort.WriteLine(command);
        //    }




        //    // Verificar se a otimização foi bem-sucedida


        //    string message = "Valores ótimos encontrados:\n"
        //                     + "Ganho do processo (Kp) [L/% h]: " + optimalK_process.ToString("0.00") + "\n"
        //                     + "Atraso (theta) [s]: " + optimalLag_process.ToString("0.00") + "\n"
        //                     + "Constante de tempo (tau) [s]: " + optimalTimeConstant_process.ToString("0.00");


        //    MessageBox.Show(message, "Resultados da Otimização", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    if (selectedSystem == "Vazão")
        //    {

        //        // Plotar os pontos da série flowExp
        //        sp.Plot.AddScatter(timeExp.ToArray(), flowExp.ToArray(), label: "Desvio da Vazão Experimental", markerShape: MarkerShape.filledCircle, markerSize: 5, lineWidth: 0);

        //        // Plotar a linha representando a série flowModel
        //        double[] flowModel = new double[timeExp.Count];
        //        for (int i = 0; i < timeExp.Count; i++)
        //        {
        //            if (timeExp[i] >= optimalLag_process)
        //            {
        //                flowModel[i] = optimalK_process * stepPumpPower * (1 - Math.Exp(-(timeExp[i] - optimalLag_process) / optimalTimeConstant_process));
        //            }
        //            else
        //            {
        //                flowModel[i] = 0;
        //            }
        //        }


        //        // Plotar os pontos da série flowExp
        //        sp.Plot.AddScatter(timeExp.ToArray(), flowModel, label: "Desvio da Vazão Modelada", markerShape: MarkerShape.filledCircle, markerSize: 0, lineWidth: 1);

        //        // Configurar o gráfico com rótulos, título e legenda

        //        sp.Plot.XLabel("Tempo");
        //        sp.Plot.YLabel("Vazão");
        //        sp.Plot.Title("Gráfico de Vazão Modelada em FOPTD");
        //    }
        //    else if (selectedSystem == "Temperatura")
        //    {
        //        // Plotar os pontos da série tempExp
        //        sp.Plot.AddScatter(timeExp.ToArray(), tempExp.ToArray(), label: "Desvio da Vazão Experimental", markerShape: MarkerShape.filledCircle, markerSize: 5, lineWidth: 0);

        //        // Plotar a linha representando a série flowModel
        //        double[] tempModel = new double[timeExp.Count];
        //        for (int i = 0; i < timeExp.Count; i++)
        //        {
        //            if (timeExp[i] >= optimalLag_process)
        //            {
        //                tempModel[i] = optimalK_process * stepResPower * (1 - Math.Exp(-(timeExp[i] - optimalLag_process) / optimalTimeConstant_process));
        //            }
        //            else
        //            {
        //                tempModel[i] = 0;
        //            }
        //        }


        //        // Plotar os pontos da série tempExp
        //        sp.Plot.AddScatter(timeExp.ToArray(), tempModel, label: "Desvio da Vazão Modelada", markerShape: MarkerShape.filledCircle, markerSize: 0, lineWidth: 1);

        //        // Configurar o gráfico com rótulos, título e legenda

        //        sp.Plot.XLabel("Tempo");
        //        sp.Plot.YLabel("Temperatura");
        //        sp.Plot.Title("Gráfico de Temperatura Modelada em FOPTD");
        //    }

        //    sp.Plot.Legend();
        //    sp.Plot.Render();
        //    sp.Refresh();

        //    double Kp = optimalK_process;
        //    double theta = optimalLag_process;
        //    double tau = optimalTimeConstant_process;
        //    tabela.Rows.Add(tabela.Rows.Count.ToString("0"),
        //                     Kp.ToString("0.000"),
        //                     tau.ToString("0.000"),
        //                     theta.ToString("0.000"));

        //    tabelaControle.Rows.Add("Sintonia ID " + (tabela.Rows.Count - 1).ToString("0"), "-",
        //                     "-",
        //                     "-");

        //    double Kc = tau / ((theta + theta) * Kp);
        //    double tauI = tau;
        //    double tauD = 0;
        //    tabelaControle.Rows.Add("IMC PI τc = θ", Kc.ToString("0.00"),
        //                     tauI.ToString("0.00"),
        //                     tauD.ToString("0.00"));

        //    Kc = (tau + theta / 2) / ((theta + theta / 2) * Kp);
        //    tauI = tau + theta / 2;
        //    tauD = (tau * theta) / (2 * tau + theta);
        //    tabelaControle.Rows.Add("IMC PID τc = θ", Kc.ToString("0.00"),
        //                     tauI.ToString("0.00"),
        //                     tauD.ToString("0.00"));

        //    Kc = tau / ((tau + theta) * Kp);
        //    tauI = tau;
        //    tauD = 0;
        //    tabelaControle.Rows.Add("IMC PI τc = τ", Kc.ToString("0.00"),
        //                     tauI.ToString("0.00"),
        //                     tauD.ToString("0.00"));

        //    Kc = (0.15 / Kp) + (tau / (Kp * theta)) * (0.35 - (theta * tau / ((theta + tau) * (theta + tau))));
        //    tauI = 0.35 * theta + 13 * theta * tau * tau / (tau * tau + 12 * theta * tau + 7 * theta * theta);
        //    tauD = 0;
        //    tabelaControle.Rows.Add("AMIGO PI", Kc.ToString("0.00"),
        //                     tauI.ToString("0.00"),
        //                     tauD.ToString("0.00"));

        //    Kc = (0.25 + 0.45 * tau / theta) / Kp;
        //    tauI = (0.4 * theta + 0.8 * tau) * theta / (theta + 0.1 * tau);
        //    tauD = (0.5 * theta * tau) / (0.3 * theta + tau);
        //    tabelaControle.Rows.Add("AMIGO PID", Kc.ToString("0.00"),
        //                     tauI.ToString("0.00"),
        //                     tauD.ToString("0.00"));


        //    timeExp.Clear();
        //    flowExp.Clear();
        //    tempExp.Clear();
        //    initialTime = 0;
        //    initialFlow = 0;
        //    initialTemp = 0;
        //}

        //// Restante do código...

        //public double ObjectiveFunctionPump(Vector<double> v)
        //{
        //    double K_process = v[0];
        //    double lag_process = v[1];
        //    double timeconstant_process = v[2];

        //    // Função objetivo (soma da diferença quadrática)
        //    double objectiveTerm = 0;
        //    for (int i = 0; i < timeExp.Count; i++)
        //    {
        //        double flowModel_k = 0;
        //        if (timeExp[i] >= lag_process)
        //        {
        //            flowModel_k = K_process * stepPumpPower * (1 - Math.Exp(-(timeExp[i] - lag_process) / timeconstant_process));
        //        }
        //        double diffSquared = (flowExp[i] - flowModel_k) * (flowExp[i] - flowModel_k);
        //        objectiveTerm += diffSquared;
        //        //MessageBox.Show("t: " + timeExp[i] + "\ni: " + i + "\ntau: " + timeconstant_process + "\ntheta: " + lag_process + "\nK: " + K_process + "\nstep: " + stepPumpPower + "\nflowModel: " + flowModel_k);
        //    }

        //    return objectiveTerm;
        //}

        //public double ObjectiveFunctionRes(Vector<double> v)
        //{
        //    double K_process = v[0];
        //    double lag_process = v[1];
        //    double timeconstant_process = v[2];

        //    // Função objetivo (soma da diferença quadrática)
        //    double objectiveTerm = 0;
        //    for (int i = 0; i < timeExp.Count; i++)
        //    {
        //        double flowModel_k = 0;
        //        if (timeExp[i] >= lag_process)
        //        {
        //            flowModel_k = K_process * stepResPower * (1 - Math.Exp(-(timeExp[i] - lag_process) / timeconstant_process));
        //        }
        //        double diffSquared = (tempExp[i] - flowModel_k) * (tempExp[i] - flowModel_k);
        //        objectiveTerm += diffSquared;
        //        //MessageBox.Show("t: " + timeExp[i] + "\ni: " + i + "\ntau: " + timeconstant_process + "\ntheta: " + lag_process + "\nK: " + K_process + "\nstep: " + stepPumpPower + "\nflowModel: " + flowModel_k);
        //    }

        //    return objectiveTerm;
        //}

        //private void tabela_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}



        //private void tabela_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    // Verifica se a edição foi realizada na terceira coluna (índice 2) e se é uma nova linha
        //    if (e.ColumnIndex == 3 && e.RowIndex == tabela.NewRowIndex - 1)
        //    {
        //        // Verifica se todas as três colunas foram preenchidas
        //        if (tabela.Rows[tabela.NewRowIndex - 1].Cells[0].Value != null &&
        //            tabela.Rows[tabela.NewRowIndex - 1].Cells[1].Value != null &&
        //            tabela.Rows[tabela.NewRowIndex - 1].Cells[2].Value != null &&
        //            tabela.Rows[tabela.NewRowIndex - 1].Cells[3].Value != null)
        //        {
        //            // Recupera os valores das células da nova linha e realiza a conversão
        //            if (double.TryParse(tabela.Rows[tabela.NewRowIndex - 1].Cells[1].Value.ToString(), out double Kp) &&
        //                double.TryParse(tabela.Rows[tabela.NewRowIndex - 1].Cells[2].Value.ToString(), out double tau) &&
        //                double.TryParse(tabela.Rows[tabela.NewRowIndex - 1].Cells[3].Value.ToString(), out double theta))
        //            {
        //                tabelaControle.Rows.Add("Sintonia ID " + (tabela.Rows.Count - 1).ToString("0"), "-",
        //                     "-",
        //                     "-");

        //                double Kc = tau / ((theta + theta) * Kp);
        //                double tauI = tau;
        //                double tauD = 0;
        //                tabelaControle.Rows.Add("IMC PI τc = θ", Kc.ToString("0.00"),
        //                                 tauI.ToString("0.00"),
        //                                 tauD.ToString("0.00"));

        //                Kc = (tau + theta / 2) / ((theta + theta / 2) * Kp);
        //                tauI = tau + theta / 2;
        //                tauD = (tau * theta) / (2 * tau + theta);
        //                tabelaControle.Rows.Add("IMC PID τc = θ", Kc.ToString("0.00"),
        //                                 tauI.ToString("0.00"),
        //                                 tauD.ToString("0.00"));

        //                Kc = tau / ((tau + theta) * Kp);
        //                tauI = tau;
        //                tauD = 0;
        //                tabelaControle.Rows.Add("IMC PI τc = τ", Kc.ToString("0.00"),
        //                                 tauI.ToString("0.00"),
        //                                 tauD.ToString("0.00"));

        //                Kc = (0.15 / Kp) + (tau / (Kp * theta)) * (0.35 - (theta * tau / ((theta + tau) * (theta + tau))));
        //                tauI = 0.35 * theta + 13 * theta * tau * tau / (tau * tau + 12 * theta * tau + 7 * theta * theta);
        //                tauD = 0;
        //                tabelaControle.Rows.Add("AMIGO PI", Kc.ToString("0.00"),
        //                                 tauI.ToString("0.00"),
        //                                 tauD.ToString("0.00"));

        //                Kc = (0.25 + 0.45 * tau / theta) / Kp;
        //                tauI = (0.4 * theta + 0.8 * tau) * theta / (theta + 0.1 * tau);
        //                tauD = (0.5 * theta * tau) / (0.3 * theta + tau);
        //                tabelaControle.Rows.Add("AMIGO PID", Kc.ToString("0.00"),
        //                                 tauI.ToString("0.00"),
        //                                 tauD.ToString("0.00"));
        //            }
        //            else
        //            {
        //                // Alguns valores não são numéricos, lide com isso de acordo com sua lógica
        //                MessageBox.Show("Os valores de Kp, theta e tau devem ser números válidos.", "Erro de conversão", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            // A nova linha não foi totalmente preenchida, lide com isso de acordo com sua lógica
        //            MessageBox.Show("Preencha todas as três colunas na nova linha.", "Dados incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }

        //        // Adiciona três novas linhas ao DataGridView "tabelaControle"

        //    }
        //}

        //private void sp_Load(object sender, EventArgs e)
        //{

        //}

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    switch (comboBox1.SelectedItem)
        //    {
        //        case "Vazão":
        //            lblDegrau.Text = "Degrau da Potência da Bomba";
        //            lblPotenciaInicial.Text = "Potência da Bomba Inicial";
        //            selectedSystem = comboBox1.SelectedItem.ToString();
        //            tabela.Columns[1].HeaderText = "Ganho do Processo (Kp) [L/% h]";
        //            tabelaControle.Columns[1].HeaderText = "Kc [% h/L]";
        //            break;
        //        case "Temperatura":
        //            lblDegrau.Text = "Degrau da Potência da Resistência";
        //            lblPotenciaInicial.Text = "Potência da Resistência Inicial";
        //            selectedSystem = comboBox1.SelectedItem.ToString();
        //            tabela.Columns[1].HeaderText = "Ganho do Processo (Kp) [°C/%]";
        //            tabelaControle.Columns[1].HeaderText = "Kc [%/°C]";
        //            break;
        //    }
        //}
    }
}
