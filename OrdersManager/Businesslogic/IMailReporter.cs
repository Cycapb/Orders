using System.Threading.Tasks;

namespace Businesslogic
{
    public interface IMailReporter
    {
        string MailTo { get; set; }
        Task Report(string fileName);
    }
}
