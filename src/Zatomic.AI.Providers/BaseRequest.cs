using Zatomic.AI.Providers.Extensions;

namespace Zatomic.AI.Providers
{
	public abstract class BaseRequest
	{
		public T Clone<T>() where T : BaseRequest
		{
			var serialized = this.Serialize();
			return serialized.Deserialize<T>();
		}
	}
}
