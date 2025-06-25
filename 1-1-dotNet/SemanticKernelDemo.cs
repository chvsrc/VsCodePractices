// https://learn.microsoft.com/en-us/semantic-kernel/get-started/quick-start-guide?pivots=programming-language-csharp
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

Console.WriteLine("Hello, World!");

// Populate values from your OpenAI deployment
var modelIdOrDeploymentName = Env.Var("AZURE_OPENAI_CHAT_DEPLOYMENT_NAME"); // "gpt-35-turbo";
var endpoint = Env.Var("AZURE_OPENAI_ENDPOINT"); //"https://<your-endpoint>.openai.azure.com/"; 
var apiKey = Env.Var("AZURE_OPENAI_KEY");  // "<your-api-key>";

var kernel = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(modelIdOrDeploymentName, endpoint, apiKey).Build();

// var question = "What is Semantic Kernel?";
// var context = kernel.CreateNewContext();
// context.Variables.Set("input", question);
// context.Variables.Set("data", sk_groundingContext);
// // Run the prompt / semantic function
// var citeSources = kernel.CreateSemanticFunction(sk_prompt, maxTokens: 150);
// // Show the result
// Console.WriteLine("--- Semantic Function result");
// var result = await citeSources.InvokeAsync(context);
// Console.WriteLine(result);

Console.WriteLine("🤖 Chatbot started! Type 'exit' to quit.\n");

while (true)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("You: ");
    Console.ResetColor();

    var userInput = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(userInput) || userInput.ToLower() == "exit")
        break;

    var chatFunction = kernel.CreateFunctionFromPrompt("""
        You are a helpful assistant. Answer the question clearly.
        Question: {{input}}
        Answer:
        """);

    var result = await kernel.InvokeAsync(chatFunction, new() { ["input"] = userInput });

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"Bot: {result}");
    Console.ResetColor();
}

// Output
//🤖 Chatbot started! Type 'exit' to quit.

//You: What is Semantic Kernel ?
//Bot : Semantic Kernel is a Microsoft SDK that helps you integrate AI models with your code using planners, functions, and memory.
