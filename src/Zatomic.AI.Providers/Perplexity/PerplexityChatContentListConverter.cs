using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Perplexity
{
	public class PerplexityChatContentListConverter : JsonConverter<List<PerplexityChatBaseContent>>
	{
		public override List<PerplexityChatBaseContent> ReadJson(JsonReader reader, Type objectType, List<PerplexityChatBaseContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<PerplexityChatBaseContent>();

			foreach (var token in array)
			{
				PerplexityChatBaseContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<PerplexityChatTextContent>(serializer);
				else if (type == "image_url") item = token.ToObject<PerplexityChatImageUrlContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<PerplexityChatBaseContent> value, JsonSerializer serializer)
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
