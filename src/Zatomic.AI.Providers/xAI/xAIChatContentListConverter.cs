using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatContentListConverter : JsonConverter<List<xAIChatBaseContent>>
	{
		public override List<xAIChatBaseContent> ReadJson(JsonReader reader, Type objectType, List<xAIChatBaseContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<xAIChatBaseContent>();

			foreach (var token in array)
			{
				xAIChatBaseContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<xAIChatTextContent>(serializer);
				else if (type == "image_url") item = token.ToObject<xAIChatImageUrlContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<xAIChatBaseContent> value, JsonSerializer serializer)
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
