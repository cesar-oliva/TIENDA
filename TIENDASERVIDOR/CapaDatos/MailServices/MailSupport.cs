using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.MailServices
{
    class MailSupport : MailServer
    {
        public MailSupport()
        {
            SenderMail = "ftasmartcard@gmail.com";
            Password = "Cesar110900";
            Host = "smtp.gmail.com";
            Port = 587;
            Ssl = true;
            InitializeSmtpClient();
        }
    }

}
