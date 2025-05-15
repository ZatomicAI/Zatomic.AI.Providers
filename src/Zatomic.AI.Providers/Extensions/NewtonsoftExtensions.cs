using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Extensions
{
	public static class NewtonsoftExtensions
	{
		public static T Deserialize<T>(this string value)
		{
			return JsonConvert.DeserializeObject<T>(value);
		}

		public static string Serialize(this object value)
		{
			return JsonConvert.SerializeObject(value);
		}
	}
}
