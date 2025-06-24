using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

public static class TimerFunction
{
    [FunctionName("RunEvery5Minutes")]
    public static void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, ILogger log)
    {
        log.LogInformation($"Function executed at: {System.DateTime.Now}");
        // Your logic here
    }
}
