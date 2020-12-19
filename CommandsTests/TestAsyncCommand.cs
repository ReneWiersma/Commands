using ReneWiersma.Commands;
using System.Threading.Tasks;

namespace ReneWiersma.CommandsTests
{
    internal class TestAsyncCommand : IAsyncCommand
    {
        public bool IsExecuted { get; private set; }

        public async Task Execute()
        {
            await Task.Delay(0);

            IsExecuted = true;
        }
    }
}
