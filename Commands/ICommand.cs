namespace ReneWiersma.Commands
{
    public interface ICommand<T>
    {
        void Execute(T input);
    }

    public interface ICommand
    {
        void Execute();
    }
}
