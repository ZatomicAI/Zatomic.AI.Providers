using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.GoogleGemini
{
	public class GoogleGeminiChatAttributionSourceConverter : JsonConverter<List<GoogleGeminiChatBaseAttributionSource>>
	{
		public override List<GoogleGeminiChatBaseAttributionSource> ReadJson(JsonReader reader, Type objectType, List<GoogleGeminiChatBaseAttributionSource> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<GoogleGeminiChatBaseAttributionSource>();

			foreach (var token in array)
			{
				GoogleGeminiChatBaseAttributionSource item;

				if (token["groundingPassage"] != null) item = token.ToObject<GoogleGeminiChatGroundingPassage>(serializer);
				else if (token["semanticRetrieverChunk"] != null) item = token.ToObject<GoogleGeminiChatSemanticRetrieverChunk>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {token}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<GoogleGeminiChatBaseAttributionSource> value, JsonSerializer serializer)
		{
			writer.WriteStartArray();

			foreach (var item in value)
			{
				JToken.FromObject(item, serializer).WriteTo(writer);
			}

			writer.WriteEndArray();
		}
	}
}
