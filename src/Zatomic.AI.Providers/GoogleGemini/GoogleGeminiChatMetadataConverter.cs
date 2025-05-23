using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.GoogleGemini
{
	public class GoogleGeminiChatMetadataConverter : JsonConverter<List<GoogleGeminiChatBaseMetadata>>
	{
		public override List<GoogleGeminiChatBaseMetadata> ReadJson(JsonReader reader, Type objectType, List<GoogleGeminiChatBaseMetadata> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<GoogleGeminiChatBaseMetadata>();

			foreach (var token in array)
			{
				GoogleGeminiChatBaseMetadata item;

				if (token["videoMetadata"] != null) item = token.ToObject<GoogleGeminiChatVideoMetadata>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {token}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<GoogleGeminiChatBaseMetadata> value, JsonSerializer serializer)
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
