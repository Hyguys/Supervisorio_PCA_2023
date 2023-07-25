using MathNet.Numerics.Distributions;
using ScottPlot.Drawing.Colormaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Supervisório_PCA_2._0
{
    public partial class SubFormONOFFTuningZieglerNichols : Form
    {
        public SubFormONOFFTuningZieglerNichols()
        {
            InitializeComponent();
            txtSetpoint.Text = Convert.ToString(Globals.setpointVazao);
            txtHysteresis.Text = Convert.ToString(Globals.histereseVazao);

            Globals.serialPort.DataReceived += new SerialDataReceivedEventHandler(ONOFFTuningDataHandler);
        }

        private bool experimentRunning = false;

        private List<double> timeExp = new List<double>();
        private List<double> flowExp = new List<double>();
        private List<double> tempExp = new List<double>();

        private List<double> amplitudes = new List<double>();
        private List<double> periods = new List<double>();

        private string selectedSystem = "Vazão";

        private double period = 0;
        private double amplitude = 0;

        private int numPointsToAverageAmplitudePeriod = 5;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubFormONOFFTuningZieglerNichols_Load(object sender, EventArgs e)
        {

        }

        private void txtSetpointVazao_TextChanged(object sender, EventArgs e)
        {



        }


        private void txtSetpointVazao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            if (Globals.serialConnected == false || Globals.serialPort == null)
            {
                MessageBox.Show("Não há uma porta serial conectada.", "Porta serial não conectada!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedSystem == "Vazão")
            { 
             

                if (!float.TryParse(txtSetpoint.Text, out float setpointVazao) || setpointVazao < 0 || setpointVazao > 80)
                {
                    MessageBox.Show("Digite um valor decimal entre 0 e 80.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSetpoint.Text = Globals.setpointVazao.ToString("0.00");
                    return;
                }

                Globals.setpointVazao = setpointVazao;


                string command = "SPF " + setpointVazao.ToString("0.00");
                Globals.serialPort.WriteLine(command);
                MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (selectedSystem == "Temperatura")
            { 

                if (!float.TryParse(txtSetpoint.Text, out float setpointTemp) || setpointTemp < 0 || setpointTemp > 50)
                {
                    MessageBox.Show("Digite um valor decimal entre 0 e 50.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSetpoint.Text = Globals.setpointTemp.ToString("0.00");
                    return;
                }

                Globals.setpointTemp = setpointTemp;
                string command = "SPT " + setpointTemp.ToString("0.00");
                Globals.serialPort.WriteLine(command);
                MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtHysteresisVazao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHysteresisVazao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            if (Globals.serialConnected == false || Globals.serialPort == null)
            {
                MessageBox.Show("Não há uma porta serial conectada.", "Porta serial não conectada!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(selectedSystem == "Vazão")
            { 
                if (!float.TryParse(txtHysteresis.Text, out float histereseVazao) || histereseVazao < 0 || histereseVazao > 50)
                {
                    MessageBox.Show("Digite um valor decimal entre 0 e 50.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHysteresis.Text = Globals.histereseVazao.ToString("0.00");
                    return;
                }

                Globals.histereseVazao = histereseVazao;
                string command = "HF " + histereseVazao.ToString("0.00");
                Globals.serialPort.WriteLine(command);
                MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (selectedSystem == "Temperatura")
            {
                if (!float.TryParse(txtHysteresis.Text, out float histereseTemp) || histereseTemp < 0 || histereseTemp > 10)
                {
                    MessageBox.Show("Digite um valor decimal entre 0 e 10.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHysteresis.Text = Globals.histereseVazao.ToString("0.00");
                    return;
                }

                Globals.histereseTemp = histereseTemp;
                string command = "HT " + histereseTemp.ToString("0.00");
                Globals.serialPort.WriteLine(command);
                MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnVazao_Click(object sender, EventArgs e)
        {
            if (Globals.serialConnected == false || Globals.serialPort == null)
            {
                MessageBox.Show("Não há uma porta serial conectada.", "Porta serial não conectada!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedSystem == "Vazão")
            {

                string command = "CTP 1";
                Globals.serialPort.WriteLine(command);

                MessageBox.Show("Comando " + command + " enviado com sucesso.\n" +
                     "Controle on-off (liga-desliga) iniciado com os seguintes parâmetros:\n" +
                     "Setpoint da vazão: " + Globals.setpointVazao + " L/h\n" +
                     "Banda de histerese: " + Globals.histereseVazao + " L/h\n",
                     "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Globals.showHysteresisVazao = true;
                Globals.showSPVazao = true;
            }
            else if (selectedSystem == "Temperatura")
            {
                string command = "CTR 1";
                Globals.serialPort.WriteLine(command);

                MessageBox.Show("Comando " + command + " enviado com sucesso.\n" +
                     "Controle on-off (liga-desliga) iniciado com os seguintes parâmetros:\n" +
                     "Setpoint da temperatura: " + Globals.setpointTemp + " °C\n" +
                     "Banda de histerese: " + Globals.histereseTemp + " °C\n",
                     "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Globals.showHysteresisTemp = true;
                Globals.showSPTemp = true;
            }

            experimentRunning = true;
        }


        private void ONOFFTuningDataHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // Verificar se o experimento está em execução
            if (!experimentRunning)
            {
                return;
            }
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

                timeExp.Add(timeData);
                flowExp.Add(flowData);


                CalculatePeriodAndAmplitude(timeExp, flowExp);
                if (!IsDisposed && txtPeriod.InvokeRequired)
                {
                    // Executa o código na thread de interface do usuário usando Invoke
                    Invoke((MethodInvoker)(() => txtPeriod.Text = period.ToString("0.00")));
                    Invoke((MethodInvoker)(() => txtAmplitude.Text = amplitude.ToString("0.00")));
                }
                else
                {
                    // Atualiza diretamente o controle na thread de interface do usuário
                    txtPeriod.Text = period.ToString("0.00");
                    txtAmplitude.Text = amplitude.ToString("0.00");
                }

            }
            else if (selectedSystem == "Temperatura")
            {
                //
                // Obter os dados mais recentes das listas globais (Globals.timeFlowData e Globals.flowData)
                // Nota: É importante sincronizar o acesso a essas listas para evitar problemas de concorrência.
                // Você pode usar o bloqueio (lock) para garantir que apenas um thread acesse as listas de cada vez.

                double timeData;
                double tempData;

                lock (Globals.timeTempData) // Bloqueia o acesso à lista Globals.timeTempData
                {
                    // Obter o valor mais recente de Globals.timeTempData
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

                timeExp.Add(timeData);
                tempExp.Add(tempData);


                CalculatePeriodAndAmplitude(timeExp, tempExp);


                if (!IsDisposed && txtPeriod.InvokeRequired)
                {
                    // Executa o código na thread de interface do usuário usando Invoke
                    Invoke((MethodInvoker)(() => txtPeriod.Text = period.ToString("0.00")));
                    Invoke((MethodInvoker)(() => txtAmplitude.Text = amplitude.ToString("0.00")));
                }
                else
                {
                    // Atualiza diretamente o controle na thread de interface do usuário
                    txtPeriod.Text = period.ToString("0.00");
                    txtAmplitude.Text = amplitude.ToString("0.00");
                }
            }
        }

        void CalculatePeriodAndAmplitude(List<double> timeExp, List<double> flowExp)
        {
            if (timeExp.Count < 2 || flowExp.Count < 2)
            {
                // Não há dados suficientes para calcular período e amplitude
                return;
            }

            // Encontra os picos e vales da senoide
            List<int> peaksIndexes = new List<int>();
            List<int> valleysIndexes = new List<int>();

            for (int i = 1; i < flowExp.Count - 1; i++)
            {
                // Verifica a derivada discreta para encontrar mudanças de inclinação
                double derivative1 = flowExp[i] - flowExp[i - 1];
                double derivative2 = flowExp[i + 1] - flowExp[i];

                // Verifica se houve uma mudança de inclinação para cima (pico)
                if (derivative1 >= 0 && derivative2 < 0)
                {
                    peaksIndexes.Add(i);
                }
                // Verifica se houve uma mudança de inclinação para baixo (vale)
                else if (derivative1 <= 0 && derivative2 > 0)
                {
                    valleysIndexes.Add(i);
                }
            }

            if (peaksIndexes.Count < 2 || valleysIndexes.Count < 2)
            {
                // Não há picos e vales suficientes para calcular o período e a amplitude
                return;
            }

            // Calcula o período a partir dos índices dos picos
            double periodSum = 0;
            for (int i = 1; i < peaksIndexes.Count; i++)
            {
                periodSum += timeExp[peaksIndexes[i]] - timeExp[peaksIndexes[i - 1]];
            }
            periods.Add(periodSum / (peaksIndexes.Count - 1));

            // Ajusta os índices para que o cálculo da amplitude considere o mesmo número de picos e vales
            if (peaksIndexes.Count > valleysIndexes.Count)
            {
                peaksIndexes.RemoveAt(peaksIndexes.Count - 1);
            }
            else if (valleysIndexes.Count > peaksIndexes.Count)
            {
                valleysIndexes.RemoveAt(0);
            }

            //Calcula amplitude
            for (int i = 0; i < peaksIndexes.Count; i++)
            {
                double amplitude = flowExp[peaksIndexes[i]] - flowExp[valleysIndexes[i]];
                amplitudes.Add(amplitude);
            }
        

            period = CalculateAverageOfLastN(periods, numPointsToAverageAmplitudePeriod);
            amplitude = CalculateAverageOfLastN(amplitudes, numPointsToAverageAmplitudePeriod);
            // Aqui você pode usar os valores calculados (period e amplitude) conforme necessário.
            // Por exemplo, pode exibi-los em caixas de texto, gráficos ou qualquer outra finalidade do seu aplicativo.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Kcu = 0;

            if (sistemaSelecionado.SelectedItem.ToString() == "Vazão")
            {
                Kcu = (4 * (Globals.upperLimitPump - Globals.lowerLimitPump)/2 ) / (Math.PI * amplitude);
            }
            else if (sistemaSelecionado.SelectedItem.ToString() == "Temperatura")
            {
                Kcu = (4 * (Globals.upperLimitRes - Globals.lowerLimitRes)/2 ) / (Math.PI * amplitude);
            }
            double Pu = period;

            double Kc = 0.5 * Kcu;
            double tauI = 0;
            double tauD = 0;
            tabelaControle.Rows.Add("Ziegler-Nichols P",
                             Kc.ToString("0.000"),
                             tauI.ToString("0.000"),
                             tauD.ToString("0.000"));

            Kc = 0.45 * Kcu;
            tauI = 0.83 * Pu;
            tauD = 0;
            tabelaControle.Rows.Add("Ziegler-Nichols PI",
                             Kc.ToString("0.000"),
                             tauI.ToString("0.000"),
                             tauD.ToString("0.000"));

            Kc = 0.60 * Kcu;
            tauI = 0.50 * Pu;
            tauD = 0.125 * Pu;
            tabelaControle.Rows.Add("Ziegler-Nichols PID",
                             Kc.ToString("0.000"),
                             tauI.ToString("0.000"),
                             tauD.ToString("0.000"));

            MessageBox.Show("Experimento finalizado! Valores encontrados:\n" +
                "Ganho último (Kcu): " + Kcu.ToString("0.00") + 
                "\nPeríodo último (Pu): " + Pu.ToString("0.00")
                ,"Experimento finalizado!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            experimentRunning = false;

            amplitudes.Clear();
            periods.Clear();
            timeExp.Clear();
            flowExp.Clear();
            tempExp.Clear();
        }

        private void sistemaSelecionado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sistemaSelecionado.SelectedItem.ToString() == "Vazão")
            {
                selectedSystem = "Vazão";
                lblSetpoint.Text = "Vazão de Referência (Setpoint)";
                txtSetpoint.Text = Globals.setpointVazao.ToString("0.0");
                lblHisterese.Text = "Histerese da Vazão";
                txtHysteresis.Text = Globals.histereseVazao.ToString("0.0");
                lblUnitSP.Text = "L / h";
                lblUnitHisterese.Text = "L / h";
                lblUnitAmplitude.Text = "L / h";
                tabelaControle.Columns[1].HeaderText = "Kc [% h/L]";
            }
            else if (sistemaSelecionado.SelectedItem.ToString() == "Temperatura")
            {
                selectedSystem = "Temperatura";
                lblSetpoint.Text = "Temp. de Referência (Setpoint)";
                txtSetpoint.Text = Globals.setpointTemp.ToString("0.0");
                lblHisterese.Text = "Histerese da Temperatura";
                txtHysteresis.Text = Globals.histereseTemp.ToString("0.0");
                lblUnitSP.Text = "°C";
                lblUnitHisterese.Text = "°C";
                lblUnitAmplitude.Text = "°C";
                tabelaControle.Columns[1].HeaderText = "Kc [%/°C]";
            }

        }

        private double CalculateAverageOfLastN(List<double> values, int n)
        {
            if (values == null || values.Count == 0 || n <= 0)
            {
                // Verifica se a lista é nula, vazia ou n é menor ou igual a zero
                return double.NaN;
            }

            int startIndex = values.Count - n;
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            List<double> lastNValues = values.GetRange(startIndex, Math.Min(n, values.Count - startIndex));
            double sum = lastNValues.Sum();

            return sum / lastNValues.Count;
        }

    }
}
