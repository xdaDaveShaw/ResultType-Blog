<Query Kind="Program" />

//Problems:
// Complex Operation is hard to test on it's own.
// Mix of business logic with side effects.

void Main()
{
	ComplexOperation("Food");
	ComplexOperation("Foo");
	ComplexOperation(null);
}

void ComplexOperation(String input)
{
	try
	{
		if (input.Length % 2 == 0)
			Console.WriteLine($"Even length: {input.Length}.");
		else
			Console.WriteLine("Length is odd.");
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex);
	}
}