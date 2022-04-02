using System;

// when we get a DateTime value in string format from database
// all the time we don't need to write this logic for validating the datetime
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter any date (12-21-2020):" + Environment.NewLine);
        string userInput = Console.ReadLine();
        if (userInput.IsValidDate())
        {
            Console.WriteLine(userInput + " is valid date");
        }
        else
        {
            Console.WriteLine(userInput + " is not a valid date");
        }
    }
}

// static class  
// static method 
// this as a method parameter
public static class ExtensionMethodClass
{
    public static bool IsValidDate(this string input)
    {
        try
        {
            DateTime.Parse(input);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
