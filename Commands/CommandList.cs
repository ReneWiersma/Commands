using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ReneWiersma.Commands
{
    internal class CommandList<T> : IEnumerable<T>
    {
        readonly IEnumerable<T> commands;

        internal CommandList(params T[] commands) : this(new List<T>(commands))
        {
        }

        internal CommandList(IEnumerable<T> commands)
        {
            Contract.Requires<ArgumentNullException>(commands != null);
            Contract.Requires<ArgumentNullException>(!commands.Any(command => command == null));

            this.commands = commands;
        }

        public IEnumerator<T> GetEnumerator() => commands.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
