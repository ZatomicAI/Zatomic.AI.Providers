namespace Zatomic.AI.Providers.Cohere
{
	public static class CohereStreamEventTypes
	{
		public const string ContentDelta = "content-delta";
		public const string ContentStart = "content-start";
		public const string ContentEnd = "content-end";
		public const string MessageStart = "message-start";
		public const string MessageEnd = "message-end";
	}
}
