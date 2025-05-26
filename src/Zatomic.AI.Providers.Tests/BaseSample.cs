using System;
using Microsoft.Extensions.Configuration;

namespace Zatomic.AI.Providers.Tests
{
	public abstract class BaseSample
	{
		public IConfiguration Configuration { get; set; }
		public string SystemPrompt { get; set; } = "You are a knowledgeable and helpful assistant.";
		public string UserPrompt { get; set; } = "Why is the sky blue? Keep it brief.";

		public BaseSample()
		{
			Configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.Development.json").Build();
		}

		public void WriteOutput(string output)
		{
			Console.WriteLine(output);
		}

		public void WriteOutput(int inputTokens, int outputTokens, int totalTokens, decimal duration)
		{
			Console.WriteLine($"Input tokens: {inputTokens}");
			Console.WriteLine($"Output tokens: {outputTokens}");
			Console.WriteLine($"Total tokens: {totalTokens}");
			Console.WriteLine($"Duration: {duration} sec");
		}
	}
}
