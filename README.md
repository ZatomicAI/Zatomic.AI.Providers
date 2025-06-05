# Zatomic.AI.Providers

C# .NET library that provides chat functionality for the following AI providers: AI21 Labs, Amazon Bedrock, Anthropic, Azure OpenAI, Azure Serverless, Cohere, Deep Infra, Fireworks AI, Google Gemini, Groq, Hugging Face, Hyperbolic, Lambda, Meta, Mistral, OpenAI, Perplexity, Together AI, and xAI.

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

## Samples

Samples for all AI providers can be found in the `src/Zatomic.AI.Providers.Samples` project. This is an NUnit test project, but that's simply to make it easy to run/debug the sample methods. Before running any of the sample methods, you must add an `AppSettings.Development.json` file to the root of the project. This file should contain the API keys, models, etc for the providers you want to run against.

The format of the `AppSettigns.Development.json` file is as follows:

```json
{
    "AI21Labs": {
        "ApiKey": "",
        "Model": ""
    },
    "AmazonBedrock": {
        "AccessKey": "",
        "SecretKey": "",
        "Region": "",
        "Model": ""
    },
    "Anthropic": {
        "ApiKey": "",
        "Model": "",
        "MaxTokens": ""
    },
    "AzureOpenAI": {
        "ApiKey": "",
        "Endpoint": "",
        "Deployment": "",
        "Model": ""
    },
    "AzureServerless": {
        "ApiKey": "",
        "Endpoint": "",
        "Model": ""
    },
    "Cohere": {
        "ApiKey": "",
        "Model": ""
    },
    "DeepInfra": {
        "ApiKey": "",
        "Model": ""
    },
    "FireworksAI": {
        "ApiKey": "",
        "Model": ""
    },
    "GoogleGemini": {
        "ApiKey": "",
        "Model": ""
    },
    "Groq": {
        "ApiKey": "",
        "Model": ""
    },
    "HuggingFace": {
        "AccessToken": "",
        "Endpoint": "",
        "Model": ""
    },
    "Hyperbolic": {
        "ApiKey": "",
        "Model": ""
    },
    "Lambda": {
        "ApiKey": "",
        "Model": ""
    },
    "Meta": {
        "ApiKey": "",
        "Model": ""
    },
    "Mistral": {
        "ApiKey": "",
        "Model": ""
    },
    "OpenAI": {
        "ApiKey": "",
        "Model": ""
    },
    "Perplexity": {
        "ApiKey": "",
        "Model": ""
    },
    "TogetherAI": {
        "ApiKey": "",
        "Model": ""
    },
    "xAI": {
        "ApiKey": "",
        "Model": ""
    }
}
```
