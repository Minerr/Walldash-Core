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
	public class WidgetHandler
	{
		/*
		public static List<Tag> GetTagsByMetricAlias(int accountId, string alias)
		{
			using(var context = new CoreContext())
			{
				return (from mt in context.MetricTags
						where mt.Metric.AccountId == accountId
							&& mt.Metric.Alias == alias
						select mt.Tag).ToList();
			}
		}
		*/

		public static List<Widget> GetAllByDashboardId(int accountId, int dashboardId)
		{
			using(var context = new CoreContext())
			{
				return (from w in context.Widgets
				 join d in context.Dashboards on w.DashboardId equals d.Id
				 where w.DashboardId == dashboardId && d.AccountId == accountId
				 select w).ToList();
			}
		}

		public static List<Widget> GetAll(int accountId)
		{
			using(var context = new CoreContext())
			{
				return (from w in context.Widgets
						join d in context.Dashboards on w.DashboardId equals d.Id
						where d.AccountId == accountId
						select w).ToList();
			}
		}

		public static Widget Get(int accountId, int widgetId)
		{
			using(var context = new CoreContext())
			{
				return (from w in context.Widgets
						join d in context.Dashboards on w.DashboardId equals d.Id
						where w.Id == widgetId && d.AccountId == accountId
						select w).FirstOrDefault();
			}
		}

		public static int Create(int accountId, Widget widget)
		{
			using(var context = new CoreContext())
			{
				Dashboard dashboard = context.Dashboards.Find(widget.DashboardId);
				if(dashboard != null && dashboard.AccountId == accountId)
				{
					context.Widgets.Add(widget);
					context.SaveChanges();

					return widget.Id;
				}
			}

			return -1;
		}

		public static void Update(int accountId, int widgetId, Widget widget)
		{
			using(var context = new CoreContext())
			{
				Widget current = context.Widgets.Find(widgetId);
				if(current != null)
				{
					Dashboard dashboard = context.Dashboards.Find(current.DashboardId);
					if(dashboard.AccountId == accountId)
					{
						current.Alias = widget.Alias;
						current.MetricAlias = widget.MetricAlias;
						current.Type = widget.Type;
						current.Width = widget.Width;
						current.Height = widget.Height;

						if(widget is GraphWidget)
						{
							GraphWidget currentGraph = (GraphWidget)current;
							GraphWidget graph = (GraphWidget)widget;
							currentGraph.GraphType = graph.GraphType;
							currentGraph.GraphColor = graph.GraphColor;
							currentGraph.GraphValueX = graph.GraphValueX;
							currentGraph.GraphValueY = graph.GraphValueY;
						}

						context.SaveChanges();
					}
				}
			}
		}

		public static void Delete(int accountId, int widgetId)
		{
			using(var context = new CoreContext())
			{
				Widget widget = context.Widgets.Find(widgetId);
				if(widget != null)
				{
					Dashboard dashboard = context.Dashboards.Find(widget.DashboardId);
					if(dashboard.AccountId == accountId)
					{
						context.Remove(widget);
						context.SaveChanges();
					}
				}
			}
		}
	}
}
