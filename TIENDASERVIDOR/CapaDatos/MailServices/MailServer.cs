using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows;

namespace CapaDatos.MailServices
{
    public abstract class MailServer
    {
        private SmtpClient smtpClient;
        private string senderMail;
        private string password;
        private string host;
        private int port;
        private bool ssl;

        public SmtpClient SmtpClient { get => smtpClient; set => smtpClient = value; }
        protected string SenderMail { get => senderMail; set => senderMail = value; }
        protected string Password { get => password; set => password = value; }
        protected string Host { get => host; set => host = value; }
        protected int Port { get => port; set => port = value; }
        protected bool Ssl { get => ssl; set => ssl = value; }

        protected void InitializeSmtpClient()
        {
            SmtpClient = new SmtpClient
            {
                Credentials = new NetworkCredential(SenderMail, Password),
                Host = Host,
                Port = Port,
                EnableSsl = Ssl
            };
        }
        public void SendMail(string subject, string body, List<string> recipientMail)
        {
            var mailMessage = new MailMessage();
            try
            {
                mailMessage.From = new MailAddress(SenderMail);
                foreach (string mail in recipientMail)
                {
                    mailMessage.To.Add(mail);
                }
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.Priority = MailPriority.Normal;
                SmtpClient.Send(mailMessage);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al enviar el email: " + ex.Message);
            }
            finally
            {
                mailMessage.Dispose();
                SmtpClient.Dispose();
            }
        }

    } 
}
