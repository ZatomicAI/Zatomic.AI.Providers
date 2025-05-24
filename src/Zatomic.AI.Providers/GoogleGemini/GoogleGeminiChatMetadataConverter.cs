using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.GoogleGemini
{
	public class GoogleGeminiChatMetadataConverter : JsonConverter<GoogleGeminiChatBaseMetadata>
	{
		public override GoogleGeminiChatBaseMetadata ReadJson(JsonReader reader, Type objectType, GoogleGeminiChatBaseMetadata existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			GoogleGeminiChatBaseMetadata item;

			var obj = JObject.Load(reader);

			if (obj["videoMetadata"] != null) item = obj.ToObject<GoogleGeminiChatVideoMetadata>(serializer);
			else throw new JsonSerializationException($"Unknown content type: {obj}");

			return item;
		}

		public override void WriteJson(JsonWriter writer, GoogleGeminiChatBaseMetadata value, JsonSerializer serializer)
		{
			JObject.FromObject(value, serializer).WriteTo(writer);
		}
	}
}
