using Supervisório_PCA_2._0;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisório_PCA_2023
{
    public partial class SubFormConfigModeloFOPTD : Form
    {
        public SubFormConfigModeloFOPTD()
        {
            InitializeComponent();
        }

        private void SubFormConfigModeloFOPTD_Load(object sender, EventArgs e)
        {
            tabelaVazao.Rows.Add("0.7", "1.5", "0.8");
            tabelaTemperatura.Rows.Add("0.010", "650", "10");
            MessageBox.Show("Atenção, essa funcionalidade não está completa. Portanto, não vai funcionar e você está vendo uma prévia.");
        }

        private void tabelaVazao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabelaVazao_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
             }

        private void tabelaTemperatura_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Globals.ExibirPrevisaoVazao = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Globals.ExibirPrevisaoTemp = checkBox2.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.KpVazao = Convert.ToDouble(tabelaVazao.Rows[0].Cells[0].Value);
            Globals.TauVazao = Convert.ToDouble(tabelaVazao.Rows[0].Cells[1].Value);
            Globals.ThetaVazao = Convert.ToDouble(tabelaVazao.Rows[0].Cells[2].Value);

            MessageBox.Show("Cadastramento do modelo FOPTD para o sistema de vazão realizado com sucesso!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tabelaTemperatura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTemp_Click(object sender, EventArgs e)
        {
            
            Globals.KpTemp = Convert.ToDouble(tabelaTemperatura.Rows[0].Cells[0].Value);
            Globals.TauTemp = Convert.ToDouble(tabelaTemperatura.Rows[0].Cells[1].Value);
            Globals.ThetaTemp = Convert.ToDouble(tabelaTemperatura.Rows[0].Cells[2].Value);

            MessageBox.Show("Cadastramento do modelo FOPTD para o sistema de temperatura realizado com sucesso!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
