using ReneWiersma.Commands;
using System.Threading.Tasks;

namespace ReneWiersma.CommandsTests
{
    internal class TestStringAsyncCommand : IAsyncCommand<string>
    {
        public string Message { get; private set; }

        public async Task Execute(string input)
        {
            await Task.Delay(0);
            Message = input;
        }
    }
}
