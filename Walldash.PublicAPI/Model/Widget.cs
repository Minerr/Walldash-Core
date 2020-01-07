using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Walldash.PublicAPI.Model
{
	public class Widget
	{
		public int Id { get; set; }
		public string Alias { get; set; }
		public int DashboardId { get; set; }
		public string MetricAlias { get; set; }
		public string Type { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public StyleSettings StyleSettings { get; set; }
		public List<string> TagFilter { get; set; }
	}

	public class StyleSettings
	{
		public string BackgroundColor { get; set; }
		public string TextColor { get; set; }
	}

	public class GraphSettings : Widget
	{
		public string GraphType { get; set; }
		public string GraphColor { get; set; }
		public string GraphValue { get; set; }
	}
}
