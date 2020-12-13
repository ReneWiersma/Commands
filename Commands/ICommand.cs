namespace ReneWiersma.Commands
{
    public interface IResultCommand<TIn, TResult>
    {
        TResult Execute(TIn input);
    }

    public interface IResultCommand<TResult>
    {
        TResult Execute();
    }

    public interface ICommand<T>
    {
        void Execute(T input);
    }

    public interface ICommand
    {
        void Execute();
    }
}
