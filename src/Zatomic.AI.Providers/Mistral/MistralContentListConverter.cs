using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralContentListConverter : JsonConverter<List<BaseMistralContent>>
	{
		public override List<BaseMistralContent> ReadJson(JsonReader reader, Type objectType, List<BaseMistralContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<BaseMistralContent>();

			foreach (var token in array)
			{
				BaseMistralContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<MistralTextContent>(serializer);
				else if (type == "image_url") item = token.ToObject<MistralImageUrlContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<BaseMistralContent> value, JsonSerializer serializer)
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
