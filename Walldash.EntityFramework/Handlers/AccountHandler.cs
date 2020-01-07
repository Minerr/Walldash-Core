using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Walldash.Domain.Model;
using Walldash.EntityFramework.DataContext;

namespace Walldash.EntityFramework.Handlers
{
	public class AccountHandler
	{
		public static int GetIdByToken(Guid token)
		{
			using(var context = new CoreContext())
			{
				Account account = context.Accounts.Where(a => a.Token == token).FirstOrDefault();
				if(account != null)
				{
					return account.Id;
				}
			}

			return -1;
		}

		public static Account Get(int accountId)
		{
			using(var context = new CoreContext())
			{
				return context.Accounts.Find(accountId);
			}
		}
	}
}
