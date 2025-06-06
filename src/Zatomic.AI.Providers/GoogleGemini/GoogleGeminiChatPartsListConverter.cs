﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.GoogleGemini
{
	public class GoogleGeminiChatPartsListConverter : JsonConverter<List<GoogleGeminiChatBasePart>>
	{
		public override List<GoogleGeminiChatBasePart> ReadJson(JsonReader reader, Type objectType, List<GoogleGeminiChatBasePart> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			var items = new List<GoogleGeminiChatBasePart>();

			foreach (var token in array)
			{
				GoogleGeminiChatBasePart item;

				if (token["text"] != null) item = token.ToObject<GoogleGeminiChatTextPart>(serializer);
				else if (token["inlineData"] != null) item = token.ToObject<GoogleGeminiChatInlineDataPart>(serializer);
				else if (token["functionCall"] != null) item = token.ToObject<GoogleGeminiChatFunctionCallPart>(serializer);
				else if (token["functionResponse"] != null) item = token.ToObject<GoogleGeminiChatFunctionResponsePart>(serializer);
				else if (token["fileData"] != null) item = token.ToObject<GoogleGeminiChatFileDataPart>(serializer);
				else if (token["executableCode"] != null) item = token.ToObject<GoogleGeminiChatExecutableCodePart>(serializer);
				else if (token["codeExecutionResult"] != null) item = token.ToObject<GoogleGeminiChatCodeExecutionResultPart>(serializer);
				else throw new JsonSerializationException($"Unknown content type: {token}");

				items.Add(item);
			}

			return items;
		}

		public override void WriteJson(JsonWriter writer, List<GoogleGeminiChatBasePart> value, JsonSerializer serializer)
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
