using System.Threading.Tasks;

namespace ReneWiersma.Commands
{
    public interface IAsyncCommand<T>
    {
        Task Execute(T input);
    }

    public interface IAsyncCommand
    {
        Task Execute();
    }
}
