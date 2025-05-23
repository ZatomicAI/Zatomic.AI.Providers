using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatCitationsListConverter : JsonConverter<List<AnthropicChatBaseCitation>>
	{
		public override List<AnthropicChatBaseCitation> ReadJson(JsonReader reader, Type objectType, List<AnthropicChatBaseCitation> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<AnthropicChatBaseCitation>();

			foreach (var token in array)
			{
				AnthropicChatBaseCitation item;

				var type = token["type"]?.Value<string>();

				if (type == "char_location") item = token.ToObject<AnthropicChatCharacterLocationCitation>(serializer);
				else if (type == "page_location") item = token.ToObject<AnthropicChatPageLocationCitation>(serializer);
				else if (type == "content_block_location") item = token.ToObject<AnthropicChatContentBlockLocationCitation>(serializer);
				else if (type == "web_search_result_location") item = token.ToObject<AnthropicChatWebSearchResultLocationCitation>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<AnthropicChatBaseCitation> value, JsonSerializer serializer)
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
