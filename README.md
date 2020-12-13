# Commands

This Commands library provides generic ICommand interfaces.

It also includes an implementation of a CompositeCommand which executes a list of ICommands in order. 

## Installation

Available on [nuget](https://www.nuget.org/packages/ReneWiersma.Commands/)

	PM> Install-Package ReneWiersma.Commands

### Example of ICommand implementation

```csharp
public class ExampleCommand : ICommand
{
    public bool IsExecuted { get; private set; }

    public void Execute()
    {
        IsExecuted = true;
    }
}
```

### Example of ICommand implementation with input paramater

```csharp
public class ExampleStringCommand : ICommand<string>
{
    public string Message { get; private set; }

    public void Execute(string input)
    {
        Message = input;
    }
}
```

### Example use of CompositeCommand
CompositeCommand accepts a list of ICommand parameters in the constructor, either as an IList, or as a parameter array. The latter approach is shown in this example.
```csharp
public void MultipleCommandsAreExecuted()
{
    var testCommand1 = new TestCommand();
    var testCommand2 = new TestCommand();
    var sut = new CompositeCommand(testCommand1, testCommand2);

    sut.Execute();

    Assert.IsTrue(testCommand1.IsExecuted);
    Assert.IsTrue(testCommand2.IsExecuted);
}
```
