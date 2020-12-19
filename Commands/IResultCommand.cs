namespace ReneWiersma.Commands
{
    public interface IResultCommand<TResult>
    {
        TResult Execute();
    }

    public interface IResultCommand<TIn, TResult>
    {
        TResult Execute(TIn input);
    }
}
