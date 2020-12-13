using System;

namespace ReneWiersma.Commands
{
    internal static class Contract
    {
        internal static void Requires(bool precondition, string message = "Precondition failed") => Requires<ArgumentException>(precondition, message);

        internal static void Requires<E>(bool precondition, string message = "Precondition failed") where E : Exception, new()
        {
            if (!precondition)
                throw Activator.CreateInstance(typeof(E), message) as E;
        }
    }
}
