using ReneWiersma.Preconditions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ReneWiersma.Commands
{
    internal static class CheckedEnumerableExtensions
    {
        internal static CheckedEnumerable<T> ToCheckedEnumerable<T>(this IEnumerable<T> commands) => new CheckedEnumerable<T>(commands);
    }

    internal class CheckedEnumerable<T> : IEnumerable<T>
    {
        readonly IEnumerable<T> items;

        internal CheckedEnumerable(IEnumerable<T> items)
        {
            Precondition.Requires(items != null, () => new ArgumentNullException(nameof(items)));
            Precondition.Requires(!items.Any(command => command == null), () => new ArgumentNullException());

            this.items = items;
        }

        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
