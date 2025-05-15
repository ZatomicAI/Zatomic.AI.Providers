namespace Zatomic.AI.Providers.Anthropic
{
	public static class AnthropicStreamEventTypes
	{
		public const string ContentBlockDelta = "content_block_delta";
		public const string ContentBlockStart = "content_block_start";
		public const string ContentBlockStop = "content_block_stop";
		public const string MessageDelta = "message_delta";
		public const string MessageStart = "message_start";
		public const string MessageStop = "message_stop";
		public const string Ping = "ping";
	}
}
