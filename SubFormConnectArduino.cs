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
            bool serialPortconnected = Globals.serialConnected;
            if (serialPortconnected == true)
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GlobalMethods.DisconnectSerialPort();
        }
    }
}
