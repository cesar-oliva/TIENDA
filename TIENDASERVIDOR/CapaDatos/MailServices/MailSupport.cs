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
            senderMail = "ftasmartcard@gmail.com";
            password = "Cesar110900";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            initializeSmtpClient();
        }
    }

}
