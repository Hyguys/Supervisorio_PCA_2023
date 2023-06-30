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

        // outras variáveis globais aqui...
    }

}
