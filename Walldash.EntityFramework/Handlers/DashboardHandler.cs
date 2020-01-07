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
	public class DashboardHandler
	{
		public static List<Dashboard> GetAll(int accountId)
		{
			using(var context = new CoreContext())
			{
				return context.Dashboards.Where(d => d.AccountId == accountId).ToList();
			}
		}

		public static Dashboard Get(int accountId, int dashboardId)
		{
			using(var context = new CoreContext())
			{
				return context.Dashboards.Single(d => d.AccountId == accountId && d.Id == dashboardId);
			}
		}

		public static int Create(Dashboard dashboard)
		{
			using(var context = new CoreContext())
			{
				context.Dashboards.Add(dashboard);
				context.SaveChanges();

				return dashboard.Id;
			}
		}

		public static void Update(int dashboardId, Dashboard dashboard)
		{
			using(var context = new CoreContext())
			{
				Dashboard current = context.Dashboards.Find(dashboardId);
				if(current != null && current.AccountId == dashboard.AccountId)
				{
					current.Alias = dashboard.Alias;
					context.SaveChanges();
				}
			}
		}

		public static void Delete(int accountId, int dashboardId)
		{
			using(var context = new CoreContext())
			{
				Dashboard dashboard = context.Dashboards.Find(dashboardId);
				if(dashboard != null && dashboard.AccountId == accountId)
				{
					context.Remove(dashboard);
					context.SaveChanges();
				}
			}
		}
	}
}
