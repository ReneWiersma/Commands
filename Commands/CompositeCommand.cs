using System.Collections.Generic;

namespace ReneWiersma.Commands
{
    public sealed class CompositeCommand : ICommand
    {
        readonly CommandList<ICommand> commands;

        public CompositeCommand(params ICommand[] commands)
        {
            this.commands = new CommandList<ICommand>(commands);
        }

        public CompositeCommand(IEnumerable<ICommand> commands)
        {
            this.commands = new CommandList<ICommand>(commands);
        }

        public void Execute()
        {
            foreach (var command in commands)
                command.Execute();
        }
    }

    public sealed class CompositeCommand<T> : ICommand<T>
    {
        readonly CommandList<ICommand<T>> commands;

        public CompositeCommand(params ICommand<T>[] commands)
        {
            this.commands = new CommandList<ICommand<T>>(commands);
        }

        public CompositeCommand(IEnumerable<ICommand<T>> commands)
        {
            this.commands = new CommandList<ICommand<T>>(commands);
        }

        public void Execute(T input)
        {
            foreach (var command in commands)
                command.Execute(input);
        }
    }
}
