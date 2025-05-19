using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatContentListConverter : JsonConverter<List<HuggingFaceChatBaseContent>>
	{
		public override List<HuggingFaceChatBaseContent> ReadJson(JsonReader reader, Type objectType, List<HuggingFaceChatBaseContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<HuggingFaceChatBaseContent>();

			foreach (var token in array)
			{
				HuggingFaceChatBaseContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<HuggingFaceChatTextContent>(serializer);
				else if (type == "image_url") item = token.ToObject<HuggingFaceChatImageUrlContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<HuggingFaceChatBaseContent> value, JsonSerializer serializer)
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
