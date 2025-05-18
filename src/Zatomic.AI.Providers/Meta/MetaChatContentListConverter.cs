using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaChatContentListConverter : JsonConverter<List<MetaChatBaseContent>>
	{
		public override List<MetaChatBaseContent> ReadJson(JsonReader reader, Type objectType, List<MetaChatBaseContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<MetaChatBaseContent>();

			foreach (var token in array)
			{
				MetaChatBaseContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<MetaChatTextContent>(serializer);
				else if (type == "image") item = token.ToObject<MetaChatImageContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<MetaChatBaseContent> value, JsonSerializer serializer)
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
