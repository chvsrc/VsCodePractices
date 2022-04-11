using System;
					
public class Program
{
	public static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        Console.WriteLine("execution step 1");
        bl.ProcessCompleted += bl_ProcessCompleted; // register with an event
        Console.WriteLine("execution step 2");
        bl.StartProcess();
        Console.WriteLine("execution step 8");
    }

    // event handler
    public static void bl_ProcessCompleted(object sender, EventArgs e)
    {
        Console.WriteLine("execution step 5");
    }
}
                    
public class ProcessBusinessLogic
{
    public event EventHandler ProcessCompleted; // event

    public void StartProcess()
    {
        Console.WriteLine("execution step 3");
        // some code here..
        OnProcessCompleted(EventArgs.Empty);
        Console.WriteLine("execution step 7");
    }


    protected virtual void OnProcessCompleted(EventArgs e)
    {
        Console.WriteLine("execution step 4");
        ProcessCompleted?.Invoke(this, e);
        Console.WriteLine("execution step 6");
    }
}
