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
    public partial class SubFormConfigSampling : Form
    {
        public SubFormConfigSampling()
        {
            InitializeComponent();
        }

        private void txtInterval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            if (Globals.serialConnected == false || Globals.serialPort == null)
            {
                MessageBox.Show("Não há uma porta serial conectada.", "Porta serial não conectada!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtInterval.Text, out int interval) || interval < 100)
            {
                MessageBox.Show("Digite um valor inteiro positivo acima de 100.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInterval.Text = string.Empty;
                return;
            }

            Globals.intervalSampling = interval;
            string command = "IS " + interval;
            Globals.serialPort.WriteLine(command);
            Globals.numberFlowPoints = (int)Math.Ceiling(Globals.HistoricoVazao * 1000.0 / Globals.intervalSampling);
            Globals.numberTempPoints = (int)Math.Ceiling(Globals.HistoricoTemp * 1000.0 / Globals.intervalSampling);
            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblMMvazao_Click(object sender, EventArgs e)
        {

        }

        private void txtMMVazao_KeyDown(object sender, KeyEventArgs e)
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

            if (!int.TryParse(txtMMVazao.Text, out int mmVazao) || mmVazao < 1)
            {
                MessageBox.Show("Digite um valor inteiro positivo válido maior do que um.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMMVazao.Text = string.Empty;
                return;
            }

            Globals.mediaMovelFlow = mmVazao;
            string command = "MMF " + mmVazao.ToString();
            Globals.serialPort.WriteLine(command);

            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtEWMAVazao_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtEWMAVazao.Text, out float alfaFlow) || alfaFlow <= 0 || alfaFlow > 1)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 1.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEWMAVazao.Text = string.Empty;
                return;
            }

            Globals.alfaFlow = alfaFlow;
            string command = "AF " + alfaFlow.ToString("0.00");
            Globals.serialPort.WriteLine(command);

            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtMMTemp_KeyDown(object sender, KeyEventArgs e)
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

            if (!int.TryParse(txtMMTemp.Text, out int mmTemp) || mmTemp < 1)
            {
                MessageBox.Show("Digite um valor inteiro positivo válido maior do que um.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMMVazao.Text = string.Empty;
                return;
            }

            Globals.mediaMovelTemp = mmTemp;
            string command = "MMT " + mmTemp.ToString();
            Globals.serialPort.WriteLine(command);

            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtEWMATemp_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtEWMATemp.Text, out float alfaTemp) || alfaTemp <= 0 || alfaTemp > 1)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 1.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEWMAVazao.Text = string.Empty;
                return;
            }

            Globals.alfaTemp = alfaTemp;
            string command = "AT " + alfaTemp.ToString("0.00");
            Globals.serialPort.WriteLine(command);

            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

      

        private void txtMMVazao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEWMAVazao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMMTemp_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubFormConfigSampling_Load(object sender, EventArgs e)
        {
            txtInterval.Text = Convert.ToString(Globals.intervalSampling);
            txtMMVazao.Text = Convert.ToString(Globals.mediaMovelFlow);
            txtEWMAVazao.Text = Convert.ToString(Globals.alfaFlow);
            txtMMTemp.Text = Convert.ToString(Globals.mediaMovelTemp);
            txtEWMATemp.Text = Convert.ToString(Globals.alfaTemp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para mais informações sobre essa seção, recomenda-se a leitura do apêndice A.1 do manual de operação do PCA.\n\n\nEm resumo, aqui estamos configurando o intervalo de amostragem e os filtros para atenuar os ruídos dos sensores.\n\nQuanto à amostragem, quanto menor o valor, mais imprecisa fica a leitura do sensor de vazão, pois toma um intervalo de tempo menor. Em compensação, você tem mais dados e consegue analisar melhor a resposta do sistema. \n\nQuanto aos filtros, se você configurar todos os parâmetros de filtragem como 1, você desliga os dois filtros, recebendo a leitura do sensor 'pura'.\n\nQuanto maior o tamanho da média móvel e quanto menor o valor de alfa, mais lento responde o sistema, mas mais suaves são os dados.\n\nVocê pode testar a eficácia do filtro plotando a variável filtrada e a variável pré-filtro simultâneamente, indo nas configurações dos gráficos.", "Ajuda - Tomada de Dados, Amostragem e Filtragem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtInterval_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
