using System;
using System.Collections.Generic;
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

        public static bool defaultIsRecordingData = false;
        public static int defaultIntervalSampling = 500;

        public static bool defaultShowHysteresisTemp = false;
        public static bool defaultShowHysteresisVazao = false;
        public static bool defaultShowSPTemp = false;
        public static bool defaultShowSPVazao = false;

        public static int defaultNumberFlowPoints = 10;
        public static int defaultMediaMovelFlow = 5;
        public static double defaultAlfaFlow = 0.4;

        public static int defaultNumberTempPoints = 20;
        public static int defaultMediaMovelTemp = 5;
        public static double defaultAlfaTemp = 0.1;

        public static double defaultPumpPower = 0;
        public static double defaultSetpointVazao = 30;
        public static double defaultHistereseVazao = 10;
        public static double defaultGanhoVazao = 1;
        public static double defaultIntegralVazao = 100;
        public static double defaultDerivativoVazao = 10;

        public static double defaultResPower = 0;
        public static double defaultSetpointTemp = 30;
        public static double defaultHistereseTemp = 3;
        public static double defaultGanhoTemp = 500;
        public static double defaultIntegralTemp = 10;
        public static double defaultDerivativoTemp = 5;

        public static int defaultControlTypeRes = 0;
        public static int defaultControlTypePump = 0;


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

    }

}
