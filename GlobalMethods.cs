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

            Globals.RampFlowSP = Globals.defaultRampFlowSP;
            Globals.RampTempSP = Globals.defaultRampTempSP;

            Globals.lowerLimitPump = Globals.defaultLowerLimitPump;
            Globals.upperLimitPump = Globals.defaultUpperLimitPump;

            Globals.lowerLimitRes = Globals.defaultLowerLimitRes;
            Globals.upperLimitRes = Globals.defaultUpperLimitRes;
        }

        public static DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Name";

            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            System.Windows.Forms.Button okButton = new System.Windows.Forms.Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            System.Windows.Forms.Button cancelButton = new System.Windows.Forms.Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
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
            Globals.pureFlowData.Clear();
            Globals.pureTempOutData.Clear();
            Globals.flowModelCalc.Clear();
            Globals.tempModelCalc.Clear();
        }

        public static void ConnectSerialPort(string selectedPort)
        {
            if (Globals.serialConnected == true && Globals.serialPort.PortName == selectedPort)
            {
                MessageBox.Show("Conexão à porta " + selectedPort + " já está estabelecida!", "Conexão já estabelecida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                ClearLists();
                ResetGlobalVariables();

                Globals.serialPort.PortName = selectedPort;
                Globals.serialPort.Open();
                Globals.serialConnected = true;
                Globals.serialPort.DtrEnable = true;
                Globals.serialPort.DiscardInBuffer();

                Thread.Sleep(300);  // Aguarda 500ms para permitir a reinicialização do Arduino

                // Limpa as listas globais de dados
                ClearLists();

                Globals.serialPort.DtrEnable = false;
              
                MessageBox.Show("Conexão à porta " + selectedPort + " estabelecida com sucesso!", "Conexão realizada com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Access to the port"))
                {
                    // Display a custom message box for "Access denied" exception
                    MessageBox.Show("Acesso à porta " + selectedPort + " foi negado. Verifique se outro programa (como o Serial Monitor da IDE do Arduino, ou o Excel Data Streamer) está utilizando a porta ou se você tem permissão de acesso.\n\nExperimente fechar o monitor serial da Arduino IDE ou o Excel e verifique se o erro permanece, se sim, feche todos os programas e abra somente o Supervisório PCA.", "Erro de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Erro ao conectar-se à porta COM: " + ex.Message, "Erro na conexão!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.Retry)
                    {
                        // Tenta novamente a conexão
                        ConnectSerialPort(selectedPort);
                    }
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



        public static Color ColorPicker(Color currentColor)
        {
            // Create an instance of ColorDialog
            ColorDialog colorDialog = new ColorDialog();

            // Set the initial color of the ColorDialog to the current color
            colorDialog.Color = currentColor;

            // Display the ColorDialog
            DialogResult result = colorDialog.ShowDialog();

            // Check if the user selected a color
            if (result == DialogResult.OK)
            {
                // Get the selected color
                Color selectedColor = colorDialog.Color;

                return selectedColor;
            }
            else
            {
                // If the user cancels, return the current color without changes
                return currentColor;
            }
        }
    }


}
