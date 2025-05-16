using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Zatomic.AI.Providers.Exceptions;
using Zatomic.AI.Providers.Extensions;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaClient
	{
		public string ApiKey { get; set; }
		public string ApiUrl { get; set; } = "https://api.llama.com/v1/chat/completions";

		public MetaClient()
		{
		}

		public MetaClient(string apiKey) : this()
		{
			ApiKey = apiKey;
		}

		public async Task<MetaResponse> ChatAsync(MetaRequest request)
		{
			MetaResponse response = null;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

				var requestJson = request.Serialize();
				var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

				string responseJson = null;

				try
				{
					var stopwatch = Stopwatch.StartNew();

					var postResponse = await httpClient.PostAsync(ApiUrl, content);
					responseJson = await postResponse.Content.ReadAsStringAsync();
					postResponse.EnsureSuccessStatusCode();

					stopwatch.Stop();

					response = responseJson.Deserialize<MetaResponse>();
					response.Duration = stopwatch.ToDurationInSeconds(2);
				}
				catch (Exception ex)
				{
					var aiEx = AIExceptionUtility.BuildMetaAIException(ex, request, responseJson);
					throw aiEx;
				}
			}

			return response;
		}
	}
}
