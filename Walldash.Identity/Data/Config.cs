using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Models;

namespace Walldash.Identity.Data
{
	public static class Config
	{
		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),
			};
		}

		public static IEnumerable<ApiResource> GetApis()
		{
			return new List<ApiResource>
			{
				new ApiResource("walldash.api", "Walldash Public API")
			};
		}

		public static IEnumerable<Client> GetClients()
		{
			return new List<Client>
			{
				new Client
				{
					ClientId = "machine",

					// no interactive user, use the clientid/secret for authentication
					AllowedGrantTypes = GrantTypes.ClientCredentials,

					// secret for authentication
					ClientSecrets = { new Secret("r0RhaEtKRQKbSJ4H".Sha256()) },

					// scopes that client has access to
					AllowedScopes = { "walldash.api" }
				},
				// resource owner password grant client
				new Client
				{
					ClientId = "ro.client",
					AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

					// secret for authentication
					ClientSecrets = { new Secret("r0RhaEtKRQKbSJ4H".Sha256()) },

					AllowedScopes = { "walldash.api" }
				},
				// OpenID Connect hybrid flow client (Main)
				new Client
				{
					ClientId = "walldash.login",
					ClientName = "Walldash login",
					AllowedGrantTypes = GrantTypes.Hybrid,
				
					// secret for authentication
					ClientSecrets = { new Secret("r0RhaEtKRQKbSJ4H".Sha256()) },

					RedirectUris           = { "http://walldash.dk/signin-oidc" },
					PostLogoutRedirectUris = { "http://walldash.dk/signout-callback-oidc" },

					AllowedScopes =
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						"walldash.api"
					},

					AllowOfflineAccess = true
				},
				// JavaScript Client
				new Client
				{
					ClientId = "js",
					ClientName = "JavaScript Client",
					AllowedGrantTypes = GrantTypes.Code,
					RequirePkce = true,
					RequireClientSecret = false,

					RedirectUris =           { "http://walldash.dk/callback.html" },
					PostLogoutRedirectUris = { "http://walldash.dk/index.html" },
					AllowedCorsOrigins =     { "http://walldash.dk" },

					AllowedScopes =
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						"walldash.api"
					}
				}
			};
		}
	}

}
