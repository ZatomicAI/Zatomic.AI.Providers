using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public abstract class GoogleGeminiChatBasePart
	{
		// This property is used to identify the type of the chat part, but it's not
		// something Google expects on input and Google doesn't returns this property
		// on output. This is here to allow us to use GoogleGeminiChatPartsListConverter
		// to dynamically convert the JSON to the correct type.

		[JsonIgnore]
		public string Type { get; set; }
	}
}
