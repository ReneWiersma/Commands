using System.Collections.Generic;

namespace ReneWiersma.Commands
{
    public sealed class CompositeCommand : ICommand
    {
        readonly IEnumerable<ICommand> commands;

        public CompositeCommand(params ICommand[] commands) =>
            this.commands = commands.ToCheckedEnumerable();

        public CompositeCommand(IEnumerable<ICommand> commands) =>
            this.commands = commands.ToCheckedEnumerable();

        public void Execute()
        {
            foreach (var command in commands)
                command.Execute();
        }
    }

    public sealed class CompositeCommand<T> : ICommand<T>
    {
        readonly IEnumerable<ICommand<T>> commands;

        public CompositeCommand(params ICommand<T>[] commands) =>
            this.commands = commands.ToCheckedEnumerable();

        public CompositeCommand(IEnumerable<ICommand<T>> commands) =>
            this.commands = commands.ToCheckedEnumerable();

        public void Execute(T input)
        {
            foreach (var command in commands)
                command.Execute(input);
        }
    }
}
