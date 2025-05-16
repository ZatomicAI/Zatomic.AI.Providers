using System;
using Zatomic.AI.Providers.AI21Labs;
using Zatomic.AI.Providers.Anthropic;
using Zatomic.AI.Providers.Cohere;
using Zatomic.AI.Providers.DeepInfra;
using Zatomic.AI.Providers.Extensions;
using Zatomic.AI.Providers.FireworksAI;

namespace Zatomic.AI.Providers.Exceptions
{
	public static class AIExceptionUtility
	{
		// NOTE: We clear the messages on all request objects to avoid data bloat in the thrown
		// exception and any unwanted logging of messages downstream (the cloning of the request
		// objects is to ensure thread safety). When the response JSON gets logged it will contain
		// the error response from the provider, not AI assistant responses.

		public static AIException BuildAI21LabsAIException(Exception ex, AI21LabsRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<AI21LabsRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("AI21 Labs", ex, clonedReq, responseJson);
		}

		public static AIException BuildAnthropicAIException(Exception ex, AnthropicRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<AnthropicRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Anthropic", ex, clonedReq, responseJson);
		}

		public static AIException BuildCohereAIException(Exception ex, CohereRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<CohereRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Cohere", ex, clonedReq, responseJson);
		}

		public static AIException BuildDeepInfraAIException(Exception ex, DeepInfraRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<DeepInfraRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Deep Infra", ex, clonedReq, responseJson);
		}

		public static AIException BuildFireworksAIAIException(Exception ex, FireworksAIRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<FireworksAIRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Fireworks AI", ex, clonedReq, responseJson);
		}

		private static AIException BuildAIException(string provider, Exception ex, BaseRequest request, string responseJson = null)
		{
			var aiEx = new AIException(ex.Message) { Provider = provider, Request = request.Serialize() };

			if (!responseJson.IsNullOrEmpty())
			{
				aiEx.Response = responseJson;
			}

			return aiEx;
		}
	}
}
