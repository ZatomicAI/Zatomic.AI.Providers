using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatContentListConverter : JsonConverter<List<OpenAIChatBaseContent>>
	{
		public override List<OpenAIChatBaseContent> ReadJson(JsonReader reader, Type objectType, List<OpenAIChatBaseContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<OpenAIChatBaseContent>();

			foreach (var token in array)
			{
				OpenAIChatBaseContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<OpenAIChatTextContent>(serializer);
				else if (type == "image_url") item = token.ToObject<OpenAIChatImageUrlContent>(serializer);
				else if (type == "input_audio") item = token.ToObject<OpenAIChatInputAudioContent>(serializer);
				else if (type == "file") item = token.ToObject<OpenAIChatFileContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<OpenAIChatBaseContent> value, JsonSerializer serializer)
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
