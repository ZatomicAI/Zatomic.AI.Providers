using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public class IbmWatsonXChatContentListConverter : JsonConverter<List<IbmWatsonXChatBaseContent>>
	{
		public override List<IbmWatsonXChatBaseContent> ReadJson(JsonReader reader, Type objectType, List<IbmWatsonXChatBaseContent> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<IbmWatsonXChatBaseContent>();

			foreach (var token in array)
			{
				IbmWatsonXChatBaseContent item;

				var type = token["type"]?.Value<string>();

				if (type == "text") item = token.ToObject<IbmWatsonXChatTextContent>(serializer);
				else if (type == "image_url") item = token.ToObject<IbmWatsonXChatImageUrlContent>(serializer);
				else if (type == "input_audio") item = token.ToObject<IbmWatsonXChatInputAudioContent>(serializer);
				else if (type == "video_url") item = token.ToObject<IbmWatsonXChatVideoUrlContent>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<IbmWatsonXChatBaseContent> value, JsonSerializer serializer)
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
