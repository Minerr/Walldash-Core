using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;
using OpenIddict.Core;
using OpenIddict.EntityFrameworkCore.Models;
using OpenIddict.Validation;
using Walldash.OpenIdDict.Data;

namespace Walldash.OpenIdDict
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			services.AddDbContext<AuthDbContext>(options =>
			{
				// Configure the context to use Microsoft SQL Server.
				options.UseSqlServer(Configuration.GetConnectionString("WalldashDb"));

				// Register the entity sets needed by OpenIddict
				options.UseOpenIddict();
			});

			// Register the Identity services.
			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<AuthDbContext>()
				.AddDefaultTokenProviders();

			// Configure Identity to use the same JWT claims as OpenIddict instead
			// of the legacy WS-Federation claims it uses by default (ClaimTypes),
			// which saves you from doing the mapping in your authorization controller.
			services.Configure<IdentityOptions>(options =>
			{
				options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
				options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
				options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
			});

			services.AddOpenIddict()
				.AddCore(options =>
				{
					// Register the Entity Framework stores.
					options.UseEntityFrameworkCore()
							.UseDbContext<AuthDbContext>();
				})
				// Register the OpenIddict server handler.
				.AddServer(options =>
				{
					// Enable the token endpoint.
					options.EnableTokenEndpoint("/connect/token");

					// Enable the client credentials flow.
					options.AllowClientCredentialsFlow();

					// During development, you can disable the HTTPS requirement.
					options.DisableHttpsRequirement();

					// Note: to use JWT access tokens instead of the default
					// encrypted format, the following lines are required:
					//
					// options.UseJsonWebTokens();
					// options.AddEphemeralSigningKey();
				})

				// Register the OpenIddict validation handler.
				// Note: the OpenIddict validation handler is only compatible with the
				// default token format or with reference tokens and cannot be used with
				// JWT tokens. For JWT tokens, use the Microsoft JWT bearer handler.
				.AddValidation();

			services.AddAuthentication(options =>
			{
				options.DefaultScheme = OpenIddictValidationDefaults.AuthenticationScheme;
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseStaticFiles();
			app.UseRouting();

			app.UseAuthentication();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});

			AddScopesAsync(app.ApplicationServices).GetAwaiter().GetResult();
		}

		private async Task AddScopesAsync(IServiceProvider services)
		{
			// Create a new service scope to ensure the database context
			// is correctly disposed when this methods returns.
			using(var scope = services.CreateScope())
			{
				var provider = scope.ServiceProvider;
				var context = provider.GetRequiredService<AuthDbContext>();
				await context.Database.EnsureCreatedAsync();
				var manager = provider.GetRequiredService<OpenIddictApplicationManager<OpenIddictApplication>>();

				var scopes = new List<OpenIddictApplicationDescriptor>();
				scopes.Add(new OpenIddictApplicationDescriptor
				{
					ClientId = "console",
					ClientSecret = "388D45FA-B36B-4988-BA59-B187D329C207",
					DisplayName = "My client application",
					Permissions =
					{
						OpenIddictConstants.Permissions.Endpoints.Token,
						OpenIddictConstants.Permissions.GrantTypes.ClientCredentials
					}
				});

				foreach(var s in scopes)
				{
					var application = await manager.FindByClientIdAsync(s.ClientId);
					if(application == null)
					{
						await manager.CreateAsync(s);
					}
				}
			}
		}
	}
}
