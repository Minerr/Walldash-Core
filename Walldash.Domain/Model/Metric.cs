using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Walldash.Domain.Model
{
	public class Metric : IEntity
	{
		public int Id { get; set; }
		[JsonIgnore] public int AccountId { get; set; }
		public string Alias { get; set; }
		public double Number { get; set; }
		public DateTimeOffset Timestamp { get; set; }
		public string Tag { get; set; }
	}
}
