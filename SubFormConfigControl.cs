using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
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
            Globals.serialPort.DataReceived += new SerialDataReceivedEventHandler(SubFormDataReceivedHandler);

            txtSetpointVazao.Text = Convert.ToString(Globals.setpointVazao);
            txtHysteresisVazao.Text = Convert.ToString(Globals.histereseVazao);
            txtGanhoVazao.Text = Convert.ToString(Globals.ganhoVazao);
            txtIntegralVazao.Text = Convert.ToString(Globals.integralVazao);
            txtDerivativoVazao.Text = Convert.ToString(Globals.derivativoVazao);
            txtPotenciaBomba.Text = Globals.pumpPower.ToString("0.00");

            txtSetpointTemp.Text = Convert.ToString(Globals.setpointTemp);
            txtHysteresisTemp.Text = Convert.ToString(Globals.histereseTemp);
            txtGanhoTemp.Text = Convert.ToString(Globals.ganhoTemp);
            txtIntegralTemp.Text = Convert.ToString(Globals.integralTemp);
            txtDerivativoTemp.Text = Convert.ToString(Globals.derivativoTemp);
            txtPotenciaResistencia.Text = Globals.resPower.ToString("0.00");

            txtAlfaDerivativoBomba.Text = Globals.alfaDerivativoBomba.ToString("0.00");
            txtAlfaDerivativoResistencia.Text = Globals.alfaDerivativoResistencia.ToString("0.00");

        }

        private void txtPotenciaBomba_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubFormDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // Lógica para lidar com os dados recebidos na porta serial no SubFormConfigControl
            if (txtPotenciaBomba.ReadOnly)
            {
                try
                {
                    if (!IsDisposed && txtPotenciaBomba.InvokeRequired)
                    {
                        // Executa o código na thread de interface do usuário usando Invoke
                        BeginInvoke((MethodInvoker)(() => txtPotenciaBomba.Text = Convert.ToString(Globals.pumpPowerData.Last())));
                    }
                    else
                    {
                        // Atualiza diretamente o controle na thread de interface do usuário
                        txtPotenciaBomba.Text = Convert.ToString(Globals.pumpPowerData.Last());
                    }
                }
                catch (InvalidOperationException ex)
                {
                    if (ex.Message == "Sequence contains no elements")
                    {
                        // Retorna da função caso a exceção seja "Sequence contains no elements"
                        return;
                    }
                    else
                    {
                        // Lidar com a exceção de outra forma, se necessário
                        throw;
                    }
                }
            }

            if (txtPotenciaResistencia.ReadOnly)
            {
                try
                {
                    if (!IsDisposed && txtPotenciaBomba.InvokeRequired)
                    {
                        // Executa o código na thread de interface do usuário usando Invoke
                        BeginInvoke((MethodInvoker)(() => txtPotenciaResistencia.Text = Convert.ToString(Globals.resPowerData.Last())));
                    }
                    else
                    {
                        // Atualiza diretamente o controle na thread de interface do usuário
                        txtPotenciaResistencia.Text = Convert.ToString(Globals.resPowerData.Last());
                    }
                }
                catch (InvalidOperationException ex)
                {
                    if (ex.Message == "Sequence contains no elements")
                    {
                        // Retorna da função caso a exceção seja "Sequence contains no elements"
                        return;
                    }
                    else
                    {
                        // Lidar com a exceção de outra forma, se necessário
                        throw;
                    }
                }
            }

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
                txtPotenciaBomba.Text = Globals.pumpPower.ToString("0.00");
                return;
            }

            if (Globals.controlTypePump == 0)
            {
                //calcular modelo aqui
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
                case 0: // MANUAL
                    txtHysteresisVazao.ReadOnly = true;
                    txtGanhoVazao.ReadOnly = true;
                    txtPotenciaBomba.ReadOnly = false;
                    txtIntegralVazao.ReadOnly = true;
                    txtDerivativoVazao.ReadOnly = true;
                    txtAlfaDerivativoBomba.ReadOnly = true;
                    Globals.showHysteresisVazao = false;
                    Globals.showSPVazao = false;

                    break;

                case 1: // ON-OFF

                    txtPotenciaBomba.ReadOnly = true;
                    txtHysteresisVazao.ReadOnly = false;
                    txtGanhoVazao.ReadOnly = true;
                    txtIntegralVazao.ReadOnly = true;
                    txtDerivativoVazao.ReadOnly = true;
                    txtAlfaDerivativoBomba.ReadOnly = true;
                    Globals.showHysteresisVazao = true;
                    Globals.showSPVazao = true;

           
                    break;

                case 2: // Controle Proporcional
                    txtPotenciaBomba.ReadOnly = true;
                    txtHysteresisVazao.ReadOnly = true;
                    txtGanhoVazao.ReadOnly = false;
                    txtIntegralVazao.ReadOnly = true;
                    txtDerivativoVazao.ReadOnly = true;
                    txtAlfaDerivativoBomba.ReadOnly = true;
                    Globals.showHysteresisVazao = false;
                    Globals.showSPVazao = true;

                    MessageBox.Show("O Controle Proporcional necessita do bias (saída do controle no setpoint desejado). Para o sistema de vazão, isso foi feito a partir de uma estimativa com o ganho do processo, dividindo o setpoint por um fator de 0.63 para se encontrar o bias.", "ALERTA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 3: // Controle Proporcional Integral
                    txtPotenciaBomba.ReadOnly = true;
                    txtHysteresisVazao.ReadOnly = true;
                    txtGanhoVazao.ReadOnly = false;
                    txtIntegralVazao.ReadOnly = false;
                    txtDerivativoVazao.ReadOnly = true;
                    Globals.showHysteresisVazao = false;
                    txtAlfaDerivativoBomba.ReadOnly = true;
                    Globals.showSPVazao = true;

                    break;

                case 4: // Controle Proporcional Integral e Derivativo
                    txtPotenciaBomba.ReadOnly = true;
                    txtHysteresisVazao.ReadOnly = true;
                    txtGanhoVazao.ReadOnly = false;
                    txtIntegralVazao.ReadOnly = false;
                    txtDerivativoVazao.ReadOnly = false;
                    txtAlfaDerivativoBomba.ReadOnly = true;
                    Globals.showHysteresisVazao = false;
                    Globals.showSPVazao = true;

           
                    break;
                case 5: //Controle PID-filtro derivativo
                    txtPotenciaBomba.ReadOnly = true;
                    txtHysteresisVazao.ReadOnly = true;
                    txtGanhoVazao.ReadOnly = false;
                    txtIntegralVazao.ReadOnly = false;
                    txtDerivativoVazao.ReadOnly = false;
                    txtAlfaDerivativoBomba.ReadOnly = false;
                    Globals.showHysteresisVazao = false;
                    Globals.showSPVazao = true;
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
                txtSetpointVazao.Text = Globals.setpointVazao.ToString("0.00");
                return;
            }

            Globals.setpointVazao = setpointVazao;

            if (Globals.RampFlowSP == true)
            {
                float durationRampFlow = (float)rampDurationFlow.Value;
                string command = "RSPF " + setpointVazao.ToString("0.00") + " " + durationRampFlow.ToString("0.00");
                Globals.serialPort.WriteLine(command);
                MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string command = "SPF " + setpointVazao.ToString("0.00");
                Globals.serialPort.WriteLine(command);
                MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtSetpointTemp_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubFormConfigControl_Load(object sender, EventArgs e)
        {
            cmbControlVazao.SelectedIndex = Globals.controlTypePump;
            cmbControlRes.SelectedIndex = Globals.controlTypeRes;
            if (Globals.RampFlowSP == true)
            {
                cmbFlowSPChange.SelectedIndex = 1;
            }

            if (Globals.RampTempSP == true)
            {
                cmbTempSPChange.SelectedIndex = 1;
            }


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
                txtHysteresisVazao.Text = Globals.histereseVazao.ToString("0.00");
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
                txtGanhoVazao.Text = Globals.ganhoVazao.ToString("0.00");
                return;
            }

            Globals.ganhoVazao = ganhoVazao;
            string command = "KCP " + ganhoVazao.ToString("0.00");
            Globals.serialPort.WriteLine(command);
            txtGanhoVazao.ForeColor = System.Drawing.Color.Green;
            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtIntegralVazao_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtIntegralVazao.Text, out float integralVazao) || integralVazao < 0 || integralVazao > 5000)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 5000.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIntegralVazao.Text = Globals.integralVazao.ToString("0.00");
                return;
            }

            Globals.integralVazao = integralVazao;
            string command = "TIP " + integralVazao.ToString("0.00");
            Globals.serialPort.WriteLine(command);
            txtIntegralVazao.ForeColor = System.Drawing.Color.Green;
            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void txtDerivativoVazao_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtDerivativoVazao.Text, out float derivativoVazao) || derivativoVazao < 0 || derivativoVazao > 5000)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 5000.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDerivativoVazao.Text =  Globals.derivativoVazao.ToString("0.00");
                return;
            }

            Globals.derivativoVazao = derivativoVazao;
            string command = "TDP " + derivativoVazao.ToString("0.00");
            Globals.serialPort.WriteLine(command);
            txtDerivativoVazao.ForeColor = System.Drawing.Color.Green;
            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtDerivativoVazao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIntegralVazao_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVazao_Click(object sender, EventArgs e)
        {
            int controlTypePump = cmbControlVazao.SelectedIndex;
            Globals.controlTypePump = controlTypePump;
            string command = "CTP " + controlTypePump.ToString("0.00");
            Globals.serialPort.WriteLine(command);
            txtGanhoVazao.ForeColor = System.Drawing.Color.Black;
            txtIntegralVazao.ForeColor = System.Drawing.Color.Black;
            txtDerivativoVazao.ForeColor = System.Drawing.Color.Black;
            switch (controlTypePump)
            {
                case 0:
                    txtPotenciaBomba.ReadOnly = false;
                    MessageBox.Show("Comando " + command + " enviado com sucesso.\n" +
                    "Controle manual iniciado!", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                case 1:
                    MessageBox.Show("Comando " + command + " enviado com sucesso.\n" +
                    "Controle on-off (liga-desliga) iniciado com os seguintes parâmetros:\n" +
                    "Setpoint da vazão: " + Globals.setpointVazao + " L/h\n" +
                    "Banda de histerese: " + Globals.histereseVazao  +  " L/h\n", 
                    "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                case 2:
                    MessageBox.Show("Comando " + command + " enviado com sucesso.\n" +
                    "Controle proporcional iniciado com os seguintes parâmetros:\n" +
                    "Setpoint da vazão: " + Globals.setpointVazao + " L/h\n" +
                    "Ganho do controlador: " + Globals.ganhoVazao + " L h-1 %-1\n" +
                    "Saída do controlador no estado estacionário estimada/empírica (bias ou viés):" + (Globals.setpointVazao/0.63).ToString("0.00") + "%\n",
                    "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                case 3:
                    MessageBox.Show("Comando " + command + " enviado com sucesso.\n" +
                    "Controle proporcional-integral iniciado com os seguintes parâmetros:\n" +
                    "Setpoint da vazão: " + Globals.setpointVazao + " L/h\n" +
                    "Ganho do controlador: " + Globals.ganhoVazao + " L h-1 %-1\n" +
                    "Tempo integral do controlador: " + Globals.integralVazao + " s",
                    "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                case 4:
                    MessageBox.Show("Comando " + command + " enviado com sucesso.\n" +
                    "Controle proporcional-integral-derivativo iniciado com os seguintes parâmetros:\n" +
                    "Setpoint da vazão: " + Globals.setpointVazao + " L/h\n" +
                    "Ganho do controlador: " + Globals.ganhoVazao + " L h-1 %-1\n" +
                    "Tempo integral do controlador: " + Globals.integralVazao + " s\n" +
                    "Tempo derivativo do controlador: " + Globals.derivativoVazao + " s",
                    "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

        }

        private void txtSetpointTemp_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtSetpointTemp.Text, out float setpointTemp) || setpointTemp < 0 || setpointTemp > 50)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 50.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSetpointTemp.Text = Globals.setpointTemp.ToString("0.00");
                return;
            }

            Globals.setpointTemp = setpointTemp;
            string command = "SPT " + setpointTemp.ToString("0.00");
            Globals.serialPort.WriteLine(command);
            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtHysteresisTemp_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtHysteresisTemp.Text, out float histereseTemp) || histereseTemp < 0 || histereseTemp > 10)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 10.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHysteresisTemp.Text = Globals.histereseTemp.ToString("0.00");
                return;
            }

            Globals.histereseTemp = histereseTemp;
            string command = "HT " + histereseTemp.ToString("0.00");
            Globals.serialPort.WriteLine(command);
            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtGanhoTemp_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtGanhoTemp.Text, out float ganhoTemp) || ganhoTemp < 0 || ganhoTemp > 5000)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 5000.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGanhoTemp.Text = Globals.ganhoTemp.ToString("0.00");
                return;
            }

            Globals.ganhoTemp = ganhoTemp;
            string command = "KCR " + ganhoTemp.ToString("0.00");
            Globals.serialPort.WriteLine(command);
            txtGanhoTemp.ForeColor = System.Drawing.Color.Green;
            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtIntegralTemp_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtIntegralTemp.Text, out float integralTemp) || integralTemp < 0 || integralTemp > 5000)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 5000.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIntegralTemp.Text = Globals.integralTemp.ToString("0.00");
                return;
            }

            Globals.integralTemp = integralTemp;
            string command = "TIR " + integralTemp.ToString("0.00");
            Globals.serialPort.WriteLine(command);
            txtIntegralTemp.ForeColor = System.Drawing.Color.Green;
            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtDerivativoTemp_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtDerivativoTemp.Text, out float derivativoTemp) || derivativoTemp < 0 || derivativoTemp > 5000)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 5000.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDerivativoTemp.Text = Globals.derivativoTemp.ToString("0.00");
                return;
            }

            Globals.derivativoTemp = derivativoTemp;
            string command = "TDR " + derivativoTemp.ToString("0.00");
            Globals.serialPort.WriteLine(command);
            txtDerivativoTemp.ForeColor = System.Drawing.Color.Green;
            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTemp_Click(object sender, EventArgs e)
        {
            int controlTypeRes = cmbControlRes.SelectedIndex;
            Globals.controlTypeRes = controlTypeRes;
            string command = "CTR " + controlTypeRes.ToString("0.00");
            Globals.serialPort.WriteLine(command);
            txtGanhoTemp.ForeColor = System.Drawing.Color.Black;
            txtIntegralTemp.ForeColor = System.Drawing.Color.Black;
            txtDerivativoTemp.ForeColor = System.Drawing.Color.Black;
            switch (controlTypeRes)
            {
                case 0:
                    txtPotenciaResistencia.ReadOnly = false;
                    MessageBox.Show("Comando " + command + " enviado com sucesso.\n" +
                    "Controle manual iniciado!", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                case 1:
                    MessageBox.Show("Comando " + command + " enviado com sucesso.\n" +
                    "Controle on-off (liga-desliga) iniciado com os seguintes parâmetros:\n" +
                    "Setpoint da temperatura: " + Globals.setpointTemp + " °C\n" +
                    "Banda de histerese: " + Globals.histereseTemp + " °C\n",
                    "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                case 2:
                    MessageBox.Show("Comando " + command + " enviado com sucesso.\n" +
                    "Controle proporcional iniciado com os seguintes parâmetros:\n" +
                    "Setpoint da temperatura: " + Globals.setpointTemp + " °C\n" +
                    "Ganho do controlador: " + Globals.ganhoTemp + " % / °C",
                    "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                case 3:
                    MessageBox.Show("Comando " + command + " enviado com sucesso.\n" +
                    "Controle proporcional-integral iniciado com os seguintes parâmetros:\n" +
                    "Setpoint da temperatura: " + Globals.setpointTemp + " °C\n" +
                    "Ganho do controlador: " + Globals.ganhoTemp + " % / °C\n" +
                    "Tempo integral do controlador: " + Globals.integralTemp + " s",
                    "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                case 4:
                    MessageBox.Show("Comando " + command + " enviado com sucesso.\n" +
                    "Controle proporcional-integral-derivativo iniciado com os seguintes parâmetros:\n" +
                    "Setpoint da temperatura: " + Globals.setpointTemp + " °C\n" +
                    "Ganho do controlador: " + Globals.ganhoTemp + " % / °C\n" +
                    "Tempo integral do controlador: " + Globals.integralTemp + " s\n" +
                    "Tempo derivativo do controlador: " + Globals.derivativoTemp + " s",
                    "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                case 5:
                    MessageBox.Show("Comando " + command + " enviado com sucesso.\n" +
                    "Controle cascata proporcional iniciado com os seguintes parâmetros:\n" +
                    "Setpoint da temperatura: " + Globals.setpointTemp + " °C\n" +
                    "Ganho do controlador: " + Globals.ganhoTemp + " % / °C\n",
                    "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                case 6:
                    MessageBox.Show("Comando " + command + " enviado com sucesso.\n" +
                    "Controle cascata proporcional-integral iniciado com os seguintes parâmetros:\n" +
                    "Setpoint da temperatura: " + Globals.setpointTemp + " °C\n" +
                    "Ganho do controlador: " + Globals.ganhoTemp + " % / °C\n" +
                    "Tempo integral do controlador: " + Globals.integralTemp + " s",
                    "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                case 7:
                    MessageBox.Show("Comando " + command + " enviado com sucesso.\n" +
                    "Controle cascata proporcional-integral-derivativo iniciado com os seguintes parâmetros:\n" +
                    "Setpoint da temperatura: " + Globals.setpointTemp + " °C\n" +
                    "Ganho do controlador: " + Globals.ganhoTemp + " % / °C\n" +
                    "Tempo integral do controlador: " + Globals.integralTemp + " s" +
                    "Tempo derivativo do controlador: " + Globals.derivativoTemp + " s",
                    "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }
        }

        private void txtPotenciaResistencia_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtPotenciaResistencia.Text, out float resPower) || resPower < 0 || resPower > 100)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 100.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPotenciaResistencia.Text = Globals.resPower.ToString("0.00");
                return;
            }

            Globals.resPower = resPower;
            string command = "RP " + resPower.ToString("0.00");
            Globals.serialPort.WriteLine(command);

            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtPotenciaResistencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbControlRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbControlRes.SelectedIndex)
            {
                case 0: // MANUAL
                    txtHysteresisTemp.ReadOnly = true;
                    txtGanhoTemp.ReadOnly = true;
                    txtIntegralTemp.ReadOnly = true;
                    txtDerivativoTemp.ReadOnly = true;
                    txtAlfaDerivativoResistencia.ReadOnly = true;
                    Globals.showHysteresisTemp = false;
                    Globals.showSPTemp = false;

                    txtSetpointVazao.ReadOnly = false;
                    break;
                case 1: // ON-OFF
                    txtPotenciaResistencia.ReadOnly = true;
                    txtHysteresisTemp.ReadOnly = false;
                    txtGanhoTemp.ReadOnly = true;
                    txtIntegralTemp.ReadOnly = true;
                    txtDerivativoTemp.ReadOnly = true;
                    txtAlfaDerivativoResistencia.ReadOnly = true;
                    Globals.showHysteresisTemp = true;
                    Globals.showSPTemp = true;

                    txtSetpointVazao.ReadOnly = false;
                    break;
                case 2: // Controle Proporcional
                    txtPotenciaResistencia.ReadOnly = true;
                    txtHysteresisTemp.ReadOnly = true;
                    txtGanhoTemp.ReadOnly = false;
                    txtIntegralTemp.ReadOnly = true;
                    txtDerivativoTemp.ReadOnly = true;
                    txtAlfaDerivativoResistencia.ReadOnly = true;
                    Globals.showHysteresisTemp = false;
                    Globals.showSPTemp = true;

                    txtSetpointVazao.ReadOnly = false;
                    MessageBox.Show("O Controle Proporcional necessita do bias (saída do controle no setpoint desejado). Atualmente para o sistema de temperatura isso não está implementado e o bias será a última saída do controlador. Portanto, somente use esse controle P para controle regulatório, para servo ele pode não funcionar devido à diferença de bias.", "ALERTA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 3: // Controle Proporcional Integral
                    txtPotenciaResistencia.ReadOnly = true;
                    txtHysteresisTemp.ReadOnly = true;
                    txtGanhoTemp.ReadOnly = false;
                    txtIntegralTemp.ReadOnly = false;
                    txtDerivativoTemp.ReadOnly = true;
                    txtAlfaDerivativoResistencia.ReadOnly = true;
                    Globals.showHysteresisTemp = false;
                    Globals.showSPTemp = true;

                    txtSetpointVazao.ReadOnly = false;
                    break;
                case 4: // Controle Proporcional Integral e Derivativo
                    txtPotenciaResistencia.ReadOnly = true;
                    txtHysteresisTemp.ReadOnly = true;
                    txtGanhoTemp.ReadOnly = false;
                    txtIntegralTemp.ReadOnly = false;
                    txtDerivativoTemp.ReadOnly = false;
                    txtAlfaDerivativoResistencia.ReadOnly = true;
                    Globals.showHysteresisTemp = false;
                    Globals.showSPTemp = true;

                    txtPotenciaBomba.ReadOnly = false;
                    txtSetpointVazao.ReadOnly = false;
                    break;
                case 5: //Controle pid com filtro derivativo
                    txtPotenciaResistencia.ReadOnly = true;
                    txtHysteresisTemp.ReadOnly = true;
                    txtGanhoTemp.ReadOnly = false;
                    txtIntegralTemp.ReadOnly = false;
                    txtDerivativoTemp.ReadOnly = false;
                    txtAlfaDerivativoResistencia.ReadOnly = false;
                    Globals.showHysteresisTemp = false;
                    Globals.showSPTemp = true;

                    txtPotenciaBomba.ReadOnly = false;
                    txtSetpointVazao.ReadOnly = false;
                    break;
                case 6: 
                    
                    // Controle Cascata Proporcional
                    if (Globals.controlTypePump == 2 || Globals.controlTypePump == 3 || Globals.controlTypePump == 4 || Globals.controlTypePump == 5)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Para que seja possível acionar o controle em cascata, a bomba deve estar em modo de controle automático (P, PI, ou PID). Altere o modo de controle e tente novamente, não esquecendo de apertar CONFIRMAR.", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    txtPotenciaResistencia.ReadOnly = false;
                    txtHysteresisTemp.ReadOnly = true;
                    txtGanhoTemp.ReadOnly = false;
                    txtIntegralTemp.ReadOnly = true;
                    txtDerivativoTemp.ReadOnly = true;
                    Globals.showHysteresisTemp = false;
                    Globals.showSPTemp = true;

                    txtPotenciaBomba.ReadOnly = true;
                    txtSetpointVazao.ReadOnly = true;
                    break;
                case 7: // Controle Cascata Proporcional-Integral
                    if (Globals.controlTypePump == 2 || Globals.controlTypePump == 3 || Globals.controlTypePump == 4)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Para que seja possível acionar o controle em cascata, a bomba deve estar em modo de controle automático (P, PI, ou PID). Altere o modo de controle e tente novamente, não esquecendo de apertar CONFIRMAR.", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    txtPotenciaResistencia.ReadOnly = false;
                    txtHysteresisTemp.ReadOnly = true;
                    txtGanhoTemp.ReadOnly = false;
                    txtIntegralTemp.ReadOnly = false;
                    txtDerivativoTemp.ReadOnly = true;
                    Globals.showHysteresisTemp = false;
                    Globals.showSPTemp = true;

                    txtPotenciaBomba.ReadOnly = true;
                    txtSetpointVazao.ReadOnly = true;
                    break;
                case 8: // Controle Cascata PID
                    if (Globals.controlTypePump == 2 || Globals.controlTypePump == 3 || Globals.controlTypePump == 4)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Para que seja possível acionar o controle em cascata, a bomba deve estar em modo de controle automático (P, PI, ou PID). Altere o modo de controle e tente novamente, não esquecendo de apertar CONFIRMAR.", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    txtPotenciaResistencia.ReadOnly = false;
                    txtHysteresisTemp.ReadOnly = true;
                    txtGanhoTemp.ReadOnly = false;
                    txtIntegralTemp.ReadOnly = false;
                    txtDerivativoTemp.ReadOnly = false;
                    Globals.showHysteresisTemp = false;
                    Globals.showSPTemp = true;

                    txtPotenciaBomba.ReadOnly = true;
                    txtSetpointVazao.ReadOnly = true;

                    break;
            }
        }

        private void cmbFlowSPChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbFlowSPChange.SelectedIndex == 1)
            {
                Globals.RampFlowSP = true;
                rampDurationFlow.Visible = true;
                lblRampFlow.Visible = true;
            }
            else
            {
                Globals.RampFlowSP = false;
                rampDurationFlow.Visible = false;
                lblRampFlow.Visible = false;
            }
        }

        private void cmbTempSPChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTempSPChange.SelectedIndex == 1)
            {
                Globals.RampTempSP = true;
                rampDurationTemp.Visible = true;
                lblRampTemp.Visible = true;
            }
            else
            {
                Globals.RampTempSP = false;
                rampDurationTemp.Visible = false;
                lblRampTemp.Visible = false;
            }
        }

        private void txtHysteresisTemp_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabVazao_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void txtAlfaDerivativoResistencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAlfaDerivativoBomba_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAlfaDerivativoResistencia_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtAlfaDerivativoResistencia.Text, out float alfaDerivativoRes) || alfaDerivativoRes < 0 || alfaDerivativoRes > 1)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 1.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAlfaDerivativoResistencia.Text = Globals.resPower.ToString("0.00");
                return;
            }

            Globals.alfaDerivativoResistencia = alfaDerivativoRes;
            string command = "ADR " + alfaDerivativoRes.ToString("0.00");
            Globals.serialPort.WriteLine(command);

            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


            private void txtAlfaDerivativoBomba_KeyDown(object sender, KeyEventArgs e)
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

                if (!float.TryParse(txtAlfaDerivativoBomba.Text, out float alfaDerivativoBomba) || alfaDerivativoBomba < 0 || alfaDerivativoBomba > 1)
                {
                    MessageBox.Show("Digite um valor decimal entre 0 e 1.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAlfaDerivativoBomba.Text = Globals.resPower.ToString("0.00");
                    return;
                }

                Globals.alfaDerivativoBomba = alfaDerivativoBomba;
                string command = "ADP " + alfaDerivativoBomba.ToString("0.00");
                Globals.serialPort.WriteLine(command);

                MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ainda em desenvolvimento!", "Em desenvolvimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }
    }
}
