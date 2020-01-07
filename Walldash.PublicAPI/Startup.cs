using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Walldash.PublicAPI
{
	public class Startup
	{
		private readonly string AllowSpecificOrigins = "publicApiCORS";
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers()
					.AddNewtonsoftJson();

			services.AddOpenApiDocument();

			// MOST BE BEFORE AUTH
			services.AddCors(options =>
			{
				options.AddPolicy(AllowSpecificOrigins,
				builder =>
				{
					builder.WithOrigins("http://walldash.dk",
										"http://localhost:3000")
								.AllowAnyHeader()
								.AllowAnyMethod();
				});
			});

			// Auth0: 1. Add Authentication Services
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.Authority = "https://walldash.eu.auth0.com/";
				options.Audience = "walldash.dk/api/";
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseHttpsRedirection();

			// MOST BE BEFORE AUTH AND BETWEEN ROUTING/ENDPOINT
			app.UseCors(AllowSpecificOrigins);

			// Auth0: 2. Enable authentication middleware
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});

			app.UseOpenApi();
			app.UseSwaggerUi3();
		}
	}
}
