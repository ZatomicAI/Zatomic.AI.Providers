# Zatomic.AI.Providers

C# .NET library that provides chat functionality for the following AI providers: [AI21 Labs](https://docs.ai21.com/reference/jamba-1-6-api-ref), [Amazon Bedrock](https://docs.aws.amazon.com/bedrock/latest/APIReference/API_runtime_Converse.html), [Anthropic](https://docs.anthropic.com/en/api/messages), [Azure OpenAI](https://learn.microsoft.com/en-us/azure/ai-services/openai/reference), [Azure Serverless](https://learn.microsoft.com/en-us/rest/api/aifoundry/model-inference/get-chat-completions/get-chat-completions), [Cohere](https://docs.cohere.com/v2/reference/chat), [Deep Infra](https://deepinfra.com/docs/openai_api), [Fireworks AI](https://docs.fireworks.ai/api-reference/post-chatcompletions), [Google Gemini](https://ai.google.dev/api/generate-content), [Groq](https://console.groq.com/docs/api-reference#chat-create), [Hugging Face](https://huggingface.co/docs/inference-providers/en/tasks/chat-completion), [Hyperbolic](https://docs.hyperbolic.xyz/reference/create_chat_completion_v1_chat_completions_post), [IBM WatsonX](https://cloud.ibm.com/apidocs/watsonx-ai#text-chat), [Inception](https://docs.inceptionlabs.ai/get-started/get-started), [Meta](https://llama.developer.meta.com/docs/api/chat/), [Mistral](https://docs.mistral.ai/api/), [Moonshot AI](https://platform.moonshot.ai/docs/api/chat), [Nvidia](https://docs.api.nvidia.com/nim/reference/llm-apis), [OpenAI](https://platform.openai.com/docs/api-reference/chat), [Perplexity](https://docs.perplexity.ai/api-reference/chat-completions-post), [Together AI](https://docs.together.ai/reference/chat-completions-1), and [xAI](https://docs.x.ai/docs/api-reference#messages-anthropic-compatible).

The library calls the chat completions REST APIs and inference endpoints for each of the above AI providers. Everything is strongly-typed with the library handling all JSON serialization/deserialization for all requests and responses. Both non-stream and streaming functionality is supported using `async` methods for improved performance, and each client utilizes exponential retries to handle `429 Too Many Requests` responses.

## Requirements

Currently, only `.net10` is supported.

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
    "IbmWatsonX": {
        "AccessToken": "",
        "ModelId": "",
        "ProjectId": ""
	},
    "Inception": {
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
    "MoonshotAI": {
        "ApiKey": "",
        "Model": ""
    },
    "Nvidia": {
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
