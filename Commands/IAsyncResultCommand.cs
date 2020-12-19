using System.Threading.Tasks;

namespace ReneWiersma.Commands
{
    public interface IAsyncResultCommand<TResult>
    {
        Task<TResult> Execute();
    }

    public interface IAsyncResultCommand<TIn, TResult>
    {
        Task<TResult> Execute(TIn input);
    }
}
