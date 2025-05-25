# Zatomic.AI.Providers

C# .NET library that provides chat functionality for the following AI providers: AI21 Labs, Amazon Bedrock, Anthropic, Azure OpenAI, Azure Serverless, Cohere, Deep Infra, Fireworks AI, Google Gemini, Hugging Face, Hyperbolic, Lambda, Meta, Mistral, OpenAI, Together AI, and xAI.

The library calls the chat completions REST APIs and inference endpoints for each of the above AI providers. Everything is strongly-typed with the library handling all JSON serialization/deserialization for all requests and responses. Both non-stream and streaming functionality is supported using `async` methods for improved performance.

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
