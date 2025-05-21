using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatContentListConverter : JsonConverter<List<AzureOpenAIChatBaseContent>>
	{
		public override List<AzureOpenAIChatBaseContent> ReadJson(JsonReader reader, Type objectType, List<AzureOpenAIChatBaseContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<AzureOpenAIChatBaseContent>();

			foreach (var token in array)
			{
				AzureOpenAIChatBaseContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<AzureOpenAIChatTextContent>(serializer);
				else if (type == "image_url") item = token.ToObject<AzureOpenAIChatImageUrlContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<AzureOpenAIChatBaseContent> value, JsonSerializer serializer)
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
