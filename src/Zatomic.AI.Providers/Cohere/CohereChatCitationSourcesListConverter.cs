using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatCitationSourcesListConverter : JsonConverter<List<CohereChatBaseCitationSource>>
	{
		public override List<CohereChatBaseCitationSource> ReadJson(JsonReader reader, Type objectType, List<CohereChatBaseCitationSource> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<CohereChatBaseCitationSource>();

			foreach (var token in array)
			{
				CohereChatBaseCitationSource item;

				var type = token["type"]?.Value<string>();

				if (type == "tool") item = token.ToObject<CohereChatToolCitationSource>(serializer);
				else if (type == "document") item = token.ToObject<CohereChatDocumentCitationSource>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {type}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<CohereChatBaseCitationSource> value, JsonSerializer serializer)
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
