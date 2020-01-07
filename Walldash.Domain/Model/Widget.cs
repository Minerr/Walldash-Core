using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Walldash.Domain.Model
{
	public class Widget : IEntity
	{
		public int Id { get; set; }
		public string Alias { get; set; }
		public int DashboardId { get; set; }
		public string MetricAlias { get; set; }
		public string Type { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public string BackgroundColor { get; set; }
		public string TextColor { get; set; }
		public string[] TagFilter { get; set; }
	}

	public class GraphWidget : Widget
	{
		public string GraphType { get; set; }
		public string GraphColor { get; set; }
		public string GraphValueX { get; set; }
		public string GraphValueY { get; set; }

	}
}
