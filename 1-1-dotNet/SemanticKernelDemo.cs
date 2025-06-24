using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

Console.WriteLine("Hello, World!");

// Populate values from your OpenAI deployment
var modelIdOrDeploymentName = "gpt-35-turbo";
var endpoint = "https://<your-endpoint>.openai.azure.com/"; 
var apiKey = "<your-api-key>";

var kernel = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(modelIdOrDeploymentName, endpoint, apiKey).Build();

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
