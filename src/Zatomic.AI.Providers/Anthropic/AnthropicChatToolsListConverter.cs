using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatToolsListConverter : JsonConverter<List<AnthropicChatBaseTool>>
	{
		public override List<AnthropicChatBaseTool> ReadJson(JsonReader reader, Type objectType, List<AnthropicChatBaseTool> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<AnthropicChatBaseTool>();

			foreach (var token in array)
			{
				AnthropicChatBaseTool item;

				var type = token["type"]?.Value<string>();

				if (type == "custom") item = token.ToObject<AnthropicChatCustomTool>(serializer);
				else if (type == "computer_20250124") item = token.ToObject<AnthropicChatComputerUseTool>(serializer);
				else if (type == "bash_20250124") item = token.ToObject<AnthropicChatBashTool>(serializer);
				else if (type == "text_editor_20250124") item = token.ToObject<AnthropicChatTextEditorTool>(serializer);
				else if (type == "web_search_20250305") item = token.ToObject<AnthropicChatWebSearchTool>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<AnthropicChatBaseTool> value, JsonSerializer serializer)
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
