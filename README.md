# Zatomic.AI.Providers

C# .NET library that provides chat functionality for the following AI providers: AI21 Labs, Amazon Bedrock, Anthropic, Azure OpenAI, Azure Serverless, Cohere, Deep Infra, Fireworks AI, Google Gemini, Hugging Face, Hyperbolic, Lambda, Meta, Mistral, OpenAI, Together AI, and xAI.

The library calls the chat completions REST APIs and inference endpoints for each of the above AI providers. Everything is strongly-typed with the library handling all JSON serialization/deserialization for all requests and responses. Both non-stream and streaming functionality is supported using `async` methods for improved performance.

## Requirements

Currently, only `.net9.0` is supported.

## Installation

Using the .NET CLI:

```sh
dotnet add package Zatomic.AI.Providers
```

Using the NuGet CLI:

```sh
nuget install Zatomic.AI.Providers
```

Using the Package Manager console:

```powershell
Install-Package Zatomic.AI.Providers
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on _Manage NuGet Packages..._
4. Click on the _Browse_ tab and search for "Zatomic.AI.Providers".
5. Click on the Zatomic.AI.Providers package, select the appropriate version in the right-pane, click _Install_.

## Non-Stream Example - OpenAI

```csharp
using Zatomic.AI.Providers

var openAIClient = new OpenAIChatClient { ApiKey = "[YOUR_API_KEY]" };

var request = new OpenAIChatRequest("gpt-4.1-2025-04-14");
request.AddSystemMessage("You are a very helpful assistant.");
request.AddUserMessage("Why is the sky blue?");

var response = await _openAIClient.ChatAsync(request);
var content = response.Choices[0].Message.Content;
```

## Streaming Example - OpenAI

```csharp
using Zatomic.AI.Providers

var openAIClient = new OpenAIChatClient { ApiKey = "[YOUR_API_KEY]" };

var request = new OpenAIChatRequest("gpt-4.1-2025-04-14");
request.AddSystemMessage("You are a very helpful assistant.");
request.AddUserMessage("Why is the sky blue?");

await foreach (var response in openAIClient.ChatStreamAsync(request))
{
    yield return response;
}
```
