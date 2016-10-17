using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Businesslogic
{
    public class MailReporter : IMailReporter
    {
        private readonly IMailSettingProvider _settingsProvider;

        public MailReporter(IMailSettingProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public string MailTo { get; set; }

        public async Task Report(string fileName)
        {
            var emailSettings = _settingsProvider.GetSettings();
            emailSettings.MailTo = this.MailTo;
            var smtpClient = CreateSmtpClient(emailSettings);

            StringBuilder messageBody = new StringBuilder();
            messageBody.Append("Excel file with orders is in attachement");

            try
            {
                MailMessage mailMessage = new MailMessage(emailSettings.MailFrom, emailSettings.MailTo,
                    "Report via Excel", messageBody.ToString());
                mailMessage.Attachments.Add(new Attachment(fileName));

                await smtpClient.SendMailAsync(mailMessage);
            }
            finally
            {
                smtpClient.Dispose();
            }
        }

        private SmtpClient CreateSmtpClient(EmailSettings emailSettings)
        {
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