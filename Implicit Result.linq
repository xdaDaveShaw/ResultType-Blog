<Query Kind="Program" />

void Main()
{
	var inputs = new[] { "Food", "Foo", null, };
	
	foreach (var result in inputs.Select(ComplexOperation))
	{
		if (result.Error != null)
			Console.WriteLine(result.Error);
		else if (result.FailureMessage != null)
			Console.WriteLine(result.FailureMessage);
		else
			Console.WriteLine($"Even length: {result.EvenLength}.");
	}
}

Result ComplexOperation(String input)
{
	try
	{
		if (input.Length % 2 == 0)
			return new Result { EvenLength = input.Length, };
		else
			return new Result { FailureMessage = "Length is odd.", };
	}
	catch (Exception ex)
	{
		return new Result { Error = ex, };
	}
}

class Result
{
	public String FailureMessage { get; set;}
	public Int32? EvenLength { get; set; }
	public Exception Error { get; set;}
}