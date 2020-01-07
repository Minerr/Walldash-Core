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
	public class DashboardController : ControllerBase
	{
		private readonly ILogger<DashboardController> _logger;

		public DashboardController(ILogger<DashboardController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Dashboard>> Get()
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				return Ok(DashboardHandler.GetAll(accountId));
			}

			return NotFound();
		}

		[HttpGet("{id}")]
		public ActionResult<Dashboard> Get(int id)
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				return Ok(DashboardHandler.Get(accountId, id));
			}

			return NotFound();
		}

		[HttpPost]
		public ActionResult<int> Post(Dashboard dashboard)
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				dashboard.AccountId = accountId;
				return Ok(DashboardHandler.Create(dashboard));
			}

			return NotFound();
		}

		[HttpPut("{id}")]
		public ActionResult Put(int id, Dashboard dashboard)
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				dashboard.AccountId = accountId;
				DashboardHandler.Update(id, dashboard);
				return NoContent();
			}

			return NotFound();
		}

		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				DashboardHandler.Delete(accountId, id);
				return NoContent();
			}

			return NotFound();
		}

		//private Dashboard ConvertModelToDomain(int accountId, Model.Dashboard dashboard)
		//{
		//	return new Dashboard()
		//	{
		//		AccountId = accountId,
		//		Alias = dashboard.Alias,
		//		Id = dashboard.Id,
		//		Widgets = new List<Widget>()
		//	};
		//}
	}
}
