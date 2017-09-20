<Query Kind="Program" />

//Problems:
// Use of exceptions causing difficult to follow code.
// Quite a bit of ceremony
// Have to be careful not to accidentally handle your own exceptions.
// None of the Logic for the failures, is anywhere near the code that identifies it.

void Main()
{
	var inputs = new[] { "Food", "Foo", null, };
	
	foreach (var input in inputs)
	{
		try
		{
			var result = ComplexOperation(input);
			Console.WriteLine($"Even length: {result}.");
		}
		catch (BusinessException be)
		{
			switch (be)
			{
				case FailureException f:
					Console.WriteLine(f.Message);
					break;
				case ErrorException e:
					Console.WriteLine(e.InnerException);
					break;
				default:
					throw;
			}
		}			
	}
}

Int32 ComplexOperation(String input)
{
	try
	{
		if (input.Length % 2 == 0)
			return input.Length;
		else
			throw new FailureException("Length is odd.");
	}
	catch (Exception ex) when (!(ex is BusinessException))
	{
		throw new ErrorException(ex);
	}
}

class FailureException : BusinessException
{
	public FailureException(String message) : base(message) { }
}

class ErrorException : BusinessException
{
	public ErrorException(Exception inner) : base(inner) { }
}

abstract class BusinessException : Exception
{
	public BusinessException(String message) : base(message) { } 
	public BusinessException(Exception inner) : base("Something bad happened", inner) { }
}