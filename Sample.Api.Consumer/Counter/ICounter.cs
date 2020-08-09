using System.Threading.Tasks;

namespace Sample.Api.Consumer.Counter
{
    public interface ICounter
    {
        Task IncrementByOne();

        Task<int> GetCount();
    }
}
