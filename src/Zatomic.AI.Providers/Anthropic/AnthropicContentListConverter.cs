using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicContentListConverter : JsonConverter<List<BaseAnthropicContent>>
	{
		public override List<BaseAnthropicContent> ReadJson(JsonReader reader, Type objectType, List<BaseAnthropicContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<BaseAnthropicContent>();

			foreach (var token in array)
			{
				BaseAnthropicContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<AnthropicTextContent>(serializer);
				else if (type == "image") item = token.ToObject<AnthropicImageContent>(serializer);
				else if (type == "thinking") item = token.ToObject<AnthropicThinkingContent>(serializer);
				else if (type == "redacted_thinking") item = token.ToObject<AnthropicRedactedThinkingContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<BaseAnthropicContent> value, JsonSerializer serializer)
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
