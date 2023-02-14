using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitcoinPriceLookup
{
	public class KucoinClient
	{
		private HttpClient _httpClient;

		public KucoinClient()
		{
			_httpClient = new HttpClient();
		}

		public async Task<MarketStatsResponse> Get24hStats(string symbol)
		{
			HttpResponseMessage response = await _httpClient.GetAsync(new Uri($"https://api.kucoin.com/api/v1/market/stats?symbol=BTC-{symbol.ToUpper()}"));

			if (response.IsSuccessStatusCode)
			{
                string content = await response.Content.ReadAsStringAsync();
				var stats = JsonSerializer.Deserialize<MarketStatsResponse>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, NumberHandling = JsonNumberHandling.AllowReadingFromString });
				return stats;
			}
			else
			{
				throw new Exception(response.ReasonPhrase);
			}
		}
	}
}

