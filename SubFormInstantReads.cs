using Supervisório_PCA_2._0;
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

namespace Supervisório_PCA_2023
{
    public partial class SubFormInstantReads : Form
    {
        bool isHalted = false;
        bool isColor = true;
        public SubFormInstantReads()
        {
            InitializeComponent();
            Globals.serialPort.DataReceived += new SerialDataReceivedEventHandler(SubFormDataReceivedHandler);
            
        }

        private void SubFormInstantReads_Load(object sender, EventArgs e)
        {
            
        }
        private void AlterarTexto(Label txtbox, double valor)
        {
            AlterarTexto(txtbox, Convert.ToString(valor));
        }

        private void AlterarTexto(Label txtbox, string texto)
        {
            try
            {
                if (!IsDisposed && txtbox.InvokeRequired)
                {
                    // Executa o código na thread de interface do usuário usando Invoke
                    BeginInvoke((MethodInvoker)(() => txtbox.Text = texto));
                }
                else
                {
                    // Atualiza diretamente o controle na thread de interface do usuário
                    txtbox.Text = texto;
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


        private void SubFormDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (isHalted)
            {
                return;
            }
            try
            {
                AlterarTexto(txtTempIn, Globals.tempInData.Last());
                AlterarTexto(txtTempOut, Globals.tempOutData.Last());
                AlterarTexto(txtPotRes, Globals.resPowerData.Last());
                AlterarTexto(txtSPTemp, Globals.tempSPData.Last());

                AlterarTexto(txtPotBomba, Globals.pumpPowerData.Last());
                AlterarTexto(txtSPVazao, Globals.flowSPData.Last());
                AlterarTexto(txtFlow, Globals.flowData.Last());
            }
            catch
            {
               
            }




            switch (Globals.controlTypePump)
            {
                case 0:
                    AlterarTexto(txtControlTypePump, "MANUAL");
                    break;
                case 1:

                    AlterarTexto(txtControlTypePump, "ON-OFF"); 
                    break;
                case 2:

                    AlterarTexto(txtControlTypePump, "P"); 
                    break;
                case 3:

                    AlterarTexto(txtControlTypePump, "PI");
                    break;
                case 4:

                    AlterarTexto(txtControlTypePump, "PID");
                    break;
                case 5:

                    AlterarTexto(txtControlTypePump, "PID-fd");
                    break;
            }

            switch (Globals.controlTypeRes)
            {
                case 0:
                    AlterarTexto(txtControlTypeRes, "MANUAL");
                    break;
                case 1:

                    AlterarTexto(txtControlTypeRes, "ON-OFF");
                    break;
                case 2:

                    AlterarTexto(txtControlTypeRes, "P");
                    break;
                case 3:

                    AlterarTexto(txtControlTypeRes, "PI");
                    break;
                case 4:

                    AlterarTexto(txtControlTypeRes, "PID");
                    break;
                case 5:

                    AlterarTexto(txtControlTypeRes, "PID-fd");
                    break;
                case 6:

                    AlterarTexto(txtControlTypeRes, "Cascata P");
                    break;
                case 7:

                    AlterarTexto(txtControlTypeRes, "Cascata PI");
                    break;
                case 8:

                    AlterarTexto(txtControlTypeRes, "Cascata PID");
                    break;

            }
            if (isColor)
            {
                txtTempIn.ForeColor = Globals.CorTempEntrada;
                txtTempOut.ForeColor = Globals.CorTemp;
                txtPotRes.ForeColor = Globals.CorPotenciaRes;
                txtSPTemp.ForeColor = Globals.CorSPTemp;

                txtFlow.ForeColor = Globals.CorVazao;
                txtPotBomba.ForeColor = Globals.CorPotenciaBomba;
                txtSPVazao.ForeColor = Globals.CorSPVazao;

            }
            else
            {
                txtTempIn.ForeColor = Color.Black;
                txtTempOut.ForeColor = Color.Black;
                txtPotRes.ForeColor = Color.Black;
                txtSPTemp.ForeColor = Color.Black;

                txtFlow.ForeColor = Color.Black;
                txtPotBomba.ForeColor = Color.Black;
                txtSPVazao.ForeColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(btnPause.Text=="Pausar")
            {
                isHalted = true;
                btnPause.Text = "Retomar";
            }
            else
            {
                isHalted = false;
                btnPause.Text = "Pausar";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            isColor = checkBox2.Checked;
        }
    }
}
