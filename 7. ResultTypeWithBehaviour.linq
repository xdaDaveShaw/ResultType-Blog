<Query Kind="Program" />

//Problems:
// A lot of ceremony upfront, and code to consume, can get messy and make the code hard to read.
// All the behaviour related to a result is in the result now and reslts can be tested.

void Main()
{
	var inputs = new[] { "Food", "Foo", null, };

	foreach (var result in inputs.Select(ComplexOperation))
	{
		result.Process();
	}
}

IProcessor processor = new Processor();

Result ComplexOperation(String input)
{
	try
	{
		if (input.Length % 2 == 0)
			return new Success(processor, input.Length);
		else
			return new Failure(processor, "Length is odd.");
	}
	catch (Exception ex)
	{
		return new Error(processor, ex);
	}
}

class Success : Result
{
	public Int32 EvenLength { get; }
	public Success(IProcessor p, Int32 value) : base(p) { EvenLength = value; }
	public override void Process() => Processor.WriteMessage($"Even length: {EvenLength}.");
}

class Failure : Result
{
	public String FailureMessage { get; }
	public Failure(IProcessor p, String message) : base(p) { FailureMessage = message; }
	public override void Process() => Processor.WriteMessage(FailureMessage);
}

class Error : Result
{
	public Exception Exception { get; }
	public Error(IProcessor p, Exception ex) : base(p) { Exception = ex; }
	public override void Process() => Processor.WriteMessage(Exception);
}

abstract class Result
{
	public Result(IProcessor processor)
	{
		Processor = processor;
	}

	protected IProcessor Processor { get;}
	
	public abstract void Process();
}

interface IProcessor
{
	void WriteMessage(Object message);
}

class Processor : IProcessor
{
	public void WriteMessage(Object message) => Console.WriteLine(message);
}