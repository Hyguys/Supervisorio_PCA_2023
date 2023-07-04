using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
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


        public static void ConnectSerialPort(string selectedPort)
        {
            try
            {
                Globals.serialPort.PortName = selectedPort;
                Globals.serialPort.Open();
                Globals.serialConnected = true;
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
                    MessageBox.Show("Desconectado da porta serial com sucesso.", "Desconectar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Nenhuma porta serial está atualmente conectada.", "Desconectar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
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
