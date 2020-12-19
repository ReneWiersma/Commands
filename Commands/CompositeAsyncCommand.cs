using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReneWiersma.Commands
{
    public sealed class CompositeAsyncCommand<T> : IAsyncCommand<T>
    {
        readonly IEnumerable<IAsyncCommand<T>> commands;

        public CompositeAsyncCommand(params IAsyncCommand<T>[] commands) =>
            this.commands = commands.ToCheckedEnumerable();

        public CompositeAsyncCommand(IEnumerable<IAsyncCommand<T>> commands) =>
            this.commands = commands.ToCheckedEnumerable();

        public async Task Execute(T input)
        {
            foreach (var command in commands)
                await command.Execute(input);
        }
    }

    public sealed class CompositeAsyncCommand : IAsyncCommand
    {
        readonly IEnumerable<IAsyncCommand> commands;

        public CompositeAsyncCommand(params IAsyncCommand[] commands) =>
            this.commands = commands.ToCheckedEnumerable();

        public CompositeAsyncCommand(IEnumerable<IAsyncCommand> commands) =>
            this.commands = commands.ToCheckedEnumerable();

        public async Task Execute()
        {
            foreach (var command in commands)
                await command.Execute();
        }
    }
}
