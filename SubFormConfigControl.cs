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
    public partial class SubFormConfigControl : Form
    {
        public SubFormConfigControl()
        {
            InitializeComponent();
        }

        private void txtPotenciaBomba_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPotenciaBomba_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtPotenciaBomba.Text, out float pumpPower) || pumpPower < 0 || pumpPower > 100)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 100.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPotenciaBomba.Text = string.Empty;
                return;
            }

            Globals.pumpPower = pumpPower;
            string command = "PP " + pumpPower.ToString("0.00");
            Globals.serialPort.WriteLine(command);

            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void cmbControlVazao_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbControlVazao.SelectedIndex)
            {
                case 0: //MANUAL
                    txtPotenciaBomba.ReadOnly = false;
                    txtHysteresisVazao.ReadOnly = true;
                    txtGanhoVazao.ReadOnly = true;
                    txtIntegralVazao.ReadOnly = true;
                    txtDerivativoVazao.ReadOnly=true;
                    break;
                case 1: //ON-OFF
                    txtPotenciaBomba.ReadOnly = true;
                    txtHysteresisVazao.ReadOnly = false;
                    txtGanhoVazao.ReadOnly = true;
                    txtIntegralVazao.ReadOnly = true;
                    txtDerivativoVazao.ReadOnly = true;
                    break; 
                case 2: //Controle Proporcional
                    txtPotenciaBomba.ReadOnly = true;
                    txtHysteresisVazao.ReadOnly = true;
                    txtGanhoVazao.ReadOnly = false;
                    txtIntegralVazao.ReadOnly = true;
                    txtDerivativoVazao.ReadOnly = true;
                    break;
                case 3: //Controle Proporcional Integral
                    txtPotenciaBomba.ReadOnly = true;
                    txtHysteresisVazao.ReadOnly = true;
                    txtGanhoVazao.ReadOnly = false;
                    txtIntegralVazao.ReadOnly = false;
                    txtDerivativoVazao.ReadOnly = true;
                    break;
                case 4: //Controle Proporcional Integral e Derivativo
                    txtPotenciaBomba.ReadOnly = true;
                    txtHysteresisVazao.ReadOnly = true;
                    txtGanhoVazao.ReadOnly = false;
                    txtIntegralVazao.ReadOnly = false;
                    txtDerivativoVazao.ReadOnly = false;
                    break;
            }
            

        }

        private void label18_Click(object sender, EventArgs e)
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

            if (!float.TryParse(txtSetpointVazao.Text, out float setpointVazao) || setpointVazao < 0 || setpointVazao > 80)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 80.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSetpointVazao.Text = string.Empty;
                return;
            }

            Globals.setpointVazao = setpointVazao;
            string command = "SPF " + setpointVazao.ToString("0.00");
            Globals.serialPort.WriteLine(command);

            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtSetpointTemp_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubFormConfigControl_Load(object sender, EventArgs e)
        {

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

            if (!float.TryParse(txtHysteresisVazao.Text, out float histereseVazao) || histereseVazao < 0 || histereseVazao > 50)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 50.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHysteresisVazao.Text = string.Empty;
                return;
            }

            Globals.histereseVazao = histereseVazao;
            string command = "HF " + histereseVazao.ToString("0.00");
            Globals.serialPort.WriteLine(command);

            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtGanhoVazao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGanhoVazao_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtGanhoVazao.Text, out float ganhoVazao) || ganhoVazao < 0 || ganhoVazao > 5000)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 5000.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHysteresisVazao.Text = string.Empty;
                return;
            }

            Globals.ganhoVazao = ganhoVazao;
            string command = "KCP " + ganhoVazao.ToString("0.00");
            Globals.serialPort.WriteLine(command);
            txtGanhoVazao.ForeColor = System.Drawing.Color.Green;
            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
