using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Walldash.EntityFramework.Handlers;

namespace Walldash.PublicAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class AccountController : ControllerBase
	{
		private readonly ILogger<AccountController> _logger;

		public AccountController(ILogger<AccountController> logger)
		{
			_logger = logger;
		}

		public static bool TryGetAccountId(HttpRequest request, out int accountId)
		{
			accountId = 0;
			StringValues accountTokenValues;
			if(request.Headers.TryGetValue("Account-Token", out accountTokenValues))
			{
				string token = accountTokenValues.FirstOrDefault();
				if(!string.IsNullOrWhiteSpace(token))
				{
					accountId = AccountHandler.GetIdByToken(Guid.Parse(token));
					if(accountId > 0)
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}
