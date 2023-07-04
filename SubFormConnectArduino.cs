using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisório_PCA_2._0
{
    public partial class SubFormConnectArduino : Form
    {
        public SubFormConnectArduino()
        {
            InitializeComponent();
        }

        private void SubFormConnectArduino_Load(object sender, EventArgs e)
        {
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

        private void searchPortsSub_Click(object sender, EventArgs e)
        {
            string[] ports = GlobalMethods.SearchSerialPorts();

            if (ports != null)
            {
                portsBoxSub.Items.Clear();
                portsBoxSub.Items.AddRange(ports);
                portsBoxSub.SelectedIndex = 0; // Definir a primeira porta como selecionada
            }
        }

        private void disconnectPortSub_Click(object sender, EventArgs e)
        {
            GlobalMethods.DisconnectSerialPort();
            textBox2.Text = "Disconectado!";
            textBox2.ForeColor = Color.Black;
        }

        private void connectPortSub_Click(object sender, EventArgs e)
        {
            if (portsBoxSub.SelectedItem != null) // Verifica se um item foi selecionado na combobox
            {
                string selectedPort = portsBoxSub.SelectedItem.ToString();
                GlobalMethods.ConnectSerialPort(selectedPort);
                textBox2.Text = "Conectado!";
                textBox2.ForeColor = Color.Blue;
            }    
        }

        
    }
}
