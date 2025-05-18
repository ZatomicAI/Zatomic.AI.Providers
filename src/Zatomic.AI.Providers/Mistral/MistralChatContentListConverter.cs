using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralChatContentListConverter : JsonConverter<List<MistralChatBaseContent>>
	{
		public override List<MistralChatBaseContent> ReadJson(JsonReader reader, Type objectType, List<MistralChatBaseContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<MistralChatBaseContent>();

			foreach (var token in array)
			{
				MistralChatBaseContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<MistralChatTextContent>(serializer);
				else if (type == "image_url") item = token.ToObject<MistralChatImageUrlContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<MistralChatBaseContent> value, JsonSerializer serializer)
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
