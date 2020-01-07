using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Walldash.PublicAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class HomeController : ControllerBase
	{
		/// <summary>
		/// Redirect to the swagger API docs
		/// </summary>
		[HttpGet("/api")]
		[HttpGet("/api/docs")]
		public ActionResult Get()
		{
			return Redirect("/swagger");
		}
	}
}
