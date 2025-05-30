using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatContentListConverter : JsonConverter<List<GroqChatBaseContent>>
	{
		public override List<GroqChatBaseContent> ReadJson(JsonReader reader, Type objectType, List<GroqChatBaseContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<GroqChatBaseContent>();

			foreach (var token in array)
			{
				GroqChatBaseContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<GroqChatTextContent>(serializer);
				else if (type == "image_url") item = token.ToObject<GroqChatImageUrlContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<GroqChatBaseContent> value, JsonSerializer serializer)
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
