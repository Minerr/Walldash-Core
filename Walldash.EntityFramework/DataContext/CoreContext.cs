using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Walldash.Domain.Model;

namespace Walldash.EntityFramework.DataContext
{
	public class CoreContext : DbContext
	{
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Dashboard> Dashboards { get; set; }
		public DbSet<Widget> Widgets { get; set; }
		public DbSet<GraphWidget> GraphWidgets { get; set; }
		public DbSet<Metric> Metrics { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			string db = @"Data Source=mssql15.unoeuro.com;Initial Catalog=mfabricius_dk_db_walldash;User ID=mfabricius_dk;Password=sysADMIN9Sk9ofN3;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			options.UseSqlServer(db);
		}

		// Specify DbSet properties etc
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Accounts
			modelBuilder.Entity<Account>()
				.HasAlternateKey(p => p.Token);

			modelBuilder.Entity<Account>()
				.Property(p => p.Token)
				.HasDefaultValueSql("newid()");

			modelBuilder.Entity<Account>()
				.HasMany(p => p.Dashboards)
				.WithOne()
				.HasForeignKey(p => p.AccountId);

			modelBuilder.Entity<Account>()
				.HasMany(p => p.Metrics)
				.WithOne()
				.HasForeignKey(p => p.AccountId);


			// Dashboard
			modelBuilder.Entity<Dashboard>()
				.Property(p => p.AccountId)
				.IsRequired();

			modelBuilder.Entity<Dashboard>()
				.HasMany(p => p.Widgets)
				.WithOne()
				.HasForeignKey(p => p.DashboardId);

			modelBuilder.Entity<Dashboard>()
				.Property(p => p.Columns)
				.IsRequired()
				.HasDefaultValue(6);

			modelBuilder.Entity<Dashboard>()
				.Property(p => p.Rows)
				.IsRequired()
				.HasDefaultValue(3);

			modelBuilder.Entity<Dashboard>()
				.Property(p => p.BackgroundColor)
				.IsRequired()
				.HasDefaultValue("#e7ecf2");

			modelBuilder.Entity<Dashboard>()
				.Property(p => p.NavbarColor)
				.IsRequired()
				.HasDefaultValue("#0f1723");


			// Widgets
			modelBuilder.Entity<Widget>()
				.Property(p => p.DashboardId)
				.IsRequired();

			modelBuilder.Entity<Widget>()
				.HasDiscriminator<string>("widget_type")
				.HasValue<Widget>("widget_base")
				.HasValue<GraphWidget>("widget_graph");

			modelBuilder.Entity<Widget>()
				.Property(p => p.BackgroundColor)
				.IsRequired()
				.HasDefaultValue("#fff");

			modelBuilder.Entity<Widget>()
				.Property(p => p.TextColor)
				.IsRequired()
				.HasDefaultValue("#000");

			modelBuilder.Entity<Widget>()
				.Property(p => p.TagFilter)
				.HasConversion(
					w => string.Join(',', w),
					w => w.Split(",", StringSplitOptions.RemoveEmptyEntries)
				);


			// Metrics
			modelBuilder.Entity<Metric>()
				.Property(p => p.AccountId)
				.IsRequired();

			modelBuilder.Entity<Metric>()
				.Property(p => p.Timestamp)
				.HasDefaultValueSql("SYSDATETIMEOFFSET()");

			modelBuilder.Entity<Metric>()
				.Property(p => p.Tag);
		}
	}
}
