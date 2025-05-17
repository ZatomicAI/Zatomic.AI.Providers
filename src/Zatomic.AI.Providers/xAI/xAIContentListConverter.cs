using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIContentListConverter : JsonConverter<List<xAIBaseContent>>
	{
		public override List<xAIBaseContent> ReadJson(JsonReader reader, Type objectType, List<xAIBaseContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<xAIBaseContent>();

			foreach (var token in array)
			{
				xAIBaseContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<xAITextContent>(serializer);
				else if (type == "image_url") item = token.ToObject<xAIImageUrlContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<xAIBaseContent> value, JsonSerializer serializer)
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
