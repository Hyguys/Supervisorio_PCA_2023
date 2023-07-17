using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Supervisório_PCA_2._0
{
    public static class GlobalMethods
    {

        public static string[] SearchSerialPorts()
        {
            // Obter todas as portas COM disponíveis no sistema
            string[] portNames = SerialPort.GetPortNames();

            // Verificar se há portas COM disponíveis
            if (portNames.Length > 0)
            {
                if (portNames.Length == 1)
                {
                    MessageBox.Show(" Uma porta COM foi encontrada!", "Porta COM encontrada!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(portNames.Length + " portas COM foram encontradas!", "Portas COM encontradas!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return portNames;
            }
            else
            {
                DialogResult result = MessageBox.Show("Nenhuma porta COM foi encontrada.", "Erro!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    return SearchSerialPorts(); // Chama o método de pesquisa novamente
                }
                else
                {
                    return null; // Nenhuma porta COM encontrada
                }
            }
        }

        public static void ResetGlobalVariables()
        {
            Globals.isRecordingData = Globals.defaultIsRecordingData;
            Globals.intervalSampling = Globals.defaultIntervalSampling;

            Globals.showHysteresisTemp = Globals.defaultShowHysteresisTemp;
            Globals.showHysteresisVazao = Globals.defaultShowHysteresisVazao;
            Globals.showSPTemp = Globals.defaultShowSPTemp;
            Globals.showSPVazao = Globals.defaultShowSPVazao;

            Globals.numberFlowPoints = Globals.defaultNumberFlowPoints;
            Globals.mediaMovelFlow = Globals.defaultMediaMovelFlow;
            Globals.alfaFlow = Globals.defaultAlfaFlow;

            Globals.numberTempPoints = Globals.defaultNumberTempPoints;
            Globals.mediaMovelTemp = Globals.defaultMediaMovelTemp;
            Globals.alfaTemp = Globals.defaultAlfaTemp;

            Globals.pumpPower = Globals.defaultPumpPower;
            Globals.setpointVazao = Globals.defaultSetpointVazao;
            Globals.histereseVazao = Globals.defaultHistereseVazao;
            Globals.ganhoVazao = Globals.defaultGanhoVazao;
            Globals.integralVazao = Globals.defaultIntegralVazao;
            Globals.derivativoVazao = Globals.defaultDerivativoVazao;

            Globals.resPower = Globals.defaultResPower;
            Globals.setpointTemp = Globals.defaultSetpointTemp;
            Globals.histereseTemp = Globals.defaultHistereseTemp;
            Globals.ganhoTemp = Globals.defaultGanhoTemp;
            Globals.integralTemp = Globals.defaultIntegralTemp;
            Globals.derivativoTemp = Globals.defaultDerivativoTemp;

            Globals.controlTypeRes = Globals.defaultControlTypeRes;
            Globals.controlTypePump = Globals.defaultControlTypePump;
        }


        public static void ClearLists()
        {
            // Limpa as listas globais de dados
            Globals.timeFlowData.Clear();
            Globals.timeTempData.Clear();
            Globals.flowData.Clear();
            Globals.flowSPData.Clear();
            Globals.pumpPowerData.Clear();
            Globals.hysteresisFlowData.Clear();
            Globals.hysteresisFlowLowerLimitData.Clear();
            Globals.hysteresisFlowUpperLimitData.Clear();
            Globals.tempInData.Clear();
            Globals.tempOutData.Clear();
            Globals.tempSPData.Clear();
            Globals.resPowerData.Clear();
            Globals.hysteresisTempData.Clear();
            Globals.hysteresisTempLowerLimitData.Clear();
            Globals.hysteresisTempUpperLimitData.Clear();
        }

        public static void ConnectSerialPort(string selectedPort)
        {
            if(Globals.serialConnected == true && Globals.serialPort.PortName == selectedPort)
            {
                MessageBox.Show("Conexão à porta " + selectedPort + " já está estabelecida!", "Conexão já estabelecida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                Globals.serialPort.PortName = selectedPort;
                Globals.serialPort.Open();
                Globals.serialConnected = true;
                Globals.serialPort.DtrEnable = true;

                Thread.Sleep(250);  // Aguarda 500ms para permitir a reinicialização do Arduino

                // Limpa as listas globais de dados
                ClearLists();

                Globals.serialPort.DtrEnable = false;

                MessageBox.Show("Conexão à porta " + selectedPort + " estabelecida com sucesso!", "Conexão realizada com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Erro ao conectar-se à porta COM: " + ex.Message, "Erro na conexão!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Retry)
                {
                    // Tenta novamente a conexão
                    ConnectSerialPort(selectedPort);
                }
            }
        }


        public static void DisconnectSerialPort()
        {
            try
            {
                if (Globals.serialPort.IsOpen)
                {
                    Globals.serialPort.Close();
                    Globals.serialConnected = false;
                    GlobalMethods.ResetGlobalVariables();
                    MessageBox.Show("Desconectado da porta serial com sucesso.", "Desconectar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    Globals.serialConnected = false;
                    MessageBox.Show("Nenhuma porta serial está atualmente conectada.", "Desconectar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                Globals.serialConnected = false;
                MessageBox.Show("Erro ao desconectar da porta serial: " + ex.Message, "Desconectar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string ReadSerialPort(string serialPortName)
        {
            SerialPort serialPort = new SerialPort(serialPortName);

            try
            {
                serialPort.Open();
                Console.WriteLine("Serial port opened. Reading data...");

                string strRead = serialPort.ReadExisting();

                return strRead;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                if (serialPort.IsOpen)
                    serialPort.Close();
            }
        }

        public static string[] SplitStringBySpace(string input)
        {
            return input.Split(' ');
        }
    }
}
