using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Businesslogic
{
    public class MailReporter : IReporter
    {
        private readonly IMailSettingProvider _settingsProvider;

        public MailReporter(IMailSettingProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public async Task Report(string fileName)
        {
            var smtpClient = CreateSmtpClient();
            var emailSettings = _settingsProvider.GetSettings();


            StringBuilder messageBody = new StringBuilder();
            messageBody.Append("Excel file with orders is in attachement");

            MailMessage mailMessage = new MailMessage(emailSettings.MailFrom, emailSettings.MailTo,
                "Report via Excel", messageBody.ToString());
            mailMessage.Attachments.Add(new Attachment(fileName));

            await smtpClient.SendMailAsync(mailMessage);
            smtpClient.Dispose();
        }

        private SmtpClient CreateSmtpClient()
        {
            var emailSettings = _settingsProvider.GetSettings();
            var client = new SmtpClient()
            {
                Host = emailSettings.ServerName,
                Port = emailSettings.ServerPort,
                EnableSsl = emailSettings.UseSsl,
                Credentials = new NetworkCredential(emailSettings.UserName, emailSettings.Password)
            };
            return client;
        }
    }
}