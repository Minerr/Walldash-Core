using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Walldash.Domain.Model
{
	public class Account : IEntity
	{
		public int Id { get; set; }
		public Guid Token { get; set; }
		public string Alias { get; set; }
		public List<Dashboard> Dashboards { get; set; }
		public List<Metric> Metrics { get; set; }
	}
}
