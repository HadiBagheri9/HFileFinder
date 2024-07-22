﻿using System.Net;
using System.Net.Mail;

namespace HFileFinder
{
    class Send
    {
        public static bool SendEmail(string from, string password, string displayName, string to, string subject, string body)
        {
            bool flag = true;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from, displayName);
            mail.To.Add(to);
            mail.Subject = subject;
            //mail.Body = body;
            mail.Attachments.Add(new Attachment(body));
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(from, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);


            return flag;
        }
    }
}