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

        // test 2
        DateTime dt = DateTime.Now;
        DateTime roundUpdt = dt.RoundUp(TimeSpan.FromMinutes(15));

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

// DateTimeExtensions
public static class DateTimeExtensions
{
    public static DateTime RoundUp(this DateTime dt, TimeSpan interval)
    {
        if (interval == TimeSpan.Zero)
            throw new ArgumentException("Interval must be greater than zero.", nameof(interval));

        long ticks = (dt.Ticks + interval.Ticks - 1) / interval.Ticks * interval.Ticks;
        return new DateTime(ticks, dt.Kind);
    }

    public static DateTime RoundDown(this DateTime dt, TimeSpan interval)
    {
        if (interval == TimeSpan.Zero)
            throw new ArgumentException("Interval must be greater than zero.", nameof(interval));

        long ticks = dt.Ticks - (dt.Ticks % interval.Ticks);
        return new DateTime(ticks, dt.Kind);
    }
}
