using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Walldash.Domain.Model;
using Walldash.EntityFramework.Handlers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Walldash.PublicAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class WidgetController : ControllerBase
	{
		private readonly ILogger<WidgetController> _logger;

		public WidgetController(ILogger<WidgetController> logger)
		{
			_logger = logger;
		}

		[HttpGet("GetByDashboardId/{dashboardId}")]
		public ActionResult<IEnumerable<JObject>> GetByDashboardId(int dashboardId)
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				var widgets = WidgetHandler.GetAllByDashboardId(accountId, dashboardId);
				if(widgets != null)
				{
					List<JObject> json = new List<JObject>();

					var serializer = new JsonSerializer()
					{
						ContractResolver = new CamelCasePropertyNamesContractResolver()
					};

					foreach(Widget widget in widgets)
					{
						json.Add(ConvertToJson(widget, serializer));
					}

					return Ok(json);
				}

				return NotFound();
			}

			return Forbid();
		}

		[HttpGet("{id}")]
		public ActionResult<JObject> Get(int id)
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				return Ok(WidgetHandler.Get(accountId, id));
			}

			return Forbid();
		}

		[HttpPost]
		public ActionResult<int> Post(JObject json)
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				Widget widget = ConvertJson(json);
				if(widget != null)
				{
					return Ok(WidgetHandler.Create(accountId, widget));
				}

				return BadRequest();
			}

			return Forbid();
		}

		[HttpPut("{id}")]
		public ActionResult Put(int id, JObject json)
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				Widget widget = ConvertJson(json);
				if(widget != null)
				{
					WidgetHandler.Update(accountId, id, widget);
					return NoContent();
				}

				return BadRequest();
			}

			return Forbid();
		}

		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			int accountId;
			if(AccountController.TryGetAccountId(Request, out accountId))
			{
				WidgetHandler.Delete(accountId, id);
				return NoContent();
			}

			return Forbid();
		}

		private Widget ConvertJson(JObject json)
		{
			string widgetType = json.Value<string>("type");

			switch(widgetType)
			{
				case "SingleData":
					return json.ToObject<Widget>();
				case "Graph":
					return json.ToObject<GraphWidget>();
			}

			return null;
		}


		private JObject ConvertToJson(Widget widget, JsonSerializer serializer = null)
		{
			if(serializer == null)
			{
				serializer = JsonSerializer.CreateDefault();
			}

			if(widget is GraphWidget)
			{
				return JObject.FromObject((GraphWidget)widget, serializer);
			}

			return JObject.FromObject(widget, serializer);
		}
	}
}
