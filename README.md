# Commands

This Commands library provides generic ICommand interfaces.

It also includes an implementation of a CompositeCommand which executes a list of ICommands in order. 

The IResultCommand may be used in cases when the command has a status result which needs to be returned. For actual queries, please use an IQuery interface.

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
The ICommand supports only one input parameter. If a command needs multiple input parameters, bundle them in a Parameter object.
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

### Example of IResultCommand implementation

```csharp
public class ExampleResultCommand : IResultCommand<Result>
{
    public bool IsExecuted { get; private set; }

    public Result Execute()
    {
        IsExecuted = true;
	
	return Result.Ok();
    }
}
```
### Example of IResultCommand implementation with input paramater
The IResultCommand supports only one input parameter. If a command needs multiple input parameters, bundle them in a Parameter object.
```csharp
public class ExampleStringCommand : ICommand<string, Result>
{
    public string Message { get; private set; }

    public Result Execute(string input)
    {
        Message = input;
	
	return Result.Ok();
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
