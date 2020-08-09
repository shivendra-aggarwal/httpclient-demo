using System.Threading.Tasks;

namespace Sample.Api.Consumer.Counter
{
    public class CounterService : ICounter
    {
        private int _counter = default;

        public async Task<int> GetCount()
        {
            return _counter;
        }

        public async Task IncrementByOne()
        {
            _counter++;
        }
    }
}
