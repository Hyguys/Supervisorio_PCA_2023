using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Supervisório_PCA_2._0
{
    public partial class MainForm : Form
    {
       

        public MainForm()
        {
            InitializeComponent();
            Globals.serialPort = new SerialPort(); // linha para inicializar o objeto serialPort 
        }

        private void tomadaDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchSerialPorts();
        }

        public void SearchSerialPorts()
        {
            // Limpar a lista de portas COM existente
            comboBox1.Items.Clear();

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

                // Adicionar as portas COM à lista
                comboBox1.Items.AddRange(portNames);
                comboBox1.SelectedIndex = 0; // Definir a primeira porta como selecionada
            }
            else
            {
                DialogResult result = MessageBox.Show("Nenhuma porta COM foi encontrada.", "Erro!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    SearchSerialPorts(); // Chama o método de pesquisa novamente
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPort = comboBox1.SelectedItem.ToString();

            // Exiba uma mensagem de confirmação
            DialogResult result = MessageBox.Show("Deseja conectar-se à porta " + selectedPort + " selecionada?", "Confirmação de conexão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Tenta conectar à porta COM selecionada
                GlobalMethods.ConnectSerialPort(selectedPort);
            }
            else
            {
                // Cancelar a conexão
                MessageBox.Show("Conexão cancelada pelo usuário.", "Conexão cancelada!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            GlobalMethods.DisconnectSerialPort();
            textBox2.Text = "Disconectado!";
            textBox2.ForeColor = Color.Black;
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            string selectedPort = comboBox1.SelectedItem.ToString();
            GlobalMethods.ConnectSerialPort(selectedPort);
            textBox2.Text = "Conectado!";
            textBox2.ForeColor = Color.Blue;
        }
    }
}
