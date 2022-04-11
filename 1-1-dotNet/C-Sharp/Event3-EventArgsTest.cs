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
    }

    // event handler
    public static void bl_ProcessCompleted(object sender, ProcessEventArgs e)
    {
        Console.WriteLine("execution step 5");
        Console.WriteLine("Process " + (e.IsSuccessful ? "Completed Successfully" : "failed"));
        Console.WriteLine("Completion Time: " + e.CompletionTime.ToLongDateString());
        Console.WriteLine("execution step 6");

    }
}

public class ProcessEventArgs : EventArgs
{
    public bool IsSuccessful { get; set; }
    public DateTime CompletionTime { get; set; }

}

public class ProcessBusinessLogic
{
    public event EventHandler<ProcessEventArgs> ProcessCompleted; // event

    public void StartProcess()
    {
        Console.WriteLine("execution step 3");
        var data = new ProcessEventArgs();

        try
        {
            //uncomment following to see the result
            //throw new NullReferenceException();

            // some process code here..

            data.IsSuccessful = true;
            data.CompletionTime = DateTime.Now;
            OnProcessCompleted(data);
        }
        catch (Exception ex)
        {
            data.IsSuccessful = false;
            data.CompletionTime = DateTime.Now;
            OnProcessCompleted(data);
        }
        Console.WriteLine("execution step 8");
    }

    protected virtual void OnProcessCompleted(ProcessEventArgs e)
    {
        Console.WriteLine("execution step 4");
        ProcessCompleted?.Invoke(this, e);
        Console.WriteLine("execution step 7");
    }
}
