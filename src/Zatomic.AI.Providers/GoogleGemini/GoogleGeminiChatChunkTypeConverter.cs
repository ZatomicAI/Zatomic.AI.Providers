using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.GoogleGemini
{
	public class GoogleGeminiChatChunkTypeConverter : JsonConverter<GoogleGeminiChatBaseChunkType>
	{
		public override GoogleGeminiChatBaseChunkType ReadJson(JsonReader reader, Type objectType, GoogleGeminiChatBaseChunkType existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			GoogleGeminiChatBaseChunkType item;

			var obj = JObject.Load(reader);

			if (obj["web"] != null) item = obj.ToObject<GoogleGeminiChatWebChunkType>(serializer);
			else throw new JsonSerializationException($"Unknown content type: {obj}");

			return item;
		}

		public override void WriteJson(JsonWriter writer, GoogleGeminiChatBaseChunkType value, JsonSerializer serializer)
		{
			JObject.FromObject(value, serializer).WriteTo(writer);
		}
	}
}
