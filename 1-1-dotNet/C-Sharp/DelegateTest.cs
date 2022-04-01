// Delegate is type safe function pointer in C#
// Delegate - callback function

// A delegate is a type that safely encapsulates a method, similar to a function pointer in C and C++.
// Unlike C function pointers, delegates are object-oriented, type safe, and secure.
// The type of a delegate is defined by the name of the delegate.

using System;

public class Program
{
	public static void Main()
	{
		new CallBackTest().Test();
	}
}

public class CallBackTest
{
	public void Test()
	{
		Console.WriteLine("execution stpe 1");
		LongRunningClass objC = new LongRunningClass();
		objC.LongRunningFunction(callBackFuncForAddition);
		Console.WriteLine("execution stpe 6");
	}

	public int callBackFuncForAddition(int x, int y)
	{
		Console.WriteLine("execution stpe 3");
		int z = x + y;
		Console.WriteLine("execution stpe 4");
		return z;
	}
}

public class LongRunningClass
{
	// delegate
	public delegate int delegateName(int x, int y);

	public void LongRunningFunction(delegateName obj)
	{
		Console.WriteLine("execution stpe 2");
		int a = obj.Invoke(5, 10);
		Console.WriteLine("execution stpe 5");
	}
}
