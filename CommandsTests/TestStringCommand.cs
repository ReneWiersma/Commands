using ReneWiersma.Commands;

namespace ReneWiersma.CommandsTests
{
    internal class TestStringCommand : ICommand<string>
    {
        public string Message { get; private set; }

        public void Execute(string input)
        {
            Message = input;
        }
    }
}
