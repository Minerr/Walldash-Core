using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Walldash.PublicAPI.Model
{
	public class Metric
	{
		public int Id { get; set; }
		public string Alias { get; set; }
		public double Number { get; set; }
		public DateTimeOffset Timestamp { get; set; }
		public List<string> Tags { get; set; }
	}
}
