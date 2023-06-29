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
        private SerialPort serialPort;

        public MainForm()
        {
            InitializeComponent();
            serialPort = new SerialPort(); // Adicione essa linha para inicializar o objeto serialPort
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

        private void SearchSerialPorts()
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
                    MessageBox.Show(portNames.Length + " porta COM foi encontrada!", "Porta COM encontrada!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DialogResult result = MessageBox.Show("Deseja conectar-se à porta COM " + selectedPort + " selecionada?", "Confirmação de conexão", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Conecte-se à porta COM selecionada
                try
                {
                    serialPort.PortName = selectedPort;
                    serialPort.Open();
                    MessageBox.Show("Conexão à porta " + selectedPort + " estabelecida com sucesso!","Conexão realizada com sucesso!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar-se à porta COM: " + ex.Message,"Erro na conexão!",MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Cancelar a conexão
                MessageBox.Show("Conexão cancelada pelo usuário.","Conexão cancelada!", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
