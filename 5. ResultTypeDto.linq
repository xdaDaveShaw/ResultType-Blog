<Query Kind="Program" />

//Problems:
// A lot of ceremony upfront, but easier to consume.
// Result is a DTO, what do I do with it is still up to the Consumer.
// Need to remember how the results are processed when extending.

void Main()
{
	var inputs = new[] { "Food", "Foo", null, };

	foreach (var result in inputs.Select(ComplexOperation))
	{
		switch (result)
		{
			case Success s:
				Console.WriteLine($"Even length: {s.EvenLength}.");
				break;
			case Failure f:
				Console.WriteLine(f.FailureMessage);
				break;
			case Error e:
				Console.WriteLine(e.Exception);
				break;
		}
	}
}

Result ComplexOperation(String input)
{
	try
	{
		if (input.Length % 2 == 0)
			return new Success(input.Length);
		else
			return new Failure("Length is odd.");
	}
	catch (Exception ex)
	{
		return new Error(ex);
	}
}

class Success : Result
{
	public Int32 EvenLength { get; }
	public Success(Int32 value) { EvenLength = value; }
}
class Failure : Result
{
	public String FailureMessage { get; }
	public Failure(String message) { FailureMessage = message; }
}

class Error : Result
{
	public Exception Exception { get; }
	public Error(Exception ex) { Exception = ex; }
}

abstract class Result
{
}