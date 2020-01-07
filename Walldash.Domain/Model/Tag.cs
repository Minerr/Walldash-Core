using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walldash.Domain.Model
{
	public class Tag
	{
		public string Alias { get; set; }
	}

	public class MetricTag : IEntity
	{
		public int Id { get; set; }
		public Tag Tag { get; set; }
		public Metric Metric { get; set; }
	}

	public class WidgetTag : IEntity
	{
		public int Id { get; set; }
		public Tag Tag { get; set; }
		public Widget Widget { get; set; }
	}
}
