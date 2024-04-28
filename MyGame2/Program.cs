using System;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

//public class MultiFormContext : ApplicationContext
//{
//    private int openForms;

//    public MultiFormContext(params Form[] forms)
//    {
//        openForms = forms.Length;

//        foreach (var form in forms)
//        {
//            form.FormClosed += (s, args) =>
//            {
//                // When we have closed the last of the "starting" forms, 
//                // end the program.
//                if (Interlocked.Decrement(ref openForms) == 0)
//                    ExitThread();
//            };

//            form.Show();
//        }
//    }
//}

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
            Console.WriteLine("Connecting to ip {0} port: {1}", ipAddress, portNo);

            TcpClient tcpclient = new TcpClient();
            tcpclient.Connect(ipAddress, portNo);

            Console.WriteLine("Client is ready.");
            NetworkStream ns = tcpclient.GetStream();

            Application.Run(new Form1(ns));
        }
    }
}
