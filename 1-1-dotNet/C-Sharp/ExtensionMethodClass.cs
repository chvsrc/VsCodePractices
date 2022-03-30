using System;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Any Integer Value" + System.Environment.NewLine);
            int userInput = Convert.ToInt32(Console.ReadLine());
            bool result = userInput.isGreaterThan5();
            Console.WriteLine("The result is " + result);
        }
    }

    // static class  
    // static method 
    // this as a method parameter
    // To convert one dto to another dto we can create a extension methods
    public static class ExtensionMethodClass
    {
        public static bool isGreaterThan5(this int input)
        {
            bool result = false;
            if (input > 5)
            {
                result = true;
            }
            return result;
        }
    }
}
