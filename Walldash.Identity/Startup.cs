using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Walldash.Identity.Data;

namespace Walldash.Identity
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			var connectionString = Configuration.GetConnectionString("WalldashDb");

			// configure identity server with in-memory users, but EF stores for clients and resources
			var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;


			services.AddDbContext<MainDbContext>(options =>
				options.UseSqlServer(connectionString));

			services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<MainDbContext>()
				.AddDefaultTokenProviders();

			services.AddIdentityServer()
				.AddAspNetIdentity<User>()
				// this adds the config data from DB (clients, resources, CORS)
				.AddConfigurationStore(options =>
				{
					options.ConfigureDbContext = builder =>
						builder.UseSqlServer(connectionString,
							sql => sql.MigrationsAssembly(migrationsAssembly));
				})
				// this adds the operational data from DB (codes, tokens, consents)
				.AddOperationalStore(options =>
				{
					options.ConfigureDbContext = builder =>
						builder.UseSqlServer(connectionString,
							sql => sql.MigrationsAssembly(migrationsAssembly));

					// this enables automatic token cleanup. this is optional.
					options.EnableTokenCleanup = true;
					options.TokenCleanupInterval = 3600; // interval in seconds (default is 3600)
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			InitializeDatabase(app);

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}


		private void InitializeDatabase(IApplicationBuilder app)
		{
			using(var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

				var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

				context.Database.Migrate();
				if(!context.Clients.Any())
				{
					foreach(var client in Config.Clients)
					{
						context.Clients.Add(client.ToEntity());
					}
					context.SaveChanges();
				}

				if(!context.IdentityResources.Any())
				{
					foreach(var resource in Config.IdentityResources)
					{
						context.IdentityResources.Add(resource.ToEntity());
					}
					context.SaveChanges();
				}

				if(!context.ApiResources.Any())
				{
					foreach(var resource in Config.ApiResources)
					{
						context.ApiResources.Add(resource.ToEntity());
					}
					context.SaveChanges();
				}
			}
		}
	}
}
