using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BlueboxBack.Core.Log
{
    class Logger
    {
        public static void Info(string message)
        {
            InfoLine(message + '\n' + '\r');
        }
        public static void InfoLine(string message)
        {
            StackTrace st = new StackTrace();
            Console.Write("{0}", message);
        }
    }
}
