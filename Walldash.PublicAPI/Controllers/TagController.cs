using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Walldash.Domain.Model;
using Walldash.EntityFramework.Handlers;

namespace Walldash.PublicAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class TagController : ControllerBase
	{
		private readonly ILogger<TagController> _logger;

		public TagController(ILogger<TagController> logger)
		{
			_logger = logger;
		}

		[HttpGet("{alias}")]
		public ActionResult<Tag> Get(string alias)
		{
			//int accountId;
			//if(AccountController.TryGetAccountId(Request, out accountId))
			//{
			//	return Ok(MetricHandler.GetTagsByMetricAlias(accountId, alias));
			//}

			return NotFound(new Tag());
		}
	}
}
