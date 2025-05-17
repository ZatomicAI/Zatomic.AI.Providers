using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaContentListConverter : JsonConverter<List<MetaBaseContent>>
	{
		public override List<MetaBaseContent> ReadJson(JsonReader reader, Type objectType, List<MetaBaseContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<MetaBaseContent>();

			foreach (var token in array)
			{
				MetaBaseContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<MetaTextContent>(serializer);
				else if (type == "image") item = token.ToObject<MetaImageContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<MetaBaseContent> value, JsonSerializer serializer)
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
