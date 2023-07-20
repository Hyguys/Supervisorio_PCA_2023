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
    public partial class SubFormConfigGraficos : Form
    {
        public SubFormConfigGraficos()
        {
            InitializeComponent();
        }

        private void SubFormConfigGraficos_Load(object sender, EventArgs e)
        {
            checkGridVazao.Checked = Globals.ExibirGridVazao;
            checkLegendaVazao.Checked = Globals.ExibirLegendaVazao;
            checkPotenciaBomba.Checked = Globals.ExibirPotenciaBomba;
            checkVazaoPrefiltragem.Checked = Globals.ExibirVazaoPreFiltragem;
            numHistoricoTempoVazao.Value = (decimal)Globals.HistoricoVazao;
            numMarkerSizeVazao.Value = Globals.MarkerSizeVazao;
            numLineSizeVazao.Value = Globals.LineSizeVazao;

            checkGridTemp.Checked = Globals.ExibirGridTemp;
            checkLegendaTemp.Checked = Globals.ExibirLegendaTemp;
            checkPotenciaRes.Checked = Globals.ExibirPotenciaResistencia;
            checkTempEntrada.Checked = Globals.ExibirTempEntrada;
            checkTempPrefiltragem.Checked = Globals.ExibirTempPreFiltragem;
            numHistoricoTempoTemp.Value = (decimal)Globals.HistoricoTemp;
            numMarkerSizeTemp.Value = Globals.MarkerSizeTemp;
            numLineSizeTemp.Value = Globals.LineSizeTemp;

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkGridVazao.Checked)
            {
                Globals.ExibirGridVazao = true;
            }
            else
            {

                Globals.ExibirGridVazao = false;
            }
        }

        private void checkLegendaVazao_CheckedChanged(object sender, EventArgs e)
        {
            if(checkLegendaVazao.Checked)
            {
                Globals.ExibirLegendaVazao = true;
            }
            else
            {

                Globals.ExibirLegendaVazao = false;
            }
        }

        private void checkPotenciaBomba_CheckedChanged(object sender, EventArgs e)
        {
            if(checkPotenciaBomba.Checked)
            {
                Globals.ExibirPotenciaBomba = true;
            }
            else
            {
                Globals.ExibirPotenciaBomba = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.CorVazao = GlobalMethods.ColorPicker(Globals.CorVazao);
       
        }

        private void checkVazaoPrefiltragem_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVazaoPrefiltragem.Checked)
            {
                Globals.ExibirVazaoPreFiltragem = true;
            }
            else
            {
                Globals.ExibirVazaoPreFiltragem = false;
            }
        }

        private void btnCorSetpointVazao_Click(object sender, EventArgs e)
        {
            Globals.CorSPVazao = GlobalMethods.ColorPicker(Globals.CorSPVazao);
        }

        private void btnCorPotenciaBomba_Click(object sender, EventArgs e)
        {
            Globals.CorPotenciaBomba = GlobalMethods.ColorPicker(Globals.CorPotenciaBomba);

        }

        private void btnCorVazaoPrefiltragem_Click(object sender, EventArgs e)
        {
            Globals.CorVazaoPrefiltragem = GlobalMethods.ColorPicker(Globals.CorVazaoPrefiltragem);

        }

        private void numHistoricoTempo_ValueChanged(object sender, EventArgs e)
        {
            Globals.HistoricoVazao = (double)numHistoricoTempoVazao.Value;
            Globals.numberFlowPoints = (int)Math.Ceiling(((double)numHistoricoTempoVazao.Value * 1000.0) / Globals.intervalSampling);
        }

        private void numMarkerSizeVazao_ValueChanged(object sender, EventArgs e)
        {
            Globals.MarkerSizeVazao = (int)numMarkerSizeVazao.Value;
        }

        private void numLineSizeVazao_ValueChanged(object sender, EventArgs e)
        {
            Globals.LineSizeVazao = (int)numLineSizeVazao.Value;
        }

        private void checkGridTemp_CheckedChanged(object sender, EventArgs e)
        {
            if (checkGridTemp.Checked)
            {
                Globals.ExibirGridTemp = true;
            }
            else
            {

                Globals.ExibirGridTemp = false;
            }
        }

        private void checkLegendaTemp_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLegendaTemp.Checked)
            {
                Globals.ExibirLegendaTemp = true;
            }
            else
            {

                Globals.ExibirLegendaTemp = false;
            }
        }

        private void checkPotenciaRes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPotenciaRes.Checked)
            {
                Globals.ExibirPotenciaResistencia = true;
            }
            else
            {
                Globals.ExibirPotenciaResistencia = false;
            }
        }

        private void checaTempPrefiltragem_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTempPrefiltragem.Checked)
            {
                Globals.ExibirTempPreFiltragem = true;
            }
            else
            {
                Globals.ExibirTempPreFiltragem = false;
            }
        }

        private void checkTempEntrada_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTempEntrada.Checked)
            {
                Globals.ExibirTempEntrada = true;
            }
            else
            {
                Globals.ExibirTempEntrada = false;
            }
        }

        private void btnCorTemp_Click(object sender, EventArgs e)
        {
            Globals.CorTemp = GlobalMethods.ColorPicker(Globals.CorTemp);

        }

        private void btnCorSetpointTemp_Click(object sender, EventArgs e)
        {
            Globals.CorSPTemp = GlobalMethods.ColorPicker(Globals.CorSPTemp);

        }

        private void btnCorPotenciaRes_Click(object sender, EventArgs e)
        {
            Globals.CorPotenciaRes = GlobalMethods.ColorPicker(Globals.CorPotenciaRes);

        }

        private void btnCorTempPrefiltragem_Click(object sender, EventArgs e)
        {
            Globals.CorTempPrefiltragem= GlobalMethods.ColorPicker(Globals.CorTempPrefiltragem);

        }

        private void btnCorTempEntrada_Click(object sender, EventArgs e)
        {
            Globals.CorTempEntrada = GlobalMethods.ColorPicker(Globals.CorTempEntrada);

        }

        private void numHistoricoTempoTemp_ValueChanged(object sender, EventArgs e)
        {
            Globals.HistoricoTemp = (double)numHistoricoTempoTemp.Value;
            Globals.numberTempPoints = (int)Math.Ceiling(((double)numHistoricoTempoTemp.Value * 1000.0) / Globals.intervalSampling);

        }

        private void numMarkerSizeTemp_ValueChanged(object sender, EventArgs e)
        {
            Globals.MarkerSizeTemp = (int)numMarkerSizeTemp.Value;

        }

        private void numLineSizeTemp_ValueChanged(object sender, EventArgs e)
        {
            Globals.LineSizeTemp = (int)numLineSizeTemp.Value;

        }
    }
}
