using System;
using System.Threading.Tasks;

namespace ByteBank.View.Utils
{
    public class ByteBankProgress<T> : IProgress<T>
    {
        private readonly TaskScheduler _taskScheduler;
        private readonly Action<T> _handler;

        public ByteBankProgress(Action<T> handler)
        {
            _taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            _handler = handler;
        }

        public void Report(T value)
        {
            Task.Factory.StartNew(
                () => _handler(value),
                System.Threading.CancellationToken.None,
                TaskCreationOptions.None,
                _taskScheduler
            );
        }
    }
}
