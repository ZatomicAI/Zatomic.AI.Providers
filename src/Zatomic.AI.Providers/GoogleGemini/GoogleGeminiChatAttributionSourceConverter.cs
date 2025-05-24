using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.GoogleGemini
{
	public class GoogleGeminiChatAttributionSourceConverter : JsonConverter<GoogleGeminiChatBaseAttributionSource>
	{
		public override GoogleGeminiChatBaseAttributionSource ReadJson(JsonReader reader, Type objectType, GoogleGeminiChatBaseAttributionSource existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			GoogleGeminiChatBaseAttributionSource item;

			var obj = JObject.Load(reader);
			
			if (obj["groundingPassage"] != null) item = obj.ToObject<GoogleGeminiChatGroundingPassage>(serializer);
			else if (obj["semanticRetrieverChunk"] != null) item = obj.ToObject<GoogleGeminiChatSemanticRetrieverChunk>(serializer);
			else throw new JsonSerializationException($"Unknown content type: {obj}");

			return item;
		}

		public override void WriteJson(JsonWriter writer, GoogleGeminiChatBaseAttributionSource value, JsonSerializer serializer)
		{
			JObject.FromObject(value, serializer).WriteTo(writer);
		}
	}
}
