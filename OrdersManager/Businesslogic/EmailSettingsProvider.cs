using System.Configuration;
using Domain;

namespace Businesslogic
{
    public class EmailSettingsProvider:IMailSettingProvider
    {
        public string MailTo { get; set; }

        public EmailSettings GetSettings()
        {
            return new EmailSettings()
            {
                MailTo = this.MailTo,
                MailFrom = ConfigurationManager.AppSettings["MailFrom"],
                UserName = ConfigurationManager.AppSettings["UserName"],
                Password = ConfigurationManager.AppSettings["Password"],
                ServerName = ConfigurationManager.AppSettings["Server"],
                ServerPort = int.Parse(ConfigurationManager.AppSettings["Port"]),
                UseSsl = bool.Parse(ConfigurationManager.AppSettings["UseSsl"])
            };
        }
}