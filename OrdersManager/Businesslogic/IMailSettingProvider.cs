using Domain;

namespace Businesslogic
{
    public interface IMailSettingProvider
    {
        EmailSettings GetSettings();
    }
}