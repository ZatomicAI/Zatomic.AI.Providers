using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatContentListConverter : JsonConverter<List<AnthropicChatBaseContent>>
	{
		public override List<AnthropicChatBaseContent> ReadJson(JsonReader reader, Type objectType, List<AnthropicChatBaseContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<AnthropicChatBaseContent>();

			foreach (var token in array)
			{
				AnthropicChatBaseContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<AnthropicChatTextContent>(serializer);
				else if (type == "image") item = token.ToObject<AnthropicChatImageContent>(serializer);
				else if (type == "thinking") item = token.ToObject<AnthropicChatThinkingContent>(serializer);
				else if (type == "redacted_thinking") item = token.ToObject<AnthropicChatRedactedThinkingContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<AnthropicChatBaseContent> value, JsonSerializer serializer)
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
