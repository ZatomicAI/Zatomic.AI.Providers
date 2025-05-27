using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Zatomic.AI.Providers
{
	public abstract class BaseClient
	{
		public async Task<HttpResponseMessage> DoWithRetryAsync(Func<Task<HttpResponseMessage>> doAsync)
		{
			var retryCount = 0;
			var maxRetries = 5;
			var delaySeconds = 1.0;
			var maxDelaySeconds = 30.0;

			while (true)
			{
				var response = await doAsync();

				// If we don't get a 429 then we're good so return the response
				if (response.StatusCode != HttpStatusCode.TooManyRequests)
				{
					return response;
				}

				retryCount++;

				// If we've hit the max retries, return the response for caller to handle
				if (retryCount > maxRetries)
				{
					return response;
				}

				// If the response has a Retry-After header, then use that for the delay; otherwise use ours
				var waitSeconds = response.Headers.RetryAfter?.Delta?.TotalSeconds ?? delaySeconds;
				waitSeconds = Math.Min(waitSeconds, maxDelaySeconds);

				// Do the wait and set the delay for the next iteration
				await Task.Delay(TimeSpan.FromSeconds(waitSeconds));
				delaySeconds = Math.Min(delaySeconds * 2, maxDelaySeconds);
			}
		}
	}
}
