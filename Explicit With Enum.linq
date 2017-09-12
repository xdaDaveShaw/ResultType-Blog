<Query Kind="Program" />

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
			return new Result { EvenLength = input.Length, Type = ResultType.Success, };
		else
			return new Result { FailureMessage = "Length is odd.", Type = ResultType.Failure, };
	}
	catch (Exception ex)
	{
		return new Result { Error = ex, Type = ResultType.Error, };
	}
}

class Result
{
	public String FailureMessage { get; set;}
	public Int32? EvenLength { get; set; }
	public Exception Error { get; set; }
	public ResultType Type { get; set; }
}

enum ResultType
{
	Success,
	Failure,
	Error,
}