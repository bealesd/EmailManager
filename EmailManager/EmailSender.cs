using System;
using System.Net;
using System.Net.Mail;

namespace EmailManager
{
    public class EmailSender
    {
        public string SmtpClient { get; set; }
        public int SmtpPort { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string MessageBody { get; set; }
        public string MessageSubject { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public EmailSender()
        {
            SmtpClient = "smtp.gmail.com";
            SmtpPort = 587;
        }
        public void SendEmail()
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                var smtpServer = new SmtpClient(SmtpClient);

                mailMessage.From = new MailAddress(From);
                mailMessage.To.Add(To);
                mailMessage.Subject = MessageSubject;
                mailMessage.Body = MessageBody;

                smtpServer.Port = SmtpPort;
                smtpServer.Credentials = new NetworkCredential(Username, Password);
                smtpServer.EnableSsl = true;

                smtpServer.Send(mailMessage);
            }
            catch (Exception)
            {
                throw new SmtpException("Message not sent.");
            }
        }
    }
}