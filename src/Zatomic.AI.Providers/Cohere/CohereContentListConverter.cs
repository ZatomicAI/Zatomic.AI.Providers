using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereContentListConverter : JsonConverter<List<BaseCohereContent>>
	{
		public override List<BaseCohereContent> ReadJson(JsonReader reader, Type objectType, List<BaseCohereContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<BaseCohereContent>();

			foreach (var token in array)
			{
				BaseCohereContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<CohereTextContent>(serializer);
				else if (type == "image_url") item = token.ToObject<CohereImageUrlContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<BaseCohereContent> value, JsonSerializer serializer)
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
