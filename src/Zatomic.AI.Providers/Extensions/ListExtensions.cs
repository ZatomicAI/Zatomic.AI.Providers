using System.Collections.Generic;
using System.Linq;

namespace Zatomic.AI.Providers.Extensions
{
	public static class ListExtensions
	{
		public static string ToDelimitedString(this List<string> list, string delimiter)
		{
			return (list == null || !list.Any()) ? string.Empty : string.Join(delimiter, list);
		}
	}
}
