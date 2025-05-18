using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Lambda
{
	public class LambdaChatContentListConverter : JsonConverter<List<LambdaChatBaseContent>>
	{
		public override List<LambdaChatBaseContent> ReadJson(JsonReader reader, Type objectType, List<LambdaChatBaseContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<LambdaChatBaseContent>();

			foreach (var token in array)
			{
				LambdaChatBaseContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<LambdaChatTextContent>(serializer);
				else if (type == "image_url") item = token.ToObject<LambdaChatImageUrlContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<LambdaChatBaseContent> value, JsonSerializer serializer)
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
