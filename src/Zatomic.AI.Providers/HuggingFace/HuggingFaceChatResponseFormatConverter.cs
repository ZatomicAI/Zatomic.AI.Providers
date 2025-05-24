using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatResponseFormatConverter : JsonConverter<HuggingFaceChatBaseResponseFormat>
	{
		public override HuggingFaceChatBaseResponseFormat ReadJson(JsonReader reader, Type objectType, HuggingFaceChatBaseResponseFormat existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var obj = JObject.Load(reader);
			var type = obj["type"]?.Value<string>();

			HuggingFaceChatBaseResponseFormat item;

			if (type == "json") item = obj.ToObject<HuggingFaceChatJsonResponseFormat>(serializer);
			else if (type == "json_schema") item = obj.ToObject<HuggingFaceChatJsonSchemaResponseFormat>(serializer);
			else if (type == "regex") item = obj.ToObject<HuggingFaceChatRegexResponseFormat>(serializer);
			else throw new JsonSerializationException($"Unknown content type: {type}");

			return item;
		}

		public override void WriteJson(JsonWriter writer, HuggingFaceChatBaseResponseFormat value, JsonSerializer serializer)
		{
			JObject.FromObject(value, serializer).WriteTo(writer);
		}
	}
}
