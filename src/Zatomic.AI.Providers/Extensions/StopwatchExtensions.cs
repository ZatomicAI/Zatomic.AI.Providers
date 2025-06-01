using System;
using System.Diagnostics;

namespace Zatomic.AI.Providers.Extensions
{
	internal static class StopwatchExtensions
	{
		public static decimal ToDurationInSeconds(this Stopwatch stopwatch, int decimalPlaces)
		{
			var duration = Math.Round((decimal)stopwatch.ElapsedMilliseconds / 1000, decimalPlaces);
			return duration;
		}
	}
}
