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
using MathNet.Numerics;

namespace Supervisório_PCA_2._0
{
    public partial class SubFormStepTuningFOPTD : Form
    {
        private bool experimentRunning = false;

        private List<double> timeExp = new List<double>();
        private List<double> flowExp = new List<double>();
        private List<double> tempExp = new List<double>();

        private double stepPumpPower = 0;
        private double stepResPower = 0;

        private double initialTime = 0.0;
        private double initialFlow = 0.0;
        private double initialTemp = 0.0;

        private string selectedSystem = "Vazão";

        private bool messageEquilibriumShown = false;

        private int residualType = 1; //0 = quadratic, 1 = absolute;

        private int numIdentification = 0;

        public SubFormStepTuningFOPTD()
        {
            InitializeComponent();
            Globals.serialPort.DataReceived += new SerialDataReceivedEventHandler(AutoTuningFOPTDDataHandler);
        }

        // Limite para considerar que o sistema atingiu o equilíbrio
        private double equilibriumThreshold = 0.05;

        // Número de pontos a serem considerados para verificar a variação, baseados em 3 segundos de pontos
        private int numPointsToCheck = (int)(3/((double)Globals.intervalSampling/1000)); 

        // Função para verificar se o sistema atingiu o equilíbrio
        private bool HasSystemReachedEquilibrium(List<double> data)
        {
            if (data.Count < numPointsToCheck)
                return false;

            // Obter os últimos 'numPointsToCheck' valores da lista
            var lastValues = data.Skip(data.Count - numPointsToCheck).ToList();

            // Verificar se a variação da saída é menor que o limiar de equilíbrio
            double average = lastValues.Average();
            if (average == 0.0)
            {
                return false; // Se a média for zero, a lista não está no estado de equilíbrio
            }

            foreach (double value in lastValues)
            {
                if (Math.Abs(value - average) / average >= equilibriumThreshold)
                {
                    return false; // Se qualquer valor estiver fora do limiar, a lista não está no estado de equilíbrio
                }
            }

            return true; // Se todos os valores estiverem dentro do limiar, a lista está no estado de equilíbrio

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Globals.serialConnected == false || Globals.serialPort == null)
            {
                MessageBox.Show("Não há uma porta serial conectada.", "Porta serial não conectada!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Observe que aqui o valor do numero que está no txtPotenciaBomba é convertido na variável stepPumpPower,
            //mesmo que o experimento a ser realizado seja da resistencia. isso é corrigido mais a frente.
            if (!double.TryParse(txtPotenciaBomba.Text,out stepPumpPower) || stepPumpPower < -100 || stepPumpPower > 100)
            {
                MessageBox.Show("Digite um valor decimal entre -100 e 100.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPotenciaBomba.Text = Globals.pumpPower.ToString("0.00");
                return;
            }
            timeExp.Clear();
            flowExp.Clear();
            tempExp.Clear();
            initialTime = 0;
            initialFlow = 0;
            initialTemp = 0;

            lblEquilibrium.Visible = false;

            if (selectedSystem == "Vazão")
            {
                // Obtém o índice do último elemento (Count - 1)
                int lastIndex = Globals.pumpPowerData.Count - 1;
                // Obtém o último elemento usando o índice
                double lastPumpPower = Globals.pumpPowerData[lastIndex];
                // Calcula o novo valor de pumpPower
                double newPumpPower = lastPumpPower + stepPumpPower;

                // Verifica se o novo valor é menor que 0 e ajusta para 0
                if (newPumpPower < Globals.lowerLimitPump)
                {
                    newPumpPower = Globals.lowerLimitPump;
                    stepPumpPower = -lastPumpPower;
                }
                // Verifica se o novo valor é maior que 100 e ajusta para 100
                else if (newPumpPower >= Globals.upperLimitPump)
                {
                    newPumpPower = Globals.upperLimitPump;
                    stepPumpPower = Globals.upperLimitPump - lastPumpPower;
                }
                string command = "CTP 0";
                Globals.serialPort.WriteLine(command);
                Thread.Sleep(100);

                Globals.pumpPower = newPumpPower;
                command = "PP " + newPumpPower.ToString("0.00");
                Globals.serialPort.WriteLine(command);

                MessageBox.Show("Controle manual acionado e potência acionada em " + newPumpPower.ToString("0.0") + "%, foi aplicado um degrau de " + stepPumpPower.ToString("0.0") + "%.\nAguardar até que o estado estacionário seja atingido novamente.", "Início do experimento!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (selectedSystem == "Temperatura")
            {
               
                //isso é pq o stepPumpPower é o valor do txtPotenciaBomba convertido para número.
                stepResPower = stepPumpPower;

                // Obtém o índice do último elemento (Count - 1)
                int lastIndex = Globals.resPowerData.Count - 1;
                // Obtém o último elemento usando o índice
                double lastResPower = Globals.resPowerData[lastIndex];
                // Calcula o novo valor de resPower
                double newResPower = lastResPower + stepResPower;

                // Verifica se o novo valor é menor que 0 e ajusta para 0
                if (newResPower < Globals.lowerLimitRes)
                {
                    newResPower = Globals.lowerLimitRes;
                    stepResPower = -lastResPower;
                }
                // Verifica se o novo valor é maior que 100 e ajusta para 100
                else if (newResPower > Globals.upperLimitRes)
                {
                    newResPower = Globals.upperLimitRes;

                    stepResPower = Globals.upperLimitRes-lastResPower;
                }
                string command = "CTR 0";
                Globals.serialPort.WriteLine(command);
                Thread.Sleep(100);

                Globals.resPower = newResPower;
                command = "RP " + newResPower.ToString("0.00");
                Globals.serialPort.WriteLine(command);

                MessageBox.Show("Controle manual acionado e potência acionada em " + newResPower.ToString("0.0") + "%, foi aplicado um degrau de " + stepResPower.ToString("0.0") + "%.\nAguardar até que o estado estacionário seja atingido novamente.", "Início do experimento!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (selectedSystem == "Sensor de Temperatura")
            {
                MessageBox.Show("Coleta de dados iniciada. Aguardar até que o estado estacionário seja atingido.", "Início do experimento!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            /* INICIAR ARMAZENAMENTO DOS DADOS DO EXPERIMENTO */

            numIdentification++;
            experimentRunning = true;
        }

        private void SubFormAutoTuningFOPTD_Load(object sender, EventArgs e)
        {

        }

        public static double CalculateRMSE(List<double> yModel, List<double> yExp)
        {
            if (yModel.Count != yExp.Count)
            {
                throw new ArgumentException("As listas devem ter o mesmo número de elementos.");
            }

            int n = yModel.Count;

            double sumOfSquaredDifferences = yModel.Zip(yExp, (m, e) => Math.Pow(m - e, 2)).Sum();
            double rmse = Math.Sqrt(sumOfSquaredDifferences / n);

            return rmse;
        }
        private void AutoTuningFOPTDDataHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (selectedSystem == "Vazão")
            {
                if (!IsDisposed && InvokeRequired)
                {
                    try
                    {
                        // Invoca o método novamente na thread da UI principal
                        BeginInvoke(new MethodInvoker(() => txtPotenciaInicial.Text = Globals.pumpPowerData.Last().ToString("0.00")));
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
                    try
                    {
                        // Invoca o método novamente na thread da UI princip
                        txtPotenciaInicial.Text = Globals.pumpPowerData.Last().ToString("0.00");
                    }
                    catch (ObjectDisposedException)
                    {
                        // Trate a exceção ObjectDisposedException, se necessário
                        // ou apenas retorne do método
                        return;
                    }
                }
            }
            if (selectedSystem == "Temperatura")
            {
                if (!IsDisposed && InvokeRequired)
                {
                    try
                    {
                        // Invoca o método novamente na thread da UI principal
                        BeginInvoke(new MethodInvoker(() => txtPotenciaInicial.Text = Globals.resPowerData.Last().ToString("0.00")));
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
                    try
                    {
                        // Invoca o método novamente na thread da UI princip
                        txtPotenciaInicial.Text = Globals.resPowerData.Last().ToString("0.00");
                    }
                    catch (ObjectDisposedException)
                    {
                        // Trate a exceção ObjectDisposedException, se necessário
                        // ou apenas retorne do método
                        return;
                    }
                }
            }
            if (selectedSystem == "Sensor de Temperatura")
            {
                if (!IsDisposed && InvokeRequired)
                {
                    try
                    {
                        // Invoca o método novamente na thread da UI principal
                        BeginInvoke(new MethodInvoker(() => txtPotenciaInicial.Text = Globals.tempOutData.Last().ToString("0.00")));
                        BeginInvoke(new MethodInvoker(() => txtPotenciaBomba.Text = (Globals.tempOutData.Last()-initialTemp).ToString("0.00")));

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
                    try
                    {
                        // Invoca o método novamente na thread da UI princip
                        txtPotenciaInicial.Text = Globals.tempOutData.Last().ToString("0.00");
                        txtPotenciaBomba.Text = (Globals.tempOutData.Last() - initialTemp).ToString("0.00");
                    }
                    catch (ObjectDisposedException)
                    {
                        // Trate a exceção ObjectDisposedException, se necessário
                        // ou apenas retorne do método
                        return;
                    }
                }
            }
            // Verificar se o experimento está em execução
            if (experimentRunning)
            {
                if (selectedSystem == "Vazão")
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

                    // Verificar se o sistema atingiu o equilíbrio na saída
                    if (HasSystemReachedEquilibrium(flowExp) && messageEquilibriumShown == false)
                    {
                        // O sistema atingiu o equilíbrio, você pode fazer alguma ação aqui
                        try
                        {
                            // Invoca o método novamente na thread da UI principal
                            BeginInvoke(new MethodInvoker(() =>lblEquilibrium.Visible = true));
                        }
                        catch (ObjectDisposedException)
                        {
                            // Trate a exceção ObjectDisposedException, se necessário
                            // ou apenas retorne do método
                            return;
                        }
                        messageEquilibriumShown = true;
                    }
                }

                else if (selectedSystem == "Temperatura")
                {
                    double timeData;
                    double tempData;
                    
                    lock (Globals.timeTempData) // Bloqueia o acesso à lista Globals.timeTempOutData
                    {
                        // Obter o valor mais recente de Globals.timeTempOutData
                        if (Globals.timeTempData.Count > 0)
                        {
                            timeData = Globals.timeTempData[Globals.timeTempData.Count - 1];
                        }
                        else
                        {
                            // Se a lista estiver vazia, atribuir um valor padrão
                            timeData = 0.0;
                        }
                    }

                    lock (Globals.tempOutData) // Bloqueia o acesso à lista Globals.tempOutData
                    {
                        // Obter o valor mais recente de Globals.tempOutData
                        if (Globals.tempOutData.Count > 0)
                        {
                            tempData = Globals.tempOutData[Globals.tempOutData.Count - 1];
                        }
                        else
                        {
                            // Se a lista estiver vazia, atribuir um valor padrão
                            tempData = 0.0;
                        }
                    }

                    // Se o initialTime ainda não foi definido, atribua o valor do primeiro dado de tempo recebido.
                    if (initialTime == 0.0)
                    {
                        initialTime = timeData;
                        initialTemp = tempData;
                    }

                    // Adicionar o tempo relativo ao initialTime às listas timeExp e flowExp
                    timeExp.Add(timeData - initialTime);
                    tempExp.Add(tempData - initialTemp);

                    // Verificar se o sistema atingiu o equilíbrio na saída
                    if (HasSystemReachedEquilibrium(tempExp) && messageEquilibriumShown == false)
                    {
                        // O sistema atingiu o equilíbrio, você pode fazer alguma ação aqui
                        try
                        {
                            // Invoca o método novamente na thread da UI principal
                            BeginInvoke(new MethodInvoker(() => lblEquilibrium.Visible = true));
                        }
                        catch (ObjectDisposedException)
                        {
                            // Trate a exceção ObjectDisposedException, se necessário
                            // ou apenas retorne do método
                            return;
                        }
                        messageEquilibriumShown = true;
                    }
                }
                else if (selectedSystem == "Sensor de Temperatura")
                {
                    double timeData;
                    double tempData;

                    lock (Globals.timeTempData) // Bloqueia o acesso à lista Globals.timeTempOutData
                    {
                        // Obter o valor mais recente de Globals.timeTempOutData
                        if (Globals.timeTempData.Count > 0)
                        {
                            timeData = Globals.timeTempData[Globals.timeTempData.Count - 1];
                        }
                        else
                        {
                            // Se a lista estiver vazia, atribuir um valor padrão
                            timeData = 0.0;
                        }
                    }

                    lock (Globals.tempOutData) // Bloqueia o acesso à lista Globals.tempOutData
                    {
                        // Obter o valor mais recente de Globals.tempOutData
                        if (Globals.tempOutData.Count > 0)
                        {
                            tempData = Globals.tempOutData[Globals.tempOutData.Count - 1];
                        }
                        else
                        {
                            // Se a lista estiver vazia, atribuir um valor padrão
                            tempData = 0.0;
                        }
                    }

                    // Se o initialTime ainda não foi definido, atribua o valor do primeiro dado de tempo recebido.
                    if (initialTime == 0.0)
                    {
                        initialTime = timeData;
                        initialTemp = tempData;
                    }

                    // Adicionar o tempo relativo ao initialTime às listas timeExp e flowExp
                    timeExp.Add(timeData - initialTime);
                    tempExp.Add(tempData - initialTemp);

                    // Verificar se o sistema atingiu o equilíbrio na saída
                    if (HasSystemReachedEquilibrium(tempExp) && messageEquilibriumShown == false)
                    {
                        // O sistema atingiu o equilíbrio, você pode fazer alguma ação aqui
                        try
                        {
                            // Invoca o método novamente na thread da UI principal
                            BeginInvoke(new MethodInvoker(() => lblEquilibrium.Visible = true));
                        }
                        catch (ObjectDisposedException)
                        {
                            // Trate a exceção ObjectDisposedException, se necessário
                            // ou apenas retorne do método
                            return;
                        }
                        messageEquilibriumShown = true;
                    }
                }
            }
        }

        private double CalcularPuMetodoNewton(double theta, double tau)
        {
            double PuLowerBound = 0.1;
            double PuUpperBound = 4 * theta - 0.01;
            double Pu = (PuLowerBound + PuUpperBound) / 2;
            double tolerance = 0.0001;
            int maxIterations = 300;
            int iteration = 0;
            double lastPu = 0;

            while (iteration < maxIterations)
            {
                double calculatedTau = Pu * Math.Tan(Math.PI * (Pu - 2 * theta) / Pu) / (2 * Math.PI);

                double delta = 0.001; // Pequena variação de Pu
                double derivative = (calculatedTau - (Pu - delta) * Math.Tan(Math.PI * ((Pu - delta) - 2 * theta) / (Pu - delta)) / (2 * Math.PI)) / delta;

                // Armazena o valor atual de Pu antes de atualizá-lo
                lastPu = Pu;

                // Atualiza Pu usando o método de Newton
                Pu = Pu - (calculatedTau - tau) / derivative;

                // Verifica se a diferença entre o tau calculado e o valor desejado é menor que a tolerância
                if (Math.Abs(calculatedTau - tau) < tolerance)
                {
                    return Pu; // Convergência atingida, retorne o valor de Pu
                }

                // Verifica se Pu está dentro dos limites
                if (Pu >= PuUpperBound)
                {
                    Pu = PuUpperBound;
                }
                else if (Pu <= PuLowerBound)
                {
                    Pu = PuLowerBound;
                }

                iteration++;
            }

            return -1; // Retorna um valor negativo para indicar que a convergência não foi atingida
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            lblEquilibrium.Visible = false;
            if (!experimentRunning)
            {
                MessageBox.Show("Nenhum experimento está rodando no momento! Clique em Iniciar!","Atenção!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            experimentRunning = false;
            messageEquilibriumShown = false;
            sp.Plot.Clear();
            double optimalK_process = 0;
            double optimalLag_process = 0;
            double optimalTimeConstant_process = 0;
            if (selectedSystem == "Vazão")
            {

                string command = "PP 0";
                Globals.serialPort.WriteLine(command);

                // Chute inicial para as variáveis de decisão
                Vector<double> initialGuess = DenseVector.OfArray(new double[] { 1.0, 1.0, 1.0 });

                // Definir os limites inferior e superior para as variáveis de decisão
                ///////////////////////////////////////////////////////////////K  THETA   TAU
                Vector<double> lowerBound = DenseVector.OfArray(new double[] { 0, (double)Globals.intervalSampling/750, 0.1 });
                Vector<double> upperBound = DenseVector.OfArray(new double[] { 3, 5, 50 });

                // Resolver o problema de otimização usando o Particle Swarm Optimization
                var optimizer = new ParticleSwarmOptimizer();

                optimalK_process = lowerBound[0];
                optimalLag_process = lowerBound[1];
                optimalTimeConstant_process = lowerBound[2];
             
                if (residualType == 0)
                {
                    var result = optimizer.FindMinimum(ObjectiveFunctionPump, lowerBound, upperBound);
                    optimalK_process = result[0];
                    optimalLag_process = result[1];
                    optimalTimeConstant_process = result[2];
                }
                else
                {
                    var result = optimizer.FindMinimum(ObjectiveFunctionPumpAbsolute, lowerBound, upperBound);
                    optimalK_process = result[0];
                    optimalLag_process = result[1];
                    optimalTimeConstant_process = result[2];
                }
                
            }
            if (selectedSystem == "Temperatura")
            {
                string command = "RP 0";
                Globals.serialPort.WriteLine(command);
                // Chute inicial para as variáveis de decisão
                Vector<double> initialGuess = DenseVector.OfArray(new double[] { 0.1, 15, 500 });

                // Definir os limites inferior e superior para as variáveis de decisão
                ///////////////////////////////////////////////////////////////K  THETA   TAU
                Vector<double> lowerBound = DenseVector.OfArray(new double[] { 0, 1, 100 });
                Vector<double> upperBound = DenseVector.OfArray(new double[] { 1, 20, 1000 });

                // Resolver o problema de otimização usando o Particle Swarm Optimization
                var optimizer = new ParticleSwarmOptimizer();

                optimalK_process = lowerBound[0];
                optimalLag_process = lowerBound[1];
                optimalTimeConstant_process = lowerBound[2];
                if (residualType == 0)
                {
                    var result = optimizer.FindMinimum(ObjectiveFunctionRes, lowerBound, upperBound);
                    optimalK_process = result[0];
                    optimalLag_process = result[1];
                    optimalTimeConstant_process = result[2];
                }
                else
                {
                    var result = optimizer.FindMinimum(ObjectiveFunctionResAbsolute, lowerBound, upperBound);
                    optimalK_process = result[0];
                    optimalLag_process = result[1];
                    optimalTimeConstant_process = result[2];
                }
            }
            if (selectedSystem == "Sensor de Temperatura")
            {
                // Chute inicial para as variáveis de decisão
                Vector<double> initialGuess = DenseVector.OfArray(new double[] { 1, 1, 1 });
                stepResPower = Convert.ToDouble(txtPotenciaInicial.Text) - initialTemp;
                // Definir os limites inferior e superior para as variáveis de decisão
                ///////////////////////////////////////////////////////////////K  THETA   TAU
                Vector<double> lowerBound = DenseVector.OfArray(new double[] { 1, 0.5, 0.5 });
                Vector<double> upperBound = DenseVector.OfArray(new double[] { 1, 30, 30 });

                // Resolver o problema de otimização usando o Particle Swarm Optimization
                var optimizer = new ParticleSwarmOptimizer();

                optimalK_process = lowerBound[0];
                optimalLag_process = lowerBound[1];
                optimalTimeConstant_process = lowerBound[2];
                if (residualType == 0)
                {
                    var result = optimizer.FindMinimum(ObjectiveFunctionRes, lowerBound, upperBound);
                    optimalK_process = result[0];
                    optimalLag_process = result[1];
                    optimalTimeConstant_process = result[2];
                }
                else
                {
                    var result = optimizer.FindMinimum(ObjectiveFunctionResAbsolute, lowerBound, upperBound);
                    optimalK_process = result[0];
                    optimalLag_process = result[1];
                    optimalTimeConstant_process = result[2];
                }
            }

            // Verificar se a otimização foi bem-sucedida


            string message = "Valores ótimos encontrados:\n"
                             + "Ganho do processo (Kp) [L/% h]: " + optimalK_process.ToString("0.00") + "\n"
                             + "Atraso (theta) [s]: " + optimalLag_process.ToString("0.00") + "\n"
                             + "Constante de tempo (tau) [s]: " + optimalTimeConstant_process.ToString("0.00");


            MessageBox.Show(message, "Resultados da Otimização", MessageBoxButtons.OK, MessageBoxIcon.Information);
            double RSquared =0;
            if (selectedSystem == "Vazão")
            {

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

                RSquared = GoodnessOfFit.RSquared(flowExp, flowModel);
                // Plotar os pontos da série flowExp
                sp.Plot.AddScatter(timeExp.ToArray(), flowModel, label: "Desvio da Vazão Modelada", markerShape: MarkerShape.filledCircle, markerSize: 0, lineWidth: 1);

                // Configurar o gráfico com rótulos, título e legenda

                sp.Plot.XLabel("Tempo");
                sp.Plot.YLabel("Vazão");
                sp.Plot.Title("Gráfico de Vazão Modelada em FOPTD");
            }

            else if (selectedSystem == "Temperatura" || selectedSystem == "Sensor de Temperatura")
            {
                // Plotar os pontos da série tempExp
                sp.Plot.AddScatter(timeExp.ToArray(), tempExp.ToArray(), label: "Desvio da Vazão Experimental", markerShape: MarkerShape.filledCircle, markerSize: 5, lineWidth: 0);

                // Plotar a linha representando a série flowModel
                double[] tempModel = new double[timeExp.Count];
                for (int i = 0; i < timeExp.Count; i++)
                {
                    if (timeExp[i] >= optimalLag_process)
                    {
                        tempModel[i] = optimalK_process * stepResPower * (1 - Math.Exp(-(timeExp[i] - optimalLag_process) / optimalTimeConstant_process));
                    }
                    else
                    {
                        tempModel[i] = 0;
                    }
                }


                RSquared = GoodnessOfFit.RSquared(tempExp, tempModel);
                // Plotar os pontos da série tempExp
                sp.Plot.AddScatter(timeExp.ToArray(), tempModel, label: "Desvio da Temperatura Modelada", markerShape: MarkerShape.filledCircle, markerSize: 0, lineWidth: 1);

                // Configurar o gráfico com rótulos, título e legenda

                sp.Plot.XLabel("Tempo");
                sp.Plot.YLabel("Temperatura");
                sp.Plot.Title("Gráfico de Temperatura Modelada em FOPTD");
            }

            sp.Plot.Legend();
            sp.Plot.Render();
            sp.Refresh();

            double Kp = optimalK_process;
            double theta = optimalLag_process;
            double tau = optimalTimeConstant_process;
            tabela.Rows.Add(numIdentification.ToString("0"),
                             Kp.ToString("0.000"),
                             tau.ToString("0.000"),
                             theta.ToString("0.000"),
                             RSquared.ToString("0.000"));

            tabelaControle.Rows.Add("Sintonia ID " + (tabela.Rows.Count - 1).ToString("0"), "-",
                             "-",
                             "-");
            if(selectedSystem == "Sensor de Temperatura")
            {
                return;
            }

            double Kc;
            double tauI;
            double tauD;
            double tauC;

            double Pu = CalcularPuMetodoNewton(theta, tau);
            double Kcu = Math.Sqrt(1 + Math.Pow((2 * Math.PI * tau / Pu), 2));
            Console.WriteLine("Pu: " + Pu + " Kcu:" + Kcu);

            Kc = 0.5 * Kcu;
            tauI = 0;
            tauD = 0;
            tabelaControle.Rows.Add("ZN P", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));

            Kc = 0.45 * Kcu;
            tauI = Pu / 1.2;
            tauD = 0;
            tabelaControle.Rows.Add("ZN PI", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));


            Kc = 0.6 * Kcu;
            tauI = Pu / 2;
            tauD = Pu / 8;
            tabelaControle.Rows.Add("ZN PID", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));

            tauC = tau;
            Kc = tau / ((tauC + theta) * Kp);
            tauI = Math.Min(tau, 4 * (tauC + theta));
            tauD = 0;
            tabelaControle.Rows.Add("SIMC PI τc = τ", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));

            tauC = theta;
            Kc = tau / ((tauC + theta) * Kp);
            tauI = Math.Min(tau, 4 * (tauC + theta));
            tauD = 0;
            tabelaControle.Rows.Add("SIMC PI τc = θ", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));


            tauC = tau;
            Kc = (tau + theta / 2) / ((tauC + theta / 2) * Kp);
            tauI = tau + theta / 2;
            tauD = (tau * theta) / (2 * tau + theta);
            tabelaControle.Rows.Add("IMC PID τc = τ", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));

            tauC = theta;
            Kc = (tau + theta / 2) / ((tauC + theta / 2) * Kp);
            tauI = tau + theta / 2;
            tauD = (tau * theta) / (2 * tau + theta);
            tabelaControle.Rows.Add("IMC PID τc = θ", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));


            Kc = (0.15 / Kp) + (tau / (Kp * theta)) * (0.35 - (theta * tau / ((theta + tau) * (theta + tau))));
            tauI = 0.35 * theta + 13 * theta * tau * tau / (tau * tau + 12 * theta * tau + 7 * theta * theta);
            tauD = 0;
            tabelaControle.Rows.Add("AMIGO PI", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));

            Kc = (0.25 + 0.45 * tau / theta) / Kp;
            tauI = (0.4 * theta + 0.8 * tau) * theta / (theta + 0.1 * tau);
            tauD = (0.5 * theta * tau) / (0.3 * theta + tau);
            tabelaControle.Rows.Add("AMIGO PID", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));

        }

        // Restante do código...


        public double ObjectiveFunctionPumpAbsolute(Vector<double> v)
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
                double diffAbs = Math.Abs(flowExp[i] - flowModel_k);
                objectiveTerm += diffAbs;
                //MessageBox.Show("t: " + timeExp[i] + "\ni: " + i + "\ntau: " + timeconstant_process + "\ntheta: " + lag_process + "\nK: " + K_process + "\nstep: " + stepPumpPower + "\nflowModel: " + flowModel_k);
            }

            return objectiveTerm;
        }

        public double ObjectiveFunctionPump(Vector<double> v)
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

        public double ObjectiveFunctionRes(Vector<double> v)
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
                    flowModel_k = K_process * stepResPower * (1 - Math.Exp(-(timeExp[i] - lag_process) / timeconstant_process));
                }
                double diffSquared = (tempExp[i] - flowModel_k) * (tempExp[i] - flowModel_k);
                objectiveTerm += diffSquared;
                //MessageBox.Show("t: " + timeExp[i] + "\ni: " + i + "\ntau: " + timeconstant_process + "\ntheta: " + lag_process + "\nK: " + K_process + "\nstep: " + stepPumpPower + "\nflowModel: " + flowModel_k);
            }

            return objectiveTerm;
        }

        public double ObjectiveFunctionSensorTemp(Vector<double> v)
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
                    flowModel_k = K_process * stepResPower * (1 - Math.Exp(-(timeExp[i] - lag_process) / timeconstant_process));
                }
                double diffSquared = (tempExp[i] - flowModel_k) * (tempExp[i] - flowModel_k);
                objectiveTerm += diffSquared;
                //MessageBox.Show("t: " + timeExp[i] + "\ni: " + i + "\ntau: " + timeconstant_process + "\ntheta: " + lag_process + "\nK: " + K_process + "\nstep: " + stepPumpPower + "\nflowModel: " + flowModel_k);
            }

            return objectiveTerm;
        }

        public double ObjectiveFunctionResAbsolute(Vector<double> v)
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
                    flowModel_k = K_process * stepResPower * (1 - Math.Exp(-(timeExp[i] - lag_process) / timeconstant_process));
                }
                double diffAbs = Math.Abs(tempExp[i] - flowModel_k);
                objectiveTerm += diffAbs;
                //MessageBox.Show("t: " + timeExp[i] + "\ni: " + i + "\ntau: " + timeconstant_process + "\ntheta: " + lag_process + "\nK: " + K_process + "\nstep: " + stepPumpPower + "\nflowModel: " + flowModel_k);
            }

            return objectiveTerm;
        }

        private void tabela_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void tabela_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a edição foi realizada na terceira coluna (índice 2) e se é uma nova linha
            if (e.ColumnIndex == 3 && e.RowIndex == tabela.NewRowIndex-1)
            {
                // Verifica se todas as três colunas foram preenchidas
                if (tabela.Rows[tabela.NewRowIndex - 1].Cells[0].Value != null &&
                    tabela.Rows[tabela.NewRowIndex - 1].Cells[1].Value != null &&
                    tabela.Rows[tabela.NewRowIndex - 1].Cells[2].Value != null &&
                    tabela.Rows[tabela.NewRowIndex - 1].Cells[3].Value != null)
                {
                    // Recupera os valores das células da nova linha e realiza a conversão
                    if (double.TryParse(tabela.Rows[tabela.NewRowIndex - 1].Cells[1].Value.ToString(), out double Kp) &&
                        double.TryParse(tabela.Rows[tabela.NewRowIndex - 1].Cells[2].Value.ToString(), out double tau) &&
                        double.TryParse(tabela.Rows[tabela.NewRowIndex - 1].Cells[3].Value.ToString(), out double theta))
                    {
                        tabelaControle.Rows.Add("Sintonia ID " + (tabela.Rows.Count - 1).ToString("0"), "-",
                             "-",
                             "-");

                        double Kc;
                        double tauI;
                        double tauD;
                        double tauC;

                        double Pu = CalcularPuMetodoNewton(theta, tau);
                        double Kcu = Math.Sqrt(1 + Math.Pow((2 * Math.PI * tau / Pu), 2));
                        Console.WriteLine("Pu: " + Pu + " Kcu:" + Kcu);

                        Kc = 0.5 * Kcu;
                        tauI = 0;
                        tauD = 0;
                        tabelaControle.Rows.Add("ZN P", Kc.ToString("0.00"),
                                         tauI.ToString("0.00"),
                                         tauD.ToString("0.00"));

                        Kc = 0.45 * Kcu;
                        tauI = Pu / 1.2;
                        tauD = 0;
                        tabelaControle.Rows.Add("ZN PI", Kc.ToString("0.00"),
                                         tauI.ToString("0.00"),
                                         tauD.ToString("0.00"));


                        Kc = 0.6 * Kcu;
                        tauI = Pu / 2;
                        tauD = Pu / 8;
                        tabelaControle.Rows.Add("ZN PID", Kc.ToString("0.00"),
                                         tauI.ToString("0.00"),
                                         tauD.ToString("0.00"));

                        tauC = tau;
                        Kc = tau / ((tauC + theta) * Kp);
                        tauI = Math.Min(tau, 4 * (tauC + theta));
                        tauD = 0;
                        tabelaControle.Rows.Add("SIMC PI τc = τ", Kc.ToString("0.00"),
                                         tauI.ToString("0.00"),
                                         tauD.ToString("0.00"));

                        tauC = theta;
                        Kc = tau / ((tauC + theta) * Kp);
                        tauI = Math.Min(tau, 4 * (tauC + theta));
                        tauD = 0;
                        tabelaControle.Rows.Add("SIMC PI τc = θ", Kc.ToString("0.00"),
                                         tauI.ToString("0.00"),
                                         tauD.ToString("0.00"));


                        tauC = tau;
                        Kc = (tau + theta / 2) / ((tauC + theta / 2) * Kp);
                        tauI = tau + theta / 2;
                        tauD = (tau * theta) / (2 * tau + theta);
                        tabelaControle.Rows.Add("IMC PID τc = τ", Kc.ToString("0.00"),
                                         tauI.ToString("0.00"),
                                         tauD.ToString("0.00"));

                        tauC = theta;
                        Kc = (tau + theta / 2) / ((tauC + theta / 2) * Kp);
                        tauI = tau + theta / 2;
                        tauD = (tau * theta) / (2 * tau + theta);
                        tabelaControle.Rows.Add("IMC PID τc = θ", Kc.ToString("0.00"),
                                         tauI.ToString("0.00"),
                                         tauD.ToString("0.00"));


                        Kc = (0.15 / Kp) + (tau / (Kp * theta)) * (0.35 - (theta * tau / ((theta + tau) * (theta + tau))));
                        tauI = 0.35 * theta + 13 * theta * tau * tau / (tau * tau + 12 * theta * tau + 7 * theta * theta);
                        tauD = 0;
                        tabelaControle.Rows.Add("AMIGO PI", Kc.ToString("0.00"),
                                         tauI.ToString("0.00"),
                                         tauD.ToString("0.00"));

                        Kc = (0.25 + 0.45 * tau / theta) / Kp;
                        tauI = (0.4 * theta + 0.8 * tau) * theta / (theta + 0.1 * tau);
                        tauD = (0.5 * theta * tau) / (0.3 * theta + tau);
                        tabelaControle.Rows.Add("AMIGO PID", Kc.ToString("0.00"),
                                         tauI.ToString("0.00"),
                                         tauD.ToString("0.00"));
                    }
                    else
                    {
                        // Alguns valores não são numéricos, lide com isso de acordo com sua lógica
                        MessageBox.Show("Os valores de Kp, theta e tau devem ser números válidos.", "Erro de conversão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // A nova linha não foi totalmente preenchida, lide com isso de acordo com sua lógica
                    MessageBox.Show("Preencha todas as três colunas na nova linha.", "Dados incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Adiciona três novas linhas ao DataGridView "tabelaControle"
                
            }
        }

        private void sp_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem)
            {
                case "Vazão":
                    lblDegrau.Text = "Degrau da Potência da Bomba";
                    lblPotenciaInicial.Text = "Potência da Bomba Inicial";
                    selectedSystem = comboBox1.SelectedItem.ToString();
                    tabela.Columns[1].HeaderText = "Kp [L/% h]";
                    tabelaControle.Columns[1].HeaderText = "Kc [% h/L]";
                    tabelaControle.Columns[2].HeaderText = "τI [s]";
                    tabelaControle.Columns[3].HeaderText = "τD [s]";
                    txtPotenciaBomba.ReadOnly = false;
                    break;
                case "Temperatura":
                    lblDegrau.Text = "Degrau da Potência da Res.";
                    lblPotenciaInicial.Text = "Potência da Resistência Inicial";
                    selectedSystem = comboBox1.SelectedItem.ToString();
                    tabela.Columns[1].HeaderText = "Kp [°C/%]";
                    tabelaControle.Columns[1].HeaderText = "Kc [%/°C]";
                    tabelaControle.Columns[2].HeaderText = "τI [s]";
                    tabelaControle.Columns[3].HeaderText = "τD [s]";
                    txtPotenciaBomba.ReadOnly = false;
                    break;
                case "Sensor de Temperatura":
                    lblDegrau.Text = "Variação de Temperatura";
                    lblPotenciaInicial.Text = "Temperatura Final (°C)";
                    selectedSystem = comboBox1.SelectedItem.ToString();
                    tabela.Columns[1].HeaderText = "Kp [°C/°C]";
                    tabelaControle.Columns[1].HeaderText = "-";
                    tabelaControle.Columns[2].HeaderText = "-";
                    tabelaControle.Columns[3].HeaderText = "-";
                    txtPotenciaBomba.ReadOnly = true;
                    break;
            }
        }

        private void txtPotenciaInicial_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbResidualType_SelectedIndexChanged(object sender, EventArgs e)
        {
            residualType = cbResidualType.SelectedIndex;
        }

        private void btnReotimizar_Click(object sender, EventArgs e)
        {
            if (timeExp.Count == 0)
            {
                MessageBox.Show("Não há dados armazenados para realizar a otimização! Inicie um experimento!", "Não há dados!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sp.Plot.Clear();
            double optimalK_process = 0;
            double optimalLag_process = 0;
            double optimalTimeConstant_process = 0;
            if (selectedSystem == "Vazão")
            {

                string command = "PP 0";
                Globals.serialPort.WriteLine(command);

                // Chute inicial para as variáveis de decisão
                Vector<double> initialGuess = DenseVector.OfArray(new double[] { 1.0, 1.0, 1.0 });

                // Definir os limites inferior e superior para as variáveis de decisão
                ///////////////////////////////////////////////////////////////K  THETA   TAU
                Vector<double> lowerBound = DenseVector.OfArray(new double[] { 0, (double)Globals.intervalSampling / 750, 0.1 });
                Vector<double> upperBound = DenseVector.OfArray(new double[] { 3, 5, 50 });

                // Resolver o problema de otimização usando o Particle Swarm Optimization
                var optimizer = new ParticleSwarmOptimizer();

                optimalK_process = lowerBound[0];
                optimalLag_process = lowerBound[1];
                optimalTimeConstant_process = lowerBound[2];

                if (residualType == 0)
                {
                    var result = optimizer.FindMinimum(ObjectiveFunctionPump, lowerBound, upperBound);
                    optimalK_process = result[0];
                    optimalLag_process = result[1];
                    optimalTimeConstant_process = result[2];
                }
                else
                {
                    var result = optimizer.FindMinimum(ObjectiveFunctionPumpAbsolute, lowerBound, upperBound);
                    optimalK_process = result[0];
                    optimalLag_process = result[1];
                    optimalTimeConstant_process = result[2];
                }

            }
            if (selectedSystem == "Temperatura")
            {
                string command = "RP 0";
                Globals.serialPort.WriteLine(command);
                // Chute inicial para as variáveis de decisão
                Vector<double> initialGuess = DenseVector.OfArray(new double[] { 0.1, 15, 500 });

                // Definir os limites inferior e superior para as variáveis de decisão
                ///////////////////////////////////////////////////////////////K  THETA   TAU
                Vector<double> lowerBound = DenseVector.OfArray(new double[] { 0, 1, 100 });
                Vector<double> upperBound = DenseVector.OfArray(new double[] { 1, 20, 1000 });

                // Resolver o problema de otimização usando o Particle Swarm Optimization
                var optimizer = new ParticleSwarmOptimizer();

                optimalK_process = lowerBound[0];
                optimalLag_process = lowerBound[1];
                optimalTimeConstant_process = lowerBound[2];
                if (residualType == 0)
                {
                    var result = optimizer.FindMinimum(ObjectiveFunctionRes, lowerBound, upperBound);
                    optimalK_process = result[0];
                    optimalLag_process = result[1];
                    optimalTimeConstant_process = result[2];
                }
                else
                {
                    var result = optimizer.FindMinimum(ObjectiveFunctionResAbsolute, lowerBound, upperBound);
                    optimalK_process = result[0];
                    optimalLag_process = result[1];
                    optimalTimeConstant_process = result[2];
                }
            }
            if (selectedSystem == "Sensor de Temperatura")
            {
                // Chute inicial para as variáveis de decisão
                Vector<double> initialGuess = DenseVector.OfArray(new double[] { 1, 1, 1 });
                stepResPower = Convert.ToDouble(txtPotenciaInicial.Text) - initialTemp;
                // Definir os limites inferior e superior para as variáveis de decisão
                ///////////////////////////////////////////////////////////////K  THETA   TAU
                Vector<double> lowerBound = DenseVector.OfArray(new double[] { 1, 0.5, 0.5 });
                Vector<double> upperBound = DenseVector.OfArray(new double[] { 1, 30, 30 });

                // Resolver o problema de otimização usando o Particle Swarm Optimization
                var optimizer = new ParticleSwarmOptimizer();

                optimalK_process = lowerBound[0];
                optimalLag_process = lowerBound[1];
                optimalTimeConstant_process = lowerBound[2];
                if (residualType == 0)
                {
                    var result = optimizer.FindMinimum(ObjectiveFunctionRes, lowerBound, upperBound);
                    optimalK_process = result[0];
                    optimalLag_process = result[1];
                    optimalTimeConstant_process = result[2];
                }
                else
                {
                    var result = optimizer.FindMinimum(ObjectiveFunctionResAbsolute, lowerBound, upperBound);
                    optimalK_process = result[0];
                    optimalLag_process = result[1];
                    optimalTimeConstant_process = result[2];
                }
            }

            // Verificar se a otimização foi bem-sucedida


            string message = "Valores ótimos encontrados:\n"
                             + "Ganho do processo (Kp) [L/% h]: " + optimalK_process.ToString("0.00") + "\n"
                             + "Atraso (theta) [s]: " + optimalLag_process.ToString("0.00") + "\n"
                             + "Constante de tempo (tau) [s]: " + optimalTimeConstant_process.ToString("0.00");


            MessageBox.Show(message, "Resultados da Otimização", MessageBoxButtons.OK, MessageBoxIcon.Information);

            double RSquared = 0;
            if (selectedSystem == "Vazão")
            {

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

                RSquared = GoodnessOfFit.RSquared(flowExp, flowModel);
                // Plotar os pontos da série flowExp
                sp.Plot.AddScatter(timeExp.ToArray(), flowModel, label: "Desvio da Vazão Modelada", markerShape: MarkerShape.filledCircle, markerSize: 0, lineWidth: 1);

                // Configurar o gráfico com rótulos, título e legenda

                sp.Plot.XLabel("Tempo");
                sp.Plot.YLabel("Vazão");
                sp.Plot.Title("Gráfico de Vazão Modelada em FOPTD");
            }

            else if (selectedSystem == "Temperatura" || selectedSystem == "Sensor de Temperatura")
            {
                // Plotar os pontos da série tempExp
                sp.Plot.AddScatter(timeExp.ToArray(), tempExp.ToArray(), label: "Desvio da Vazão Experimental", markerShape: MarkerShape.filledCircle, markerSize: 5, lineWidth: 0);

                // Plotar a linha representando a série flowModel
                double[] tempModel = new double[timeExp.Count];
                for (int i = 0; i < timeExp.Count; i++)
                {
                    if (timeExp[i] >= optimalLag_process)
                    {
                        tempModel[i] = optimalK_process * stepResPower * (1 - Math.Exp(-(timeExp[i] - optimalLag_process) / optimalTimeConstant_process));
                    }
                    else
                    {
                        tempModel[i] = 0;
                    }
                }


                RSquared = GoodnessOfFit.RSquared(tempExp, tempModel);
                // Plotar os pontos da série tempExp
                sp.Plot.AddScatter(timeExp.ToArray(), tempModel, label: "Desvio da Temperatura Modelada", markerShape: MarkerShape.filledCircle, markerSize: 0, lineWidth: 1);

                // Configurar o gráfico com rótulos, título e legenda

                sp.Plot.XLabel("Tempo");
                sp.Plot.YLabel("Temperatura");
                sp.Plot.Title("Gráfico de Temperatura Modelada em FOPTD");
            }
            sp.Plot.Legend();
            sp.Plot.Render();
            sp.Refresh();

            double Kp = optimalK_process;
            double theta = optimalLag_process;
            double tau = optimalTimeConstant_process;
            tabela.Rows.Add(numIdentification.ToString("0") + "*",
                             Kp.ToString("0.000"),
                             tau.ToString("0.000"),
                             theta.ToString("0.000"));

            tabelaControle.Rows.Add("Ressintonia ID " + (tabela.Rows.Count - 2).ToString("0"), "-",
                             "-",
                             "-");
            if (selectedSystem == "Sensor de Temperatura")
            {
                return;
            }

            double Kc;
            double tauI;
            double tauD;
            double tauC;

            double Pu = CalcularPuMetodoNewton(theta, tau);
            double Kcu = Math.Sqrt(1 + Math.Pow((2 * Math.PI * tau / Pu), 2));
            Console.WriteLine("Pu: " + Pu + " Kcu:" + Kcu);

            Kc = 0.5 * Kcu;
            tauI = 0;
            tauD = 0;
            tabelaControle.Rows.Add("ZN P", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));

            Kc = 0.45 * Kcu;
            tauI = Pu / 1.2;
            tauD = 0;
            tabelaControle.Rows.Add("ZN PI", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));


            Kc = 0.6 * Kcu;
            tauI = Pu / 2;
            tauD = Pu / 8;
            tabelaControle.Rows.Add("ZN PID", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));

            tauC = tau;
            Kc = tau / ((tauC + theta) * Kp);
            tauI = Math.Min(tau, 4 * (tauC + theta));
            tauD = 0;
            tabelaControle.Rows.Add("SIMC PI τc = τ", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));

            tauC = theta;
            Kc = tau / ((tauC + theta) * Kp);
            tauI = Math.Min(tau, 4 * (tauC + theta));
            tauD = 0;
            tabelaControle.Rows.Add("SIMC PI τc = θ", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));


            tauC = tau;
            Kc = (tau + theta / 2) / ((tauC + theta / 2) * Kp);
            tauI = tau + theta / 2;
            tauD = (tau * theta) / (2 * tau + theta);
            tabelaControle.Rows.Add("IMC PID τc = τ", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));

            tauC = theta;
            Kc = (tau + theta / 2) / ((tauC + theta / 2) * Kp);
            tauI = tau + theta / 2;
            tauD = (tau * theta) / (2 * tau + theta);
            tabelaControle.Rows.Add("IMC PID τc = θ", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));


            Kc = (0.15 / Kp) + (tau / (Kp * theta)) * (0.35 - (theta * tau / ((theta + tau) * (theta + tau))));
            tauI = 0.35 * theta + 13 * theta * tau * tau / (tau * tau + 12 * theta * tau + 7 * theta * theta);
            tauD = 0;
            tabelaControle.Rows.Add("AMIGO PI", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));

            Kc = (0.25 + 0.45 * tau / theta) / Kp;
            tauI = (0.4 * theta + 0.8 * tau) * theta / (theta + 0.1 * tau);
            tauD = (0.5 * theta * tau) / (0.3 * theta + tau);
            tabelaControle.Rows.Add("AMIGO PID", Kc.ToString("0.00"),
                             tauI.ToString("0.00"),
                             tauD.ToString("0.00"));

        }
    }
    
}
