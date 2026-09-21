using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatContentListConverter : JsonConverter<List<MicrosoftFoundryChatBaseContent>>
	{
		public override List<MicrosoftFoundryChatBaseContent> ReadJson(JsonReader reader, Type objectType, List<MicrosoftFoundryChatBaseContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<MicrosoftFoundryChatBaseContent>();

			foreach (var token in array)
			{
				MicrosoftFoundryChatBaseContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<MicrosoftFoundryChatTextContent>(serializer);
				else if (type == "image_url") item = token.ToObject<MicrosoftFoundryChatImageUrlContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<MicrosoftFoundryChatBaseContent> value, JsonSerializer serializer)
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
