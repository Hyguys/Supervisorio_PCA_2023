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
    public partial class SubFormLimitsResPump : Form
    {
        public SubFormLimitsResPump()
        {
            InitializeComponent();
        }

        private void SubFormLimitsResPump_Load(object sender, EventArgs e)
        {
            txtUpperPump.Text = Globals.upperLimitPump.ToString("0.00");
            txtLowerPump.Text = Globals.lowerLimitPump.ToString("0.00");
            txtUpperRes.Text = Globals.upperLimitRes.ToString("0.00");
            txtLowerRes.Text = Globals.lowerLimitRes.ToString("0.00");
        }

        private void txtUpperPump_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUpperPump_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtUpperPump.Text, out float upperPump) || upperPump < 0 || upperPump > 100)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 100.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUpperPump.Text = Globals.upperLimitPump.ToString("0.00");
                return;
            }

            Globals.upperLimitPump = upperPump;
            string command = "ULP " + upperPump.ToString("0.00");
            Globals.serialPort.WriteLine(command);
            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtLowerPump_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtLowerPump.Text, out float lowerPump) || lowerPump < 0 || lowerPump > 100)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 100.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLowerPump.Text = Globals.upperLimitPump.ToString("0.00");
                return;
            }

            Globals.upperLimitPump = lowerPump;
            string command = "LLP " + lowerPump.ToString("0.00");
            Globals.serialPort.WriteLine(command);
            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtUpperRes_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtUpperRes.Text, out float upperRes) || upperRes < 0 || upperRes > 100)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 100.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUpperRes.Text = Globals.upperLimitRes.ToString("0.00");
                return;
            }

            Globals.upperLimitRes = upperRes;
            string command = "ULR " + upperRes.ToString("0.00");
            Globals.serialPort.WriteLine(command);
            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtLowerRes_KeyDown(object sender, KeyEventArgs e)
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

            if (!float.TryParse(txtLowerRes.Text, out float lowerRes) || lowerRes < 0 || lowerRes > 100)
            {
                MessageBox.Show("Digite um valor decimal entre 0 e 100.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLowerRes.Text = Globals.upperLimitRes.ToString("0.00");
                return;
            }

            Globals.upperLimitRes = lowerRes;
            string command = "LLR " + lowerRes.ToString("0.00");
            Globals.serialPort.WriteLine(command);
            MessageBox.Show("Comando " + command + " enviado com sucesso.", "Envio do comando!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}
