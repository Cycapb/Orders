using Domain;

namespace Businesslogic
{
    public interface IMailSettingProvider
    {
        string MailTo { get; set; }
        EmailSettings GetSettings();
    }
}