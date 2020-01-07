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
	public class MetricHandler
	{

		public static List<string> GetTagsByMetricAlias(int accountId, string alias)
		{
			using(var context = new CoreContext())
			{
				return (from m in context.Metrics
						where m.AccountId == accountId
							&& m.Alias == alias
						select m.Tag).ToList();
			}
		}

		public static List<Metric> GetAllByAliasAndTags(int accountId, string alias, HashSet<string> tags)
		{
			using(var context = new CoreContext())
			{
				return (from m in context.Metrics
						where m.AccountId == accountId 
							&& m.Alias == alias
							&& tags.Contains(m.Tag)
						select m)
						.OrderByDescending(m => m.Timestamp).ToList();
			}
		}

		public static List<Metric> GetAllByTags(int accountId, HashSet<string> tags)
		{
			using(var context = new CoreContext())
			{
				return (from m in context.Metrics
						where m.AccountId == accountId
							&& tags.Contains(m.Tag)
						select m)
						.OrderByDescending(m => m.Timestamp).ToList();
			}
		}

		public static Metric GetLatestByTags(int accountId, string alias, HashSet<string> tags)
		{
			using(var context = new CoreContext())
			{
				return (from m in context.Metrics
						where m.AccountId == accountId
							&& m.Alias == alias
							&& tags.Contains(m.Tag)
						select m)
						.OrderByDescending(m => m.Timestamp).FirstOrDefault();
			}
		}

		public static Metric GetLatest(int accountId, string alias)
		{
			using(var context = new CoreContext())
			{
				return context.Metrics.Where(m => m.Alias == alias && m.AccountId == accountId).OrderByDescending(m => m.Timestamp).FirstOrDefault();
			}
		}

		public static List<string> GetAliases(int accountId)
		{
			using(var context = new CoreContext())
			{
				return (from	m in context.Metrics
						where	m.AccountId == accountId
						select	m.Alias).Distinct().ToList();
			}
		}

		public static List<Metric> GetAllByAlias(int accountId, string alias)
		{
			using(var context = new CoreContext())
			{
				return context.Metrics.Where(w => w.Alias == alias && w.AccountId == accountId).ToList();
			}
		}

		public static List<Metric> GetAll(int accountId)
		{
			using(var context = new CoreContext())
			{
				return context.Metrics.Where(w => w.AccountId == accountId).ToList();
			}
		}

		public static Metric Get(int accountId, int metricId)
		{
			using(var context = new CoreContext())
			{
				Metric metric = context.Metrics.Find(metricId);
				if(metric != null && metric.AccountId == accountId)
				{
					return metric;
				}
			}

			return null;
		}

		public static int Create(Metric metric)
		{
			using(var context = new CoreContext())
			{
				context.Metrics.Add(metric);
				context.SaveChanges();

				return metric.Id;
			}
		}

		public static void Update(int accountId, int metricId, Metric metric)
		{
			using(var context = new CoreContext())
			{
				Metric current = context.Metrics.Find(metricId);
				if(current != null && current.AccountId == accountId)
				{
					current.Alias = metric.Alias;
					current.Number = metric.Number;
					current.Timestamp = metric.Timestamp;
					context.SaveChanges();
				}
			}
		}

		public static void Delete(int accountId, int metricId)
		{
			using(var context = new CoreContext())
			{
				Metric metric = context.Metrics.Find(metricId);
				if(metric != null && metric.AccountId == accountId)
				{
					context.Remove(metric);
					context.SaveChanges();
				}
			}
		}
	}
}
