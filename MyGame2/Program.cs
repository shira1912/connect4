using System;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ConnectFour
{
    internal static class Program
    {
        private const int portNo = 5000;
        private const string ipAddress = "127.0.0.1";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }
    }
}
