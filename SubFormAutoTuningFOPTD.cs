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
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using MathNet.Numerics.Optimization;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;
using ParticleSwarmOptimization;
using ScottPlot;
using System.Diagnostics;

namespace Supervisório_PCA_2._0
{
    public partial class SubFormAutoTuningFOPTD : Form
    {
        private bool experimentRunning = false;
        private List<double> timeExp = new List<double>();
        private List<double> flowExp = new List<double>();
        private float stepPumpPower = 0;
        private double initialTime = 0.0;
        private double initialFlow = 0.0;

        public SubFormAutoTuningFOPTD()
        {
            InitializeComponent();
            Globals.serialPort.DataReceived += new SerialDataReceivedEventHandler(AutoTuningFOPTDDataHandler);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
         


            if (Globals.serialConnected == false || Globals.serialPort == null)
            {
                MessageBox.Show("Não há uma porta serial conectada.", "Porta serial não conectada!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(txtPotenciaBomba.Text,out stepPumpPower) || stepPumpPower < -100 || stepPumpPower > 100)
            {
                MessageBox.Show("Digite um valor decimal entre -100 e 100.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPotenciaBomba.Text = string.Empty;
                return;
            }

            if(Globals.controlTypePump != 0)
            {
                Globals.showHysteresisVazao = false;
                Globals.showSPVazao = false;

                Globals.controlTypePump = 0;
                Globals.serialPort.WriteLine("CTP 0");
                Thread.Sleep(250);

            }
            // Obtém o índice do último elemento (Count - 1)
            int lastIndex = Globals.pumpPowerData.Count - 1;
            // Obtém o último elemento usando o índice
            double lastPumpPower = Globals.pumpPowerData[lastIndex];
            // Calcula o novo valor de pumpPower
            double newPumpPower = lastPumpPower + stepPumpPower;

            // Verifica se o novo valor é menor que 0 e ajusta para 0
            if (newPumpPower < 0)
            {
                newPumpPower = 0;
            }
            // Verifica se o novo valor é maior que 100 e ajusta para 100
            else if (newPumpPower > 100)
            {
                newPumpPower = 100;
            }


            Globals.pumpPower = newPumpPower;
            string command = "PP " + newPumpPower.ToString("0.00");
            Globals.serialPort.WriteLine(command);


            MessageBox.Show("Vazão acionada em " + newPumpPower.ToString("0.00") + "%, foi aplicado um degrau de " + stepPumpPower + "%.\nAguardar até que o estado estacionário seja atingido novamente.", "Início do experimento!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            /* INICIAR ARMAZENAMENTO DO EXPERIMENTO */
            experimentRunning = true;
        }

        private void SubFormAutoTuningFOPTD_Load(object sender, EventArgs e)
        {

        }

        private void AutoTuningFOPTDDataHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // Verificar se o experimento está em execução
            if (experimentRunning)
            {
                // Obter os dados mais recentes das listas globais (Globals.timeFlowData e Globals.flowData)
                // Nota: É importante sincronizar o acesso a essas listas para evitar problemas de concorrência.
                // Você pode usar o bloqueio (lock) para garantir que apenas um thread acesse as listas de cada vez.

                double timeData;
                double flowData;

                lock (Globals.timeFlowData) // Bloqueia o acesso à lista Globals.timeFlowData
                {
                    // Obter o valor mais recente de Globals.timeFlowData
                    if (Globals.timeFlowData.Count > 0)
                    {
                        timeData = Globals.timeFlowData[Globals.timeFlowData.Count - 1];
                    }
                    else
                    {
                        // Se a lista estiver vazia, atribuir um valor padrão
                        timeData = 0.0;
                    }
                }

                lock (Globals.flowData) // Bloqueia o acesso à lista Globals.flowData
                {
                    // Obter o valor mais recente de Globals.flowData
                    if (Globals.flowData.Count > 0)
                    {
                        flowData = Globals.flowData[Globals.flowData.Count - 1];
                    }
                    else
                    {
                        // Se a lista estiver vazia, atribuir um valor padrão
                        flowData = 0.0;
                    }
                }

                // Se o initialTime ainda não foi definido, atribua o valor do primeiro dado de tempo recebido.
                if (initialTime == 0.0)
                {
                    initialTime = timeData;
                    initialFlow = flowData;
                }

                // Adicionar o tempo relativo ao initialTime às listas timeExp e flowExp
                timeExp.Add(timeData - initialTime);
                flowExp.Add(flowData - initialFlow);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!experimentRunning)
            {
                MessageBox.Show("Nenhum experimento está rodando no momento! Clique em Iniciar!","Atenção!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            experimentRunning = false;
            sp.Plot.Clear();

            // Chute inicial para as variáveis de decisão
            Vector<double> initialGuess = DenseVector.OfArray(new double[] { 1.0, 1.0, 1.0 });

            // Definir os limites inferior e superior para as variáveis de decisão
            ///////////////////////////////////////////////////////////////K     THETA   TAU
            Vector<double> lowerBound = DenseVector.OfArray(new double[] { 0.01, 1, 0.01 });
            Vector<double> upperBound = DenseVector.OfArray(new double[] { 100, 0.01, 100 });

            // Resolver o problema de otimização usando o Particle Swarm Optimization
            var optimizer = new ParticleSwarmOptimizer();
            var result = optimizer.FindMinimum(ObjectiveFunction, lowerBound, upperBound);


            // Verificar se a otimização foi bem-sucedida
            double optimalK_process = result[0];
            double optimalLag_process = result[1];
            double optimalTimeConstant_process = result[2];

            string message = "Valores ótimos encontrados:\n"
                             + "Ganho do processo (Kp) [L/% h]: " + optimalK_process.ToString("0.00") + "\n"
                             + "Atraso (theta) [s]: " + optimalLag_process.ToString("0.00") + "\n"
                             + "Constante de tempo (tau) [s]: " + optimalTimeConstant_process.ToString("0.00");


            MessageBox.Show(message, "Resultados da Otimização", MessageBoxButtons.OK, MessageBoxIcon.Information);


            // Plotar os pontos da série flowExp
            sp.Plot.AddScatter(timeExp.ToArray(), flowExp.ToArray(), label: "Desvio da Vazão Experimental", markerShape: MarkerShape.filledCircle, markerSize: 5, lineWidth: 0);

            // Plotar a linha representando a série flowModel
            double[] flowModel = new double[timeExp.Count];
            for (int i = 0; i < timeExp.Count; i++)
            {
                if (timeExp[i] >= optimalLag_process)
                {
                    flowModel[i] = optimalK_process * stepPumpPower * (1 - Math.Exp(-(timeExp[i] - optimalLag_process) / optimalTimeConstant_process));
                }
                else
                {
                    flowModel[i] = 0;
                }
            }
           

            // Plotar os pontos da série flowExp
            sp.Plot.AddScatter(timeExp.ToArray(), flowModel, label: "Desvio da Vazão Modelada", markerShape: MarkerShape.filledCircle, markerSize: 0, lineWidth: 1);

            // Configurar o gráfico com rótulos, título e legenda
            
            sp.Plot.XLabel("Tempo");
            sp.Plot.YLabel("Vazão");
            sp.Plot.Title("Gráfico de Vazão Modelada em FOPTD");
            sp.Plot.Legend();
            sp.Plot.Render();
            sp.Refresh();
            tabela.Rows.Add(optimalK_process.ToString("0.00"),
                             optimalLag_process.ToString("0.00"),
                             optimalTimeConstant_process.ToString("0.00"));
            timeExp.Clear();
            flowExp.Clear();
            initialTime = 0;
            initialFlow = 0;
        }

        // Restante do código...

        public double ObjectiveFunction(Vector<double> v)
        {
            double K_process = v[0];
            double lag_process = v[1];
            double timeconstant_process = v[2];

            // Função objetivo (soma da diferença quadrática)
            double objectiveTerm = 0;
            for (int i = 0; i < timeExp.Count; i++)
            {
                double flowModel_k = 0;
                if (timeExp[i] >= lag_process)
                {
                    flowModel_k = K_process * stepPumpPower * (1 - Math.Exp(-(timeExp[i] - lag_process) / timeconstant_process));
                }
                double diffSquared = (flowExp[i] - flowModel_k) * (flowExp[i] - flowModel_k);
                objectiveTerm += diffSquared;
                //MessageBox.Show("t: " + timeExp[i] + "\ni: " + i + "\ntau: " + timeconstant_process + "\ntheta: " + lag_process + "\nK: " + K_process + "\nstep: " + stepPumpPower + "\nflowModel: " + flowModel_k);
            }

            return objectiveTerm;
        }

        private void tabela_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
