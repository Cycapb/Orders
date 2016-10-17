using Domain;

namespace Businesslogic
{
    public interface IMailSettingsProvider
    {
        EmailSettings GetSettings();
    }
}