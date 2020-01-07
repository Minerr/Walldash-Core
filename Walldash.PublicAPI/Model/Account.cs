using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Walldash.PublicAPI.Model
{
	public class Account
	{
		public int Id { get; set; }
		public Guid Token { get; set; }
		public string Alias { get; set; }
	}
}
