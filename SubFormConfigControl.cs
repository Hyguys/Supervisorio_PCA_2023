﻿using System;
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
            txtSetpointVazao.Text = Convert.ToString(Globals.setpointVazao);
            txtHysteresisVazao.Text = Convert.ToString(Globals.histereseVazao);
            txtGanhoVazao.Text = Convert.ToString(Globals.ganhoVazao);
            txtIntegralVazao.Text = Convert.ToString(Globals.integralVazao);
            txtDerivativoVazao.Text = Convert.ToString(Globals.derivativoVazao);

            txtSetpointTemp.Text = Convert.ToString(Globals.setpointTemp);
            txtHysteresisTemp.Text = Convert.ToString(Globals.histereseTemp);
            txtGanhoTemp.Text = Convert.ToString(Globals.ganhoTemp);
            txtIntegralTemp.Text = Convert.ToString(Globals.integralTemp);
            txtDerivativoTemp.Text = Convert.ToString(Globals.derivativoTemp);
            Globals.serialPort.DataReceived += new SerialDataReceivedEventHandler(SubFormDataReceivedHandler);

        }

        private void txtPotenciaBomba_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubFormDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // Lógica para lidar com os dados recebidos na porta serial no SubFormConfigControl
            if (Globals.controlTypePump == 1 || Globals.controlTypePump == 2 || Globals.controlTypePump == 3 || Globals.controlTypePump == 4)
            {
                try
                {
                    if (!IsDisposed && txtPotenciaBomba.InvokeRequired)
                    {
                        // Executa o código na thread de interface do usuário usando Invoke
                        Invoke((MethodInvoker)(() => txtPotenciaBomba.Text = Convert.ToString(Globals.pumpPowerData.Last())));
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

            if (Globals.controlTypeRes == 1 || Globals.controlTypeRes == 2 || Globals.controlTypeRes == 3 || Globals.controlTypeRes == 4)
            {
                try
                {
                    if (!IsDisposed && txtPotenciaBomba.InvokeRequired)
                    {
                        // Executa o código na thread de interface do usuário usando Invoke
                        Invoke((MethodInvoker)(() => txtPotenciaResistencia.Text = Convert.ToString(Globals.resPowerData.Last())));
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
                    txtIntegralVazao.ReadOnly = true;
                    txtDerivativoVazao.ReadOnly = true;
                    Globals.showHysteresisVazao = false;
                    Globals.showSPVazao = false;

                    // Definir cores dos TextBox
                    //txtPotenciaBomba.BackColor = Color.White;
                    //txtHysteresisVazao.BackColor = Color.Gainsboro;
                    //txtGanhoVazao.BackColor = Color.Gainsboro;
                    //txtIntegralVazao.BackColor = Color.Gainsboro;
                    //txtDerivativoVazao.BackColor = Color.Gainsboro;
                    break;

                case 1: // ON-OFF

                    txtPotenciaBomba.ReadOnly = true;
                    txtHysteresisVazao.ReadOnly = false;
                    txtGanhoVazao.ReadOnly = true;
                    txtIntegralVazao.ReadOnly = true;
                    txtDerivativoVazao.ReadOnly = true;
                    Globals.showHysteresisVazao = true;
                    Globals.showSPVazao = true;

                    // Definir cores dos TextBox
                    //txtPotenciaBomba.BackColor = Color.Gainsboro;
                    //txtHysteresisVazao.BackColor = Color.White;
                    //txtGanhoVazao.BackColor = Color.Gainsboro;
                    //txtIntegralVazao.BackColor = Color.Gainsboro;
                    //txtDerivativoVazao.BackColor = Color.Gainsboro;
                    break;

                case 2: // Controle Proporcional
                    txtPotenciaBomba.ReadOnly = true;
                    txtHysteresisVazao.ReadOnly = true;
                    txtGanhoVazao.ReadOnly = false;
                    txtIntegralVazao.ReadOnly = true;
                    txtDerivativoVazao.ReadOnly = true;
                    Globals.showHysteresisVazao = false;
                    Globals.showSPVazao = true;

                    // Definir cores dos TextBox
                    //txtPotenciaBomba.BackColor = Color.Gainsboro;
                    //txtHysteresisVazao.BackColor = Color.Gainsboro;
                    //txtGanhoVazao.BackColor = Color.White;
                    //txtIntegralVazao.BackColor = Color.Gainsboro;
                    //txtDerivativoVazao.BackColor = Color.Gainsboro;

                    MessageBox.Show("O Controle Propocional digital, implementado na forma de velocidade, não é viável (não controla). Está disponível aqui somente para fins didáticos, mas o controle mais simples que pode ser implementado é o Controle PI","ALERTA!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    break;

                case 3: // Controle Proporcional Integral
                    txtPotenciaBomba.ReadOnly = true;
                    txtHysteresisVazao.ReadOnly = true;
                    txtGanhoVazao.ReadOnly = false;
                    txtIntegralVazao.ReadOnly = false;
                    txtDerivativoVazao.ReadOnly = true;
                    Globals.showHysteresisVazao = false;
                    Globals.showSPVazao = true;

                    // Definir cores dos TextBox
                    //txtPotenciaBomba.BackColor = Color.Gainsboro;
                    //txtHysteresisVazao.BackColor = Color.Gainsboro;
                    //txtGanhoVazao.BackColor = Color.White;
                    //txtIntegralVazao.BackColor = Color.White;
                    //txtDerivativoVazao.BackColor = Color.Gainsboro;
                    break;

                case 4: // Controle Proporcional Integral e Derivativo
                    txtPotenciaBomba.ReadOnly = true;
                    txtHysteresisVazao.ReadOnly = true;
                    txtGanhoVazao.ReadOnly = false;
                    txtIntegralVazao.ReadOnly = false;
                    txtDerivativoVazao.ReadOnly = false;
                    Globals.showHysteresisVazao = false;
                    Globals.showSPVazao = true;

                    // Definir cores dos TextBox
                    //txtPotenciaBomba.BackColor = Color.Gainsboro;
                    //txtHysteresisVazao.BackColor = Color.Gainsboro;
                    //txtGanhoVazao.BackColor = Color.White;
                    //txtIntegralVazao.BackColor = Color.White;
                    //txtDerivativoVazao.BackColor = Color.White;
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
                    "Ganho do controlador: " + Globals.ganhoVazao + " L h-1 %-1",
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
                    Globals.showHysteresisTemp = false;
                    Globals.showSPTemp = false;

                    // Definir cores dos TextBox
                   // txtPotenciaResistencia.BackColor = Color.White;
                   // txtHysteresisTemp.BackColor = Color.Gainsboro;
                   /// txtGanhoTemp.BackColor = Color.Gainsboro;
                   // txtIntegralTemp.BackColor = Color.Gainsboro;
                   // txtDerivativoTemp.BackColor = Color.Gainsboro;

                    break;
                case 1: // ON-OFF
                    txtPotenciaResistencia.ReadOnly = true;
                    txtHysteresisTemp.ReadOnly = false;
                    txtGanhoTemp.ReadOnly = true;
                    txtIntegralTemp.ReadOnly = true;
                    txtDerivativoTemp.ReadOnly = true;
                    Globals.showHysteresisTemp = true;
                    Globals.showSPTemp = true;


                    // Definir cores dos TextBox
                   // txtPotenciaResistencia.BackColor = Color.Gainsboro;
                   // txtHysteresisTemp.BackColor = Color.White;
                   // txtGanhoTemp.BackColor = Color.Gainsboro;
                   // txtIntegralTemp.BackColor = Color.Gainsboro;
                   // txtDerivativoTemp.BackColor = Color.Gainsboro;
                    break;
                case 2: // Controle Proporcional
                    txtPotenciaResistencia.ReadOnly = true;
                    txtHysteresisTemp.ReadOnly = true;
                    txtGanhoTemp.ReadOnly = false;
                    txtIntegralTemp.ReadOnly = true;
                    txtDerivativoTemp.ReadOnly = true;
                    Globals.showHysteresisTemp = false;
                    Globals.showSPTemp = true;


                    // Definir cores dos TextBox
                    // txtPotenciaResistencia.BackColor = Color.Gainsboro;
                    // txtHysteresisTemp.BackColor = Color.Gainsboro;
                    // txtGanhoTemp.BackColor = Color.White;
                    // txtIntegralTemp.BackColor = Color.Gainsboro;
                    // txtDerivativoTemp.BackColor = Color.Gainsboro;


                    MessageBox.Show("O Controle Propocional digital, implementado na forma de velocidade, não é viável (não controla). Está disponível aqui somente para fins didáticos, mas o controle mais simples que pode ser implementado é o Controle PI", "ALERTA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 3: // Controle Proporcional Integral
                    txtPotenciaResistencia.ReadOnly = true;
                    txtHysteresisTemp.ReadOnly = true;
                    txtGanhoTemp.ReadOnly = false;
                    txtIntegralTemp.ReadOnly = false;
                    txtDerivativoTemp.ReadOnly = true;
                    Globals.showHysteresisTemp = false;
                    Globals.showSPTemp = true;


                    // Definir cores dos TextBox
                  //  txtPotenciaResistencia.BackColor = Color.Gainsboro;
                   // txtHysteresisTemp.BackColor = Color.Gainsboro;
                   // txtGanhoTemp.BackColor = Color.White;
                   // txtIntegralTemp.BackColor = Color.White;
                   // txtDerivativoTemp.BackColor = Color.Gainsboro;
                    break;
                case 4: // Controle Proporcional Integral e Derivativo
                    txtPotenciaResistencia.ReadOnly = true;
                    txtHysteresisTemp.ReadOnly = true;
                    txtGanhoTemp.ReadOnly = false;
                    txtIntegralTemp.ReadOnly = false;
                    txtDerivativoTemp.ReadOnly = false;
                    Globals.showHysteresisTemp = false;


                    // Definir cores dos TextBox
                    //txtPotenciaResistencia.BackColor = Color.Gainsboro;
                   // txtHysteresisTemp.BackColor = Color.Gainsboro;
                   // txtGanhoTemp.BackColor = Color.White;
                   // txtIntegralTemp.BackColor = Color.White;
                   // txtDerivativoTemp.BackColor = Color.White;
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
    }
}
