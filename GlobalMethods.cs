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
        public static SerialPort serialPort;

        public static void ConnectSerialPort(string selectedPort)
        {
            try
            {
                serialPort.PortName = selectedPort;
                serialPort.Open();
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

    }
}
