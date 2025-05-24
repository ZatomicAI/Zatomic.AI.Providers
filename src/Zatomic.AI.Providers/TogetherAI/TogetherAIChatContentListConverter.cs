using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIChatContentListConverter : JsonConverter<List<TogetherAIChatBaseContent>>
	{
		public override List<TogetherAIChatBaseContent> ReadJson(JsonReader reader, Type objectType, List<TogetherAIChatBaseContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<TogetherAIChatBaseContent>();

			foreach (var token in array)
			{
				TogetherAIChatBaseContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<TogetherAIChatTextContent>(serializer);
				else if (type == "image_url") item = token.ToObject<TogetherAIChatImageUrlContent>(serializer);
				else if (type == "video_url") item = token.ToObject<TogetherAIChatVideoUrlContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<TogetherAIChatBaseContent> value, JsonSerializer serializer)
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
