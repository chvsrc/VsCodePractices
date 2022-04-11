 
// When we want to enable a class or object to 
// notify other classes or objects we use Events 

// The class that sends (or raises) the event is called the publisher 
// and the classes that receive (or handle) the event are called subscribers.



using System;

public class Program
{
    public static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        // register with an event
        Console.WriteLine("Step 1");
        bl.ProcessCompleted += bl_ProcessCompleted;
        Console.WriteLine("Step 2");
        bl.StartProcess();
        Console.WriteLine("Step 8");
    }

    // event handler
    public static void bl_ProcessCompleted()
    {
        Console.WriteLine("Step 5");
    }
}


public class ProcessBusinessLogic
{
    // delegate
    public delegate void Notify();

    // event
    public event Notify ProcessCompleted; 

    public void StartProcess()
    {
        Console.WriteLine("Step 3");
        // some code here..
        OnProcessCompleted();
        Console.WriteLine("Step 7");
    }


    protected virtual void OnProcessCompleted()
    {
        Console.WriteLine("Step 4");
        ProcessCompleted?.Invoke();
        Console.WriteLine("Step 6");
    }
}
