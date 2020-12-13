using ReneWiersma.Commands;

namespace ReneWiersma.CommandsTests
{
    internal class TestCommand : ICommand
    {
        public bool IsExecuted { get; private set; }

        public void Execute()
        {
            IsExecuted = true;
        }
    }
}
