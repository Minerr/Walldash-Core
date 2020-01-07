using System;
using System.Collections.Generic;
using System.Linq;
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
	public class MetricController : ControllerBase
	{
		private readonly ILogger<MetricController> _logger;

		public MetricController(ILogger<MetricController> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Get all metrics
		/// </summary>
		[HttpGet]
		public ActionResult<IEnumerable<Metric>> Get()
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				return Ok(MetricHandler.GetAll(accountId));
			}

			return NotFound();
		}

		/// <summary>
		/// Get a specific metric
		/// </summary>
		[HttpGet("{id}")]
		public ActionResult<Metric> Get(int id)
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				return Ok(MetricHandler.Get(accountId, id));
			}

			return NotFound();
		}

		/// <summary>
		/// Get a specific metric
		/// </summary>
		[HttpGet("GetByFilter")]
		public ActionResult<Metric> GetByFilter(string alias = null, HashSet<string> tags = null)
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				bool filterByAlias = !string.IsNullOrWhiteSpace(alias);
				bool filterByTags = tags != null;

				if(filterByAlias && filterByTags)
				{
					return Ok(MetricHandler.GetAllByAliasAndTags(accountId, alias, tags));
				}
				else if(filterByAlias)
				{
					return Ok(MetricHandler.GetAllByAlias(accountId, alias));
				}
				else if(filterByTags)
				{
					return Ok(MetricHandler.GetAllByTags(accountId, tags));
				}

				return NotFound();
			}

			return Unauthorized();
		}

		/// <summary>
		/// Get all metric aliases
		/// </summary>
		[HttpGet("GetAliases")]
		public ActionResult<IEnumerable<string>> GetAliases()
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				return Ok(MetricHandler.GetAliases(accountId));
			}

			return NotFound();
		}

		/// <summary>
		/// Get the most recent metric by its timestamp
		/// </summary>
		[HttpGet("GetLatest/{alias}")]
		public ActionResult<Metric> GetLatest(string alias, HashSet<string> tags = null)
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				if(tags != null)
				{
					return Ok(MetricHandler.GetLatestByTags(accountId, alias, tags));
				}

				return Ok(MetricHandler.GetLatest(accountId, alias));
			}

			return Unauthorized();
		}

		/// <summary>
		/// Save a metric to the database
		/// </summary>
		[HttpPost]
		public ActionResult<int> Post(Metric metric)
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				metric.AccountId = accountId;
				return Ok(MetricHandler.Create(metric));
			}

			return NotFound();
		}

		// PUT: api/metric/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, Metric metric)
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				MetricHandler.Update(accountId, id, metric);
				return NoContent();
			}

			return NotFound();
		}

		// DELETE: api/metric/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				MetricHandler.Delete(accountId, id);
				return NoContent();
			}

			return NotFound();
		}
	}
}
