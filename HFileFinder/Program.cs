using System;

namespace HFileFinder
{
    class Program
    {
        private string email = "email";
        private string password = "password";
        private string to = "to";
        private string displayName = "HFileFinder";
        private string subject = Environment.MachineName + "/" + Environment.UserName + " : ";
        private string body = "";

        static void Main(string[] args)
        {
            FileFinder.Main();



            int filesCount = FileFinder.path.Length;
        }
    }
}
