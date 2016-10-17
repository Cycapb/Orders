using System.Configuration;
using Domain;

namespace Businesslogic
{
    public class EmailSettingsProvider : IMailSettingsProvider
    {
        public EmailSettings GetSettings()
        {
            return new EmailSettings()
            {
                MailFrom = ConfigurationManager.AppSettings["MailFrom"],
                UserName = ConfigurationManager.AppSettings["UserName"],
                Password = ConfigurationManager.AppSettings["Password"],
                ServerName = ConfigurationManager.AppSettings["Server"],
                ServerPort = int.Parse(ConfigurationManager.AppSettings["Port"]),
                UseSsl = bool.Parse(ConfigurationManager.AppSettings["UseSsl"])
            };
        }
    }
}