using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Walldash.Domain.Model
{
	public class Dashboard : IEntity
	{
		public int Id { get; set; }
		[JsonIgnore]public int AccountId { get; set; }
		public string Alias { get; set; }
		[JsonIgnore] public List<Widget> Widgets { get; set; }
		public int Columns { get; set; }
		public int Rows { get; set; }
		public string BackgroundColor { get; set; }
		public string NavbarColor { get; set; }
	}
}
