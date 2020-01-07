using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Walldash.SystemMonitor
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}

	public class StockMonitor
	{
		private readonly string API_TOKEN = @"XLktlmXUdu9Dpvl7LZiDu9X4h7yG1ZSzRNPe4f0fEX04HB7i5DQ3PFlCFZOE";
		private readonly string ENDPOINT = @"https://api.worldtradingdata.com/api/v1";

		public StockMonitor()
		{

		}

		private HttpClient GetHttpClient()
		{
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Clear();
			client.BaseAddress = new Uri(ENDPOINT);

			return client;
		}


		public async Task<List<Stock>> GetStocks(params string[] symbols)
		{
			List<Stock> stocks = new List<Stock>();

			int maxCount = 5;
			int count = symbols.Length < maxCount ? maxCount : symbols.Length;
			if(count > 0)
			{
				string symbolsPlainText = string.Join(',', symbols.Take(count));

				using(HttpClient client = GetHttpClient())
				{
					var response = await client.GetAsync($"stock?symbol={symbolsPlainText}&api_token={API_TOKEN}");
					if(response.IsSuccessStatusCode)
					{
						string content = await response.Content.ReadAsStringAsync();
						stocks = JsonConvert.DeserializeObject<List<Stock>>(content);
					}
				}
			}

			return stocks;
		}

		public class Stock
		{
			public string Symbol { get; set; }
		}
	}
}
