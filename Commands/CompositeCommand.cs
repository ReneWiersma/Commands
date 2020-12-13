using System;
using System.Collections.Generic;
using System.Linq;

namespace ReneWiersma.Commands
{
    public abstract class AbstractCompositeCommand<T>
    {
        protected readonly IList<T> commands;

        protected AbstractCompositeCommand(params T[] commands) : this(new List<T>(commands))
        {
        }

        protected AbstractCompositeCommand(IList<T> commands)
        {
            Contract.Requires<ArgumentNullException>(commands != null);
            Contract.Requires<ArgumentNullException>(!commands.Any(command => command == null));

            this.commands = commands;
        }
    }

    public sealed class CompositeCommand : AbstractCompositeCommand<ICommand>, ICommand
    {
        public CompositeCommand(params ICommand[] commands) : base(commands) 
        { 
        }

        public CompositeCommand(IList<ICommand> commands) : base(commands)
        { 
        }

        public void Execute()
        {
            foreach (var command in commands)
                command.Execute();
        }
    }

    public sealed class CompositeCommand<T> : AbstractCompositeCommand<ICommand<T>>, ICommand<T>
    {
        public CompositeCommand(params ICommand<T>[] commands) : base(commands)
        {
        }

        public CompositeCommand(IList<ICommand<T>> commands) : base(commands)
        {
        }

        public void Execute(T input)
        {
            foreach (var command in commands)
                command.Execute(input);
        }
    }
}
