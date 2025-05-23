using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.GoogleGemini
{
	public class GoogleGeminiChatChunkTypeConverter : JsonConverter<List<GoogleGeminiChatBaseChunkType>>
	{
		public override List<GoogleGeminiChatBaseChunkType> ReadJson(JsonReader reader, Type objectType, List<GoogleGeminiChatBaseChunkType> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<GoogleGeminiChatBaseChunkType>();

			foreach (var token in array)
			{
				GoogleGeminiChatBaseChunkType item;

				if (token["web"] != null) item = token.ToObject<GoogleGeminiChatWebChunkType>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {token}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<GoogleGeminiChatBaseChunkType> value, JsonSerializer serializer)
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
