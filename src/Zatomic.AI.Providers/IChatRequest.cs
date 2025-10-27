namespace Zatomic.AI.Providers
{
	public interface IChatRequest
	{
		void AddAssistantMessage(string content);
		void AddSystemMessage(string content);
		void AddUserMessage(string content);
		void ClearMessages();
	}
}
