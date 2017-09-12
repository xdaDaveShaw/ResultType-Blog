<Query Kind="Program" />

//Problems:
// A lot of ceremony upfront, but easier to consume.
// Type is still mutable but now only inside the type.
// Nothing is forcing people to check Type property first.
// When getting a result you still don't know what to do with it.
// Still violates OCP.

void Main()
{
	var inputs = new[] { "Food", "Foo", null, };
	
	foreach (var result in inputs.Select(ComplexOperation))
	{
		switch (result.Type)
		{
			case ResultType.Success:
				Console.WriteLine($"Even length: {result.EvenLength}.");
				break;
			case ResultType.Failure:
				Console.WriteLine(result.FailureMessage);
				break;
			case ResultType.Error:
				Console.WriteLine(result.Error);
				break;
		}
	}
}

Result ComplexOperation(String input)
{
	try
	{
		if (input.Length % 2 == 0)
			return Result.CreateSuccess(input.Length);
		else
			return Result.CreateFailure("Length is odd.");
	}
	catch (Exception ex)
	{
		return Result.CreateError(ex);
	}
}

class Result
{
	public String FailureMessage { get; private set; }
	public Int32? EvenLength { get; private set; }
	public Exception Error { get; private set; }
	public ResultType Type { get; private set; }

	public static Result CreateFailure(String message)
	{
		return new Result { FailureMessage = message, Type = ResultType.Failure, };
	}

	public static Result CreateSuccess(Int32 value)
	{
		return new Result { EvenLength = value, Type = ResultType.Success, };
	}

	public static Result CreateError(Exception ex)
	{
		return new Result { Error = ex, Type = ResultType.Error, };
	}
}

enum ResultType
{
	Success,
	Failure,
	Error,
}