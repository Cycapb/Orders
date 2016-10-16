using System.Threading.Tasks;

namespace Businesslogic
{
    public interface IReporter
    {
        Task Report(string fileName);
    }
}
