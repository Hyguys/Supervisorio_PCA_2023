using ScottPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supervisório_PCA_2._0
{
    public static class Globals
    {

        //apesar de declarada aqui, a serialPort global esta inicializada no mainForm
        public static SerialPort serialPort;

        public static bool serialConnected = false; //variável global que armazena o estado global da conexão com a porta serial

        public static List<double> timeFlowData = new List<double>();
        public static List<double> timeTempData = new List<double>();
        public static List<double> flowData = new List<double>();
        public static List<double> flowSPData = new List<double>();
        public static List<double> pumpPowerData = new List<double>();
        public static List<double> hysteresisFlowData = new List<double>();
        public static List<double> hysteresisFlowUpperLimitData = new List<double>();
        public static List<double> hysteresisFlowLowerLimitData = new List<double>();

        public static List<double> tempInData = new List<double>();
        public static List<double> tempOutData = new List<double>();
        public static List<double> tempSPData = new List<double>();
        public static List<double> resPowerData = new List<double>();
        public static List<double> hysteresisTempData = new List<double>();
        public static List<double> hysteresisTempUpperLimitData = new List<double>();
        public static List<double> hysteresisTempLowerLimitData = new List<double>();

        public static List<double> pureTempOutData = new List<double>();
        public static List<double> pureFlowData = new List<double>();

        public static List<double> timeModelData = new List<double>();
        public static List<double> flowModelCalc = new List<double>();
        public static List<double> tempModelCalc = new List<double>();

        /*SEÇÃO VALORES PADRÃO VARIÁVEIS GLOBAIS*/
        public static int globalListsNumber = 13;

        public static bool defaultIsRecordingData = false;
        public static int defaultIntervalSampling = 250;

        public static bool defaultShowHysteresisTemp = false;
        public static bool defaultShowHysteresisVazao = false;
        public static bool defaultShowSPTemp = false;
        public static bool defaultShowSPVazao = false;

        public static int defaultNumberFlowPoints = 5*1000/250;
        public static int defaultMediaMovelFlow = 8;
        public static double defaultAlfaFlow = 0.4;

        public static int defaultNumberTempPoints = 10 * 1000 / 250;
        public static int defaultMediaMovelTemp = 10;
        public static double defaultAlfaTemp = 0.1;

        public static double defaultPumpPower = 0;
        public static double defaultSetpointVazao = 35;
        public static double defaultHistereseVazao = 10;
        public static double defaultGanhoVazao = 2;
        public static double defaultIntegralVazao = 2;
        public static double defaultDerivativoVazao = 1;

        public static double defaultResPower = 0;
        public static double defaultSetpointTemp = 30;
        public static double defaultHistereseTemp = 3;
        public static double defaultGanhoTemp = 500;
        public static double defaultIntegralTemp = 10;
        public static double defaultDerivativoTemp = 5;

        public static int defaultControlTypeRes = 0;
        public static int defaultControlTypePump = 0;

        public static bool defaultRampFlowSP = false;
        public static bool defaultRampTempSP = false;

        public static double defaultAlfaDerivativoBomba = 0.5;
        public static double defaultAlfaDerivativoResistencia = 0.5;

        public static double defaultLowerLimitPump = 0;
        public static double defaultUpperLimitPump = 100;

        public static double defaultLowerLimitRes = 0;
        public static double defaultUpperLimitRes = 100;



        public static bool defaultExibirGridVazao = true;
        public static bool defaultExibirLegendaVazao = true;
        public static bool defaultExibirPotenciaBomba = true;
        public static bool defaultExibirVazaoPreFiltragem = false;
        public static bool defaultExibirPrevisaoVazao = false;
        public static int defaultMarkerSizeVazao = 3;
        public static int defaultLineSizeVazao = 1;
        public static int defaultHistoricoVazao = 5;
        public static Color defaultCorVazao = Color.Blue;
        public static Color defaultCorSPVazao = Color.Green;
        public static Color defaultCorPotenciaBomba = Color.DarkMagenta;
        public static Color defaultCorVazaoPrefiltragem = Color.LightBlue;

        public static bool defaultExibirGridTemp = true;
        public static bool defaultExibirLegendaTemp = true;
        public static bool defaultExibirPotenciaResistencia = true;
        public static bool defaultExibirTempEntrada = false;
        public static bool defaultExibirTempPreFiltragem = false;
        public static bool defaultExibirPrevisaoTemp = false;
        public static int defaultMarkerSizeTemp = 3;
        public static int defaultLineSizeTemp = 1;
        public static int defaultHistoricoTemp = 10;
        public static Color defaultCorTemp = Color.Red;
        public static Color defaultCorSPTemp = Color.Green;
        public static Color defaultCorPotenciaRes = Color.DarkMagenta;
        public static Color defaultCorTempPrefiltragem = Color.DarkSalmon;
        public static Color defaultCorTempEntrada = Color.Navy;



        /*SEÇÃO INICIALIZAÇÃO VARIÁVEIS GLOBAIS*/
        public static bool isRecordingData = defaultIsRecordingData;
        public static int intervalSampling = defaultIntervalSampling;

        public static bool showHysteresisTemp = defaultShowHysteresisTemp;
        public static bool showHysteresisVazao = defaultShowHysteresisVazao;
        public static bool showSPTemp = defaultShowSPTemp;
        public static bool showSPVazao = defaultShowSPVazao;

        public static int numberFlowPoints = defaultNumberFlowPoints;
        public static int mediaMovelFlow = defaultMediaMovelFlow;
        public static double alfaFlow = defaultAlfaFlow;

        public static int numberTempPoints = defaultNumberTempPoints;
        public static int mediaMovelTemp = defaultMediaMovelTemp;
        public static double alfaTemp = defaultAlfaTemp;

        public static double pumpPower = defaultPumpPower;
        public static double setpointVazao = defaultSetpointVazao;
        public static double histereseVazao = defaultHistereseVazao;
        public static double ganhoVazao = defaultGanhoVazao;
        public static double integralVazao = defaultIntegralVazao;
        public static double derivativoVazao = defaultDerivativoVazao;

        public static double resPower = defaultResPower;
        public static double setpointTemp = defaultSetpointTemp;
        public static double histereseTemp = defaultHistereseTemp;
        public static double ganhoTemp = defaultGanhoTemp;
        public static double integralTemp = defaultIntegralTemp;
        public static double derivativoTemp = defaultDerivativoTemp;

        public static int controlTypeRes = defaultControlTypeRes;
        public static int controlTypePump = defaultControlTypePump;

        public static bool RampFlowSP = defaultRampFlowSP;
        public static bool RampTempSP = defaultRampTempSP;

        public static double alfaDerivativoBomba = defaultAlfaDerivativoBomba;
        public static double alfaDerivativoResistencia = defaultAlfaDerivativoResistencia;


        public static double lowerLimitPump = defaultLowerLimitPump;
        public static double upperLimitPump = defaultUpperLimitPump;

        public static double lowerLimitRes = defaultLowerLimitRes;
        public static double upperLimitRes = defaultLowerLimitRes;





        public static bool ExibirGridVazao = defaultExibirGridVazao;
        public static bool ExibirLegendaVazao = defaultExibirLegendaVazao;
        public static bool ExibirPotenciaBomba = defaultExibirPotenciaBomba;
        public static bool ExibirVazaoPreFiltragem = defaultExibirVazaoPreFiltragem;
        public static bool ExibirPrevisaoVazao = defaultExibirPrevisaoVazao;
        public static int MarkerSizeVazao = defaultMarkerSizeVazao;
        public static int LineSizeVazao = defaultLineSizeVazao;
        public static double HistoricoVazao = defaultHistoricoVazao;
        public static Color CorVazao = defaultCorVazao;
        public static Color CorSPVazao = defaultCorSPVazao;
        public static Color CorPotenciaBomba = defaultCorPotenciaBomba;
        public static Color CorVazaoPrefiltragem = defaultCorVazaoPrefiltragem;

        public static bool ExibirGridTemp = defaultExibirGridTemp;
        public static bool ExibirLegendaTemp = defaultExibirLegendaTemp;
        public static bool ExibirPotenciaResistencia = defaultExibirPotenciaResistencia;
        public static bool ExibirTempEntrada = defaultExibirTempEntrada;
        public static bool ExibirTempPreFiltragem = defaultExibirTempPreFiltragem;
        public static bool ExibirPrevisaoTemp = defaultExibirPrevisaoTemp;
        public static int MarkerSizeTemp = defaultMarkerSizeTemp;
        public static int LineSizeTemp = defaultLineSizeTemp;
        public static double HistoricoTemp = defaultHistoricoTemp;
        public static Color CorTemp = defaultCorTemp;
        public static Color CorSPTemp = defaultCorSPTemp;
        public static Color CorPotenciaRes = defaultCorPotenciaRes;
        public static Color CorTempPrefiltragem = defaultCorTempPrefiltragem;
        public static Color CorTempEntrada = defaultCorTempEntrada;

        public static double KpVazao;
        public static double TauVazao;
        public static double ThetaVazao;

        public static double KpTemp;
        public static double TauTemp;
        public static double ThetaTemp;
    }

}
