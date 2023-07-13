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
        public static SerialPort serialPort;

        public static bool serialConnected = false; //variável global que armazena o estado global da conexão com a porta serial

        public static List<double> timeFlowData = new List<double>();
        public static List<double> timeTempData = new List<double>();
        public static List<double> flowData = new List<double>();
        public static List<double> flowSPData = new List<double>();
        public static List<double> pumpPowerData = new List<double>();
        public static List<double> hysteresisFlowData = new List<double>();
        public static List<double> tempInData = new List<double>();
        public static List<double> tempOutData = new List<double>();
        public static List<double> tempSPData = new List<double>();
        public static List<double> resPowerData = new List<double>();
        public static List<double> hysteresisTempData = new List<double>();

        public static bool isRecordingData = false;
        public static int intervalSampling = 500;

        public static int numberFlowPoints = 10;
        public static int mediaMovelFlow = 5;
        public static double alfaFlow = 0.4;

        public static int numberTempPoints = 20;
        public static int mediaMovelTemp = 5;
        public static double alfaTemp = 0.1;

        public static double pumpPower = 0;
        public static double setpointVazao = 30;
        public static double histereseVazao = 10;
        public static double ganhoVazao = 1;
        public static double integralVazao = 100;
        public static double derivativoVazao = 10;

        public static double resPower = 0;
        public static double setpointTemp = 30;
        public static double histereseTemp = 3;
        public static double ganhoTemp = 500;
        public static double integralTemp = 10;
        public static double derivativoTemp = 5;

        public static int controlTypeRes = 0;
        public static int controlTypePump = 0;
    }

}
